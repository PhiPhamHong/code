using Core.Extensions;
using Core.Utility.Language;

namespace Core.Attributes.Validators
{
    public class ValidatorStrongPasswordAttribute : ValidatorAttribute
    {

        public override bool Validate()
        {
            if (Value.IsNull()) return true;
            return Value.ToString().Trim().IsStrongPassword();
        }

        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} không hợp lệ, phải gồm (8 ký tự): chữ thường, chữ hoa, chữ số và ký tự đặc biệt").Frmat(FieldName);
        }
    }
}
