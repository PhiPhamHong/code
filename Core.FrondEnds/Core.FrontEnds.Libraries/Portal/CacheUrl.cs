using Core.Caching;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.Utility;
using Core.Utility.Xml;
using System.Collections.Generic;
using System.Linq;
namespace Core.FrontEnds.Libraries.Portal
{
    [CacheFactory(TypeFactory = typeof(PortalContextCacheFactory))]
    public abstract class CacheUrl<TPageConfig> : CacheEntry<Pair<string, PageTag>>, ICacheUrl where TPageConfig : PagesConfig, new()
    {
        [PropertyCacheOptional("Url")] public string Url { set; get; }
        [PropertyCacheOptional("Extension")] public string Extension { set; get; }

        protected override Pair<string, PageTag> LoadForCache()
        {
            return GetPageUrls(CacheReadConfig<TPageConfig>.Load()).Select(p => p.GetPageTag()).FirstOrDefault(p => p != null);
        }

        protected IEnumerable<PageUrl> GetPageUrls(TPageConfig pagesConfig)
        {
            yield return new PageUrl.FromEngine { Url = Url, Extension = Extension, PagesConfig = pagesConfig };
            yield return new PageUrl.FromNormalConfig { Url = Url, Extension = Extension, PagesConfig = pagesConfig };
        }
    }

    public interface ICacheUrl
    {
        string Url { set; get; }
        string Extension { set; get; }
        Pair<string, PageTag> Get();
    }
}
