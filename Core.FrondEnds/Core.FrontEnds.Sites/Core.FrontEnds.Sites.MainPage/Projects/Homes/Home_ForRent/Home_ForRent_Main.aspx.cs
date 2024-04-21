using Core.FrontEnds.Libraries.Web;

using System.Web.UI;


namespace Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForRent
{
    public partial class Home_ForRent_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}