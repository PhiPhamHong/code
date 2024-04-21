using System;
using System.Reflection;
using Core.Utility;
namespace Core.Reflectors
{
    public class ReflectAttribute<TKey, TAttribute> : DictionaryCacheBase<TKey, TAttribute, ReflectAttribute<TKey, TAttribute>>
        where TKey : MemberInfo
        where TAttribute : Attribute
    {
        protected override TAttribute GetValueForDic(TKey key)
        {
            return MemberInfoHelper.Inst.GetAttribute<TAttribute>(key, true);
        }
    }
}
