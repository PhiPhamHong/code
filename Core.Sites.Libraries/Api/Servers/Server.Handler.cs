using Core.Sites.Libraries.Api.Servers.Entities;

namespace Core.Sites.Libraries.Api.Servers
{
    public partial class Server
    {
        public class Handler : ApiBase
        {
            private const string ApiSendNotifications = "api/SendNotifications";
            private const string ApiResetConfigByCompany = "api/ResetConfigByCompany";
            private const string ApiResetConfigByServer = "api/ResetConfigByServer";

            public Notification.Response SendNotification(Notification.Request request) => Call<Notification.Request, Notification.Response>(ApiSendNotifications, request);
            public ResetConfig.ByCompany.Response ResetConfigByCompany(ResetConfig.ByCompany.Request request) => Call<ResetConfig.ByCompany.Request, ResetConfig.ByCompany.Response>(ApiResetConfigByCompany, request);
            public ResetConfig.ByServer.Response Datasend(ResetConfig.ByServer.Request request) => Call<ResetConfig.ByServer.Request, ResetConfig.ByServer.Response>(ApiResetConfigByServer, request);

        }
    }
}
