using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.Web.Extensions;
using System.Linq;


namespace Core.FE.Sites.Transports.Projects.Web.Controls
{
    public partial class SiteHead : Module
    {
        protected Seo Com = CacheSeo.GetData().FirstOrDefault();
        protected override void BeforeInitData()
        {
        }
    }
}