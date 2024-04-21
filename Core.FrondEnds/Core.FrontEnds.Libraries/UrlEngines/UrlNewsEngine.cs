using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.News;
using System.Collections.Generic;
using Core.Extensions;
using System.Linq;
using Core.Business.Entities.Websites;

namespace Core.FrontEnds.Libraries.UrlEngines
{
    public class UrlNewsEngine : IUrlEngine
    {
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            var news = CacheNews.GetData().FirstOrDefault(c => c.Alias == urlVitural);
            if (news == null || news.NewsId == 0) return;

            FeContext.Url.News.NewsId = news.NewsId;
            FeContext.Url.News.Alias = news.Alias;
            FeContext.Url.News.Entity = news;
            FeContext.Url.LanguageId = news.LanguageId;
            FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(l => l.LanguageId == news.LanguageId);

            result.Meta = news;
            result.Query = GetQuery(news).JoinString(s => s, "&");
        }
        private IEnumerable<string> GetQuery(News.Fe news)
        {
            yield return "nalias=" + news.Alias;
            yield return "link=2";
            yield return "lang=" + news.LanguageId;
            yield return "cattype=" + (int)Category.Type.News;
            yield return "catid=" + news.CatId;
        }
    }
}
