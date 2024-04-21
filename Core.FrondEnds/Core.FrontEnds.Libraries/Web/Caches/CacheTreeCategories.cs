using Core.Business.Entities.Websites;
using Core.Caching;
using Core.FrontEnds.Libraries.Utilities;
using System.Collections.Generic;
using System.Linq;
namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheTreeCategories : CacheByWebCacheFactory<List<Category.Fe>, CacheCategories>
    {
        protected override List<Category.Fe> LoadForCache()
        {
            return new CategoryTree { }.GetInTreeView(0, false);
        }

        public static List<Category.Fe> GetByCategoryType(Category.Type type)
        {
            return GetData().Where(c => c.CatType == type && c.LanguageId == FeContext.Url.LanguageId).ToList();
        }
    }
}
