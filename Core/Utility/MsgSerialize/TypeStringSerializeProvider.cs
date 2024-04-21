using System;
using System.Linq;
using System.Text;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class TypeStringSerializeProvider : TypeNormalSerializeProvider
    {
        public const short Length = 0;
        public static Type TypeObject = typeof(string);

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            var bytes = Encoding.UTF8.GetBytes(Convert.ToString(value));

            var length = (short)bytes.Length;
            if (length == 0) return new byte[] { 0, 0 };
            else
            {
                var lengthBytes = BinaryLibrary.GetBytesFromShort(length);
                return lengthBytes.Concat(bytes).ToArray();
            }
        }

        protected override object DoConvert(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public override Type Type
        {
            get { return TypeObject; }
        }
    }
}
