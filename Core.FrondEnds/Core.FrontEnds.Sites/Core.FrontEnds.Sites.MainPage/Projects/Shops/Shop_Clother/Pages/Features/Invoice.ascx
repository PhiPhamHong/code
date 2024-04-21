﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Invoice.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother.Pages.Features.Invoice" %>



<!DOCTYPE html>
<html lang="en">
   <head><!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-120909275-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-120909275-1');
</script>

      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
      <meta name="description" content="Osahan Fashion - Bootstrap 4 E-Commerce Theme">
      <meta name="keywords" content="Osahan, fashion, Bootstrap4, shop, e-commerce, modern, flat style, responsive, online store, business, mobile, blog, bootstrap 4, html5, css3, jquery, js, gallery, slider, touch, creative, clean">
      <meta name="author" content="Askbootstrap">
      <title>Osahan Fashion - Bootstrap 4 E-Commerce Theme</title>
      <!-- Favicon Icon -->
      <link rel="apple-touch-icon" sizes="76x76" href="/Projects/Web/Resources/images/apple-icon.png">
      <link rel="icon" type="image/png" href="/Projects/Web/Resources/images/favicon.png">
      <!-- Bootstrap core CSS -->
      <link href="css/bootstrap.min.css" rel="stylesheet">
      <!-- Custom styles for this template -->
      <link href="css/style.css" rel="stylesheet">
      <link href="css/animate.css" rel="stylesheet">
      <link href="css/animate.css" rel="stylesheet">
      <link href="css/mobile.css" rel="stylesheet">
      <!-- Font Icons -->
      <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
      <link href="css/icofont.css" rel="stylesheet" type="text/css">
      <!-- Owl Carousel -->
      <link rel="stylesheet" href="plugins/owl-carousel/owl.carousel.css">
      <link rel="stylesheet" href="plugins/owl-carousel/owl.theme.css">
   </head>
   <body>
      <div class="modal fade login-modal-main" id="bd-example-modal">
         <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
               <div class="modal-body">
                  <div class="login-modal">
                     <div class="row">
                        <div class="col-lg-6 pad-right-0">
                           <div class="login-modal-left">
                           </div>
                        </div>
                        <div class="col-lg-6 pad-left-0">
                           <button type="button" class="close close-top-right" data-dismiss="modal" aria-label="Close">
                           <span aria-hidden="true">&times;</span>
                           <span class="sr-only">Close</span>
                           </button>
                           <form>
                              <div class="login-modal-right">
                                 <!-- Tab panes -->
                                 <div class="tab-content">
                                    <div class="tab-pane active" id="login" role="tabpanel">
                                       <h5 class="heading-design-h5">Login to your account</h5>
                                       <fieldset class="form-group">
                                          <label for="formGroupExampleInput">Enter Email/Mobile number</label>
                                          <input type="text" class="form-control" id="formGroupExampleInput" placeholder="+91 123 456 7890">
                                       </fieldset>
                                       <fieldset class="form-group">
                                          <label for="formGroupExampleInput2">Enter Password</label>
                                          <input type="password" class="form-control" id="formGroupExampleInput2" placeholder="********">
                                       </fieldset>
                                       <fieldset class="form-group">
                                          <button type="submit" class="btn btn-lg btn-theme-round btn-block">Enter to your account</button>
                                       </fieldset>
                                       <div class="login-with-sites text-center">
                                          <p>or Login with your social profile:</p>
                                          <button class="btn-facebook login-icons btn-lg"><i class="fa fa-facebook"></i> Facebook</button>
                                          <button class="btn-google login-icons btn-lg"><i class="fa fa-google"></i> Google</button>
                                          <button class="btn-twitter login-icons btn-lg"><i class="fa fa-twitter"></i> Twitter</button>
                                       </div>
                                       <p><label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                          <input type="checkbox" class="custom-control-input">
                                          <span class="custom-control-indicator"></span>
                                          <span class="custom-control-description">Remember me </span>
                                          </label>
                                       </p>
                                    </div>
                                    <div class="tab-pane" id="register" role="tabpanel">
                                       <h5 class="heading-design-h5">Register Now!</h5>
                                       <fieldset class="form-group">
                                          <label for="formGroupExampleInput">Enter Email/Mobile number</label>
                                          <input type="text" class="form-control" id="formGroupExampleInput" placeholder="+91 123 456 7890">
                                       </fieldset>
                                       <fieldset class="form-group">
                                          <label for="formGroupExampleInput2">Enter Password</label>
                                          <input type="password" class="form-control" id="formGroupExampleInput2" placeholder="********">
                                       </fieldset>
                                       <fieldset class="form-group">
                                          <label for="formGroupExampleInput3">Enter Confirm Password </label>
                                          <input type="password" class="form-control" id="formGroupExampleInput3" placeholder="********">
                                       </fieldset>
                                       <fieldset class="form-group">
                                          <button type="submit" class="btn btn-lg btn-theme-round btn-block">Create Your Account</button>
                                       </fieldset>
                                       <p>
                                          <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                          <input type="checkbox" class="custom-control-input">
                                          <span class="custom-control-indicator"></span>
                                          <span class="custom-control-description">I Agree with Term and Conditions  </span>
                                          </label>
                                       </p>
                                    </div>
                                 </div>
                                 <div class="clearfix"></div>
                                 <div class="text-center login-footer-tab">
                                    <ul class="nav nav-tabs" role="tablist">
                                       <li class="nav-item">
                                          <a class="nav-link active" data-toggle="tab" href="#login" role="tab"><i class="icofont icofont-lock"></i> LOGIN</a>
                                       </li>
                                       <li class="nav-item">
                                          <a class="nav-link" data-toggle="tab" href="#register" role="tab"><i class="icofont icofont-pencil-alt-5"></i> REGISTER</a>
                                       </li>
                                    </ul>
                                 </div>
                                 <div class="clearfix"></div>
                              </div>
                           </form>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <div class="navbar-top">
         <div class="container">
            <div class="row">
               <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-left">
                  <p>
                     End Of Reason Sale- Get Min <span class="text-danger">40- 80%</span> off! 
                  </p>
               </div>
               <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-right">
                  <ul class="list-inline">
                     <li class="list-inline-item">
                        <a href="#"><i class="icofont icofont-iphone"></i> +1-123-456-7890</a>
                     </li>
                     <li class="list-inline-item">
                        <a href="#"><i class="icofont icofont-headphone-alt"></i> Contact Us</a>
                     </li>
                     <li class="list-inline-item">
                        <span>Download App</span> &nbsp;
                        <a href="#"><i class="icofont icofont-brand-windows"></i></a>
                        <a href="#"><i class="icofont icofont-brand-apple"></i></a>
                        <a href="#"><i class="icofont icofont-brand-android-robot"></i></a>
                     </li>
                  </ul>
               </div>
            </div>
         </div>
      </div>
      <nav class="navbar navbar-expand-lg navbar-light bg-faded osahan-menu">
         <div class="container">
            <a class="navbar-brand" href="index.html"> <img src="/Projects/Web/Resources/images/logo.png" alt="logo"> </a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
               <ul class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto">
                  <li class="nav-item dropdown active">
                     <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     <i class="icofont icofont-ui-home"></i> Home <span class="sr-only">(current)</span>
                     </a>
                     <div class="dropdown-menu">
                        <a class="dropdown-item" href="index.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Home Version 1 </a>
                        <a class="dropdown-item" href="index2.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Home Version 2 </a>
                        <a class="dropdown-item" href="index3.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Home Version 3 </a>
                        <a class="dropdown-item" href="index4.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Home Version 4 </a>
                        <a class="dropdown-item" href="index5.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Home Version 5 </a>
                     </div>
                  </li>
                  <li class="nav-item dropdown mega-dropdown-main">
                     <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     Men
                     </a>
                     <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">Clothing <span class="badge badge-danger">HOT</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Casual shirt</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Trousers</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Suits & Blazers <span class="badge badge-warning">20%</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sportswear </a>
                                 <a class="mega-title" href="#">Eyewear </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Backpacks</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Ray-Ban <span class="badge badge-info">NEW</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Opium </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Joe Black </a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">Jewellery <span class="badge badge-secondary">50%</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Gold</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Platinum</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Rings </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Neckwear </a>
                                 <a class="mega-title" href="#">Watches <span class="badge badge-primary">25% OFF</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Fastrack </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Timex </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Citizen</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Titan <span class="badge badge-light">60%</span></a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">Shoes <span class="badge badge-success">SALE</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sports & Outdoor</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Mocassins</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sneakers </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Formal Shoes </a>
                                 <a class="mega-title" href="#">Accessories </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Handbags <span class="badge badge-dark">NEW</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sunglasses</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Clutches </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Backpacks </a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                              <span class="mega-menu-img hidden-sm"> <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><img src="/Projects/Web/Resources/images/offers/men-top.png" alt="Bannar 1"></a> </span>
                           </div>
                        </div>
                     </div>
                  </li>
                  <li class="sale-nav nav-item dropdown mega-dropdown-main">
                     <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     Women
                     </a>
                     <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                              <span class="mega-menu-img hidden-sm"> <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><img src="/Projects/Web/Resources/images/offers/women-top.png" alt="Bannar 1"></a> </span>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">Eyewear <span class="badge badge-primary">NEW</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Backpacks</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Ray-Ban</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Opium <span class="badge badge-secondary">20%</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Joe Black </a>
                                 <a class="mega-title" href="#">Clothing <span class="badge badge-success">SALE</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Casual shirt</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Trousers</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Suits & Blazers </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sportswear </a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">Watches <span class="badge badge-default">HOT</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Fastrack </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Timex </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Citizen <span class="badge badge-success">5%</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Titan </a>
                                 <a class="mega-title" href="#">Jewellery </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Gold</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Platinum</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Rings </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Neckwear <span class="badge badge-light">25%</span> </a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">Shoes  <span class="badge badge-danger">60%</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sports & Outdoor</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Mocassins</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sneakers <span class="badge badge-dark">10%</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Formal Shoes </a>
                                 <a class="mega-title" href="#">Accessories <span class="badge badge-warning">50% OFF</span> </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Handbags</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sunglasses</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Clutches </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Backpacks <span class="badge badge-info">HOT</span></a>
                              </div>
                           </div>
                        </div>
                     </div>
                  </li>
                  <li class="nav-item dropdown mega-dropdown-main">
                     <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     Kids
                     </a>
                     <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list"><a class="mega-title" href="#">Baby clothing <span class="badge badge-info">10% OFF</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Casual shirt</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Trousers</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Suits & Blazers </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sportswear </a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list"><a class="mega-title" href="#">Boys <span class="badge badge-danger">HOT</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Clothing</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Shoes</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Watches <span class="badge badge-primary">5% OFF</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sunglasses </a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">Girls </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Baby Girl <span class="badge badge-dark">10%</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Shoes <span class="badge badge-warning">NEW</span></a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Watches </a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Sunglasses </a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                              <span class="mega-menu-img hidden-sm"> <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>"><img src="/Projects/Web/Resources/images/offers/kids-top.png" alt="Bannar 1"></a> </span>
                           </div>
                        </div>
                     </div>
                  </li>
                  <li class="nav-item dropdown mega-dropdown-main">
                     <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     Pages
                     </a>
                     <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                           <div class="col-lg-2 col-sm-2 col-xs-2 col-md-2">
                              <div class="mega-list"><a class="mega-title" href="#">Shop Pages </a>
                                 <a href="shop-grid-full.html">Shop Grid Full width </a>
                                 <a href="shop-grid-right-sidebar.html">Shop Grid Right Sidebar</a>
                                 <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Shop Grid Left Sidebar</a>
                                 <a href="shop-list-full.html">Shop List Full width </a>
                                 <a href="shop-list-right-sidebar.html">Shop List Right Sidebar</a>
                                 <a href="shop-list-left-sidebar.html">Shop List Left Sidebar</a>
                              </div>
                           </div>
                           <div class="col-lg-2 col-sm-2 col-xs-2 col-md-2">
                              <div class="mega-list"><a class="mega-title" href="#">Product Pages </a>
                                 <a href="category.html">Category Page</a>
                                 <a href="shop-detail.html">Shop Detail</a>
                                 <a href="wishlist.html">Wishlists </a>
                                 <a href="wishlist-user.html">My Wishlist </a>
                                 <a href="compare.html">Compare </a>
                                 <a href="quick_view.html">Quick View </a>
                              </div>
                           </div>
                           <div class="col-lg-2 col-sm-2 col-xs-2 col-md-2">
                              <div class="mega-list"><a class="mega-title" href="#">Cart Pages </a>
                                 <a href="view-cart.html">Cart </a>
                                 <a href="cart_order.html">Cart Order</a>
                                 <a href="cart_checkout.html">Cart Checkout</a>
                                 <a href="cart_delivery.html">Cart Delivery</a>
                                 <a href="cart_done.html">Thanks for order</a>
                                 <a href="shopping_cart.html">Shopping Cart Tabs</a>
                              </div>
                           </div>
                           <div class="col-lg-2 col-sm-2 col-xs-2 col-md-2">
                              <div class="mega-list"><a class="mega-title" href="#">Account Pages </a>
                                 <a href="my-profile.html">My Profile</a>
                                 <a href="my-address.html">My Address</a>
                                 <a href="order-list.html">Order List</a>
                                 <a href="order-status.html">Order Status</a>
                                 <a href="invoice.html">Invoice A4</a>
                                 <a href="about.html">About Us </a>
                              </div>
                           </div>
                           <div class="col-lg-2 col-sm-2 col-xs-2 col-md-2">
                              <div class="mega-list"><a class="mega-title" href="#">Static Pages </a>
                                 <a href="faq.html">FAQ </a>
                                 <a href="login.html">Login</a>
                                 <a href="register.html">Register</a>
                                 <a href="login.html">Login Modal</a>
                                 <a href="terms-conditions.html">Terms and Conditions </a>
                                 <a href="privacy-policy.html">Privacy Policy</a>
                              </div>
                           </div>
                           <div class="col-lg-2 col-sm-2 col-xs-2 col-md-2">
                              <div class="mega-list"><a class="mega-title" href="#">Other Pages </a>
                                 <a href="blog-right.html">Blog &ndash; Right Sidebar </a>
                                 <a href="blog-left.html">Blog &ndash; Left Sidebar </a>
                                 <a href="blog.html">Blog &ndash; Full-Width </a>
                                 <a href="<%= Url("Shop_Clother_NewDetail") %>">Single post </a> 
                                 <a href="email-template.html">Email Template </a>
                                 <a href="404.html">Error 404 </a>
                              </div>
                           </div>
                        </div>
                     </div>
                  </li>
                  <li class="nav-item dropdown mega-dropdown-main">
                     <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     Components
                     </a>
                     <div class="dropdown-menu mega-dropdown mega-list-arrow-none">
                        <div class="row">
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">A - C </a>
                                 <a href="alerts.html"><i class="icofont icofont-exclamation-tringle"></i> Alerts</a>
                                 <a href="badge.html"><i class="icofont icofont-file-alt"></i> Badge</a>
                                 <a href="breadcrumb.html"><i class="icofont icofont-all-caps"></i> Breadcrumb</a>
                                 <a href="button-group.html"><i class="icofont icofont-ui-social-link"></i> Button Group</a>
                                 <a href="buttons.html"><i class="icofont icofont-link-alt"></i> Buttons</a>
                                 <a href="card.html"><i class="icofont icofont-ui-v-card"></i> Card</a>
                                 <a href="carousel.html"><i class="icofont icofont-image"></i> Carousel</a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">A - I </a>
                                 <a href="collapse.html"><i class="icofont icofont-listing-box"></i> Collapse</a>
                                 <a href="dropdowns.html"><i class="icofont icofont-line-block-down"></i> Dropdowns</a>
                                 <a href="figures.html"><i class="icofont icofont-paper"></i> Figures</a>
                                 <a href="forms.html"><i class="icofont icofont-ui-edit"></i> Forms</a>
                                 <a href="grid-system.html"><i class="icofont icofont-calculations"></i> Grid System</a>
                                 <a href="images.html"><i class="icofont icofont-ui-image"></i> Images</a>
                                 <a href="input-group.html"><i class="icofont icofont-paperclip"></i> Input Group</a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">J - P </a>
                                 <a href="jumbotron.html"><i class="icofont icofont-page"></i> Jumbotron</a>
                                 <a href="list-group.html"><i class="icofont icofont-list"></i> List Group</a>
                                 <a href="media-object.html"><i class="icofont icofont-multimedia"></i> Media Object</a>
                                 <a href="modal.html"><i class="icofont icofont-picture"></i> Modal</a>
                                 <a href="nav.html"><i class="icofont icofont-square"></i> Nav</a>
                                 <a href="navbar.html"><i class="icofont icofont-navigation-menu"></i> Navbar</a>
                                 <a href="pagination.html"><i class="icofont icofont-bubble-right"></i> Pagination</a>
                              </div>
                           </div>
                           <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                              <div class="mega-list">
                                 <a class="mega-title" href="#">P - T</a>
                                 <a href="popovers.html"><i class="icofont icofont-scroll-right"></i> Popovers</a>
                                 <a href="progress.html"><i class="icofont icofont-circle-ruler"></i> Progress</a>
                                 <a href="blank-page.html"><i class="icofont icofont-paper"></i> Page Blank</a>
                                 <a href="scrollspy.html"><i class="icofont icofont-hand-drag1"></i> Scrollspy</a>
                                 <a href="tables.html"><i class="icofont icofont-table"></i> Tables</a>
                                 <a href="tooltips.html"><i class="icofont icofont-cursor-drag"></i> Tooltips</a>
                                 <a href="typography.html"><i class="icofont icofont-line-height"></i> Typography</a>
                              </div>
                           </div>
                        </div>
                     </div>
                  </li>
                  <li class="nav-item dropdown">
                     <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                     Blog
                     </a>
                     <div class="dropdown-menu">
                        <a class="dropdown-item" href="blog-right.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Blog &ndash; Right Sidebar </a>
                        <a class="dropdown-item" href="blog-left.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Blog &ndash; Left Sidebar </a>
                        <a class="dropdown-item" href="blog.html"><i class="fa fa-angle-right" aria-hidden="true"></i> Blog &ndash; Full-Width </a>
                        <a class="dropdown-item" href="<%= Url("Shop_Clother_NewDetail") %>"><i class="fa fa-angle-right" aria-hidden="true"></i> Single post </a> 
                     </div>
                  </li>
                  <li class="nav-item">
                     <a class="nav-link" href="contact.html">Contact</a>
                  </li>
               </ul>
               <div class="my-2 my-lg-0">
                  <ul class="list-inline main-nav-right">
                     <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-theme-round dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="icofont icofont-shopping-cart"></i> Cart <small class="cart-value">02</small>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right cart-dropdown">
                           <div class="dropdown-item">						
                              <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="Remove">
                              <i class="fa fa-trash-o"></i>
                              </a>
                              <a href="#">
                              <img class="img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt="Product">
                              <strong>Ipsums Dolors Untra </strong>
                              <small>Color : Red | Size : M</small>
                              <span class="product-desc-price">$529.99</span>
                              <span class="product-price text-danger">$329.99</span>
                              </a>
                           </div>
                           <div class="dropdown-item">						
                              <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="Remove">
                              <i class="fa fa-trash-o"></i>
                              </a>
                              <a href="#">
                              <img class="img-fluid" src="/Projects/Web/Resources/images/all-products/small/3.jpg" alt="Product">
                              <strong>Ipsums Dolors Untra </strong>
                              <small>Color : Black | Size : XL</small>
                              <span class="product-desc-price">$82.99</span>
                              <span class="product-price text-danger">$36.99</span>
                              </a>
                           </div>
                           <div class="dropdown-item">						
                              <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="Remove">
                              <i class="fa fa-trash-o"></i>
                              </a>
                              <a href="#">
                              <img class="img-fluid" src="/Projects/Web/Resources/images/all-products/small/2.jpg" alt="Product">
                              <strong>Ipsums Dolors Untra </strong>
                              <small>Color : white | Size : L</small>
                              <span class="product-desc-price">$29.99</span>
                              <span class="product-price text-danger">$20.99</span>
                              </a>
                           </div>
                           <div class="dropdown-divider"></div>
                           <div class="dropdown-cart-footer text-center">
                              <h4> <strong>Subtotal</strong>: $210 </h4>
                              <a class="btn btn-sm btn-danger" href="view-cart.html"> <i class="icofont icofont-shopping-cart"></i> VIEW
                              CART </a> <a href="cart_checkout.html" class="btn btn-sm btn-primary"> CHECKOUT </a>
                           </div>
                        </div>
                     </li>
                     <li class="list-inline-item">
                        <a  class="btn btn-theme-round" data-toggle="modal" data-target="#bd-example-modal" href="#"><i class="icofont icofont-ui-user"></i> Sign In</a>
                     </li>
                  </ul>
               </div>
            </div>
         </div>
      </nav>
      <div class="osahan-breadcrumb">
         <div class="container">
            <div class="row">
               <div class="col-lg-12 col-md-12">
                  <ol class="breadcrumb">
                     <li class="breadcrumb-item"><a href="#"><i class="icofont icofont-ui-home"></i> Home</a></li>
                     <li class="breadcrumb-item"><a href="#">Pages</a></li>
                     <li class="breadcrumb-item active">Page Name</li>
                  </ol>
               </div>
            </div>
         </div>
      </div>
      <section class="receipt_page">
         <div class="container">
            <div class="row">
               <div class="col-lg-8 col-md-8 mx-auto">
                  <div class="receipt-main">
                     <div class="receipt-header">
                        <div class="row">
                           <div class="col-lg-6 col-md-6">
                              <div class="receipt-left">
                                 <img class="img-responsive" alt="iamgurdeeposahan" src="/Projects/Web/Resources/images/users/3.jpg">
                              </div>
                           </div>
                           <div class="col-lg-6 col-md-6 text-right">
                              <div class="receipt-right">
                                 <h5>AskBootstrap.</h5>
                                 <p>+91 85680-79956 <i class="fa fa-phone fa-fw"></i></p>
                                 <p>iamosahan@gmail.com <i class="fa fa-envelope-o fa-fw"></i></p>
                                 <p>India <i class="fa fa-location-arrow fa-fw"></i></p>
                              </div>
                           </div>
                        </div>
                     </div>
                     <div class="receipt-header receipt-header-mid">
                        <div class="row">
                           <div class="col-lg-8 col-md-8 text-left">
                              <div class="receipt-right">
                                 <h5>Gurdeep Osahan <span class="badge badge-danger">#HSFB 342823</span></h5>
                                 <p><b>Mobile :</b> +91 12345-6789</p>
                                 <p><b>Email :</b> info@gmail.com</p>
                                 <p><b>Address :</b> Australia</p>
                              </div>
                           </div>
                           <div class="col-lg-4 col-md-4">
                              <div class="receipt-left">
                                 <h1>Receipt</h1>
                              </div>
                           </div>
                        </div>
                     </div>
                     <div>
                        <table class="table table-bordered">
                           <thead>
                              <tr>
                                 <th>Description</th>
                                 <th>Amount</th>
                              </tr>
                           </thead>
                           <tbody>
                              <tr>
                                 <td class="col-md-9">Ipsums Dolors Untra  | August 2017</td>
                                 <td class="col-md-3">$15,000/-</td>
                              </tr>
                              <tr>
                                 <td class="col-md-9">Ipsums Dolors Untra  | August 2017</td>
                                 <td class="col-md-3">$6,00/-</td>
                              </tr>
                              <tr>
                                 <td class="col-md-9">Ipsums Dolors Untra  | August 2017</td>
                                 <td class="col-md-3">$35,00/-</td>
                              </tr>
                              <tr>
                                 <td class="text-right">
                                    <p>
                                       <strong>Total Amount: </strong>
                                    </p>
                                    <p>
                                       <strong>Shipping: </strong>
                                    </p>
                                    <p>
                                       <strong>Total (tax excl.): </strong>
                                    </p>
                                    <p>
                                       <strong>Tax: </strong>
                                    </p>
                                 </td>
                                 <td>
                                    <p>
                                       <strong>$65,500/-</strong>
                                    </p>
                                    <p>
                                       <strong>$500/-</strong>
                                    </p>
                                    <p>
                                       <strong>$1300/-</strong>
                                    </p>
                                    <p>
                                       <strong>$9500/-</strong>
                                    </p>
                                 </td>
                              </tr>
                              <tr>
                                 <td class="text-right">
                                    <h2><strong>Total: </strong></h2>
                                 </td>
                                 <td class="text-left">
                                    <h2><strong class="text-danger"> $31.566/-</strong></h2>
                                 </td>
                              </tr>
                           </tbody>
                        </table>
                     </div>
                     <div class="receipt-header receipt-header-mid receipt-footer">
                        <div class="row">
                           <div class="col-lg-8 col-md-8 text-left">
                              <div class="receipt-right">
                                 <p><b>Date :</b> 15 Aug 2018</p>
                                 <h5 style="color: rgb(140, 140, 140);">Thank you for your business!</h5>
                              </div>
                           </div>
                           <div class="col-lg-4 col-md-4">
                              <div class="receipt-left">
                                 <h1>Signature</h1>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </section>
      <section class="top-brands">
         <div class="container">
            <div class="section-header">
               <h5 class="heading-design-h5">Top Brands <span class="badge badge-primary">200 Brands</span></h5>
            </div>
            <div class="row text-center">
               <div class="col-lg-2 col-md-2 col-sm-2">
                  <a href="#"><img class="img-responsive" src="/Projects/Web/Resources/images/brands/1.jpg" alt=""></a>
               </div>
               <div class="col-lg-2 col-md-2 col-sm-2">
                  <a href="#"><img class="img-responsive" src="/Projects/Web/Resources/images/brands/2.jpg" alt=""></a>
               </div>
               <div class="col-lg-2 col-md-2 col-sm-2">
                  <a href="#"><img class="img-responsive" src="/Projects/Web/Resources/images/brands/3.jpg" alt=""></a>
               </div>
               <div class="col-lg-2 col-md-2 col-sm-2">
                  <a href="#"><img class="img-responsive" src="/Projects/Web/Resources/images/brands/4.jpg" alt=""></a>
               </div>
               <div class="col-lg-2 col-md-2 col-sm-2">
                  <a href="#"><img class="img-responsive" src="/Projects/Web/Resources/images/brands/5.jpg" alt=""></a>
               </div>
               <div class="col-lg-2 col-md-2 col-sm-2">
                  <a href="#"><img class="img-responsive" src="/Projects/Web/Resources/images/brands/6.jpg" alt=""></a>
               </div>
            </div>
         </div>
      </section>
      <footer>
         <section class="footer-Content">
            <div class="container">
               <div class="row">
                  <div class="col-lg-3 col-md-3 col-sm-3">
                     <div class="footer-widget">
                        <h3 class="block-title">About</h3>
                        <div class="textwidget">
                           <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum. Sed ex est,  Sed ex est, consectetur eget consectetur, Lorem ipsum dolor sit amet...</p>
                        </div>
                     </div>
                  </div>
                  <div class="col-lg-3 col-md-3 col-sm-3">
                     <div class="footer-widget">
                        <h3 class="block-title">Categories</h3>
                        <ul class="menu">
                           <li><a href="#"><span>562</span>  Footwear </a></li>
                           <li><a href="#"><span>451</span>  Luggage </a></li>
                           <li><a href="#"><span>352</span>  Clothing </a></li>
                           <li><a href="#"><span>312</span>  Eyewear </a></li>
                           <li><a href="#"><span>262</span>  Watches</a></li>
                           <li><a href="#"><span>152</span> Jewellery </a></li>
                           <li><a href="#"><span>352</span>  Clothing </a></li>
                           <li><a href="#"><span>312</span>  Eyewear </a></li>
                           <li><a href="#"><span>262</span>  Watches</a></li>
                           <li><a href="#"><span>152</span> Jewellery </a></li>
                           <li><a href="#"><span>562</span>  Footwear </a></li>
                           <li><a href="#"><span>451</span>  Bags</a></li>
                        </ul>
                     </div>
                  </div>
                  <div class="col-lg-3 col-md-3 col-sm-3">
                     <div class="footer-widget">
                        <h3 class="block-title">Latest Post</h3>
                        <ul class="blog-footer">
                           <li>
                              <a href="#">Lorem ipsum dolor sit amet, quem...</a>
                              <span class="post-date"><i class="fa fa-calendar" aria-hidden="true"></i> March 12, 2017</span>
                           </li>
                           <li>
                              <a href="#">Full Width Media Post Lorem ipsum..</a>
                              <span class="post-date"><i class="fa fa-calendar" aria-hidden="true"></i> September 25, 2017</span>
                           </li>
                           <li>
                              <a href="#">Perfect Video Post Lorem ipsum..</a>
                              <span class="post-date"><i class="fa fa-calendar" aria-hidden="true"></i> November 19, 2017</span>
                           </li>
                        </ul>
                     </div>
                  </div>
                  <div class="col-lg-3 col-md-3 col-sm-3">
                     <div class="footer-widget">
                        <h3 class="block-title">Quick Links</h3>
                        <ul class="menu">
                           <li><a href="#">Home</a></li>
                           <li><a href="#">About</a></li>
                           <li><a href="#">FAQ</a></li>
                           <li><a href="#">Careers</a></li>
                           <li><a href="#">Discount</a></li>
                           <li><a href="#">Categories</a></li>
                           <li><a href="#">Retunrs</a></li>
                           <li><a href="#">Team</a></li>
                           <li><a href="#">Contact</a></li>
                           <li><a href="#">Blog</a></li>
                           <li><a href="#">Help</a></li>
                           <li><a href="#">Advertise With Us</a></li>
                        </ul>
                     </div>
                  </div>
               </div>
            </div>
         </section>
      </footer>
      <section class="footer">
         <div class="container">
            <div class="row">
               <div class="col-lg-8 col-md-8 col-sm-8">
                  <div class="footer-logo pull-left hidden-xs">
                     <img alt="" src="/Projects/Web/Resources/images/footer-logo.png" class="img-responsive">
                  </div>
                  <div class="footer-links">
                     <ul>
                        <li><a href="#">Home</a></li>
                        <li><a href="#">New Collection</a></li>
                        <li><a href="#">Mens Collection</a></li>
                        <li><a href="#">Women Dresses</a></li>
                        <li><a href="#">Kids Collection</a></li>
                     </ul>
                  </div>
                  <div class="copyright">
                     <p>© Copyright 2018 Osahan Fashion.&nbsp; | &nbsp;Made with <i class="fa fa-heart"></i>
                        by
                        <a target="_blank" href="https://www.facebook.com/iamgurdeeposahan">
                        <strong>Osahan Studio</strong>
                        </a>
                     </p>
                  </div>
               </div>
               <div class="col-lg-4 col-md-4 col-sm-4 text-right">
                  <div class="social-icon">
                     <a href="#"><i class="fa fa-facebook"></i></a>
                     <a href="#"><i class="fa fa-twitter"></i></a>
                     <a href="#"><i class="fa fa-linkedin"></i></a>
                     <a href="#"><i class="fa fa-instagram"></i></a>
                  </div>
               </div>
            </div>
         </div>
      </section>
      <section class="footer-bottom">
         <div class="container">
            <div class="row">
               <div class="col-lg-6 col-md-6 text-left">
                  <div class="payment-menthod">
                     <img alt="" src="/Projects/Web/Resources/images/payment_methods.png">
                  </div>
               </div>
               <div class="col-lg-6 col-md-6 text-right">
                  <strong>Download App &nbsp; </strong>
                  <a href="#"><img alt="" src="/Projects/Web/Resources/images/app-store.png"></a>
                  <a href="#"><img alt="" src="/Projects/Web/Resources/images/google-play.png"></a>
               </div>
            </div>
         </div>
      </section>
      <!-- Bootstrap Core JavaScript -->
      <script src="js/jquery.min.js"></script>
      <script src="js/popper.min.js"></script>
      <script src="plugins/tether/tether.min.js"></script>
      <script src="js/bootstrap.min.js"></script>
      <!-- Custom js -->
      <script src="js/custom.js"></script>
      <!-- Select2 -->
      <link href="plugins/select2/css/select2.min.css" rel="stylesheet" />
      <script src="plugins/select2/js/select2.min.js"></script>
      <!-- Owl Carousel -->
      <script src="plugins/owl-carousel/owl.carousel.js"></script>
   </body>
</html>
