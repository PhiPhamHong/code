using Core.Business.Entities.ERP;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web.Caches.Products;
using System.Web;
using System.Linq;

namespace Core.FE.MobileShop.Controls
{
    public partial class Header : Module
    {
        protected bool IsLogin { get; set; }
        protected Product Data { get; set; }
        protected override void BeforeInitData()
        {
            
            if (HttpContext.Current.Session["Data"] != null)
            {
                IsLogin = true;
            }
            else
                IsLogin = false;
        }
        protected override void OnInitData()
        {
            Data = CacheProducts.GetData().FirstOrDefault(c=>c.IsActive && c.IsHomePage);
            base.OnInitData();
        }
    }
}