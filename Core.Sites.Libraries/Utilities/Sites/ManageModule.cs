#region Using
using System;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using Aspose.Cells;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites.Reports;
using Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders;
using Core.Utility;
using Core.Extensions;
using Core.Reflectors;
using Core.Web.WebBase;
using Core.Web.Extensions;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Attributes;
using Core.Business.Entities;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using Core.Utility.Language;
using Newtonsoft.Json;
#endregion
namespace Core.Sites.Libraries.Utilities.Sites
{
    #region Module Base
    public abstract class ManageModule<TEntity, TProvider> : FormEditModule<TEntity, TProvider>, IFormGridTarget, IManageModule
    where TEntity : class, new()
    where TProvider : ManageModuleProviderBase<TEntity>, new()
    {
        private readonly TEntity EntityEmpty = new TEntity();

        public ManageModule() : base() { }
        public string GetTableEntityName() => EntityEmpty is ModelBase ? EntityEmpty.As<ModelBase>().GetEntityName() : string.Empty;
        public string GetTableFieldKeyName() => EntityEmpty is ModelBase ? EntityEmpty.As<ModelBase>().GetFieldKeyName() : string.Empty;

        #region Tải dữ liệu trên lưới
        public void LoadData()
        {
            var data = DoLoadData();
            this.SetData("objects", data.T2);
            ResponseMessage.Current.RecordsTotal = data.T1;
        }
        private Pair<int, object> DoLoadData()
        {
            var start = this.Query<int>("start");
            var length = this.Query<int>("length");

            var columnOrder = this.Query<int>("order[0][column]");
            var orderDir = this.Query<string>("order[0][dir]");
            var fieldOrder = this.Query<string>("columns[" + columnOrder + "][data]");

            Provider.DataSource.Start = start;
            Provider.DataSource.Length = length;
            Provider.DataSource.FieldOrder = fieldOrder;
            Provider.DataSource.Dir = orderDir;

            var source = Provider.DataSource.GetData();
            var summary = Provider.DataSource.GetDataSummary();

            if (summary.Summaries != null)
                this.SetData("ReportSummary", summary.Summaries);

            // Điền dữ liệu form tìm kiếm
            return new Pair<int, object>
            {
                T2 = source,
                T1 = summary.Total
            };
        }
        #endregion
        #region Xóa hoặc cập nhật giá trị trên một dòng
        public virtual void UpdateField() => Provider.UpdateField(ParseEntity(false), this.Query<string>("field"));
        public virtual void Delete()
        {
            if (!CanDelete) return;
            var t = ParseEntity(false);
            Provider.DoDeleteInTransaction(t);
        }
        protected virtual bool CanDelete { get { return Permission.CanDelete(); } }
        #endregion
        #region Thực hiện hiển thị Form cập nhật và cập nhật dữ liệu
        public void Edit()
        {
            if (CanShowItem)
            {
                var form = LoadControlEdit();
                var entity = Provider.GetByKey(ParseEntity(false)) ?? new TEntity();
                form.As<PortalModule<TEntity>>().Entity = entity;

                if (entity.Is<ICompanyNeedValidate>() && entity.As<ICompanyNeedValidate>().CompanyId == 0)
                    entity.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCurrentCompanyId();

                var isAddNew = this.Query<bool>("FormAdd");

                // Kiểm tra xem Module này có thể mở cấu hình form cập nhật hay không
                // Gửi xuống client thông tin để tạo nút bấm thực hiện cấu hình      
                var fsca = ReflectClassInfo<FormSaveConfigAttribute>.Inst[GetType()];
                if (fsca != null)
                {
                    this.SetData("FormSaveConfig", fsca);
                    var moduleInfo = ModuleConfigInfo.Get(fsca.Module);
                    if (isAddNew)
                    {
                        var fsc = fsca.FillSaveConfig == null ? new FillSaveConfig { } : fsca.FillSaveConfig.CreateInstance<FillSaveConfig>();
                        fsc.NewEntityWithSetting(entity, moduleInfo.PropertySetting, moduleInfo.Setting);
                    }

                    this.SetData("SaveConfig", moduleInfo.Setting);
                }

                if (form.Is<IFormEdit>())
                {
                    var formEdit = form.As<FormEdit<TEntity>>();
                    if (isAddNew) formEdit.CanDoAdd = CanAdd;
                    else formEdit.CanDoEdit = CanEdit;
                }
                BeforeInitFormEdit(form.As<PortalModule<TEntity>>(), entity);
                form.InitData();
                AfterInitFormEdit(form.As<PortalModule<TEntity>>(), entity);
                this.SetData("FormEdit", form.As<PortalModule<TEntity>>().FormatForm().GetHtml());
                this.SetData("EntityData", form.As<PortalModule<TEntity>>().Entity);
            }
            else throw new Exception("Bạn không có quyền thao tác");
        }
        protected virtual void BeforeInitFormEdit(PortalModule<TEntity> form, TEntity t) { }
        protected virtual void AfterInitFormEdit(PortalModule<TEntity> form, TEntity t) { }

        protected virtual ControlBase LoadControlEdit() => DoLoad(Type.GetType(this.Query<string>("form")));
        #endregion
        #region Xuất Excel
        [FileDownload(MimeType = MimeType.Excel97To2003)]
        public FileResult ExportExcel()
        {
            if (!CanExport)
                throw new Exception("Bạn không có quyền thao tác");

            var result = ExportExcelHelper();
            OnExport(result.T1, result.T3);

            var stream = new MemoryStream();
            result.T1.Save(stream, SaveFormat.Excel97To2003);
            stream.Seek(0, SeekOrigin.Begin);

            return new FileResult { Stream = stream, FileName = result.T2 };
        }

        protected Pair<Workbook, string, int> ExportExcelHelper()
        {
            var columnOrder = this.Query<int>("order[0][column]");
            var orderDir = this.Query<string>("order[0][dir]");
            var fieldOrder = this.Query<string>("columns[" + columnOrder + "][data]");

            // Điền dữ liệu form tìm kiếm
            //this.ParseParamTo(Provider, true);
            //Provider.DataSource.Start = 0;
            //Provider.DataSource.Length = int.MaxValue - 1;
            Provider.DataSource.FieldOrder = fieldOrder;
            Provider.DataSource.Dir = orderDir;

            var report = new ReportCenter { Target = this };
            report.BeforeFill += OnBeforeFill;

            return report.Export(Provider.DataSource.GetData(), Provider.DataSource.GetDataSummary().Summaries);
        }

        //protected virtual List<TEntity> DataForExcel() => Provider.CurrentData;

        protected virtual void OnBeforeFill(ExcelBinderBase binder, Worksheet sheet, ReportCenter report) { }

        protected virtual void OnExport(Workbook workbook, int row) { }

        /// <summary>
        /// Lấy ra các fields hiển thị trên grid
        /// </summary>
        private IEnumerable<string> GetListFields()
        {
            var totalFields = this.Query("TotalFields").SplitTo<int>();
            for (var j = 0; j < totalFields.Count; j++)
            {
                var i = totalFields[j];

                var field = this.Query<string>("columns[" + i + "][data]");
                if ((field.IsNull() || field == i.ToString()) && i > 0)
                {
                    //j++;
                    continue;
                }

                if (field.IsNotNull()) yield return field;
            }
        }

        public class ColumnSpanConfig
        {
            public int Row { set; get; }
            public int Column { set; get; }
            public string Text { set; get; }
            public int Colspan { set; get; }
        }

        private static readonly Regex rexColspan = new Regex("row-span-([0-9]+)-col-([0-9]+)-sp-([0-9]+)", RegexOptions.Compiled);
        private IEnumerable<ColumnSpanConfig> GetColumnSpanConfig()
        {
            return HttpContext.Current.Request.Params.Cast<string>()
                .Select(key => new { key, value = HttpContext.Current.Request.Params[key] })
                .Select(kv => new { match = rexColspan.Match(kv.key), kv })
                .Where(mkv => mkv.match.Success)
                .Select(mkv => new ColumnSpanConfig
                {
                    Row = mkv.match.Groups[1].Value.To<int>(),
                    Column = mkv.match.Groups[2].Value.To<int>(),
                    Colspan = mkv.match.Groups[3].Value.To<int>(),
                    Text = mkv.kv.value
                });
        }

        public ColumnConfig ColumnConfig
        {
            get
            {
                var cc = new ColumnConfig();
                var pa = new ReflectTypeListPropertyWithAttribute<PropertyInfoAttribute>()[typeof(TEntity)];
                var fields = GetListFields().Select((f, i) => new { f, i });

                pa.Join(fields, p => p.T1.Name, fi => fi.f, (p, fi) =>
                {
                    var column = FindColumnConfigChain.Execute(fi.f, this.Query<string>("DataFormatType_" + fi.f));
                    column.Visible = true;
                    column.Caption = p.T2.Name;
                    BuildColumnConfig(column, p.T2, p.T1);
                    column.Width = this.Query<int>("W_" + fi.f);
                    column.SummaryTitle = this.Query<string>("ST_" + fi.f);
                    column.HorizontalAlign = this.Query<HorizontalAlign>("Align_" + fi.f);
                    return new { column, fi };
                })
                .OrderBy(cfi => cfi.fi.i)
                .ForEach(ci => cc.Columns.Add(ci.column));

                #region Tạo column conspan
                var rowSpans = GetColumnSpanConfig().ToList();
                if (rowSpans.Count == 0) return cc;

                var columns = cc.Columns.ToList(); cc.Columns.Clear();
                var rows = rowSpans.GroupBy(r => r.Row).OrderBy(g => g.Key).Select(g => new { Row = g.Key, Columns = g.ToList() }).ToList();
                var dic = rows.Select((r, i) => new { r, i })
                    .ToDictionary(ri => ri.i, ri => ri.r.Columns.Select(c =>
                        new Pair<ColumnSpanConfig, ColumnConfig> { T1 = c, T2 = new ColumnConfig { Caption = c.Text } }).ToList());

                for (var i = 0; i < dic.Count; i++)
                {
                    if (i == 0) dic[i].ForEach(c => cc.Columns.Add(c.T2));
                    else
                    {
                        var pdic = dic[i - 1];
                        var totalSpan = 0;
                        for (var j = 0; j < dic[i].Count; j++)
                        {
                            totalSpan += dic[i][j].T1.Colspan;

                            var ptotalSpan = 0;
                            for (var z = 0; z < pdic.Count; z++)
                            {
                                ptotalSpan += pdic[z].T1.Colspan;
                                if (totalSpan <= ptotalSpan)
                                {
                                    pdic[z].T2.Columns.Add(dic[i][j].T2);
                                    break;
                                }
                            }
                        }
                    }
                }

                var bottom = dic[dic.Count - 1];
                for (var i = 0; i < columns.Count; i++)
                {
                    var totalSpan = 0;
                    for (var j = 0; j < bottom.Count; j++)
                    {
                        totalSpan += bottom[j].T1.Colspan;
                        if (i + 1 <= totalSpan)
                        {
                            bottom[j].T2.Columns.Add(columns[i]);
                            break;
                        }
                    }
                }
                #endregion

                return cc;
            }
        }

        protected virtual void BuildColumnConfig(ColumnConfig c, PropertyInfoAttribute p, PropertyInfo pi) { }

        public string Excel_GetSubtitle() => Provider.GetSubTitle();
        public virtual string Excel_FileTemplate => string.Empty;
        public virtual int? Excel_Y_Title => null;
        public virtual int? Excel_X_Title => null;
        public virtual int? Excel_Y_SubTitle => null;
        public virtual int? Excel_X_SubTitle => null;
        public virtual int? Excel_StartRow => null;
        public virtual bool? Excel_CreateHeader => null;
        public virtual bool? Excel_BindSummary => null;
        public virtual bool? Excel_FillTitle => null;
        public virtual bool? Excel_UseStyleTemplate => null;

        public virtual string Excel_GetTitle()
        {
            var reportInfo = this.GetReportInfo();
            if (reportInfo != null && reportInfo.Title.IsNotNull()) return reportInfo.Title;
            return this.Query<string>("ReportTitle");
        }
        #endregion
        protected virtual bool CanShowItem => true;
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            var cmi = $"_{ConcreteModuleId.ToString()}";
            var column = Singleton<UserHelper>.Inst.GetConfigOfCurrentUser(ControlName + cmi);
            this.SetData("UserColumn", column);
            this.SetData("ConcreteModuleId", cmi);
            this.SetData("TableEntityName", GetTableEntityName());
            this.SetData("TableFieldKeyName", GetTableFieldKeyName());
        }

        protected virtual object ConcreteModuleId => string.Empty;

        public void SaveUserColumn() => Singleton<UserHelper>.Inst.SaveUserColumn();
    }
    public abstract class ManageModule<TEntity, TProvider, TControlEdit> : ManageModule<TEntity, TProvider>
        where TEntity : class, new()
        where TProvider : ManageModuleProviderBase<TEntity>, new()
        where TControlEdit : ControlBase
    {
        protected override ControlBase LoadControlEdit() => Control<TControlEdit>.Create();
    }

    #region Module để cập nhật đối tượng
    public abstract class FormEdit<TEntity, TProvider> : FormEditModule<TEntity, TProvider>
        where TEntity : class, new()
        where TProvider : ManageModuleProviderBase<TEntity>, new()
    {
        sealed protected override void OnInitData()
        {
            Entity = GetForEdit();
            if (Entity != null) this.SetData("Entity", Entity);
            else Entity = new TEntity();
            AfterInitFormEdit();
        }
        protected virtual void AfterInitFormEdit() { }
        protected virtual TEntity GetForEdit()
        {
            var t = new TEntity();
            if (PortalContext.IsAjax && CoreQuery != null) t.Parse(CoreQuery, false);
            else this.ParseParamTo(t, true);

            return Provider.GetByKey(t);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (Entity is IAuthor)
            {
                var strHtml = new StringBuilder();
                using (var strWriter = new StringWriter(strHtml))
                using (HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter))
                    base.Render(htmlWriter);
                typeof(IAuthor).GetProperties().ForEach(p => strHtml.AppendFormat("<input type='hidden' name='{0}' />", p.Name));
                writer.Write(strHtml);
            }
            else base.Render(writer);
        }
    }
    public abstract class FormEditModule<TEntity, TProvider> : PortalModule<TEntity>, IManageModulePermission
        where TEntity : class, new()
        where TProvider : ManageModuleProviderBase<TEntity>, new()
    {
        public TProvider Provider { get; } = new TProvider();

        protected virtual void OnBeforeConstructor() { }

        public FormEditModule()
        {
            Provider.Module = this;
            Permission = GetType().GetClassInfoAttribute<ManageModulePermissionAttribute>();

            OnBeforeConstructor();

            // Nhận tất cả dữ liệu được truyền lên bởi client
            // Chỉ có tải dữ liệu thì mới thực hiện Validate Provider
            Provider.GetDataSource();

            if (this.Query("_m") == "LoadData" || this.Query("_m") == "ExportExcel")
            {
                this.ParseParamTo(Provider, true);
                if (Provider.DataSource != null) this.ParseParamTo(Provider.DataSource, true);
            }
            else
            {
                this.ParseTo(Provider);
                if (Provider.DataSource != null) this.ParseTo(Provider.DataSource);
            }

            if (Provider.DataSource != null && Provider.DataSource.Is<ICompanyNeedValidate>())
                Provider.DataSource.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCompanyId(Provider.DataSource.As<ICompanyNeedValidate>().CompanyId);

            if (Provider.Is<ICompanyNeedValidate>())
                Provider.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCompanyId(Provider.As<ICompanyNeedValidate>().CompanyId);
        }

        #region Điền dữ liệu vào Entity và thực hiện lưu trữ
        public bool UseDataEntityWhenSave { set; get; } = true;

        public void Save()
        {
            var formAdd = this.Query<bool>("FormAdd");
            if ((formAdd && CanAdd) || (!formAdd && CanEdit))
            {
                var t = ParseForSave != null ? ParseForSave() : ParseEntity();
                Provider.DoSaveInTransaction(t);

                if (UseDataEntityWhenSave && this is IManageModule)
                {
                    var key = this.As<IManageModule>().GetTableFieldKeyName();
                    this.SetData(key, t.Eval(key));
                    this.SetData("EntityData", t);
                }
            }
            else throw new Exception("Bạn không có quyền thao tác");
        }
        public TEntity Validate()
        {
            var t = ParseForSave != null ? ParseForSave() : ParseEntity();
            Provider.DoValiate(t);
            return t;
        }

        public event Func<TEntity> ParseForSave;

        public TEntity ParseEntity(bool hasValidate = true, bool validateFullProperties = true) => hasValidate ? this.ParseParamTo<TEntity>(validateFullProperties) : this.ParseTo<TEntity>();
        #endregion
        #region Quyền thêm hoặc sửa trên form
        public ManageModulePermissionAttribute Permission { get; } = null;
        public virtual bool CanAdd => Permission.CanAdd();
        public virtual bool CanEdit => Permission.CanEdit();
        public virtual bool CanExport => Permission.CanExport();
        #endregion
    }
    #endregion
    #endregion
    #region Provider
    #region Provider dành cho quản lý những đối tượng cần lưu trữ người nhập, sửa, ngày nhập, ngày sửa
    public abstract class ManageModuleProvider<TEntity, TKey> : ManageModuleProvider<TEntity>
        where TEntity : ModelBase, IModel<TKey>, new()
    {
        sealed protected override void BeforeSave(TEntity t)
        {
            if (t is IAuthor)
            {
                var author = t.As<IAuthor>();
                if (t.Key.Equals(default(TKey)))
                {
                    author.CreatedDate = author.UpdatedDate = DateTime.Now;
                    author.CreatedByUserId = author.UpdatedByUserId = PortalContext.CurrentUser.User.UserId;
                }
                else
                {
                    author.UpdatedDate = DateTime.Now;
                    author.UpdatedByUserId = PortalContext.CurrentUser.User.UserId;

                    if (author.CreatedDate == DateTime.MinValue) author.CreatedDate = author.UpdatedDate;
                    if (author.CreatedByUserId == 0) author.CreatedByUserId = author.UpdatedByUserId;
                }
            }
            OnBeforeSave(t);
        }
        protected virtual void OnBeforeSave(TEntity t) { }

        sealed public override TEntity GetOldWhenSave(TEntity t)
        {
            if (!t.Key.Equals(default(TKey)))
            {
                var told = new TEntity { Key = t.Key };
                if (told.GetByKey()) return told;
            }
            return null;
        }
        sealed protected override void Validate(TEntity t)
        {
            BeforeValidate(t);
            if (t.Is<ICompanyNeedValidate>())
            {
                PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(t.As<ICompanyNeedValidate>().CompanyId, string.Empty);
                if (OldEntity != null)
                    PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(OldEntity.As<ICompanyNeedValidate>().CompanyId, string.Empty);
            }
            AfterValidateCompany(t);

            if (t.Is<ICommonSystem>())
            {
                if (OldEntity != null)
                {
                    if (OldEntity.As<ICommonSystem>().IsSystem)
                    {
                        if (PortalContext.CurrentUser.CurrentCompanyId != AppSetting.CompanyFullPermission)
                            throw new Exception("Không thể cập nhật được dữ liệu chung toàn hệ thống");
                    }
                }
                else
                {
                    if (t.As<ICommonSystem>().IsSystem)
                        if (PortalContext.CurrentUser.CurrentCompanyId != AppSetting.CompanyFullPermission)
                            throw new Exception("Bạn không có quyền cập nhật dữ liệu chung toàn hệ thống");
                }
            }

            if (t.Is<IVersion>())
            {
                if (OldEntity != null)
                {
                    if (t.As<IVersion>().Version != OldEntity.As<IVersion>().Version) throw new Exception("Thông tin đã được thay đổi. Vui lòng tải lại dữ liệu trước khi cập nhật");
                    t.As<IVersion>().Version++;
                }
            }

            ValidateHelper(t);
        }
        protected virtual void ValidateHelper(TEntity t) { }
        protected virtual void BeforeValidate(TEntity t) { }
        protected virtual void AfterValidateCompany(TEntity t) { }

        sealed protected override void ValidateDelete(TEntity t)
        {
            if (t.Is<ICompanyNeedValidate>())
            {
                if (OldEntity != null)
                    PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(OldEntity.As<ICompanyNeedValidate>().CompanyId, string.Empty);
            }

            if (t.Is<ICommonSystem>())
            {
                if (OldEntity != null)
                    if (OldEntity.As<ICommonSystem>().IsSystem)
                    {
                        if (PortalContext.CurrentUser.GetCurrentCompanyId() != AppSetting.CompanyFullPermission)
                            throw new Exception("Không thể xóa được dữ liệu chung toàn hệ thống");
                    }
            }

            ValidateDeleteHelper(t);
        }
        protected virtual void ValidateDeleteHelper(TEntity t) { }
        public override TEntity GetByKey(TEntity t)
        {
            if (t.Key.Equals(default(TKey))) return null;
            return base.GetByKey(t);
        }

        sealed protected override void ProcessWriteLog(List<LogEntity> logEntities, bool checkWhenOneLog) => LogEntityHelper.Save(logEntities, checkWhenOneLog);
        sealed protected override void BuildLogWhenSave(TEntity @new, List<LogEntity> logEntities) => logEntities.Insert(0, LogEntity.LogEntityChange(@new, OldEntity));
        sealed protected override void BuildLogWhenDelete(TEntity deleted, List<LogEntity> logEntities) => logEntities.Add(LogEntity.LogEntityDelete(OldEntity));

        public abstract class Source<TDataSource> : ManageModuleProvider<TEntity, TKey> where TDataSource : class, ISource, new()
        {
            sealed protected override ISource CreateDataSource()
            {
                var source = new TDataSource { };
                OnCreateDataSource(source);
                return source;
            }
            protected virtual void OnCreateDataSource(TDataSource source) { }
            new public TDataSource DataSource { protected set => base.DataSource = value; get => base.DataSource as TDataSource; }
        }
    }
    #endregion
    #region Mở rộng Provider để quản lý các ModelBase => chính ra nên là IModelBase thì tốt hơn. Nhưng đoạn này lười nên cứ thế đã. Sau này mở rộng thì sửa sau
    public abstract class ManageModuleProvider<TEntity> : ManageModuleProviderBase<TEntity>
        where TEntity : ModelBase, new()
    {
        #region các phương thức vitual và abstract
        //public override List<TEntity> GetData(int start, int length, string fieldOrder, string dir) => User.ModuleGetData<TEntity>(KeySearch, Singleton<TEntity>.Inst.GetTableName(), Singleton<TEntity>.Inst.GetFieldByFieldSearchAttribute(), start, length, fieldOrder, dir);
        //public override int GetTotal() => User.ModuleGetDataCount(KeySearch, Singleton<TEntity>.Inst.GetTableName(), Singleton<TEntity>.Inst.GetFieldByFieldSearchAttribute());
        protected override void Delete(TEntity t) => t.Delete();
        protected override void Save(TEntity t, List<LogEntity> logEntities, IDataBaseService service)
        {
            if (service != null && t.Is<IModelDataBaseService>())
                t.As<IModelDataBaseService>().SetDataBaseService(service);
            t.Upsert();
        }
        public override TEntity GetByKey(TEntity t) => t.GetByKey() ? t : null;
        public override void UpdateField(TEntity t, string field) => t.Update(field);
        #endregion

        new public abstract class Source<TDataSource> : ManageModuleProvider<TEntity> where TDataSource : class, ISource, new()
        {
            sealed protected override ISource CreateDataSource()
            {
                var source = new TDataSource { };
                OnCreateDataSource(source);
                return source;
            }
            protected virtual void OnCreateDataSource(TDataSource source) { }
            new public TDataSource DataSource { protected set => base.DataSource = value; get => base.DataSource as TDataSource; }
        }
    }
    #endregion
    #endregion
    #region ProviderBase cung cấp phương thức cơ bản nhất => quản lý mọi loại đối tượng
    public abstract class ManageModuleProviderBase<TEntity> where TEntity : class, new()
    {
        public IViPortalModule Module { set; get; }
        public ISource DataSource { protected set; get; }
        public ISource GetDataSource() => DataSource = CreateDataSource();
        protected virtual ISource CreateDataSource() => null;
        protected virtual void ValidateDelete(TEntity t) { }
        protected virtual void Delete(TEntity t) { }

        public virtual TEntity GetByKey(TEntity t) { return new TEntity(); }
        public virtual void UpdateField(TEntity t, string field) { }
        #endregion

        #region Save Entity
        public void DoDeleteInTransaction(TEntity t, IDataBaseService tservice = null)
        {
            if (NeedGetOldWhenSave) OldEntity = GetOldWhenSave(t);
            var logEntities = new List<LogEntity> { };

            ValidateDelete(t);
            BuildLogWhenDelete(t, logEntities);
            Delete(t);
            ProcessWriteLog(logEntities, false);
        }


        public TEntity OldEntity { set; get; }
        protected bool NeedGetOldWhenSave => true;
        public virtual TEntity GetOldWhenSave(TEntity t) => null;
        public void DoSaveInTransaction(TEntity t, IDataBaseService tservice = null)
        {
            DoValiate(t);

            BeforeSave(t);
            var logEntities = new List<LogEntity> { };

            IDataBaseService service = null;
            if (UseTransactionInSave)
            {
                if (t.Is<IModelDataBaseService>())
                    service = t.As<IModelDataBaseService>().GetDataBaseService();
            }

            bool isOkSave = true;
            try
            {
                if (service != null) service.BeginTransaction();
                Save(t, logEntities, service);
            }
            catch (Exception ex)
            {
                isOkSave = false;
                throw ex;
            }
            finally
            {
                if (service != null)
                    service.Commit(isOkSave);
            }

            AfterSave(t);
            BuildLogWhenSave(t, logEntities);
            ProcessWriteLog(logEntities, true);
            AfterFinishTransactionSave(t);
        }
        protected virtual bool UseTransactionInSave => false;
        public void DoValiate(TEntity t)
        {
            if (NeedGetOldWhenSave && OldEntity == null) OldEntity = GetOldWhenSave(t);
            Validate(t);
        }
        protected virtual void BuildLogWhenSave(TEntity @new, List<LogEntity> logEntities) { }
        protected virtual void BuildLogWhenDelete(TEntity deleted, List<LogEntity> logEntities) { }

        protected virtual void AfterFinishTransactionSave(TEntity t) { }
        protected virtual void ProcessWriteLog(List<LogEntity> logEntities, bool checkWhenOneLog) { }

        protected virtual void Save(TEntity t, List<LogEntity> logEntities, IDataBaseService service) { }
        protected virtual void BeforeSave(TEntity t) { }
        protected virtual void AfterSave(TEntity t) { }
        protected virtual void Validate(TEntity t) { }
        #endregion

        
        public virtual string GetSubTitle()
        {
            return ReflectTypeListPropertyWithAttribute<PropertyMapperAttribute>.Inst[GetType()].Select(pm =>
            {
                return new { Value = pm.T1.GetValue(this, null), Pm = pm };
            })
            .Where(vm => vm.Value != null && vm.Value.ToString().IsNotNull())
            .Select(vm =>
            {
                var value = vm.Pm.T2.Is<PropertyMapperAttribute>() ? vm.Pm.T2.As<PropertyMapperAttribute>().DoMap(vm.Value) : vm.Value.ToString();
                return new { Value = value, Name = vm.Pm.T2.Name };
            })
            .Where(vn => vn.Value.IsNotNull())
            .JoinString(vn => LanguageHelper.GetLabel(vn.Name) + ": " + vn.Value, ", ");
        }

        public abstract class Source<TDataSource> : ManageModuleProviderBase<TEntity> where TDataSource : class, ISource, new()
        {
            sealed protected override ISource CreateDataSource()
            {
                var source = new TDataSource { };
                OnCreateDataSource(source);
                return source;
            }
            protected virtual void OnCreateDataSource(TDataSource source) { }
            new public TDataSource DataSource { protected set => base.DataSource = value; get => base.DataSource as TDataSource; }
        }
    }
    #region Định nghĩa quyền trên Form gồm 3 quyền cơ bản là thêm sửa xóa
    public class ManageModulePermissionAttribute : ClassInfoAttribute
    {
        public int Add { set; get; }
        public int Edit { set; get; }
        public int Delete { set; get; }
        public int Export { set; get; }
    }
    public static class ManageModulePermissionAttributeExtension
    {
        public static bool CanAdd(this ManageModulePermissionAttribute permission) { return permission.Can("Add"); }
        public static bool CanEdit(this ManageModulePermissionAttribute permission) { return permission.Can("Edit"); }
        public static bool CanDelete(this ManageModulePermissionAttribute permission) { return permission.Can("Delete"); }
        public static bool CanExport(this ManageModulePermissionAttribute permission) { return permission.Can("Export"); }
        public static bool Can(this ManageModulePermissionAttribute permission, string name)
        {
            if (permission == null) return true;
            var p = permission.Eval(name).To<int>();
            var result = p == 0 || PortalContext.HasPermission(p);
            if (!result)
                throw new Exception("Bạn không có quyền thực hiện chức năng này");
            return result;
        }
    }
    #endregion
    public static class FormEditExtension
    {
        public static Control FormatForm<TEntity>(this PortalModule<TEntity> control) where TEntity : class, new()
        {
            var plc = new PlaceHolder();
            plc.Controls.Add(control);

            if (control.Entity is IAuthor) plc.AddHiddenFieldByInterface<IAuthor>();
            if (control.Entity is IVersion) plc.AddHiddenFieldByInterface<IVersion>();

            return plc;
        }
        public static void AddHiddenFieldByInterface<T>(this Control control) => typeof(T).GetProperties().ForEach(p => control.Controls.Add(new LiteralControl { Text = "<input type='hidden' name='" + p.Name + "' />" }));
    }
    public class SearchAttribute : Attribute { }
    public interface IReportProvider
    {
        object DoGetSummary();
    }

    public interface IFormEdit
    {
        bool CanDoAdd { get; }
        bool CanDoEdit { get; }
    }
    public abstract class FormEdit<TEntity> : PortalModule<TEntity>, IFormEdit where TEntity : class, new()
    {
        public bool CanDoAdd { set; get; }
        public bool CanDoEdit { set; get; }
        public virtual bool CanModify { get { return CanDoAdd || CanDoEdit; } }
    }



    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class FormSaveConfigAttribute : ClassInfoAttribute
    {
        public bool NeedConfig { set; get; } = true;
        public string Module => Type.Name;
        public Type FillSaveConfig { set; get; }
    }

    public class ModuleConfigInfo
    {
        public PathItem PathItem { set; get; }
        public FormSaveConfigSetting Setting { set; get; }
        public PropertyInfo PropertySetting { set; get; }

        public static ModuleConfigInfo Get(string module)
        {
            var moduleName = $"{module}Config";
            var modulePathItem = PortalContext.PathImageForMenuConfig.FirstOrDefault(pi => pi.Name == moduleName);

            object setting = null;

            var propertySetting = modulePathItem.Type.GetProperty("Setting", BindingFlags.Instance | BindingFlags.NonPublic);
            if (propertySetting != null)
            {
                // Tải thông tin cấu hình của người dùng theo module
                var userConfig = PortalContext.CurrentUser.GetConfig(moduleName);
                if (userConfig.Config.IsNotNull())
                    try { setting = JsonConvert.DeserializeObject(userConfig.Config, propertySetting.PropertyType); }
                    catch { }

                if (setting == null) setting = propertySetting.PropertyType.CreateInstance();

                if (setting != null && setting.Is<ICompanyNeedValidate>())
                    setting.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCompanyId(setting.As<ICompanyNeedValidate>().CompanyId);
            }

            return new ModuleConfigInfo { PathItem = modulePathItem, Setting = setting as FormSaveConfigSetting, PropertySetting = propertySetting };
        }
    }
    public class FillSaveConfig
    {
        public void NewEntityWithSetting(object entity, PropertyInfo propertySetting, FormSaveConfigSetting setting)
        {
            FillSetting(entity, propertySetting, setting);
            OnNewEntityWithSetting(entity, setting);
        }

        protected virtual void OnNewEntityWithSetting(object entity, FormSaveConfigSetting setting) { }
        public static void FillSetting(object entity, PropertyInfo propertySetting, FormSaveConfigSetting setting)
        {
            var entityType = entity.GetType();
            ReflectTypeListPropertyWithAttribute<PropertyInfoAttribute>.Inst[propertySetting.PropertyType].ForEach(p =>
            {
                var property = entityType.GetProperty(p.T1.Name);
                if (property == null) return;

                var oldValue = property.GetValue(entity);
                var defaultValue = property.PropertyType.CreateInstance();

                if (Equals(oldValue, defaultValue)) property.SetValue(entity, p.T1.GetValue(setting));
            });
        }
    }

    public class FillSaveConfig<TEntity, TSetting> : FillSaveConfig
        where TEntity : class
        where TSetting : FormSaveConfigSetting
    {
        sealed protected override void OnNewEntityWithSetting(object entity, FormSaveConfigSetting setting) => OnNewEntityWithSetting(entity.As<TEntity>(), setting.As<TSetting>());
        protected virtual void OnNewEntityWithSetting(TEntity entity, TSetting setting) { }
    }

    public interface IFormSaveConfigSetting { }
    public class FormSaveConfigSetting : IFormSaveConfigSetting, ICompanyNeedValidate
    {
        [PropertyInfo(Name = "Công ty")] public int CompanyId { set; get; }
    }

    public class DataSourceCommon<TEntity> : DataSource<TEntity>.Module where TEntity : ModelBase, new()
    {
        public virtual string KeySearch => ReflectTypeListPropertyWithAttribute<SearchAttribute>.Inst[GetType()].Select(p => p.T1.GetValue(this).To<string>()).FirstOrDefault();

        public override List<TEntity> GetEntities() => User.ModuleGetData<TEntity>(KeySearch, Singleton<TEntity>.Inst.GetTableName(), Singleton<TEntity>.Inst.GetFieldByFieldSearchAttribute(), Start, Length, FieldOrder, Dir);
        public override int GetTotal() => User.ModuleGetDataCount(KeySearch, Singleton<TEntity>.Inst.GetTableName(), Singleton<TEntity>.Inst.GetFieldByFieldSearchAttribute());
    }
}