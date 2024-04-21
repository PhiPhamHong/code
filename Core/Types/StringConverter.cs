using System.ComponentModel;
using System.Globalization;
using System;
namespace Core.Types
{
    [ConverterOf(Target = typeof(string))]
    public class StringConverter : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {                
                default: return value.ToString().Trim();
                case ShTypeCode.DBNull: return string.Empty;
            }
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.UnKnown;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }
    }
}
