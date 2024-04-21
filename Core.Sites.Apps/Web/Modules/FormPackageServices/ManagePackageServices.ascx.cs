using Core.Business.Entities;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Sites.Libraries.Business;
namespace Core.Sites.Apps.Web.Modules.FormPackageServices
{
    [Script(Src = "/Web/Modules/FormPackageServices/js/ManagePackageServices.js")]
    [ManageModulePermission(Add = 12, Delete = 14, Edit = 13)]
    [Module]
    public partial class ManagePackageServices : ManageModule<PackageService, ManagePackageServices.ModuleProvider, FormEditPackageService>
    {
        public class ModuleProvider : ManageModuleProvider<PackageService, int>.Source<DataSourceCommon<PackageService>> { }
    }

    
}