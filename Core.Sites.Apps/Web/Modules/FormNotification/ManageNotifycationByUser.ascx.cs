
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
using Core.Sites.Libraries.Business;


namespace Core.Sites.Apps.Web.Modules.FormNotification
{
    [Script(Src = "/Web/Modules/FormNotification/js/ManageNotifycationByUser.js")]
    [Module]
    public partial class ManageNotifycationByUser : ManageModule<Notification.User.ItemByUser, ManageNotifycationByUser.ModuleProvider>
    {
        public class ModuleProvider : ManageModuleProviderBase<Notification.User.ItemByUser>.Source<Notification.User.ItemByUser.DataSource>
        {
            protected override void OnCreateDataSource(Notification.User.ItemByUser.DataSource source) => source.UserId = PortalContext.CurrentUser.User.UserId;
        }
    }
}