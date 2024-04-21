<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs" Inherits="Core.FE.Sites.Shop.Clothers.Projects.Web.Pages.Categories" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="<%= Url("Home") %>"><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                    <li class="breadcrumb-item active">Danh mục sản phẩm</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="category-page">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-6">
                <div class="widget">
                    <div class="widget-header">
                        <small>98,156 Items</small>
                        <h1><i class="icofont icofont-man-in-glasses"></i>Men's Fashion</h1>
                    </div>
                    <div class="widget-body">
                        <ul class="trends">
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-boot"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-bag"></i>Bags &amp; Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jersey"></i>Clothing <span class="badge badge-danger">HOT</span><span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-diving-goggle"></i>Eyewear <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-boot"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-bag"></i>Bags &amp; Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jersey"></i>Clothing <span class="badge badge-danger">HOT</span><span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-diving-goggle"></i>Eyewear <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-6">
                <div class="widget">
                    <div class="widget-header">
                        <small>98,156 Items</small>
                        <h1><i class="icofont icofont-woman-in-glasses"></i>Women's Fashion</h1>
                    </div>
                    <div class="widget-body">
                        <ul class="trends">
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-sandals-female"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jewlery"></i>Fashion Jewellery <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-bag"></i>Bags &amp; Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jersey"></i>Clothing <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-sandals-female"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jewlery"></i>Fashion Jewellery <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-bag"></i>Bags &amp; Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jersey"></i>Clothing <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
                <div class="widget">
                    <div class="widget-header">
                        <small>65,156 Items</small>
                        <h1><i class="icofont icofont icofont-baby"></i>Kids Fashion</h1>
                    </div>
                    <div class="widget-body">
                        <ul class="trends">
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-diving-goggle"></i>Eyewear <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-boot"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-bag"></i>Bags &amp; Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jersey"></i>Clothing <span class="badge badge-danger">HOT</span><span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-diving-goggle"></i>Eyewear <span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-boot"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-bag"></i>Bags &amp; Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-jersey"></i>Clothing <span class="badge badge-danger">HOT</span><span class="item-numbers">65</span></a></li>
                            <li><a href="<%= Url("Products") %>"><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href="<%= Url("Products") %>"><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
