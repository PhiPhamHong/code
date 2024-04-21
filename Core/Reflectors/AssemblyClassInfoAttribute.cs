using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Core.Attributes;
using Core.Utility;
using Core.Extensions;
namespace Core.Reflectors
{
    /// <summary>
    /// Lấy danh sách ClassInfoAttribute của một Assembly
    /// </summary>
    public class AssemblyClassInfoAttribute<T> : DictionaryCacheBase<Assembly, List<T>, AssemblyClassInfoAttribute<T>> where T : ClassInfoAttribute
    {
        /// <summary>
        /// Thực hiện lấy List ClassInfoAttribute theo Assembly
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override List<T> GetValueForDic(Assembly key)
        {
            return key.GetTypes().Select(t => ReflectClassInfo<T>.Inst[t]).Where(t => t.IsNotNull()).ToList();
        }
    }

    /// <summary>
    /// Lấy danh sách ClassInfoAttribute của một Assembly theo Type
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <typeparam name="TType"></typeparam>
    public class AssemblyClassInfoAttribute<TAttribute, TType> : DictionaryCacheBase<Assembly, List<TAttribute>, AssemblyClassInfoAttribute<TAttribute, TType>> where TAttribute : ClassInfoAttribute
    {
        /// <summary>
        /// Thực hiện lấy List ClassInfoAttribute theo Assembly
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override List<TAttribute> GetValueForDic(Assembly key)
        {
            // Type cần lọc
            var typeOf = typeof(TType);

            // return List Attribute ClassInfoAttribute theo các Type được lọc
            return key.GetTypes().Where(t => t.BaseType.CompareType(typeOf)).Select(t => ReflectClassInfo<TAttribute>.Inst[t]).Where(t => t.IsNotNull()).ToList();
        }
    }
}
