
using Core.FrontEnds.Libraries.Web;
using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile
{
    public partial class Shop_Mobile_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}