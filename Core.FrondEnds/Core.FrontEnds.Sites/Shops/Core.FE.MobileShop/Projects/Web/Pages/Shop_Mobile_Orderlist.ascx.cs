using Core.Business.Entities.CRM;
using Core.Business.Entities.ERP;
using Core.Extensions;
using Core.FrontEnds.Libraries.Portal;
using System.Web;
using System.Linq;
using Core.Web.Extensions;

namespace Core.FE.MobileShop.Projects.Web.Pages
{
    [Module]
    public partial class Shop_Mobile_Orderlist : Module
    {
        protected Customer Cus { get; set; }
        protected override void OnInitData()
        {
            Cus = HttpContext.Current.Session["Data"].As<Customer>();

            var Orders = Order.Inst.GetAllToList().Where(c=>c.TeleSaleId == Cus.TeleSaleId).ToList();
            Orders.BindTo(rpOrders);
        }
    }
}