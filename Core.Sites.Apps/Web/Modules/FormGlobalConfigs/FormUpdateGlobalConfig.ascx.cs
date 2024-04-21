using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
namespace Core.Sites.Apps.Web.Modules.FormGlobalConfigs
{
    [Script(Src = "/Web/Modules/FormGlobalConfigs/js/FormUpdateGlobalConfig.js")]
    [Module]
    public partial class FormUpdateGlobalConfig : FormEdit<GlobalConfig, FormUpdateGlobalConfig.ManageModuleProvider>
    {
        protected override GlobalConfig GetForEdit() => GlobalConfig.GetByCompanyId(PortalContext.Config.CompanyId);
        public class ManageModuleProvider : ManageModuleProvider<GlobalConfig, int>
        {

        }
    }
}