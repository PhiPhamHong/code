using System;
using System.Linq;
using Core.Attributes;
using Core.Utility;
using System.Collections.Generic;
using System.ComponentModel;
namespace Core.Reflectors
{
    public class ReflectFieldInfo<TAttribute> : DictionaryCacheBase<Type, List<TAttribute>, ReflectFieldInfo<TAttribute>> where TAttribute : FieldInfoAttribute
    {
        protected override List<TAttribute> GetValueForDic(Type key)
        {
            return key.GetFields().Select(fi =>
            {
                var arr = fi.GetCustomAttributes(typeof(TAttribute), true);
                return new { Fi = fi, Attr = arr.Length == 0 ? null : arr[0] as TAttribute };
            }).
            Where(fia => fia.Attr != null).
            Select(fia =>
            {
                fia.Attr.FieldInfo = fia.Fi;
                fia.Attr.RawValue = fia.Fi.GetRawConstantValue();
                fia.Attr.FieldValue = TypeDescriptor.GetConverter(fia.Fi.FieldType).ConvertFromString(fia.Attr.RawValue.ToString());
                return fia.Attr;
            }).ToList();
        }
    }

    //public class ReflectEnumAttribute<TAttribute> : DictionaryCacheBase<Type, List<TAttribute>, ReflectEnumAttribute<TAttribute>>
    //    where TAttribute : Attribute
    //{
    //    protected override List<TAttribute> GetValueForDic(Type key)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
