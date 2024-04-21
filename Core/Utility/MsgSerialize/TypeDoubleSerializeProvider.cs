using System;
using Core.Extensions;
using Core.Attributes;
namespace Core.Utility.MsgSerialize
{
    public class TypeDoubleSerializeProvider : TypeNormalSerializeProvider
    {
        public const short Length = 8;
        public static Type TypeObject = typeof(double);

        protected override short LengthInDeserialize
        {
            get { return Length; }
        }
        public override Type Type
        {
            get { return TypeObject; }
        }
        protected override object DoConvert(byte[] bytes)
        {
            return BitConverter.ToDouble(bytes, 0);
        }
        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return BitConverter.GetBytes((double)value);
        }

        public class NullProvider : TypeDoubleSerializeProvider
        {
            new public static Type TypeObject = typeof(double?);
            public override Type Type
            {
                get { return TypeObject; }
            }

            public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
            {
                return base.Serialize(value == null ? 0 : value, typeDetermine, pia);
            }
        }
    }

    public class TypeDecimalSerializeProvider : TypeDoubleSerializeProvider
    {
        new public static Type TypeObject = typeof(decimal);
        public override Type Type
        {
            get { return TypeObject; }
        }

        protected override object DoConvert(byte[] bytes)
        {
            return base.DoConvert(bytes).To<decimal>();
        }
        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return base.Serialize(value.To<double>(), typeDetermine, pia);
        }

        new public class NullProvider : TypeDecimalSerializeProvider
        {
            new public static Type TypeObject = typeof(decimal?);
            public override Type Type
            {
                get { return TypeObject; }
            }
            public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
            {
                return base.Serialize(value == null ? 0 : value, typeDetermine, pia);
            }
        }
    }
}