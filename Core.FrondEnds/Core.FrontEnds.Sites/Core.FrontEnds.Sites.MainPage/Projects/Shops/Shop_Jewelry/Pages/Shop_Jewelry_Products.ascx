<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Jewelry_Products.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Jewelry.Pages.Shop_Jewelry_Products" %>
<%@ Register Src="~/Projects/Shops/Shop_Jewelry/Modules/Categories.ascx" TagPrefix="uc1" TagName="Categories" %>


<section class="section-padding bg-dark inner-header">
         <div class="container">
            <div class="row">
               <div class="col-md-12 text-center">
                  <h1 class="mt-0 mb-3 text-white">Shop</h1>
                  <div class="breadcrumbs">
                     <p class="mb-0 text-white"><a href="<%= Url("Shop_Jewelry") %>" class="text-white">Home</a>  /  <span class="text-success">Shop</span></p>
                  </div>
               </div>
            </div>
         </div>
      </section>
      <section class="shop-list section-padding">
         <div class="container">
            <div class="row">
               <div class="col-md-3">
                  <div class="shop-filters">
                     <div id="accordion">
                        <div class="card">
                           <div class="card-header" id="headingOne">
                              <h5 class="mb-0">
                                 <button class="btn btn-link" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
								 Stones <span class="mdi mdi-chevron-down float-right"></span>
                                 </button>
                              </h5>
                           </div>
                           <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordion">
                              <div class="card-body">
                                 <div class="list-group">
									<a href="" class="list-group-item list-group-item-action">Diamond <span class="badge badge-info">(1215)</span></a>
									<a href="" class="list-group-item list-group-item-action">Diamond And Gemstone (574)</a>
									<a href="" class="list-group-item list-group-item-action">Gemstone <span class="badge badge-danger">NEW</span></a>
									<a href="" class="list-group-item list-group-item-action active">Pearl (250)</a>
									<a href="" class="list-group-item list-group-item-action">Ruby (227)</a>
									<a href="" class="list-group-item list-group-item-action">Emerald (68)</a>
									<a href="" class="list-group-item list-group-item-action">Topaz (42)</a>
									<a href="" class="list-group-item list-group-item-action">Tourmaline (38)</a>
									<a href="" class="list-group-item list-group-item-action">Sapphire (35)</a>
									<a href="" class="list-group-item list-group-item-action">Amethyst (26)</a>
									<a href="" class="list-group-item list-group-item-action">Aquamarine (21)</a>
									<a href="" class="list-group-item list-group-item-action">Citrine (19)</a>
									<a href="" class="list-group-item list-group-item-action">Navaratna (19) </a>
				                </div>
                              </div>
                           </div>
                        </div>
                        <div class="card">
                           <div class="card-header" id="headingTwo">
                              <h5 class="mb-0">
                                 <button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                 Price <span class="mdi mdi-chevron-down float-right"></span>
                                 </button>
                              </h5>
                           </div>
                           <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
                              <div class="card-body">
                                 <div class="list-group">
									<a href="" class="list-group-item list-group-item-action">Below $. 10,000 (46)</a>
									<a href="" class="list-group-item list-group-item-action">$. 10,000 - $. 20,000 (278)</a>
									<a href="" class="list-group-item list-group-item-action">$. 20,000 - $. 30,000 (284)</a>
									<a href="" class="list-group-item list-group-item-action">$. 30,000 - $. 40,000 (203)</a>
									<a href="" class="list-group-item list-group-item-action">$. 40,000 - $. 50,000 (130)</a>
									<a href="" class="list-group-item list-group-item-action">$. 50,000 and Above (274) </a>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="card">
                           <div class="card-header" id="headingThree">
                              <h5 class="mb-0">
                                 <button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                 Metal <span class="mdi mdi-chevron-down float-right"></span>
                                 </button>
                              </h5>
                           </div>
                           <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                              <div class="card-body">
                                 <div class="list-group">
                                    <a href="" class="list-group-item list-group-item-action">Diamond <span class="badge badge-info">(1215)</span></a>
									<a href="" class="list-group-item list-group-item-action">Diamond And Gemstone (574)</a>
									<a href="" class="list-group-item list-group-item-action">Gemstone (365)</a>
									<a href="" class="list-group-item list-group-item-action">Pearl (250)</a>
									<a href="" class="list-group-item list-group-item-action">Ruby (227)</a>
									<a href="" class="list-group-item list-group-item-action">Emerald (68)</a>
									<a href="" class="list-group-item list-group-item-action">Topaz (42)</a>
									<a href="" class="list-group-item list-group-item-action">Tourmaline (38)</a>
									<a href="" class="list-group-item list-group-item-action">Sapphire (35)</a>
									<a href="" class="list-group-item list-group-item-action">Amethyst (26)</a>
									<a href="" class="list-group-item list-group-item-action">Aquamarine (21)</a>
									<a href="" class="list-group-item list-group-item-action">Citrine (19)</a>
									<a href="" class="list-group-item list-group-item-action">Navaratna (19) </a>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
				<div class="left-ad mt-4">
					<img class="img-fluid" alt="" src="http://via.placeholder.com/254x261">
				</div>
               </div>
               <div class="col-md-9">
                  <a href=""><img class="img-fluid mb-3" src="/Projects/Shops/Shop_Jewelry/Resources/img/shop.jpg" alt=""></a>
                  <div class="shop-head">
                     <a href="<%= Url("Shop_Jewelry") %>"><span class="mdi mdi-home"></span> Home</a> <span class="mdi mdi-chevron-right"></span> <a href="">Jewellery</a> <span class="mdi mdi-chevron-right"></span> <a href="">Earrings</a>
                     <div class="btn-group float-right mt-2">
                        <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Sort by Products &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </button>
                        <div class="dropdown-menu dropdown-menu-right">
                           <a class="dropdown-item" href="#">Relevance</a>
                           <a class="dropdown-item" href="#">Price (Low to High)</a>
                           <a class="dropdown-item" href="#">Price (High to Low)</a>
                           <a class="dropdown-item" href="#">Discount (High to Low)</a>
                           <a class="dropdown-item" href="#">Name (A to Z)</a>
                        </div>
                     </div>
                     <h5 class="mb-3">Jewellery</h5>
                  </div>
                  <div class="row no-gutters">
                     <div class="col-md-4">
                        <div class="product">
                           <a href="<%= Url("Shop_Jewelry_Single") %>">
                              <div class="product-header">
                                 <span class="badge badge-success">50% OFF</span>
                                 <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/1.jpg" alt="">
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
                     <div class="col-md-4">
                        <div class="product">
                           <a href="<%= Url("Shop_Jewelry_Single") %>">
                              <div class="product-header">
                                 <span class="badge badge-success">50% OFF</span>
                                 <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/2.jpg" alt="">
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
                     <div class="col-md-4">
                        <div class="product">
                           <a href="<%= Url("Shop_Jewelry_Single") %>">
                              <div class="product-header">
                                 <span class="badge badge-success">50% OFF</span>
                                 <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/3.jpg" alt="">
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
                  <div class="row no-gutters">
                     <div class="col-md-4">
                        <div class="product">
                           <a href="<%= Url("Shop_Jewelry_Single") %>">
                              <div class="product-header">
                                 <span class="badge badge-success">50% OFF</span>
                                 <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/4.jpg" alt="">
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
                     <div class="col-md-4">
                        <div class="product">
                           <a href="<%= Url("Shop_Jewelry_Single") %>">
                              <div class="product-header">
                                 <span class="badge badge-success">50% OFF</span>
                                 <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/5.jpg" alt="">
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
                     <div class="col-md-4">
                        <div class="product">
                           <a href="<%= Url("Shop_Jewelry_Single") %>">
                              <div class="product-header">
                                 <span class="badge badge-success">50% OFF</span>
                                 <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/6.jpg" alt="">
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
                  <div class="row no-gutters">
                     <div class="col-md-4">
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
                     <div class="col-md-4">
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
                     <div class="col-md-4">
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
                  </div>
                  <nav>
                     <ul class="pagination justify-content-center mt-4">
                        <li class="page-item disabled">
                           <span class="page-link">Previous</span>
                        </li>
                        <li class="page-item"><a class="page-link" href="#">1</a></li>
                        <li class="page-item active">
                           <span class="page-link">
                           2
                           <span class="sr-only">(current)</span>
                           </span>
                        </li>
                        <li class="page-item"><a class="page-link" href="#">3</a></li>
                        <li class="page-item">
                           <a class="page-link" href="#">Next</a>
                        </li>
                     </ul>
                  </nav>
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
