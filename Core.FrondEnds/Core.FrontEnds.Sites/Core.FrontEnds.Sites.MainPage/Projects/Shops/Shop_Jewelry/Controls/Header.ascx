<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Jewelry.Controls.Header" %>



<div class="modal fade login-modal-main" id="bd-example-modal">
    <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
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
                                <span aria-hidden="true"><i class="mdi mdi-close"></i></span>
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
                                                <a href="<%= Url("Shop_Jewelry_HomeLogin") %>">
                                                    <button <%--type="submit"--%> class="btn btn-lg btn-secondary btn-block">Enter to your account</button>
                                                </a>
                                            </fieldset>
                                            <div class="login-with-sites text-center">
                                                <p>or Login with your social profile:</p>
                                                <button class="btn-facebook login-icons btn-lg"><i class="mdi mdi-facebook"></i>Facebook</button>
                                                <button class="btn-google login-icons btn-lg"><i class="mdi mdi-google"></i>Google</button>
                                                <button class="btn-twitter login-icons btn-lg"><i class="mdi mdi-twitter"></i>Twitter</button>
                                            </div>
                                            <div class="custom-control custom-checkbox">
                                                <input type="checkbox" class="custom-control-input" id="customCheck1">
                                                <label class="custom-control-label" for="customCheck1">Remember me</label>
                                            </div>
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
                                                <label>Enter Confirm Password </label>
                                                <input type="password" class="form-control" placeholder="********">
                                            </fieldset>
                                            <fieldset class="form-group">
                                                <a href="<%= Url("Shop_Jewelry_HomeLogin") %>">
                                                    <button <%--type="submit"--%> class="btn btn-lg btn-secondary btn-block">Create Your Account</button>
                                                </a>

                                            </fieldset>
                                            <div class="custom-control custom-checkbox">
                                                <input type="checkbox" class="custom-control-input" id="customCheck2">
                                                <label class="custom-control-label" for="customCheck2">I Agree with <a href="#">Term and Conditions</a></label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="text-center login-footer-tab">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link active" data-toggle="tab" href="#login" role="tab"><i class="mdi mdi-lock"></i>LOGIN</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#register" role="tab"><i class="mdi mdi-pencil"></i>REGISTER</a>
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
<nav class="navbar navbar-light navbar-expand-lg bg-white bg-faded osahan-menu">
    <div class="container">
        <a class="navbar-brand" href="<%= Url("Shop_Jewelry") %>">
            <img src="/Projects/Shops/Shop_Jewelry/Resources/img/logo.png" alt="logo">
        </a>
        <button class="navbar-toggler navbar-toggler-white" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse" id="navbarNavDropdown">
            <div class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto top-categories-search-main">
                <div class="top-categories-search">
                    <div class="input-group">
                        <input class="form-control" placeholder="Search for jewelery" aria-label="Search for jewelery" type="text">
                        <span class="input-group-btn">
                            <button class="btn btn-secondary" type="button"><i class="mdi mdi-file-find"></i>Search</button>
                        </span>
                    </div>
                </div>
            </div>
            <% if (IsLogin == true) %>
            <%{ %>
            <div class="my-2 my-lg-0">
                <ul class="list-inline main-nav-right">

                    <li class="list-inline-item dropdown osahan-top-dropdown">
                        <a class="btn btn-theme-round dropdown-toggle dropdown-toggle-top-user" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                            <img alt="logo" src="/Projects/Shops/Shop_Jewelry/Resources/img/user/1.jpg"><strong>Hi</strong> Osahan
                        </a>
                        <div class="dropdown-menu dropdown-menu-right dropdown-list-design">
                            <a href="<%= Url("Shop_Jewelry_Profile") %>" class="dropdown-item"><i aria-hidden="true" class="mdi mdi-account-outline"></i>My Profile</a>
                            <a href="<%= Url("Shop_Jewelry_Address") %>" class="dropdown-item"><i aria-hidden="true" class="mdi mdi-map-marker-circle"></i>My Address</a>
                            <a href="<%= Url("Shop_Jewelry_Wishlist") %>" class="dropdown-item"><i aria-hidden="true" class="mdi mdi-heart-outline"></i>Wish List </a>
                            <a href="<%= Url("Shop_Jewelry_Orderlist") %>" class="dropdown-item"><i aria-hidden="true" class="mdi mdi-format-list-bulleted"></i>Order List</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="<%= Url("Shop_Jewelry") %>"><i class="mdi mdi-lock"></i>Logout</a>
                        </div>
                    </li>
                    <li class="list-inline-item cart-btn">
                        <a href="#" data-toggle="offcanvas" class="btn btn-link"><i class="mdi mdi-cart"></i>My Cart <small class="cart-value">5</small></a>
                    </li>
                </ul>
            </div>
            <%} %>
            <% else %>
            <%{ %>
            <div class="my-2 my-lg-0">
                <ul class="list-inline main-nav-right">
                    <li class="list-inline-item">
                        <a href="#" data-target="#bd-example-modal" data-toggle="modal" class="btn btn-link border-left"><i class="mdi mdi-account-circle"></i>Login/Sign Up</a>
                    </li>

                    <li class="list-inline-item cart-btn">
                        <a href="#" data-toggle="offcanvas" class="btn btn-link"><i class="mdi mdi-cart"></i>My Cart <small class="cart-value">5</small></a>
                    </li>
                </ul>
            </div>
            <%} %>
        </div>
    </div>
</nav>
<nav class="navbar navbar-expand-lg navbar-light bg-dark osahan-menu-2 pad-none-mobile">
    <div class="container">
        <div class="collapse navbar-collapse" id="navbarText">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto">

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="<%= Url("Shop_Jewelry") %>" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <span class="mdi mdi-store"></span> Home </a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="<%= Url("Shop_Jewelry") %>"><i class="mdi mdi-chevron-right" aria-hidden="true"></i> <span class="mdi mdi-store"></span> Home no login </a>
                        <a class="dropdown-item" href="<%= Url("Shop_Jewelry_HomeLogin") %>"><i class="mdi mdi-chevron-right" aria-hidden="true"></i> <span class="mdi mdi-store"></span> Home with login </a>
                    </div>
                </li>

                <li class="nav-item">
                    <a class="nav-link shop" href="<%= Url("Shop_Jewelry") %>"><span class="mdi mdi-store"></span>Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Jewelry_Shop") %>">Rings</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Jewelry_Shop") %>">Bangles</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Jewelry_Shop") %>">Solitaires</a>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="<%= Url("Shop_Jewelry_Shop") %>" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">All Jewellery
                    </a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="<%= Url("Shop_Jewelry_Shop") %>"><i class="mdi mdi-chevron-right" aria-hidden="true"></i>Rings</a>
                        <a class="dropdown-item" href="<%= Url("Shop_Jewelry_Shop") %>"><i class="mdi mdi-chevron-right" aria-hidden="true"></i>Bangles</a>
                        <a class="dropdown-item" href="<%= Url("Shop_Jewelry_Shop") %>"><i class="mdi mdi-chevron-right" aria-hidden="true"></i>Solitaires</a>
                    </div>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Jewelry_About") %>">About </a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="<%= Url("Shop_Jewelry_Contact") %>">Contact</a>
                </li>

            </ul>
        </div>
    </div>
</nav>
