using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web.Caches.Products;
using Core.Web.Extensions;
using System.Linq;

namespace Core.FE.MobileShop.Projects.Web.Pages
{
    [Module]
    public partial class Shop_Mobile_Home : Module
    {
        protected int Total { get; set; }
        protected override void BeforeInitData()
        {
            var Datas = CacheProducts.GetData();
            Total = Datas.Count();
            Datas.Where(da => da.IsActive == true && da.IsHomePage == true).ToList().BindTo(rpProducts);
            Datas.Where(da => da.IsActive == true && da.IsHomePage == true && da.IsBestSeller).ToList().BindTo(rpBestseller);
            Datas.Where(da => da.IsActive == true && da.IsHomePage == true && da.IsHot).ToList().BindTo(rpHots);
            Datas.Where(da => da.IsActive == true && da.IsHomePage == true && da.IsOnSale).ToList().BindTo(rpOnsale);
        }
    }
}