using System;
using Core.Extensions;
using Core.Attributes;
using Core.Utility;
namespace Core.Reflectors
{
    public class ReflectClassInfo<TAttribute> : DictionaryCacheBase<Type, TAttribute, ReflectClassInfo<TAttribute>> where TAttribute : ClassInfoAttribute
    {
        protected override TAttribute GetValueForDic(Type key)
        {
            var att = key.GetAttribute<TAttribute>();
            if (att != null) att.Type = key;            
            return att;
        }
    }
}