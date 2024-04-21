<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Design.Modules.Contact" %>
<div id="call-section" class="text-center">
    <div class="container">
        <h2>We're here 24/7 to answer any questions. Just call! <strong>0-888-123-4567</strong></h2>
    </div>
</div>
<!-- Contact Section -->
<!-- Contact Section -->
<div id="contact" class="text-center">
    <div class="container">
        <div class="section-title text-center">
            <h2><b> Contact form </b></h2>
            <hr>
            <p> Lorem ipsum dolor sit amet, consectetur adipiscing .</p>
            <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit duis sed. </p>
        </div>
        <div class="col-md-10 col-md-offset-1">
            <form name="sentMessage" id="contactForm" novalidate>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="name" class="form-control" placeholder="Your name" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="company" class="form-control" placeholder="Your company name">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="address" class="form-control" placeholder="Your address" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="tel" id="phone" class="form-control" placeholder="Phone number" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <input type="email" id="email" class="form-control" placeholder="Your email address">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <textarea name="message" id="message" class="form-control" rows="4" placeholder="Message" required></textarea>
                    <p class="help-block text-danger"></p>
                </div>
                <div id="success"></div>
                <button type="submit" class="btn btn-custom btn-lg"> Send message </button>
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
                <p>My Dinh - Ha Noi - Viet Nam </p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-phone" aria-hidden="true"></i>
                <p>0392-655-345 / +84-392-434-345</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-envelope-o" aria-hidden="true"></i>
                <p>cskh.teamdesign@gmail.com</p>
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
            &copy; Copyright 2017 Team Design. All Rights Reserved
              
            <div class="rfloat heartline">
                Made with<i class="fa fa-heart hearticon"></i>by
                 
                <a target="_blank" href="https://facebook.com/PGTZeus"> APhi Bụng Bự </a>
            </div>
        </div>
    </div>
</div>

