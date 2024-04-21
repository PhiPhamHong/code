using Core.Business.Entities.ERP;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches.Products;
using Core.Web.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Core.FE.MobileShop.Projects.Web.Pages
{
    [Module]
    public partial class Shop_Mobile_Shop_details : Module
    {
        protected Product Entity { get; set; }
        protected override void BeforeInitData()
        {
            Entity = FeContext.Url.Product.Entity;
            List<IMG> L1 = new List<IMG>();
            List<IMG> L2 = new List<IMG>();
            Entity.Images.Split(',').ToList().ForEach(c => {
                L1.Add(new IMG { Thumb = "https://sserp.vn" + c });
                L2.Add(new IMG { Thumb = "https://sserp.vn" + c });
            });
            L1.BindTo(rpL1);
            L2.BindTo(rpL2);

            var Datas = CacheProducts.GetData();
            Datas.Where(da => da.IsActive == true && da.IsSuggest == true).Take(16).ToList().BindTo(rpHots);
        }

        public class IMG
        {
            public string Thumb { get; set; }
        }
    }
}