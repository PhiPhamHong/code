using System.Linq;
using System.Collections.Generic;
using System;
namespace Core.Utility.MsgSerialize
{
    public static class SerializeLibrary
    {
        private static Dictionary<Type, TypeSerializeProvider> dic = Create();

        private static Dictionary<Type, TypeSerializeProvider> Create()
        {
            return new List<TypeSerializeProvider>
            {
                new TypeByteSerializeProvider(),
                new TypeInt16SerializeProvider(),
                new TypeInt32SerializeProvider(),
                new TypeInt32SerializeProvider.NullProvider(),
                new TypeSingleSerializeProvider(),
                new TypeInt64SerializeProvider(),
                new TypeStringSerializeProvider(),
                new TypeListSerializeProvider(),
                new TypeBooleanSerializeProvider(),
                new TypeGuidSerializeProvider(),
                new TypeObjectSerializeProvider(),
                new Enum(),
                new TypeDateTimeSerializeProvider(),
                new TypeDateTimeSerializeProvider.NullProvider(),
                new TypeDoubleSerializeProvider(),
                new TypeDoubleSerializeProvider.NullProvider(),
                new TypeDecimalSerializeProvider(),
                new TypeDecimalSerializeProvider.NullProvider()
            }.ToDictionary(t => t.Type, t => t);
        }
        
        public static TypeSerializeProvider GetByTypeCode(Type type)
        {
            TypeSerializeProvider provider = null;
            if(dic.TryGetValue(type, out provider)) 
                return provider;
            else
            {
                if (type.Name == TypeListSerializeProvider.TypeObject.Name) return dic[TypeListSerializeProvider.TypeObject];
                else if (type.IsEnum) return dic[Enum.TypeObject];
                else return dic[TypeObjectSerializeProvider.TypeObject];
            }
        }
    }
}
