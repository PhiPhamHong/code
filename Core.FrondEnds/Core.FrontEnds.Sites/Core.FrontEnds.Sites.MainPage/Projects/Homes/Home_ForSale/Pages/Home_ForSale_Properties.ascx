<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForSale_Properties.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForSale.Pages.Home_ForSale_Properties" %>


<section class="osahan-slider">
    <div id="osahanslider" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#osahanslider" data-slide-to="0" class="active"></li>
            <li data-target="#osahanslider" data-slide-to="1"></li>
        </ol>
        <div class="carousel-inner" role="listbox">
            <div class="carousel-item active slider-one">
                <div class="overlay"></div>
            </div>
            <div class="carousel-item slider-two">
                <div class="overlay"></div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#osahanslider" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#osahanslider" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <div class="slider-form inner-page-form">
        <div class="container">
            <h1 class="text-left mb-5 text-white">Find Your Favorite Property</h1>
            <form>
                <div class="row no-gutters">
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="mdi mdi-map-marker-multiple"></i></div>
                            <select class="form-control select2" name="location">
                                <option disabled="" selected="">Any Location</option>
                                <option>Australia</option>
                                <option>Brazil</option>
                                <option>Cambodia</option>
                                <option>Dominica</option>
                                <option>France</option>
                                <option>Guyana</option>
                                <option>Hong Kong</option>
                                <option>Ireland</option>
                                <option>Japan</option>
                                <option>Malaysia</option>
                                <option>Nepal</option>
                                <option>Oman</option>
                                <option>Peru</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="mdi mdi-city"></i></div>
                            <select class="form-control select2" name="location">
                                <option disabled="" selected="">Any Status</option>
                                <option>Heigh </option>
                                <option>Midium</option>
                                <option>Normal</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="mdi mdi-home-modern"></i></div>
                            <select class="form-control select2" name="location">
                                <option disabled="" selected="">Any Type</option>
                                <option>Property Types</option>
                                <option value="">House/Villa</option>
                                <option value="">Flat</option>
                                <option value="">Plot/Land</option>
                                <option value="">Office Space</option>
                                <option value="">Shop/Showroom</option>
                                <option value="">Commercial Land</option>
                                <option value="">Warehouse/ Godown</option>
                                <option value="">Industrial Building</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="mdi mdi-hotel"></i></div>
                            <select class="form-control select2" name="location">
                                <option disabled="" selected="">Min. Bedrooms</option>
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                                <option>6</option>
                                <option>7</option>
                                <option>8</option>
                                <option>9</option>
                                <option>10</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="mdi mdi-magnify-minus-outline"></i></div>
                            <select class="form-control select2" name="location">
                                <option disabled="" selected="">Min Size</option>
                                <option>100</option>
                                <option>200</option>
                                <option>300</option>
                                <option>400</option>
                                <option>500</option>
                                <option>600</option>
                                <option>700</option>
                                <option>800</option>
                                <option>900</option>
                                <option>1000</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="mdi mdi-magnify-plus-outline"></i></div>
                            <select class="form-control select2" name="location">
                                <option disabled="" selected="">Max Size</option>
                                <option>1000</option>
                                <option>2000</option>
                                <option>3000</option>
                                <option>4000</option>
                                <option>5000</option>
                                <option>6000</option>
                                <option>7000</option>
                                <option>8000</option>
                                <option>9000</option>
                                <option>10000</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="mdi mdi-hot-tub"></i></div>
                            <select class="form-control select2" name="location">
                                <option disabled="" selected="">Baths</option>
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                                <option>6</option>
                                <option>7</option>
                                <option>8</option>
                                <option>9</option>
                                <option>10</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-6">
                        <div class="input-group">
                            <button type="submit" class="btn btn-secondary btn-block no-radius font-weight-bold">SEARCH</button>
                        </div>
                    </div>
                </div>
            </form>
            <div class="top-search">
                <strong class="text-white"><i class="mdi mdi-keyboard"></i>Top Search</strong>
                <a href="">Flat</a>
                <a href="">Plot/Land</a>
                <a href="">Office Space</a>
                <a href="">Shop/Showroom</a>
                <a href="">Commercial Land</a>
                <a href="">Warehouse/ Godown</a>
                <a href="">Industrial Building</a>
            </div>
        </div>
    </div>
</section>
<!-- End Main Slider With Form -->
<!-- Properties List -->
<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-3">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Property Type</h5>
                        <ul class="sidebar-card-list">
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>House/Villa <span class="sidebar-badge">90</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Flat <span class="sidebar-badge">60</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Plot/Land <span class="sidebar-badge">44</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Office Space <span class="sidebar-badge">38</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Shop/Showroom <span class="sidebar-badge">29</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Commercial Land <span class="sidebar-badge">28</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Warehouse/ Godown <span class="sidebar-badge">12</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Industrial Building <span class="sidebar-badge">8</span></a></li>
                        </ul>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body property-features-add">
                        <h5 class="card-title mb-3">Property Features</h5>
                        <div class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input" id="osahan-checkbox" checked>
                            <label class="custom-control-label" for="osahan-checkbox">Center Cooling</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input" id="osahan-checkbox1">
                            <label class="custom-control-label" for="osahan-checkbox1">Fire Alarm</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input" id="osahan-checkbox2" checked>
                            <label class="custom-control-label" for="osahan-checkbox2">Heating</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input" id="osahan-checkbox3">
                            <label class="custom-control-label" for="osahan-checkbox3">Gym</label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Property Status</h5>
                        <ul class="sidebar-card-list">
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>For Rent <span class="sidebar-badge">600</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>For Sale <span class="sidebar-badge">1200</span></a></li>
                        </ul>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Property By City</h5>
                        <ul class="sidebar-card-list">
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>New York <span class="sidebar-badge">220</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Los Angeles <span class="sidebar-badge">150</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Chicago <span class="sidebar-badge">100</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Houston <span class="sidebar-badge">50</span></a></li>
                            <li><a href=""><i class="mdi mdi-chevron-right"></i>Philadelphia <span class="sidebar-badge">23</span></a></li>
                        </ul>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title mb-4">Featured Properties</h5>
                        <div id="featured-properties" class="carousel slide" data-ride="carousel">
                            <ol class="carousel-indicators">
                                <li data-target="#featured-properties" data-slide-to="0" class="active"></li>
                                <li data-target="#featured-properties" data-slide-to="1"></li>
                            </ol>
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <div class="card card-list">
                                        <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                            <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/1.png" alt="Card image cap">
                                            <div class="card-body">
                                                <h5 class="card-title">House in Kent Street</h5>
                                                <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>127 Kent Sreet, Sydny</h6>
                                                <h2 class="text-primary mb-0 mt-3">$130,000 <small>/month</small>
                                                </h2>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                                <div class="carousel-item">
                                    <div class="card card-list">
                                        <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                            <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/2.png" alt="Card image cap">
                                            <div class="card-body">
                                                <h5 class="card-title">Family House in Hudson</h5>
                                                <h6 class="card-subtitle mb-2 text-muted"><i class="mdi mdi-home-map-marker"></i>Hoboken, NJ, USA</h6>
                                                <h2 class="text-primary mb-0 mt-3">$127,000 <small>/month</small>
                                                </h2>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-9">
                <div class="osahan_top_filter row">
                    <div class="col-lg-6 col-md-6 tags-action">
                        <span>Center Cooling <a href=""><i class="mdi mdi-window-close"></i></a></span>
                        <span>Heating <a href=""><i class="mdi mdi-window-close"></i></a></span>
                    </div>
                    <div class="col-lg-6 col-md-6 sort-by-btn float-right">
                        <div class="view-mode float-right">
                            <a class="active" href="properties-grid.html"><i class="mdi mdi-grid"></i></a><a href="properties-list.html"><i class="mdi mdi-format-list-bulleted"></i></a>
                        </div>
                        <div class="dropdown float-right">
                            <button class="btn btn-primary btn-sm dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="mdi mdi-filter"></i>Sort by 
                            </button>
                            <div class="dropdown-menu float-right" aria-labelledby="dropdownMenuButton">
                                <a class="dropdown-item" href=""><i class="mdi mdi-chevron-right"></i>Popularity </a>
                                <a class="dropdown-item" href=""><i class="mdi mdi-chevron-right"></i>New </a>
                                <a class="dropdown-item" href=""><i class="mdi mdi-chevron-right"></i>Discount </a>
                                <a class="dropdown-item" href=""><i class="mdi mdi-chevron-right"></i>Price: Low to High </a>
                                <a class="dropdown-item" href=""><i class="mdi mdi-chevron-right"></i>Price: High to Low </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>12</div>
                                    <span class="badge badge-primary">For Sale</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/1.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$130,000 <small>/Per Month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">House in Kent Street</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>127 Kent Sreet, Sydny</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>3</strong></span>
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>2</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>60</div>
                                    <span class="badge badge-secondary">For Rent</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/2.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$127,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Family House in Hudson</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>Hoboken, NJ, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>5</strong></span>
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>3</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>03</div>
                                    <span class="badge badge-success">For Sale</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/3.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$55,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Loft Above The City</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>Hope Street (Stop P), London</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>2</strong></span>
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>1</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>18</div>
                                    <span class="badge badge-danger">For Sale</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/4.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$25,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Store Space Greenville</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>260 Hoboken, NJ 07030, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>6</strong></span>
                                    <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>987 sq ft</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>04</div>
                                    <span class="badge badge-warning">For Rent</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/5.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$12,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Villa in Melbourne</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>NJ 07305, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>8</strong></span>
                                    <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>120 sq ft</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>45</div>
                                    <span class="badge badge-info">For Rent</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/6.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$356, 000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Villa on Hollywood Boulev</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>Jersey City, NJ 07302, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>3</strong></span>
                                    <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>187 sq ft</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>12</div>
                                    <span class="badge badge-primary">For Sale</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/1.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$130,000 <small>/Per Month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">House in Kent Street</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>127 Kent Sreet, Sydny</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>3</strong></span>
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>2</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>60</div>
                                    <span class="badge badge-secondary">For Rent</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/2.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$127,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Family House in Hudson</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>Hoboken, NJ, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>5</strong></span>
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>3</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>03</div>
                                    <span class="badge badge-success">For Sale</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/3.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$55,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Loft Above The City</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>Hope Street (Stop P), London</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>2</strong></span>
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>1</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>18</div>
                                    <span class="badge badge-danger">For Sale</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/4.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$25,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Store Space Greenville</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>260 Hoboken, NJ 07030, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>6</strong></span>
                                    <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>987 sq ft</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>04</div>
                                    <span class="badge badge-warning">For Rent</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/5.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$12,000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Villa in Melbourne</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>NJ 07305, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-sofa"></i>Beds : <strong>8</strong></span>
                                    <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>120 sq ft</strong></span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="card card-list">
                            <a href="<%= Url("Home_ForSale_PropertyDetail") %>">
                                <div class="card-img">
                                    <div class="love-badge text-danger"><i class="mdi mdi-heart-outline"></i></div>
                                    <div class="badge images-badge"><i class="mdi mdi-image-filter"></i>45</div>
                                    <span class="badge badge-info">For Rent</span>
                                    <img class="card-img-top" src="/Projects/Homes/Home_ForSale/Resources/img/list/6.png" alt="Card image cap">
                                </div>
                                <div class="card-body">
                                    <h2 class="text-primary mb-2 mt-0">$356, 000 <small>/month</small>
                                    </h2>
                                    <h5 class="card-title mb-2">Villa on Hollywood Boulev</h5>
                                    <h6 class="card-subtitle mt-1 mb-0 text-muted"><i class="mdi mdi-home-map-marker"></i>Jersey City, NJ 07302, USA</h6>
                                </div>
                                <div class="card-footer">
                                    <span><i class="mdi mdi-scale-bathroom"></i>Baths : <strong>3</strong></span>
                                    <span><i class="mdi mdi-move-resize-variant"></i>Area : <strong>187 sq ft</strong></span>
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
<!-- End Properties List -->
<!-- Join Team -->

