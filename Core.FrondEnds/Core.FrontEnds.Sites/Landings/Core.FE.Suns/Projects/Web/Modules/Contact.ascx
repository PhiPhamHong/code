<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="Core.FE.Suns.Projects.Web.Modules.Contact" %>
<div id="contact">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-6 wow bounceInLeft animated" data-wow-duration="1s" data-wow-delay="0.1s" data-wow-offset="0">
                <div class="section-title">
                    <h2>Get In Touch</h2>
                    <p>Consectetur adipisicing elit, sed do eiusmod tempor</p>
                </div>
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
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" id="phone" class="form-control" placeholder="Phone" required="required">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" id="Service" class="form-control" placeholder="Service" required="required">
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
            <div class="col-sm-6 col-md-5 col-md-offset-1 wow bounceInRight animated" data-wow-duration="1s" data-wow-delay="0.1s" data-wow-offset="0">
                <div class="contact-info">
                    <h4 class="block-title">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut et dolore magna aliqua. Ut enim ad minim veniam.
                        </h4>
                    <div class="contact-item">
                        <p><span><i class="fa fa-home fa-fw" aria-hidden="true"></i>Address</span>4321 California St, San Francisco, CA 12345</p>
                    </div>
                    <div class="contact-item">
                        <p><span><i class="fa fa-phone fa-fw" aria-hidden="true"></i>Phone</span> +1 123 456 1234, +1 123 456 1215</p>
                    </div>
                    <div class="contact-item">
                        <p><span><i class="fa fa-envelope-o fa-fw" aria-hidden="true"></i>Email</span> info@company.com, company@gmail.com</p>
                    </div>
                    <div class="social">
                        <ul>
                            <li><a><i class="fa fa-facebook"></i></a></li>
                            <li><a><i class="fa fa-twitter"></i></a></li>
                            <li><a><i class="fa fa-google-plus"></i></a></li>
                            <li><a><i class="fa fa-youtube"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="overlay-map" onclick="style.pointerEvents='none'"></div>
<iframe width="100%" height="400" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3501889.0795673826!2d73.15687918966267!3d31.00357561172526!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391964aa569e7355%3A0x8fbd263103a38861!2sPunjab!5e0!3m2!1sen!2sin!4v1503422781241" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>
