<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads.Controls.Header" %>
<nav class="navbar top-navbar" role="navigation">
    <div class="container">
        <div class="row margin-none">
            <div class="navbar-header col-sm-2">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="<%= Url("Classified_Ads") %>">
                    <img alt="logo" src="/Projects/Classifieds/Classified_Ads/Resources/images/logo.png"></a>
            </div>
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li><a href="<%= Url("Classified_Ads") %>">Home</a></li>
                    <li class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="" aria-expanded="false">Categories Pages <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="<%= Url("Classified_Ads_Categories") %>"><i class="fa fa-fw fa-angle-right"></i>Categories</a>
                            </li>

                            <li>
                                <a href="<%= Url("Classified_Ads_Single") %>"><i class="fa fa-fw fa-angle-right"></i>Ads Detail </a>
                            </li>
                        </ul>
                    </li>
                    <li><a href="<%= Url("Classified_Ads_FAQ") %>">FAQ</a></li>
                    <li><a href="<%= Url("Classified_Ads_Contact") %>">Contact Us</a></li>
                    <li class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="" aria-expanded="false">Blog <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="<%= Url("Classified_Ads_Blog") %>"><i class="fa fa-fw fa-angle-right"></i>Blog</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_BlogDetail") %>"><i class="fa fa-fw fa-angle-right"></i>Blog Details</a>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="" aria-expanded="false">Other Pages <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="<%= Url("Classified_Ads_Price") %>"><i class="fa fa-fw fa-angle-right"></i> Pricing</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_Privacy") %>"><i class="fa fa-fw fa-angle-right"></i>Privacy Policy</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_404") %>"><i class="fa fa-fw fa-angle-right"></i>404 Not Found</a>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="" aria-expanded="false">My Account <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="<%= Url("Classified_Ads_Settings") %>"><i class="fa fa-fw fa-angle-right"></i>Profile</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_Post") %>"><i class="fa fa-fw fa-angle-right"></i>Post Your Ad</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_Settings") %>"><i class="fa fa-fw fa-angle-right"></i>Settings</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_MyAds") %>"><i class="fa fa-fw fa-angle-right"></i>My Ads</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_Alert") %>"><i class="fa fa-fw fa-angle-right"></i>AD Alert</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_Favourites") %>"><i class="fa fa-fw fa-angle-right"></i>Favourite Ads</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_Close") %>"><i class="fa fa-fw fa-angle-right"></i>Close account</a>
                            </li>
                            <li>
                                <a href="<%= Url("Classified_Ads_Login") %>"><i class="fa fa-fw fa-power-off"></i>Log Out</a>
                            </li>
                        </ul>
                    </li>
                </ul>
                <div class="user-login pull-right">
                    <%if (IsLogin) %>
                    <%{ %>
                    <ul class="nav navbar-right top-nav">
                        <li class="dropdown">
                            <a aria-expanded="true" href="" class="dropdown-toggle" data-toggle="dropdown">
                                <img src="images/user.jpg" alt="User Image" class="user-dp">
                                Jhone Doe <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <a href="settings.html"><i class="fa fa-fw fa-user"></i>Profile</a>
                                </li>
                                <li>
                                    <a href="my-ads.html"><i class="fa fa-fw fa-pencil"></i>My Ads</a>
                                </li>
                                <li>
                                    <a href="favourite.html"><i class="fa fa-fw fa-heart"></i>Favourite Ads</a>
                                </li>
                                <li>
                                    <a href="ad-alerts.html"><i class="fa fa-fw fa-clock-o"></i>Ad Alerts</a>
                                </li>
                                <li>
                                    <a href="settings.html"><i class="fa fa-fw fa-gear"></i>Settings</a>
                                </li>
                                <li>
                                    <a href="login.html"><i class="fa fa-fw fa-power-off"></i>Log Out</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <%} %>
                    <%else %>
                    <%{ %>
                    <a href="<%= Url("Classified_Ads_Register") %>">REGISTER</a>
                    <span>or</span>
                    <a class="btn btn-md btn-primary" href="<%= Url("Classified_Ads_Login") %>">Sign In</a>
                    <%} %>
                </div>
            </div>
        </div>
    </div>
</nav>
<!-- End Navbar -->

<!-- Search Box -->
<section class="search-box">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="main-search-box text-center">
                    <h1 class="intro-title">Sell or Advertise anything online</h1>
                    <p class="sub-title">Buy and sell everything from used cars to mobile phones and computers, or search for property, jobs and more</p>
                    <form action="#" method="GET">
                        <div class="col-md-4 col-sm-4 search-input">
                            <input placeholder="What are you looking for...?" class="form-control input-lg search-form" type="text">
                        </div>
                        <div class="col-md-3 col-sm-3 search-input">
                            <select class="form-control input-lg search-form">
                                <option selected="selected" value="">All Categories</option>
                                <option value="Vehicles" style="background-color: #E9E9E9; font-weight: bold;" disabled="disabled">- Vehicles - </option>
                                <option value="Cars">Cars</option>
                                <option value="Motorcycles">Motorcycles</option>
                                <option value="Boats">Boats</option>
                                <option value="Vehicles">Other Vehicles</option>
                                <option value="House" style="background-color: #E9E9E9; font-weight: bold;" disabled="disabled">- House and Children - 
                                </option>
                                <option value="Appliances">Appliances</option>
                                <option value="Inside">Inside</option>
                                <option value="Games">Games and Clothing</option>
                                <option value="Garden">Garden</option>
                                <option value="Multimedia" style="background-color: #E9E9E9; font-weight: bold;" disabled="disabled">- Multimedia - </option>
                                <option value="Telephony">Telephony</option>
                                <option value="Image">Image and sound</option>
                                <option value="Real" style="background-color: #E9E9E9; font-weight: bold;" disabled="disabled">- Real Estate - 
                                </option>
                                <option value="Apartment">Apartment</option>
                                <option value="Home">Home</option>
                                <option value="Vacation">Vacation Rentals</option>
                                <option value="Grounds">Grounds</option>
                                <option value="Houseshares">Houseshares</option>
                                <option value="Other real estate">Other real estate</option>
                                <option value="Services" style="background-color: #E9E9E9; font-weight: bold;" disabled="disabled">- Services - </option>
                                <option value="Jobs">Jobs</option>
                                <option value="Job application">Job application</option>
                                <option value="Services">Services</option>
                                <option value="dropoff" style="background-color: #E9E9E9; font-weight: bold;" disabled="disabled">- Extra - </option>
                                <option value="Other">Other</option>
                            </select>
                        </div>
                        <div class="col-md-3 col-sm-3 search-input">
                            <select class="form-control input-lg search-form">
                                <option selected="selected" value="">All Locations</option>
                                <option value="AL">Alabama</option>
                                <option value="AK">Alaska</option>
                                <option value="AZ">Arizona</option>
                                <option value="AR">Arkansas</option>
                                <option value="CA">California</option>
                                <option value="CO">Colorado</option>
                                <option value="CT">Connecticut</option>
                                <option value="DE">Delaware</option>
                                <option value="DC">District Of Columbia</option>
                                <option value="FL">Florida</option>
                                <option value="GA">Georgia</option>
                                <option value="HI">Hawaii</option>
                                <option value="ID">Idaho</option>
                                <option value="IL">Illinois</option>
                                <option value="IN">Indiana</option>
                                <option value="IA">Iowa</option>
                                <option value="KS">Kansas</option>
                                <option value="KY">Kentucky</option>
                                <option value="LA">Louisiana</option>
                                <option value="ME">Maine</option>
                                <option value="MD">Maryland</option>
                                <option value="MA">Massachusetts</option>
                                <option value="MI">Michigan</option>
                                <option value="MN">Minnesota</option>
                                <option value="MS">Mississippi</option>
                                <option value="MO">Missouri</option>
                                <option value="MT">Montana</option>
                                <option value="NE">Nebraska</option>
                                <option value="NV">Nevada</option>
                                <option value="NH">New Hampshire</option>
                                <option value="NJ">New Jersey</option>
                                <option value="NM">New Mexico</option>
                                <option value="NY">New York</option>
                                <option value="NC">North Carolina</option>
                                <option value="ND">North Dakota</option>
                                <option value="OH">Ohio</option>
                                <option value="OK">Oklahoma</option>
                                <option value="OR">Oregon</option>
                                <option value="PA">Pennsylvania</option>
                                <option value="RI">Rhode Island</option>
                                <option value="SC">South Carolina</option>
                                <option value="SD">South Dakota</option>
                                <option value="TN">Tennessee</option>
                                <option value="TX">Texas</option>
                                <option value="UT">Utah</option>
                                <option value="VT">Vermont</option>
                                <option value="VA">Virginia</option>
                                <option value="WA">Washington</option>
                                <option value="WV">West Virginia</option>
                                <option value="WI">Wisconsin</option>
                                <option value="WY">Wyoming</option>
                                <option value="Other-Locations">Other Locations</option>
                            </select>
                        </div>
                        <div class="col-md-2 col-sm-2 search-input">
                            <button class="btn btn-primary btn-lg simple-btn btn-block">
                                <i class="fa fa-search"></i>Search
                            </button>
                        </div>
                    </form>
                </div>
                <div class="top-categories margin-bottom-none col-md-12">
                    <h4>Popular Categories</h4>
                    <a href="<%= Url("Classified_Ads_Categories") %>">
                        <i class="fa fa-book"></i>Books
                    </a>
                    <a href="<%= Url("Classified_Ads_Categories") %>">
                        <i class="fa fa-briefcase"></i>Jobs
                    </a>
                    <a href="<%= Url("Classified_Ads_Categories") %>">
                        <i class="fa fa-mobile"></i>Mobiles
                    </a>
                    <a href="<%= Url("Classified_Ads_Categories") %>">
                        <i class="fa fa-laptop"></i>Laptop
                    </a>
                    <a href="<%= Url("Classified_Ads_Categories") %>">
                        <i class="fa fa-building-o"></i>Property
                    </a>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- Categories Page Nav -->
            <div class="all-categories-nav">
                <a href="#Restaurant">
                    <i class="fa fa-glass shortcut-icon icon-blue"></i>
                    <p>Restaurant <small>5,56 Ads</small></p>
                </a>
                <a href="#Real_Estate">
                    <i class="fa fa-home shortcut-icon icon-green"></i>
                    <p>Real Estate <small>9,156 Ads</small></p>
                </a>
                <a href="#Cars">
                    <i class="fa fa-car shortcut-icon icon-brown"></i>
                    <p>Cars <small>6,16 Ads</small></p>
                </a>
                <a href="#Shopping">
                    <i class="fa fa-shopping-cart shortcut-icon icon-violet"></i>
                    <p>Shopping <small>98,156 Ads</small></p>
                </a>
                <a href="#Job">
                    <i class="fa fa-briefcase shortcut-icon icon-dark-blue"></i>
                    <p>Job <small>9,16 Ads</small></p>
                </a>
                <a href="#Hotels">
                    <i class="fa fa-building-o shortcut-icon icon-orange"></i>
                    <p>Hotels <small>6,56 Ads</small></p>
                </a>
                <a href="#Services">
                    <i class="fa fa-star shortcut-icon icon-light-blue"></i>
                    <p>Services <small>2,156 Ads</small></p>
                </a>
                <a href="#Pets">
                    <i class="fa fa-paw shortcut-icon icon-light-green"></i>
                    <p>Pets <small>9,156 Ads</small></p>
                </a>
            </div>
            <!-- End Categories Page Nav -->
        </div>
    </div>
</section>
