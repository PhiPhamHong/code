<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FreeTrial.ascx.cs" Inherits="Core.FE.Sites.Api.Projects.Web.Modules.FreeTrial" %>
<section class="download-app-block bg-primary" id="download-app">
    <div class="container">
        <div class="section-title text-center wow animated zoomIn">
            <span class="badge badge-white text-white">Are you ready?</span>
            <h2 class="text-white">Download Software</h2>
            <span class="section-title-line section-title-line line-white"></span>
        </div>
        <div class="row">
            <div class="col-md-8 mx-auto text-center">
                <p class="lead mb-5 text-white">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Et, consequuntur, modi mollitia corporis ipsa voluptate corrupti eum ratione ex ea praesentium quibusdam? Aut, in eum facere corrupti necessitatibus perspiciatis quis?</p>
                <p>
                    <button type="button" class="btn btn-light btn-lg">DOWNLOAD NOW</button></p>
            </div>
        </div>
    </div>
</section>
<section class="trial-block" id="trial">
    <div class="container">
        <div class="section-title text-center wow animated zoomIn">
            <span class="badge badge-info">Get Started</span>
            <h2>Start your free trial. No credit card requires</h2>
            <span class="section-title-line section-title-line"></span>
        </div>
        <div class="row">
            <div class="col-md-8 mx-auto">
                <form name="sentMessage" id="contactForm" novalidate>
                    <div class="control-group form-group">
                        <div class="controls">
                            <input type="text" placeholder="Full Name" class="form-control" id="name" required data-validation-required-message="Please enter your name.">
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-group form-group col-md-6">
                            <div class="controls">
                                <input type="tel" placeholder="Phone Number" class="form-control" id="phone" required data-validation-required-message="Please enter your phone number.">
                            </div>
                        </div>
                        <div class="control-group form-group col-md-6">
                            <div class="controls">
                                <input type="email" placeholder="Email Address" class="form-control" id="email" required data-validation-required-message="Please enter your email address.">
                            </div>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <textarea rows="4" cols="100" placeholder="Message" class="form-control" id="message" required data-validation-required-message="Please enter your message" maxlength="999" style="resize: none"></textarea>
                        </div>
                    </div>
                    <div id="success"></div>
                    <!-- For success/fail messages -->
                    <button type="submit" class="btn btn-primary btn-lg btn-block">START YOUR FREE TRIAL NOW</button>
                </form>
                <p class="mt-3 text-center mb-0">Create Your <a class="text-primary">FREE</a> Account Now & Get 30 days <a class="text-primary" >FREE</a> trial. No credit card required</p>
            </div>
        </div>
    </div>
</section>
