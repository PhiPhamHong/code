using System;

namespace Core.Attributes.Validators
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class NeedValidateAttribute : Attribute
    {
        
    }

    public interface INeedBuildValue
    {
        object BuildValue(object value);
    }
}