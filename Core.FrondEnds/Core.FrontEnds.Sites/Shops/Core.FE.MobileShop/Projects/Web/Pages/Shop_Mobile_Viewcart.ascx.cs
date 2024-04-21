using Core.FE.MobileShop.Projects.Web.Tools;
using Core.FrontEnds.Libraries.Portal;
using Core.Web.Extensions;

namespace Core.FE.MobileShop.Projects.Web.Pages
{
    [Module]
    public partial class Shop_Mobile_Viewcart : Module
    {
        protected override void OnInitData()
        {
            ShCart.Current.Items.BindTo(rpCart);
        }
    }
}