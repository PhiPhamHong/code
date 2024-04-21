using Core.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
namespace Core.Reflectors
{
    public class ReflectTypeListPropertyWithListAttribute<TAttribute> : DictionaryCacheBase<Type, List<Pair<PropertyInfo, List<TAttribute>>>, ReflectTypeListPropertyWithListAttribute<TAttribute>> where TAttribute : Attribute
    {
        protected override List<Pair<PropertyInfo, List<TAttribute>>> GetValueForDic(Type key)
        {
            return MemberInfoHelper.Inst.GetListPairPropertyListAttribute<TAttribute>(key, true);
        }
    }
}
