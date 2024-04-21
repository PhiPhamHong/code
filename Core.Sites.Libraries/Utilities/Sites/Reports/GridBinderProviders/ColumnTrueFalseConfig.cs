using Core.Extensions;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class ColumnTrueFalseConfig : ColumnConfig
    {
        public string TextTrue { set; get; }

        public string TextFalse { set; get; }

        protected override object Format(object value)
        {
            return value.To<bool>() ? TextFalse : TextTrue;
        }
    }
}
