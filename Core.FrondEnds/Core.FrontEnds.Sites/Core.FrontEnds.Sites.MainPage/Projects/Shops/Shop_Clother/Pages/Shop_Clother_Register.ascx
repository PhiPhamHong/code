<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Clother_Register.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother.Pages.Shop_Clother_Register" %>
<%@ Register Src="~/Projects/Shops/Shop_Clother/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="<%= Url("Shop_Clother") %>"><i class="icofont icofont-ui-home"></i>Home</a></li>
                    <li class="breadcrumb-item active">Register</li>
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
                            <div class="tab-pane active" id="register" role="tabpanel">
                                <h5 class="heading-design-h5">Register Now!</h5>
                                <fieldset class="form-group">
                                    <label for="formGroupExampleInput">Enter Email/Mobile number</label>
                                    <input type="text" class="form-control" id="formGroupExampleInput" placeholder="+91 123 456 7890">
                                </fieldset>
                                <fieldset class="form-group">
                                    <label for="formGroupExampleInput2">Enter Password</label>
                                    <input type="password" class="form-control" id="formGroupExampleInput2" placeholder="********">
                                </fieldset>
                                <fieldset class="form-group">
                                    <label for="formGroupExampleInput3">Enter Confirm Password </label>
                                    <input type="password" class="form-control" id="formGroupExampleInput3" placeholder="********">
                                </fieldset>
                                <fieldset class="form-group">
                                    <button type="submit" class="btn btn-lg btn-theme-round btn-block">Create Your Account</button>
                                </fieldset>
                                <p>
                                    <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
                                        <input type="checkbox" class="custom-control-input">
                                        <span class="custom-control-indicator"></span>
                                        <span class="custom-control-description">I Agree with Term and Conditions  </span>
                                    </label>
                                </p>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="text-center login-footer-tab">
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link" href="<%= Url("Shop_Clother_Login") %>""><i class="icofont icofont-lock"></i>LOGIN</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link active" href="<%= Url("Shop_Clother_Login") %>""><i class="icofont icofont-pencil-alt-5"></i>REGISTER</a>
                                </li>
                            </ul>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" id="Top_Brands" />
