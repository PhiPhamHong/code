using Core.Business.Entities;
using Core.Business.Entities.Others.PriceConfigs;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;

namespace Core.Sites.Apps.Web.Projects.Orthers.PriceConfigs.FormProductTypes
{
    [Module]
    [Script(Src = "/Web/Projects/Orthers/PriceConfigs/FormProductTypes/js/ManageProductTypes.js")]
    [ManageModulePermission(Add = Per.P_51001, Edit = Per.P_51002, Delete = Per.P_51003)]
    public partial class ManageProductTypes : ManageModule<ProductType, ProductType.Language, int, int, ManageProductTypes.ModuleProvider, EditProductType, EditProductTypeLanguages>
    {
        public class ModuleProvider : ManageModuleProviderLanguage.Source<ProductType.DataSource> 
        {

        }
    }
}