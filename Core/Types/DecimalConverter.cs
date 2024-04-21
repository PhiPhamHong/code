using System.ComponentModel;
using System.Globalization;
using System;
using Core.Extensions;
using System.Text.RegularExpressions;
namespace Core.Types
{
    [ConverterOf(Target = typeof(decimal))]
    public class DecimalConverter : DecimalConverterBase
    {

    }

    [ConverterOf(Target = typeof(decimal?))]
    public class DecimalNullConverter : DecimalConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch(typeCode)
            {
                case ShTypeCode.String:
                    var strValue = value.ToString();
                    return strValue.IsNull() ? (decimal?)null : Convert.ToDecimal(strValue.Replace(",", string.Empty));
                case ShTypeCode.DBNull: return null;
                default: return base.ConvertFrom(context, culture, value, typeCode);
            }
        }
    }

    public abstract class DecimalConverterBase : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String:
                    var strValue = value.ToString();//.GetOnlyDigital();
                    return strValue.IsNull() ? (decimal)0 : Convert.ToDecimal(strValue.Replace(",", string.Empty));
                case ShTypeCode.Int64:
                case ShTypeCode.Int32:
                case ShTypeCode.Int16:
                case ShTypeCode.Double: return Convert.ToDecimal(value);
                case ShTypeCode.Decimal: return value;
                case ShTypeCode.DBNull: return (decimal)0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.Decimal | ShTypeCode.String | ShTypeCode.Int64 | ShTypeCode.Int32 | ShTypeCode.Int16 | ShTypeCode.Double | ShTypeCode.DBNull;
        }
    }
}