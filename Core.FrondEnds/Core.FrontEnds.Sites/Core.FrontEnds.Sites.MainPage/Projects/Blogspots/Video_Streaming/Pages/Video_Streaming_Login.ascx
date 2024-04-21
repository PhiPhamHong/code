<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_Streaming_Login.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Video_Streaming.Pages.Video_Streaming_Login" %>
<section class="login-main-wrapper">
    <div class="container-fluid pl-0 pr-0">
        <div class="row no-gutters">
            <div class="col-md-5 p-5 bg-white full-height">
                <div class="login-main-left">
                    <div class="text-center mb-5 login-main-left-header pt-4">
                        <img src="/Projects/Blogspots/Video_Streaming/Resources/img/favicon.png" class="img-fluid" alt="LOGO">
                        <h5 class="mt-3 mb-3">Welcome to Vidoe</h5>
                        <p>It is a long established fact that a reader
                            <br>
                            will be distracted by the readable.</p>
                    </div>
                    <form action="<%= Url("Video_Streaming") %>">
                        <div class="form-group">
                            <label>Mobile number</label>
                            <input type="text" class="form-control" placeholder="Enter mobile number">
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <input type="password" class="form-control" placeholder="Password">
                        </div>
                        <div class="mt-4">
                            <div class="row">
                                <div class="col-12">
                                    <button type="submit" class="btn btn-outline-primary btn-block btn-lg">Sign In</button>
                                </div>
                            </div>
                        </div>
                    </form>
                    <div class="text-center mt-5">
                        <p class="light-gray">Don’t have an account? <a href="<%= Url("Video_Streaming_ForgotPass") %>">Fotgot Password</a></p>
                        <p class="light-gray">Don’t have an account? <a href="<%= Url("Video_Streaming_Register") %>">Sign Up</a></p>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="login-main-right bg-white p-5 mt-5 mb-5">
                    <div class="owl-carousel owl-carousel-login">
                        <div class="item">
                            <div class="carousel-login-card text-center">
                                <img src="/Projects/Blogspots/Video_Streaming/Resources/img/login.png" class="img-fluid" alt="LOGO">
                                <h5 class="mt-5 mb-3">​Watch videos offline</h5>
                                <p class="mb-4">when an unknown printer took a galley of type and scrambled<br>
                                    it to make a type specimen book. It has survived not
                                    <br>
                                    only five centuries</p>
                            </div>
                        </div>
                        <div class="item">
                            <div class="carousel-login-card text-center">
                                <img src="/Projects/Blogspots/Video_Streaming/Resources/img/login.png" class="img-fluid" alt="LOGO">
                                <h5 class="mt-5 mb-3">Download videos effortlessly</h5>
                                <p class="mb-4">when an unknown printer took a galley of type and scrambled<br>
                                    it to make a type specimen book. It has survived not
                                    <br>
                                    only five centuries</p>
                            </div>
                        </div>
                        <div class="item">
                            <div class="carousel-login-card text-center">
                                <img src="/Projects/Blogspots/Video_Streaming/Resources/img/login.png" class="img-fluid" alt="LOGO">
                                <h5 class="mt-5 mb-3">Create GIFs</h5>
                                <p class="mb-4">when an unknown printer took a galley of type and scrambled<br>
                                    it to make a type specimen book. It has survived not
                                    <br>
                                    only five centuries</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
