<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_All_Price.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All.Pages.Classified_All_Price" %>
<%@ Register Src="~/Projects/Classifieds/Classified_All/Modules/Download.ascx" TagPrefix="uc1" TagName="Download" %>

<section class="breadcumb_area">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 text-center">
                <div class="breadcumb_section">
                    <div class="page_title">
                        <h3>Pricing</h3>
                    </div>
                    <div class="page_pagination">
                        <ul>
                            <li><a href="<%= Url("Classified_All") %>">Home</a></li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>Pricing</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Breadcumb -->

<!-- pricing -->
<section class="pricing-table">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-default text-center basic-plan margin-bottom-none">
                    <div class="panel-heading">
                        <h3 class="panel-title">Silver</h3>
                    </div>
                    <div class="panel-body">
                        <div class="plan-price">
                            <div class="price-value">$49<span>.00</span></div>
                            <div class="interval">per month</div>
                        </div>
                    </div>
                    <ul class="list-group">
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>Free ad posting</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>6&nbsp;Featured ads availability</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>10GB Disk Space</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>100% Secure!</li>
                        <li class="list-group-item"><a href="<%= Url("Classified_All_Login") %>" class="btn btn-primary">Sign Up!</a></li>
                    </ul>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-primary text-center advanced-plan margin-bottom-none">
                    <div class="panel-heading">
                        <h3 class="panel-title">Advanced</h3>
                    </div>
                    <div class="panel-body">
                        <div class="plan-price">
                            <div class="price-value">$99<span>.00</span></div>
                            <div class="interval">per month</div>
                        </div>
                    </div>
                    <ul class="list-group">
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>Free ad posting</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>6&nbsp;Featured ads availability</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>10GB Disk Space</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>100% Secure! <a href="<%= Url("Classified_All_Login") %>" data-toggle="tooltip" data-placement="top" title="Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae,">&nbsp;<i class="fa fa-info-circle"></i></a></li>
                        <li class="list-group-item"><a href="<%= Url("Classified_All_Login") %>" class="btn btn-primary btn-lg">Sign Up!</a></li>
                    </ul>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default text-center basic-plan">
                    <div class="panel-heading">
                        <h3 class="panel-title">Professional</h3>
                    </div>
                    <div class="panel-body">
                        <div class="plan-price">
                            <div class="price-value">$199<span>.00</span></div>
                            <div class="interval">per month</div>
                        </div>
                    </div>
                    <ul class="list-group">
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>Free ad posting</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>6&nbsp;Featured ads availability</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>10GB Disk Space</li>
                        <li class="list-group-item"><i class="fa fa-check-square text-primary"></i>100% Secure!</li>
                        <li class="list-group-item"><a href="<%= Url("Classified_All_Login") %>" class="btn btn-primary">Sign Up!</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End pricing -->
<uc1:Download runat="server" id="Download" />
