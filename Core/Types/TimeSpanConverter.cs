using System;
using System.ComponentModel;
using System.Globalization;
using Core.Extensions;
namespace Core.Types
{
    [ConverterOf(Target = typeof(TimeSpan))]
    [ConverterOf(Target = typeof(TimeSpan?))]
    public class TimeSpanConverter : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch(typeCode)
            {
                case ShTypeCode.DBNull: return null; 
                case ShTypeCode.TimeSpan: return value;
                case ShTypeCode.String: return value.ToString().IsNull() ? (TimeSpan?)null : TimeSpan.Parse(value.ToString());
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.TimeSpan | ShTypeCode.String | ShTypeCode.DBNull;
        }
    }
}