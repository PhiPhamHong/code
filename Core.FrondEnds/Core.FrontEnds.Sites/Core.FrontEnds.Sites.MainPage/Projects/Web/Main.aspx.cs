using Core.FrontEnds.Libraries.Web;
using System.Web.UI;
namespace Core.FrontEnds.Sites.MainPage.Projects.Web
{
    public partial class Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}