using Core.FrontEnds.Libraries.Web;

using System.Web.UI.WebControls;

namespace Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Controls
{
    public partial class Shop_Mobile : MasterPageBase
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