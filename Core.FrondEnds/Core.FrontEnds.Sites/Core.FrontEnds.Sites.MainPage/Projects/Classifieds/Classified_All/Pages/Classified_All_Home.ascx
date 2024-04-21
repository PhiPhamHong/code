<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_All_Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All.Pages.Classified_All_Home" %>
<%@ Register Src="~/Projects/Classifieds/Classified_All/Modules/Categories.ascx" TagPrefix="uc1" TagName="Categories" %>
<%@ Register Src="~/Projects/Classifieds/Classified_All/Modules/Download.ascx" TagPrefix="uc1" TagName="Download" %>
<%@ Register Src="~/Projects/Classifieds/Classified_All/Modules/MainCategories.ascx" TagPrefix="uc1" TagName="MainCategories" %>



<section class="featured-products">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="carousel-section-header">
                    <h1>Trending Ads <a href="<%= Url("Classified_All_Categories") %>" class="btn btn-md btn-primary pull-right">Show More Items <b>24727</b> <i class="fa fa-arrow-right"></i></a></h1>
                </div>
                <div id="owl-carousel-featured" class="owl-carousel owl-carousel-featured">
                    <div class="item">
                        <div class="item-ads-grid icon-blue">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/restaurant/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>There are many variations</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 10.35 AM</li>
                                    <li class="item-cat"><i class="fa fa-glass"></i><a href="<%= Url("Classified_All_Categories") %>">Restaurant</a> , <a href="<%= Url("Classified_All_Categories") %>">Cafe</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Buffalo </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-green">
                            <div class="item-badge-grid hot-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/real_estate/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 02.05 AM</li>
                                    <li class="item-cat"><i class="fa fa-home"></i><a href="<%= Url("Classified_All_Categories") %>">Real Estate</a> , <a href="<%= Url("Classified_All_Categories") %>">For Rent</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Frederick </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-brown">
                            <div class="item-badge-grid premium-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/cars/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 03.15 AM</li>
                                    <li class="item-cat"><i class="fa fa-car"></i><a href="<%= Url("Classified_All_Categories") %>">Cars</a> , <a href="<%= Url("Classified_All_Categories") %>">Car Parts</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Augusta </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid highlight-ads icon-violet">
                            <div class="item-badge-grid btn-primary">
                                <a href="">Premium Ad</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/shopping/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 11.45 PM</li>
                                    <li class="item-cat"><i class="fa fa-shopping-cart"></i><a href="<%= Url("Classified_All_Categories") %>">Shopping</a> , <a href="<%= Url("Classified_All_Categories") %>">Accessories</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>San Diego </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-dark-blue">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/job/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 09.45 PM</li>
                                    <li class="item-cat"><i class="fa fa-briefcase"></i><a href="<%= Url("Classified_All_Categories") %>">Job</a> , <a href="<%= Url("Classified_All_Categories") %>">Banking</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Juneau</a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-orange">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/hotels/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 02.05 AM</li>
                                    <li class="item-cat"><i class="fa fa-building-o"></i><a href="<%= Url("Classified_All_Categories") %>">Hotels</a> , <a href="<%= Url("Classified_All_Categories") %>">Events & Nightlife</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Fairbanks</a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-light-blue">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/services/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 12.09 PM</li>
                                    <li class="item-cat"><i class="fa fa-star"></i><a href="<%= Url("Classified_All_Categories") %>">Services</a> , <a href="<%= Url("Classified_All_Categories") %>">Computers</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Fort Smith </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-light-green">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/pets/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 10.35 AM</li>
                                    <li class="item-cat"><i class="fa fa-paw"></i><a href="<%= Url("Classified_All_Categories") %>">Pets</a> , <a href="<%= Url("Classified_All_Categories") %>">Dogs</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Manchester</a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div id="owl-carousel-featured" class="owl-carousel owl-carousel-featured">
                    <div class="item">
                        <div class="item-ads-grid icon-blue">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/restaurant/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>There are many variations</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 10.35 AM</li>
                                    <li class="item-cat"><i class="fa fa-glass"></i><a href="<%= Url("Classified_All_Categories") %>">Restaurant</a> , <a href="<%= Url("Classified_All_Categories") %>">Cafe</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Buffalo </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-green">
                            <div class="item-badge-grid hot-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/real_estate/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 02.05 AM</li>
                                    <li class="item-cat"><i class="fa fa-home"></i><a href="<%= Url("Classified_All_Categories") %>">Real Estate</a> , <a href="<%= Url("Classified_All_Categories") %>">For Rent</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Frederick </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-brown">
                            <div class="item-badge-grid premium-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/cars/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 03.15 AM</li>
                                    <li class="item-cat"><i class="fa fa-car"></i><a href="<%= Url("Classified_All_Categories") %>">Cars</a> , <a href="<%= Url("Classified_All_Categories") %>">Car Parts</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Augusta </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-violet">
                            <div class="item-badge-grid btn-primary">
                                <a href="">Premium Ad</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/shopping/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 11.45 PM</li>
                                    <li class="item-cat"><i class="fa fa-shopping-cart"></i><a href="<%= Url("Classified_All_Categories") %>">Shopping</a> , <a href="<%= Url("Classified_All_Categories") %>">Accessories</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>San Diego </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-dark-blue">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/job/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 09.45 PM</li>
                                    <li class="item-cat"><i class="fa fa-briefcase"></i><a href="<%= Url("Classified_All_Categories") %>">Job</a> , <a href="<%= Url("Classified_All_Categories") %>">Banking</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Juneau</a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-orange">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/hotels/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 02.05 AM</li>
                                    <li class="item-cat"><i class="fa fa-building-o"></i><a href="<%= Url("Classified_All_Categories") %>">Hotels</a> , <a href="<%= Url("Classified_All_Categories") %>">Events & Nightlife</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Fairbanks</a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-light-blue">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/services/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 12.09 PM</li>
                                    <li class="item-cat"><i class="fa fa-star"></i><a href="<%= Url("Classified_All_Categories") %>">Services</a> , <a href="<%= Url("Classified_All_Categories") %>">Computers</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Fort Smith </a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="item-ads-grid icon-light-green">
                            <div class="item-badge-grid featured-ads">
                                <a href="">HOT</a>
                            </div>
                            <div class="item-img-grid">
                                <img alt="" src="/Projects/Classifieds/Classified_All/Resources/images/categories/pets/1.png" class="img-responsive img-center">
                                <div class="item-title">
                                    <a href="<%= Url("Classified_All_Single") %>">
                                        <h4>Lorem Ipsum is simply</h4>
                                    </a>
                                    <h3>$ 64.5000</h3>
                                </div>
                            </div>
                            <div class="item-meta">
                                <ul>
                                    <li class="item-date"><i class="fa fa-clock-o"></i>Today 10.35 AM</li>
                                    <li class="item-cat"><i class="fa fa-paw"></i><a href="<%= Url("Classified_All_Categories") %>">Pets</a> , <a href="<%= Url("Classified_All_Categories") %>">Dogs</a></li>
                                    <li class="item-location"><a href="<%= Url("Classified_All_Categories") %>"><i class="fa fa-map-marker"></i>Manchester</a></li>
                                    <li class="item-type"><i class="fa fa-bookmark"></i>New</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</section>
<!-- End Featured Products -->

<!-- Categories List -->
<uc1:Categories runat="server" id="Categories" />
<!-- End Categories List -->
<uc1:MainCategories runat="server" id="MainCategories" />
<!-- App Store -->
<uc1:Download runat="server" id="Download" />
<!-- End App Store -->
