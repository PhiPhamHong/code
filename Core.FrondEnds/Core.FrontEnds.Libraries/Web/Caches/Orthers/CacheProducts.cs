using Core.Caching;
using Core.FrontEnds.Libraries.Web.Caches.News;
using System.Collections.Generic;
using System.Linq;

namespace Core.FrontEnds.Libraries.Web.Caches.Orthers
{
    public class CacheProducts : CacheByWebCacheFactory<List<Core.Business.Entities.Websites.News.Fe>, CacheProducts>
    {
        protected override List<Core.Business.Entities.Websites.News.Fe> LoadForCache()
        {
            var data = CacheNews.GetData();
            data = data.Where(c => c.Type == Business.Entities.Websites.Category.Type.Product).ToList();
            return data;
        }
    }
}
