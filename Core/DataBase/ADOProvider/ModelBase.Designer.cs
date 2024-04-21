using Core.DataBase.ADOProvider.ShSqlCommand;
using System.Data;
using System;
using System.Linq;
using Core.Extensions;
using Core.Utility.MsgSerialize;
using Core.DataBase.ADOProvider.Attributes;
using Core.Reflectors;
namespace Core.DataBase.ADOProvider
{
    /// <summary>
    /// Mở rộng thêm phương thức cho ModelBase
    /// </summary>
    public partial class ModelBase
    {
        private Type type = null;
        protected Type ModelType
        {
            get
            {
                if (type.IsNull()) type = GetType();
                return type;
            }
        }

        public virtual void Upsert()
        {
            var keyName = GetFieldKeyName();
            var keyValue = this.GetPropertyValue(keyName);
            var typeKeyValue = keyValue.GetType();
            if (object.Equals(keyValue, Activator.CreateInstance(typeKeyValue)))
            {
                if (typeKeyValue == typeof(Guid))
                    this.SetValueToProperty(keyName, Guid.NewGuid());
                Insert();
            }
            else Update();
        }
        public virtual void Save() { ExeSaveQuery<ShSaveCommand>(); }
        public virtual void Insert() { ExeSaveQuery<ShInsertCommand>(); }
        public virtual void Update(params string[] fields) { ExeSaveQuery<ShUpdateCommand>(fields); }
        public virtual int Delete() { return ExeNoneQuery<ShDeleteCommand>(); }
        public virtual DataTable GetAll() { return ExeQuery<ShGetAllCommand>(); }
        public virtual bool GetByKey()
        {
            var table = ExeQuery<ShGetByKeyCommand>();
            if (table != null && table.Rows.Count != 0) ParseFrom(table.Rows[0]);
            return table != null && table.Rows.Count != 0;
        }

        private TSqlBuilder builder = null;
        /// <summary>
        /// Lấy ra Builder xây dựng câu lệnh Sql cơ bản
        /// </summary>        
        protected TSqlBuilder Builder
        {
            get
            {
                if (builder == null) builder = new TSqlBuilder(ModelType);
                return builder;
            }
        }

        private DataTable ExeQuery<TCommand>() where TCommand : ShSelectCommand, new()
        {
            var cmd = Builder.BuildCommand<TCommand>(this);
            return RunCommandToDataTable(cmd);
        }
        private int ExeNoneQuery<TCommand>() where TCommand : ShCommand, new()
        {
            var cmd = Builder.BuildCommand<TCommand>(this);
            return RunCommand(cmd);
        }
        private void ExeSaveQuery<TCommand>(params string[] fields) where TCommand : ShCommand, new()
        {
            var cmd = Builder.BuildCommand<TCommand>(this, fields);
            var table = RunCommandToDataTable(cmd);
            if (table.Rows.Count != 0) ParseFrom(table.Rows[0]);
        }
        public byte[] KeyToBytes()
        {
            var fieldKey = Builder.FieldPKs.FirstOrDefault();
            if (fieldKey == null) return new byte[0];
            var valueKey = this.GetPropertyValue(fieldKey.Name);
            var type = valueKey.GetType();
            var provider = SerializeLibrary.GetByTypeCode(type);
            return provider.Serialize(valueKey, type, null);
        }
        public string GetFieldKeyName()
        {
            var ff = Builder == null ? null : Builder.FieldPKs.FirstOrDefault();
            return ff == null ? string.Empty : ff.FieldName;
        }
        public string GetTableName() { return Builder == null || Builder.TableInfo == null ? string.Empty : Builder.TableInfo.TableName; }
        public string GetEntityName() { return Builder == null || Builder.TableInfo == null ? string.Empty : Builder.TableInfo.Name; }
        public string GetFieldsByLanguageAttribute()
        {
            return Builder.AllFields.Where(f => f.T2 is LanguageAttribute).JoinString(f => f.T1.Name);
        }
        public string GetFieldByFieldSearchAttribute()
        {
            return Builder.AllFields.Where(f => f.T2 is FieldSearchAttribute).JoinString(f => f.T1.Name);
        }
        private DataTable RunCommandToDataTable(ShCommand cmd)
        {
            if (cmd == null) return null;
            return DataBaseService.ExeSql(cmd.Command, cmd.Parameter);
        }
        private int RunCommand(ShCommand cmd)
        {
            if (cmd == null) return -1;
            return DataBaseService.ExeSqlNoneQuery(cmd.Command, cmd.Parameter);
        }
    }
}