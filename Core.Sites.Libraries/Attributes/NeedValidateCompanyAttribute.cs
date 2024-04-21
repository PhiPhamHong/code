using Core.Attributes.Validators;
using Core.Sites.Libraries.Business;

namespace Core.Sites.Libraries.Attributes
{
    public class NeedValidateCompanyAttribute : NeedValidateAttribute, INeedBuildValue
    {
        public object BuildValue(object value)
        {
            return PortalContext.CurrentUser.GetCompanyIdAuthen((int)value);
        }
    }
}
