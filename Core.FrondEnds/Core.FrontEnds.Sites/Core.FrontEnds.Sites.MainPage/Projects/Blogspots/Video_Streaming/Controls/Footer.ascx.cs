using Core.FrontEnds.Libraries.Portal;
using System.Web;

namespace Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Video_Streaming.Controls
{
    public partial class Footer : Module
    {
        protected bool Show 
        {
            get
            {
                var url = HttpContext.Current.Request.Url.AbsoluteUri;
                if (url.Contains("Login") || url.Contains("Register") || url.Contains("Forgot"))
                    return false;
                else
                    return true;
            }
        }
    }
}