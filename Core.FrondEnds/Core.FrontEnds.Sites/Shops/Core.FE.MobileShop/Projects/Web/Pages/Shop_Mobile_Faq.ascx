<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Faq.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Faq" %>
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
      <section class="faq-page">
         <div class="container">
            <div class="section-header section-header-center text-center">
               <h3 class="heading-design-center-h3">
                  Frequently asked questions (FAQ)
               </h3>
               <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque<br> lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum. </p>
               <br>
            </div>
            <div class="row">
               <div class="col-lg-6 col-md-6">
                  <div class="widget">
                     <div id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="card">
                           <div class="card-header" role="tab" id="headingOne">
                              <h5 class="mb-0">
                                 <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                 <i class="icofont icofont-question-square"></i>   Where can I get access to Capital IQ? 
                                 </a>
                              </h5>
                           </div>
                           <div id="collapseOne" class="collapse show" role="tabpanel" aria-labelledby="headingOne">
                              <div class="card-body">
                                 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                              </div>
                           </div>
                        </div>
                        <div class="card">
                           <div class="card-header" role="tab" id="headingTwo">
                              <h5 class="mb-0">
                                 <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                 <i class="icofont icofont-question-square"></i> Where can I find market research reports? 
                                 </a>
                              </h5>
                           </div>
                           <div id="collapseTwo" class="collapse" role="tabpanel" aria-labelledby="headingTwo">
                              <div class="card-body">
                                 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                              </div>
                           </div>
                        </div>
                        <div class="card">
                           <div class="card-header" role="tab" id="headingThree">
                              <h5 class="mb-0">
                                 <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                 <i class="icofont icofont-question-square"></i> How do I get access to case studies? 
                                 </a>
                              </h5>
                           </div>
                           <div id="collapseThree" class="collapse" role="tabpanel" aria-labelledby="headingThree">
                              <div class="card-body">
                                 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                              </div>
                           </div>
                        </div>
                        <div class="card mb-0">
                           <div class="card-header" role="tab" id="headingThreeg">
                              <h5 class="mb-0">
                                 <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                 <i class="icofont icofont-question-square"></i>  How much should I capitalize?  
                                 </a>
                              </h5>
                           </div>
                           <div id="collapseThreeg" class="collapse" role="tabpanel" aria-labelledby="headingThreeg">
                              <div class="card-body">
                                 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
               <div class="col-lg-6 col-md-6">
                  <div class="widget">
                     <div class="section-header">
                        <h5 class="heading-design-h5">
                           Ask us question
                        </h5>
                     </div>
                     <form>
                        <div class="row">
                           <div class="col-sm-12">
                              <div class="form-group">
                                 <label class="control-label">Your Name <span class="required">*</span></label>
                                 <input class="form-control border-form-control" value="" placeholder="Enter Name" type="text">
                              </div>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-sm-6">
                              <div class="form-group">
                                 <label class="control-label">Email Address <span class="required">*</span></label>
                                 <input class="form-control border-form-control " value="" placeholder="ex@gmail.com" type="email">
                              </div>
                           </div>
                           <div class="col-sm-6">
                              <div class="form-group">
                                 <label class="control-label">Phone <span class="required">*</span></label>
                                 <input class="form-control border-form-control" value="" placeholder="Enter Phone" type="number">
                              </div>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-sm-12">
                              <div class="form-group">
                                 <label class="control-label">Your Message <span class="required">*</span></label>
                                 <textarea class="form-control border-form-control"></textarea>
                              </div>
                           </div>
                        </div>
                        <div class="row mt-1">
                           <div class="col-sm-12 text-right">
                              <button type="button" class="btn btn-success btn-lg"> Cencel </button>
                              <button type="button" class="btn btn-theme-round btn-lg"> Send Message </button>
                           </div>
                        </div>
                     </form>
                  </div>
               </div>
            </div>
         </div>
      </section>
<uc1:Top_Brands runat="server" id="Top_Brands" />
