<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FE.MobileShop.Controls.Header" %>
<%@ Register Src="~/Projects/Web/Modules/ProfileLink.ascx" TagPrefix="uc1" TagName="ProfileLink" %>
<%@ Register Src="~/Projects/Web/Modules/Cart/CartHeader.ascx" TagPrefix="uc1" TagName="CartHeader" %>


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

                                <div class="login-modal-right">
                                    <!-- Tab panes -->
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="login" role="tabpanel">
                                            <h5 class="heading-design-h5">Đăng nhập vào tài khoản của bạn</h5>
                                            <fieldset class="form-group">
                                                <label>Tài khoản </label>
                                                <input type="text" class="form-control" placeholder="Nhập tài khoản" id="username">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label>Nhập mật khẩu</label>
                                                <input type="password" class="form-control" placeholder="********" id="password">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <a href="">
                                                    <button data-cmd="Login" class="btn btn-lg btn-theme-round btn-block">Đăng nhập</button>
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
                                            <h5 class="heading-design-h5">ĐĂNG KÝ NGAY!</h5>
                                            <h5 class="heading-design-h6">Thông tin chung</h5>
                                            <fieldset class="form-group">
                                                <label>Tên của bạn</label>
                                                <input type="text" class="form-control" placeholder="Nhập tên bạn" id="resname">
                                            </fieldset>

                                            <fieldset class="form-group">
                                                <label>Địa chỉ</label>
                                                <input type="text" class="form-control" placeholder="Nhập địa chỉ" id="resaddress">
                                            </fieldset>

                                            <fieldset class="form-group">
                                                <label>SĐT</label>
                                                <input type="text" class="form-control" placeholder="+91 123 456 7890" id="resphone">
                                            </fieldset>

                                            <fieldset class="form-group">
                                                <label>Email</label>
                                                <input type="text" class="form-control" placeholder="ANV@gmail.com" id="resmail">
                                            </fieldset>

                                            <h5 class="heading-design-h6">Thông tin tài khoản</h5>

                                            <fieldset class="form-group">
                                                <label>Tên tài khoản</label>
                                                <input type="text" class="form-control" placeholder="Nhập tài khoản" id="resusername">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label>Mật khẩu</label>
                                                <input type="password" class="form-control" placeholder="********" id="respassword">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <label for="formGroupExampleInput3"> Nhập lại mật khẩu </label>
                                                <input type="password" class="form-control" id="resconfirm" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <a href="">
                                                    <button data-cmd="Register" class="btn btn-lg btn-theme-round btn-block"> ĐĂNG KÝ </button>
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
                    SALE - Min <strong><span class="text-danger">40-80%</span> </strong>off!  
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
            <img src="/Projects/Web/Resources/images/logo.png" alt="logo">
        </a>
        <button class="navbar-toggler navbar-toggler-white" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse" id="navbarNavDropdown">
            <div class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto top-categories-search-main">
                <div class="top-categories-search">
                    <div class="input-group" id="FromTim">
                        <span class="input-group-btn categories-dropdown">
                            <select class="form-control">
                                <option selected="selected">Tất cả </option>
                                <optgroup label="Window">
                                    <option value="0">DELL</option>
                                    <option value="2">HP</option>
                                    <option value="3">Lenovo</option>
                                    <option value="4">ASUS</option>
                                </optgroup>
                                <optgroup label="MacOS">
                                    <option value="5">MACBOOK </option>
                                </optgroup>
                            </select>
                        </span>
                        <input class="form-control" id="Input" placeholder="Tìm kiểm theo sản phẩm hoặc nhãn hàng" aria-label="Search products & brands" type="text">
                        <span class="input-group-btn">
                            <button class="btn btn-warning" data-cmd="clickTimkiem" type="button"><i class="icofont icofont-search-alt-2"></i>Tìm kiếm</button>
                        </span>
                    </div>
                </div>
            </div>
            <div class="my-2 my-lg-0">
                <ul class="list-inline main-nav-right">

                    <li class="list-inline-item dropdown osahan-top-dropdown" id="Cartheader">
                        <uc1:CartHeader runat="server" ID="CartHeader" />
                    </li>



                    <%if (IsLogin) %>
                    <%{ %>
                    <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-outline-light dropdown-toggle dropdown-toggle dropdown-toggle-top-user" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <img src="/Projects/Web/Resources/images/apple-icon.png" alt="alt text">
                            <strong>Hello </strong> <%= HttpContext.Current.Session["UserName"].ToString() %>
                        </a>
                        <uc1:ProfileLink runat="server" ID="ProfileLink" />
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
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Mobile") %>">Trang chủ</a>
                </li>
                <li class="sale-nav nav-item dropdown mega-dropdown-main">
                    <a class="nav-link dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Sản phẩm
                    </a>
                    <div class="dropdown-menu mega-dropdown">
                        <div class="row">
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3 mega-dropdown-ads">
                                <span class="mega-menu-img hidden-sm"><a href="<%= Url("Shop_Mobile_Grid_left_sidebar") %>">
                                    <img src="<%= Data.Avatar %>" alt="Bannar 1"></a> </span>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="/latop-moi-chinh-hang">LAPTOP MỚI CHÍNH HÃNG <span class="badge badge-default">HOT</span></a>
                                    <a href="/hangmaytinh=asus">ASUS </a>
                                    <a href="/hangmaytinh=dell">DELL </a>
                                    <a href="/hangmaytinh=lenovo">LENOVO <span class="badge badge-success">5%</span></a>
                                    <a href="//hangmaytinh=hp"> HP </a>
                                    <a href="//hangmaytinh=macbook"> MACBOOK <span class="badge badge-light">25%</span> </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="/latop-cu-chinh-hang">LAPTOP CŨ CHÍNH HÃNG <span class="badge badge-default">HOT</span></a>
                                    <a href="/hangmaytinh=asus">ASUS </a>
                                    <a href="/hangmaytinh=dell">DELL </a>
                                    <a href="/hangmaytinh=lenovo">LENOVO <span class="badge badge-success">5%</span></a>
                                    <a href="//hangmaytinh=hp"> HP </a>
                                    <a href="//hangmaytinh=macbook"> MACBOOK <span class="badge badge-light">25%</span> </a>
                                </div>
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3 col-md-3">
                                <div class="mega-list">
                                    <a class="mega-title" href="/latop-theo-nhu-cau">LAPTOP THEO NHU CẦU <span class="badge badge-default">HOT</span></a>
                                    <a href="/hangmaytinh=asus">ASUS </a>
                                    <a href="/hangmaytinh=dell">DELL </a>
                                    <a href="/hangmaytinh=lenovo">LENOVO <span class="badge badge-success">5%</span></a>
                                    <a href="//hangmaytinh=hp"> HP </a>
                                    <a href="//hangmaytinh=macbook"> MACBOOK <span class="badge badge-light">25%</span> </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Mobile_About") %>">Nhãn hàng</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Mobile_About") %>">Giới thiệu</a>
                </li>

                <li class="nav-item">
                    <%--<a class="nav-link" href="<%= Url("Shop_Mobile_Blog_left") %>">Tin tức</a>--%>
                    <a class="nav-link" href="">Tin tức</a>
                </li>

                <%--<li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Tin tức
                    </a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="<%= Url("Shop_Mobile_Blog_left") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Blogs </a>
                        <a class="dropdown-item" href="<%= Url("Shop_Mobile_Blog_single") %>"><i class="fa fa-angle-right" aria-hidden="true"></i>Blog detail </a>
                    </div>
                </li>--%>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Mobile_Contact") %>">Liên hệ</a>
                </li>
            </ul>
            <span class="navbar-text">Worlds's Fastest <b class="text-primary">Online Shopping</b> Destination</span>
        </div>
    </div>
</nav>
