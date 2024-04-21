<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Quickview.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Pages.Shop_Mobile_Quickview" %>
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
      <section class="receipt_page">
         <div class="container">
         <div class="row">
            <div class="text-center col-lg-12">
               <button class="btn btn-primary btn-lg" data-toggle="modal" data-target=".bd-example-modal-lg">Quick View (CLICK HERE)</button>
            </div>
            <!-- Modal -->
            <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
               <div class="modal-dialog modal-lg" role="document">
                  <div class="modal-content">
                     <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel"><i class="icofont icofont-jersey"></i>
                           Clothing 
                        </h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                        </button>
                     </div>
                     <div class="modal-body">
                        <div class="container-fluid-full">
                           <div class="row">
                              <div class="col-lg-5 col-md-5">
                                 <div class="shop-detail-left">
                                    <div class="item-img-grid">
                                       <div class="favourite-icon">
                                          <a class="fav-btn" title="" data-placement="bottom" data-toggle="tooltip" href="" data-original-title="Save Ad">115 <i class="fa fa-heart"></i></a>
                                       </div>
                                       <div id="sync1" class="owl-carousel">
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/1.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/2.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/3.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/4.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/5.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/6.jpg" class="img-responsive img-center"></div>
                                       </div>
                                       <div id="sync2" class="owl-carousel">
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/1.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/2.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/3.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/4.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/5.jpg" class="img-responsive img-center"></div>
                                          <div class="item"><img alt="" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/large/6.jpg" class="img-responsive img-center"></div>
                                       </div>
                                    </div>
                                 </div>
                              </div>
                              <div class="col-lg-7 col-md-7">
                                 <div class="shop-detail-right">
                                    <div class="widget">
                                       <div class="product-name">
                                          <p class="text-danger text-uppercase"><i class="icofont icofont-iphone"></i>
                                             Mobile 
                                          </p>
                                          <h1>iPhone X</h1>
                                          <span>Product code: <b>1919140</b> | Sold by: <strong class="text-info">Gurdeeposahan</strong></span>
                                       </div>
                                       <div class="price-box">
                                          <h5>
                                             <span class="product-desc-price">Price : $329.00</span>
                                             <span class="product-price text-danger">Special Price <i class="icofont icofont-price"></i> $201.00</span>
                                             <span class="badge badge-default">50% Off</span>
                                          </h5>
                                       </div>
                                       <div class="ratings">
                                          <div class="stars-rating">
                                             <i class="icofont icofont-star active"></i>
                                             <i class="icofont icofont-star active"></i>
                                             <i class="icofont icofont-star"></i>
                                             <i class="icofont icofont-star"></i>
                                             <i class="icofont icofont-star"></i> <span>(613)</span>
                                             <span class="rating-links pull-right"> <a href="">1 Review(s)</a> <span class="separator"> </span> <a href=""><i class="icofont icofont-comment"></i> Add Your Review</a> </span>
                                          </div>
                                       </div>
                                       <div class="short-description">
                                          <h4>
                                             Quick Overview  
                                             <span class="pull-right">Availability: <strong class="badge badge-success">In Stock</strong></span>
                                          </h4>
                                          <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b> Nam fringilla augue nec est tristique auctor. Donec non est at libero vulputate rutrum.
                                          </p>
                                          <p> Vivamus adipiscing nisl ut dolor dignissim semper. Nulla luctus malesuada tincidunt. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hiMenaeos.</p>
                                       </div>
                                       <div class="product-color-size-area row">
                                          <div class="color-area col-lg-6 col-md-6">
                                             <h4>Color</h4>
                                             <div class="color">
                                                <ul class="osahan-select-color">
                                                   <li>
                                                      <a class="color-bg bg-blue" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Blue"></a>
                                                      <a class="color-bg bg-navy" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Navy"></a>
                                                      <a class="color-bg bg-red" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Red"></a>
                                                      <a class="color-bg bg-maroon" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Maroon"></a>
                                                      <a class="color-bg bg-pink" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Pink"></a>
                                                      <a class="color-bg bg-yellow" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Yellow"></a>
                                                   </li>
                                                </ul>
                                             </div>
                                          </div>
                                          <div class="size-area col-lg-6 col-md-6">
                                             <h4>Size</h4>
                                             <div class="size">
                                                <ul class="list-inline">
                                                   <li class="list-inline-item"><a href="">S</a></li>
                                                   <li class="list-inline-item"><a href="">L</a></li>
                                                   <li class="list-inline-item"><a href="">M</a></li>
                                                   <li class="list-inline-item"><a href="">XL</a></li>
                                                   <li class="list-inline-item"><a href="">XXL</a></li>
                                                </ul>
                                             </div>
                                          </div>
                                       </div>
                                       <div class="product-variation">
                                          <form action="#" method="post">
                                             <button type="button" class="btn btn-outline-success btn-lg"><i class="icofont icofont-heart"></i> Add To Wishlist</button>
                                             <button type="button" class="btn btn-theme-round btn-lg"> <i class="icofont icofont-shopping-cart"></i> Add To Cart</button>
                                          </form>
                                       </div>
                                       <div class="product-cart-option">
                                          <ul class="list-inline">
                                             <li class="list-inline-item"><a href="wishlist.html"><i class="icofont icofont-heart"></i> <span>Add to Wishlist</span></a></li>
                                             <li class="list-inline-item"><a href=""><i class="icofont icofont-retweet"></i> <span>Add to Compare</span></a></li>
                                             <li class="list-inline-item"><a href=""><i class="icofont icofont-send-mail"></i> <span>Email to a Friend</span></a></li>
                                          </ul>
                                       </div>
                                    </div>
                                 </div>
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
