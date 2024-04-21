<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_All_Register.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All.Pages.Classified_All_Register" %>
<%@ Register Src="~/Projects/Classifieds/Classified_All/Modules/Download.ascx" TagPrefix="uc1" TagName="Download" %>

<section class="breadcumb_area">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 text-center">
                <div class="breadcumb_section">
                    <div class="page_title">
                        <h3>Sign Up</h3>
                    </div>
                    <div class="page_pagination">
                        <ul>
                            <li><a href="<%= Url("Classified_All") %>">Home</a></li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>Sign Up</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Breadcumb -->

<!-- Login -->
<section class="login">
    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-sm-offset-4">
                <div class="login-panel widget">
                    <div class="login-body">
                        <form>
                            <div class="form-group">
                                <label class="control-label">Email <span class="required">*</span></label>
                                <input type="text" placeholder="Email Address" class="form-control">
                            </div>
                            <div class="form-group">
                                <label class="control-label">Password <span class="required">*</span></label>
                                <input type="password" placeholder="Password" class="form-control">
                            </div>
                            <div class="form-group">
                                <label class="control-label">Confirm Password <span class="required">*</span></label>
                                <input type="password" placeholder="Confirm Password" class="form-control">
                            </div>
                            <div class="form-group">
                                <button class="btn btn-block btn-lg btn-primary">Sign Up</button>
                            </div>
                        </form>
                    </div>
                    <div class="login-footer">
                        <div class="checkbox checkbox-primary pull-left">
                            <input id="checkbox2" type="checkbox">
                            <label for="checkbox2">
                                I Agree with Term and Conditions
                            </label>
                        </div>
                    </div>
                </div>
                <p class="text-center margin-bottom-none"><a href="<%= Url("Classified_All_Login") %>"><strong>Have an account? </strong></a></p>
            </div>
        </div>
    </div>
</section>
<!-- End Login -->
<uc1:Download runat="server" id="Download" />
