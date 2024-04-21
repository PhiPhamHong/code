using System;
using Core.Forms;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Cors;
using Owin;
using Core.Sites.Hubs;
namespace Core.Sites.ServerForms.Utilities
{
    public partial class FormCenter
    {
        private IDisposable serverSignalRSelfHost = null;

        [CenterStart(Stt = 2)]
        private void StartSignalRSelfHost()
        {
            serverSignalRSelfHost = WebApp.Start<Startup>(Parent.Config.SignalRSelfHostIP + ":" + Parent.Config.SignalRSelfHostPort);
        }

        [CenterStop]
        private void StopSignalRSelfHost()
        {
            if (serverSignalRSelfHost != null)
                serverSignalRSelfHost.Dispose();
        }
    }
}