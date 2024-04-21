using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
using System.Linq;
using System.Collections.Generic;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using Core.DataBase.ADOProvider;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Modules.FormNotification
{
    [Script(Src = "/Web/Modules/FormNotification/js/ManageNotifications.js")]
    [ManageModulePermission(Add = 22601, Edit = 22602, Delete = 22603)]
    [Module]
    public partial class ManageNotifications : ManageModule<Notification, ManageNotifications.ModuleProvider, FormEditNotification>, IAjax
    {
        public class ModuleProvider : ManageModuleProvider<Notification, int>.Source<Notification.DataSource>
        {
            public class StoreDataSave
            {
                public List<Notification.User> Users { set; get; }
                public List<CompanyConfig> CompanyConfigs { set; get; }
                public string CompanyIds { set; get; }
                public List<User> UsersByCompanyIds { set; get; }
            }
            private StoreDataSave DataSave { set; get; }
            protected override void OnBeforeSave(Notification t)
            {
                DataSave = new StoreDataSave { };
                // Danh sách các users đã được gửi cảnh báo trước đó
                DataSave.Users = t.NotificationId == 0
                    ? new List<Notification.User> { }
                    : Notification.User.Inst.SelectToList(u => u.NotificationId == t.NotificationId);

                // Tìm các công ty phù hợp với thông báo này
                DataSave.CompanyConfigs = CompanyConfig.Inst.GetAllCastToList().ToList();

                // Danh sách người dùng của các công ty được thông báo
                DataSave.CompanyIds = DataSave.CompanyConfigs.JoinString(c => c.CompanyId);
                DataSave.UsersByCompanyIds = User.GetAllByCompanyIds(DataSave.CompanyIds);
            }
            sealed protected override bool UseTransactionInSave => true;
            sealed protected override void Save(Notification t, List<LogEntity> logEntities, IDataBaseService service)
            {
                t.InService(service).Save();

                // Những người dùng mới cần được thông báo
                DataSave.UsersByCompanyIds.FindNewItems(DataSave.Users, uc => uc.UserId, u => u.UserId)
                        .ForEach(uc =>
                        {
                            new Notification.User { UserId = uc.UserId, CompanyId = uc.CompanyId, NotificationId = t.NotificationId }
                                .InService(service).Insert();
                        });

                // Nếu là cập nhật lại thông báo thì đánh dấu lại để người dùng đọc lại
                DataSave.UsersByCompanyIds.Join(DataSave.Users, uc => uc.UserId, u => u.UserId, (uc, u) =>
                {
                    u.DateKnown = null;
                    u.DateViewed = null;
                    u.Viewed = false;
                    u.Known = false;
                    return u;
                }).ForEach(u => u.InService(service).Update());

                // Xóa những người dùng không cần được thông báo nữa
                DataSave.Users.FindNewItems(DataSave.UsersByCompanyIds, u => u.UserId, uc => uc.UserId).ForEach(u => u.InService(service).Delete());

                //PortalContext.GlobalConfig.ServerDriver.SendNotification(new SendNotification.Request { NotificationId = t.NotificationId });
            }
        }
        public void LoadNotifications()
        {
            var items = Notification.User.LoadByUserId(PortalContext.CurrentUser.User.UserId);
            this.SetData("Items", items);
        }
        public void UpdateKnown() => Notification.User.UpdateKnown(PortalContext.CurrentUser.User.UserId);
        public void UpdateViewed() => Notification.User.UpdateViewed(PortalContext.CurrentUser.User.UserId, this.Query<int>("id"));

    }
}