using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business.Entities;
using Core.Extensions;
using Core.Business.Enums;
using Core.Web.WebBase;
using Core.Business.Entities.Websites;

namespace Core.Sites.Hubs
{
    public partial class AppHub
    {
        public override Task OnConnected()
        {
            Doconnected();
            return base.OnConnected();
        }
        public override Task OnReconnected()
        {
            Doconnected();
            return base.OnReconnected();
        }
        private void Doconnected()
        {
            var userIds = Context.QueryString["token"].Decrypt().SplitTo<int>().Distinct().ToList();
            var sessionType = Context.QueryString["sessionType"].To<SessionType>();

            IUserLogin user = null;
            if (userIds.Count > 0)
            {
                switch(sessionType)
                {
                    case SessionType.Account: user = new User { UserId = userIds[0] }; break;
                    //case SessionType.Partner: user = new Partner.User { UserId = userIds[0] }; break; case Build PartnerSite
                }
                if (!user.GetByKey()) return;
            }
            Groups.Add(Context.ConnectionId, user.UserId + "." + sessionType);

            Server.RemoveByConnectionId(Context.ConnectionId);
            var newUser = Server.NewConnectionId(Context.ConnectionId, user.CompanyId, new UserState
            {
                ConnectionId = Context.ConnectionId,
                UserId = user.UserId,
                UserName = user.UserName,
                Avatar = user.Avatar,
                CompanyId = user.CompanyId,
                Browser = Context.QueryString["browser"],
                Ip = Convert.ToString(Context.Request.Environment["server.RemoteIpAddress"]),
                SessionId = Context.QueryString["appSession"],
                DateConnected = DateTime.Now,
                UserId2 = userIds.Count > 1 ? userIds[1] : 0,
                SessionType = sessionType,
                PartnerId = user.PartnerId
            });

            // Gửi yêu cầu logout khỏi hệ thống với các người cùng tài khoản
            var uu = Server.GetByCompany(newUser.CompanyId).Where(u => u.UserId == newUser.UserId && 
                                                   u.SessionType == newUser.SessionType &&
                                                   u.SessionId != newUser.SessionId && 
                                                   u.ConnectionId != newUser.ConnectionId).ToList();
            LogoutClient(uu.Where(u => 
            {
                if (u.SessionType == SessionType.Account && u.UserId == 1) return false;
                return true;
            }).Select(u => u.ConnectionId).ToList(), "Tài khoản đang sử dụng đã được dùng ở một máy khác!");
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            RemoveByConnectionId(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
        private void RemoveByConnectionId(string connectionId)
        {
            var u = Server.RemoveByConnectionId(connectionId);
            if (u != null)
                NotifyUserStateChange(u, true);
        }
        public void LogoutClient(List<string> connectionIds, string msg)
        {
            connectionIds.ForEach(connectionId => 
            {
                if (connectionId != Context.ConnectionId)
                {
                    Clients.Client(connectionId).logout(msg);
                    RemoveByConnectionId(connectionId);
                }
            });
        }
    }
}