
using Core.FrontEnds.Libraries.Web;
using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Design
{
    public partial class Landing_Design_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}