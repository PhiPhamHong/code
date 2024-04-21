<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Category.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Pages.Shop_Mobile_Category" %>
<%@ Register Src="~/Projects/Shops/Shop_Mobile/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



<div class="osahan-breadcrumb">
         <div class="container">
            <div class="row">
               <div class="col-lg-12 col-md-12">
                  <ol class="breadcrumb">
                     <li class="breadcrumb-item"><a href=""><i class="icofont icofont-ui-home"></i> Home</a></li>
                     <li class="breadcrumb-item"><a href="">Pages</a></li>
                     <li class="breadcrumb-item active">Page Name</li>
                  </ol>
               </div>
            </div>
         </div>
      </div>
      <section class="category-page">
         <div class="container">
            <div class="row">
               <div class="col-lg-4 col-md-4 col-sm-4">
                  <div class="widget">
                     <div class="categories-page-image">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/homepage3/men.png" alt="">
                     </div>
                     <div class="widget-header">
                        <small>98,156 Items</small>
                        <h1><i class="icofont icofont-brand-android-robot"></i> SMART PHONES</h1>
                     </div>
                     <div class="widget-body">
                        <ul class="trends">
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-android-nexus"></i> Mobiles <span class="item-numbers">155</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-android-tablet"></i> Tabs <span class="item-numbers">80</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-laptop"></i> Laptops <span class="badge badge-danger">HOT</span><span class="item-numbers">65</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-gift"></i> Accessories <span class="item-numbers">155</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-apple-watch"></i> Watches <span class="item-numbers">80</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                     </div>
                  </div>
               </div>
               <div class="col-lg-4 col-md-4 col-sm-4">
                  <div class="widget">
                     <div class="categories-page-image">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/homepage3/kids.png" alt="">
                     </div>
                     <div class="widget-header">
                        <small>65,156 Items</small>
                        <h1><i class="icofont icofont-brand-windows"></i> WINDOWS MOBILES </h1>
                     </div>
                     <div class="widget-body">
                        <ul class="trends">
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-android-nexus"></i> Mobiles <span class="badge badge-success">HOT</span> <span class="item-numbers">155</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-android-tablet"></i> Tabs <span class="item-numbers">80</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-laptop"></i> Laptops <span class="item-numbers">65</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-gift"></i> Accessories <span class="item-numbers">155</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-apple-watch"></i> Watches <span class="item-numbers">80</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                     </div>
                  </div>
               </div>
               <div class="col-lg-4 col-md-4 col-sm-4">
                  <div class="widget">
                     <div class="categories-page-image">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/homepage3/women.png" alt="">
                     </div>
                     <div class="widget-header">
                        <small>98,156 Items</small>
                        <h1><i class="icofont icofont-brand-apple"></i> ANDROID MOBILES</h1>
                     </div>
                     <div class="widget-body">
                        <ul class="trends">
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-android-nexus"></i> Mobiles <span class="item-numbers">155</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-android-tablet"></i> Tabs <span class="item-numbers">80</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-laptop"></i> Laptops <span class="badge badge-danger">HOT</span><span class="item-numbers">65</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-gift"></i> Accessories <span class="item-numbers">155</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><i class="icofont icofont-apple-watch"></i> Watches <span class="item-numbers">80</span></a></li>
                           <li><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </section>
<uc1:Top_Brands runat="server" id="Top_Brands" />
