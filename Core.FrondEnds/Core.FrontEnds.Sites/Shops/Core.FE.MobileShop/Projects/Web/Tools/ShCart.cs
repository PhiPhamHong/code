using Core.Business.Entities.CRM;
using Core.Business.Entities.ERP;
using Core.Extensions;
using Core.FE.MobileShop.Projects.Web.Modules.Cart;
using Core.FrontEnds.Libraries.Utilities;
using Core.FrontEnds.Libraries.Web;
using Core.Web.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.FE.MobileShop.Projects.Web.Tools
{
    public class ShCart: Cart, IAjax
    {
        protected override void OnAddItem()
        {
            var module = Control<CartHeader>.Create();
            module.InitData();
            this.SetData("Cart", module.Html);
        }
        protected override void OnRemoveItem()
        {
            var module = Control<CartHeader>.Create();
            module.InitData();
            this.SetData("Cart", module.Html);
        }

        public void CheckOut(string name, string sdt, string address, string mail)
        {

            Customer data = HttpContext.Current.Session["Data"] != null ? HttpContext.Current.Session["Data"].As<Customer>() : null;

            Order order = new Order();
            order.CompanyId = 1;
            order.ConfirmDate = DateTime.Now;
            order.Type = OrderType.SingleOut;
            order.ObjName = name;
            order.ObjPhone = sdt;
            order.ObjAddress = address;
            order.ObjEmail = mail;
            order.Source = OrderSource.Web;
            if(data != null)
            {
                order.UseFor = OrderUseFor.Customer;
                order.TeleSaleId = data.TeleSaleId;
            }   
            var capital = 0;
            ShCart.Current.Items.ForEach(c =>
            {
                capital = capital + c.Product.Cost.To<int>();
            });
            order.Capital = capital;
            order.Amount = ShCart.Current.TotalMoney;
            order.Com = 0;
            order.Profit = order.Amount - order.Capital;
            order.CurrencyId = 1;
            order.ExchangeRate = 1;
            order.Status = OrderStatus.Unpaid;
            order.Code = "ORDER-" + DateTime.Now.ToString("ddMMyyyy") + "WEB";
            order.UseFor = OrderUseFor.Visitor;
            order.UserId = 4;
            order.CreatedDate = DateTime.Now;
            order.IsLock = false;
            order.Upsert();
            ShCart.Current.Items.ForEach(c =>
            {
                Order.Detail detail = new Order.Detail();
                detail.OrderId = order.OrderId;
                detail.ProductId = c.Product.ProductId;
                detail.Quantity = 1;
                detail.StockId = 1;
                detail.SubPrice = 0;
                detail.TotalSubPrice = 0;
                detail.SubCost = 0;
                detail.TotalSubCost = 0;
                detail.Cost = c.Product.Cost;
                detail.Price = c.Product.PriceSale;
                detail.Capital = c.Product.Cost;
                detail.Amount = c.Product.PriceSale;
                detail.Com = 0;
                detail.PartnerId = 1;
                detail.Profit = detail.Amount - detail.Capital;
                detail.Upsert();
            });

            FeContext.CookieOfCart.RemoveAll();

            var module = Control<CartHeader>.Create();
            module.InitData();
            this.SetData("Cart", module.Html);

        }
    }
}