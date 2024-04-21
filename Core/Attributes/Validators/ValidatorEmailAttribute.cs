using Core.Extensions;
using Core.Utility.Language;
namespace Core.Attributes.Validators
{
    public  class ValidatorEmailAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (Value.IsNull() || (Value is string && Value.ToString().IsNull())) return true;
            return Value.ToString().IsValidEmail();
        }

        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} không đúng định dạng email").Frmat(this.FieldName);
        }
    }
}
