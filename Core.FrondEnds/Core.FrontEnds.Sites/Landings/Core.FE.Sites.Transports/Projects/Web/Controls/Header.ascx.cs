using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.News;
using Core.Web.Extensions;
using System.Linq;

namespace Core.FE.Sites.Transports.Projects.Web.Controls
{
    public partial class Header : Module
    {
        //protected Seo Com = CacheSeo.GetData().FirstOrDefault();
        protected string url_en = "/home-en";
        protected string url_cn = "/home-cn";
        protected string url_jp = "/home-jp";
        protected string url_kr = "/home-kr";

        protected override void BeforeInitData()
        {
            //Lấy categories Parent = 0, và được hiển thị ở MenuNgang.
            var cates = CacheCategories.GetData().Where(c=>c.ParentId == 0 && c.IsShow == true && c.Horizontal == true && c.LanguageId == FeContext.Url.LanguageId).ToList();
            cates.BindTo(rpsmallcate);


            //build url page
            switch (FeContext.Url.LinkType)
            {
                case FeContext.UrlContext.Link.Page:
                    {
                        var pages = CachePageUrls.GetData();
                        var currentpage = pages.FirstOrDefault(c=>c.VirtualUrl == FeContext.Url.Current.Trim('/'));
                        var allLanguageofcurrentPages = pages.Where(c=>c.PageUrlId == currentpage.PageUrlId).ToList();

                        var page_en = allLanguageofcurrentPages.FirstOrDefault(c => c.LanguageId == 1);
                        var page_cn = allLanguageofcurrentPages.FirstOrDefault(c => c.LanguageId == 3);
                        var page_jp = allLanguageofcurrentPages.FirstOrDefault(c => c.LanguageId == 4);
                        var page_kr = allLanguageofcurrentPages.FirstOrDefault(c => c.LanguageId == 5);

                        url_en = page_en != null ? page_en.VirtualUrl : url_en;
                        url_cn = page_cn != null ? page_cn.VirtualUrl : url_cn;
                        url_jp = page_jp != null ? page_jp.VirtualUrl : url_jp;
                        url_kr = page_kr != null ? page_kr.VirtualUrl : url_kr;
                        break;
                    }
                case FeContext.UrlContext.Link.Category:
                    {
                        var categories = CacheCategories.GetData();
                        var currentpages = categories.Where(c => c.CatId == FeContext.Url.Category.CatId).ToList();

                        var page_en = currentpages.FirstOrDefault(c => c.LanguageId == 1);
                        var page_cn = currentpages.FirstOrDefault(c => c.LanguageId == 3);
                        var page_jp = currentpages.FirstOrDefault(c => c.LanguageId == 4);
                        var page_kr = currentpages.FirstOrDefault(c => c.LanguageId == 5);

                        url_en = page_en != null ? page_en.UrlFormat : url_en;
                        url_cn = page_cn != null ? page_cn.UrlFormat : url_cn;
                        url_jp = page_jp != null ? page_jp.UrlFormat : url_jp;
                        url_kr = page_kr != null ? page_kr.UrlFormat : url_kr;
                        break;
                    }
                case FeContext.UrlContext.Link.New:
                    {
                        var news = CacheNews.GetData();
                        var currentpages = news.Where(c => c.NewsId == FeContext.Url.News.NewsId).ToList();

                        var page_en = currentpages.FirstOrDefault(c => c.LanguageId == 1);
                        var page_cn = currentpages.FirstOrDefault(c => c.LanguageId == 3);
                        var page_jp = currentpages.FirstOrDefault(c => c.LanguageId == 4);
                        var page_kr = currentpages.FirstOrDefault(c => c.LanguageId == 5);

                        url_en = page_en != null ? page_en.UrlFormat : url_en;
                        url_cn = page_cn != null ? page_cn.UrlFormat : url_cn;
                        url_jp = page_jp != null ? page_jp.UrlFormat : url_jp;
                        url_kr = page_kr != null ? page_kr.UrlFormat : url_kr;
                        break;
                    }
            }
        }
    }
}