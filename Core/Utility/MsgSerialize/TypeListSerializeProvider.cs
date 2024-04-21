using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Core.Attributes;
using Core.Extensions;
namespace Core.Utility.MsgSerialize
{
    public class TypeListSerializeProvider : TypeSerializeProvider
    {
        public static Type TypeObject = typeof(List<>);

        public override Type Type
        {
            get { return TypeObject; }
        }

        public override object Deserialize(byte[] bytes, Type typeDetermine, PropertyIndexAttribute pia, ref int index)
        {
            // Tìm tổng số bản ghi
            short total = 0;
            var first = bytes[index]; index++; if (index >= bytes.Length) return null;
            if(pia.TypeCode == TypeCode.Byte) total = first;
            
            else
            {
                var second = bytes[index]; index++; if (index >= bytes.Length) return null;
                total = BinaryLibrary.GetShortFromBytes(first, second);
            }

            var typeofList = typeDetermine.GenericTypeArguments[0];
            var data = TypeObject.MakeGenericType(typeofList).CreateInstance() as IList;

            var provider = SerializeLibrary.GetByTypeCode(typeofList);

            for (int i = 0; i < total; i ++ )
            {                
                var t = provider.Deserialize(bytes, typeofList, pia, ref index);
                // var t = DeserializeHelper(bytes, typeofList, ref index);
                data.Add(t);
            }

            return data;
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            var data = value.CastToList();

            if(data == null)
            {
                switch(pia.TypeCode)
                {
                    case TypeCode.Byte: return new byte[] { 0 };
                    default: return new byte[] { 0, 0 };
                }
            }            

            byte[] byteLengths = null;

            var typeofList = typeDetermine.GenericTypeArguments[0];
            var provider = SerializeLibrary.GetByTypeCode(typeofList);

            switch(pia.TypeCode)
            {
                case TypeCode.Byte: byteLengths = new byte[] { (byte)data.Count }; break;
                default: byteLengths = BinaryLibrary.GetBytesFromShort((short)data.Count); break;
            }

            // return byteLengths.Concat(data.SelectMany(d => d.Serialize())).ToArray();
            return byteLengths.Concat(data.SelectMany(d => provider.Serialize(d, typeofList, pia))).ToArray();
        }

        public override string SerializeToString(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            var data = value.CastToList();
            if (data == null) return string.Empty;

            var typeofList = typeDetermine.GenericTypeArguments[0];
            var provider = SerializeLibrary.GetByTypeCode(typeofList);

            return data.JoinString(d => provider.SerializeToString(d, typeofList, pia), "_");
        }
    }
}
