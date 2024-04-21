using System;
using System.ComponentModel;
using System.Globalization;
using Core.Extensions;
namespace Core.Types
{
    [ConverterOf(Target = typeof(DateTime))]
    [ConverterOf(Target = typeof(DateTime?))]
    public class DateTimeConverter : ShTypeConverter
    {        
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value.ToString().Trim().IsNull() ? (DateTime?)null : Convert.ToDateTime(value, CultureInfo.GetCultureInfo("vi-VN"));
                case ShTypeCode.DateTime: return value;                
                case ShTypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.DateTime | ShTypeCode.String | ShTypeCode.DBNull;
        }
    }
}