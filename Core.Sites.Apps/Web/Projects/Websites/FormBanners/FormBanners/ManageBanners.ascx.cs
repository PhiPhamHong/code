using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Projects.Websites.FormBanners.FormBanners
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormBanners/FormBanners/js/ManageBanners.js")]
    [ManageModulePermission(Add = 23401, Edit = 23402, Delete = 23403)]
    public partial class ManageBanners : ManageModule<Banner, Banner.Language, int, int, ManageBanners.ModuleProvider, FormEditBanners, FormEditBannerLanguages>
    {
        public class ModuleProvider : ManageModuleProviderLanguage.Source<Banner.DataSource> { }
    }
}