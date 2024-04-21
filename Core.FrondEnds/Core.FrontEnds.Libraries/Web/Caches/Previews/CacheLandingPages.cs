using Core.Business.Entities.CRM;
using Core.Caching;
using System.Collections.Generic;


namespace Core.FrontEnds.Libraries.Web.Caches.Previews
{
    public class CacheLandingPages : CacheByWebCacheFactory<List<LandingPage>, CacheLandingPages>
    {
        protected override List<LandingPage> LoadForCache()
        {
            return LandingPage.Inst.GetAllToList();
        }
    }
}
