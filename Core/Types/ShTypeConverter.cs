using System.ComponentModel;
using System.Data.SqlTypes;
using System;
using System.Globalization;
namespace Core.Types
{
    /// <summary>
    /// TypeConvert
    /// </summary>
    public abstract class ShTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {                  
            return GetTypeCodeCanConvert().IsSet(SqlTypeDescriptor.Inst.GetShTypeCode(sourceType));
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return ConvertFrom(context, culture, value, value == null ? ShTypeCode.DBNull : SqlTypeDescriptor.Inst.GetShTypeCode(value.GetType()));
        }

        public virtual object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            // Mặc định là Convert theo class Base
            return base.ConvertFrom(context, culture, value);
        }

        public abstract ShTypeCode GetTypeCodeCanConvert();
    }
}
