using System;
using Core.Attributes;
using Core.Extensions;
namespace Core.Utility.MsgSerialize
{
    public class TypeGuidSerializeProvider : TypeStringSerializeProvider
    {
        new public static Type TypeObject = typeof(Guid);

        public override Type Type 
        { 
            get { return TypeObject; }
        }

        protected override object DoConvert(byte[] bytes)
        {
            string data = string.Empty;
            try
            {
                data = Convert.ToString(base.DoConvert(bytes));
                return string.IsNullOrEmpty(data) ? Guid.Empty : new Guid(data);
            }
            catch (ArgumentNullException) { throw new SerializeException { Type = Type, Value = data }; }
            catch (FormatException) { throw new SerializeException { Type = Type, Value = data }; }
        }

        public override byte[] Serialize(object value, Type typeDetermine, PropertyIndexAttribute pia)
        {
            return base.Serialize(value == null || (Guid)value == Guid.Empty ? string.Empty : value, typeDetermine, pia);
        }
    }

    public class SerializeException : Exception
    {
        public Type Type { set; get; }
        public object Value { set; get; }

        public override string Message
        {
            get { return Format.Frmat(Type, Value); }
        }

        public const string Format = "{0}:{1}";
    }
}