<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_Ads_Contact.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads.Pages.Classified_Ads_Contact" %>
<%@ Register Src="~/Projects/Classifieds/Classified_Ads/Modules/Download.ascx" TagPrefix="uc1" TagName="Download" %>

<section class="breadcumb_area">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 text-center">
                <div class="breadcumb_section">
                    <div class="page_title">
                        <h3>Contact Us</h3>
                    </div>
                    <div class="page_pagination">
                        <ul>
                            <li><a href="<%= Url("Classified_Ads") %>">Home</a></li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>Contact Us</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Breadcumb -->

<!-- Contact Us -->
<section class="contact">
    <div class="container">
        <div class="row">
            <div class="col-md-6 ">
                <div class="widget top-space margin-bottom-none">
                    <div class="widget-header">
                        <h1>Contact Us</h1>
                    </div>
                    <form method="POST" action="#" id="contactForm" novalidate="novalidate">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="control-label">Your Name <span class="required">*</span></label>
                                    <input type="text" name="" value="" placeholder="Enter Name" class="form-control" maxlength="100">
                                </div>
                                <div class="col-md-6">
                                    <label class="control-label">Your Email Address <span class="required">*</span></label>
                                    <input type="email" name="" value="" placeholder="Enter Email Address" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Subject</label>
                            <input type="text" name="" value="" placeholder="Enter The Subject" class="form-control">
                        </div>
                        <div class="form-group">
                            <label class="control-label">Message <span class="required">*</span></label>
                            <textarea placeholder="Enter Message" name="message" class="form-control" rows="3"></textarea>
                        </div>
                        <div class="text-right">
                            <input type="submit" class="btn btn-primary" value="Send Message">
                        </div>
                    </form>
                </div>
            </div>
            <div class="col-md-6">
                <div class="widget margin-bottom-none">
                    <div class="widget-header">
                        <h1>Get in Touch</h1>
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    <hr>
                    <h4 class="heading-primary">TEAM Design -  <strong>Ads</strong></h4>
                    <ul class="list list-icons list-icons-style-3 mt-xlg">
                        <li><i class="fa fa-fw fa-map-marker"></i><strong>Address:</strong> 1234 Street Name, City Name, United States</li>
                        <li><i class="fa fa-fw fa-phone"></i><strong>Phone:</strong> (123) 456-789</li>
                        <li><i class="fa fa-fw fa-envelope"></i><strong>Email:</strong> <a href="mailto:mail@example.com">mail@example.com</a></li>
                    </ul>
                    <hr>
                    <h4 class="heading-primary">Business <strong>Hours</strong></h4>
                    <ul class="list list-icons list-dark mt-xlg">
                        <li><i class="fa fa-fw fa-clock-o"></i>Monday - Friday - 9am to 5pm</li>
                        <li><i class="fa fa-fw fa-clock-o"></i>Saturday - 9am to 2pm</li>
                        <li><i class="fa fa-fw fa-clock-o"></i>Sunday - Closed</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Contact Us -->
<uc1:Download runat="server" id="Download" />
