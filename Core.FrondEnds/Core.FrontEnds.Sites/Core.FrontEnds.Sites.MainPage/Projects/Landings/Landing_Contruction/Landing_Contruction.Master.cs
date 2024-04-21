using Core.FrontEnds.Libraries.Web;
using System.Web.UI.WebControls;

namespace Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Contruction
{
    public partial class Landing_Contruction : MasterPageBase
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