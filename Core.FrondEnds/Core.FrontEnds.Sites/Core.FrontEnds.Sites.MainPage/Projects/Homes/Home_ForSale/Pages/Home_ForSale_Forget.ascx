<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForSale_Forget.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForSale.Pages.Home_ForSale_Forget" %>


<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-4 mx-auto">
                <div class="card padding-card">
                    <div class="card-body">
                        <h5 class="card-title mb-4">Reset Password</h5>
                        <form>
                            <div class="form-group">
                                <label>Email address <span class="text-danger">*</span></label>
                                <input type="email" class="form-control" placeholder="Your Email or Username">
                            </div>
                            <button type="submit" class="btn btn-primary btn-lg btn-block">RESET PASSWORD</button>
                        </form>
                        <div class="mt-4 text-center">
                            Don't have an account? <a href="<%= Url("Home_ForSale_Register") %>">Register</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Login -->
<!-- Join Team -->

