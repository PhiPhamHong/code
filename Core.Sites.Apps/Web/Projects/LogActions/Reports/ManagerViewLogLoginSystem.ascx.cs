
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;



namespace Core.Sites.Apps.Web.Projects.LogActions.Reports
{
    [Script(Src = "Web/Projects/LogActions/Reports/js/ManagerViewLogLoginSystem.js")]
    [Module]
    public partial class ManagerViewLogLoginSystem : ManageModule<User.LoginLog, ManagerViewLogLoginSystem.ModuleProvider>
    {
        public class ModuleProvider : ManageModuleProvider<User.LoginLog>.Source<User.LoginLog.DataSource>
        {
            
        }
    }
}