<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Orderlist.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Orderlist" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="/trang-chu"><i class="icofont icofont-ui-home"></i>Home</a></li>
                    <li class="breadcrumb-item active">Đơn hàng của bạn</li>
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
                        <div class="user-cover" style="background-image: url(/Projects/Web/Resources/images/user-cover-img.jpg);">
                            <div class="info-label" data-toggle="tooltip" title="" data-original-title="Verified Account"><i class="icofont icofont-check-circled"></i></div>
                        </div>
                        <div class="user-info">
                            <div class="user-avatar"><a class="edit-avatar" href=""><i class="icofont icofont-edit"></i></a>
                                <img src="/Projects/Web/Resources/images/apple-icon.png" alt="User"></div>
                            <div class="user-data">
                                <h4><%= Cus.Name %></h4>
                                <span><i class="icofont icofont-ui-calendar"></i><%= Cus.CreatedDate.ToString("dd/MM/yyyy") %></span>
                            </div>
                        </div>
                    </aside>
                    <nav class="list-group">
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Profile") %>"><i class="icofont icofont-ui-user fa-fw"></i>My Profile</a>
                        <a class="list-group-item active justify-content-between" href="<%= Url("Shop_Mobile_Orderlist") %>"><span><i class="icofont icofont-list fa-fw"></i>Order List</span> <span class="badge badge-warning">6 Items</span></a>
                    </nav>
                </div>
                <div class="left-ad mt-4">
                    <img class="rounded img-fluid" src="http://via.placeholder.com/350x100" alt="">
                </div>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-7">
                <div class="widget">
                    <div class="section-header">
                        <h5 class="heading-design-h5">Danh sách đơn hàng đã mua
                        </h5>
                    </div>
                    <div class="order-list-tabel-main">
                        <table class="datatabel table table-striped table-bordered order-list-tabel table-responsive">
                            <thead>
                                <tr>
                                    <th style="min-width:200px;">Mã Đơn #</th>
                                    <th>Ngày đặt</th>
                                    <th>Trạng thái</th>
                                    <th>Tổng tiền</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpOrders">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("Code") %></td>
                                            <td><%# Eval("CreatedDate") %></td>
                                            <td><span class="badge badge-info">In Progress</span></td>
                                            <td><%# Eval("Amount","{0:0,0}") %></td>
                                            <td><a data-toggle="tooltip" data-placement="top" title="Xem chi tiết" href="" data-original-title="View Detail" class="btn btn-theme-round btn-sm"><i class="icofont icofont-eye-alt"></i></a></td>
                                        </tr>
                               
                                    </ItemTemplate>
                                </asp:Repeater>
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
