<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Login.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Login" %>
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
      <section class="login_page">
         <div class="container">
            <div class="row">
               <div class="col-lg-6 col-md-6 mx-auto">
                  <div class="widget">
                     <div class="login-modal-right">
                        <!-- Tab panes -->
                        <div class="tab-content">
                           <div class="tab-pane active" id="login" role="tabpanel">
                              <h5 class="heading-design-h5">Login to your account</h5>
                              <fieldset class="form-group">
                                 <label>Enter Email/Mobile number</label>
                                 <input type="text" class="form-control" placeholder="+91 123 456 7890">
                              </fieldset>
                              <fieldset class="form-group">
                                 <label>Enter Password</label>
                                 <input type="password" class="form-control" placeholder="********">
                              </fieldset>
                              <fieldset class="form-group">
                                 <button type="submit" class="btn btn-lg btn-theme-round btn-block">Enter to your account</button>
                              </fieldset>
                              <div class="login-with-sites text-center">
                                 <p>or Login with your social profile:</p>
                                 <button class="btn-facebook login-icons btn-lg"><i class="fab fa-facebook"></i> Facebook</button>
                                 <button class="btn-google login-icons btn-lg"><i class="fab fa-google"></i> Google</button>
                                 <button class="btn-twitter login-icons btn-lg"><i class="fab fa-twitter"></i> Twitter</button>
                              </div>
                              <p><label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                 <input type="checkbox" class="custom-control-input">
                                 <span class="custom-control-indicator"></span>
                                 <span class="custom-control-description">Remember me </span>
                                 </label>
                              </p>
                           </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="text-center login-footer-tab">
                           <ul class="nav nav-tabs" role="tablist">
                              <li class="nav-item">
                                 <a class="nav-link active" href="<%= Url("Shop_Mobile_Login") %>"><i class="icofont icofont-lock"></i> LOGIN</a>
                              </li>
                              <li class="nav-item">
                                 <a class="nav-link" href="<%= Url("Shop_Mobile_Register") %>"><i class="icofont icofont-pencil-alt-5"></i> REGISTER</a>
                              </li>
                           </ul>
                        </div>
                        <div class="clearfix"></div>
                     </div>
                  </div>
                  <br><br>
                  <div class="text-center">		
                     <a class="btn btn-theme-round" data-toggle="modal" data-target="#bd-example-modal" href=""><i class="icofont icofont-shopping-cart"></i> Login Modal (CLICK HERE)</a>
                  </div>
               </div>
            </div>
         </div>
      </section>
<uc1:Top_Brands runat="server" id="Top_Brands" />
