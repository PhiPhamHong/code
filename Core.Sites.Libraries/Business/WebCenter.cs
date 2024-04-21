using System.Linq;
using Core.Business.Entities;
namespace Core.Sites.Libraries.Business
{
    public partial class WebCenter
    {
        public void UpdateCompayConfig(CompanyConfig config)
        {

        }
        public void SendNotification(int notificationId)
        {
            var Notification = new Notification { NotificationId = notificationId };
            if (!Notification.GetByKey() || !Notification.IsActive) return;

            // Danh sách những người dùng cần gửi thông báo
            var users = Notification.User.Inst.SelectToList(u => u.NotificationId == notificationId);

            //AppSetting.TravelHubHelper.PushNotification(Notification, users);
        }
    }
}