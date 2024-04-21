
using Core.Business.Entities.ERP;
using Core.Caching;
using System.Collections.Generic;

namespace Core.FrontEnds.Libraries.Web.Caches.Products
{
    public class CacheProducts : CacheByWebCacheFactory<List<Product>, CacheProducts>
    {
        [PropertyCacheOptional("LanguageId")] public int LanguageId { get { return FeContext.Url.LanguageId == 0 ? 2 : FeContext.Url.LanguageId; } }
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<Product> LoadForCache()
        {
            var data = new Product.DataSource { CompanyId = CompanyId, LanguageId = LanguageId, FieldOrder = "CompanyId" }.GetEntities();
            data.ForEach(c => { c.Avatar = "https://sserp.vn" + c.Avatar; });
            data.ForEach(c => { c.UrlFormat = FeUrl.GetUrl(c.Alias); });
            return data;
        }
    }
}
