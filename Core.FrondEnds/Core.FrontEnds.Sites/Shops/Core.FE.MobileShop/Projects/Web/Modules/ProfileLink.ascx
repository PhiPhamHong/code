<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileLink.ascx.cs" Inherits="Core.FE.MobileShop.Modules.ProfileLink" %>
<div class="dropdown-menu dropdown-menu-right dropdown-list-design">
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Profile") %>"><i class="icofont icofont-ui-user"></i>My Profile</a>
    <a class="dropdown-item" href="<%= Url("Shop_Mobile_Orderlist") %>"><i class="icofont icofont-list"></i>Order List</a>
    <div class="dropdown-divider"></div>
    <a class="dropdown-item" data-cmd="Logout" href=""><i class="icofont icofont-logout"></i>Logout</a>
</div>
