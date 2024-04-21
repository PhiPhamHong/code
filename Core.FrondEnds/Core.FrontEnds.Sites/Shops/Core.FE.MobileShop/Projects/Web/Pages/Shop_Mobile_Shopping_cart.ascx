<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Shopping_cart.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Shopping_cart" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<%@ Import Namespace="Core.FE.MobileShop.Projects.Web.Tools" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href=""><i class="icofont icofont-ui-home"></i>Home</a></li>

                    <li class="breadcrumb-item active">Giỏ hàng</li>
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
                    <!-- Nav tabs -->
                    <div class="text-center">
                        <ul class="nav nav-tabs round-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link " style="width: 250px; margin: 10px;" data-toggle="tab" href="#ordertab" role="tab"> Đơn hàng </a>
<%--                                <a class="nav-link" style="width: 250px; margin: 10px;" data-toggle="tab" href="#deliverytab" role="tab"> Thông tin </a>
                                <a class="nav-link" style="width: 250px; margin: 10px;" data-toggle="tab" href="#donetab" role="tab"> Thành công </a>--%>
                            </li>
                        </ul>
                    </div>
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div class="tab-pane active" id="ordertab" role="tabpanel">
                            <div class="order-detail-content">
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
                                                        <td class="availability in-stock"><span class="badge badge-success">Còn hàng </span></td>
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
                                <div class="cart_navigation">
                                    <a href="/trang-chu" class="btn btn-theme-round-outline pull-left"><i class="fa fa-arrow-left"></i>Mua thêm</a>
                                    <a data-toggle="tab" href="#deliverytab" role="tab" class="nav-link btn btn-theme-round pull-right"><i class="fa fa-check"></i>Tiếp theo</a>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="deliverytab" role="tabpanel">
                            <div class="order-detail-form" id="FromInfo">
                                <form class="col-lg-10 col-md-10 mx-auto" >
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <label class="control-label">Họ và tên <span class="required">*</span></label>
                                                <input id="name" class="form-control border-form-control" value="" placeholder="Họ và tên..." type="text">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label class="control-label">Số điện thoại <span class="required">*</span></label>
                                                <input id="sdt" class="form-control border-form-control" value="" placeholder="123 456 7890" type="number">
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <label class="control-label">Địa chỉ <span class="required">*</span></label>
                                                <input id="address" class="form-control border-form-control " value="" placeholder="" type="text">
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <label class="control-label">Email</label>
                                                <input id="mail" class="form-control border-form-control " value="" placeholder="abc@gmail.com"  type="email">
                                            </div>
                                        </div>
                                    </div>
                                    
                                </form>
                                <div class="cart_navigation">
                                    <a href="#deliverytab" class="btn btn-theme-round-outline pull-left">Quay lại</a>
                                    <a data-cmd="Dathang"  class="nav-link btn btn-theme-round pull-right"> Hoàn thành </a>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="donetab" role="tabpanel">
                            <div class="order-detail-form text-center">
                                <div class="col-lg-10 col-md-10 mx-auto order-done">
                                    <i class="icofont icofont-check-circled"></i>
                                    <h2 class="text-success">Đặt hàng thành công!</h2>
                                    <p>
                                        Chúc mừng, đơn hàng của bạn đã được gửi đi, chúng tôi sẽ lên đơn và liên hệ người bán để tiến hành giao hàng cho bạn trong thời gian sớm nhất. vui lòng giữ liên lạc trong thời gian chờ nhận hàng. Xin cảm ơn!
                                    </p>
                                </div>
                                <div class="cart_navigation text-center">
                                    <a href="/trang-chu" class="btn btn-theme-round-outline">Tiếp tục mua hàng</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
