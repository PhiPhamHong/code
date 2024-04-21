using Core.Business.Entities.ERP;
using Core.Business.Entities.Websites;
using Core.Extensions;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches.Products;
using System.Collections.Generic;
using System.Linq;


namespace Core.FrontEnds.Libraries.Utilities
{
    public abstract class Cart
    {
        public void AddItem(int productId, int quantity, bool update)
        {
            FeContext.CookieOfCart.Upsert(productId, quantity, update);
            OnAddItem();
            OnChange();
        }
        public void UpdateItems(string items)
        {
            items.Split(';').ForEach(item =>
            {
                var item_ = item.Split(':');
                FeContext.CookieOfCart.Upsert(item_[0].To<int>(), item_[1].To<int>());
            });
            OnUpdateItems(items);
            OnChange();
        }
        public void RemoveItem(int productId)
        {
            FeContext.CookieOfCart.Remove(productId);
            OnRemoveItem();
            OnChange();
        }
        public void RemoveItemAll()
        {
            FeContext.CookieOfCart.RemoveAll();
            OnRemoveItemAll();
            OnChange();
        }

        protected virtual void OnAddItem() { }
        protected virtual void OnUpdateItems(string items) { }
        protected virtual void OnRemoveItem() { }
        protected virtual void OnRemoveItemAll() { }
        protected virtual void OnChange() { }

        public class Item
        {
            public FeContext.CookieOfCart.ProductItem CartItem { set; get; }
            public Product Product { set; get; }
            public decimal TotalMoney { set; get; }
        }
        public class CartResult
        {
            public List<Item> Items { set; get; }
            public decimal TotalMoney { set; get; }
        }

        public static CartResult Current
        {
            get
            {
                var items = FeContext.Cart.Items;

                var cart = new CartResult { };
                var products = CacheProducts.GetData();
                cart.Items = items.Join(products, item => item.ProductId, product => product.ProductId, (item, product) =>
                {
                    return new Item { CartItem = item, Product = product, TotalMoney = item.Quantity * (product.As<Product>().PriceSale ?? 0) };
                }).ToList();
                cart.TotalMoney = cart.Items.Sum(item => item.TotalMoney);
                return cart;
            }
        }
    }
}