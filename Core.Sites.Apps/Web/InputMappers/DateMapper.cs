using System;

using Core.Extensions;
using Core.Attributes;

namespace Core.Sites.Apps.Web.InputMappers
{
    public class DateMapper : PropertyMapper
    {
        public override string DoMap(object value)
        {
            return "{0:dd/MM/yyyy}".Frmat(value);
        }
    }

    public class DateMapperAttribute : PropertyMapperAttribute
    {
        public DateMapperAttribute() : base(typeof(DateMapper)) { }
    }
}