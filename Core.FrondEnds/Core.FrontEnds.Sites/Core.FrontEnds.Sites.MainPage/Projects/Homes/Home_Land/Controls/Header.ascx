﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_Land.Controls.Header" %>



<header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container">
            <a class="navbar-brand text-success logo" href="<%= Url("Home_Land") %>">
                <img src="/Projects/Homes/Home_Land/Resources/img/logo.png" alt="osahan logo">
            </a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0 margin-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_Land") %>">Home</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Properties
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_Land_Properties") %>">Properties</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_PropertyDetail") %>">Property Details</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Agency
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_Land_Agencies") %>">Agency List</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_Trusted") %>">Trusted Agencies</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_AgencyProfile") %>">Agency Profile</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Blog
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_Land_Blog") %>">Blogs</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_BlogDetail") %>">Blog Detail</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">My Account
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_Land_Profile") %>">User Profile</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_MyProperties") %>">My Properties</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_FavoriteProperties") %>">Favorite Properties</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_AddProperty") %>">Add Property</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="" id="navbarDropdownPortfolio" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Pages
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownPortfolio">
                            <a class="dropdown-item" href="<%= Url("Home_Land_About") %>">About Us</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_FAQ") %>">FAQ</a>
                            <a class="dropdown-item" href="<%= Url("Home_Land_404") %>">404 Page</a>
                        </div>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= Url("Home_Land_Contact") %>">Contact</a>
                    </li>
                </ul>
                <div class="my-2 my-lg-0">
                    <ul class="list-inline main-nav-right">
                        <li class="list-inline-item">
                            <a class="btn btn btn-outline-primary btn-sm" href="<%= Url("Home_Land_Login") %>"><i class="mdi mdi-account-outline"></i>Sign In</a>
                        </li>
                        <li class="list-inline-item">
                            <a class="btn btn-primary btn-sm" href="<%= Url("Home_Land_Register") %>"><i class="mdi mdi-security-account"></i>Sign Up</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </nav>
</header>
