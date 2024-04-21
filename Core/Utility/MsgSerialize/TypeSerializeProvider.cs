using System;
using System.Linq;
using Core.Attributes;
using Core.Extensions;
namespace Core.Utility.MsgSerialize
{
    public abstract class TypeSerializeProvider
    {
        public abstract Type Type { get; }

        public abstract object Deserialize(byte[] bytes, Type typeDetermine, PropertyIndexAttribute pia, ref int index);

        public abstract byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia);

        protected object DeserializeHelper(byte[] bytes, Type type, ref int index)
        {
            var t = type.CreateInstance();
            foreach (var p in TypePropertyIndex.Inst[type])
            {
                if (index >= bytes.Length) break;

                var provider = SerializeLibrary.GetByTypeCode(p.T1.PropertyType);
                var value = provider.Deserialize(bytes, p.T1.PropertyType, p.T2, ref index);
                p.T1.SetValue(t, value);
            }
            return t;
        }

        public virtual string SerializeToString(object value, Type typeDetermine, PropertyIndexAttribute pia) { return Convert.ToString(value); }
    }

    public abstract class TypeNormalSerializeProvider : TypeSerializeProvider
    {
        protected abstract short LengthInDeserialize { get; }

        sealed public override object Deserialize(byte[] bytes, Type typeDetermine, PropertyIndexAttribute pia, ref int i)
        {
            short valueLength = LengthInDeserialize;
            
            if (valueLength == 0)
            {
                var first = bytes[i]; i++; if (i >= bytes.Length) return null;
                var second = bytes[i]; i++; if (i >= bytes.Length) return null;
                valueLength = BinaryLibrary.GetShortFromBytes(first, second);
            }

            var index = i;
            var value = bytes.Where((b, j) => index <= j && j < index + valueLength).ToArray();
            i = i + valueLength;

            return DoConvert(value);
        }

        protected abstract object DoConvert(byte[] bytes);
    }
}