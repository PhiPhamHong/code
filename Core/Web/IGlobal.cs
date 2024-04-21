using System.Collections.Generic;
using System.Configuration;
using Core.Extensions;
using System.Linq;
using System.Web;
using System;

namespace Core.Web
{
    public interface IGlobal
    {
        void Application_Start();
        void Application_BeginRequest();
    }

    public class WebGlobal : HttpApplication
    {
        private static List<IGlobal> CreateGlobal()
        {
            return ConfigurationManager.AppSettings["Global"].WhenEmpty(() => "Core.Sites.Libraries.Utilities.DefaultGlobal,Core.Sites.Libraries").Split('@').Select(t =>
            {
                try { return t.CreateInstance<IGlobal>(); }
                catch { return null; }
            }).Where(t => t != null).ToList();
        }
        private static List<IGlobal> globals = CreateGlobal();

        protected void Application_Start()
        {
            globals.ForEach(g => g.Application_Start());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            globals.ForEach(g => g.Application_BeginRequest());
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}