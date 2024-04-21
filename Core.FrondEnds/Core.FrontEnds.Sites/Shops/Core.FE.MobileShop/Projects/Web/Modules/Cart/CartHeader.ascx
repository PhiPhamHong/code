<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartHeader.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Modules.Cart.CartHeader" %>
<%@ Import Namespace="Core.FE.MobileShop.Projects.Web.Tools" %>



<a class="btn btn-outline-light dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    <i class="icofont icofont-shopping-cart"></i>Giỏ hàng <small class="cart-value"><%= ShCart.Current.Items.Count %></small>
</a>
<div class="dropdown-menu dropdown-menu-right cart-dropdown">
    <asp:Repeater runat="server" ID="rpCart">
        <ItemTemplate>
            <div class="dropdown-item">
                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                    <i class="fa fa-trash-o"></i>
                </a>
                <a href="<%= Url("Shop_Mobile_Shopping_cart") %>">
                    <img class="img-fluid" src="<%# Eval("Product.Avatar") %>" alt="Product">
                    <strong><%# Eval("Product.Name") %> </strong>
                    <span class="product-desc-price"><%# Eval("Product.PriceOld","{0:0,0}") %></span>
                    <span class="product-price text-danger"><%# Eval("Product.PriceSale","{0:0,0}") %></span>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="dropdown-divider"></div>
    <div class="dropdown-cart-footer text-center">
        <h4><strong>Tổng tiền</strong>: <%= ShCart.Current.TotalMoney != 0 ? ShCart.Current.TotalMoney.ToString("###,###") : "0" %> </h4>
        <a class="btn btn-sm btn-danger" href="<%= Url("Shop_Mobile_Shopping_cart") %>"><i class="icofont icofont-shopping-cart"></i>Đi tới giỏ hàng </a>
    </div>
</div>
