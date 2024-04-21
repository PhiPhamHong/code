using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;


namespace Core.Sites.Apps.Web.Projects.Websites.FormHashtags
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormHashtags/js/ManageHashtags.js")]
    [ManageModulePermission(Add = Per.P_22801, Edit = Per.P_22802, Delete = Per.P_22803)]
    public partial class ManageHashtags : ManageModule<Hashtag, Hashtag.Language, int, int, ManageHashtags.ModuleProvider, EditHashtag, EditHashtagLanguages>
    {
        public class ModuleProvider : ManageHashtags.ManageModuleProviderLanguage.Source<Hashtag.DataSource> { }
    }
}