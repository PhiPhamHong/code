using Core.Business.Entities.ERP;
using Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrontEnds.Libraries.Web.Caches.Products
{
    public class CacheFacturers : CacheByWebCacheFactory<List<Product.ManuFacturer>, CacheFacturers>
    {
        protected override List<Product.ManuFacturer> LoadForCache()
        {
            return new Product.ManuFacturer.DataSource { CompanyId = 1, FieldOrder = "CompanyId" }.GetEntities();
        }
    }
}
