﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_Land_MyProperties.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_Land.Pages.MyAccount.Home_Land_MyProperties" %>


<section class="tab-view">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <ul class="nav justify-content-center">
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_Land_Profile") %>">User Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active text-primary" href="<%= Url("Home_Land_MyProperties") %>">My Properties</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_Land_FavoriteProperties") %>">Favorite Properties</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_Land_AddProperty") %>">Add Property</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</section>
<!-- My Properties -->
<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <div class="card card-list card-list-view">
                            <a href="<%= Url("Home_Land_PropertyDetail") %>">
                                <div class="row no-gutters">
                                    <div class="col-lg-5 col-md-5">
                                        <span class="badge badge-success">For Sale</span>
                                        <img class="card-img-top" src="/Projects/Homes/Home_Land/Resources/img/list/1.png" alt="Card image cap">
                                    </div>
                                    <div class="col-lg-7 col-md-7">
                                        <div class="card-body">
                                            <span class="float-right text-primary"><i class="mdi mdi-table-edit"></i>Edit</span>
                                            <h5 class="card-title">House in Kent Street</h5>
                                            <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>127 Kent Sreet, Sydny, NEW 2000</h6>
                                            <h2 class="text-primary mb-0 mt-3">$130,000 <small>/month</small>
                                            </h2>
                                        </div>
                                        <div class="card-footer">
                                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>3</strong></span>
                                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>2</strong></span>
                                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>587 sq ft</strong></span>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12">
                        <div class="card card-list card-list-view">
                            <a href="<%= Url("Home_Land_PropertyDetail") %>">
                                <div class="row no-gutters">
                                    <div class="col-lg-5 col-md-5">
                                        <span class="badge badge-secondary">For Rent</span>
                                        <img class="card-img-top" src="/Projects/Homes/Home_Land/Resources/img/list/2.png" alt="Card image cap">
                                    </div>
                                    <div class="col-lg-7 col-md-7">
                                        <div class="card-body">
                                            <span class="float-right text-primary"><i class="mdi mdi-table-edit"></i>Edit</span>
                                            <h5 class="card-title">Family House in Hudson</h5>
                                            <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>Hoboken, NJ, USA</h6>
                                            <h2 class="text-primary mb-0 mt-3">$127,000 <small>/month</small>
                                            </h2>
                                        </div>
                                        <div class="card-footer">
                                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>5</strong></span>
                                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>3</strong></span>
                                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>300 sq ft</strong></span>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12">
                        <div class="card card-list card-list-view">
                            <a href="<%= Url("Home_Land_PropertyDetail") %>">
                                <div class="row no-gutters">
                                    <div class="col-lg-5 col-md-5">
                                        <span class="badge badge-danger">For Sale</span>
                                        <img class="card-img-top" src="/Projects/Homes/Home_Land/Resources/img/list/4.png" alt="Card image cap">
                                    </div>
                                    <div class="col-lg-7 col-md-7">
                                        <div class="card-body">
                                            <span class="float-right text-primary"><i class="mdi mdi-table-edit"></i>Edit</span>
                                            <h5 class="card-title">Store Space Greenville</h5>
                                            <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>250-260 3rd St, Hoboken, NJ 07030, USA</h6>
                                            <h2 class="text-primary mb-0 mt-3">$25,000 <small>/month</small>
                                            </h2>
                                        </div>
                                        <div class="card-footer">
                                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>6</strong></span>
                                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>4</strong></span>
                                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>987 sq ft</strong></span>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12">
                        <div class="card card-list card-list-view">
                            <a href="<%= Url("Home_Land_PropertyDetail") %>">
                                <div class="row no-gutters">
                                    <div class="col-lg-5 col-md-5">
                                        <span class="badge badge-warning">For Rent</span>
                                        <img class="card-img-top" src="/Projects/Homes/Home_Land/Resources/img/list/5.png" alt="Card image cap">
                                    </div>
                                    <div class="col-lg-7 col-md-7">
                                        <div class="card-body">
                                            <span class="float-right text-primary"><i class="mdi mdi-table-edit"></i>Edit</span>
                                            <h5 class="card-title">Villa in Melbourne</h5>
                                            <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>NJ 07305, USA</h6>
                                            <h2 class="text-primary mb-0 mt-3">$12,000 <small>/month</small>
                                            </h2>
                                        </div>
                                        <div class="card-footer">
                                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>8</strong></span>
                                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>4</strong></span>
                                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>120 sq ft</strong></span>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12">
                        <div class="card card-list card-list-view">
                            <a href="<%= Url("Home_Land_PropertyDetail") %>">
                                <div class="row no-gutters">
                                    <div class="col-lg-5 col-md-5">
                                        <span class="badge badge-info">For Rent</span>
                                        <img class="card-img-top" src="/Projects/Homes/Home_Land/Resources/img/list/6.png" alt="Card image cap">
                                    </div>
                                    <div class="col-lg-7 col-md-7">
                                        <div class="card-body">
                                            <span class="float-right text-primary"><i class="mdi mdi-table-edit"></i>Edit</span>
                                            <h5 class="card-title">Villa on Hollywood Boulev</h5>
                                            <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>The Village, Jersey City, NJ 07302, USA</h6>
                                            <h2 class="text-primary mb-0 mt-3">$356, 000 <small>/month</small>
                                            </h2>
                                        </div>
                                        <div class="card-footer">
                                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>1</strong></span>
                                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>3</strong></span>
                                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>187 sq ft</strong></span>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12">
                        <div class="card card-list card-list-view">
                            <a href="<%= Url("Home_Land_PropertyDetail") %>">
                                <div class="row no-gutters">
                                    <div class="col-lg-5 col-md-5">
                                        <span class="badge badge-success">For Sale</span>
                                        <img class="card-img-top" src="/Projects/Homes/Home_Land/Resources/img/list/3.png" alt="Card image cap">
                                    </div>
                                    <div class="col-lg-7 col-md-7">
                                        <div class="card-body">
                                            <span class="float-right text-primary"><i class="mdi mdi-table-edit"></i>Edit</span>
                                            <h5 class="card-title">Loft Above The City</h5>
                                            <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>Hope Street (Stop P), London SW11, UK</h6>
                                            <h2 class="text-primary mb-0 mt-3">$55,000 <small>/month</small>
                                            </h2>
                                        </div>
                                        <div class="card-footer">
                                            <span><i class="mdi mdi-sofa"></i>Beds : <strong>2</strong></span>
                                            <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>1</strong></span>
                                            <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>100 sq ft</strong></span>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <nav class="mt-5">
                    <ul class="pagination justify-content-center">
                        <li class="page-item disabled">
                            <a class="page-link" href="" tabindex="-1"><i class="mdi mdi-chevron-left"></i></a>
                        </li>
                        <li class="page-item active"><a class="page-link" href="">1</a></li>
                        <li class="page-item"><a class="page-link" href="">2</a></li>
                        <li class="page-item"><a class="page-link" href="">3</a></li>
                        <li class="page-item"><a class="page-link" href="">...</a></li>
                        <li class="page-item"><a class="page-link" href="">10</a></li>
                        <li class="page-item">
                            <a class="page-link" href=""><i class="mdi mdi-chevron-right"></i></a>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>
</section>
<!-- End My Properties -->
<!-- Join Team -->

