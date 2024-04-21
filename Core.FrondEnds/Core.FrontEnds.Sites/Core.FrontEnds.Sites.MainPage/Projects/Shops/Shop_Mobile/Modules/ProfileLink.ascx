<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileLink.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Modules.ProfileLink" %>
<div class="dropdown-menu dropdown-menu-right dropdown-list-design">
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Profile") %>"><i class="icofont icofont-ui-user"></i>My Profile</a>
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Address") %>"><i class="icofont icofont-location-pin"></i>My Address</a>
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Wishlist_user") %>"><i class="icofont icofont-heart-alt"></i>Wish List <span class="badge badge-success">6</span></a>
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Orderlist") %>"><i class="icofont icofont-list"></i>Order List</a>
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Orderstatus") %>"><i class="icofont icofont-truck-loaded"></i>Order Status</a>
    <div class="dropdown-divider"></div>
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Login") %>"><i class="icofont icofont-logout"></i>Logout</a>
</div>
