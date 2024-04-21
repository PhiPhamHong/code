
using Core.FrontEnds.Libraries.Web;
using System.Web.UI;


namespace Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Vegetable
{
    public partial class Shop_Vegetable_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}