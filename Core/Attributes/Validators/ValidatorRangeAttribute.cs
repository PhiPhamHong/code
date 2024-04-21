using System;
using Core.Extensions;
using Core.Utility.Language;
namespace Core.Attributes.Validators
{
    public class ValidatorRangeAttribute : ValidatorAttribute
    {
        private RangeType range = RangeType.Between;
        public double Min { set; get; }
        public double Max { set; get; }

        public ValidatorRangeAttribute(RangeType range)
        {
            this.range = range;
        }


        public override bool Validate()
        {
            if (this.Value == null || this.Value.ToString().IsNull()) return true;

            // Giá trị cần so sánh
            var value = Convert.ToDouble(this.Value);

            // Thực hiện so sánh
            switch (range)
            {
                case RangeType.Between: return value >= Min && value <= Max;
                case RangeType.Greater: return value > Min;
            }

            // Mặc định là luôn đúng
            return true;
        }

        public override string GetMessage()
        {
            switch(range)
            {
                case RangeType.Between: return LanguageHelper.GetLabel("{0} phải lớn hơn {1} và nhỏ hơn {2}").Frmat(FieldName, Min, Max);
                default: return LanguageHelper.GetLabel("{0} phải lớn hơn {1}").Frmat(FieldName, Min);
            }
        }
    }

    public enum RangeType
    {
        Between = 0,
        Greater = 1
    }
}
