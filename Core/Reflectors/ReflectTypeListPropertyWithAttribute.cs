using System;
using Core.Utility;
using System.Collections.Generic;
using System.Reflection;
namespace Core.Reflectors
{
    public class ReflectTypeListPropertyWithAttribute<TAttribute> : DictionaryCacheBase<Type, List<Pair<PropertyInfo, TAttribute>>, ReflectTypeListPropertyWithAttribute<TAttribute>> where TAttribute : Attribute
    {
        protected override List<Pair<PropertyInfo, TAttribute>> GetValueForDic(Type key)
        {
            return MemberInfoHelper.Inst.GetListPairPropertyAttribute<TAttribute>(key, true);
        }
    }

    public class ReflectTypeListPropertyNonePublicWithAttribute<TAttribute> : DictionaryCacheBase<Type, List<Pair<PropertyInfo, TAttribute>>, ReflectTypeListPropertyNonePublicWithAttribute<TAttribute>> where TAttribute : Attribute
    {
        protected override List<Pair<PropertyInfo, TAttribute>> GetValueForDic(Type key)
        {
            return MemberInfoHelper.Inst.GetListPairPropertyNonePublicAttribute<TAttribute>(key, true);
        }
    }
}