<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Vegetable_404NotFound.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Vegetable.Pages.Shop_Vegetable_404NotFound" %>
<section class="not-found-page section-padding">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto text-center  pt-4 pb-5">
                <h1>
                    <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/404.png" alt="404"></h1>
                <h1>Sorry! Page not found.</h1>
                <p class="land">Unfortunately the page you are looking for has been moved or deleted.</p>
                <div class="mt-5">
                    <a href="<%= Url("Shop_Vegetable") %>" class="btn btn-success btn-lg"><i class="mdi mdi-home"></i>GO TO HOME PAGE</a>
                </div>
            </div>
        </div>
    </div>
</section>
