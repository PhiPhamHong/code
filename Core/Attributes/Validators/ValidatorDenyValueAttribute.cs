using Core.Extensions;
using Core.Utility.Language;
namespace Core.Attributes.Validators
{
    public class ValidatorDenyValueAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            return !Value.ToString().Equals(valueDeny.ToString());
        }
        private object valueDeny = null;
        public ValidatorDenyValueAttribute(object valueDeny)
        {
            this.valueDeny = valueDeny;
        }
        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("Vui lòng chọn {0}").Frmat(FieldName);
        }
    }
}