using Core.Business.Entities.Others.PriceConfigs;
using Core.Caching;
using System.Collections.Generic;

namespace Core.FrontEnds.Libraries.Web.Caches.Orthers.PriceConfigs
{
    public class CacheDirections : CacheByWebCacheFactory<List<Direction>, CacheDirections>
    {
        [PropertyCacheOptional("LanguageId")] public int LanguageId { get { return FeContext.Url.LanguageId; } }
        protected override List<Direction> LoadForCache()
        {
            var data = new Direction.DataSource { LanguageId = LanguageId, Start = 0, Length = int.MaxValue, FieldOrder = "CreatedDate", Dir = "ASC" }.GetEntities();
            return data;
        }
    }
}
