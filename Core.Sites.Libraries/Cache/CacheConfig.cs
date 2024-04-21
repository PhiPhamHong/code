using Core.Business.Entities;
using Core.Caching;

namespace Core.Sites.Libraries.Cache
{
    public class CacheConfig : CacheByWebCacheFactory<CompanyConfig>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { set; get; }

        protected override CompanyConfig LoadForCache()
        {
            return CompanyConfig.Inst.GetByCompanyId(CompanyId);
        }
    }
}
