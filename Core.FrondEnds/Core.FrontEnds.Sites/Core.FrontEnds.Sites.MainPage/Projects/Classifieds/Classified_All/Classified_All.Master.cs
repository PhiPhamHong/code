using Core.FrontEnds.Libraries.Web;
using System.Web.UI.WebControls;

namespace Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All
{
    public partial class Classified_All : MasterPageBase
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