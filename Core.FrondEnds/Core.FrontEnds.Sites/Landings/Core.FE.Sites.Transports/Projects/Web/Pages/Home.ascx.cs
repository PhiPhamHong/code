using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.Web.Extensions;
using System.Linq;

namespace Core.FE.Sites.Transports.Projects.Web.Pages
{
    [Module]
    public partial class Home : Module
    {
        protected override void BeforeInitData()
        {
            var banners = CacheBanners.GetData().Where(c => c.Address == "HOME").ToList();
            banners.BindTo(rpbanner);
        }
    }
}