using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches.Products;
using Core.Web.Extensions;
using System.Linq;

namespace Core.FE.MobileShop.Projects.Web.Pages
{
    [Module]
    public partial class Shop_Mobile_Grid_left_sidebar : Module
    {
        protected override void OnInitData()
        {
            var Datas = CacheProducts.GetData();
            if (FeContext.Url.Search.Type == 0)
            {
                if (FeContext.Url.Category.CatId != 0)
                    Datas.Where(da => da.IsActive == true && da.CatId == FeContext.Url.Category.CatId).ToList().BindTo(rpHots);
                else
                    Datas.Where(da => da.IsActive == true).ToList().BindTo(rpHots);
            }
            else
            {
                if (FeContext.Url.Search.Type == 1)
                {
                    Datas.Where(da => da.Name.Contains(FeContext.Url.Search.Content)).ToList().BindTo(rpHots);
                }
                else
                    Datas.Where(da => FeContext.Url.Search.Facturers.FirstOrDefault(c => c.FacturerId == da.FacturerId) != null).ToList().BindTo(rpHots);
            }
        }
    }
}