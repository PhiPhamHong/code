using System;
using Core.Attributes;
using Core.Extensions;
namespace Core.Utility.MsgSerialize
{
    public class TypeObjectSerializeProvider : TypeSerializeProvider
    {
        public static Type TypeObject = typeof(object);

        public override Type Type
        {
            get { return TypeObject; }
        }

        public override object Deserialize(byte[] bytes, Type typeDetermine, PropertyIndexAttribute pia, ref int index)
        {
            return DeserializeHelper(bytes, typeDetermine, ref index);
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            if (value == null) return new byte[] { };
            if (value is byte[]) return (byte[])value;

            return value.Serialize();
        }

        public override string SerializeToString(object value, Type type, PropertyIndexAttribute pia)
        {
            if (value == null) return string.Empty;
            if (value is byte[]) return ((byte[])value).JoinString(b => b);

            return value.SerializeFormatString();
        }
    }
}
