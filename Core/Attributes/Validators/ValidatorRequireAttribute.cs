using Core.Utility.Language;
using Core.Extensions;
namespace Core.Attributes.Validators
{
    public class ValidatorRequireAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (this.Value == null) return false;
            if (string.IsNullOrEmpty(this.Value.ToString().Trim())) return false;
            return true;
        }
        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} không được để trống").Frmat(FieldName);
        }
    }
}
