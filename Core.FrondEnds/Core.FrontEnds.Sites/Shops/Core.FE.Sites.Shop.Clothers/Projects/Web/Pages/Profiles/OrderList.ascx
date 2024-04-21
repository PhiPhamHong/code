<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderList.ascx.cs" Inherits="Core.FE.Sites.Shop.Clothers.Projects.Web.Pages.Profiles.OrderList" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="<%= Url("Home") %>"><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                    <li class="breadcrumb-item"><a href="<%= Url("Profile") %>">Cá nhân</a></li>
                    <li class="breadcrumb-item active">Đơn hàng</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="shopping_cart_page">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-5">
                <div class="user-account-sidebar">
                    <aside class="user-info-wrapper">
                        <div class="user-cover" style="background-image: url(/Projects/Web/Resources/images/user-cover-img.jpg);">
                            <div class="info-label" data-toggle="tooltip" title="" data-original-title="Verified Account"><i class="icofont icofont-check-circled"></i></div>
                        </div>
                        <div class="user-info">
                            <div class="user-avatar"><a class="edit-avatar" href=""><i class="icofont icofont-edit"></i></a>
                                <img src="/Projects/Web/Resources/images/user-ava.jpg" alt="User"></div>
                            <div class="user-data">
                                <h4>Osahan Singh</h4>
                                <span><i class="icofont icofont-ui-calendar"></i>Joined February 06, 2017</span>
                            </div>
                        </div>
                    </aside>
                    <nav class="list-group">
                        <a class="list-group-item" href="<%= Url("Profile") %>"><i class="icofont icofont-ui-user fa-fw"></i>My Profile</a>
                        <a class="list-group-item active" href="<%= Url("Address") %>"><i class="icofont icofont-location-pin fa-fw"></i>My Address</a>
                        <a class="list-group-item justify-content-between" href="<%= Url("WishList") %>"><span><i class="icofont icofont-heart-alt fa-fw"></i>Wish List</span> <span class="badge badge-danger">35 Items</span></a>
                        <a class="list-group-item justify-content-between" href="<%= Url("OrderList") %>"><span><i class="icofont icofont-list fa-fw"></i>Order List</span> <span class="badge badge-warning">6 Items</span></a>
                        <a class="list-group-item" href="<%= Url("Login") %>"><i class="icofont icofont-logout fa-fw"></i>Logout</a>
                    </nav>
                </div>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-7">
                <div class="widget">
                    <div class="section-header">
                        <h5 class="heading-design-h5">Order List
                        </h5>
                    </div>
                    <div class="order-list-tabel-main">
                        <table class="datatabel table table-striped table-bordered order-list-tabel table-responsive" width="100%" cellspacing="0">
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
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#258</td>
                                    <td>July 21, 2017</td>
                                    <td><span class="badge badge-info">In Progress</span></td>
                                    <td>$315.20</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#254</td>
                                    <td>June 15, 2017</td>
                                    <td><span class="badge badge-warning">Delayed</span></td>
                                    <td>$1,264.00</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#293</td>
                                    <td>May 19, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$198.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#266</td>
                                    <td>April 04, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$598.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#277</td>
                                    <td>March 30, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$98.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#243</td>
                                    <td>August 08, 2017</td>
                                    <td><span class="badge badge-danger">Canceled</span></td>
                                    <td>$760.50</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#258</td>
                                    <td>July 21, 2017</td>
                                    <td><span class="badge badge-info">In Progress</span></td>
                                    <td>$315.20</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#254</td>
                                    <td>June 15, 2017</td>
                                    <td><span class="badge badge-warning">Delayed</span></td>
                                    <td>$1,264.00</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#293</td>
                                    <td>May 19, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$198.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#266</td>
                                    <td>April 04, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$598.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                </tr>
                                <tr>
                                    <td>#277</td>
                                    <td>March 30, 2017</td>
                                    <td><span class="badge badge-success">Delivered</span></td>
                                    <td>$98.35</td>
                                    <td><a data-toggle="tooltip" data-placement="top" title="" href="<%= Url("ProductDetails") %>" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
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
