using Core.Business.Entities.Websites;
using Core.Caching;
using Core.Utility;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web
{
    public abstract class PageSetting<TConfig> : Singleton<TConfig>, IPageSetting where TConfig : class, new()
    {
        public virtual string SiteName { set; get; }

        public PageSetting()
        {
            this.Parse(Config.GetConfigs(), false);
            Start();
        }

        public class Cache : CacheByWebCacheFactory<TConfig, Cache>
        {
            protected override TConfig LoadForCache()
            {
                return New;
            }
        }

        protected virtual void Start() { }
    }

    public interface IPageSetting
    {
        string SiteName { get; }
    }
}
