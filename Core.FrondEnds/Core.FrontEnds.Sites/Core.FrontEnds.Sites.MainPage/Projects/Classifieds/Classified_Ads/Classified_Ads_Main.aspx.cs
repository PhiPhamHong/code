using Core.FrontEnds.Libraries.Web;
using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads
{
    public partial class Classified_Ads_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}