using Core.Extensions;
using Core.Utility.Language;

namespace Core.Attributes.Validators
{
    public class ValidatorPhoneNumberAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (Value.IsNull()) return true;
            var phoneNumber = Value.ToString().Trim();
            if (string.IsNullOrEmpty(phoneNumber)) return true;
            phoneNumber = phoneNumber.Replace("(+84)", "0");
            phoneNumber = phoneNumber.Replace("+84", "0");
            phoneNumber = phoneNumber.Replace("0084", "0");

            return phoneNumber.IsValidVietNamPhoneNumber();
        }
        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} không đúng định dạng Số điện thoại").Frmat(FieldName);
        }
    }
}
