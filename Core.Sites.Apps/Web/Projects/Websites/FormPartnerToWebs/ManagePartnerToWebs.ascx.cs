using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;

namespace Core.Sites.Apps.Web.Projects.Websites.FormPartnerToWebs
{
    [Script(Src = "Web/Projects/Websites/FormPartnerToWebs/js/ManagePartnerToWebs.js")]
    [ManageModulePermission(Add = Per.P_52001, Edit = Per.P_52002, Delete = Per.P_52003)]
    [Module]
    public partial class ManagePartnerToWebs : ManageModule<PartnerBottom, ManagePartnerToWebs.ModuleProvider, EditPartnerToWeb>
    {
        public class ModuleProvider : ManageModuleProvider<PartnerBottom>.Source<PartnerBottom.DataSource> { }
    }
}