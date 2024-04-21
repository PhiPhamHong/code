using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    [Script(Src = "/Web/Modules/FormUsers/js/FormUserUpdateConfigRuntime.js")]
    [Module]
    public partial class FormUserUpdateConfigRuntime : PortalModule<User.UserSession.ConfigRuntime>, IAjax
    {
        protected override void OnInitData()
        {
            this.SetData("Config", PortalContext.CurrentUser.Config);
        }

        public void SaveConfig()
        {
            this.ParseParamTo(PortalContext.CurrentUser.Config, true);
            PortalContext.CurrentUser.SaveConfig();
        }
    }
}