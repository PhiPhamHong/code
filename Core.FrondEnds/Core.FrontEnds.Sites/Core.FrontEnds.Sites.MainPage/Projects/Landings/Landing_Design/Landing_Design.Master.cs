using Core.FrontEnds.Libraries.Web;

using System.Web.UI.WebControls;

namespace Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Design
{
    public partial class Landing_Design : MasterPageBase
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