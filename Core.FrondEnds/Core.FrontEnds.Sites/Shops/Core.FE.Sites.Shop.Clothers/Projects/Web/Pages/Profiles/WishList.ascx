<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WishList.ascx.cs" Inherits="Core.FE.Sites.Shop.Clothers.Projects.Web.Pages.Profiles.WishList" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
         <div class="container">
            <div class="row">
               <div class="col-lg-12 col-md-12">
                  <ol class="breadcrumb">
                     <li class="breadcrumb-item"><a href="<%= Url("Home") %>"><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                     <li class="breadcrumb-item"><a href="<%= Url("Profile") %>">Cá nhân</a></li>
                     <li class="breadcrumb-item active">Đã thích</li>
                  </ol>
               </div>
            </div>
         </div>
      </div>
      <section class="shopping_cart_page">
         <div class="container">
            <div class="row">
               <div class="col-lg-4 col-md-4 col-sm-5">
                  <div class="user-account-sidebar">
                     <aside class="user-info-wrapper">
                        <div class="user-cover" style="background-image: url(/Projects/Web/Resources/images/user-cover-img.jpg);">
                           <div class="info-label" data-toggle="tooltip" title="" data-original-title="Verified Account"><i class="icofont icofont-check-circled"></i></div>
                        </div>
                        <div class="user-info">
                           <div class="user-avatar"><a class="edit-avatar" href=""><i class="icofont icofont-edit"></i></a><img src="/Projects/Web/Resources/images/user-ava.jpg" alt="User"></div>
                           <div class="user-data">
                              <h4>Osahan Singh</h4>
                              <span><i class="icofont icofont-ui-calendar"></i> Joined February 06, 2017</span>
                           </div>
                        </div>
                     </aside>
                     <nav class="list-group">
                        <a class="list-group-item" href="<%= Url("Profile") %>"><i class="icofont icofont-ui-user fa-fw"></i> My Profile</a>
                        <a class="list-group-item" href="<%= Url("Address") %>"><i class="icofont icofont-location-pin fa-fw"></i> My Address</a>
                        <a class="list-group-item active justify-content-between" href="<%= Url("WishList") %>"><span><i class="icofont icofont-heart-alt fa-fw"></i> Wish List</span> <span class="badge badge-danger"> 35 Items</span></a>
                        <a class="list-group-item justify-content-between" href="<%= Url("OrderList") %>"><span><i class="icofont icofont-list fa-fw"></i> Order List</span> <span class="badge badge-warning">6 Items</span></a>
                        <a class="list-group-item" href="<%= Url("Login") %>"><i class="icofont icofont-logout fa-fw"></i> Logout</a>
                     </nav>
                  </div>
               </div>
               <div class="col-lg-8 col-md-8 col-sm-7">
                  <div class="widget">
                     <div class="section-header">
                        <h5 class="heading-design-h5">
                           My Wishlist
                        </h5>
                     </div>
                     <div class="row">
                        <div class="col-lg-4 col-md-6">
                           <div class="h-100">
                              <div class="product-item">
                                 <div class="product-item-image">
                                    <span class="like-icon"><a href=""> <i class="icofont icofont-close-circled"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/men/small/2.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                       <span class="product-desc-price">$329.00</span>
                                       <span class="product-price">$201.00</span>
                                       <span class="product-discount">10% Off</span>
                                    </h5>
                                    <p>
                                       <a class="btn btn-success" href=""><i class="icofont icofont-shopping-cart"></i> Add To Cart</a>
                                    </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                           <div class="h-100">
                              <div class="product-item">
                                 <div class="product-item-image">
                                    <span class="like-icon"><a href=""> <i class="icofont icofont-close-circled"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                       <span class="product-desc-price">$529.99</span>
                                       <span class="product-price">$329.99</span>
                                       <span class="product-discount">30% Off</span>
                                    </h5>
                                    <p>
                                       <a class="btn btn-success" href=""><i class="icofont icofont-shopping-cart"></i> Add To Cart</a>
                                    </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                           <div class="h-100">
                              <div class="product-item">
                                 <div class="product-item-image">
                                    <span class="like-icon"><a href=""> <i class="icofont icofont-close-circled"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/4.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                       <span class="product-desc-price">$630.00</span>
                                       <span class="product-price">$350.00</span>
                                       <span class="product-discount">5% Off</span>
                                    </h5>
                                    <p>
                                       <a class="btn btn-success" href=""><i class="icofont icofont-shopping-cart"></i> Add To Cart</a>
                                    </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                     <div class="row">
                        <div class="col-lg-4 col-md-6">
                           <div class="h-100">
                              <div class="product-item">
                                 <div class="product-item-image">
                                    <span class="like-icon"><a href=""> <i class="icofont icofont-close-circled"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                       <span class="product-desc-price">$529.99</span>
                                       <span class="product-price">$329.99</span>
                                       <span class="product-discount">30% Off</span>
                                    </h5>
                                    <p>
                                       <a class="btn btn-success" href=""><i class="icofont icofont-shopping-cart"></i> Add To Cart</a>
                                    </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                           <div class="h-100">
                              <div class="product-item">
                                 <div class="product-item-image">
                                    <span class="like-icon"><a href=""> <i class="icofont icofont-close-circled"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/4.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                       <span class="product-desc-price">$630.00</span>
                                       <span class="product-price">$350.00</span>
                                       <span class="product-discount">5% Off</span>
                                    </h5>
                                    <p>
                                       <a class="btn btn-success" href=""><i class="icofont icofont-shopping-cart"></i> Add To Cart</a>
                                    </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                           <div class="h-100">
                              <div class="product-item">
                                 <div class="product-item-image">
                                    <span class="like-icon"><a href=""> <i class="icofont icofont-close-circled"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/women/small/3.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                       <span class="product-desc-price">$229.00</span>
                                       <span class="product-price">$101.00</span>
                                       <span class="product-discount">20% Off</span>
                                    </h5>
                                    <p>
                                       <a class="btn btn-success" href=""><i class="icofont icofont-shopping-cart"></i> Add To Cart</a>
                                    </p>
                                 </div>
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
