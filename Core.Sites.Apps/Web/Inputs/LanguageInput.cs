using Core.Sites.Libraries.Business;
using Core.Business.Entities;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Inputs
{
    public class LanguageInput : SelectModel<Language, LanguageInput>
    {
        public override string ToString()
        {
            if (value == null || value.Length == 0) Value(PortalContext.DefaultLanguage);
            SetFireChange("LanguageId");
            return base.ToString();
        }

        public class SelectData : SelectDataAttribute
        {
            public SelectData() : base("LanguageId") { }
            public override bool NeedBuildValue
            {
                get { return true; }
            }
            public override object BuildValue(object value)
            {
                var languageId_ = (int)value;
                if (languageId_ == 0) languageId_ = PortalContext.DefaultLanguage;
                return languageId_;
            }
        }
    }
}