<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Clother_About.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother.Pages.Shop_Clother_About" %>
<%@ Register Src="~/Projects/Shops/Shop_Clother/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="inner-about">
</div>
      <section class="about_page">
         <div class="container">
            <div class="row">
               <div class="col-lg-8 col-md-8 mx-auto">
                  <div class="widget widget-margin-top">
                     <div class="section-header section-header-center text-center">
                        <h5 class="text-primary">SINCE <b>1995</b></h5>
                        <h3 class="heading-design-center-h3">
                           About Osahan Fashion
                        </h3>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque<br> lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum. </p>
                        <br>
                     </div>
                     <div class="row">
                        <div class="col-lg-4 col-md-4">
                           <div class="about_page_widget widget">
                              <i class="icofont icofont-files"></i>
                              <h2>60 Million+</h2>
                              <h5>Products</h5>
                              <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                           </div>
                        </div>
                        <div class="col-lg-4 col-md-4">
                           <div class="about_page_widget widget">
                              <i class="icofont icofont-cart-alt"></i>
                              <h2>300,000</h2>
                              <h5>Sellers</h5>
                              <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                           </div>
                        </div>
                        <div class="col-lg-4 col-md-4">
                           <div class="about_page_widget widget">
                              <i class="icofont icofont-globe"></i>
                              <h2>6000+</h2>
                              <h5>Cities</h5>
                              <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </section>
      <section class="our-team-main">
         <div class="container">
            <div class="section-header section-header-center text-center">
               <h3 class="heading-design-center-h3">
                  Our Team
               </h3>
               <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque<br> lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum. </p>
               <br>
            </div>
            <div class="row">
               <div class="col-lg-8 col-md-8 mx-auto">
                  <div class="row">
                     <div class="col-lg-4 col-md-4">
                        <div class="our-team widget">
                           <div class="team_img">
                              <img src="/Projects/Shops/Shop_Clother/Resources/images/men/small/2.jpg">
                              <ul class="social">
                                 <li><a href=""><i class="fa fa-facebook"></i></a></li>
                                 <li><a href=""><i class="fa fa-twitter"></i></a></li>
                                 <li><a href=""><i class="fa fa-linkedin"></i></a></li>
                                 <li><a href=""><i class="fa fa-google-plus"></i></a></li>
                              </ul>
                           </div>
                           <div class="team-content">
                              <h3 class="title">Osahan</h3>
                              <span class="post">CEO</span>
                           </div>
                        </div>
                     </div>
                     <div class="col-lg-4 col-md-4">
                        <div class="our-team widget">
                           <div class="team_img">
                              <img src="/Projects/Shops/Shop_Clother/Resources/images/men/small/1.jpg">
                              <ul class="social">
                                 <li><a href=""><i class="fa fa-facebook"></i></a></li>
                                 <li><a href=""><i class="fa fa-twitter"></i></a></li>
                                 <li><a href=""><i class="fa fa-linkedin"></i></a></li>
                                 <li><a href=""><i class="fa fa-google-plus"></i></a></li>
                              </ul>
                           </div>
                           <div class="team-content">
                              <h3 class="title">Jon Sam</h3>
                              <span class="post">web developer</span>
                           </div>
                        </div>
                     </div>
                     <div class="col-lg-4 col-md-4">
                        <div class="our-team widget">
                           <div class="team_img">
                              <img src="/Projects/Shops/Shop_Clother/Resources/images/men/small/4.jpg">
                              <ul class="social">
                                 <li><a href=""><i class="fa fa-facebook"></i></a></li>
                                 <li><a href=""><i class="fa fa-twitter"></i></a></li>
                                 <li><a href=""><i class="fa fa-linkedin"></i></a></li>
                                 <li><a href=""><i class="fa fa-google-plus"></i></a></li>
                              </ul>
                           </div>
                           <div class="team-content">
                              <h3 class="title">Deep Shan</h3>
                              <span class="post">Marketing Manager</span>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
