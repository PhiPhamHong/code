using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Core.Extensions;
using System.Collections.Generic;
using Core.Sites.Hubs;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(Startup))]
namespace Core.Sites.Hubs
{
    public partial class AppHub : Hub
    {
        public static AppHubServer Server = new AppHubServer();

        public static IHubContext Instance
        {
            get { return GlobalHost.ConnectionManager.GetHubContext<AppHub>(); }
        }

        public void SendMessage(List<string> connectionIds, string msg)
        {
            connectionIds.ForEach(connectionId => { if (connectionId != Context.ConnectionId) Clients.Client(connectionId).receiveMessage(msg); });
        }

        public void SendAllUserMessage(string msg)
        {
            var userState = Server.GetByConnectionId(Context.ConnectionId);
            if (userState == null) return;

            Server.GetByCompany(userState.CompanyId)
                .Where(us => us.UserId != 1)
                .Where(us => us.SessionType == userState.SessionType)
                .Where(us => us.ConnectionId != Context.ConnectionId)
                .ForEach(us => Clients.Client(us.ConnectionId).receiveMessage(msg));
        }

        public void SendSreen(string data, int companyId, int userId)
        {
            Clients.Group(userId.ToString()).receiveScreen(data);
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                // Setup the cors middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    // EnableJSONP = true
                };

                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch is already runs under the "/signalr"
                // path.
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}