using Core.FrontEnds.Libraries.Web;
using System.Web.UI;
namespace Core.FE.Shop.Jewelries.Projects.Web
{
    public partial class Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}