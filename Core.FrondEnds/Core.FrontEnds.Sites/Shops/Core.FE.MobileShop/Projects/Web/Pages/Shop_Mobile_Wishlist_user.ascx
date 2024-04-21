<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Wishlist_user.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Wishlist_user" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



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
      <section class="shopping_cart_page">
         <h6 class="sr-only">validator.w3</h6>
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
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Profile") %>"><i class="icofont icofont-ui-user fa-fw"></i>My Profile</a>
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Address") %>"><i class="icofont icofont-location-pin fa-fw"></i>My Address</a>
                        <a class="list-group-item active justify-content-between" href="<%= Url("Shop_Mobile_Wishlist_user") %>"><span><i class="icofont icofont-heart-alt fa-fw"></i>Wish List</span> <span class="badge badge-danger">35 Items</span></a>
                        <a class="list-group-item justify-content-between" href="<%= Url("Shop_Mobile_Orderlist") %>"><span><i class="icofont icofont-list fa-fw"></i>Order List</span> <span class="badge badge-warning">6 Items</span></a>
                        <a class="list-group-item justify-content-between" href="<%= Url("Shop_Mobile_Orderstatus") %>"><span><i class="icofont icofont-truck-loaded fa-fw"></i>Order Status</span> <span class="badge badge-success">4</span></a>
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Login") %>"><i class="icofont icofont-logout fa-fw"></i>Logout</a>
                    </nav>
				    </div>
					<div class="left-ad mt-4">
						<img class="rounded img-fluid" src="http://via.placeholder.com/350x300" alt="">
					</div>
               </div>
               <div class="col-lg-8 col-md-8 col-sm-7">
                  <div class="widget">
                     <div class="section-header">
                        <h5 class="heading-design-h5">
                           My Wishlist
                        </h5>
                     </div>
                     <div class="row mb-4">
                        <div class="col-lg-4 col-md-6">
                           <div class="h-100">
                              <div class="product-item">
                                 <div class="product-item-image">
                                    <span class="like-icon"><a href=""> <i class="icofont icofont-close-circled"></i></a></span>
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products-list/small/2.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                       <span class="product-desc-price">$529.99</span>
                                       <span class="product-price">$329.99</span>
                                       <span class="product-discount">30% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                       <span class="product-desc-price">$529.99</span>
                                       <span class="product-price">$329.99</span>
                                       <span class="product-discount">30% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/4.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                       <span class="product-desc-price">$630.00</span>
                                       <span class="product-price">$350.00</span>
                                       <span class="product-discount">5% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                       <span class="product-desc-price">$529.99</span>
                                       <span class="product-price">$329.99</span>
                                       <span class="product-discount">30% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/4.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                       <span class="product-desc-price">$630.00</span>
                                       <span class="product-price">$350.00</span>
                                       <span class="product-discount">5% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>"><img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products-list/small/3.jpg" alt=""></a>
                                 </div>
                                 <div class="product-item-body">
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                       <span class="product-desc-price">$229.00</span>
                                       <span class="product-price">$101.00</span>
                                       <span class="product-discount">20% Off</span>
                                    </p>
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
<uc1:Top_Brands runat="server" id="Top_Brands" />
