<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_Land_Contact.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_Land.Pages.Home_Land_Contact" %>


<section class="section-map">
    <div id="map">
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3501889.0795673826!2d73.15687918966267!3d31.00357561172526!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391964aa569e7355%3A0x8fbd263103a38861!2sPunjab!5e0!3m2!1sen!2sin!4v1503422781241" width="100%" height="450" frameborder="0" style="border: 0" allowfullscreen></iframe>
    </div>
</section>
<!-- End Contact Us -->
<!-- Contact Me -->
<section class="section-padding  bg-white">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-4">
                <div class="section-title">
                    <h2 class="mt-1 mb-5">Get In Touch</h2>
                </div>
                <h6 class="text-dark"><i class="mdi mdi-home-map-marker"></i>Address :</h6>
                <p>86 Petersham town, New South wales Waedll Steet, Australia PA 6550</p>
                <h6 class="text-dark"><i class="mdi mdi-phone"></i>Phone :</h6>
                <p>+91 12345-67890, (+91) 123 456 7890</p>
                <h6 class="text-dark"><i class="mdi mdi-deskphone"></i>Mobile :</h6>
                <p>(+20) 220 145 6589, +91 12345-67890</p>
                <h6 class="text-dark"><i class="mdi mdi-email"></i>Email :</h6>
                <p>team@gmail.com, info@gmail.com</p>
                <h6 class="text-dark"><i class="mdi mdi-link"></i>Website :</h6>
                <p>www.teamdesign.info</p>
            </div>
            <form class="col-lg-8 col-md-8" name="sentMessage" id="contactForm" novalidate>
                <div class="section-title">
                    <h2 class="mt-1 mb-5">Contact Us</h2>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Full Name <span class="text-danger">*</span></label>
                        <input type="text" placeholder="Full Name" class="form-control" id="name" required data-validation-required-message="Please enter your name.">
                        <p class="help-block"></p>
                    </div>
                </div>
                <div class="row">
                    <div class="control-group form-group col-md-6">
                        <label>Phone Number <span class="text-danger">*</span></label>
                        <div class="controls">
                            <input type="tel" placeholder="Phone Number" class="form-control" id="phone" required data-validation-required-message="Please enter your phone number.">
                        </div>
                    </div>
                    <div class="control-group form-group col-md-6">
                        <div class="controls">
                            <label>Email Address <span class="text-danger">*</span></label>
                            <input type="email" placeholder="Email Address" class="form-control" id="email" required data-validation-required-message="Please enter your email address.">
                        </div>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Message <span class="text-danger">*</span></label>
                        <textarea rows="4" cols="100" placeholder="Message" class="form-control" id="message" required data-validation-required-message="Please enter your message" maxlength="999"></textarea>
                    </div>
                </div>
                <div id="success"></div>
                <!-- For success/fail messages -->
                <button type="submit" class="btn btn-secondary btn-lg">Send Message</button>
            </form>
        </div>
    </div>
</section>
<!-- End Contact Me -->
<!-- Join Team -->

