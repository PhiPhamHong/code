using Core.Utility;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
namespace Core.Reflectors
{
    public class ReflectTypeListProperty : DictionaryCacheBase<Type, List<PropertyInfo>, ReflectTypeListProperty>
    {
        protected override List<PropertyInfo> GetValueForDic(Type key)
        {
            return key.GetProperties().ToList();
        }
    }
}