using System;
using System.ComponentModel;
using System.Globalization;
namespace Core.Types
{
    [ConverterOf(Target = typeof(Guid))]
    public class GuidConverter : ShTypeConverter
    {        
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.String: return value.ToString() == "0" ?  Guid.NewGuid() : new Guid(value.ToString());
                case ShTypeCode.Guid: return value;
                case ShTypeCode.DBNull: return Guid.Empty;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.String | ShTypeCode.Guid | ShTypeCode.DBNull;
        }
    }
}
