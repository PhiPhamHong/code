using Core.FrontEnds.Libraries.Web;
using System.Web.UI;
namespace Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother
{
    public partial class Shop_Clother_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}