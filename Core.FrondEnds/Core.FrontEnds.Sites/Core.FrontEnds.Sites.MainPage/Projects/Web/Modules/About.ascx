<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="About.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Web.Modules.About" %>

<div id="about">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-md-6 ">
                <div class="about-img">
                    <img src="<%= ResourceImage("about2.jpg") %>" class="img-responsive" alt=""></div>
            </div>
            <div class="col-xs-12 col-md-6">
                <div class="about-text">
                    <h2>Welcome to <b>Design Studio</b></h2>
                    <hr>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate.</p>
                    <h3>Message CEO</h3>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis sed dapibus leo nec ornare diam. Sed commodo nibh ante facilisis bibendum dolor feugiat at.</p>
                    <div class="text-right">
                        <img src="<%= ResourceImage("sign.png") %>" alt="">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
