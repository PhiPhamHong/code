using System;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class TypeInt16SerializeProvider : TypeNormalSerializeProvider
    {
        public const short Length = 2;
        public static Type TypeObject = typeof(short);

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return BinaryLibrary.GetBytesFromShort((short)value);
        }

        protected override object DoConvert(byte[] bytes)
        {
            return BinaryLibrary.GetShortFromBytes(bytes[0], bytes[1]);
        }

        public override Type Type
        {
            get { return TypeObject; }
        }
    }
}
