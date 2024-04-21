<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Controls.Header" %>
<%@ Register Src="~/Projects/Shops/Shop_Mobile/Modules/ProfileLink.ascx" TagPrefix="uc1" TagName="ProfileLink" %>

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
                                                <label>Enter Email/Mobile number</label>
                                                <input type="text" class="form-control" placeholder="+91 123 456 7890">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label>Enter Password</label>
                                                <input type="password" class="form-control" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <a href="<%= Url("Shop_Mobile_HasLogin") %>">
                                                    <button type="submit" class="btn btn-lg btn-theme-round btn-block">Enter to your account</button>
                                                </a>

                                            </fieldset>
                                            <div class="login-with-sites text-center">
                                                <p>or Login with your social profile:</p>
                                                <button class="btn-facebook login-icons btn-lg"><i class="fab fa-facebook"></i>Facebook</button>
                                                <button class="btn-google login-icons btn-lg"><i class="fab fa-google"></i>Google</button>
                                                <button class="btn-twitter login-icons btn-lg"><i class="fab fa-twitter"></i>Twitter</button>
                                            </div>
                                            <p>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Remember me </span>
                                                </label>
                                            </p>
                                        </div>
                                        <div class="tab-pane" id="register" role="tabpanel">
                                            <h5 class="heading-design-h5">Register Now!</h5>
                                            <fieldset class="form-group">
                                                <label>Enter Email/Mobile number</label>
                                                <input type="text" class="form-control" placeholder="+91 123 456 7890">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label>Enter Password</label>
                                                <input type="password" class="form-control" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label for="formGroupExampleInput3">Enter Confirm Password </label>
                                                <input type="password" class="form-control" id="formGroupExampleInput3" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <a href="<%= Url("Shop_Mobile_HasLogin") %>">
                                                    <button type="submit" class="btn btn-lg btn-theme-round btn-block">Create Your Account</button>
                                                </a>

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
                                                <a class="nav-link active" data-toggle="tab" href="#login" role="tab"><i class="icofont icofont-lock"></i>LOGIN</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#register" role="tab"><i class="icofont icofont-pencil-alt-5"></i>REGISTER</a>
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
<div class="navbar-top navbar-top-2">
    <div class="container">
        <div class="row">
            <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-left">
                <p>
                    SALE - Get Min <strong><span class="text-danger">40-80%</span> </strong>off!  
                </p>
            </div>
            <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-right">
                <ul class="list-inline">
                    <li class="list-inline-item">
                        <a href=""><i class="icofont icofont-iphone"></i>+1-123-456-7890</a>
                    </li>
                    <li class="list-inline-item">
                        <a href=""><i class="icofont icofont-headphone-alt"></i>Contact Us</a>
                    </li>
                    <li class="list-inline-item">
                        <span>Download App</span> &nbsp;
                   <a href=""><i class="icofont icofont-brand-windows"></i></a>
                        <a href=""><i class="icofont icofont-brand-apple"></i></a>
                        <a href=""><i class="icofont icofont-brand-android-robot"></i></a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<nav class="navbar navbar-light navbar-expand-lg bg-primary bg-faded osahan-menu osahan-menu-top-2">
    <div class="container">
        <a class="navbar-brand" href="<%= Url("Shop_Mobile") %>">
            <img src="/Projects/Shops/Shop_Mobile/Resources/images/logo-white.png" alt="logo">
        </a>
        <button class="navbar-toggler navbar-toggler-white" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse" id="navbarNavDropdown">
            <div class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto top-categories-search-main">
                <div class="top-categories-search">
                    <div class="input-group">
                        <span class="input-group-btn categories-dropdown">
                            <select class="form-control">
                                <option selected="selected">All Categories</option>
                                <optgroup label="Android">
                                    <option value="0">Samsung</option>
                                    <option value="2">Micromax</option>
                                    <option value="3">Lenovo</option>
                                    <option value="4">Vivo</option>
                                </optgroup>
                                <optgroup label="iOS">
                                    <option value="5">Apple </option>
                                </optgroup>
                            </select>
                        </span>
                        <input class="form-control" placeholder="Search products & brands" aria-label="Search products & brands" type="text">
                        <span class="input-group-btn">
                            <button class="btn btn-warning" type="button"><i class="icofont icofont-search-alt-2"></i>Search</button>
                        </span>
                    </div>
                </div>
            </div>
            <div class="my-2 my-lg-0">
                <ul class="list-inline main-nav-right">
                    <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-outline-light dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="icofont icofont-shopping-cart"></i>Cart <small class="cart-value">02</small>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right cart-dropdown">
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Mobile_Shopping_cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/small/1.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : Red | Model: Grand s2</small>
                                    <span class="product-desc-price">$529.99</span>
                                    <span class="product-price text-danger">$329.99</span>
                                </a>
                            </div>
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Mobile_Shopping_cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/small/3.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : Black | Model: Grand S</small>
                                    <span class="product-desc-price">$82.99</span>
                                    <span class="product-price text-danger">$36.99</span>
                                </a>
                            </div>
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Mobile_Shopping_cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/small/2.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : white | Model: Grand s2</small>
                                    <span class="product-desc-price">$29.99</span>
                                    <span class="product-price text-danger">$20.99</span>
                                </a>
                            </div>
                            <div class="dropdown-divider"></div>
                            <div class="dropdown-cart-footer text-center">
                                <h4><strong>Subtotal</strong>: $210 </h4>
                                <a class="btn btn-sm btn-danger" href="<%= Url("Shop_Mobile_Cartcheckout") %>"><i class="icofont icofont-shopping-cart"></i>VIEW
                         CART </a><a href="<%= Url("Shop_Mobile_Cartcheckout") %>" class="btn btn-sm btn-primary">CHECKOUT </a>
                            </div>
                        </div>
                    </li>

                    
                    <%if (IsLogin) %>
                    <%{ %>
                    <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-outline-light dropdown-toggle dropdown-toggle dropdown-toggle-top-user" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <img src="/Projects/Shops/Shop_Mobile/Resources/images/user-ava.jpg" alt="alt text">
                            <strong>Hi</strong> Osahan
                        </a>
                        <uc1:ProfileLink runat="server" id="ProfileLink" />
                    </li>
                    <%} %>
                    <%else %>
                    <%{ %>
                    <li class="list-inline-item">
                        <a class="btn btn-theme-round" data-toggle="modal" data-target="#bd-example-modal" href=""><i class="icofont icofont-ui-user"></i><b>Đăng nhập</b> </a>
                    </li>
                    <%} %>
                </ul>
            </div>
        </div>
    </div>
</nav>
<nav class="navbar navbar-expand-lg navbar-light bg-light osahan-menu osahan-menu-2 pad-none-mobile">
    <div class="container">
        <div class="collapse navbar-collapse" id="navbarText">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                <li class="nav-item dropdown mega-dropdown-main active">
                    <a class="nav-link dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="icofont icofont-ui-home"></i>Home <span class="sr-only">(current)</span>
                    </a>
                    <div class="dropdown-menu mega-dropdown" style="width:50%">
                        <div class="row">
                            <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6">
                                <div class="mega-dropdown-pages">
                                    <a href="<%= Url("Shop_Mobile_HasLogin") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/index1.jpg" alt="Home with Login"></a>
                                    <a class="icon-round-btn" href="<%= Url("Shop_Mobile_HasLogin") %>">
                                        <i class="icofont icofont-thin-right"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6">
                                <div class="mega-dropdown-pages">
                                    <a href="<%= Url("Shop_Mobile") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/index2.jpg" alt="Home without login"></a>
                                    <a class="icon-round-btn" href="<%= Url("Shop_Mobile") %>">
                                        <i class="icofont icofont-thin-right"></i>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="sale-nav nav-item dropdown mega-dropdown-main">
                    <a class="nav-link dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Products
                    </a>
                    <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                                <span class="mega-menu-img hidden-sm"><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                    <img src="/Projects/Shops/Shop_Mobile/Resources/images/offers/menu2-top.png" alt="Bannar 1"></a> </span>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">All Mobile Phones <span class="badge badge-primary">NEW</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name <span class="badge badge-secondary">20%</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">Smart phones <span class="badge badge-success">SALE</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">Android Mobiles <span class="badge badge-default">HOT</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name <span class="badge badge-success">5%</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">Windows Mobiles </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name <span class="badge badge-light">25%</span> </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">Refurbished Mobiles  <span class="badge badge-danger">60%</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name <span class="badge badge-dark">10%</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">All Mobile Accessories <span class="badge badge-warning">50% OFF</span> </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Brand name <span class="badge badge-info">HOT</span></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="nav-item dropdown mega-dropdown-main">
                    <a class="nav-link dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Brands
                    </a>
                    <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list brands-icon-top">
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">Smart phones Brands <span class="badge badge-info">10% OFF</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/1.png" alt="Brand">
                                        Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/2.png" alt="Brand">
                                        Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/3.png" alt="Brand">
                                        Brand name </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/4.png" alt="Brand">
                                        Brand name </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list brands-icon-top">
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">Android Mobiles Brands <span class="badge badge-danger">HOT</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/5.png" alt="Brand">
                                        Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/6.png" alt="Brand">
                                        Brand name</a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/7.png" alt="Brand">
                                        Brand name <span class="badge badge-primary">5% OFF</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/8.png" alt="Brand">
                                        Brand name </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list brands-icon-top">
                                    <a class="mega-title" href="<%= Url("Shop_Mobile_Category") %>">Windows Mobiles Brands </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/9.png" alt="Brand">
                                        Brand name <span class="badge badge-dark">10%</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/10.png" alt="Brand">
                                        Brand name <span class="badge badge-warning">NEW</span></a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/11.png" alt="Brand">
                                        Brand name </a>
                                    <a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                        <img src="/Projects/Shops/Shop_Mobile/Resources/images/brands/12.png" alt="Brand">
                                        Brand name </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                                <span class="mega-menu-img hidden-sm"><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                    <img src="/Projects/Shops/Shop_Mobile/Resources/images/offers/kids-top.png" alt="Bannar 1"></a> </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Products</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">Items</a>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Blog
                    </a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="<%= Url("Shop_Mobile_Blog_left") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Blogs </a>
                        <a class="dropdown-item" href="<%= Url("Shop_Mobile_Blog_single") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Blog detail </a>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Mobile_Contact") %>">Contact</a>
                </li>
            </ul>
            <span class="navbar-text">Worlds's Fastest <b class="text-primary">Online Shopping</b> Destination</span>
        </div>
    </div>
</nav>
