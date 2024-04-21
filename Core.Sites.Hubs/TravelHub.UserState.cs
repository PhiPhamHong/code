using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Core.Extensions;
using Core.Business.Enums;

namespace Core.Sites.Hubs
{
    public partial class AppHub
    {
        public class UserState
        {
            public string ConnectionId { set; get; }
            public int CompanyId { set; get; }
            public int UserId { set; get; }
            public string UserName { set; get; }
            public string Avatar { set; get; }
            public bool WindowFocus { set; get; }
            public string ModuleName { set; get; }
            public string Browser { set; get; }
            public string Ip { set; get; }
            public string SessionId { set; get; }
            public DateTime DateConnected { set; get; }
            public int UserId2 { set; get; }
            public SessionType SessionType { set; get; }
            public int PartnerId { set; get; }

            public bool WantFollowForViewUserState { set; get; }
        }

        public void SendUserState(bool windowFocus, string moduleName)
        {
            Server.UpdateByConnectionId(Context.ConnectionId, u =>
            {
                u.WindowFocus = windowFocus;
                u.ModuleName = moduleName;

                NotifyUserStateChange(u);
            });
        }
        private void NotifyUserStateChange(UserState u, bool remove = false)
        {
            if (u.UserId == 1) return;
            // Gửi thông tin trạng thái User vừa thay đổi xuống Client (của người quản lý)
            Server.GetByCompany(u.CompanyId)
                .Where(us => us.SessionType == u.SessionType)
                .Where(us => us.WantFollowForViewUserState)
                .ForEach(us => Clients.Client(us.ConnectionId).notifyUserStateChange(u, remove));
        }

        public List<UserState> SendRegistryRoomViewUserState()
        {
            var userState = Server.GetByConnectionId(Context.ConnectionId);
            if (userState == null) return null;
            userState.WantFollowForViewUserState = true;
            return Server.GetByCompany(userState.CompanyId).Where(us => us.UserId != 1)
                                     .Where(us => us.SessionType == userState.SessionType).ToList();
        }
        public void SendUnRegistryRoomViewUserState()
        {
            var userState = Server.GetByConnectionId(Context.ConnectionId);
            if (userState != null)
                userState.WantFollowForViewUserState = false;
        }

        public class Company
        {
            public int CompanyId { set; get; }
            public ConcurrentDictionary<string, UserState> Users
            {
                get { return users; }                
            }
            private ConcurrentDictionary<string, UserState> users = new ConcurrentDictionary<string, UserState>();

            public UserState NewConnectionId(string connectionId, UserState u)
            {
                return Users[connectionId] = u;
            }
            public UserState GetByConnectionId(string connectionId)
            {
                UserState u = null;
                Users.TryGetValue(connectionId, out u);
                return u;
            }
            public UserState UpdateByConnectionId(string connectionId, Action<UserState> action)
            {
                UserState u = null;
                if (Users.TryGetValue(connectionId, out u))
                    action(u);
                return u;
            }
        }
    }

    public static class TravelHubCompanyExtension
    {
        public static AppHub.UserState FindByConnectionId(this ConcurrentDictionary<int, AppHub.Company> Companies, string connectionId)
        {
            foreach (var kv in Companies)
            {
                var u = kv.Value.GetByConnectionId(connectionId);
                if (u != null) return u;
            }
            return null;
        }
        public static AppHub.UserState RemoveByConnectionId(this ConcurrentDictionary<int, AppHub.Company> Companies, string connectionId)
        {
            foreach (var kv in Companies)
            {
                AppHub.UserState u = null;
				if (kv.Value.Users.TryRemove(connectionId, out u))
					return u;
            }
            return null;
        }
    }
}