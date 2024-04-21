﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForRent_Register.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForRent.Pages.Home_ForRent_Register" %>
<%@ Register Src="~/Projects/Homes/Home_ForRent/Modules/JoinTeam.ascx" TagPrefix="uc1" TagName="JoinTeam" %>

<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-5 col-md-5 mx-auto">
                <div class="card padding-card">
                    <div class="card-body">
                        <h5 class="card-title mb-4">Register</h5>
                        <form>
                            <div class="form-group">
                                <label>Full Name <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Enter Full Name">
                            </div>
                            <div class="form-group">
                                <label>Mobile Number <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Enter Mobile Number">
                            </div>
                            <div class="form-group">
                                <label>Email Address <span class="text-danger">*</span></label>
                                <input type="email" class="form-control" placeholder="Enter Email Address">
                            </div>
                            <div class="form-group">
                                <label>Password <span class="text-danger">*</span></label>
                                <input type="email" class="form-control" placeholder="Enter Password">
                            </div>
                            <div class="form-group">
                                <div class="custom-control custom-checkbox">
                                    <input type="checkbox" class="custom-control-input" id="customControlAutosizing">
                                    <label class="custom-control-label" for="customControlAutosizing">I agree with all <a href="<%= Url("Home_ForRent_Terms") %>">Terms & Conditions</a></label>
                                </div>
                            </div>
                            <button type="submit" class="btn btn-primary btn-lg btn-block">REGISTER</button>
                        </form>
                        <div class="mt-4 text-center login-with-social">
                            <button type="button" class="btn btn-facebook btn-block"><i class="mdi mdi-facebook"></i>Login With Facebook</button>
                            <button type="button" class="btn btn-twitter btn-block"><i class="mdi mdi-twitter"></i>Login With Twitter</button>
                            <button type="button" class="btn btn-google btn-block"><i class="mdi mdi-google-plus"></i>Login With Google</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Register -->
<!-- Join Team -->
<uc1:JoinTeam runat="server" id="JoinTeam" />