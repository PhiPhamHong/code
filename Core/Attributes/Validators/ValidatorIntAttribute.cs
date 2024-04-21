using Core.Extensions;
using Core.Utility.Language;
using System;

namespace Core.Attributes.Validators
{
    public class ValidatorIntAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            try
            {
                var s = Value.To<int>();
                if (s > int.MaxValue)
                    return false;
                else
                    return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} phải là số nguyên và nhỏ hơn " + int.MaxValue + "").Frmat(FieldName);
        }
    }
}
