using Core.Business.Entities.ERP;
using Core.Extensions;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.Products;
using System.Collections.Generic;
using System.Linq;

namespace Core.FrontEnds.Libraries.UrlEngines.Products
{
    public class UrlProductDetailEngine : IUrlEngine
    {
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            var product = CacheProducts.GetData().FirstOrDefault(c => c.Alias == urlVitural);
            if (product == null) return;
            product.Title = product.Name;
            result.Meta = product;
            FeContext.Url.LanguageId = product.LanguageId;
            FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(l => l.LanguageId == product.LanguageId);

            FeContext.Url.Product.LanguageId = product.LanguageId;
            FeContext.Url.Product.Entity = product;

            result.Query = GetQuery(product).JoinString(q => q, "&");
        }

        private IEnumerable<string> GetQuery(Product product)
        {
            yield return "link=3";
            yield return "productId=" + product.ProductId;
            yield return "catId=" + product.CatId;
        }
    }
}
