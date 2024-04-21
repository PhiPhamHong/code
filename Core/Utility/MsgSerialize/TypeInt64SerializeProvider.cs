using System;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class TypeInt64SerializeProvider : TypeNormalSerializeProvider
    {
        public const short Length = 8;
        public static Type TypeObject = typeof(long);

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return BitConverter.GetBytes((long)value);
        }

        protected override object DoConvert(byte[] bytes)
        {
            return BitConverter.ToInt64(bytes, 0); 
        }

        public override Type Type
        {
            get { return TypeObject; }
        }
    }
}
