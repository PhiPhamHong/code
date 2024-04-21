using System.ComponentModel;
using System.Globalization;
using System;
using Core.Extensions;
namespace Core.Types
{
    [ConverterOf(Target = typeof(float))]
    public class SingleConverter : SingleConverterBase
    {

    }

    [ConverterOf(Target = typeof(float?))]
    public class SingleNullConverter : SingleConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value.ToString().IsNull() ? null : (float?)Convert.ToSingle(value);
                case ShTypeCode.DBNull: return null;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }
    }

    public abstract class SingleConverterBase : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value == null || string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToSingle(value);
                case ShTypeCode.Double: return Convert.ToSingle(value);

                case ShTypeCode.Single: return value;
                case ShTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.Single | ShTypeCode.String | ShTypeCode.Double | ShTypeCode.DBNull;
        }
    }
}
