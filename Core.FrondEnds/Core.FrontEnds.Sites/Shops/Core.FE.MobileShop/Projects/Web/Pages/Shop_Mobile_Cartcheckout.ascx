<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Cartcheckout.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Cartcheckout" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



<div class="osahan-breadcrumb">
         <div class="container">
            <div class="row">
               <div class="col-lg-12 col-md-12">
                  <ol class="breadcrumb">
                     <li class="breadcrumb-item"><a href=""><i class="icofont icofont-ui-home"></i> Home</a></li>
                     <li class="breadcrumb-item"><a href="">Pages</a></li>
                     <li class="breadcrumb-item active">Page Name</li>
                  </ol>
               </div>
            </div>
         </div>
      </div>
      <section class="shopping_cart_page">
         <div class="container">
            <div class="row">
               <div class="col-lg-12 col-md-12">
                  <div class="checkout-step mb-40">
                     <ul>
                        <li>
                           <a href="<%= Url("Shop_Mobile_Cart_delivery") %>">
                              <div class="step">
                                 <div class="line"></div>
                                 <div class="circle">1</div>
                              </div>
                              <span>Shipping</span>
                           </a>
                        </li>
                        <li>
                           <a href="<%= Url("Shop_Mobile_Cart_order") %>">
                              <div class="step">
                                 <div class="line"></div>
                                 <div class="circle">2</div>
                              </div>
                              <span>Order Overview</span>
                           </a>
                        </li>
                        <li class="active">
                           <a href="<%= Url("Shop_Mobile_Cartcheckout") %>">
                              <div class="step">
                                 <div class="line"></div>
                                 <div class="circle">3</div>
                              </div>
                              <span>Payment</span>
                           </a>
                        </li>
                        <li>
                           <a href="<%= Url("Shop_Mobile_Cart_done") %>">
                              <div class="step">
                                 <div class="line"></div>
                                 <div class="circle">4</div>
                              </div>
                              <span>Order Complete</span>
                           </a>
                        </li>
                     </ul>
                  </div>
               </div>
               <div class="col-lg-8 col-md-8 mx-auto">
                  <div class="widget">
                     <div class="section-header section-header-center text-center">
                        <h3 class="heading-design-center-h3">
                           Select a payment method
                        </h3>
                     </div>
                     <form class="col-lg-8 col-md-8 mx-auto">
                        <div class="payment-menthod text-center">
                           <ul>
                              <li><a class="active" href=""><i class="icofont icofont-paypal-alt"></i></a>
                              </li>
                              <li><a href=""><i class="icofont icofont-visa-alt"></i></a>
                              </li>
                              <li><a href=""><i class="icofont icofont-mastercard-alt"></i></a>
                              </li>
                              <li><a href=""><i class="icofont icofont-google-wallet-alt-1"></i></a>
                              </li>
                              <li><a href=""><i class="icofont icofont-american-express-alt"></i></a>
                              </li>
                           </ul>
                        </div>
                        <div class="form-group">
                           <label class="control-label">Card Number</label>
                           <input class="form-control border-form-control" value="" placeholder="0000 0000 0000 0000" type="text">
                        </div>
                        <div class="row">
                           <div class="col-sm-3">
                              <div class="form-group">
                                 <label class="control-label">Month</label>
                                 <input class="form-control border-form-control" value="" placeholder="01" type="text">
                              </div>
                           </div>
                           <div class="col-sm-3">
                              <div class="form-group">
                                 <label class="control-label">Year</label>
                                 <input class="form-control border-form-control" value="" placeholder="15" type="text">
                              </div>
                           </div>
                           <div class="col-sm-3">
                           </div>
                           <div class="col-sm-3">
                              <div class="form-group">
                                 <label class="control-label">CVV</label>
                                 <input class="form-control border-form-control" value="" placeholder="135" type="text">
                              </div>
                           </div>
                        </div>
                        <hr>
                        <label class="custom-control custom-radio">
                        <input id="radioStacked3" name="radio-stacked" class="custom-control-input" type="radio">
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description"><strong>Would you like to pay by Cash on Delivery?</strong></span>
                        </label>
                        <p>Vestibulum semper accumsan nisi, at blandit tortor maxi'mus in phasellus malesuada sodales odio, at dapibus libero malesuada quis.</p>
                        <a href="<%= Url("Shop_Mobile_Cart_done") %>" class="btn btn-theme-round btn-lg pull-right">NEXT</a>
                     </form>
                  </div>
               </div>
            </div>
         </div>
      </section>
<uc1:Top_Brands runat="server" id="Top_Brands" />
