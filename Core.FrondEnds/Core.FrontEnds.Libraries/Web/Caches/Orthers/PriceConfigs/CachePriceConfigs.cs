using Core.Business.Entities.Others.PriceConfigs;
using Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrontEnds.Libraries.Web.Caches.Orthers.PriceConfigs
{
    public class CachePriceConfigs : CacheByWebCacheFactory<List<PriceConfig>, CachePriceConfigs>
    {
        protected override List<PriceConfig> LoadForCache()
        {
            var data = new PriceConfig.DataSource { }.GetEntities();
            return data;
        }
    }
}
