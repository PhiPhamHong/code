﻿using Core.FrontEnds.Libraries.Web;

using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_Land
{
    public partial class Home_Land_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}