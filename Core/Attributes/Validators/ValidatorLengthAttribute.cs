using Core.Extensions;
using Core.Utility.Language;
namespace Core.Attributes.Validators
{
    /// <summary>
    /// Validate chiều dài một ký string
    /// </summary>
    public class ValidatorLengthAttribute : ValidatorAttribute
    {
        public int Min { set; get; }
        public int Max { set; get; }

        public override bool Validate()
        {
            if (this.Value.As<string>().IsNull()) return true;

            var length = this.Value == null ? 0 : this.Value.ToString().Length;

            var isMinValid = Min == 0 || length >= Min;
            var isMaxValid = Max == 0 || length <= Max;

            return isMaxValid && isMinValid;
        }

        /// <summary>
        /// Thông báo
        /// </summary>
        /// <returns></returns>
        public override string GetMessage()
        {
            if (Min == 0 && Max != 0)
                return LanguageHelper.GetLabel("{0} phải nhỏ hơn {1} ký tự").Frmat(FieldName, Max);
            else if (Min != 0 && Max == 0)
                return LanguageHelper.GetLabel("{0} phải lớn hơn {1} ký tự").Frmat(FieldName, Min);
            else
                return LanguageHelper.GetLabel("{0} phải từ {1} đến {2} ký tự").Frmat(FieldName, Min, Max);
        }
    }
}
