using System;
using Core.Attributes;
using Core.Extensions;
namespace Core.Utility.MsgSerialize
{
    public class TypeDateTimeSerializeProvider : TypeInt64SerializeProvider
    {
        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            long longValue = value == null ? 0 : ((DateTime)value).GetLongFromDateTime();
            return base.Serialize(longValue, TypeInt64SerializeProvider.TypeObject, pia);
        }

        protected override object DoConvert(byte[] bytes)
        {
            return ((long)base.DoConvert(bytes)).GetDateTimeFromLong();
        }

        public override Type Type
        {
            get { return TypeObject; }
        }

        new public static Type TypeObject = typeof(DateTime);

        public class NullProvider : TypeDateTimeSerializeProvider
        {
            protected override object DoConvert(byte[] bytes)
            {
                var time = (DateTime)base.DoConvert(bytes);
                return time == DateTime.MinValue ? (DateTime?)null : time;
            }

            public override Type Type
            {
                get { return TypeObject; }
            }
            new public static Type TypeObject = typeof(DateTime?);
        }
    }
}
