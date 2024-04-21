using Core.Extensions;
using System.Data;
using System;
using System.Linq;
using Core.Utility;
using System.Linq.Expressions;
using System.Collections.Generic;
using Core.Attributes;
using Core.Attributes.Validators;
using Core.Utility.Language;
using Core.DataBase.ADOProvider.Attributes;
using Core.Reflectors;

namespace Core.DataBase.ADOProvider
{
    public partial class ModelBase : IModelDataBaseService
    {
        #region IDataBaseService
        private IDataBaseService dataBaseService = null;

        /// <summary>
        /// Thiết lập DataBaseService
        /// </summary>
        /// <param name="dataBaseService"></param>
        public void SetDataBaseService(IDataBaseService dataBaseService)
        {
            this.dataBaseService = dataBaseService;
        }

        /// <summary>
        /// Cung cấp IDataBaseService mà model muốn sử dụng truy vấn vào db 
        /// </summary>
        /// <returns></returns>
        public virtual IDataBaseService GetDataBaseService()
        {
            return null;
        }

        /// <summary>
        /// Một Service cần thực hiện xuống cơ sở dữ liệu
        /// </summary>
        protected IDataBaseService DataBaseService
        {
            get
            {
                // Lấy ra service cần dùng cho Model
                if (dataBaseService.IsNull()) dataBaseService = GetDataBaseService();

                // return
                return dataBaseService;
            }
        }
        #endregion
        #region protected
        protected DataTable ExeStore(string store, params object[] values)
        {
            return DoExeWith(inputs => DataBaseService.ExeStore(store, inputs.T1), store, values);
        }

        public int ExeStoreNoneQuery(string store, params object[] values)
        {
            return DoExeWith(inputs => DataBaseService.ExeStoreNoneQuery(store, inputs.T1), store, values);
        }

        protected Pair<DataTable, Param> ExeStoreWithOutput(string store, params object[] values)
        {
            return DoExeWith(inputs => DataBaseService.ExeStoreToTable(store, inputs.T1, inputs.T2), store, values);
        }

        protected Pair<int, Param> ExeStoreNoneQueryWithOutput(string store, params object[] values)
        {
            return DoExeWith(inputs => DataBaseService.ExeStoreNoneQuery(store, inputs.T1, inputs.T2), store, values);
        }

        public void ParseFrom(DataRow dr)
        {            
            this.Parse(dr, false);
        }
        #endregion
        #region private static
        private T DoExeWith<T>(Func<Pair<Param, Param>, T> func, string store, params object[] values)
        {
            // Nếu không có service thì trả ra mặc định
            if (this.DataBaseService.IsNull()) return default(T);

            // Nếu mảng rỗng thì khởi tạo một phần tử rỗng
            if (values.IsNull()) values = new object[] { null };

            // Lấy ra Param
            var param = GetParamsFromStore(store, values);

            // Thực thi
            return func(param);
        }
         
        private Pair<Param, Param> GetParamsFromStore(string store, params object[] values)
        {
            // Nếu không truyền tập giá trị của param thì lấy tất cả giá trị thuộc tính của đối tượng
            if (values.Length == 0) return DoGetParamsFromStore(store, (s, i) => this.Eval(s));

            // Ngược lại tạo Param theo thứ tự như trong gọi thủ tục
            return DoGetParamsFromStore(store, (s, i) => values[i]);
        }

        private Pair<Param, Param> DoGetParamsFromStore(string store, Func<string, int, object> func)
        {
            // Lấy ra các Params từ Cache
            var autoParams = GetParamInfo(store);

            // Tạo ParamInputs tương ứng
            var paramInputs = new Param();

            // Tạo ParamOutputs tương ứng
            var paramOutputs = new Param();

            // Thiết lập Param
            for (int i = 0; i < autoParams.Rows.Count; i++)
                switch (autoParams.Rows[i][1].ToString())
                {
                    // Tạo Param Output
                    case "INOUT": DoCreateParamItem(paramOutputs, autoParams.Rows[i], i, (s, index) => func(s, index)); break;

                    // Tạo Param Input
                    default: DoCreateParamItem(paramInputs, autoParams.Rows[i], i, (s, index) => func(s, index)); break;
                }

            // return
            return new Pair<Param, Param> { T1 = paramInputs, T2 = paramOutputs };
        }
        
        private void DoCreateParamItem(Param p, DataRow row, int index, Func<string, int, object> func)
        {
            // name
            string s = row[0].ToString();

            // Biến lưu tên param
            string paramName = string.Empty;

            // Tạo Param
            p[paramName = s.TrimStart('@'), row[3].To<string>(), row[2].IsNull() ? null : new Nullable<int>(row[2].To<int>())] = func(paramName, index);
        }

        private DataTable GetParamInfo(string store)
        {
            // Lấy ra các Params từ Cache
            var p = new Param { };
            p["Store"] = store;
            return DataBaseService.ExeSql("SELECT PARAMETER_NAME, PARAMETER_MODE, CHARACTER_MAXIMUM_LENGTH, DATA_TYPE FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = @Store", p);
        }

        /// <summary>
        /// Hàm rỗng
        /// Mục đích thông báo những Parameter cần khởi tạo cho câu lệnh truy xuất đến CSDL
        /// </summary>
        /// <param name="values"></param>
        protected void With(params object[] values) { }
        #endregion
        public virtual void SaveForeign()
        {
            Upsert();
        }
    }

    public class ModelBase<T> : ModelBase where T : ModelBase, new()
    {
        public static T Inst { get { return Singleton<T>.Inst; } }
        public static T New { get { return Singleton<T>.New; } }

        public T InService(IDataBaseService service)
        {
            SetDataBaseService(service);
            return this as T;
        }
        public DataTable Select(Expression<Func<T, bool>> predicate, int top = 0)
        {
            // Biến lưu thứ tự của Param
            int i = 0;

            // Phân tích chuỗi mệnh đề where
            var pre = AnalyticQuery(predicate.Body.As<BinaryExpression>(), ref i);

            // command
            var command = "{0} {1}".Frmat(this.Builder.BuildSelectAllField(top), pre.T1.IsNotNull() ? "WHERE {0}".Frmat(pre.T1) : string.Empty);
            return this.DataBaseService.ExeSql(command, pre.T2);
        }
        public List<T> SelectToList(Expression<Func<T, bool>> predicate, int top = 0) { return Select(predicate).ToList<T>(false); }
        public List<TEntity> SelectToList<TEntity>(Expression<Func<T, bool>> predicate, int top = 0) where TEntity : new() { return Select(predicate).ToList<TEntity>(false); }

        public IEnumerable<T> SelectCastToList(Expression<Func<T, bool>> predicate, int top = 0) { return Select(predicate).Cast<T>(false); }
        public IEnumerable<TEntity> SelectCastToList<TEntity>(Expression<Func<T, bool>> predicate, int top = 0) where TEntity : new() { return Select(predicate).Cast<TEntity>(false); }

        public bool Exists(Expression<Func<T, bool>> predicate) { return SelectToList(predicate, 1).Count != 0; }
        public T SelectFirst(Expression<Func<T, bool>> predicate) { return SelectToList(predicate, 1).FirstOrDefault(); }
        public TItem SelectFirst<TItem>(Expression<Func<T, bool>> predicate) where TItem : new() { return SelectToList<TItem>(predicate, 1).FirstOrDefault(); }
        public TValue SelectFirstValue<TValue>(string store, params object[] values)
        {
            var data = ExeStore(store, values);
            if (data.Rows.Count == 0) return default(TValue);

            return data.Rows[0][0].To<TValue>();
        }
        public bool IsExists<TKey>(Expression<Func<T, TKey>> id, params Expression<Func<T, object>>[] checks)
        {
            var pre = new Pair<string, Param>();
            pre.T2 = new Param();

            var fieldCheckExists = checks.Select(check => check.GetName()).ToArray();
            pre.T1 = fieldCheckExists.JoinString(field => 
            {
                pre.T2[field] = this.Eval(field);
                return field + " = @" + field;
            }, " AND ");

            var idName = id.GetName();

            var command = "{0} {1}".Frmat(Builder.BuildSelectAllField(1), pre.T1.IsNotNull() ? "WHERE {0}".Frmat(pre.T1) : string.Empty);
            var first = this.DataBaseService.ExeSql(command, pre.T2).ToList<T>().FirstOrDefault();

            return first != null && !Equals(first.Eval(idName), this.Eval(idName));
        }
        public void ThrowIfExists<TKey>(Expression<Func<T, TKey>> id, string msg, params Expression<Func<T, object>>[] checks)
        {
            if (!IsExists(id, checks)) return;
            var property = ModelType.GetProperty(checks[0].GetName());
            var propertyInfo = property.GetAttribute<PropertyInfoAttribute>();
            throw new ValidatorException(property.Name, msg.IsNotNull() ? msg : LanguageHelper.GetLabel("{0} này đã tồn tại").Frmat(propertyInfo == null || propertyInfo.Name.IsNull() ? property.Name : propertyInfo.Name));
        }
        public void ThrowIfExists<TKey>(Expression<Func<T, TKey>> id, params Expression<Func<T, object>>[] checks)
        {
            ThrowIfExists(id, string.Empty, checks);
        }
        protected Pair<List<T>, Param> ExeStoreToListWithOutput(string store, params object[] values)
        {
            var result = ExeStoreWithOutput(store, values);
            return new Pair<List<T>, Param> { T1 = result.T1.ToList<T>(), T2 = result.T2 };
        }
        protected Pair<IEnumerable<T>, Param> ExeStoreCastToListWithOutput(string store, params object[] values)
        {
            var result = ExeStoreWithOutput(store, values);
            return new Pair<IEnumerable<T>, Param> { T1 = result.T1.Cast<T>(false), T2 = result.T2 };
        }

        public List<T> ExeStoreToList(string store, params object[] values) { return ExeStoreToList<T>(store, values); }
        public IEnumerable<T> ExeStoreCastToList(string store, params object[] values) { return ExeStoreCastToList<T>(store, values); }

        public List<TItem> ExeStoreToList<TItem>(string store, params object[] values) where TItem : new() { return ExeStore(store, values).ToList<TItem>(false); }
        public IEnumerable<TItem> ExeStoreCastToList<TItem>(string store, params object[] values) where TItem : new() { return ExeStore(store, values).Cast<TItem>(false); }

        public T ExeStoreToFirst(string store, params object[] values) { return ExeStoreCastToList(store, values).FirstOrDefault(); }
        public TItem ExeStoreToFirst<TItem>(string store, params object[] values) where TItem : new() { return ExeStoreCastToList<TItem>(store, values).FirstOrDefault(); }

        public List<T> GetAllToList() { return GetAll().ToList<T>(false); }
        public IEnumerable<T> GetAllCastToList() { return GetAll().Cast<T>(false); }

        public List<TItem> GetAllToList<TItem>() where TItem : new() { return GetAll().ToList<TItem>(false); }
        public T GetFirst() { return GetAllCastToList().FirstOrDefault(); }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            // Biến lưu thứ tự các param
            int i = 0;

            // Phân tích chuỗi mệnh đề where
            var pre = AnalyticQuery(predicate.Body.As<BinaryExpression>(), ref i);

            // Command
            var command = "DELETE t FROM {0} t {1}".Frmat(Builder.TableInfo.TableName, pre.T1.IsNotNull() ? "WHERE {0}".Frmat(pre.T1) : string.Empty);

            // Thực thi lệnh xóa
            return DataBaseService.ExeSqlNoneQuery(command, pre.T2);
        }
        public int Update(Expression<Func<T, bool>> predicateSet, Expression<Func<T, bool>> predicate)
        {
            // Biến lưu thứ tự các Param
            int i = 0;

            // Phân tích mệnh đề Set
            var set = AnalyticSet(predicateSet.Body.As<BinaryExpression>(), ref i);

            // Phân tích mệnh đề
            var where = AnalyticQuery(predicate.Body.As<BinaryExpression>(), ref i, set.T2);

            // Command Sql
            var command = "UPDATE t SET {0} FROM {1} t {2}".Frmat(set.T1, Builder.TableInfo.TableName, where.T1.IsNotNull() ? "WHERE {0}".Frmat(where.T1) : string.Empty);

            // return số bản ghi được cập nhật
            return DataBaseService.ExeSqlNoneQuery(command, set.T2);
        }

        private Pair<string, Param> AnalyticQuery(BinaryExpression be, ref int i, Param param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Where, Value = Param
            var result = new Pair<string, Param> { T1 = string.Empty };

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpression
            result.T2 = param.IsNull() ? new Param() : param;

            // Nếu biểu thức bên trái là MemberExpression
            if (be.Left.Is<MemberExpression>())
            {
                // Tên field
                string name = be.Left.As<MemberExpression>().Member.Name;

                // Nếu như bên phải là một biểu thức
                if (be.Right.Is<BinaryExpression>()) result.T1 = "{0}.{1} {3} {2}".Frmat(prefix, name, Analytic(be.Right.As<BinaryExpression>(), ref i, result.T2, prefix).T1, be.NodeType.GetExpression());

                else
                {
                    // Giá trị
                    object value = be.Right.GetValue();

                    // Khởi tạo Param
                    result.T2["{0}_{1}".Frmat(name, i)] = value;

                    // Tạo biểu thức cho mệnh đề where
                    result.T1 = "{3}.{0} {2} @{0}_{1}".Frmat(name, i, be.NodeType.GetExpression(), prefix);

                    // Tăng biến i
                    i++;
                }
            }
            else
            {
                // Biểu thức bên trái
                var rl = AnalyticQuery(be.Left.As<BinaryExpression>(), ref i, result.T2, prefix);

                // be.Left.As<UnaryExpression>().Operand is MemberExpression

                // Biểu thức bên phải
                var rr = AnalyticQuery(be.Right.As<BinaryExpression>(), ref i, result.T2, prefix);

                // Nối hai biểu thức với nhau
                result.T1 = "({0}) {2} ({1})".Frmat(rl.T1, rr.T1, be.NodeType.GetExpression());
            }

            // return kết quả
            return result;
        }
        private Pair<string, Param> AnalyticSet(BinaryExpression be, ref int i, Param param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Mệnh đề Set, Value = Param
            var result = new Pair<string, Param> { T1 = string.Empty };

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpression
            result.T2 = param.IsNull() ? new Param() : param;

            // Nếu biểu thức bên trái là MemberExpression
            if (be.Left.Is<MemberExpression>())
            {
                // Tên field
                string name = be.Left.As<MemberExpression>().Member.Name;

                // Nếu right là một biểu thức thì phân tích
                if (be.Right.Is<BinaryExpression>()) result.T1 = "{0}.{1} = {2}".Frmat(prefix, name, Analytic(be.Right.As<BinaryExpression>(), ref i, result.T2, prefix).T1);

                // Nếu là Constant
                else
                {
                    // Giá trị
                    object value = be.Right.GetValue();

                    // Khởi tạo Param
                    result.T2["{0}_{1}".Frmat(name, i)] = value;

                    // Thiết lập biểu thức
                    result.T1 = "{2}.{0} = @{0}_{1}".Frmat(name, i, prefix);

                    // Tăng i
                    i++;
                }
            }
            else
            {
                // Biểu thức bên trái
                var rl = AnalyticSet(be.Left.As<BinaryExpression>(), ref i, result.T2, prefix);

                // Biểu thức bên phải
                var rr = AnalyticSet(be.Right.As<BinaryExpression>(), ref i, result.T2, prefix);

                // Ghép các mệnh đề
                result.T1 += "{0},{1},".Frmat(rl.T1, rr.T1);
            }

            // Trim dấu , cuối cùng
            result.T1 = result.T1.TrimEnd(',');

            // return kết quả
            return result;
        }
        private Pair<string, Param> Analytic(BinaryExpression be, ref int i, Param param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Mệnh đề Set, Value = Param
            var result = new Pair<string, Param> { T1 = string.Empty };

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpression
            result.T2 = param.IsNull() ? new Param() : param;

            // Biểu thức trái
            var rl = AnalyticExpression(be.Left, ref i, result.T2, prefix);

            // Biểu thức phải
            var rr = AnalyticExpression(be.Right, ref i, result.T2, prefix);

            // Ghép biểu thức trái và phải với nhau
            result.T1 = "({0} {2} {1})".Frmat(rl.T1, rr.T1, be.NodeType.GetExpression());

            // return kết quả
            return result;
        }
        private Pair<string, Param> AnalyticExpression(Expression ex, ref int i, Param param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Mệnh đề Set, Value = Param
            var result = new Pair<string, Param> { T1 = string.Empty };

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpression
            result.T2 = param.IsNull() ? new Param() : param;

            // Nếu là MemberExpression
            if (ex.Is<MemberExpression>())
            {
                // Gán thành MemberExpression
                var me = ex.As<MemberExpression>();

                // Nếu Base của me là một Constants thì tạo param
                if (me.Expression.Is<ConstantExpression>()) CreateParamFromExpression(me, result, ref i);

                // Ngược lại Format như một field của bảng
                else result.T1 = "{0}.{1}".Frmat(prefix, me.Member.Name);
            }
            // Nếu không thì lại phân tích cả biểu thức
            else if (ex.Is<BinaryExpression>()) result.T1 = Analytic(ex.As<BinaryExpression>(), ref i, result.T2, prefix).T1;

            // Ngược lại thì coi như một biểu thức trả ra hằng số
            else CreateParamFromExpression(ex, result, ref i);

            // return kết quả
            return result;
        }
        private void CreateParamFromExpression(Expression ex, Pair<string, Param> result, ref int i)
        {
            result.T2["ShP{0}".Frmat(i)] = ex.GetValue();
            result.T1 = "@ShP{0}".Frmat(i);
            i++;
        }
    }

    public interface IModelDataBaseService
    {
        IDataBaseService GetDataBaseService();
        void SetDataBaseService(IDataBaseService dataBaseService);
    }

    public interface IModel<TKey> { TKey Key { set; get; } }
    public interface IModelForeign<TKeyForeign>
    {
        TKeyForeign KeyForeign { set; get; }
        int Stt { set; get; }
        bool Editted { set; get; }
        void SaveForeign();
    }
    public interface IModelForeign<TKeyForeign, TEntity> : IModelForeign<TKeyForeign>
    {
        List<TEntity> GetDetails(TKeyForeign key);
    }
    public interface IModelForeignValidate
    {
        void ValidateDetail();
    }

    public interface IAuthor
    {
        int CreatedByUserId { set; get; }
        DateTime CreatedDate { set; get; }
        int UpdatedByUserId { set; get; }
        DateTime UpdatedDate { set; get; }
    }

    public interface IAlias : IAliasUrl { string NameForAlias { get; } }
    public interface IAliasUrl { string Alias { set; get; } }
    public interface IEmpty { bool IsEmpty { get; } }

    public static class IModelExtension
    {
        public static ModelListSave<T> SplitItems<T, TKey>(this IEnumerable<T> newItems, Func<List<T>> oldItems, Func<bool> needDelete)
            where T : IEmpty, IModel<TKey>
        {
            return newItems.Where(item => !item.IsEmpty).ToList().SplitItems(oldItems, needDelete, t => t.Key);
        }

        public static void Save <T, TKey>(this ModelListSave<T> data, 
            TKey key,
            IDataBaseService service,
            List<LogEntity> logEntities,

            Action<T> action = null,
            Action<T> afterSave = null,
            Func<T, bool> nSave = null,
            Action<T> afterDelete = null
            )
            where T : ModelBase, IModelForeign<TKey>, IModel<TKey>, new()
        {
            data.Upserts.Select((t, i) =>
            {
                if (Equals(t.Key, default(TKey)) || t.Editted || (nSave != null && nSave(t)))
                {
                    t.KeyForeign = key;
                    t.Stt = i;
                    action?.Invoke(t);
                    t.SetDataBaseService(service);
                    t.SaveForeign();
                    afterSave?.Invoke(t);
                }
                return t;
            }).Count();
            if (data.Deletes != null) data.Deletes.ForEach(t =>
            {
                t.SetDataBaseService(service);
                t.Delete();
                afterDelete?.Invoke(t);
            });

            if (logEntities == null) return;

            //// Các bản ghi thêm mới
            // Chỉ ghi log thêm mới lúc cập nhật đơn hàng
            if (data.Olds != null)
                data.Upserts.FindNewItems(data.Olds, t1 => t1.Key, t3 => t3.Key).ForEach(t1 => logEntities.Add(LogEntity.LogEntityChange(t1, null)));
            //else
            //    data.T1.ForEach(t1 => logEntities.Add(LogEntity.LogEntityChange(t1, null)));

            // Các bản ghi được chỉnh sửa
            if (data.Olds != null)
                data.Upserts.SJoin(data.Olds, t1 => t1.Key, t3 => t3.Key, (t1, t3) =>
                {
                    var log = LogEntity.LogEntityChange(t1, t3);
                    if (log.Details.Count != 0) logEntities.Add(log);
                });

            // Các bản ghi bị xóa đi
            if (data.Deletes != null)
                data.Deletes.ForEach(t2 => logEntities.Add(LogEntity.LogEntityDelete(t2)));
        }
    }

    public interface ILanguage
    {
        int LanguageId { set; get; }
    }

    public interface ILanguage<TLanguage, TKey, TKeyForeign> : ILanguage
    {
        TKeyForeign KeyLanguage { get; set; }
        List<TLanguage> GetEntityLanguages(TKey key);
    }

    public static class ILanguageExtension
    {
        public static void Copy<TLanguage>(this TLanguage to, TLanguage from) where TLanguage : ILanguage
        {
            var properties = ReflectTypeListProperty.Inst[typeof(TLanguage)];
            properties.ForEach(p =>
            {
                var vTo = Convert.ToString(p.GetValue(to));
                if (vTo.IsNotNull()) return;

                p.SetValue(to, p.GetValue(from));
            });
        }
    }

    public interface ICommonSystem
    {
        bool IsSystem { get; }
    }

    public interface IPageMeta
    {
        string Title { get; }
        string MetaKeywords { get; }
        string MetaDescription { get; }
        string Image { get; }
    }
    public interface IReportSummary
    {
        int Total { set; get; }
        string TitleSummary { set; get; }
    }
    public interface IVersion
    {
        int Version { set; get; }
    }
}