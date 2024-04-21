using System.ComponentModel;
using System.Globalization;
using System;
namespace Core.Types
{
    [ConverterOf(Target = typeof(double))]
    public class DoubleConverter : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String:
                case ShTypeCode.Decimal:
                case ShTypeCode.Int16:
                case ShTypeCode.Int32:
                case ShTypeCode.Int64:
                case ShTypeCode.Single: return Convert.ToDouble(value);
                case ShTypeCode.Double: return value;
                case ShTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.Double | ShTypeCode.Int16 | ShTypeCode.Int32 | ShTypeCode.Int64 | ShTypeCode.Decimal | ShTypeCode.String | ShTypeCode.DBNull;
        }
    }
}
