using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
namespace Core.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberInfoHelper : Singleton<MemberInfoHelper>
    {
        public TAttribute GetAttribute<TAttribute>(MemberInfo mi, bool inherit) where TAttribute : Attribute
        {
            var arr = mi.GetCustomAttributes(typeof(TAttribute), inherit);
            return arr.Length == 0 ? null : arr[0] as TAttribute;
        }

        public List<TAttribute> GetAttributes<TAttribute>(MemberInfo mi, bool inherit) where TAttribute : Attribute
        {
            return mi.GetCustomAttributes(typeof(TAttribute), inherit).Cast<TAttribute>().ToList();
        }

        public List<Pair<PropertyInfo, TAttribute>> GetListPairPropertyAttribute<TAttribute>(Type type, bool inherit) where TAttribute : Attribute
        {
            return type.GetProperties().Select(p => new Pair<PropertyInfo, TAttribute> { T1 = p, T2 = GetAttribute<TAttribute>(p, inherit) }).Where(pr => pr.T2 != null).ToList();
        }

        public List<Pair<PropertyInfo, List<TAttribute>>> GetListPairPropertyListAttribute<TAttribute>(Type type, bool inherit) where TAttribute : Attribute
        {
            return type.GetProperties().Select(p => new Pair<PropertyInfo, List<TAttribute>> { T1 = p, T2 = GetAttributes<TAttribute>(p, inherit) }).Where(pr => pr.T2.Count != 0).ToList();
        }

        public List<Pair<PropertyInfo, TAttribute>> GetListPairPropertyNonePublicAttribute<TAttribute>(Type type, bool inherit) where TAttribute : Attribute
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Select(p => new Pair<PropertyInfo, TAttribute> { T1 = p, T2 = GetAttribute<TAttribute>(p, inherit) }).Where(pr => pr.T2 != null).ToList();
        }
    }
}
