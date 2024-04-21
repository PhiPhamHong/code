<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Clother_Step_Two.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother.Pages.Checkouts.Shop_Clother_Step_Two" %>
<%@ Register Src="~/Projects/Shops/Shop_Clother/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="<%= Url("Shop_Clother") %>"><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                    <li class="breadcrumb-item"><a href="<%= Url("Shop_Clother_Cart") %>">Giỏ hàng</a></li>
                    <li class="breadcrumb-item active">Đặt hàng</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="shopping_cart_page">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <div class="checkout-step mb-40">
                    <ul>
                        <li>
                            <a href="cart_delivery.html">
                                <div class="step">
                                    <div class="line"></div>
                                    <div class="circle">1</div>
                                </div>
                                <span>Shipping</span>
                            </a>
                        </li>
                        <li class="active">
                            <a href="cart_order.html">
                                <div class="step">
                                    <div class="line"></div>
                                    <div class="circle">2</div>
                                </div>
                                <span>Order Overview</span>
                            </a>
                        </li>
                        <li>
                            <a href="cart_checkout.html">
                                <div class="step">
                                    <div class="line"></div>
                                    <div class="circle">3</div>
                                </div>
                                <span>Payment</span>
                            </a>
                        </li>
                        <li>
                            <a href="cart_done.html">
                                <div class="step">
                                    <div class="line"></div>
                                    <div class="circle">4</div>
                                </div>
                                <span>Order Complete</span>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-8 col-md-8">
                <div class="widget">
                    <div class="section-header">
                        <h3 class="heading-design-h5">Order Overview
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
                                <tr>
                                    <td class="cart_product"><a href="">
                                        <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/3.jpg" alt="Product"></a></td>
                                    <td class="cart_description">
                                        <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                        <small><a href="">Color : Red</a></small>
                                        <small><a href="">Size : M</a></small>
                                    </td>
                                    <td class="availability in-stock"><span class="badge badge-success">In stock</span></td>
                                    <td class="price"><span>$49.88</span></td>
                                    <td class="qty">
                                        <div class="input-group">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-theme-round btn-number" disabled="disabled" data-type="minus" data-field="quant[1]">
                                                    <span class="fa fa-minus"></span>
                                                </button>
                                            </span>
                                            <input name="quant[1]" class="form-control border-form-control form-control-sm input-number" value="1" min="1" max="10" type="text">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-theme-round btn-number" data-type="plus" data-field="quant[1]">
                                                    <span class="fa fa-plus"></span>
                                                </button>
                                            </span>
                                        </div>
                                    </td>
                                    <td class="price"><span>$49.88</span></td>
                                    <td class="action">
                                        <a data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove"><i class="fa fa-trash-o"></i></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cart_product"><a href="">
                                        <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/2.jpg" alt="Product"></a></td>
                                    <td class="cart_description">
                                        <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                        <small><a href="">Color : Green</a></small><br>
                                        <small><a href="">Size : XL</a></small>
                                    </td>
                                    <td class="availability out-of-stock"><span class="badge badge-primary">No stock</span></td>
                                    <td class="price"><span>$00.00</span></td>
                                    <td class="qty">
                                        <div class="input-group">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-theme-round btn-number" disabled="disabled" data-type="minus" data-field="quant[1]">
                                                    <span class="fa fa-minus"></span>
                                                </button>
                                            </span>
                                            <input name="quant[1]" class="form-control border-form-control form-control-sm input-number" value="1" min="1" max="10" type="text">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-theme-round btn-number" data-type="plus" data-field="quant[1]">
                                                    <span class="fa fa-plus"></span>
                                                </button>
                                            </span>
                                        </div>
                                    </td>
                                    <td class="price"><span>00.00</span></td>
                                    <td class="action">
                                        <a data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove"><i class="fa fa-trash-o"></i></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cart_product"><a href="">
                                        <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/1.jpg" alt="Product"></a></td>
                                    <td class="cart_description">
                                        <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                        <small><a href="">Color : Blue</a></small><br>
                                        <small><a href="">Size : S</a></small>
                                    </td>
                                    <td class="availability in-stock"><span class="badge badge-warning">In stock</span></td>
                                    <td class="price"><span>$99.00</span></td>
                                    <td class="qty">
                                        <div class="input-group">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-theme-round btn-number" disabled="disabled" data-type="minus" data-field="quant[1]">
                                                    <span class="fa fa-minus"></span>
                                                </button>
                                            </span>
                                            <input name="quant[1]" class="form-control border-form-control form-control-sm input-number" value="1" min="1" max="10" type="text">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-theme-round btn-number" data-type="plus" data-field="quant[1]">
                                                    <span class="fa fa-plus"></span>
                                                </button>
                                            </span>
                                        </div>
                                    </td>
                                    <td class="price"><span>$188.00</span></td>
                                    <td class="action">
                                        <a data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove"><i class="fa fa-trash-o"></i></a>
                                    </td>
                                </tr>
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
                                       <button type="submit" class="btn btn-sm btn-success pull-left">Apply</button>
                                        </form>
                                    </td>
                                    <td colspan="2">Discount : $237.88 </td>
                                </tr>
                                <tr>
                                    <td colspan="2"></td>
                                    <td colspan="3">Total products (tax incl.)</td>
                                    <td colspan="2">$437.88 </td>
                                </tr>
                                <tr>
                                    <td colspan="5"><strong>Total</strong></td>
                                    <td colspan="2"><strong>$337.88 </strong></td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <a href="<%= Url("Shop_Clother_Step_Three") %>" class="btn btn-theme-round btn-lg pull-right">NEXT</a>
                </div>
            </div>
            <div class="col-lg-4 col-md-4">
                <div class="widget mb18">
                    <div class="card">
                        <div class="card-header">
                            Billing Address 
                        </div>
                        <div class="card-body">
                            <div class="card-text"><strong>TITLE</strong></div>
                            <div class="card-text"><strong>Gurdeep Singh Osahan</strong></div>
                            <div class="card-text">
                                4894 Burke Street<br>
                                North Billerica, MA 01862 
                            </div>
                        </div>
                    </div>
                </div>
                <div class="widget">
                    <div class="card">
                        <div class="card-header">
                            Shipping Address  
                        </div>
                        <div class="card-body">
                            <div class="card-text"><strong>TITLE</strong></div>
                            <div class="card-text"><strong>Gurdeep Singh Osahan</strong></div>
                            <div class="card-text">
                                4894 Burke Street<br>
                                North Billerica, MA 01862 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
