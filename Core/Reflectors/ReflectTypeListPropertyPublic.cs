using Core.Utility;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
namespace Core.Reflectors
{
    public class ReflectTypeListPropertyPublic : DictionaryCacheBase<Type, List<PropertyInfo>, ReflectTypeListPropertyPublic>
    {
        protected override List<PropertyInfo> GetValueForDic(Type key)
        {
            return key.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
        }
    }
}
