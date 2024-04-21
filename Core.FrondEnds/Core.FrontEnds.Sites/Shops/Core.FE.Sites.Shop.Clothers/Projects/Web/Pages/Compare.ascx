<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Compare.ascx.cs" Inherits="Core.FE.Sites.Shop.Clothers.Projects.Web.Pages.Compare" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="<%= Url("Home") %>"><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                    <li class="breadcrumb-item active">So sánh sản phẩm</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="compare-page">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <div class="widget">
                    <div class="table-responsive">
                        <table class="table table-bordered table-compare">
                            <tbody>
                                <tr>
                                    <td style="width: 20%;" class="compare-label">Product Image</td>
                                    <td style="width: 20%;"><a href="">
                                        <img class="img-thumbnail" src="/Projects/Web/Resources/images/men/small/1.jpg" alt="Product" width="230"></a></td>
                                    <td style="width: 20%;"><a href="">
                                        <img class="img-thumbnail" src="/Projects/Web/Resources/images/men/small/2.jpg" alt="Product" width="230"></a></td>
                                    <td style="width: 20%;"><a href="">
                                        <img class="img-thumbnail" src="/Projects/Web/Resources/images/men/small/3.jpg" alt="Product" width="230"></a></td>
                                    <td style="width: 20%;"><a href="">
                                        <img class="img-thumbnail" src="/Projects/Web/Resources/images/men/small/4.jpg" alt="Product" width="230"></a></td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Product Name</td>
                                    <td><a href="">Donec Ac Tempus</a></td>
                                    <td><a href="">Ipsums Dolors Untra </a></td>
                                    <td><a href="">Donec Ac Tempus</a></td>
                                    <td><a href="">Ipsums Dolors Untra </a></td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Rating</td>
                                    <td>
                                        <div class="rating"><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i>&nbsp; <span>(2 Reviews)</span></div>
                                    </td>
                                    <td>
                                        <div class="rating"><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i>&nbsp; <span>(3 Reviews)</span></div>
                                    </td>
                                    <td>
                                        <div class="rating"><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i><i class="fa fa-star-o"></i>&nbsp; <span>(0 Reviews)</span></div>
                                    </td>
                                    <td>
                                        <div class="rating"><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>&nbsp; <span>(5 Reviews)</span> </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Price</td>
                                    <td class="price">$49.99</td>
                                    <td class="price">$99.00</td>
                                    <td class="price">$25.55</td>
                                    <td class="price">$88.99</td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Description</td>
                                    <td>Lorem Ipsum Dolor Sit Amet, Consectetuer Adipiscing Elit, Sed Diam Nonummy Nibh Euismod.</td>
                                    <td>Tincidunt Ut Laoreet Dolore Magna Aliquam Erat Volutpat. Ut Wisi Enim Ad Minim Veniam, Quis Nostrud Exerci Tation Ullamcorper.</td>
                                    <td>Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. sed diam nonummy nibh euismod tincidunt.</td>
                                    <td>Lorem Ipsum Dolor Sit Amet, Consectetuer Adipiscing Elit, Sed Diam Nonummy Nibh Euismod.</td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Manufacturer</td>
                                    <td>Hermes</td>
                                    <td>D&amp;G </td>
                                    <td>Gola</td>
                                    <td>Kappa</td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Availability</td>
                                    <td class="instock">Instock (25 items)</td>
                                    <td class="outofstock">Out of stock</td>
                                    <td class="instock">Instock (30 items)</td>
                                    <td class="instock">Instock (50 items)</td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Size</td>
                                    <td>X</td>
                                    <td>XL</td>
                                    <td>XS</td>
                                    <td>XX</td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Color</td>
                                    <td>Red</td>
                                    <td>Blue</td>
                                    <td>Green</td>
                                    <td>Lavender</td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Dimensions</td>
                                    <td>20x30x52cm</td>
                                    <td>30x20x42cm</td>
                                    <td>70x25x22cm</td>
                                    <td>50x40x62cm</td>
                                </tr>
                                <tr>
                                    <td class="compare-label">Action</td>
                                    <td class="action">
                                        <button class="btn btn-primary"><i class="fa fa-shopping-cart"></i></button>
                                        <button class="btn btn-info"><i class="fa fa-heart"></i></button>
                                        <button class="btn btn-danger"><i class="fa fa-close"></i></button>
                                    </td>
                                    <td class="action">
                                        <button class="btn btn-primary"><i class="fa fa-shopping-cart"></i></button>
                                        <button class="btn btn-info"><i class="fa fa-heart"></i></button>
                                        <button class="btn btn-danger"><i class="fa fa-close"></i></button>
                                    </td>
                                    <td class="action">
                                        <button class="btn btn-primary"><i class="fa fa-shopping-cart"></i></button>
                                        <button class="btn btn-info"><i class="fa fa-heart"></i></button>
                                        <button class="btn btn-danger"><i class="fa fa-close"></i></button>
                                    </td>
                                    <td class="action">
                                        <button class="btn btn-primary"><i class="fa fa-shopping-cart"></i></button>
                                        <button class="btn btn-info"><i class="fa fa-heart"></i></button>
                                        <button class="btn btn-danger"><i class="fa fa-close"></i></button>
                                    </td>
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
