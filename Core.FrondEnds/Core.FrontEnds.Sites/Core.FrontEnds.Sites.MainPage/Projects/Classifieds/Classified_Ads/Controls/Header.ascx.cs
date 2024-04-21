using Core.FrontEnds.Libraries.Portal;
using System.Web;

namespace Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads.Controls
{
    public partial class Header : Module
    {
        protected bool IsLogin { get; set; }
        protected override void BeforeInitData()
        {
            var url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("HasLogin"))
            {
                IsLogin = true;
            }
            else
                IsLogin = false;
        }
    }
}