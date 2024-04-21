<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Done.ascx.cs" Inherits="Core.FE.Sites.Shop.Clothers.Projects.Web.Pages.Checkouts.Done" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="<%= Url("Home") %>"><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                    <li class="breadcrumb-item"><a href="<%= Url("Cart") %>">Giỏ hàng</a></li>
                    <li class="breadcrumb-item active">Đặt hàng thành công</li>
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
                            <a href="<%= Url("Step_One") %>">
                                <div class="step">
                                    <div class="line"></div>
                                    <div class="circle">1</div>
                                </div>
                                <span>Shipping</span>
                            </a>
                        </li>
                        <li>
                            <a href="<%= Url("Step_Two") %>">
                                <div class="step">
                                    <div class="line"></div>
                                    <div class="circle">2</div>
                                </div>
                                <span>Order Overview</span>
                            </a>
                        </li>
                        <li>
                            <a href="<%= Url("Step_Three") %>">
                                <div class="step">
                                    <div class="line"></div>
                                    <div class="circle">3</div>
                                </div>
                                <span>Payment</span>
                            </a>
                        </li>
                        <li class="active">
                            <a href="<%= Url("Done") %>">
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
            <div class="col-lg-8 col-md-8 mx-auto">
                <div class="widget">
                    <div class="order-detail-form text-center">
                        <div class="col-lg-10 col-md-10 mx-auto order-done">
                            <i class="icofont icofont-check-circled"></i>
                            <h2 class="text-success">Congrats! Your Order has been Accepted..</h2>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum. Sed ex est, Sed ex est, consectetur eget consectetur, Lorem ipsum dolor sit amet...
                            </p>
                        </div>
                        <div class="cart_navigation text-center">
                            <a href="<%= Url("Products") %>" class="btn btn-theme-round">Return to store</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
