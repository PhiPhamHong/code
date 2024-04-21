using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Utility.Language;
using Core.Extensions;
namespace Core.Attributes.Validators
{
    public class ValidatorNotAllowEqualAttribute : ValidatorAttribute
    {
        private readonly string _fieldCompare = string.Empty;

        public ValidatorNotAllowEqualAttribute(string fieldCompare)
        {
            _fieldCompare = fieldCompare;
        }

        public override bool Validate()
        {
            // Lấy giá trị cần so sánh
            object valueCompare; // this.ObjectValidate.GetPropertyValue(this.fieldCompare);

            if (!Data.TryGetValue(_fieldCompare, out valueCompare)) return true;

            // Nếu 1 trong 2 là Null thì không thực hiện validate
            if (valueCompare == null || Value == null) return true;

            return !Value.ToString().Equals(valueCompare.ToString());
        }

        public override string GetMessage()
        {
            string nameAlias = string.Empty;
            var pi = ObjectType.GetProperty(_fieldCompare);
            if (pi != null)
            {
                var fa = MemberInfoHelper.Inst.GetAttribute<FieldAttribute>(pi, true);
                if (fa != null)
                    nameAlias = fa.Name;
            }
            return LanguageHelper.GetLabel("{0} không được bằng {1}").Frmat(FieldName, (nameAlias ?? _fieldCompare));
        }
    }
}
