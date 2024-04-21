using System;

using Core.FrontEnds.Libraries.Web;
using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Blog_Game
{
    public partial class Blog_Game_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}