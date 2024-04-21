using Core.Business.Entities.Others.PriceConfigs;
using Core.Caching;
using System.Collections.Generic;

namespace Core.FrontEnds.Libraries.Web.Caches.Orthers.PriceConfigs
{
    public class CacheProductTypes : CacheByWebCacheFactory<List<ProductType>, CacheProductTypes>
    {
        [PropertyCacheOptional("LanguageId")] public int LanguageId { get { return FeContext.Url.LanguageId; } }
        protected override List<ProductType> LoadForCache()
        {
            var data = new ProductType.DataSource { LanguageId = LanguageId, Start = 0, Length = int.MaxValue, FieldOrder = "CreatedDate", Dir = "ASC" }.GetEntities();
            return data;
        }
    }
}
