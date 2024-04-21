using System;
using Core.FrontEnds.Libraries.Web;
using System.Web.UI;


namespace Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Jewelry
{
    public partial class Shop_Jewelry_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}