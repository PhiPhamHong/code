using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.Orthers.PriceConfigs;
using Core.Web.Extensions;
using System.Linq;

namespace Core.FE.Sites.Transports.Projects.Web.Pages
{
    [Module]
    public partial class Costs : Module
    {
        protected string Target { get; set; }
        protected override void BeforeInitData()
        {
            var page = CachePageUrls.GetData().FirstOrDefault(c => "/" + c.VirtualUrl == FeContext.Url.Current);
            Target = page != null ? page.Title : FeContext.Url.PageTitle;

            var directions = CacheDirections.GetData();
            var startdirections = directions.Where(c => c.IsStart).ToList();
            var enddirections = directions.Where(c => c.IsEnd).ToList();

            var productTypes = CacheProductTypes.GetData();

            startdirections.BindTo(rpStart);
            enddirections.BindTo(rpEnd);
            productTypes.BindTo(rpType);
        }
    }
}