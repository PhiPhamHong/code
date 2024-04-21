<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForSale_Profile.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForSale.Pages.MyAccount.Home_ForSale_Profile" %>


<section class="tab-view">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <ul class="nav justify-content-center">
                    <li class="nav-item">
                        <a class="nav-link active text-success" href="<%= Url("Home_ForSale_Profile") %>">User Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForSale_MyProperties") %>">My Properties</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForSale_FavoriteProperties") %>">Favorite Properties</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForSale_AddProperty") %>">Add Property</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</section>
<!-- User Profile -->

<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto">
                <form>
                    <div class="card padding-card">
                        <div class="card-body">
                            <h5 class="card-title mb-4">Personal Details</h5>
                            <div class="form-group">
                                <label>First Name <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Enter First Name">
                            </div>
                            <div class="form-group">
                                <label>Last Name <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Enter Last Name">
                            </div>
                            <div class="form-group">
                                <label>Email Address <span class="text-danger">*</span></label>
                                <input type="email" class="form-control" placeholder="Enter Email Address">
                            </div>
                            <div class="form-group">
                                <label>Phone <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Enter Phone">
                            </div>
                            <div class="form-group">
                                <label>Location <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Enter Locations">
                            </div>
                            <div class="form-group">
                                <label>About Me <span class="text-danger">*</span></label>
                                <textarea rows="10" cols="100" class="form-control"></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="card padding-card">
                        <div class="card-body">
                            <h5 class="card-title mb-4">Social Profiles</h5>
                            <div class="form-group">
                                <label>Facebook</label>
                                <input type="text" class="form-control" placeholder="Facebook URL">
                            </div>
                            <div class="form-group">
                                <label>Twitter</label>
                                <input type="text" class="form-control" placeholder="@Username">
                            </div>
                            <div class="form-group">
                                <label>Google+</label>
                                <input type="email" class="form-control" placeholder="">
                            </div>
                            <div class="form-group">
                                <label>Linkedin <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Linkedin URL">
                            </div>
                            <div class="form-group">
                                <label>Instagram <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="@Username">
                            </div>
                        </div>
                    </div>
                    <div class="card padding-card">
                        <div class="card-body">
                            <h5 class="card-title mb-4">Change Password</h5>
                            <div class="form-group">
                                <label>Password <span class="text-danger">*</span></label>
                                <input type="password" class="form-control" placeholder="">
                            </div>
                            <div class="form-group">
                                <label>Confirm Password <span class="text-danger">*</span></label>
                                <input type="password" class="form-control" placeholder="">
                            </div>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary btn-lg">SAVE EDITS</button>
                </form>
            </div>
        </div>
    </div>
</section>
<!-- End User Profile -->
<!-- Join Team -->

