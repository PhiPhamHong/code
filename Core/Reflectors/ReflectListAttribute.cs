using System.Collections.Generic;
using Core.Utility;
using System.Reflection;
using System;
using System.Linq;
namespace Core.Reflectors
{
    public class ReflectListAttribute<TKey, TAttribute> : DictionaryCacheBase<TKey, List<TAttribute>, ReflectListAttribute<TKey, TAttribute>>
        where TKey : MemberInfo
        where TAttribute : Attribute
    {
        protected override List<TAttribute> GetValueForDic(TKey key)
        {
            return MemberInfoHelper.Inst.GetAttributes<TAttribute>(key, true);
        }
    }
}
