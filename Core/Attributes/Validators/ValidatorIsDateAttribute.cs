using Core.Extensions;
using System;
using Core.Utility.Language;
namespace Core.Attributes.Validators
{
    public class ValidatorIsDateAttribute : ValidatorAttribute
    {
        /// <summary>
        /// Xem có đúng định dạng ngày hay không
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            try
            {
                if (Value != null && Value.ToString().Trim().IsNotNull()) Value.To<DateTime>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} không đúng định dạng ngày").Frmat(FieldName);
        }
    }
}
