using Core.FrontEnds.Libraries.Web;

using System.Web.UI.WebControls;

namespace Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForRent
{
    public partial class Home_ForRent : MasterPageBase
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