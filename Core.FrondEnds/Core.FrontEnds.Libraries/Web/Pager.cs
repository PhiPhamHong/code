using Core.Utility;
using System;
using System.Web;
using Core.Extensions;
using Core.FrontEnds.Libraries.Extensions;
namespace Core.FrontEnds.Libraries.Web
{
    public partial class Pager
    {
        public int PageSize { get; set; } = FeContext.Url.PageSize;

        private bool hasRender = false;
        private long totalRow = 0;
        public long TotalRow
        {
            get { return totalRow; }
            set
            {
                totalRow = value;
                hasRender = true;
            }
        }

        public int PageIndex { get; set; } = FeContext.Url.PageIndex;

        public string FixUrl { set; get; }

        protected virtual string Extension
        {
            get { return Setting.Extension; }
        }

        public virtual string RenderPager()
        {
            if (!hasRender || TotalPage == 1) return string.Empty;
            return HandlerPage(TotalPage, Url);
        }

        protected int TotalPage
        {
            get { return (int)Math.Ceiling((decimal)TotalRow / PageSize); }
        }

        protected string Url
        {
            get
            {
                var pair = FixUrl.IsNotNull() ? new Pair<string, string> { T1 = FixUrl } : HttpContext.Current.Request.GetCurrentUrlNotPaging(Extension);
                var query = Convert.ToString(HttpContext.Current.Items["VirtualQuery"]);
                if (Extension.IsNull()) return pair.T1 + "/page-{page}" + (query.IsNull() ? "" : query);
                return pair.T1 + "/page-{page}." + Extension + (query.IsNull() ? "" : query);
            }
        }

        public string GetLinkNextPage()
        {
            if (PageIndex >= TotalPage) return string.Empty;
            return Url.Replace("{page}", (PageIndex + 1).ToString());
        }

        protected virtual string HandlerPage(int totalPage, string url)
        {
            var strReturn = "<div class=\"pages\"><strong>Page:</strong><ol>";
            strReturn += CreateLink(PageIndex == 1 ? PageIndex : PageIndex - 1, "Previous", url, TypeLink.First);
            strReturn += CreateLink(TotalRow < PageSize ? PageIndex : PageIndex + 1, "Next", url, TypeLink.Last);
            return strReturn + "</ol></div>";
        }

        private string CreateLink(int Page, string Text, string aHref, TypeLink link = TypeLink.Between)
        {
            return "<li" + (Page == PageIndex ? " class=\"active\"" : "") + "><a" + (Page == PageIndex ? "" : " href=\"" + aHref.Replace("{page}", Page.ToString()) + "\"") + " p='" + Page + "'>" + Text + "</a></li>";
        }

        public enum TypeLink
        {
            First = 0,
            Between = 1,
            Last = 2
        }
    }
}
