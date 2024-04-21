using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Core.Attributes;
using Core.Utility;
namespace Core.Reflectors
{
    public class ReflectTypeListMethodInfo<TAttribute> : DictionaryCacheBase<Type, List<TAttribute>, ReflectTypeListMethodInfo<TAttribute>> where TAttribute : MethodInfoAttribute
    {
        protected override List<TAttribute> GetValueForDic(Type key)
        {
            return key.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).
                Select(m => Singleton<ReflectMethodInfo<TAttribute>>.Inst[m]).Where(t => t != null).ToList();
        }
    }
}
