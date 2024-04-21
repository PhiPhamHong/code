﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Jewelry_Orderlist.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Jewelry.Pages.Profiles.Shop_Jewelry_Orderlist" %>
<section class="section-padding bg-dark inner-header">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <h1 class="mt-0 mb-3 text-white">Order List</h1>
                <div class="breadcrumbs">
                    <p class="mb-0 text-white"><a href="<%= Url("Shop_Jewelry") %>" class="text-white">Home</a>  /  <span class="text-success">Order List</span></p>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="account-page section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-9 mx-auto">
                <div class="row no-gutters">
                    <div class="col-md-4">
                        <div class="card account-left">
                            <div class="user-profile-header">
                                <img alt="logo" src="/Projects/Shops/Shop_Jewelry/Resources/img/user.jpg">
                                <h5 class="mb-1 text-secondary"><strong>Hi </strong>TEAM</h5>
                                <p>+91 8568079956</p>
                            </div>
                            <div class="list-group">
                                <a href="<%= Url("Shop_Jewelry_Profile") %>" class="list-group-item list-group-item-action"><i aria-hidden="true" class="mdi mdi-account-outline"></i>My Profile</a>
                                <a href="<%= Url("Shop_Jewelry_Address") %>" class="list-group-item list-group-item-action"><i aria-hidden="true" class="mdi mdi-map-marker-circle"></i>My Address</a>
                                <a href="<%= Url("Shop_Jewelry_Wishlist") %>" class="list-group-item list-group-item-action"><i aria-hidden="true" class="mdi mdi-heart-outline"></i>Wish List </a>
                                <a href="<%= Url("Shop_Jewelry_Orderlist") %>" class="list-group-item list-group-item-action active"><i aria-hidden="true" class="mdi mdi-format-list-bulleted"></i>Order List</a>
                                <a href="<%= Url("Shop_Jewelry") %>" class="list-group-item list-group-item-action"><i aria-hidden="true" class="mdi mdi-lock"></i>Logout</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="card card-body account-right">
                            <div class="widget">
                                <div class="section-header">
                                    <h5 class="heading-design-h5">Order List
                                    </h5>
                                </div>
                                <div class="order-list-tabel-main table-responsive">
                                    <table class="datatabel table table-striped table-bordered order-list-tabel" width="100%" cellspacing="0">
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
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#258</td>
                                                <td>July 21, 2017</td>
                                                <td><span class="badge badge-info">In Progress</span></td>
                                                <td>$315.20</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#254</td>
                                                <td>June 15, 2017</td>
                                                <td><span class="badge badge-warning">Delayed</span></td>
                                                <td>$1,264.00</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#293</td>
                                                <td>May 19, 2017</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>$198.35</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#266</td>
                                                <td>April 04, 2017</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>$598.35</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#277</td>
                                                <td>March 30, 2017</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>$98.35</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#243</td>
                                                <td>August 08, 2017</td>
                                                <td><span class="badge badge-danger">Canceled</span></td>
                                                <td>$760.50</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#258</td>
                                                <td>July 21, 2017</td>
                                                <td><span class="badge badge-info">In Progress</span></td>
                                                <td>$315.20</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#254</td>
                                                <td>June 15, 2017</td>
                                                <td><span class="badge badge-warning">Delayed</span></td>
                                                <td>$1,264.00</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#293</td>
                                                <td>May 19, 2017</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>$198.35</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#266</td>
                                                <td>April 04, 2017</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>$598.35</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                            <tr>
                                                <td>#277</td>
                                                <td>March 30, 2017</td>
                                                <td><span class="badge badge-success">Delivered</span></td>
                                                <td>$98.35</td>
                                                <td><a data-toggle="tooltip" data-placement="top" title="" href="#" data-original-title="View Detail" class="btn btn-info btn-sm"><i class="mdi mdi-eye"></i></a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
