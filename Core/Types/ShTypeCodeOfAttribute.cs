using Core.Attributes;
using System;
namespace Core.Types
{
    /// <summary>
    /// Mở rộng cho TypeCode của dữ liệu gì
    /// </summary>    
    public class ShTypeCodeOfAttribute : FieldInfoAttribute
    {
        private Type type = null;
        public Type Type
        {
            get { return type; }            
        }

        public ShTypeCodeOfAttribute(Type type)
        {
            this.type = type;
        }
    }
}
