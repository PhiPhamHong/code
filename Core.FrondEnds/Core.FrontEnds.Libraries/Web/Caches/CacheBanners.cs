using Core.Business.Entities.Websites;
using Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheBanners : CacheByWebCacheFactory<List<Banner.Fe>, CacheBanners>
    {
        [PropertyCacheOptional("LanguageId")] public int LanguageId { get { return FeContext.Url.LanguageId; } }
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<Banner.Fe> LoadForCache()
        {
            var result = Banner.Fe.Get(CompanyId, LanguageId);
            return result;
        }
    }
}
