<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_All_Forgot.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All.Pages.Classified_All_Forgot" %>
<%@ Register Src="~/Projects/Classifieds/Classified_All/Modules/Download.ascx" TagPrefix="uc1" TagName="Download" %>

<section class="breadcumb_area">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 text-center">
                <div class="breadcumb_section">
                    <div class="page_title">
                        <h3>Reset Password</h3>
                    </div>
                    <div class="page_pagination">
                        <ul>
                            <li><a href="<%= Url("Classified_All") %>">Home</a></li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>Reset Password</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Breadcumb -->

<!-- Forgot Password -->
<section class="forgot-password">
    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-sm-offset-4">
                <div class="login-panel widget">
                    <div class="login-body">
                        <form>
                            <div class="form-group">
                                <label class="control-label">Email <span class="required">*</span></label>
                                <input type="text" placeholder="Your Email or Username" class="form-control">
                            </div>
                            <div class="form-group">
                                <button class="btn btn-block btn-lg btn-primary">Reset Password</button>
                            </div>
                        </form>
                    </div>
                </div>
                <p class="text-center margin-bottom-none">Don't have an account? <a href="<%= Url("Classified_All_Register") %>"><strong>Signup</strong></a></p>
            </div>
        </div>
    </div>
</section>
<!-- End Forgot Password -->
<uc1:Download runat="server" id="Download" />
