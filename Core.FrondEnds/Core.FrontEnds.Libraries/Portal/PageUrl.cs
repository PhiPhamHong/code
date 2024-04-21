using Core.FrontEnds.Libraries.Portal.Configs;
using Core.Utility;

namespace Core.FrontEnds.Libraries.Portal
{
    public abstract partial class PageUrl
    {
        public string Url { set; get; } // sẽ không bao giờ gồm "http://" + HttpContext.Current.Request.Url.Authority + "/" + 
        public string Extension { set; get; }
        public PagesConfig PagesConfig { set; get; }
        public abstract Pair<string, PageTag> GetPageTag();
    }
}
