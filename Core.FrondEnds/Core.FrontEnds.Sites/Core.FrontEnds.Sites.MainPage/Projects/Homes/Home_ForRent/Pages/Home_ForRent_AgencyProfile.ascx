<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForRent_AgencyProfile.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForRent.Pages.Home_ForRent_AgencyProfile" %>
<%@ Register Src="~/Projects/Homes/Home_ForRent/Modules/JoinTeam.ascx" TagPrefix="uc1" TagName="JoinTeam" %>

<section class="section-padding bg-dark inner-header">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <h1 class="mt-0 mb-3">Agency Profile</h1>
                <div class="breadcrumbs">
                    <p class="mb-0"><a href="<%= Url("Home_ForRent") %>"><i class="mdi mdi-home-outline"></i>Home</a> / Agency Profile</p>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Inner Header -->
<!-- Agency Profile -->
<section class="section-padding bg-white">
    <div class="container">
        <div class="row">
            <div class="col-lg-5 col-md-5">
                <img class="rounded img-fluid" src="/Projects/Homes/Home_ForRent/Resources/img/agent.jpg" alt="Card image cap">
            </div>
            <div class="col-lg-7 col-md-7">
                <h2 class="mt-2 mb-2">Modern House</h2>
                <h6 class="text-primary mb-3">
                    <i class="mdi mdi-home-map-marker"></i>
                    127 Kent Sreet, Sydny, NEW 2000
                </h6>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum.lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum. </p>
                <div class="row mt-3">
                    <div class="col-lg-6 col-md-6">
                        <p><strong class="text-dark">Phone :</strong> +91 12345-67890</p>
                        <p><strong class="text-dark">Mobile :</strong> (+20) 220 145 6589</p>
                        <p><strong class="text-dark">Email :</strong> iamosahan@gmail.com</p>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <p><strong class="text-dark">Website :</strong> www.askbootstrap.com</p>
                        <p><strong class="text-dark">Properties Listed :</strong> 15</p>
                        <p><strong class="text-dark">License  :</strong> RE511U0</p>
                    </div>
                </div>
                <div class="footer-social">
                    <span>Follow : </span>
                    <a class="btn-facebook" href=""><i class="mdi mdi-facebook"></i></a>
                    <a class="btn-twitter" href=""><i class="mdi mdi-twitter"></i></a>
                    <a class="btn-instagram" href=""><i class="mdi mdi-instagram"></i></a>
                    <a class="btn-whatsapp" href=""><i class="mdi mdi-whatsapp"></i></a>
                    <a class="btn-messenger" href=""><i class="mdi mdi-facebook-messenger"></i></a>
                    <a class="btn-google" href=""><i class="mdi mdi-google"></i></a>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Agency Profile -->
<!-- My Properties -->
<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 section-title text-left mb-4">
                <h2>My Properties</h2>
            </div>
            <div class="col-lg-4 col-md-4">
                <div class="card card-list">
                    <a href="<%= Url("Home_ForRent_PropertyDetail") %>">
                        <div class="card-img">
                            <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                            <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>18</div>
                            <span class="badge badge-danger">For Sale</span>
                            <img class="card-img-top" src="/Projects/Homes/Home_ForRent/Resources/img/list/4.png" alt="Card image cap">
                        </div>
                        <div class="card-body">
                            <h2 class="text-primary mb-2 mt-0">$25,000 <small>/month</small>
                            </h2>
                            <h5 class="card-title mb-2">Store Space Greenville</h5>
                            <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>250-260 3rd St, Hoboken, NJ 07030, USA</h6>
                        </div>
                        <div class="card-footer">
                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>6</strong></span>
                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>4</strong></span>
                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>987 sq ft</strong></span>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-lg-4 col-md-4">
                <div class="card card-list">
                    <a href="<%= Url("Home_ForRent_PropertyDetail") %>">
                        <div class="card-img">
                            <div class="love-badge text-danger"><i class="mdi mdi-heart"></i></div>
                            <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>04</div>
                            <span class="badge badge-warning">For Rent</span>
                            <img class="card-img-top" src="/Projects/Homes/Home_ForRent/Resources/img/list/5.png" alt="Card image cap">
                        </div>
                        <div class="card-body">
                            <h2 class="text-primary mb-2 mt-0">$12,000 <small>/month</small>
                            </h2>
                            <h5 class="card-title mb-2">Villa in Melbourne</h5>
                            <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>NJ 07305, USA</h6>
                        </div>
                        <div class="card-footer">
                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>8</strong></span>
                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>4</strong></span>
                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>120 sq ft</strong></span>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-lg-4 col-md-4">
                <div class="card card-list">
                    <a href="<%= Url("Home_ForRent_PropertyDetail") %>">
                        <div class="card-img">
                            <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                            <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>45</div>
                            <span class="badge badge-info">For Rent</span>
                            <img class="card-img-top" src="/Projects/Homes/Home_ForRent/Resources/img/list/6.png" alt="Card image cap">
                        </div>
                        <div class="card-body">
                            <h2 class="text-primary mb-2 mt-0">$356, 000 <small>/month</small>
                            </h2>
                            <h5 class="card-title mb-2">Villa on Hollywood Boulev</h5>
                            <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>The Village, Jersey City, NJ 07302, USA</h6>
                        </div>
                        <div class="card-footer">
                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>1</strong></span>
                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>3</strong></span>
                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>187 sq ft</strong></span>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End My Properties -->
<!-- Contact Me -->
<section class="section-padding  bg-white">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 section-title text-left mb-4">
                <h2>Contact Me</h2>
            </div>
            <form class="col-lg-12 col-md-12" name="sentMessage">
                <div class="row">
                    <div class="control-group form-group col-lg-4 col-md-4">
                        <div class="controls">
                            <label>Your Name <span class="text-danger">*</span></label>
                            <input type="text" class="form-control" required>
                        </div>
                    </div>
                    <div class="control-group form-group col-lg-4 col-md-4">
                        <div class="controls">
                            <label>Email Address <span class="text-danger">*</span></label>
                            <input type="email" class="form-control" required>
                        </div>
                    </div>
                    <div class="control-group form-group col-lg-4 col-md-4">
                        <div class="controls">
                            <label>Phone Number <span class="text-danger">*</span></label>
                            <input type="email" class="form-control" required>
                        </div>
                    </div>
                </div>
                <div class="control-group form-group">
                    <div class="controls">
                        <label>Message <span class="text-danger">*</span></label>
                        <textarea rows="10" cols="100" class="form-control"></textarea>
                    </div>
                </div>
                <button type="submit" class="btn btn-secondary btn-lg">Send Message</button>
            </form>
        </div>
    </div>
</section>
<!-- End Contact Me -->
<!-- Join Team -->
<uc1:JoinTeam runat="server" id="JoinTeam" />
