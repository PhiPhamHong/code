using System;
using Core.Attributes;
using System.Collections.Generic;
using Core.Extensions;
namespace Core.Utility.MsgSerialize
{
    public class TypeByteSerializeProvider : TypeNormalSerializeProvider
    {
        public const short Length = 1;
        public static Type TypeObject = typeof(byte);

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return new byte[] { (byte)value };
        }

        protected override object DoConvert(byte[] bytes)
        {
            return bytes[0];
        }

        public override Type Type
        {
            get { return TypeObject; }
        }

        public override string SerializeToString(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            var data = value as List<byte>;
            if (data == null) return string.Empty;
            return data.JoinString(b => b);
        }
    }
}
