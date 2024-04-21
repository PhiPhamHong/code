using Core.FrontEnds.Libraries.Web;
using System.Web.UI.WebControls;

namespace Core.FE.MobileShop.Projects.Web
{
    public partial class Site : MasterPageBase
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