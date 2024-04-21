
using Core.FrontEnds.Libraries.Web;
using System.Web.UI;


namespace Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Company
{
    public partial class Landing_Company_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}