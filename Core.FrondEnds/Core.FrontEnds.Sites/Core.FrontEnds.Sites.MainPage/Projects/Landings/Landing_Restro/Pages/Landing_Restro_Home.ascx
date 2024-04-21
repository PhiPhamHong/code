<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Landing_Restro_Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Restro.Pages.Landing_Restro_Home" %>
<nav id="menu" class="navbar navbar-default navbar-fixed-top">
    <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
            <a class="navbar-brand page-scroll" href="#page-top">Restro</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li><a href="#page-top" class="page-scroll">Home</a></li>
                <li><a href="#about" class="page-scroll">About</a></li>
                <li><a href="#restaurant-menu" class="page-scroll">Menu</a></li>
                <li><a href="#services" class="page-scroll">Services</a></li>
                <li><a href="#portfolio" class="page-scroll">Gallery</a></li>
                <li><a href="#team" class="page-scroll">Chefs</a></li>
                <li><a href="#call-reservation" class="page-scroll">Contact</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
</nav>
<!-- Header -->
<header id="header">
    <div class="intro">
        <div class="overlay">
            <!-- muted -->
            <video loop="loop" muted="muted" autoplay poster="/Projects/Landings/Landing_Restro/Resources/img/screenshot.jpg" id="background">
                <source src="/Projects/Landings/Landing_Restro/Resources/video.mp4" type="video/mp4">
            </video>
            <div class="container">
                <div class="row">
                    <div class="intro-text">
                        <h1>Restro</h1>
                        <p>Cafe  <i class="fa fa-circle"></i>Restaurant  <i class="fa fa-circle"></i>Wine Bar</p>
                        <button type="button" class="btn btn-custom btn-lg" data-toggle="modal" data-target="#reserve-modal">Book a Table</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>
<!-- About Section -->
<div id="about">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-md-6 ">
                <div class="about-img">
                    <img src="/Projects/Landings/Landing_Restro/Resources/img/about.jpg" class="img-responsive" alt=""></div>
            </div>
            <div class="col-xs-12 col-md-6">
                <div class="about-text">
                    <h2>Welcome to our <b>Restro</b></h2>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate.</p>
                    <h3>Awarded Chefs</h3>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis sed dapibus leo nec ornare diam. Sed commodo nibh ante facilisis bibendum dolor feugiat at.</p>
                    <div class="text-right">
                        <img src="/Projects/Landings/Landing_Restro/Resources/img/sign.png" alt="">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Restaurant Menu Section -->
<div id="restaurant-menu">
    <div class="section-title text-center center">
        <div class="overlay">
            <h2>Main <b>Menus</b></h2>
            <hr>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit duis sed.</p>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-4">
                <div class="menu-section">
                    <h2 class="menu-section-title">Breakfast & <b>Starters</b></h2>
                    <hr>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item1.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish</div>
                        <div class="menu-item-price">$35  <span>$15</span></div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item2.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$30 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item3.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish</div>
                        <div class="menu-item-price">$30 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item4.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$30 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-4">
                <div class="menu-section">
                    <h2 class="menu-section-title">Main <b>Course</b></h2>
                    <hr>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item5.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$45 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item4.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$30 <span>$15</span></div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item3.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish</div>
                        <div class="menu-item-price">$30 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item1.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$30 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-4">
                <div class="menu-section">
                    <h2 class="menu-section-title">Coffee & <b>Drinks</b></h2>
                    <hr>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item5.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$45 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item4.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish</div>
                        <div class="menu-item-price">$30 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item3.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$30 <span>$15</span></div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                    <div class="menu-item">
                        <div class="menu-item-image">
                            <img class="img-responsive img-circle" src="/Projects/Landings/Landing_Restro/Resources/img/item/item1.jpg" alt="">
                        </div>
                        <div class="menu-item-name">Delicious Dish </div>
                        <div class="menu-item-price">$30 </div>
                        <div class="menu-item-description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Services Section -->
<div id="services">
    <div class="section-title text-center center">
        <div class="overlay">
            <h2>Our <b>Service</b></h2>
            <hr>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit duis sed.</p>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-4">
                <div class="service">
                    <div class="icon">
                        <img src="/Projects/Landings/Landing_Restro/Resources/img/services/1.png" alt=""></div>
                    <h3>Amazing <b>Set Up</b></h3>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, c-r adipiscing elit. In maximus ligula semper metus pellentesque mattis. Maecenas volutpat, diam enim. </p>
                </div>
                <div class="service">
                    <div class="icon">
                        <img src="/Projects/Landings/Landing_Restro/Resources/img/services/2.png" alt=""></div>
                    <h3>Amazing <b>Food</b></h3>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, c-r adipiscing elit. In maximus ligula semper metus pellentesque mattis. Maecenas volutpat, diam enim. </p>
                </div>
            </div>
            <div class="col-xs-12 col-sm-4">
                <div class="service">
                    <div class="icon">
                        <img src="/Projects/Landings/Landing_Restro/Resources/img/services/3.png" alt=""></div>
                    <h3>Amazing <b>Music</b></h3>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, c-r adipiscing elit. In maximus ligula semper metus pellentesque mattis. Maecenas volutpat, diam enim. </p>
                </div>
                <div class="service">
                    <div class="icon">
                        <img src="/Projects/Landings/Landing_Restro/Resources/img/services/4.png" alt=""></div>
                    <h3>Amazing <b>Service</b></h3>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, c-r adipiscing elit. In maximus ligula semper metus pellentesque mattis. Maecenas volutpat, diam enim. </p>
                </div>
            </div>
            <div class="col-xs-12 col-sm-4">
                <div class="service">
                    <div class="icon">
                        <img src="/Projects/Landings/Landing_Restro/Resources/img/services/5.png" alt=""></div>
                    <h3>Amazing <b>Food</b></h3>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, c-r adipiscing elit. In maximus ligula semper metus pellentesque mattis. Maecenas volutpat, diam enim. </p>
                </div>
                <div class="service">
                    <div class="icon">
                        <img src="/Projects/Landings/Landing_Restro/Resources/img/services/6.png" alt=""></div>
                    <h3>Amazing <b>Music</b></h3>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, c-r adipiscing elit. In maximus ligula semper metus pellentesque mattis. Maecenas volutpat, diam enim. </p>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Portfolio Section -->
<div id="portfolio">
    <div class="section-title text-center center">
        <div class="overlay">
            <h2>Photo <b>Gallery</b></h2>
            <hr>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit duis sed.</p>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="categories">
                <ul class="cat">
                    <li>
                        <ol class="type">
                            <li><a href="" data-filter="*" class="active">All</a></li>
                            <li><a href="" data-filter=".breakfast">Breakfast</a></li>
                            <li><a href="" data-filter=".lunch">Lunch</a></li>
                            <li><a href="" data-filter=".dinner">Dinner</a></li>
                        </ol>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
        </div>
        <div class="row">
            <div class="portfolio-items">
                <div class="col-sm-6 col-md-4 col-lg-4 breakfast">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/01-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Breakfast</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/01-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 dinner">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/02-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Dinner</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/02-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 dinner">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/05-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Dinner</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/05-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 lunch">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/07-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Lunch</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/07-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 breakfast">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/08-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Breakfast</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/08-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 dinner">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/09-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Dinner</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/09-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 lunch">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/10-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Lunch</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/10-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 lunch">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/11-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Lunch</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/11-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-4 breakfast">
                    <div class="portfolio-item">
                        <div class="hover-bg">
                            <a href="img/portfolio/12-large.jpg" title="Dish Name" data-lightbox-gallery="gallery1">
                                <div class="hover-text">
                                    <h4><small>Breakfast</small><br>
                                        Dish <b>Name</b></h4>
                                </div>
                                <img src="/Projects/Landings/Landing_Restro/Resources/img/portfolio/12-large.jpg" class="img-responsive" alt="Project Title">
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Team Section -->
<div id="team" class="text-center">
    <div class="overlay">
        <div class="container">
            <div class="col-md-10 col-md-offset-1 section-title">
                <h2>Meet <b>Our Chefs</b></h2>
                <hr>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit duis sed dapibus leonec.</p>
            </div>
            <div id="row">
                <div class="col-md-4 team">
                    <div class="thumbnail">
                        <div class="team-img">
                            <img src="/Projects/Landings/Landing_Restro/Resources/img/team/01.jpg" alt="..."></div>
                        <div class="caption">
                            <h3>Mike <b>Doe</b></h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis sed dapibus leo nec ornare diam.</p>
                            <div class="social-share-new">
                                <a href="" class="btn-social btn-facebook"><i class="fa fa-facebook"></i></a>
                                <a href="" class="btn-social btn-instagram"><i class="fa fa-instagram"></i></a>
                                <a href="" class="btn-social btn-instagram"><i class="fa fa-yelp"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 team">
                    <div class="thumbnail">
                        <div class="team-img">
                            <img src="/Projects/Landings/Landing_Restro/Resources/img/team/02.jpg" alt="..."></div>
                        <div class="caption">
                            <h3>Chris <b>Doe</b></h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis sed dapibus leo nec ornare diam.</p>
                            <div class="social-share-new">
                                <a href="" class="btn-social btn-facebook"><i class="fa fa-facebook"></i></a>
                                <a href="" class="btn-social btn-instagram"><i class="fa fa-instagram"></i></a>
                                <a href="" class="btn-social btn-instagram"><i class="fa fa-yelp"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 team">
                    <div class="thumbnail">
                        <div class="team-img">
                            <img src="/Projects/Landings/Landing_Restro/Resources/img/team/03.jpg" alt="..."></div>
                        <div class="caption">
                            <h3>Ethan <b>Doe</b></h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis sed dapibus leo nec ornare diam.</p>
                            <div class="social-share-new">
                                <a href="" class="btn-social btn-facebook"><i class="fa fa-facebook"></i></a>
                                <a href="" class="btn-social btn-instagram"><i class="fa fa-instagram"></i></a>
                                <a href="" class="btn-social btn-instagram"><i class="fa fa-yelp"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Call Reservation Section -->
<div id="call-reservation" class="text-center">
    <div class="container">
        <h2>Want to make a reservation? Call <strong>1-887-654-3210</strong></h2>
    </div>
</div>
<!-- Contact Section -->
<div id="contact" class="text-center">
    <div class="container">
        <div class="section-title text-center">
            <h2>Contact <b>Form</b></h2>
            <hr>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit duis sed.</p>
        </div>
        <div class="col-md-10 col-md-offset-1">
            <form name="sentMessage" id="contactForm" novalidate>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="name" class="form-control" placeholder="Name" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="email" id="email" class="form-control" placeholder="Email" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <textarea name="message" id="message" class="form-control" rows="4" placeholder="Message" required></textarea>
                    <p class="help-block text-danger"></p>
                </div>
                <div id="success"></div>
                <button type="submit" class="btn btn-custom btn-lg">Send Message</button>
            </form>
        </div>
    </div>
</div>
<!-- Footer Section -->
<div id="footer">
    <div class="container text-center">
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-location-arrow" aria-hidden="true"></i>
                <p>4321 California St,<br>
                    San Francisco, CA 12345</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-clock-o" aria-hidden="true"></i>
                <p>Mon-Thurs: 10:00 AM - 11:00 PM<br>
                    Fri-Sun: 11:00 AM - 02:00 AM</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-phone" aria-hidden="true"></i>
                <p>Phone: +1 123 456 1234<br>
                    Email: info@company.com</p>
            </div>
        </div>
    </div>
</div>
<div class="footer-bottom">
    <div class="col-sm-12 text-center">
        <div class="footer-social text-center">
            <div class="social-share-new">
                <a href="" class="btn-social btn-behance"><i class="fa fa-behance"></i></a>
                <a href="" class="btn-social btn-dribbble"><i class="fa fa-dribbble"></i></a>
                <a href="" class="btn-social btn-facebook"><i class="fa fa-facebook"></i></a>
                <a href="" class="btn-social btn-google-plus"><i class="fa fa-google-plus"></i></a>
                <a href="" class="btn-social btn-instagram"><i class="fa fa-instagram"></i></a>
                <a href="" class="btn-social btn-linkedin"><i class="fa fa-linkedin"></i></a>
                <a href="" class="btn-social btn-pinterest"><i class="fa fa-pinterest"></i></a>
                <a href="" class="btn-social btn-skype"><i class="fa fa-skype"></i></a>
                <a href="" class="btn-social btn-twitter"><i class="fa fa-twitter"></i></a>
                <a href="" class="btn-social btn-youtube"><i class="fa fa-youtube"></i></a>
                <a href="" class="btn-social btn-email"><i class="fa fa-envelope-o"></i></a>
            </div>
        </div>
        <div class="text-center">
            &copy; Copyright 2017 Restro . All Rights Reserved
               <div class="rfloat heartline">
                   Made with<i class="fa fa-heart hearticon"></i>by
                  <a target="_blank" href="https://www.facebook.com/PGT.Zeus"> APhi Bụng Bự </a>
               </div>
        </div>
    </div>
</div>
<!-- Book a Table Popup -->
<div class="modal right fade" id="reserve-modal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header text-center">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h2><small>book a table</small><br>
                    0800 123 456
                    <br>
                    <b class="theme-color">Or book online</b></h2>
            </div>
            <form action="#">
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Date</label>
                                <input value="" placeholder="dd/mm/yyyy" class="form-control" type="text">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Time</label>
                                <input value="" placeholder="Enter Time" class="form-control" type="text">
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Guests</label>
                        <input value="" placeholder="Enter No of People" class="form-control" type="text">
                    </div>
                    <div class="form-group">
                        <label>Name</label>
                        <input value="" placeholder="Enter Name" class="form-control" type="text">
                    </div>
                    <div class="form-group">
                        <label>Phone</label>
                        <input value="" placeholder="Enter Phone Number" class="form-control" type="text">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-custom btn-lg btn-block">Book Now</button>
                </div>
            </form>
        </div>
    </div>
</div>
