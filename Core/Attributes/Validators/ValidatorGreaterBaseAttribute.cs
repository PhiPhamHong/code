using System;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Extensions;
using Core.Utility.Language;
namespace Core.Attributes.Validators
{
    public abstract class ValidatorGreaterBaseAttribute : ValidatorAttribute
    {
        /// <summary>
        /// Field cần được so sánh giá trị
        /// </summary>
        private readonly string _fieldCompare = string.Empty;

        public ValidatorGreaterBaseAttribute(string fieldCompare)
        {
            _fieldCompare = fieldCompare;
        }

        /// <summary>
        /// Thực hiện lấy message khi dữ liệu không đúng
        /// </summary>
        /// <returns></returns>
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

            return LanguageHelper.GetLabel("{0} phải lớn hơn {1}").Frmat(FieldName, (nameAlias ?? _fieldCompare));
        }

        /// <summary>
        /// Thực hiện validate
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            // Lấy giá trị cần so sánh
            object valueCompare; // this.ObjectValidate.GetPropertyValue(this.fieldCompare);

            if (!Data.TryGetValue(_fieldCompare, out valueCompare)) return true;

            // Nếu 1 trong 2 là Null thì không thực hiện validate
            if (valueCompare == null || Value == null) return true;

            // Đúng khi mà lớn hơn
            return IsValueGreater(valueCompare);
        }

        protected abstract bool IsValueGreater(object valueCompare);
    }

    /// <summary>
    /// Validate giá trị lớn hơn với kiểu Double
    /// </summary>
    public class ValidatorGreaterAttribute : ValidatorGreaterBaseAttribute
    {
        public ValidatorGreaterAttribute(string fieldName) : base(fieldName) { }

        protected override bool IsValueGreater(object valueCompare)
        {
            if (Value == null || valueCompare == null || string.IsNullOrEmpty(Value.ToString().Trim())
                || string.IsNullOrEmpty(valueCompare.ToString().Trim())) return true;
            return Convert.ToDouble(Value) >= Convert.ToDouble(valueCompare);
        }
    }

    /// <summary>
    /// Validate giá trị lớn hơn kiểu DateTime
    /// </summary>
    public class ValidatorDateGreaterAttribute : ValidatorGreaterBaseAttribute
    {
        public ValidatorDateGreaterAttribute(string fieldName) : base(fieldName) { }

        protected override bool IsValueGreater(object valueCompare)
        {
            if (Value == null || string.IsNullOrEmpty(Value.ToString().Trim())) return true;
            if (valueCompare == null || string.IsNullOrEmpty(valueCompare.ToString().Trim())) return true;

            var to = Value.To<DateTime>();
            if (to == DateTime.MinValue) return true;

            var from = valueCompare.To<DateTime>();
            if (from == DateTime.MinValue) return true;

            return to >= from;
        }
    }

    public class ValidatorDateGreaterNowAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (Value == null) return true;
            return Value.To<DateTime>() >= DateTime.Today;
        }

        public override string GetMessage()
        {
            return LanguageHelper.GetLabel("{0} phải lớn hơn ngày hiện tại").Frmat(FieldName);
        }
    }
}