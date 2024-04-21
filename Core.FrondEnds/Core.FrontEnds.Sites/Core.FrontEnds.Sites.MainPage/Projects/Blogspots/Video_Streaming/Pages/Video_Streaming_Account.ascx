<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_Streaming_Account.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Video_Streaming.Pages.Video_Streaming_Account" %>
<%@ Register Src="~/Projects/Blogspots/Video_Streaming/Modules/Channels.ascx" TagPrefix="uc1" TagName="Channels" %>
<%@ Register Src="~/Projects/Blogspots/Video_Streaming/Modules/Videos.ascx" TagPrefix="uc1" TagName="Videos" %>


<div class="container-fluid pb-0">
    <div class="row">
        <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-primary o-hidden h-100 border-none">
                <div class="card-body">
                    <div class="card-body-icon">
                        <i class="fas fa-fw fa-users"></i>
                    </div>
                    <div class="mr-5"><b>26</b> Channels</div>
                </div>
                <a class="card-footer text-white clearfix small z-1" href="#">
                    <span class="float-left">View Details</span>
                    <span class="float-right">
                        <i class="fas fa-angle-right"></i>
                    </span>
                </a>
            </div>
        </div>
        <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-warning o-hidden h-100 border-none">
                <div class="card-body">
                    <div class="card-body-icon">
                        <i class="fas fa-fw fa-video"></i>
                    </div>
                    <div class="mr-5"><b>156</b> Videos</div>
                </div>
                <a class="card-footer text-white clearfix small z-1" href="#">
                    <span class="float-left">View Details</span>
                    <span class="float-right">
                        <i class="fas fa-angle-right"></i>
                    </span>
                </a>
            </div>
        </div>
        <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-success o-hidden h-100 border-none">
                <div class="card-body">
                    <div class="card-body-icon">
                        <i class="fas fa-fw fa-list-alt"></i>
                    </div>
                    <div class="mr-5"><b>123</b> Categories</div>
                </div>
                <a class="card-footer text-white clearfix small z-1" href="#">
                    <span class="float-left">View Details</span>
                    <span class="float-right">
                        <i class="fas fa-angle-right"></i>
                    </span>
                </a>
            </div>
        </div>
        <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-danger o-hidden h-100 border-none">
                <div class="card-body">
                    <div class="card-body-icon">
                        <i class="fas fa-fw fa-cloud-upload-alt"></i>
                    </div>
                    <div class="mr-5"><b>13</b> New Videos</div>
                </div>
                <a class="card-footer text-white clearfix small z-1" href="#">
                    <span class="float-left">View Details</span>
                    <span class="float-right">
                        <i class="fas fa-angle-right"></i>
                    </span>
                </a>
            </div>
        </div>
    </div>
    <hr>
    <div class="video-block section-padding">
        <div class="row">
            <div class="col-md-12">
                <div class="main-title">
                    <div class="btn-group float-right right-action">
                        <a href="#" class="right-action-link text-gray" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Sort by <i class="fa fa-caret-down" aria-hidden="true"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <a class="dropdown-item" href="#"><i class="fas fa-fw fa-star"></i>&nbsp; Top Rated</a>
                            <a class="dropdown-item" href="#"><i class="fas fa-fw fa-signal"></i>&nbsp; Viewed</a>
                            <a class="dropdown-item" href="#"><i class="fas fa-fw fa-times-circle"></i>&nbsp; Close</a>
                        </div>
                    </div>
                    <h6>My Videos</h6>
                </div>
            </div>
            <uc1:Videos runat="server" id="Videos" />
        </div>
    </div>
    <hr class="mt-0">
    <div class="video-block section-padding">
        <div class="row">
            <div class="col-md-12">
                <div class="main-title">
                    <div class="btn-group float-right right-action">
                        <a href="#" class="right-action-link text-gray" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Sort by <i class="fa fa-caret-down" aria-hidden="true"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <a class="dropdown-item" href="#"><i class="fas fa-fw fa-star"></i>&nbsp; Top Rated</a>
                            <a class="dropdown-item" href="#"><i class="fas fa-fw fa-signal"></i>&nbsp; Viewed</a>
                            <a class="dropdown-item" href="#"><i class="fas fa-fw fa-times-circle"></i>&nbsp; Close</a>
                        </div>
                    </div>
                    <h6>My Channels</h6>
                </div>
            </div>
            <uc1:Channels runat="server" id="Channels" />
            <uc1:Channels runat="server" id="Channels1" />
        </div>
    </div>
</div>
