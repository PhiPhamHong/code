using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;

namespace Core.FE.Sites.Landings.Projects.Web.Pages
{
    [Module]
    public partial class Previews : Module
    {
        protected string Design { get; set; }
        protected override void OnInitData()
        {
            switch (FeContext.Url.Preview.Type)
            {
                case FrontEnds.Libraries.UrlEngines.Previews.LinkType.Landing:
                    {
                        var ladi = FeContext.Url.Preview.Landing;
                        Design = ladi.Design;
                        break;
                    }
                case FrontEnds.Libraries.UrlEngines.Previews.LinkType.Template:
                    {
                        var temp = FeContext.Url.Preview.Template;
                        Design = temp.Design;
                        break;
                    }
            }
        }
    }
}