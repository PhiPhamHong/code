using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches.Previews;
using System.Linq;

namespace Core.FE.Sites.Landings.Projects.Web.Pages
{
    [ModuleAttribute]
    public partial class Landings : Module
    {
        protected string Design { get; set; }
        protected string FormDesign { get; set; }
        protected override void BeforeInitData()
        {
            var ladi = FeContext.Url.Landing.Landing;
            Design = ladi.Design;
            var form = CacheUptinForms.GetData().FirstOrDefault(c => c.UptinFormId == ladi.UptinFormId);
            FormDesign = form.Design;
        }
    }
}