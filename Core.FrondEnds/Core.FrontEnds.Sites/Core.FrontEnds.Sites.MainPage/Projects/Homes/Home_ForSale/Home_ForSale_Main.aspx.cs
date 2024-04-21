using Core.FrontEnds.Libraries.Web;

using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForSale
{
    public partial class Home_ForSale_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}