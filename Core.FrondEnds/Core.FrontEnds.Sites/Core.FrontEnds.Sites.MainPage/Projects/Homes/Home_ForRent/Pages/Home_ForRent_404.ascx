<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForRent_404.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForRent.Pages.Home_ForRent_404" %>
<%@ Register Src="~/Projects/Homes/Home_ForRent/Modules/JoinTeam.ascx" TagPrefix="uc1" TagName="JoinTeam" %>

<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto text-center">
                <h1>
                    <img class="img-fluid" src="/Projects/Homes/Home_ForRent/Resources/img/404.png" alt="404"></h1>
                <h1>Sorry! Page not found.</h1>
                <p class="land">Unfortunately the page you are looking for has been moved or deleted.</p>
                <div class="mt-5">
                    <a href="<%= Url("Home_ForRent") %>" class="btn btn-secondary btn-lg"><i class="mdi mdi-home"></i>GO TO HOME PAGE</a>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End 404 Page -->
<!-- Join Team -->

<uc1:JoinTeam runat="server" id="JoinTeam" />
