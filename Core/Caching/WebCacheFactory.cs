using Core.Caching.CacheProvider;
using Core.Utility;
namespace Core.Caching
{
    /// <summary>
    /// WebCacheFactory
    /// </summary>
    public class WebCacheFactory : ICacheFactory
    {
        public ICacheProvider Provider
        {
            get { return Singleton<WebCacheProvider>.Inst; }
        }
    }
}
