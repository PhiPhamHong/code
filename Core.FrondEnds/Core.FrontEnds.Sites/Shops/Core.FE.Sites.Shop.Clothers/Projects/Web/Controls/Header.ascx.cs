using Core.FrontEnds.Libraries.Portal;
using System.Web;

namespace Core.FE.Sites.Shop.Clothers.Projects.Web.Controls
{
    public partial class Header : Module
    {
        protected bool IsLogin { get; set; }
        protected override void BeforeInitData()
        {
            var url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("HomeLogin"))
            {
                IsLogin = true;
            }
            else
                IsLogin = false;
        }
    }
}