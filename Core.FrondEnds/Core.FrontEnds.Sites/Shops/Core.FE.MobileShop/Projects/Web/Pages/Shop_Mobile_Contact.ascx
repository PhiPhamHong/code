﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Contact.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Contact" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<section class="map-contact padding-none">
    <h6 class="sr-only">validator.w3</h6>
    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3501889.0795673826!2d73.15687918966267!3d31.00357561172526!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391964aa569e7355%3A0x8fbd263103a38861!2sPunjab!5e0!3m2!1sen!2sin!4v1503422781241" width="100%" height="250" frameborder="0" style="border: 0" allowfullscreen></iframe>
</section>
<section class="about_page">
    <div class="container">
        <div class="section-header section-header-center text-center">
            <h3 class="heading-design-center-h3">Thông tin liên hệ 
            </h3>
            <br>
        </div>
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto">
                <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="about_page_widget widget">
                            <i class="icofont icofont-iphone"></i>
                            <h5>Phone</h5>
                            <h2>+1-23-456789</h2>
                            <p>Fax: +1-23-456789</p>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="about_page_widget widget">
                            <i class="icofont icofont-location-pin"></i>
                            <h5>Address</h5>
                            <h2>Hà Nội</h2>
                            <p> Đại Đồng  </p>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="about_page_widget widget">
                            <i class="icofont icofont-ui-email"></i>
                            <h5>Email</h5>
                            <h2>info@abc.com</h2>
                            <p>vietvv@email.com</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="our-team-main">
    <div class="container">
        <div class="section-header section-header-center text-center">
            <h3 class="heading-design-center-h3">Gửi cho chúng tôi lời nhắn
            </h3>
            <br>
        </div>
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto">
                <div class="widget">
                    <form>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label class="control-label">Tên bạn <span class="required">*</span></label>
                                    <input class="form-control border-form-control" value="" placeholder="Enter Name" type="text">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label class="control-label">Địa chỉ mail <span class="required">*</span></label>
                                    <input class="form-control border-form-control " value="" placeholder="ex@gmail.com" type="email">
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label class="control-label">Điện thoại <span class="required">*</span></label>
                                    <input class="form-control border-form-control" value="" placeholder="Enter Phone" type="number">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label class="control-label">Nội dung <span class="required">*</span></label>
                                    <textarea class="form-control border-form-control"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 text-right">
                                <button type="button" class="btn btn-outline-danger">Huy </button>
                                <button type="button" class="btn btn-outline-success">Send </button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />