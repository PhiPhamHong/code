<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Profile.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Profile" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="/trang-chu"><i class="icofont icofont-ui-home"></i>Home</a></li>
                    <li class="breadcrumb-item active">Profiles</li>
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
                        <a class="list-group-item active" href="<%= Url("Shop_Mobile_Profile") %>"><i class="icofont icofont-ui-user fa-fw"></i>My Profile</a>
                        <a class="list-group-item justify-content-between" href="<%= Url("Shop_Mobile_Orderlist") %>"><span><i class="icofont icofont-list fa-fw"></i>Order List</span> <span class="badge badge-warning">6 Items</span></a>
                    </nav>
                </div>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-7">
                <div class="widget">
                    <div class="section-header">
                        <h5 class="heading-design-h5">My Profile
                        </h5>
                        <p>Thông tin cá nhân </p>
                    </div>
                    <form>
                        <h5 class="heading-design-h6">Thông tin chung</h5>
                        <fieldset class="form-group">
                            <label>Tên của bạn</label>
                            <input type="text" class="form-control" value="<%= Cus.Name %>" placeholder="Nhập tên bạn" id="resname">
                        </fieldset>

                        <fieldset class="form-group">
                            <label>Địa chỉ</label>
                            <input type="text" class="form-control" value="<%= Cus.Address %>" placeholder="Nhập địa chỉ" id="resaddress">
                        </fieldset>

                        <fieldset class="form-group">
                            <label>SĐT</label>
                            <input type="text" class="form-control" value="<%= Cus.Phone %>"  placeholder="+91 123 456 7890" id="resphone">
                        </fieldset>

                        <fieldset class="form-group">
                            <label>Email</label>
                            <input type="text" class="form-control" value="<%= Cus.Email %>"  placeholder="ANV@gmail.com" id="resmail">
                        </fieldset>

                        <h5 class="heading-design-h6">Thông tin tài khoản</h5>

                        <fieldset class="form-group">
                            <label>Tên tài khoản</label>
                            <input type="text" class="form-control" value="<%= Cus.MemberName %>"  placeholder="Nhập tài khoản" id="resusername">
                        </fieldset>
                        <fieldset class="form-group">
                            <label>Mật khẩu</label>
                            <input type="password" class="form-control" placeholder="********" id="respassword">
                        </fieldset>
                    </form>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
