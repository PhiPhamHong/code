using Core.Business.Entities;
using System.Collections.Generic;

namespace Core.Sites.Libraries.Utilities
{
    public interface IHubHelper
    {
        void PushNotification(Notification notification, List<Notification.User> users);
    }
}