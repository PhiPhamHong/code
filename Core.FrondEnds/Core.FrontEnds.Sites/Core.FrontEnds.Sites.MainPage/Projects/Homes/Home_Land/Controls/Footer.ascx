﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_Land.Controls.Footer" %>
<%@ Register Src="~/Projects/Homes/Home_Land/Modules/JoinTeam.ascx" TagPrefix="uc1" TagName="JoinTeam" %>


<uc1:JoinTeam runat="server" ID="JoinTeam" />

<section class="section-padding footer">
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-3">
                <h4 class="mb-5 mt-0"><a class="logo" href="<%= Url("Home_Land") %>">
                    <img src="/Projects/Homes/Home_Land/Resources/img/logo.png" alt="osahan logo"></a></h4>
                <p> 86 Petersham town, New South wales<br>
                    Waedll Steet, Australia PA 6550</p>
                <p class="mb-0"><a class="text-warning" href=""><i class="mdi mdi-phone"></i>+61 525 240 310</a></p>
                <p class="mb-0"><a class="text-success" href=""><i class="mdi mdi-email"></i>team@gmail.com</a></p>
                <p class="mb-0"><a class="text-primary" href=""><i class="mdi mdi-earth"></i>www.teamdesign.info</a></p>
            </div>
            <div class="col-lg-2 col-md-2">
                <h6 class="mb-4">OUR PROPERTIES</h6>
                <ul>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Single Story</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Dubble Story</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Tripple Story</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Resort</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Home in Merrick Way</a></li>
                    <ul>
            </div>
            <div class="col-lg-2 col-md-2">
                <h6 class="mb-4">QUICK LINKS</h6>
                <ul>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Home in Coral Gables</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Villa on Grand Avenue</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Home in Merrick Way</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Land / Plots</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Restaurent</a></li>
                    <ul>
            </div>
            <div class="col-lg-2 col-md-2">
                <h6 class="mb-4">ABOUT</h6>
                <ul>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Company Information</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Careers</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Store Location</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Affillate Program</a></li>
                    <li><a href=""><i class="mdi mdi-arrow-right"></i>Copyright</a></li>
                    <ul>
            </div>
            <div class="col-lg-3 col-md-3">
                <h6 class="mb-4">NEWSLETTER</h6>
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Email Address..." aria-label="Recipient's username" aria-describedby="basic-addon2">
                    <div class="input-group-append">
                        <button class="btn btn-secondary" type="button"><i class="mdi mdi-arrow-right"></i></button>
                    </div>
                </div>
                <p class="text-info newsletter-info"><i class="mdi mdi-email-variant"></i>Get the most recent updates from our site and be updated your self...</p>
                <h6 class="mb-3 mt-4">GET IN TOUCH</h6>
                <div class="footer-social">
                    <a class="btn-facebook" href=""><i class="mdi mdi-facebook"></i></a>
                    <a class="btn-twitter" href=""><i class="mdi mdi-twitter"></i></a>
                    <a class="btn-instagram" href=""><i class="mdi mdi-instagram"></i></a>
                    <a class="btn-whatsapp" href=""><i class="mdi mdi-whatsapp"></i></a>
                    <a class="btn-messenger" href=""><i class="mdi mdi-facebook-messenger"></i></a>
                    <a class="btn-google" href=""><i class="mdi mdi-google"></i></a>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Footer -->
<!-- Copyright -->
<section class="pt-4 pb-4 text-center footer-bottom">
    <p class="mt-0 mb-0">© Copyright 2018 <strong> TEAM Design </strong>. All Rights Reserved</p>
    <small class="mt-0 mb-0">Made with <i class="mdi mdi-heart text-danger"></i>by <a class="text-warning" target="_blank" href="https://teamdesign.info/">TEAM Design</a>
    </small>
</section>
