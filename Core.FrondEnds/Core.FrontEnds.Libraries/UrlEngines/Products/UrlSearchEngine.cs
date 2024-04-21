using Core.Extensions;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.Products;
using System.Collections.Generic;
using System.Linq;

namespace Core.FrontEnds.Libraries.UrlEngines.Products
{
    public class UrlSearchEngine : IUrlEngine
    {
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            if (urlVitural.Contains("timkiem"))
            {
                FeContext.Url.Search.Type = 1;
                FeContext.Url.Search.Content = urlVitural.Split('=')[1];
            }
            else
            {
                if (urlVitural.Contains("hangmaytinh"))
                {
                    FeContext.Url.Search.Type = 2;
                    FeContext.Url.Search.Facturers = CacheFacturers.GetData().Where(c => c.Code.ToLower() == urlVitural.Split('=')[1]).ToList();
                }
            }
            FeContext.Url.LanguageId = 2;
            FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(c => c.LanguageId == 2);
            result.Query = GetQuery(urlVitural.Split('=')[1]).JoinString(q => q, "&");
        }

        private IEnumerable<string> GetQuery(string abc)
        {
            yield return "link=3";
            yield return "content=" + abc;
        }
    }
}
