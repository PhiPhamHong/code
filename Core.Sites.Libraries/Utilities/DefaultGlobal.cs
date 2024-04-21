using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Extensions;
using Core.Utility;
using Core.Web;
using System.Web;

namespace Core.Sites.Libraries.Utilities
{
    public class DefaultGlobal : IGlobal
    {
        public void Application_BeginRequest()
        {

        }

        public void Application_Start()
        {
            if (AppSetting.UseWebCenter)
            {
                PortalContext.WebCenter = new WebCenter { };
                PortalContext.WebCenter.Start();
            }
        }
    }
}