using Core.Web;
using System.Web.Http;
using Core.Web.Api;

namespace Core.Sites.Libraries.Utilities
{
    public class ApiGlobal : IGlobal
    {
        public void Application_BeginRequest()
        {
            
        }

        public void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}