using Core.Utility.Language;
using System;
using System.Text.RegularExpressions;
using Core.Extensions;
namespace Core.Attributes.Validators
{
    public class ValidatorNotAllowSpecialCharacterAttribute : ValidatorAttribute
    {
        private static Regex rg = new Regex("^[a-zA-Z0-9 ]*$");

        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} không được chứa ký tự đặc biệt").Frmat(FieldName);
        }

        public override bool Validate()
        {
            if (Value.IsNull()) return true;
            return rg.IsMatch(Value.ToString());
        }
    }
}
