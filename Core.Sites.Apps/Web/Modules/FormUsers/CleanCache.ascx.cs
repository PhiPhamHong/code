using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Caching.CacheProvider;
namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    [Module]
    public partial class CleanCache : PortalModule
    {
        protected override void OnInitData()
        {
            WebCacheProvider.ClearAll();
        }
    }
}