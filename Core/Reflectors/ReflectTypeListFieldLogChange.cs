using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Core.Attributes;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Extensions;
namespace Core.Reflectors
{
    public class ReflectTypeListFieldLogChange : DictionaryCacheBase<Type, List<Pair<PropertyInfo, IFieldLogChange>>, ReflectTypeListFieldLogChange>
    {
        protected override List<Pair<PropertyInfo, IFieldLogChange>> GetValueForDic(Type key)
        {
            return ReflectTypeListPropertyWithAttribute<PropertyInfoAttribute>.Inst[key]
                .Where(p => p.T2.Is<IFieldLogChange>())
                .Select(p => new Pair<PropertyInfo, IFieldLogChange> 
                {
                    T1 = p.T1,
                    T2 = p.T2.As<IFieldLogChange>()
                }).ToList();
        }
    }
}