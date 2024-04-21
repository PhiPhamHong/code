using Core.Business.Entities.Websites;
using Core.Caching;
using System.Collections.Generic;

namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheSeo : CacheByWebCacheFactory<List<Seo>, CacheSeo>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<Seo> LoadForCache()
        {
            return Seo.GetAllSeo(CompanyId);
        }
    }
}