<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Jewelry_ProductDetails.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Jewelry.Pages.Shop_Jewelry_ProductDetails" %>
<%@ Register Src="~/Projects/Shops/Shop_Jewelry/Modules/Categories.ascx" TagPrefix="uc1" TagName="Categories" %>




<section class="section-padding bg-dark inner-header">
         <div class="container">
            <div class="row">
               <div class="col-md-12 text-center">
                  <h1 class="mt-0 mb-3 text-white">Shop Detail</h1>
                  <div class="breadcrumbs">
                     <p class="mb-0 text-white"><a href="<%= Url("Shop_Jewelry") %>" class="text-white">Home</a>  /  <span class="text-success">Shop Detail</span></p>
                  </div>
               </div>
            </div>
         </div>
      </section>
      <section class="shop-single section-padding">
         <div class="container">
            <div class="row">
               <div class="col-md-6">
                  <div class="shop-detail-left">
                     <div class="shop-detail-slider">
                        <div class="favourite-icon">
                           <a class="fav-btn" title="" data-placement="bottom" data-toggle="tooltip" href="#" data-original-title="59% OFF"><i class="mdi mdi-tag-outline"></i></a>
                        </div>
                        <div id="sync1" class="owl-carousel text-center">
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/1.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/2.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/3.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/4.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/5.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/6.jpg" class="img-fluid img-center"></div>
                        </div>
                        <div id="sync2" class="owl-carousel">
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/1.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/2.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/3.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/4.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/5.jpg" class="img-fluid img-center"></div>
                           <div class="item"><img alt="" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/6.jpg" class="img-fluid img-center"></div>
                        </div>
                     </div>
                  </div>
               </div>
               <div class="col-md-6">
                  <div class="shop-detail-right">
                     <span class="badge badge-success">50% OFF</span>
                     <h2>Oxidized Three Layer Necklace </h2>
                     <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                     <p class="regular-price"><i class="mdi mdi-tag-outline"></i> MRP : $800.99</p>
                     <p class="offer-price mb-0">Discounted price : <span class="text-danger">$450.99</span></p>
                     <a href="<%= Url("Shop_Jewelry_Checkout") %>"><button type="button" class="btn btn-secondary btn-lg"><i class="mdi mdi-cart-outline"></i> Add To Cart</button> </a>
                     <div class="short-description">
                        <h5>
                           Quick Overview  
                           <p class="float-right">Availability: <span class="badge badge-success">In Stock</span></p>
                        </h5>
                        <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b> Nam fringilla augue nec est tristique auctor. Donec.
                        </p>
                        <p class="mb-0"> Vivamus adipiscing nisl ut dolor dignissim semper. Nulla luctus malesuada tincidunt. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hiMenaeos. Integer enim purus interdum.</p>
                     </div>
                     <h6 class="mb-3 mt-4">Why shop from Osahan Jewelry?</h6>
                     <div class="row">
                        <div class="col-md-6">
                           <div class="feature-box">
                              <i class="mdi mdi-truck-fast"></i>
                              <h6 class="text-info">Free Delivery</h6>
                              <p>Lorem ipsum dolor...</p>
                           </div>
                        </div>
                        <div class="col-md-6">
                           <div class="feature-box">
                              <i class="mdi mdi-basket"></i>
                              <h6 class="text-info">100% Guarantee</h6>
                              <p>Rorem Ipsum Dolor sit...</p>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </section>
      <section class="product-items-slider section-padding bg-white border-top">
         <div class="container">
            <div class="section-header">
               <h5 class="heading-design-h5">Best Offers View <span class="badge badge-primary">20% OFF</span>
                  <a class="float-right text-secondary" href="<%= Url("Shop_Jewelry_Shop") %>">View All</a>
               </h5>
            </div>
            <div class="owl-carousel owl-carousel-featured">
               <div class="item">
                  <div class="product">
                     <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                           <span class="badge badge-success">50% OFF</span>
                           <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/7.jpg" alt="">
                           <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                           <h5>Product Title Here</h5>
                           <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                           <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                           <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i><br><span class="regular-price">$800.99</span></p>
                        </div>
                     </a>
                  </div>
               </div>
               <div class="item">
                  <div class="product">
                     <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                           <span class="badge badge-success">50% OFF</span>
                           <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/8.jpg" alt="">
                           <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                           <h5>Product Title Here</h5>
                           <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                           <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                           <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i><br><span class="regular-price">$800.99</span></p>
                        </div>
                     </a>
                  </div>
               </div>
               <div class="item">
                  <div class="product">
                     <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                           <span class="badge badge-success">50% OFF</span>
                           <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/9.jpg" alt="">
                           <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                           <h5>Product Title Here</h5>
                           <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                           <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                           <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i><br><span class="regular-price">$800.99</span></p>
                        </div>
                     </a>
                  </div>
               </div>
               <div class="item">
                  <div class="product">
                     <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                           <span class="badge badge-success">50% OFF</span>
                           <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/10.jpg" alt="">
                           <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                           <h5>Product Title Here</h5>
                           <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                           <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                           <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i><br><span class="regular-price">$800.99</span></p>
                        </div>
                     </a>
                  </div>
               </div>
               <div class="item">
                  <div class="product">
                     <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                           <span class="badge badge-success">50% OFF</span>
                           <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/11.jpg" alt="">
                           <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                           <h5>Product Title Here</h5>
                           <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                           <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                           <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i><br><span class="regular-price">$800.99</span></p>
                        </div>
                     </a>
                  </div>
               </div>
               <div class="item">
                  <div class="product">
                     <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                           <span class="badge badge-success">50% OFF</span>
                           <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/12.jpg" alt="">
                           <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                           <h5>Product Title Here</h5>
                           <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                           <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                           <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i><br><span class="regular-price">$800.99</span></p>
                        </div>
                     </a>
                  </div>
               </div>
            </div>
         </div>
      </section>

<uc1:Categories runat="server" ID="Categories" />
