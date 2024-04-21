using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using System.Linq;
namespace Core.FrontEnds.Libraries.UrlEngines
{
    public class Url404Engine : IUrlEngine
    {
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            FeContext.Url.LanguageId = 2;
            FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(l => l.LanguageId == 2);
            result.Query = "error=404";
        }
    }
}
