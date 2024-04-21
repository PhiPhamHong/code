<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForSale.Controls.Header" %>

<div class="navbar-top bg-primary">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-4">
                <p>
                    Welcome To <strong>TEAM Design</strong> Property! 
                </p>
            </div>
            <div class="col-lg-8 col-md-8 text-right">
                <ul class="list-inline">
                    <li class="list-inline-item">
                        <a href=""><i class="mdi mdi-email-outline"></i>info@oproperty.com</a>
                    </li>
                    <li class="list-inline-item">
                        <a href=""><i class="mdi mdi-phone"></i>+1-123-456-7890</a>
                    </li>
                    <li class="list-inline-item">
                        <a href=""><i class="mdi mdi-headphones"></i>Contact Us</a>
                    </li>
                    <li class="list-inline-item">
                        <span>Download App</span> &nbsp;
                        <a href=""><i class="mdi mdi-windows"></i></a>
                        <a href=""><i class="mdi mdi-apple"></i></a>
                        <a href=""><i class="mdi mdi-android"></i></a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>

<header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container">
            <a class="navbar-brand text-success logo" href="<%= Url("Home_ForSale") %>">
                <img src="/Projects/Homes/Home_ForSale/Resources/img/logo.png" alt="osahan logo">
            </a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForSale") %>">Home</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Properties
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_Properties") %>">Properties</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_PropertyDetail") %>">Property Details</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Agency
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_Agencies") %>">Agency List</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_Trusted") %>">Trusted Agencies</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_AgencyProfile") %>">Agency Profile</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Blog
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_Blog") %>">Blogs</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_BlogDetail") %>">Blog Detail</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">My Account
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_Profile") %>">User Profile</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_MyProperties") %>">My Properties</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_FavoriteProperties") %>">Favorite Properties</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_AddProperty") %>">Add Property</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Pages
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_About") %>">About Us</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_FAQ") %>">FAQ</a>
                            <a class="dropdown-item" href="<%= Url("Home_ForSale_404") %>">404 Page</a>
                        </div>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_ForSale_Contact") %>">Contact</a>
                    </li>
                </ul>
                <div class="my-2 my-lg-0">
                    <ul class="list-inline main-nav-right">
                        <li class="list-inline-item">
                            <a class="btn btn btn-outline-primary btn-sm" href="<%= Url("Home_ForSale_Login") %>"><i class="mdi mdi-account-outline"></i>Sign In</a>
                        </li>
                        <li class="list-inline-item">
                            <a class="btn btn-primary btn-sm" href="<%= Url("Home_ForSale_Register") %>"><i class="mdi mdi-security-account"></i>Sign Up</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </nav>
</header>
