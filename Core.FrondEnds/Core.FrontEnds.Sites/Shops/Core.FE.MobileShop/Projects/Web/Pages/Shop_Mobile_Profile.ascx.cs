using Core.Business.Entities.CRM;
using Core.Extensions;
using Core.FrontEnds.Libraries.Portal;
using System.Web;

namespace Core.FE.MobileShop.Projects.Web.Pages
{
    [Module]
    public partial class Shop_Mobile_Profile : Module
    {
        protected Customer Cus { get; set; }
        protected override void OnInitData()
        {
            Cus = HttpContext.Current.Session["Data"].As<Customer>();
        }
    }
}