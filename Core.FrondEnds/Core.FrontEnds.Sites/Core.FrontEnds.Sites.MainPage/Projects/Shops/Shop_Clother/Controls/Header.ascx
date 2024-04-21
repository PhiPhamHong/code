<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother.Controls.Header" %>
<%--<div class="my-2 my-lg-0">
    <ul class="list-inline main-nav-right">
        <li class="list-inline-item dropdown osahan-top-dropdown">
            <a class="btn btn-theme-round dropdown-toggle dropdown-toggle-top-user" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <img src="/Projects/Shops/Shop_Clother/Resources/images/user-ava.jpg">
                <strong>Hi</strong> Osahan
            </a>
            <div class="dropdown-menu dropdown-menu-right dropdown-list-design">
                <a class="dropdown-item" href="my-profile.html"><i class="icofont icofont-ui-user"></i>My Profile</a>
                <a class="dropdown-item" href="my-address.html"><i class="icofont icofont-location-pin"></i>My Address</a>
                <a class="dropdown-item" href="wishlist-user.html"><i class="icofont icofont-heart-alt"></i>Wish List <span class="badge badge-success">6</span></a>
                <a class="dropdown-item" href="order-list.html"><i class="icofont icofont-list"></i>Order List</a>
                <a class="dropdown-item" href="order-status.html"><i class="icofont icofont-truck-loaded"></i>Order Status</a>
                <a class="dropdown-item" href="invoice.html"><i class="icofont icofont-paper"></i>Invoice A4</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="login.html"><i class="icofont icofont-logout"></i>Logout</a>
            </div>
        </li>
    </ul>
</div>--%>




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
                                <span class="sr-only">Đóng</span>
                            </button>
                            <form>
                                <div class="login-modal-right">
                                    <!-- Tab panes -->
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="login" role="tabpanel">
                                            <h5 class="heading-design-h5">Đăng nhập tài khoản của bạn</h5>
                                            <fieldset class="form-group">
                                                <label for="formGroupExampleInput">Nhập email/Sđt</label>
                                                <input type="text" class="form-control" placeholder="+91 123 456 7890">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label for="formGroupExampleInput2">Nhập mật khẩu</label>
                                                <input type="password" class="form-control" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <a href="<%= Url("Shop_Clother_HomeLogin") %>">
                                                    <button type="submit" class="btn btn-lg btn-theme-round btn-block">Đăng nhập</button>
                                                </a>

                                            </fieldset>
                                            <div class="login-with-sites text-center">
                                                <p>Hoặc đăng nhập với mạng xã hội</p>
                                                <button class="btn-facebook login-icons btn-lg"><i class="fa fa-facebook"></i>Facebook</button>
                                                <button class="btn-google login-icons btn-lg"><i class="fa fa-google"></i>Google</button>
                                                <button class="btn-twitter login-icons btn-lg"><i class="fa fa-twitter"></i>Twitter</button>
                                            </div>
                                            <p>
                                                <p>
                                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                        <input type="checkbox" class="custom-control-input">
                                                        <span class="custom-control-indicator"></span>
                                                        <span class="custom-control-description">Nhớ mật khẩu </span>
                                                    </label>
                                                </p>
                                            </p>
                                        </div>
                                        <div class="tab-pane" id="register" role="tabpanel">
                                            <h5 class="heading-design-h5">Đăng ký ngay!</h5>
                                            <fieldset class="form-group">
                                                <label for="formGroupExampleInput">Nhập email/Sđt</label>
                                                <input type="text" class="form-control" id="formGroupExampleInput" placeholder="+91 123 456 7890">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label for="formGroupExampleInput2">Nhập mật khẩu</label>
                                                <input type="password" class="form-control" id="formGroupExampleInput2" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label for="formGroupExampleInput3">Nhập lại mật khẩu </label>
                                                <input type="password" class="form-control" id="formGroupExampleInput3" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <a href="<%= Url("Shop_Clother_HomeLogin") %>"> 
                                                    <button type="submit" class="btn btn-lg btn-theme-round btn-block">Tạo tài khoản</button>
                                                </a>
                                                
                                            </fieldset>
                                            <p>
                                                <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                                    <input type="checkbox" class="custom-control-input">
                                                    <span class="custom-control-indicator"></span>
                                                    <span class="custom-control-description">Tôi đồng ý với các chính sách và điều khoản</span>
                                                </label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="text-center login-footer-tab">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link active" data-toggle="tab" href="#login" role="tab"><i class="icofont icofont-lock"></i>Đăng nhập</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#register" role="tab"><i class="icofont icofont-pencil-alt-5"></i>Đăng ký</a>
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
                    Giảm giá sốc từ: <span class="text-danger">40 - 80%</span> siêu hot! 
                </p>
            </div>
            <div class="col-lg-6 col-sm-6 col-xs-6 col-md-6 text-right">
                <ul class="list-inline">
                    <li class="list-inline-item">
                        <a href=""><i class="icofont icofont-iphone"></i>+1-123-456-7890</a>
                    </li>
                    <li class="list-inline-item">
                        <a href=""><i class="icofont icofont-headphone-alt"></i>Liên hệ</a>
                    </li>
                    <li class="list-inline-item">
                        <span>Tải App</span> &nbsp;
                        <a href=""><i class="icofont icofont-brand-windows"></i></a>
                        <a href=""><i class="icofont icofont-brand-apple"></i></a>
                        <a href=""><i class="icofont icofont-brand-android-robot"></i></a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<nav class="navbar navbar-expand-lg navbar-light bg-faded osahan-menu">
    <div class="container">
        <a class="navbar-brand" href="<%= Url("Shop_Clother") %>">
            <img src="/Projects/Shops/Shop_Clother/Resources/images/logo.png" alt="logo">
        </a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavDropdown" data-control-load="loadDropdown">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto">
                <li class="nav-item dropdown active">
                    <a class="nav-link" href="<%= Url("Shop_Clother") %>">
                        <i class="icofont icofont-ui-home"></i>Trang chủ 
                    </a>
                </li>
                <li class="nav-item dropdown mega-dropdown-main">
                    <a class="nav-link dropdown-toggle" href="<%= Url("Shop_Clother_Categories") %>" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Đồ nam
                    </a>
                    <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Quần áo <span class="badge badge-danger">HOT</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Áo sơ mi</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Quần</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Vét & quần âu<span class="badge badge-warning">20%</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Đồ thể thao </a>
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Kính mắt </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Kính dâm</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Kính áp tròng <span class="badge badge-info">NEW</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Kính trắng </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Kính UV</a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Trang sức <span class="badge badge-secondary">50%</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Vàng</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Bạch kim</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Nhẫn </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Vòng tay </a>
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Đồng hồ <span class="badge badge-primary">25% OFF</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Fastrack </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Timex </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Citizen</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Titan <span class="badge badge-light">60%</span></a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Giày <span class="badge badge-success">SALE</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Thể thao</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Mocassins</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sneakers </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Formal Shoes </a>
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Phụ kiện </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Túi xách <span class="badge badge-dark">NEW</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Kính chống nắng</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Clutches </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Ba lô </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                                <span class="mega-menu-img hidden-sm"><a href="<%= Url("Shop_Clother_Categories") %>">
                                    <img src="/Projects/Shops/Shop_Clother/Resources/images/offers/men-top.png" alt="Bannar 1"></a> </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="sale-nav nav-item dropdown mega-dropdown-main">
                    <a class="nav-link dropdown-toggle" href="<%= Url("Shop_Clother_Categories") %>" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Đồ nữ
                    </a>
                    <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                                <span class="mega-menu-img hidden-sm"><a href="<%= Url("Shop_Clother_Categories") %>">
                                    <img src="/Projects/Shops/Shop_Clother/Resources/images/offers/women-top.png" alt="Bannar 1"></a> </span>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Kính mắt <span class="badge badge-primary">NEW</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Ba lô</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Ray-Ban</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Opium <span class="badge badge-secondary">20%</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Joe Black </a>
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Clothing <span class="badge badge-success">SALE</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Casual shirt</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Trousers</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Suits & Blazers </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sportswear </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Watches <span class="badge badge-default">HOT</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Fastrack </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Timex </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Citizen <span class="badge badge-success">5%</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Titan </a>
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Jewellery </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Gold</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Platinum</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Rings </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Neckwear <span class="badge badge-light">25%</span> </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="">Shoes  <span class="badge badge-danger">60%</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sports & Outdoor</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Mocassins</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sneakers <span class="badge badge-dark">10%</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Formal Shoes </a>
                                    <a class="mega-title" href="">Accessories <span class="badge badge-warning">50% OFF</span> </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Handbags</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sunglasses</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Clutches </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Backpacks <span class="badge badge-info">HOT</span></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="nav-item dropdown mega-dropdown-main">
                    <a class="nav-link dropdown-toggle" href="<%= Url("Shop_Clother_Categories") %>" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Trẻ em
                    </a>
                    <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Baby clothing <span class="badge badge-info">10% OFF</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Casual shirt</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Trousers</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Suits & Blazers </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sportswear </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Boys <span class="badge badge-danger">HOT</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Clothing</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Shoes</a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Watches <span class="badge badge-primary">5% OFF</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sunglasses </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="<%= Url("Shop_Clother_Categories") %>">Girls </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Baby Girl <span class="badge badge-dark">10%</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Shoes <span class="badge badge-warning">NEW</span></a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Watches </a>
                                    <a href="<%= Url("Shop_Clother_Products") %>">Sunglasses </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                                <span class="mega-menu-img hidden-sm"><a href="<%= Url("Shop_Clother_Products") %>">
                                    <img src="/Projects/Shops/Shop_Clother/Resources/images/offers/kids-top.png" alt="Bannar 1"></a> </span>
                            </div>
                        </div>
                    </div>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="<%= Url("Shop_Clother_News") %>" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Tin tức
                    </a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="<%= Url("Shop_Clother_NewDetail") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Cách nhận biết đồ thật </a>
                        <a class="dropdown-item" href="<%= Url("Shop_Clother_NewDetail") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Giới hạn mua hàng </a>
                        <a class="dropdown-item" href="<%= Url("Shop_Clother_NewDetail") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Mua nhẫn ở đâu giá rẻ? </a>
                        <a class="dropdown-item" href="<%= Url("Shop_Clother_NewDetail") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Thực hư nhẫn kim cương giá 10 tỷ </a>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Clother_FAQ") %>">Hỏi đáp</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Clother_Contact") %>">Liên hệ</a>
                </li>
            </ul>
            <% if (IsLogin == true) %>
            <%{ %>
            <div class="my-2 my-lg-0">
                <ul class="list-inline main-nav-right">
                    <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-theme-round dropdown-toggle dropdown-toggle-top-user" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <img src="/Projects/Shops/Shop_Clother/Resources/images/user-ava.jpg">
                            <strong>Hi</strong> Team
                        </a>
                        <div class="dropdown-menu dropdown-menu-right dropdown-list-design">
                            <a class="dropdown-item" href="<%= Url("Shop_Clother_Profile") %>"><i class="icofont icofont-ui-user"></i>My Profile</a>
                            <a class="dropdown-item" href="<%= Url("Shop_Clother_Address") %>"><i class="icofont icofont-location-pin"></i>My Address</a>
                            <a class="dropdown-item" href="<%= Url("Shop_Clother_WishList") %>"><i class="icofont icofont-heart-alt"></i>Wish List <span class="badge badge-success">6</span></a>
                            <a class="dropdown-item" href="<%= Url("Shop_Clother_OrderList") %>"><i class="icofont icofont-list"></i>Order List</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="<%= Url("Shop_Clother") %>"><i class="icofont icofont-logout"></i>Logout</a>
                        </div>
                    </li>
                    <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-theme-round dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="icofont icofont-shopping-cart"></i><b>Giỏ hàng</b> <small class="cart-value">03</small>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right cart-dropdown">
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Clother_Cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/1.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : Red | Size : M</small>
                                    <span class="product-desc-price">$529.99</span>
                                    <span class="product-price text-danger">$329.99</span>
                                </a>
                            </div>
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Clother_Cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/3.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : Black | Size : XL</small>
                                    <span class="product-desc-price">$82.99</span>
                                    <span class="product-price text-danger">$36.99</span>
                                </a>
                            </div>
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Clother_Cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/2.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : white | Size : L</small>
                                    <span class="product-desc-price">$29.99</span>
                                    <span class="product-price text-danger">$20.99</span>
                                </a>
                            </div>
                            <div class="dropdown-divider"></div>
                            <div class="dropdown-cart-footer text-center">
                                <h4><strong>Subtotal</strong>: $210 </h4>
                                <a class="btn btn-sm btn-primary" href="<%= Url("Shop_Clother_Cart") %>"><i class="icofont icofont-shopping-cart"></i>Đi tới giỏ hàng </a>
                            </div>
                        </div>
                    </li>
                </ul>

            </div>
            <%} %>
            <% else %>
            <%{ %>
            <div class="my-2 my-lg-0">
                <ul class="list-inline main-nav-right">
                    <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-theme-round dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="icofont icofont-shopping-cart"></i><b>Giỏ hàng</b> <small class="cart-value">03</small>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right cart-dropdown">
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Clother_Cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/1.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : Red | Size : M</small>
                                    <span class="product-desc-price">$529.99</span>
                                    <span class="product-price text-danger">$329.99</span>
                                </a>
                            </div>
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Clother_Cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/3.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : Black | Size : XL</small>
                                    <span class="product-desc-price">$82.99</span>
                                    <span class="product-price text-danger">$36.99</span>
                                </a>
                            </div>
                            <div class="dropdown-item">
                                <a class="pull-right" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove">
                                    <i class="fa fa-trash-o"></i>
                                </a>
                                <a href="<%= Url("Shop_Clother_Cart") %>">
                                    <img class="img-fluid" src="/Projects/Shops/Shop_Clother/Resources/images/all-products/small/2.jpg" alt="Product">
                                    <strong>Ipsums Dolors Untra </strong>
                                    <small>Color : white | Size : L</small>
                                    <span class="product-desc-price">$29.99</span>
                                    <span class="product-price text-danger">$20.99</span>
                                </a>
                            </div>
                            <div class="dropdown-divider"></div>
                            <div class="dropdown-cart-footer text-center">
                                <h4><strong>Subtotal</strong>: $210 </h4>
                                <a class="btn btn-sm btn-primary" href="<%= Url("Shop_Clother_Cart") %>"><i class="icofont icofont-shopping-cart"></i>Đi tới giỏ hàng </a>
                            </div>
                        </div>
                    </li>
                    <li class="list-inline-item">
                        <a class="btn btn-theme-round" data-toggle="modal" data-target="#bd-example-modal" href=""><i class="icofont icofont-ui-user"></i><b>Đăng nhập</b> </a>
                    </li>
                </ul>
            </div>
            <%} %>
        </div>
    </div>
</nav>
