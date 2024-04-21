<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Viewcart.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Viewcart" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>
<%@ Import Namespace="Core.FE.MobileShop.Projects.Web.Tools" %>


<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="/trang-chu"><i class="icofont icofont-ui-home"></i>Home</a></li>
                    <li class="breadcrumb-item active">Gio</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="shopping_cart_page">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto">
                <div class="widget">
                    <div class="section-header">
                        <h3 class="heading-design-h5">Cart
                        </h3>
                    </div>
                    <div class="table-responsive">
                        <table class="table cart_summary">
                            <thead>
                                <tr>
                                    <th class="cart_product">Product</th>
                                    <th>Description</th>
                                    <th>Avail.</th>
                                    <th>Unit price</th>
                                    <th>Qty</th>
                                    <th>Total</th>
                                    <th class="action"><i class="fa fa-trash-o"></i></th>
                                </tr>
                            </thead>


                            <tbody>
                                <asp:Repeater runat="server" ID="rpCart">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="cart_product"><a href="">
                                                <img class="img-fluid" src="<%# Eval("Product.Avatar") %>" alt="Product"></a></td>
                                            <td class="cart_description">
                                                <p class="product-name"><a href="<%# Eval("Product.UrlFormat") %>"><%# Eval("Product.Name") %> </a></p>
                                                
                                            </td>
                                            <td class="availability in-stock"><span class="badge badge-success"> Còn hàng </span></td>
                                            <td class="price"><span><%# Eval("Product.PriceSale","{0:0,0}") %></span></td>
                                            <td class="qty">
                                                <div class="input-group">
                                                    <span class="input-group-btn">
                                                        <button type="button" class="btn btn-theme-round btn-number" disabled="disabled" data-type="minus" data-field="quant[1]">
                                                            <span class="fa fa-minus"></span>
                                                        </button>
                                                    </span>
                                                    <input name="quant[1]" class="form-control border-form-control form-control-sm input-number" value="1" type="text">
                                                    <span class="input-group-btn">
                                                        <button type="button" class="btn btn-theme-round btn-number" data-type="plus" data-field="quant[1]">
                                                            <span class="fa fa-plus"></span>
                                                        </button>
                                                    </span>
                                                </div>
                                            </td>
                                            <td class="price"><span><%# Eval("Product.PriceSale","{0:0,0}") %></span></td>
                                            <td class="action">
                                                <a data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove"><i class="fa fa-trash-o"></i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </tbody>


                            <tfoot>
                                <tr>
                                    <td colspan="1"></td>
                                    <td colspan="4">
                                        <form class="form-inline pull-right">
                                            <div class="form-group">
                                                <input class="form-control border-form-control form-control-sm" placeholder="Enter discount code" type="text">
                                            </div>
                                            &nbsp;
                                       <button type="submit" class="btn btn-success pull-left btn-sm">Gửi</button>
                                        </form>
                                    </td>
                                    <td colspan="2">Tổng tiền hàng : <%= ShCart.Current.TotalMoney.ToString("###,###") %> </td>
                                </tr>
                                <tr>
                                    <td colspan="2"></td>
                                    <td colspan="3">Tổng khấu trừ</td>
                                    <td colspan="2">0 </td>
                                </tr>
                                <tr>
                                    <td colspan="5"><strong>Tổng tiền</strong></td>
                                    <td colspan="2"><strong><%= ShCart.Current.TotalMoney.ToString("###,###") %>  </strong></td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <a href="<%= Url("Shop_Mobile_Cartcheckout") %>" class="btn btn-theme-round btn-lg pull-right">NEXT</a>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
