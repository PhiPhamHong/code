<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_Streaming_404.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Video_Streaming.Pages.Video_Streaming_404" %>
<div class="container-fluid">
    <div class="row">
        <div class="col-md-8 mx-auto text-center  pt-4 pb-5">
            <h1>
                <img alt="404" src="/Projects/Blogspots/Video_Streaming/Resources/img/404.png" class="img-fluid"></h1>
            <h1>Sorry! Page not found.</h1>
            <p class="land">Unfortunately the page you are looking for has been moved or deleted.</p>
            <div class="mt-5">
                <a class="btn btn-outline-primary" href="<%= Url("Video_Streaming") %>"><i class="mdi mdi-home"></i>BACK TO HOME PAGE</a>
            </div>
        </div>
    </div>
</div>
