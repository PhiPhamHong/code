using Core.Business.Entities.Websites;
using Core.Caching;
using System.Collections.Generic;
using System.Linq;
using Core.FrontEnds.Libraries.Extensions;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheCategories : CacheByWebCacheFactory<List<Category.Fe>, CacheCategories>
    {
      
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<Category.Fe> LoadForCache()
        {
            var data = Category.Fe.Get(CompanyId).OrderBy(c => c.Stt).ToList();
            data.ForEach(c => { c.UrlFormat = FeUrl.GetUrl(c.Alias); });
            data.Where(c => c.ParentId == 0).ForEach(c => CalTotal(data, c));
            return data;
        }
        private static void CalTotal(List<Category.Fe> data, Category.Fe category)
        {
            var childs = data.Where(c => c.ParentId == category.CatId);
            var total = 0;
            foreach (var child in childs)
            {
                CalTotal(data, child);
                total += child.Total;
            }
            category.Total += total;
        }
    }
}
