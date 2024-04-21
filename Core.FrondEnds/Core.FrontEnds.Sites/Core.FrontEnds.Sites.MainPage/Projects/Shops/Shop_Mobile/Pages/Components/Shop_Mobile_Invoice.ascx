<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Invoice.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Pages.Components.Shop_Mobile_Invoice" %>
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
<section class="receipt_page">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-md-8 mx-auto">
                <div class="receipt-main">
                    <div class="receipt-header">
                        <div class="row">
                            <div class="col-lg-6 col-md-6">
                                <div class="receipt-left">
                                    <img class="img-responsive" alt="iamgurdeeposahan" src="/Projects/Shops/Shop_Mobile/Resources/images/users/3.jpg">
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 text-right">
                                <div class="receipt-right">
                                    <h5>AskBootstrap.</h5>
                                    <p>+91 85680-79956 <i class="fa fa-phone fa-fw"></i></p>
                                    <p>iamosahan@gmail.com <i class="fa fa-envelope-o fa-fw"></i></p>
                                    <p>India <i class="fa fa-location-arrow fa-fw"></i></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="receipt-header receipt-header-mid">
                        <div class="row">
                            <div class="col-lg-8 col-md-8 text-left">
                                <div class="receipt-right">
                                    <h5>Gurdeep Osahan <span class="badge badge-danger">#HSFB 342823</span></h5>
                                    <p><b>Mobile :</b> +91 12345-6789</p>
                                    <p><b>Email :</b> info@gmail.com</p>
                                    <p><b>Address :</b> Australia</p>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4">
                                <div class="receipt-left">
                                    <h1>Receipt</h1>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>Description</th>
                                    <th>Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="col-md-9">Ipsums Dolors Untra  | August 2017</td>
                                    <td class="col-md-3">$15,000/-</td>
                                </tr>
                                <tr>
                                    <td class="col-md-9">Ipsums Dolors Untra  | August 2017</td>
                                    <td class="col-md-3">$6,00/-</td>
                                </tr>
                                <tr>
                                    <td class="col-md-9">Ipsums Dolors Untra  | August 2017</td>
                                    <td class="col-md-3">$35,00/-</td>
                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <p>
                                            <strong>Total Amount: </strong>
                                        </p>
                                        <p>
                                            <strong>Shipping: </strong>
                                        </p>
                                        <p>
                                            <strong>Total (tax excl.): </strong>
                                        </p>
                                        <p>
                                            <strong>Tax: </strong>
                                        </p>
                                    </td>
                                    <td>
                                        <p>
                                            <strong>$65,500/-</strong>
                                        </p>
                                        <p>
                                            <strong>$500/-</strong>
                                        </p>
                                        <p>
                                            <strong>$1300/-</strong>
                                        </p>
                                        <p>
                                            <strong>$9500/-</strong>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <h2><strong>Total: </strong></h2>
                                    </td>
                                    <td class="text-left">
                                        <h2><strong class="text-danger">$31.566/-</strong></h2>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="receipt-header receipt-header-mid receipt-footer">
                        <div class="row">
                            <div class="col-lg-8 col-md-8 text-left">
                                <div class="receipt-right">
                                    <p><b>Date :</b> 15 Aug 2019</p>
                                    <h5 style="color: rgb(140, 140, 140);">Thank you for your business!</h5>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4">
                                <div class="receipt-left">
                                    <h1>Signature</h1>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
