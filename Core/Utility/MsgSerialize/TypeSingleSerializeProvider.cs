using System;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class TypeSingleSerializeProvider : TypeNormalSerializeProvider
    {
        public const short Length = 4;
        public static Type TypeObject = typeof(float);

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return BitConverter.GetBytes((Single)value);
        }

        protected override object DoConvert(byte[] bytes)
        {
            return BitConverter.ToSingle(bytes, 0);
        }

        public override Type Type
        {
            get { return TypeObject; }
        }
    }
}
