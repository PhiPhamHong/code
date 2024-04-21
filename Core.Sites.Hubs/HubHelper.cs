using System;
using System.Linq;
using System.Collections.Generic;
using Core.Business.Entities;
using Core.Extensions;
using Core.Business.Enums;
using Core.Sites.Libraries.Utilities;

namespace Core.Sites.Hubs
{
    public class HubHelper : IHubHelper
    {
        public static void WithGroupUser(int userId, SessionType sessionType, Action<dynamic> withGroup)
        {
            withGroup(AppHub.Instance.Clients.Group(userId + "." + sessionType));
        }

        public void PushNotification(Notification notification, List<Notification.User> users)
        {
            users.GroupBy(u => u.CompanyId).ForEach(g => 
            {
                g.SGroupJoin(AppHub.Server.GetByCompany(g.Key).Where(u => u.SessionType == SessionType.Account), u => u.UserId, us => us.UserId, (u, gu) => 
                {
                    gu.ForEach(gui =>
                    {
                        AppHub.Instance.Clients.Client(gui.ConnectionId).receiveNotification(notification);
                    });
                });
            });
        }
    }
}
