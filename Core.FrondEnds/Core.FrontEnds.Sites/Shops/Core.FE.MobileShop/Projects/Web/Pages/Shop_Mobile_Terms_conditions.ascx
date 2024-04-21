<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Terms_conditions.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Terms_conditions" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>


<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href=""><i class="icofont icofont-ui-home"></i>Home</a></li>
                    <li class="breadcrumb-item"><a href="">Pages</a></li>
                    <li class="breadcrumb-item active">Page Name</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="blog_page">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <div class="widget">
                    <div class="section-header">
                        <h5 class="heading-design-h5">Terms and Conditions  
                        </h5>
                    </div>
                    <p class="lead">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus risus nisl, fringilla vitae orci non, mollis dapibus dui.</p>
                    <hr>
                    <p class="h5">User Account, Password, and Security: </p>
                    <p>Vivamus luctus egestas convallis. Vestibulum arcu sapien, consequat a urna a, gravida molestie est. Mauris iaculis felis id elit laoreet, vitae blandit odio lacinia. Etiam viverra arcu lobortis semper posuere. Curabitur mattis a erat at ultricies. Duis ac porta est, non rhoncus orci. Sed venenatis, nunc sit amet eleifend consequat, nibh leo laoreet purus, id pretium purus quam quis magna. Nullam mollis velit eu velit congue, quis facilisis tortor vestibulum. Sed malesuada nibh vitae neque pulvinar pretium. Nullam fermentum aliquet metus ac sollicitudin. </p>
                    <hr>
                    <p class="h5">User Conduct and Rules:  </p>
                    <p>Donec sit amet convallis est. Morbi molestie, est sed viverra vehicula, ligula sem egestas urna, vel porta erat purus nec quam. Nunc ac iaculis sem. Aenean varius augue quam, et fringilla turpis porta mollis. Pellentesque quis cursus erat, a molestie neque. Fusce sed magna eu purus rhoncus fermentum. Cras non arcu ac metus volutpat varius. Duis id eros ac felis sodales ornare. </p>
                    <p>Duis eu massa diam. Donec in porta tortor, in pharetra velit. Nunc at justo convallis, tempor tortor non, tempus mauris. Integer tristique nisl hendrerit, rhoncus odio a, semper risus. Integer vehicula tempus porttitor.</p>
                    <hr>
                    <p class="h5">Delivery: </p>
                    <p class="mb-0">sit amet condimentum massa turpis vel nisl. Suspendisse lobortis lorem mollis, sodales magna non, eleifend neque. Vestibulum vulputate nibh et lacus luctus venenatis. Mauris pulvinar ultrices libero, interdum convallis urna dapibus sed. Sed libero ligula, ultricies non pharetra at, ullamcorper sed quam. </p>
                </div>
            </div>
            <div class="col-md-3">
                <div class="widget blog-sidebar mb18">
                    <div class="sidebar-widget">
                        <ul class="widget-post">
                            <li>
                                <a href="<%= Url("Shop_Mobile_Blog_single") %>" class="widget-post-media">
                                    <img src="/Projects/Web/Resources/images/blog/blog-01.jpg" alt="alt">
                                </a>
                                <div class="widget-post-info">
                                    <h6><a href="">Veritatis et quasi</a></h6>
                                    <span class="entry-meta"><i class="icofont icofont-ui-user"></i>by Olivia Reyes &nbsp; <i class="icofont icofont-calendar"></i>June 16, 2019</span>
                                </div>
                            </li>
                            <li>
                                <a href="<%= Url("Shop_Mobile_Blog_single") %>" class="widget-post-media">
                                    <img src="/Projects/Web/Resources/images/blog/blog-02.jpg" alt="alt">
                                </a>
                                <div class="widget-post-info">
                                    <h6><a href="">Sed fringilla mauris</a></h6>
                                    <span class="entry-meta"><i class="icofont icofont-ui-user"></i>by Jon Beyes &nbsp; <i class="icofont icofont-calendar"></i>March 10, 2019</span>
                                </div>
                            </li>
                            <li>
                                <a href="<%= Url("Shop_Mobile_Blog_single") %>" class="widget-post-media">
                                    <img src="/Projects/Web/Resources/images/blog/blog-03.jpg" alt="alt">
                                </a>
                                <div class="widget-post-info">
                                    <h6><a href="">Harum quidem rerum</a></h6>
                                    <span class="entry-meta"><i class="icofont icofont-ui-user"></i>by Osahan Singh &nbsp; <i class="icofont icofont-calendar"></i>June 27, 2019</span>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
