<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Orderlist.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Pages.Shop_Mobile_Orderlist" %>
<%@ Register Src="~/Projects/Shops/Shop_Mobile/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href=""><i class="icofont icofont-ui-home"></i>Home</a></li>
                    <li class="breadcrumb-item"><a href="">Pages</a></li>
                    <li class="breadcrumb-item active">Page Name</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="shopping_cart_page">
    <h6 class="sr-only"></h6>
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-5">
                <div class="user-account-sidebar">
                    <aside class="user-info-wrapper">
                        <div class="user-cover" style="background-image: url(/Projects/Shops/Shop_Mobile/Resources/images/user-cover-img.jpg);">
                            <div class="info-label" data-toggle="tooltip" title="" data-original-title="Verified Account"><i class="icofont icofont-check-circled"></i></div>
                        </div>
                        <div class="user-info">
                            <div class="user-avatar"><a class="edit-avatar" href=""><i class="icofont icofont-edit"></i></a>
                                <img src="/Projects/Shops/Shop_Mobile/Resources/images/user-ava.jpg" alt="User"></div>
                            <div class="user-data">
                                <h4>Osahan Singh</h4>
                                <span><i class="icofont icofont-ui-calendar"></i>Joined February 06, 2017</span>
                            </div>
                        </div>
                    </aside>
                    <nav class="list-group">
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Profile") %>"><i class="icofont icofont-ui-user fa-fw"></i>My Profile</a>
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Address") %>"><i class="icofont icofont-location-pin fa-fw"></i>My Address</a>
                        <a class="list-group-item justify-content-between" href="<%= Url("Shop_Mobile_Wishlist_user") %>"><span><i class="icofont icofont-heart-alt fa-fw"></i>Wish List</span> <span class="badge badge-danger">35 Items</span></a>
                        <a class="list-group-item active justify-content-between" href="<%= Url("Shop_Mobile_Orderlist") %>"><span><i class="icofont icofont-list fa-fw"></i>Order List</span> <span class="badge badge-warning">6 Items</span></a>
                        <a class="list-group-item justify-content-between" href="<%= Url("Shop_Mobile_Orderstatus") %>"><span><i class="icofont icofont-truck-loaded fa-fw"></i>Order Status</span> <span class="badge badge-success">4</span></a>
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Login") %>"><i class="icofont icofont-logout fa-fw"></i>Logout</a>
                    </nav>
                </div>
                <div class="left-ad mt-4">
                    <img class="rounded img-fluid" src="http://via.placeholder.com/350x100" alt="">
                </div>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-7">
                <div class="widget">
                    <div class="section-header">
                        <h5 class="heading-design-h5">Order List
                        </h5>
                    </div>
                    <div class="order-list-tabel-main">
                        <table class="datatabel table table-striped table-bordered order-list-tabel table-responsive">
                            <thead>
                                <tr>
                                    <th>Order #</th>
                                    <th>Date Purchased</th>
                                    <th>Status</th>
                                    <th>Total</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>#243</td>
                                    <td>August 08, 2017</td>
                                    <td><span class="badge badge-danger">Canceled</span></td>
                                    <td>$760.50</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#258</td>
                                    <td>July 21, 2017</td>
                                    <td><span class="badge badge-info">In Progress</span></td>
                                    <td>$315.20</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#254</td>
                                    <td>June 15, 2017</td>
                                    <td><span class="badge badge-warning">Delayed</span></td>
                                    <td>$1,264.00</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#293</td>
                                    <td>May 19, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$198.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#266</td>
                                    <td>April 04, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$598.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#277</td>
                                    <td>March 30, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$98.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#243</td>
                                    <td>August 08, 2017</td>
                                    <td><span class="badge badge-danger">Canceled</span></td>
                                    <td>$760.50</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#258</td>
                                    <td>July 21, 2017</td>
                                    <td><span class="badge badge-info">In Progress</span></td>
                                    <td>$315.20</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#254</td>
                                    <td>June 15, 2017</td>
                                    <td><span class="badge badge-warning">Delayed</span></td>
                                    <td>$1,264.00</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#293</td>
                                    <td>May 19, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$198.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#266</td>
                                    <td>April 04, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$598.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#277</td>
                                    <td>March 30, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$98.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("Shop_Mobile_Shop_details") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
