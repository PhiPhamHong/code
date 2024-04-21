<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeLogin.ascx.cs" Inherits="Core.FE.Sites.Shop.Clothers.Projects.Web.Pages.HomeLogin" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="owl-carousel owl-carousel-slider">
    <div class="item">
        <a href="<%= Url("Home") %>">
            <img class="d-block img-fluid" src="/Projects/Web/Resources/images/slider/slider3.jpg" alt="First slide"></a>
    </div>
    <div class="item">
        <a href="<%= Url("Home") %>">
            <img class="d-block img-fluid" src="/Projects/Web/Resources/images/slider/slider1.jpg" alt="First slide"></a>
    </div>
    <div class="item">
        <a href="<%= Url("Home") %>">
            <img class="d-block img-fluid" src="/Projects/Web/Resources/images/slider/slider2.jpg" alt="First slide"></a>
    </div>
</div>
<!-- Featured Products -->
<section class="featured-products">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="carousel-section-header">
                    <h5 class="heading-design-h5">Featured Items <a href="<%= Url("Products") %>" class="btn btn-warning pull-right">Show More Items <b>24727</b> <i class="fa fa-arrow-right"></i></a></h5>
                </div>
                <div id="owl-carousel-featured" class="owl-carousel owl-carousel-featured">
                    <div class="item">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-danger offer-badge">HOT</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                        <span class="product-desc-price">$529.99</span>
                                        <span class="product-price">$329.99</span>
                                        <span class="product-discount">30% Off</span>
                                    </h5>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Size</strong> <span>ONE SIZE</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star"></i>
                                        <i class="icofont icofont-star"></i><span>(415)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-info offer-badge">NEW</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a class="active" href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/2.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                        <span class="product-desc-price">$329.00</span>
                                        <span class="product-price">$201.00</span>
                                        <span class="product-discount">10% Off</span>
                                    </h5>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Size</strong> <span>ONE SIZE</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star"></i>
                                        <i class="icofont icofont-star"></i>
                                        <i class="icofont icofont-star"></i><span>(613)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="h-100">
                            <div class="product-item pro">
                                <span class="badge badge-primary offer-badge">30% OFF</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/3.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                        <span class="product-desc-price">$229.00</span>
                                        <span class="product-price">$101.00</span>
                                        <span class="product-discount">20% Off</span>
                                    </h5>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Size</strong> <span>ONE SIZE</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star"></i><span>(613)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-default offer-badge">NEW</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/4.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                        <span class="product-desc-price">$200.00</span>
                                        <span class="product-price">$100.00</span>
                                        <span class="product-discount">50% Off</span>
                                    </h5>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Size</strong> <span>10</span> <span>9</span> <span>8</span> <span>7</span> <span>6</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i><span>(44)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-warning offer-badge">OFFERS</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/5.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                        <span class="product-desc-price">$430.00</span>
                                        <span class="product-price">$350.00</span>
                                        <span class="product-discount">20% Off</span>
                                    </h5>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Size</strong> <span>10</span> <span>9</span> <span>8</span> <span>7</span> <span>6</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star"></i>
                                        <i class="icofont icofont-star"></i>
                                        <i class="icofont icofont-star"></i>
                                        <i class="icofont icofont-star"></i><span>(150)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-success offer-badge">50% OFF</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%= Url("ProductDetails") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/6.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                    <h5>
                                        <span class="product-desc-price">$630.00</span>
                                        <span class="product-price">$350.00</span>
                                        <span class="product-discount">5% Off</span>
                                    </h5>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Size</strong> <span>10</span> <span>9</span> <span>8</span> <span>7</span> <span>6</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star"></i><span>(300)</span>
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
<!-- End Featured Products -->
<section class="categories-list">
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-4 col-sm-5">
                <div class="widget">
                    <div class="widget-header">
                        <small>98,156 Items</small>
                        <h1><i class="icofont icofont-man-in-glasses"></i>Men's Fashion</h1>
                    </div>
                    <div class="widget-body">
                        <ul class="trends">
                            <li><a href=""><i class="icofont icofont-boot"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href=""><i class="icofont icofont-bag"></i>Bags & Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href=""><i class="icofont icofont-jersey"></i>Clothing <span class="badge badge-danger">HOT</span><span class="item-numbers">65</span></a></li>
                            <li><a href=""><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href=""><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href=""><i class="icofont icofont-diving-goggle"></i>Eyewear <span class="item-numbers">65</span></a></li>
                            <li><a href=""><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-8 col-sm-7">
                <div class="single-categorie">
                    <div id="owl-carousel-featured" class="owl-carousel categories-list-page">
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-danger offer-badge">HOT</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/men/small/1.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$529.99</span>
                                            <span class="product-price">$329.99</span>
                                            <span class="product-discount">30% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i><span>(415)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-info offer-badge">NEW</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a class="active" href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/men/small/2.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$329.00</span>
                                            <span class="product-price">$201.00</span>
                                            <span class="product-discount">10% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i><span>(613)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-primary offer-badge">30% OFF</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/men/small/3.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$229.00</span>
                                            <span class="product-price">$101.00</span>
                                            <span class="product-discount">20% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i><span>(613)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-default offer-badge">NEW</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/men/small/4.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$200.00</span>
                                            <span class="product-price">$100.00</span>
                                            <span class="product-discount">50% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i><span>(44)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-warning offer-badge">OFFERS</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/men/small/5.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$430.00</span>
                                            <span class="product-price">$350.00</span>
                                            <span class="product-discount">20% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i><span>(150)</span>
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
<section class="hot-offers">
    <div class="container">
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6">
                <a href="">
                    <img src="/Projects/Web/Resources/images/offers/home2_banner_2.jpg" alt="">
                </a>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <a href="">
                    <img src="/Projects/Web/Resources/images/offers/home2_banner_3.jpg" alt="">
                </a>
            </div>
        </div>
    </div>
</section>
<section class="categories-list">
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-4 col-sm-5">
                <div class="widget">
                    <div class="widget-header">
                        <small>98,156 Items</small>
                        <h1><i class="icofont icofont-woman-in-glasses"></i>Women's Fashion</h1>
                    </div>
                    <div class="widget-body">
                        <ul class="trends">
                            <li><a href=""><i class="icofont icofont-sandals-female"></i>Footwear <span class="item-numbers">155</span></a></li>
                            <li><a href=""><i class="icofont icofont-jewlery"></i>Fashion Jewellery <span class="item-numbers">65</span></a></li>
                            <li><a href=""><i class="icofont icofont-bag"></i>Bags & Luggage <span class="item-numbers">80</span></a></li>
                            <li><a href=""><i class="icofont icofont-jersey"></i>Clothing <span class="item-numbers">65</span></a></li>
                            <li><a href=""><i class="icofont icofont-gift"></i>Accessories <span class="item-numbers">155</span></a></li>
                            <li><a href=""><i class="icofont icofont-apple-watch"></i>Watches <span class="item-numbers">80</span></a></li>
                            <li><a href=""><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-8 col-sm-7">
                <div class="single-categorie">
                    <div id="owl-carousel-featured" class="owl-carousel categories-list-page">
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-danger offer-badge">HOT</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/women/small/1.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$529.99</span>
                                            <span class="product-price">$329.99</span>
                                            <span class="product-discount">30% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i><span>(415)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-info offer-badge">NEW</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a class="active" href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/women/small/2.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$329.00</span>
                                            <span class="product-price">$201.00</span>
                                            <span class="product-discount">10% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i><span>(613)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-primary offer-badge">30% OFF</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/women/small/3.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$229.00</span>
                                            <span class="product-price">$101.00</span>
                                            <span class="product-discount">20% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i><span>(613)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-default offer-badge">NEW</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/women/small/4.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$200.00</span>
                                            <span class="product-price">$100.00</span>
                                            <span class="product-discount">50% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star active"></i><span>(44)</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="h-100">
                                <div class="product-item">
                                    <span class="badge badge-warning offer-badge">OFFERS</span>
                                    <div class="product-item-image">
                                        <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                        <a href="<%= Url("ProductDetails") %>">
                                            <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/women/small/5.jpg" alt=""></a>
                                    </div>
                                    <div class="product-item-body">
                                        <div class="product-item-action">
                                            <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                        </div>
                                        <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                                        <h5>
                                            <span class="product-desc-price">$430.00</span>
                                            <span class="product-price">$350.00</span>
                                            <span class="product-discount">20% Off</span>
                                        </h5>
                                    </div>
                                    <div class="product-item-footer">
                                        <div class="product-item-size">
                                            <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                                        </div>
                                        <div class="stars-rating">
                                            <i class="icofont icofont-star active"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i>
                                            <i class="icofont icofont-star"></i><span>(150)</span>
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
<section class="hot-offers light-bg text-center">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <a href="">
                    <img src="/Projects/Web/Resources/images/offers/home1_bn1.png" alt="">
                </a>
            </div>
        </div>
    </div>
</section>
<section class="deals-of-the-day">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Hot Products 
                  <div class="pull-right" id="countdown"></div>
            </h5>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="h-100">
                    <div class="product-item">
                        <div class="product-item-image">
                            <span class="like-icon"><a class="active" href=""><i class="icofont icofont-heart"></i></a></span>
                            <a href="<%= Url("ProductDetails") %>">
                                <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/men/small/2.jpg" alt=""></a>
                        </div>
                        <div class="product-item-body">
                            <div class="product-item-action">
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
                            </div>
                            <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                            <h5>
                                <span class="product-desc-price">$329.00</span>
                                <span class="product-price">$201.00</span>
                                <span class="product-discount">10% Off</span>
                            </h5>
                        </div>
                        <div class="product-item-footer">
                            <div class="product-item-size">
                                <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                            </div>
                            <div class="stars-rating">
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star"></i>
                                <i class="icofont icofont-star"></i>
                                <i class="icofont icofont-star"></i><span>(613)</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="h-100">
                    <div class="product-item">
                        <div class="product-item-image">
                            <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                            <a href="<%= Url("ProductDetails") %>">
                                <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt=""></a>
                        </div>
                        <div class="product-item-body">
                            <div class="product-item-action">
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
                            </div>
                            <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                            <h5>
                                <span class="product-desc-price">$529.99</span>
                                <span class="product-price">$329.99</span>
                                <span class="product-discount">30% Off</span>
                            </h5>
                        </div>
                        <div class="product-item-footer">
                            <div class="product-item-size">
                                <strong>Size</strong> <span>ONE SIZE</span>
                            </div>
                            <div class="stars-rating">
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star"></i>
                                <i class="icofont icofont-star"></i><span>(415)</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="h-100">
                    <div class="product-item">
                        <div class="product-item-image">
                            <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                            <a href="<%= Url("ProductDetails") %>">
                                <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/4.jpg" alt=""></a>
                        </div>
                        <div class="product-item-body">
                            <div class="product-item-action">
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
                            </div>
                            <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                            <h5>
                                <span class="product-desc-price">$630.00</span>
                                <span class="product-price">$350.00</span>
                                <span class="product-discount">5% Off</span>
                            </h5>
                        </div>
                        <div class="product-item-footer">
                            <div class="product-item-size">
                                <strong>Size</strong> <span>10</span> <span>9</span> <span>8</span> <span>7</span> <span>6</span>
                            </div>
                            <div class="stars-rating">
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star"></i><span>(300)</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="h-100">
                    <div class="product-item">
                        <div class="product-item-image">
                            <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                            <a href="<%= Url("ProductDetails") %>">
                                <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/women/small/3.jpg" alt=""></a>
                        </div>
                        <div class="product-item-body">
                            <div class="product-item-action">
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
                            </div>
                            <h4 class="card-title"><a href="<%= Url("ProductDetails") %>">Ipsums Dolors Untra</a></h4>
                            <h5>
                                <span class="product-desc-price">$229.00</span>
                                <span class="product-price">$101.00</span>
                                <span class="product-discount">20% Off</span>
                            </h5>
                        </div>
                        <div class="product-item-footer">
                            <div class="product-item-size">
                                <strong>Size</strong> <span>S</span> <span>M</span> <span>L</span> <span>XL</span> <span>2XL</span>
                            </div>
                            <div class="stars-rating">
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star"></i><span>(613)</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />