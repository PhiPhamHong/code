using System;
using System.Linq;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using System.Collections.Generic;
using Core.Reflectors;
using System.Reflection;
using Core.Utility;
namespace Core.DataBase.ADOProvider.ShSqlCommand
{
    /// <summary>
    /// Build Command từ ModelBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TSqlBuilder
    {
        public TSqlBuilder(Type typeOfT) { this.typeOfT = typeOfT; }

        private Type typeOfT = null;
        public Type TypeOfT
        {
            get { return typeOfT; }
        }

        private TableInfoAttribute tableInfo = null;
        /// <summary>
        /// Thông tin về bảng trong cơ sở dữ liệu
        /// </summary>
        public TableInfoAttribute TableInfo
        {
            get
            {
                // Nếu thông tin bảng chưa có thì lấy ra
                if (tableInfo == null) tableInfo = typeOfT.GetAttribute<TableInfoAttribute>();
                return tableInfo;
            }
        }

        private List<FieldAttribute> fieldPKs = null;
        /// <summary>
        /// Danh sách Primary Key
        /// </summary>
        public List<FieldAttribute> FieldPKs
        {
            get
            {
                // Nếu chưa thông tin khóa chính thì lấy ra
                if (fieldPKs == null)
                    // Chỉ lấy những Field là khóa chính
                    fieldPKs = AllFields.Where(f => f.T2.IsKey).Select(f => 
                    {
                        f.T2.FieldName = f.T1.Name;
                        return f.T2;
                    }).ToList();
                // trả ra danh sách khóa chinh
                return fieldPKs;
            }
        }

        public List<Pair<PropertyInfo, FieldAttribute>> AllFields
        {
            get { return ReflectTypeListPropertyWithAttribute<FieldAttribute>.Inst[typeOfT]; }
        }

        private List<PropertyInfo> allProperties = null;
        public List<PropertyInfo> AllProperties
        {
            get
            {
                if (allProperties == null)
                    allProperties = AllFields.Select(f => f.T1).ToList();
                return allProperties;
            }
        }

        public ShCommand BuildCommand<TCommand>(ModelBase t, params string[] fields) where TCommand : ShCommand, new()
        {
            // Build ra câu lệnh Command
            var cmd = new TCommand();

            // Nếu như Builder hiện tại không hợp lệ thì trả ra command null
            if (!cmd.IsValid(this)) return null;

            cmd.Build(t, this, fields);
            return cmd;
        }

        /// <summary>
        /// Build select với tất cả các field
        /// </summary>
        /// <returns></returns>
        public string BuildSelectAllField(int top = 0)
        {
            // Select
            string str = " SELECT";

            // Nếu có tìm top
            if (top != 0) str += " TOP " + top;

            // Các fields
            this.AllProperties.ForEach(p => str += " t.{0},".Frmat(p.Name));

            // Build lệnh
            return str.TrimEnd(',') + " FROM {0} t".Frmat(this.TableInfo.TableName);
        }
    }
}
