
using Core.Business.Entities;
using Core.Caching;
using Core.Sites.Libraries.Api.Devices.Drivers;
using Core.Sites.Libraries.Api.Servers;
using Core.Sites.Libraries.Business;

namespace Core.Sites.Libraries.Cache
{
    public class CacheGlobalConfig : CacheByWebCacheFactory<CacheGlobalConfig.Data, CacheGlobalConfig>
    {
        protected override Data LoadForCache()
        {
            var config = GlobalConfig.GetByCompanyId(PortalContext.Config.CompanyId) ?? GlobalConfig.Empty;
            var data = new Data { Config = config };
            data.Timekeeper = new Driver.Timekeeper { BaseUrl = data.Config.TimkeeperBaseUrl };
            data.Handler = new Server.Handler { BaseUrl = data.Config.ServerApiBaseUrl };
            return data;
        }

        public class Data
        {
            public GlobalConfig Config { set; get; }
            public Driver.Timekeeper Timekeeper { set; get; }
            public Server.Handler Handler { set; get; }
        }
    }
}