<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForRent_AddProperty.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForRent.Pages.MyAccount.Home_ForRent_AddProperty" %>
<%@ Register Src="~/Projects/Homes/Home_ForRent/Modules/JoinTeam.ascx" TagPrefix="uc1" TagName="JoinTeam" %>

<section class="tab-view">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <ul class="nav justify-content-center">
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForRent_Profile") %>">User Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForRent_MyProperties") %>">My Properties</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForRent_FavoriteProperties") %>">Favorite Properties</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active text-success" href="<%= Url("Home_ForRent_AddProperty") %>">Add Property</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</section>
<!-- Add Property -->
<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto">
                <form>
                    <div class="card padding-card">
                        <div class="card-body">
                            <h5 class="card-title mb-4">Property Description</h5>
                            <div class="form-group">
                                <label>Property Title <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" placeholder="Enter Full Name">
                            </div>
                            <div class="form-group">
                                <label>Property Description <span class="text-danger">*</span></label>
                                <textarea class="form-control" rows="4"></textarea>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label>Type <span class="text-danger">*</span></label>
                                    <select class="form-control custom-select">
                                        <option>Select Type</option>
                                        <option>Type 1</option>
                                        <option>Type 2</option>
                                        <option>Type 3</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Status <span class="text-danger">*</span></label>
                                    <select class="form-control custom-select">
                                        <option>Select Status</option>
                                        <option>Type 1</option>
                                        <option>Type 2</option>
                                        <option>Type 3</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Location <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Location">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label>Bedrooms <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Bedrooms">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Bathrooms <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Bathrooms">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Floors <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Floors">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label>Garages <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Garages">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Area <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="sq ft">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Size <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="sq ft">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label>Sale of Rent Price <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Rent Price">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Before Price Label<span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Price Label">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>After Price Label <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Price Label">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label>Property ID <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Property ID">
                                </div>
                                <div class="form-group col-md-6">
                                    <label>Video URL</label>
                                    <input type="text" class="form-control" placeholder="Youtube, Vimeo, Dailymotion, etc...">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card property-features-add padding-card">
                        <div class="card-body">
                            <h5 class="card-title mb-4">Property Features</h5>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox">
                                        <label class="custom-control-label" for="osahan-checkbox">Center Cooling</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox1">
                                        <label class="custom-control-label" for="osahan-checkbox1">Fire Alarm</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox2">
                                        <label class="custom-control-label" for="osahan-checkbox2">Heating</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox3">
                                        <label class="custom-control-label" for="osahan-checkbox3">Gym</label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox4">
                                        <label class="custom-control-label" for="osahan-checkbox4">Balcony</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox5">
                                        <label class="custom-control-label" for="osahan-checkbox5">Modern Kitchen</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox6">
                                        <label class="custom-control-label" for="osahan-checkbox6">Pool</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox7">
                                        <label class="custom-control-label" for="osahan-checkbox7">Elevator</label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox8">
                                        <label class="custom-control-label" for="osahan-checkbox8">Dryer</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox9">
                                        <label class="custom-control-label" for="osahan-checkbox9">Sauna</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox10">
                                        <label class="custom-control-label" for="osahan-checkbox10">Dish Washer</label>
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="osahan-checkbox11">
                                        <label class="custom-control-label" for="osahan-checkbox12">Pet Frindly</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card padding-card">
                        <div class="card-body">
                            <h5 class="card-title mb-4">Property Gallery</h5>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="fuzone">
                                        <div class="fu-text">
                                            <span><i class="mdi mdi-image-area"></i>Click here or drop files to upload</span>
                                        </div>
                                        <input class="upload" type="file">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="fuzone">
                                        <div class="fu-text">
                                            <span><i class="mdi mdi-image-area"></i>Click here or drop files to upload</span>
                                        </div>
                                        <input class="upload" type="file">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="fuzone">
                                        <div class="fu-text">
                                            <span><i class="mdi mdi-image-area"></i>Click here or drop files to upload</span>
                                        </div>
                                        <input class="upload" type="file">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card padding-card">
                        <div class="card-body">
                            <h5 class="card-title mb-4">Property Location</h5>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label>Address <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Address">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Country<span class="text-danger">*</span></label>
                                    <select class="form-control custom-select">
                                        <option>Select Country</option>
                                        <option>Country 1</option>
                                        <option>Country 2</option>
                                        <option>Country 3</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>City <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter City">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label>State <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter State">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Zip/Postal Code <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="Enter Zip/Postal">
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Neighborhood <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" placeholder="...">
                                </div>
                            </div>
                            <div class="mt-3" id="map">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3501889.0795673826!2d73.15687918966267!3d31.00357561172526!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391964aa569e7355%3A0x8fbd263103a38861!2sPunjab!5e0!3m2!1sen!2sin!4v1503422781241" width="100%" height="450" frameborder="0" style="border: 0" allowfullscreen></iframe>
                            </div>
                        </div>
                    </div>
                    <button type="submit" class="btn btn-primary btn-lg">ADD PROPERTY</button>
                </form>
            </div>
        </div>
    </div>
</section>
<!-- End Add Property -->
<!-- Join Team -->
<uc1:JoinTeam runat="server" id="JoinTeam" />
