using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Core.Utility;
namespace Core.Attributes
{
    public class PropertyIndexAttribute : Attribute
    {
        public int Index { set; get; }
        public TypeCode TypeCode { set; get; }
    }

    /// <summary>
    /// Lưu trữ loại đối tượng và danh sách property với PropertyIndexAttributes
    /// </summary>
    public class TypePropertyIndex : TypePropertyIndex<PropertyIndexAttribute, TypePropertyIndex> { }

    public class TypePropertyIndex<TPropertyIndexAttribute, TTypePropertyIndex> : DictionaryCacheBase<Type, List<Pair<PropertyInfo, TPropertyIndexAttribute>>, TTypePropertyIndex>
        where TPropertyIndexAttribute : PropertyIndexAttribute
        where TTypePropertyIndex : new()
    {
        protected override List<Pair<PropertyInfo, TPropertyIndexAttribute>> GetValueForDic(Type key)
        {
            return key.GetProperties().Select(p => new Pair<PropertyInfo, TPropertyIndexAttribute> { T1 = p, T2 = p.GetCustomAttribute<TPropertyIndexAttribute>() }).Where(k => k.T2 != null).OrderBy(k => k.T2.Index).ToList();
        }
    }
}
