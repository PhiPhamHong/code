using System.ComponentModel;
using System.Globalization;
using System;
using Core.Extensions;
namespace Core.Types
{
    [ConverterOf(Target = typeof(int))]
    public class Int32Converter : Int32ConverterBase
    {
        
    }

    [ConverterOf(Target = typeof(int?))]
    public class Int32NullConverter : Int32ConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value.ToString().IsNull() ? null : (int?)Convert.ToInt32(value.ToString().Replace(",", string.Empty));
                case ShTypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
    }

    public abstract class Int32ConverterBase : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value.ToString().IsNull() ? 0 : Convert.ToInt32(value.ToString().Replace(",", string.Empty));

                case ShTypeCode.Int16:
                case ShTypeCode.Byte:
                case ShTypeCode.Decimal:
                case ShTypeCode.Int64:
                case ShTypeCode.Double: return Convert.ToInt32(value);

                case ShTypeCode.Int32: return value;
                case ShTypeCode.Boolean: return value.To<bool>() ? 1 : 0;

                case ShTypeCode.DBNull: return 0;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.String | ShTypeCode.Double | ShTypeCode.Int32 | ShTypeCode.Int16 | ShTypeCode.Byte | ShTypeCode.Boolean | ShTypeCode.Int64 | ShTypeCode.DBNull;
        }
    }
}
