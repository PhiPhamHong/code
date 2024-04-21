
using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Projects.Websites.FormPageUrls
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormPageUrls/js/ManagePageUrls.js")]
    [ManageModulePermission(Add = 23201, Edit = 23202, Delete = 23203)]
    public partial class ManagePageUrls : ManageModule<PageUrl, PageUrl.Language, int, int, ManagePageUrls.ModuleProvider, FormEditPageUrl, FormEditPageUrlLanguage>
    {
        public class ModuleProvider : ManageModuleProvider<PageUrl, PageUrl.Language, int, int>.Source<PageUrl.DataSource> { }
    }
}