using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using System.Linq;

namespace Core.FrontEnds.Libraries.UrlEngines
{
    public class UrlByPageUrlEngine : IUrlEngine
    {
        public int WebsiteId { set; get; }
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            var pages = CachePageUrls.GetData().Where(p => !p.Indirect && p.WebsiteId == WebsiteId);
            foreach (var p in pages)
            {
                if (p.Match)
                {
                    var match = p.Rex.Match(urlVitural);
                    if (match.Success)
                    {
                        result.Meta = p;
                        result.Query = p.Rex.Replace(urlVitural, p.RealUrl) + "&lang=" + p.LanguageId + "&prefix=" + p.Prefix + "&" + p.PageQuery;
                        FeContext.Url.LanguageId = p.LanguageId;
                        FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(l => l.LanguageId == p.LanguageId);
                        return;
                    }
                }
                else if (p.VirtualUrl == urlVitural)
                {
                    result.Meta = p;
                    if (p.LanguageId == 2) p.LanguageId = 1;
                    result.Query = p.PageQuery + "&lang=" + p.LanguageId + "&prefix=" + p.Prefix + "&pageVirtualUrl=" + p.VirtualUrl + "&title=" + p.Title + "&link=" + (urlVitural.Contains("trang-chu") || urlVitural.Contains("home-") ? 0 : 1);
                    FeContext.Url.LanguageId = p.LanguageId;
                    FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(l => l.LanguageId == p.LanguageId);

                    return;
                }
            }
        }
    }
}
