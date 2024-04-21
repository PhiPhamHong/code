using System;
using System.Linq;
using System.Collections.Generic;
using Core.Attributes;
using Core.Reflectors;
using Core.Extensions;
namespace Core.Utility
{
    public class EnumHelper<T> : Singleton<EnumHelper<T>>
    {
        private Type type = null;
        public EnumHelper() { type = typeof(T); }
        public List<TAttribute> GetAttributes<TAttribute>() where TAttribute : FieldInfoAttribute
        {
            return ReflectFieldInfo<TAttribute>.Inst[type];
        }
        public T ParseFromString(string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }

    public class EnumHelper<T, TAttribute> : Singleton<EnumHelper<T, TAttribute>> where TAttribute : FieldInfoAttribute
    {
        private Dictionary<object, TAttribute> dic = null;
        private Dictionary<object, TAttribute> Dic
        {
            get 
            {
                if (dic == null)
                    dic = EnumHelper<T>.Inst.GetAttributes<TAttribute>().ToDictionary(f => f.FieldValue, f => f);
                return dic; 
            }
        }

        public TAttribute GetAttribute(T t)
        {   
            TAttribute ta = null;
            Dic.TryGetValue(t, out ta);
            return ta;
        }
    }
}
