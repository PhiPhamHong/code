using System.ComponentModel;
using System.Globalization;
using System;
using Core.Extensions;
namespace Core.Types
{
    [ConverterOf(Target = typeof(short))]
    public class Int16Converter : Int16ConverterBase
    {

    }

    [ConverterOf(Target = typeof(short?))]
    public class Int16NullConverter : Int16ConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch(typeCode)
            {
                case ShTypeCode.String: return value.ToString().IsNull() ? null : (short?)Convert.ToInt16(value);
                case ShTypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
    }

    public abstract class Int16ConverterBase : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value.ToString().IsNull() ? (short)0 : Convert.ToInt16(value.ToString().Replace(",", string.Empty));
                case ShTypeCode.Byte: return Convert.ToInt16(value);
                case ShTypeCode.Int16: return value;
                case ShTypeCode.DBNull: return (short)0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.Int16 | ShTypeCode.String | ShTypeCode.Byte | ShTypeCode.DBNull;
        }
    }
}