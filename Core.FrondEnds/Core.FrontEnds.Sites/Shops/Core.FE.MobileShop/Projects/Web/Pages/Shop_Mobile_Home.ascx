<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Home.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Home" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="owl-carousel owl-carousel-slider">
    <div class="item">
        <a href="">
            <img class="d-block img-fluid" src="/Projects/Web/Resources/images/b1.jpg" alt="First slide"></a>
    </div>
    <%--<div class="item">
        <a href="">
            <img class="d-block img-fluid" src="/Projects/Web/Resources/images/b2.jpg" alt="First slide"></a>
    </div>--%>
    <div class="item">
        <a href="">
            <img class="d-block img-fluid" src="/Projects/Web/Resources/images/b3.jpg" alt="First slide"></a>
    </div>
</div>
<!-- Featured Products -->
<section class="featured-products">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="carousel-section-header">
                    <h5 class="heading-design-h5">Sản phẩm nổi bật <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>" class="btn btn-warning pull-right mobile-none">Xem tất cả <b><%= Total %></b> <i class="fa fa-arrow-right"></i></a></h5>
                </div>
                <div class="owl-carousel owl-carousel-featured">
                    <%--<div class="item">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-danger offer-badge">HOT</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                        <span class="product-desc-price">$529.99</span>
                                        <span class="product-price">$329.99</span>
                                        <span class="product-discount">30% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/2.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                        <span class="product-desc-price">$329.00</span>
                                        <span class="product-price">$201.00</span>
                                        <span class="product-discount">10% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/3.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                        <span class="product-desc-price">$229.00</span>
                                        <span class="product-price">$101.00</span>
                                        <span class="product-discount">20% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/4.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                        <span class="product-desc-price">$229.00</span>
                                        <span class="product-price">$101.00</span>
                                        <span class="product-discount">20% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/5.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                        <span class="product-desc-price">$430.00</span>
                                        <span class="product-price">$350.00</span>
                                        <span class="product-discount">20% Off</span>
                                    </p>
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
                                    <a href="<%= Url("Shop_Mobile_Shop_details") %>">
                                        <img class="card-img-top img-fluid" src="/Projects/Web/Resources/images/all-products/small/6.jpg" alt=""></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href=""><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>">Ipsums Dolors Untra</a></p>
                                    <p>
                                        <span class="product-desc-price">$430.00</span>
                                        <span class="product-price">$350.00</span>
                                        <span class="product-discount">20% Off</span>
                                    </p>
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
                    </div>--%>

                    <asp:Repeater runat="server" ID="rpProducts">
                        <ItemTemplate>
                            <div class="item">
                                <div class="h-100">
                                    <div class="product-item">
                                        <span class="badge badge-danger offer-badge">HOT</span>
                                        <div class="product-item-image">
                                            <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                            <a href="<%# Eval("UrlFormat") %>">
                                                <img class="card-img-top img-fluid" src="<%# Eval("Avatar") %>" alt="<%# Eval("Name") %>"></a>
                                        </div>
                                        <div class="product-item-body">
                                            <div class="product-item-action">
                                                <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" data-cmd="AddToCart" data-id="<%# Eval("ProductId") %>"><i class="icofont icofont-shopping-cart"></i></a>
                                                <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%# Eval("UrlFormat") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                            </div>
                                            <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>"><%# Eval("Name") %></a></p>
                                            <p>
                                                <span class="product-desc-price"><%# Eval("PriceOld","{0:0,0}") %></span>
                                                <span class="product-price"><%# Eval("PriceSale","{0:0,0}") %></span>
                                                <%--<span class="product-discount">30% Off</span>--%>
                                            </p>
                                        </div>
                                        <div class="product-item-footer">
                                            <div class="product-item-size">
                                                <strong>Colors: </strong><span>ONE COLOR</span>
                                            </div>
                                            <div class="stars-rating">
                                                <i class="icofont icofont-star active"></i>
                                                <i class="icofont icofont-star active"></i>
                                                <i class="icofont icofont-star active"></i>
                                                <i class="icofont icofont-star active"></i>
                                                <i class="icofont icofont-star"></i><%--<span>(415)</span>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Featured Products -->
<%--<section class="banner-area hot-offers">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
                <div class="banner-block mt-0">
                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                        <img src="/Projects/Web/Resources/images/offers-list/1.jpg" alt="banner collection">
                    </a>
                    <div class="text-des-container pad-zero">
                        <div class="text-des">
                            <h2>Product Name</h2>
                            <p>Lorem Ipsum is simply dummy!</p>
                            <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                        <div class="banner-block">
                            <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                <img src="/Projects/Web/Resources/images/offers-list/2.jpg" alt="banner sunglasses">
                            </a>
                            <div class="text-des-container">
                                <div class="text-des">
                                    <h2>Product Name</h2>
                                    <p>Lorem Ipsum is simply dummy!</p>
                                    <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="banner-block">
                            <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                <img src="/Projects/Web/Resources/images/offers-list/3.jpg" alt="banner jeans">
                            </a>
                            <div class="text-des-container pad-zero">
                                <div class="text-des">
                                    <h2>Product Name</h2>
                                    <p>Lorem Ipsum is simply dummy!</p>
                                    <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-lg-6 col-md-6">
                        <div class="banner-block">
                            <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                <img src="/Projects/Web/Resources/images/offers-list/4.jpg" alt="banner kids">
                            </a>
                            <div class="text-des-container">
                                <div class="text-des">
                                    <h2>Product Name</h2>
                                    <p>Lorem Ipsum is simply dummy!</p>
                                    <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="banner-block">
                            <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                <img src="/Projects/Web/Resources/images/offers-list/5.jpg" alt="banner women">
                            </a>
                            <div class="text-des-container">
                                <div class="text-des">
                                    <h2>Product Name</h2>
                                    <p>Lorem Ipsum is simply dummy!</p>
                                    <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="banner-block">
                            <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                <img src="/Projects/Web/Resources/images/offers-list/6.jpg" alt="banner beauty">
                            </a>
                            <div class="text-des-container">
                                <div class="text-des">
                                    <h2>Product Name</h2>
                                    <p>Lorem Ipsum is simply dummy!</p>
                                    <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-4 col-lg-4 col-md-4">
                <div class="banner-block mt-0">
                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                        <img src="/Projects/Web/Resources/images/offers-list/7.jpg" alt="banner arrival">
                    </a>
                    <div class="text-des-container">
                        <div class="text-des">
                            <h2>Product Name</h2>
                            <p>Lorem Ipsum is simply dummy!</p>
                            <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                        </div>
                    </div>
                </div>
                <div class="banner-block">
                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                        <img src="/Projects/Web/Resources/images/offers-list/8.jpg" alt="banner watch">
                    </a>
                    <div class="text-des-container">
                        <div class="text-des">
                            <h2>Product Name</h2>
                            <p>Lorem Ipsum is simply dummy!</p>
                            <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                        </div>
                    </div>
                </div>
                <div class="banner-block">
                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                        <img src="/Projects/Web/Resources/images/offers-list/9.jpg" alt="banner look">
                    </a>
                    <div class="text-des-container">
                        <div class="text-des">
                            <h2>Product Name</h2>
                            <p>Lorem Ipsum is simply dummy!</p>
                            <a class="btn btn-primary" href=""><i class="icofont icofont-shopping-cart"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>--%>
<section class="categories-list">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Sản phẩm đang khuyến mại
            </h5>
        </div>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="single-categorie">
                    <div class="owl-carousel categories-list-page">
                        <asp:Repeater runat="server" ID="rpOnsale">
                            <ItemTemplate>
                                <div class="item">
                                    <div class="h-100">
                                        <div class="product-item">
                                            <span class="badge badge-danger offer-badge">HOT</span>
                                            <div class="product-item-image">
                                                <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                                <a href="<%# Eval("UrlFormat") %>">
                                                    <img class="card-img-top img-fluid" src="<%# Eval("Avatar") %>" alt="<%# Eval("Name") %>"></a>
                                            </div>
                                            <div class="product-item-body">
                                                <div class="product-item-action">
                                                    <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm" data-cmd="AddToCart" data-id="<%# Eval("ProductId") %>" ><i class="icofont icofont-shopping-cart"></i></a>
                                                    <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%# Eval("UrlFormat") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                                </div>
                                                <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>"><%# Eval("Name") %></a></p>
                                                <p>
                                                    <span class="product-desc-price"><%# Eval("PriceOld","{0:0,0}") %></span>
                                                    <span class="product-price"><%# Eval("PriceSale","{0:0,0}") %></span>
                                                    <%--<span class="product-discount">30% Off</span>--%>
                                                </p>
                                            </div>
                                            <div class="product-item-footer">
                                                <div class="product-item-size">
                                                    <strong>Colors: </strong><span>ONE COLOR</span>
                                                </div>
                                                <div class="stars-rating">
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star"></i><%--<span>(415)</span>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<%--<div class="hot-offers pt-0 pb-0 ads-two">
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
</div>--%>
<section class="categories-list">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Sản phẩm bán chạy
            </h5>
        </div>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="single-categorie">
                    <div class="owl-carousel categories-list-page">

                        <asp:Repeater runat="server" ID="rpBestseller">
                            <ItemTemplate>
                                <div class="item">
                                    <div class="h-100">
                                        <div class="product-item">
                                            <span class="badge badge-info offer-badge">NEW</span>
                                            <div class="product-item-image">
                                                <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                                <a href="<%# Eval("UrlFormat") %>">
                                                    <img class="card-img-top img-fluid" src="<%# Eval("Avatar") %>" alt="<%# Eval("Name") %>"></a>
                                            </div>
                                            <div class="product-item-body">
                                                <div class="product-item-action">
                                                    <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm"  data-cmd="AddToCart" data-id="<%# Eval("ProductId") %>"><i class="icofont icofont-shopping-cart"></i></a>
                                                    <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%# Eval("UrlFormat") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                                </div>
                                                <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>"><%# Eval("Name") %></a></p>
                                                <p>
                                                    <span class="product-desc-price"><%# Eval("PriceOld","{0:0,0}") %></span>
                                                    <span class="product-price"><%# Eval("PriceSale","{0:0,0}") %></span>
                                                    <%--<span class="product-discount">30% Off</span>--%>
                                                </p>
                                            </div>
                                            <div class="product-item-footer">
                                                <div class="product-item-size">
                                                    <strong>Colors: </strong><span>ONE COLOR</span>
                                                </div>
                                                <div class="stars-rating">
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star active"></i>
                                                    <i class="icofont icofont-star"></i><%--<span>(415)</span>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="hot-offers text-center pt-0 pb-0">
    <h6 class="sr-only">Services List</h6>
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <a href="">
                    <img src="/Projects/Web/Resources/images/banner.jpg" alt="">
                </a>
            </div>
        </div>
    </div>
</section>
<section class="deals-of-the-day">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Sản phẩm hot
                  <span class="pull-right" id="countdown"></span>
            </h5>
        </div>
        <div class="row">
            <asp:Repeater runat="server" ID="rpHots">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-3 col-sm-6">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-danger offer-badge">HOT</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%# Eval("UrlFormat") %>">
                                        <img class="card-img-top img-fluid" src="<%# Eval("Avatar") %>" alt="<%# Eval("Name") %>"></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm"  data-cmd="AddToCart" data-id="<%# Eval("ProductId") %>"><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%# Eval("UrlFormat") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>"><%# Eval("Name") %></a></p>
                                    <p>
                                        <span class="product-desc-price"><%# Eval("PriceOld","{0:0,0}") %></span>
                                        <span class="product-price"><%# Eval("PriceSale","{0:0,0}") %></span>
                                        <%--<span class="product-discount">30% Off</span>--%>
                                    </p>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Colors: </strong><span>ONE COLOR</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star"></i><%--<span>(415)</span>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</section>

<uc1:Top_Brands runat="server" ID="Top_Brands" />
