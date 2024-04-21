using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.Web.Caches;
using System.Linq;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web
{
    public partial class FeContext
    {
        public static UrlContext Url
        {
            get { return Get(() => new UrlContext(), "Url"); }
        }

        

        public partial class UrlContext
        {
            public int LanguageId { set; get; }
            public Language Language { set; get; }
            public int CompanyId
            {
                get
                {
                    return Setting.CurrentCompanyId;
                }
            }
            public bool Ajax { get { return GetParam<bool>("pageAjax"); } }
            public bool IsHome { get { return GetParam<bool>("IsHome"); } }
            public int PageIndex { get { return GetParam("page", 1); } }
            public int PageSize { get { return GetParam("size", 12); } }

            public string PageTitle { get { return GetParam("title"); } }
            public string Prefix { get { return GetParam("prefix"); } }
            public string Current { get { return Get<string>("VirtualUrl"); } }
            public string Path { get { return Get<string>("VirtualPath"); } }
            public Link LinkType { get { return GetParam<Link>("link"); } }
            public string Keyword { get { return Get<string>("qs_q"); } }

            public string GetCurrentLink(int languageId)
            {
                switch (LinkType)
                {
                    case Link.Category: return FeUrl.GetUrl(CacheCategories.GetData().FirstOrDefault(c => c.CatId == Category.Entity.CatId && c.LanguageId == languageId), PageIndex, Keyword);

                    //case Link.News: return FeUrl.GetUrl(CacheNewsByNewsId.GetData(PageNewsDetail.News.NewsId).FirstOrDefault(n => n.LanguageId == languageId));
                    //case Link.News2:
                    //    var news = CacheNewsByNewsId.GetData(PageNewsDetail.News.NewsId).FirstOrDefault(n => n.LanguageId == languageId);
                    //    return UrlHelper.Inst.GetUrl(news, news.NewsId);
                    default: return GetCurrentLink(Prefix, PageIndex, Keyword, languageId);
                }
            }
            public static string GetCurrentLink(string prefix, int pageIndex, string keyword, int languageId)
            {
                var pageUrl = CachePageUrls.GetData().FirstOrDefault(c => c.Prefix == prefix && c.LanguageId == languageId);
                if (pageUrl == null) return null;

                return pageUrl.Match ?
                    GetLink2(pageUrl, pageUrl.TemplateUrls[1].Split(',').Select(q => GetParam<string>(q)).ToArray()) :
                    GetLink(pageUrl, pageIndex, keyword);
            }

            public static string GetLink(string prefix, int pageIndex = 0, string keyword = "") { return GetLink(prefix, pageIndex, keyword, Url.LanguageId); }
            public static string GetLink(string prefix, int pageIndex, string keyword, int languageId)
            {
                if (languageId == 0) languageId = FeContext.DefaultLanguageId;
                var pageUrl = CachePageUrls.GetData().FirstOrDefault(c => !c.Match && c.Prefix == prefix && c.LanguageId == languageId);
                if (pageUrl == null) return null;
                return GetLink(pageUrl, pageIndex, keyword);
            }
            public static string GetLink(string prefix, int languageId)
            {
                return GetLink(prefix, 0, string.Empty, languageId);
            }
            public static string GetLink(PageUrl.Fe pageUrl, int pageIndex, string keyword)
            {
                return FeUrl.GetUrl(pageUrl.VirtualUrl, pageIndex, keyword);
            }

            public static string GetLink2(string prefix, params object[] @params) { return GetLink2(prefix, Url.LanguageId, @params); }
            public static string GetLink2(string prefix, int languageId, params object[] @params)
            {
                var pageUrl = CachePageUrls.GetData().FirstOrDefault(c => c.Match && c.Prefix == prefix && c.LanguageId == languageId);
                if (pageUrl == null) return null;
                return GetLink2(pageUrl, @params);
            }
            public static string GetLink2(PageUrl.Fe pageUrl, params object[] @params)
            {
                return FeUrl.GetUrl(pageUrl.TemplateUrls[0].Frmat(@params));
            }

            public enum Link : byte
            {
                Normal = 0,    // Dành cho các đường link kiểu như home,about-us (Link fix cứng)
                Page = 1,
                New = 2,
                Category = 3,  // Link chuyên mục
            }
        }
    }
}
