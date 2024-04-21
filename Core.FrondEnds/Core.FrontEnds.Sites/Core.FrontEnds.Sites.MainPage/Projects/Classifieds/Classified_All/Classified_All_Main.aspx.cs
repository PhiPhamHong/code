using Core.FrontEnds.Libraries.Web;
using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All
{
    public partial class Classified_All_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}