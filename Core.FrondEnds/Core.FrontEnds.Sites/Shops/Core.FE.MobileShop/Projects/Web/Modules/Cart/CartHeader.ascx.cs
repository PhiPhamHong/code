using Core.FE.MobileShop.Projects.Web.Tools;
using Core.FrontEnds.Libraries.Portal;
using Core.Web.Extensions;

namespace Core.FE.MobileShop.Projects.Web.Modules.Cart
{
    public partial class CartHeader : Module
    {
        protected override void OnInitData()
        {
            ShCart.Current.Items.BindTo(rpCart);
        }
    }
}