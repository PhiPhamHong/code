using Core.Attributes;
using Core.Extensions;

namespace Core.Business.Mappers
{
    public class DateMapper : PropertyMapper
    {
        public override string DoMap(object value) => "{0:dd/MM/yyyy}".Frmat(value);
    }

    public class DateMapperAttribute : PropertyMapperAttribute
    {
        public DateMapperAttribute() : base(typeof(DateMapper)) { }
    }
}
