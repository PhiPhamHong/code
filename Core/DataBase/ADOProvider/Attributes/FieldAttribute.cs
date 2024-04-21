using System;
using Core.Attributes;
namespace Core.DataBase.ADOProvider.Attributes
{
    /// <summary>
    /// Thông tin Field dữ liệu tương ứng cột trong cơ sở dữ liệu
    /// </summary>
    public class FieldAttribute : PropertyInfoAttribute, IFieldLogChange
    {
        public bool IsKey { set; get; }
        public bool IsIdentity { set; get; }
        public string FieldName { set; get; }

        private bool logWhenChange = true;
        public bool LogWhenChange
        {
            get { return logWhenChange; }
            set { logWhenChange = value; }
        }
    }
}