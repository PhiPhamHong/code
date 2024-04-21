<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Products.ascx.cs" Inherits="Core.FE.Sites.Shop.Clothers.Projects.Web.Pages.Products" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href=""><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                    <li class="breadcrumb-item active">Danh sách sản phẩm</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="products_page">
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-4">
                <div class="widget">
                    <div class="category_sidebar">
                        <aside class="sidebar_widget">
                            <div class="widget_title">
                                <h5 class="heading-design-h5"><i class="icofont icofont-filter"></i>Category</h5>
                            </div>
                            <div id="accordion" role="tablist" aria-multiselectable="true">
                                <div class="card">
                                    <div class="card-header" role="tab" id="headingOne">
                                        <h5 class="mb-0">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Women
                           <span><i class="fa fa-plus-square-o"></i></span>
                                            </a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="collapse show" role="tabpanel" aria-labelledby="headingOne">
                                        <div class="card-block">
                                            <ul class="trends">
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Footwear <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Fashion Jewellery <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Bags &amp; Luggage <span class="badge badge-success">SALE</span><span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input" checked>
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Clothing <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Accessories <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Watches <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li><a href=""><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header" role="tab" id="headingTwo">
                                        <h5 class="mb-0">
                                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Men
                           <span><i class="fa fa-plus-square-o"></i></span>
                                            </a>
                                        </h5>
                                    </div>
                                    <div id="collapseTwo" class="collapse" role="tabpanel" aria-labelledby="headingTwo">
                                        <div class="card-block">
                                            <ul class="trends">
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Clothing <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Accessories <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Watches <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Footwear <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Fashion Jewellery <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Bags &amp; Luggage <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li><a href=""><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header" role="tab" id="headingThree">
                                        <h5 class="mb-0">
                                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">Kids
                           <span><i class="fa fa-plus-square-o"></i></span>
                                            </a>
                                        </h5>
                                    </div>
                                    <div id="collapseThree" class="collapse" role="tabpanel" aria-labelledby="headingThree">
                                        <div class="card-block">
                                            <ul class="trends">
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Footwear <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Fashion Jewellery <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Bags &amp; Luggage <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Clothing <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Accessories <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Watches <span class="item-numbers">155</span></span>
                                                    </label>
                                                </li>
                                                <li><a href=""><strong>Show More </strong><i class="icofont icofont-bubble-right"></i></a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </aside>
                        <hr>
                        <aside class="sidebar_widget">
                            <div class="widget_title">
                                <h5 class="heading-design-h5">Brand</h5>
                            </div>
                            <div class="card">
                                <div class="collapse show">
                                    <div class="card-block">
                                        <ul class="trends">
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Roadster <span class="item-numbers">569</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input" checked>
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">John Players <span class="item-numbers">2911</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Tommy Hilfiger <span class="item-numbers">2593</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Puma <span class="item-numbers">999</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Nike <span class="badge badge-warning">50% OFF</span> <span class="item-numbers">3000</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Watches <span class="item-numbers">Jack & Jones</span></span>
                                                </label>
                                            </li>
                                            <li><a href=""><strong>+ 923 more </strong><i class="icofont icofont-bubble-right"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                        </aside>
                        <hr>
                        <aside class="sidebar_widget">
                            <div class="widget_title">
                                <h5 class="heading-design-h5">Price</h5>
                            </div>
                            <div class="card">
                                <div class="collapse show">
                                    <div class="card-block">
                                        <ul class="trends">
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">$68 to $659 <span class="item-numbers">365548</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input" checked>
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">$660 to $1014 <span class="item-numbers">3658</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">$1015 to $1679 <span class="item-numbers">7845</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">$1680 to $1856 <span class="item-numbers">6548</span></span>
                                                </label>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                        </aside>
                        <hr>
                        <aside class="sidebar_widget">
                            <div class="widget_title">
                                <h5 class="heading-design-h5">Colour</h5>
                            </div>
                            <div class="card">
                                <div class="collapse show">
                                    <div class="card-block">
                                        <ul class="osahan-select-color">
                                            <li><a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-blue" href="" data-original-title="Blue"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-black" href="" data-original-title="Black"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-white" href="" data-original-title="white"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-grey" href="" data-original-title="Grey"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-navy" href="" data-original-title="Navy"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-red" href="" data-original-title="Red"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-beige" href="" data-original-title="Beige"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-maroon" href="" data-original-title="Maroon"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-pink" href="" data-original-title="Pink"></a>
                                                <a data-toggle="tooltip" data-placement="top" title="" class="color-bg bg-yellow" href="" data-original-title="Yellow"></a>
                                                <a title="" href="">+ 37 more</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                        </aside>
                        <hr>
                        <aside class="sidebar_widget">
                            <div class="widget_title">
                                <h5 class="heading-design-h5">Size</h5>
                            </div>
                            <div class="card">
                                <div class="collapse show">
                                    <div class="card-block">
                                        <ul class="trends">
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input" checked>
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">X - Small <span class="item-numbers">203</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Small <span class="item-numbers">16</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Medium <span class="item-numbers">84</span></span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Large <span class="item-numbers">95</span></span>
                                                </label>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                        </aside>
                        <hr>
                        <aside class="sidebar_widget">
                            <div class="widget_title">
                                <h5 class="heading-design-h5">Discount</h5>
                            </div>
                            <div class="card">
                                <div class="collapse show">
                                    <div class="card-block">
                                        <ul class="trends">
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input" checked>
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">80% and above</span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">70% and above</span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">60% and above</span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">50% and above</span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">40% and above</span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">30% and above</span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">20% and above</span>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="custom-control custom-radio">
                                                    <input id="radio1" name="radio" type="radio" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">10% and above</span>
                                                </label>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                        </aside>
                    </div>
                </div>
                <hr>
                <a href="<%= Url("Products") %>">
                    <img class="rounded" src="/Projects/Web/Resources/images/women-top.png" alt="Bannar 1">
                </a>
            </div>
            <div class="col-lg-9 col-md-8">
                <div class="osahan-inner-slider" data-control-load="innerSlider">
                    <div class="owl-carousel owl-carousel-slider">
                        <div class="item">
                            <a href="">
                                <img class="d-block img-fluid" src="/Projects/Web/Resources/images/grid-slider/slider1.jpg" alt="First slide"></a>
                        </div>
                        <div class="item">
                            <a href="">
                                <img class="d-block img-fluid" src="/Projects/Web/Resources/images/grid-slider/slider2.jpg" alt="First slide"></a>
                        </div>
                        <div class="item">
                            <a href="">
                                <img class="d-block img-fluid" src="/Projects/Web/Resources/images/grid-slider/slider3.jpg" alt="First slide"></a>
                        </div>
                    </div>
                </div>
                <div class="osahan_products_top_filter row">
                    <div class="col-lg-6 col-md-6 tags-action">
                        <span>Clothing <a><i class="icofont icofont-close-line-circled"></i></a></span>
                        <span>John Players <a><i class="icofont icofont-close-line-circled"></i></a></span>
                        <span>X - Small <a><i class="icofont icofont-close-line-circled"></i></a></span>
                    </div>
                    <div class="col-lg-6 col-md-6 sort-by-btn pull-right">
                        <div class="view-mode pull-right">
                            <a class="active" href="<%= Url("Products") %>"><i class="fa fa-th-large"></i></a><a href="shop-list-left-sidebar.html"><i class="fa fa-th-list"></i></a>
                        </div>
                        <div class="dropdown pull-right">
                            <button class="btn btn-primary  dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="icofont icofont-filter"></i>Sort by 
                            </button>
                            <div class="dropdown-menu pull-right" aria-labelledby="dropdownMenuButton">
                                <a class="dropdown-item"><i class="fa fa-angle-right" aria-hidden="true"></i>Popularity </a>
                                <a class="dropdown-item"><i class="fa fa-angle-right" aria-hidden="true"></i>New </a>
                                <a class="dropdown-item"><i class="fa fa-angle-right" aria-hidden="true"></i>Discount </a>
                                <a class="dropdown-item"><i class="fa fa-angle-right" aria-hidden="true"></i>Price: Low to High </a>
                                <a class="dropdown-item"><i class="fa fa-angle-right" aria-hidden="true"></i>Price: High to Low </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row products_page_list">
                    <div class="clearfix"></div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    <div class="col-lg-3 col-md-6">
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
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
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
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    <div class="col-lg-12 col-md-12">
                        <div class="item">
                            <a href="">
                                <img src="/Projects/Web/Resources/images/offers/home1_bn1.png" alt="">
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
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
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    </div>
                    <div class="col-lg-3 col-md-6">
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
                    <div class="col-lg-3 col-md-6">
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
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="" data-original-title="Add To Cart"><i class="icofont icofont-shopping-cart"></i></a>
                                            <a data-toggle="tooltip" data-placement="top" title="" class="btn btn-theme-round btn-sm" href="<%= Url("ProductDetails") %>" data-original-title="View Detail"><i class="icofont icofont-search-alt-2"></i></a>
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
                    </div>
                </div>
                <nav aria-label="Page navigation example">
                    <ul class="pagination justify-content-center">
                        <li class="page-item disabled"><a class="page-link" href=""><i class="fa fa-angle-left" aria-hidden="true"></i></a></li>
                        <li class="page-item active"><a class="page-link" href="">1</a></li>
                        <li class="page-item"><a class="page-link" href="">2</a></li>
                        <li class="page-item"><a class="page-link" href="">3</a></li>
                        <li class="page-item"><a class="page-link" href="">4</a></li>
                        <li class="page-item"><a class="page-link" href=""><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
