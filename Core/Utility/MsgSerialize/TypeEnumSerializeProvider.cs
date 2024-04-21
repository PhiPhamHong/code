using System;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class Enum : TypeSerializeProvider
    {
        public static Type TypeObject = typeof(System.Enum);

        public override Type Type
        {
            get { return TypeObject; }
        }

        public override object Deserialize(byte[] bytes, Type typeDetermine, PropertyIndexAttribute pia, ref int index)
        {
            var provider = GetProvider(typeDetermine);
            var value = provider.Deserialize(bytes, provider.Type, pia, ref index);
            return System.Enum.ToObject(typeDetermine, value);
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            var provider = GetProvider(typeDetermine);
            return provider.Serialize(value, provider.Type, pia);
        }

        private TypeSerializeProvider GetProvider(Type typeDetermine)
        {
            var typeOfEnum = System.Enum.GetUnderlyingType(typeDetermine);
            var provider = typeOfEnum == TypeByteSerializeProvider.TypeObject ?
                SerializeLibrary.GetByTypeCode(TypeByteSerializeProvider.TypeObject) :
                SerializeLibrary.GetByTypeCode(TypeInt32SerializeProvider.TypeObject);
            return provider;
        }
    }
}
