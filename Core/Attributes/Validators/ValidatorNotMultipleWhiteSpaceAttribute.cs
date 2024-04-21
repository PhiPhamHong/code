using System.Text.RegularExpressions;
using Core.Extensions;
using Core.Utility.Language;
namespace Core.Attributes.Validators
{
    /// <summary>
    /// Không được phép nhiều khoảng trắng liên tiếp nhau
    /// </summary>
    public class ValidatorNotMultipleWhiteSpaceAttribute : ValidatorAttribute
    {
        /// <summary>
        /// regex kiểm tra có 2 ký tự trắng liên tiếp hay không
        /// </summary>
        private static Regex regex = new Regex("\\s\\s");

        public override bool Validate()
        {
            if (this.Value == null) return true;

            return !regex.Match(this.Value.ToString()).Success;
        }

        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} không được chứa các khoảng trắng liên tiếp").Frmat(FieldName);
        }
    }
}
