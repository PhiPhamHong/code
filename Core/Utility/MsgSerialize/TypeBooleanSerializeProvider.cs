using System;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class TypeBooleanSerializeProvider : TypeNormalSerializeProvider
    {
        public const short Length = 1;
        public static Type TypeObject = typeof(bool);

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }

        protected override object DoConvert(byte[] bytes)
        {
            return bytes[0] == 1;
        }

        public override Type Type
        {
            get { return TypeObject; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return new byte[] { (byte)(((bool)value) ? 1 : 0) };
        }
    }
}