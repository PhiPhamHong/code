using Core.Business.Entities.Websites;
using Core.Caching;
using System.Collections.Generic;


namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CachePartners : CacheByWebCacheFactory<List<PartnerBottom>, CachePartners>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<PartnerBottom> LoadForCache()
        {
            return new PartnerBottom.DataSource { CompanyId = CompanyId, FieldOrder = "CompanyId" }.GetEntities();
        }
    }
}
