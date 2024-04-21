using Core.Business.Entities.Websites;
using Core.Caching;
using System.Collections.Generic;

namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheMeta : CacheByWebCacheFactory<List<Meta>, CacheMeta>
    {
        [PropertyCacheOptional("LanguageId")] public int LanguageId { get { return FeContext.Url.LanguageId; } }
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<Meta> LoadForCache()
        {
            return Meta.Get(CompanyId, LanguageId);
        }
    }
}
