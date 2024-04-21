using System.ComponentModel;
using System.Globalization;
namespace Core.Types
{    
    [ConverterOf(Target = typeof(bool))]
    public class BooleanConverter : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value.ToString() == "true" || value.ToString() == "True" || value.ToString() == "1";
                case ShTypeCode.Int32: return value.ToString() == "1";
                case ShTypeCode.Boolean: return value;
                case ShTypeCode.DBNull: return false;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.Int32 | ShTypeCode.Boolean | ShTypeCode.String | ShTypeCode.DBNull;
        }
    }
}
