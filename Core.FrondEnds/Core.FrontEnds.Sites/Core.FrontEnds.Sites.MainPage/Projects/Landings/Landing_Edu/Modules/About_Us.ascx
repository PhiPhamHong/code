<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="About_Us.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Edu.Modules.About_Us" %>
<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/Features.ascx" TagPrefix="uc1" TagName="Features" %>


<section class="banner-block pb-0" id="banner">
    <div class="container">
        <div class="row">
            <div class="col-md-6 content z-index1">
                <h1 class="text-black">Courseo - Educational Coaching Template</h1>
                <p class="lead mb-5 text-black">Lorem ipsum dolor sit amet, mollis felis dapibus arcu donec viverra. Pede phasellus eget.</p>
                <p class="mb-0">
                    <button type="button" class="btn btn-success btn-lg">Read More</button>
                    <button type="button" class="btn btn-info btn-lg">Apply Demo</button>
                </p>
            </div>
            <div class="col-md-6 text-center z-index1">
                <div class="">
                    <img class="img-fluid wow fadeInUp radius25" src="/Projects/Landings/Landing_Edu/Resources/images/main.jpg" alt="">
                </div>
            </div>
        </div>
    </div>
</section>


<uc1:Features runat="server" ID="Features" />


<section id="about">
    <div class="container">
        <div class="section-title text-center">
            <span class="badge badge-success">About Us</span>
            <h2>A New Start</h2>
            <span class="section-title-line"></span>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <div class="container">
                    <img class="img-fluid wow fadeInUp radius25" src="/Projects/Landings/Landing_Edu/Resources/images/start2.jpg" alt="">
                </div>
            </div>
            <div class="col-md-6 content">
                <ul class="check-list">
                    <li><i class="fas fa-check"></i>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</li>
                    <li><i class="fas fa-check"></i>Maecenas eget ante non mauris vestibulum aliquet eu malesuada tellus.</li>
                    <li><i class="fas fa-check"></i>Quisque tincidunt ante id enim tempus scelerisque.</li>
                    <li><i class="fas fa-check"></i>Sed laoreet magna tincidunt, interdum felis vel, consectetur felis.</li>
                    <li><i class="fas fa-check"></i>In pharetra lorem sed turpis rhoncus, posuere porttitor tellus pretium.</li>
                    <li><i class="fas fa-check"></i>Nulla feugiat velit sodales, laoreet massa eget, semper urna.</li>
                    <li><i class="fas fa-check"></i>Integer at odio at arcu pharetra lobortis in interdum tortor.</li>
                    <li><i class="fas fa-check"></i>Morbi dapibus libero eget metus pulvinar mattis.</li>
                    <li><i class="fas fa-check"></i>Nunc vel ipsum a mauris viverra gravida.</li>
                </ul>
                <div><a href="index.htm#" class="btn btn-success btn-lg">Get Started Today</a></div>
            </div>
        </div>
    </div>
</section>
