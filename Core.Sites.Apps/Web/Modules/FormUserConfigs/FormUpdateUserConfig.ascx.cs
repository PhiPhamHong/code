using Core.Business.Entities;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.DataBase.ADOProvider;
using System.Collections.Generic;
using Core.DataBase.ADOProvider.Attributes;
namespace Core.Sites.Apps.Web.Modules.FormUserConfigs
{
    [Script(Src = "/Web/Modules/FormUserConfigs/js/FormUpdateUserConfig.js")]
    [Module]
    public partial class FormUpdateUserConfig : FormEdit<UserConfig, ManageModuleProviderUserConfig>
    {
        protected override UserConfig GetForEdit() => UserConfig.GetByUserIdWithDefault(PortalContext.CurrentUser.User.UserId);
    }

    public class ManageModuleProviderUserConfig : ManageModuleProvider<UserConfig, int>
    {
        protected override void Save(UserConfig t, List<LogEntity> logEntities, IDataBaseService service)
        {
            t.UserId = PortalContext.CurrentUser.User.UserId;
            base.Save(t, logEntities, service);
        }
    }
}