using System;
namespace Core.DataBase.ADOProvider.Attributes
{
    /// <summary>
    /// Thông tin bảng
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableInfoAttribute : Attribute
    {
        public string TableName { set; get; }
        public string Name { set; get; }
    }
}