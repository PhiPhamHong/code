using System.Reflection;
using Core.Attributes;
namespace Core.Reflectors
{
    /// <summary>
    /// ReflectMethodInfo MethodInfoAttribute
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    public class ReflectMethodInfo<TAttribute> : ReflectAttribute<MethodInfo, TAttribute> where TAttribute : MethodInfoAttribute
    {
        protected override TAttribute GetValueForDic(MethodInfo key)
        {
            var att = base.GetValueForDic(key);
            if(att != null) att.MethodInfo = key;
            return att;
        }
    }
}
