using Core.Attributes;
using Core.Utility;
using Core.Web.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FrontEnds.Libraries.Web
{
    public partial class FeContext
    {
        public class CookieOfCart : ObjectCookie
        {
            [PropertyIndex(Index = 0)] public List<ProductItem> Items { set; get; }

            protected override void OnLoad()
            {
                if (Items == null) Items = new List<ProductItem>();
            }
            protected override ICompressor CreateCompressor()
            {
                return Singleton<Compressor>.Inst;
            }

            public class ProductItem
            {
                [PropertyIndex(Index = 0)] public int ProductId { set; get; }
                [PropertyIndex(Index = 1)] public int Quantity { set; get; }
                [PropertyIndex(Index = 2)] public int QuantityChidren { set; get; }
                //[PropertyIndex(Index = 3)] public decimal? TotalRefund { set; get; }
            }

            public static void OnEdit(Action<CookieOfCart> action)
            {
                action(Cart);
                Cart.WriteCookie();
            }
            public static T OnEdit<T>(Func<CookieOfCart, T> func)
            {
                var result = func(Cart);
                Cart.WriteCookie();
                return result;
            }

            public static void Upsert(int productId, int quantity, bool isUpdate = false)
            {
                OnEdit(cart =>
                {
                    var item = cart.Items.FirstOrDefault(p => p.ProductId == productId);
                    if (item == null)
                    {
                        item = new ProductItem { ProductId = productId };
                        cart.Items.Add(item);
                    }
                    if (isUpdate) item.Quantity = quantity;
                    else item.Quantity = quantity;
                });
            }
            public static void Remove(int productId)
            {
                OnEdit(cart => cart.Items = cart.Items.Where(p => p.ProductId != productId).ToList());
            }
            public static void RemoveAll()
            {
                OnEdit(cart => cart.Items.Clear());
            }
        }

        public static CookieOfCart Cart
        {
            get { return Get(() => new CookieOfCart(), Const.COOKIE_OF_CART); }
        }
    }
}
