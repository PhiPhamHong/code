using Core.Business.Entities;
using Core.Business.Entities.Others.PriceConfigs;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;


namespace Core.Sites.Apps.Web.Projects.Orthers.PriceConfigs.FormDirections
{
    [Module]
    [Script(Src = "/Web/Projects/Orthers/PriceConfigs/FormDirections/js/ManageDirections.js")]
    [ManageModulePermission(Add = Per.P_51001, Edit = Per.P_51002, Delete = Per.P_51003)]
    public partial class ManageDirections : ManageModule<Direction, Direction.Language, int, int, ManageDirections.ModuleProvider, EditDirection, EditDirectionLanguages>
    {
        public class ModuleProvider : ManageModuleProviderLanguage.Source<Direction.DataSource> 
        {

        }
    }
}