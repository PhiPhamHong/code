using System.ComponentModel;
using System.Globalization;
using System;
using Core.Extensions;
namespace Core.Types
{
    [ConverterOf(Target = typeof(byte))]
    public class ByteConverter : ShTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, ShTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ShTypeCode.Int32:
                case ShTypeCode.String: return value.IsNull() ? (byte)0 : (value.ToString().IsNull() ? (byte)0 : Convert.ToByte(value));
                case ShTypeCode.Byte: return value;
                case ShTypeCode.DBNull: return (byte)0;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override ShTypeCode GetTypeCodeCanConvert()
        {
            return ShTypeCode.Byte | ShTypeCode.String | ShTypeCode.Int32 | ShTypeCode.DBNull;
        }
    }
}
