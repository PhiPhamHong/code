using Core.FrontEnds.Libraries.Web;
using System.Web.UI.WebControls;

namespace Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads
{
    public partial class Classified_Ads : MasterPageBase
    {
        protected override Literal LiteralBottom
        {
            get { return ltrBottom; }
        }

        protected override Literal LiteralHead
        {
            get { return ltrHead; }
        }
    }
}