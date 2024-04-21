<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Design.Controls.Header" %>
<nav id="menu" class="navbar navbar-default navbar-fixed-top on">
    <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
            <a class="navbar-brand page-scroll" href="#page-top"><i class="fa fa-circle" aria-hidden="true"></i>TEAM Design</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li><a href="#page-top" class="page-scroll">Home</a></li>
                <li><a href="#about" class="page-scroll">About</a></li>
                <li><a href="#services" class="page-scroll">Services</a></li>
                <li><a href="#portfolio" class="page-scroll">Portfolio</a></li>
                <li><a href="#team" class="page-scroll">Team</a></li>
                <li><a href="#contact" class="page-scroll">Contact</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
</nav>
<header id="header">
    <div class="intro">
        <div class="overlay overlay-none">
            <!-- muted -->
            <video loop="loop" muted="muted" autoplay  poster="/Projects/Web/Resources/images/screenshot.jpg" id="background">
                <source src="/Projects/Web/Resources/images/video.mp4" type="video/mp4">
            </video>
            <div class="container">
                <div class="row"> 
                    <div class="intro-text">
                        <h3>TEAM</h3>
                        <h1>Design</h1>
                        <p> Creative Digital Agency</p>
                        <button type="button" class="btn btn-custom btn-lg" data-toggle="modal" data-target="#work-modal"> Contact for me! </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>