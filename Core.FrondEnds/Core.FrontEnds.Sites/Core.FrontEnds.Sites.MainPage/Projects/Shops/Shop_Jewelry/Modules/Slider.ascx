<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slider.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Jewelry.Modules.Slider" %>
<section class="carousel-slider-main text-center bg-white">
    <div class="owl-carousel owl-carousel-slider">
        <div class="item">
            <a href="<%= Url("Shop_Jewelry_Shop") %>">
                <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/slider/slider1.jpg" alt="First slide"></a>
        </div>
        <div class="item">
            <a href="<%= Url("Shop_Jewelry_Shop") %>">
                <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/slider/slider2.jpg" alt="First slide"></a>
        </div>
    </div>
</section>
