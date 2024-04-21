using System;
using Core.FrontEnds.Libraries.Web;
using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Software
{
    public partial class Landing_Software_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}