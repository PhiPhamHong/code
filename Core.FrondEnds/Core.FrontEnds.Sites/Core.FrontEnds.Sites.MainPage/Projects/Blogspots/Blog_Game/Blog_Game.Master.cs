using Core.FrontEnds.Libraries.Web;

using System.Web.UI.WebControls;

namespace Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Blog_Game
{
    public partial class Blog_Game : MasterPageBase
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