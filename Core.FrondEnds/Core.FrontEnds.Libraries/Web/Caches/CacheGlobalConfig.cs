using Core.Business.Entities;
using Core.Caching;


namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheGlobalConfig : CacheByWebCacheFactory<GlobalConfig, CacheGlobalConfig>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override GlobalConfig LoadForCache()
        {
            return GlobalConfig.GetByCompanyId(CompanyId);
        }
    }
}
