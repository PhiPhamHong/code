using Core.Attributes;
using System;
namespace Core.DataBase.ADOProvider.Attributes
{
    /// <summary>
    /// Định nghĩa xem Model này thì sẽ sử dụng Db Service nào
    /// </summary>
    public class DbServiceTypeAttribute : ClassInfoAttribute
    {
        /// <summary>
        /// Type của class có Attribute ClassInfo
        /// </summary>
        public Type TypeTarget { set; get; }
    }
}
