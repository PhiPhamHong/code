using System;
using System.Linq;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class TypeInt32SerializeProvider : TypeNormalSerializeProvider
    {
        public static Type TypeObject = typeof(int);
        public const short Length = 4;

        public override Type Type
        {
            get { return TypeObject; }
        }

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return BitConverter.GetBytes((int)value);
        }

        protected override object DoConvert(byte[] bytes)
        {
            return bytes[0] + bytes[1] * 256 + bytes[2] * 65536 + bytes[3] * 16777216; 
        }

        public class NullProvider : TypeInt32SerializeProvider
        {
            new public static Type TypeObject = typeof(int?);

            public override Type Type
            {
                get { return TypeObject; }
            }

            public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
            {
                return value == null ? base.Serialize(0, typeDetermine, pia) : base.Serialize(value, typeDetermine, pia);
            }
        }
    }
}
