﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_Streaming_Subcriptions.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Video_Streaming.Pages.Video_Streaming_Subcriptions" %>
<%@ Register Src="~/Projects/Blogspots/Video_Streaming/Modules/Channels.ascx" TagPrefix="uc1" TagName="Channels" %>

<div class="container-fluid">
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
                    <h6>Subscriptions</h6>
                </div>
            </div>
            <uc1:Channels runat="server" id="Channels" />
            <uc1:Channels runat="server" id="Channels1" />
            <uc1:Channels runat="server" id="Channels2" />
            <uc1:Channels runat="server" id="Channels3" />
        </div>
        <nav aria-label="Page navigation example">
            <ul class="pagination justify-content-center pagination-sm mb-0">
                <li class="page-item disabled">
                    <a class="page-link" href="#" tabindex="-1">Previous</a>
                </li>
                <li class="page-item active"><a class="page-link" href="#">1</a></li>
                <li class="page-item"><a class="page-link" href="#">2</a></li>
                <li class="page-item"><a class="page-link" href="#">3</a></li>
                <li class="page-item">
                    <a class="page-link" href="#">Next</a>
                </li>
            </ul>
        </nav>
    </div>
</div>
