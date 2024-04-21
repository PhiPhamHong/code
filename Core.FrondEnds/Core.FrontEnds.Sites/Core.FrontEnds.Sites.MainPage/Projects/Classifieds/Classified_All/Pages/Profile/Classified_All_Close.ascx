<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_All_Close.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All.Pages.Profile.Classified_All_Close" %>
<section class="profile-breadcumb">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 text-left">
                <div class="breadcumb_section">
                    <div class="page_pagination">
                        <ul>
                            <li><a href="<%= Url("Classified_All") %>"><i class="fa fa-home"></i>Home</a></li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>My Account</li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>Close Account</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Breadcumb -->

<!-- Close Account -->
<section class="close-account">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <div class="widget profile-widget margin-bottom-none">
                    <div class="widget-body">
                        <div class="avatar">
                            <a class="btn-icon" title="" data-placement="left" data-toggle="tooltip" href="" data-original-title="Edit">
                                <i class="fa fa-camera"></i>
                            </a>
                            <img class="profile-dp" alt="User Image" src="/Projects/Classifieds/Classified_All/Resources/images/user.jpg">
                        </div>
                        <div class="profile-info">
                            <h2 class="seller-name">John Doe</h2>
                            <p class="seller-detail">Joined : <strong>21 June 2017</strong></p>
                        </div>
                        <div class="list-group">
                            <a class="list-group-item" href="<%= Url("Classified_All_MyAds") %>">
                                <span class="label label-info">15</span>
                                <i class="fa fa-fw fa-pencil"></i>My Ads
                            </a>
                            <a class="list-group-item" href="<%= Url("Classified_All_Favourites") %>">
                                <span class="label label-success">10</span>
                                <i class="fa fa-fw fa-heart"></i>Favourite Ads
                            </a>
                            <a class="list-group-item" href="<%= Url("Classified_All_Alert") %>">
                                <i class="fa fa-fw fa-clock-o"></i>Ad Alerts
                            </a>
                            <a class="list-group-item" href="<%= Url("Classified_All_Settings") %>">
                                <i class="fa fa-fw fa-gear"></i>Settings
                            </a>
                            <a class="list-group-item" href="<%= Url("Classified_All_Close") %>">
                                <i class="fa fa-fw fa-cog"></i>Close Account
                            </a>
                            <a class="list-group-item" href="<%= Url("Classified_All_Login") %>">
                                <i class="fa fa-fw fa-power-off"></i>Log Out
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-9">
                <div class="widget my-profile margin-bottom-none">
                    <div class="widget-header">
                        <h1>Close account </h1>
                    </div>
                    <div class="widget-body">
                        <form class="row">
                            <div class="form-group">
                                <label class="col-sm-12 control-label">You are sure you want to close your account? <span class="required">*</span></label>
                                <div class="col-sm-12">
                                    <div class="radio radio-info radio-inline">
                                        <input type="radio" checked="" name="radioInline" value="option1" id="inlineRadio1">
                                        <label for="inlineRadio1">Yes </label>
                                    </div>
                                    <div class="radio radio-info radio-inline">
                                        <input type="radio" name="radioInline" value="option1" id="inlineRadio2">
                                        <label for="inlineRadio2">No </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <button class="btn btn-success" type="submit"><i class="fa fa-save"></i>Submit</button>
                                    <button class="btn btn-danger" type="submit"><i class="fa fa-close"></i>Cancel</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Close Account -->
