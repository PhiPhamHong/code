<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Video_Streaming.Controls.Header" %>
<%if (Show == true) %>
<%{ %>
<ul class="sidebar navbar-nav">
    <li class="nav-item active">
        <a class="nav-link" href="<%= Url("Video_Streaming") %>">
            <i class="fas fa-fw fa-home"></i>
            <span>Home</span>
        </a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="<%= Url("Video_Streaming_Channels") %>">
            <i class="fas fa-fw fa-users"></i>
            <span>Channels</span>
        </a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="<%= Url("Video_Streaming_Single_Channel") %>">
            <i class="fas fa-fw fa-user-alt"></i>
            <span>Single Channel</span>
        </a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="<%= Url("Video_Streaming_Videos") %>">
            <i class="fas fa-fw fa-video"></i>
            <span>Video Page</span>
        </a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="<%= Url("Video_Streaming_Uploading") %>">
            <i class="fas fa-fw fa-cloud-upload-alt"></i>
            <span>Upload Video</span>
        </a>
    </li>
    <li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <i class="fas fa-fw fa-folder"></i>
            <span>Pages</span>
        </a>
        <div class="dropdown-menu">
            <h6 class="dropdown-header">Login Screens:</h6>
            <a class="dropdown-item" href="<%= Url("Video_Streaming_Login") %>">Login</a>
            <a class="dropdown-item" href="<%= Url("Video_Streaming_Register") %>">Register</a>
            <a class="dropdown-item" href="<%= Url("Video_Streaming_ForgotPass") %>">Forgot Password</a>
            <div class="dropdown-divider"></div>
            <h6 class="dropdown-header">Other Pages:</h6>
            <a class="dropdown-item" href="<%= Url("Video_Streaming_Blogs") %>">Blog</a>
            <a class="dropdown-item" href="<%= Url("Video_Streaming_BlogDetail") %>">Blog Detail</a>
            <a class="dropdown-item" href="<%= Url("Video_Streaming_404") %>">404 Page</a>
            <a class="dropdown-item" href="<%= Url("Video_Streaming_Contact") %>">Contact</a>
        </div>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="<%= Url("Video_Streaming_Histories") %>">
            <i class="fas fa-fw fa-history"></i>
            <span>History Page</span>
        </a>
    </li>

    <li class="nav-item channel-sidebar-list">
        <h6>SUBSCRIPTIONS</h6>
        <ul>
            <li>
                <a href="<%= Url("Video_Streaming_Subcriptions") %>">
                    <img class="img-fluid" alt="" src="/Projects/Blogspots/Video_Streaming/Resources/img/s1.png">
                    Your Life 
                     </a>
            </li>
            <li>
                <a href="<%= Url("Video_Streaming_Subcriptions") %>">
                    <img class="img-fluid" alt="" src="/Projects/Blogspots/Video_Streaming/Resources/img/s2.png">
                    Unboxing  <span class="badge badge-warning">2</span>
                </a>
            </li>
            <li>
                <a href="<%= Url("Video_Streaming_Subcriptions") %>">
                    <img class="img-fluid" alt="" src="/Projects/Blogspots/Video_Streaming/Resources/img/s3.png">
                    Product / Service  
                     </a>
            </li>
            <li>
                <a href="<%= Url("Video_Streaming_Subcriptions") %>">
                    <img class="img-fluid" alt="" src="/Projects/Blogspots/Video_Streaming/Resources/img/s4.png">
                    Gaming 
                     </a>
            </li>
        </ul>
    </li>
</ul>
<%} %>