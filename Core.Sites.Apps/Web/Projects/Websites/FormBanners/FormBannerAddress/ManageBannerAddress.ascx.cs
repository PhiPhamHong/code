
using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Projects.Websites.FormBanners.FormBannerAddress
{
    [Script(Src = "Web/Projects/Websites/FormBanners/FormBannerAddress/js/ManageBannerAddress.js")]
    [ManageModulePermission(Add = 23301, Edit = 23302, Delete = 23303)]
    [Module]
    public partial class ManageBannerAddress : ManageModule<Banner.Target, ManageBannerAddress.ModuleProvider,EditBannerAddress>
    {
        public class ModuleProvider : ManageModuleProvider<Banner.Target>.Source<Banner.Target.DataSource> { }
    }
}