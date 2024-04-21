<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Jewelry_Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Jewelry.Pages.Shop_Jewelry_Home" %>
<%@ Register Src="~/Projects/Shops/Shop_Jewelry/Modules/Slider.ascx" TagPrefix="uc1" TagName="Slider" %>
<%@ Register Src="~/Projects/Shops/Shop_Jewelry/Modules/Categories.ascx" TagPrefix="uc1" TagName="Categories" %>




<uc1:Slider runat="server" id="Slider" />
<uc1:Categories runat="server" id="Categories" />
<section class="product-items-slider section-padding">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Top Savers Today <span class="badge badge-primary">20% OFF</span>
                <a class="float-right text-secondary" href="<%= Url("Shop_Jewelry_Shop") %>">View All</a>
            </h5>
        </div>
        <div class="owl-carousel owl-carousel-featured">
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/1.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/2.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/3.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/4.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/5.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/6.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="offer-product">
    <div class="container">
        <div class="row no-gutters">
            <div class="col-md-6">
                <a href="<%= Url("Shop_Jewelry") %>">
                    <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/ad/1.jpg" alt=""></a>
            </div>
            <div class="col-md-6">
                <a href="<%= Url("Shop_Jewelry") %>">
                    <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/ad/2.jpg" alt=""></a>
            </div>
        </div>
    </div>
</section>
<section class="product-items-slider section-padding">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5"> Best offers view <span class="badge badge-primary">20% OFF</span>
                <a class="float-right text-secondary" href="<%= Url("Shop_Jewelry_Shop") %>">View All</a>
            </h5>
        </div>
        <div class="owl-carousel owl-carousel-featured">
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/1.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/2.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/3.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/4.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/5.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Jewelry_Single") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Jewelry/Resources/img/item/6.jpg" alt="">
                            <span class="text-danger mdi mdi-heart"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Diamond</strong> - 18Kt Gold</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i></button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>
