using Core.Caching.CacheProvider;
using Core.Utility;
namespace Core.Caching
{
    public class PortalContextCacheFactory : ICacheFactory
    {
        public ICacheProvider Provider
        {
            get { return Singleton<PortalContextCacheProvider>.Inst; }
        }
    }
}
