<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Vegetable_Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Vegetable.Pages.Shop_Vegetable_Home" %>
<%@ Register Src="~/Projects/Shops/Shop_Vegetable/Modules/Feature_Box_Bottom.ascx" TagPrefix="uc1" TagName="Feature_Box_Bottom" %>

<section class="top-category section-padding">
    <div class="container">
        <div class="owl-carousel owl-carousel-category">
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/1.jpg" alt="">
                        <h6>Fruits & Vegetables</h6>
                        <p>150 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/2.jpg" alt="">
                        <h6>Grocery & Staples</h6>
                        <p>95 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/3.jpg" alt="">
                        <h6>Beverages</h6>
                        <p>65 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/4.jpg" alt="">
                        <h6>Home & Kitchen</h6>
                        <p>965 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/5.jpg" alt="">
                        <h6>Furnishing & Home Needs</h6>
                        <p>125 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/6.jpg" alt="">
                        <h6>Household Needs</h6>
                        <p>325 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/7.jpg" alt="">
                        <h6>Personal Care</h6>
                        <p>156 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/8.jpg" alt="">
                        <h6>Breakfast & Dairy</h6>
                        <p>857 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/9.jpg" alt="">
                        <h6>Biscuits, Snacks & Chocolates</h6>
                        <p>48 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/10.jpg" alt="">
                        <h6>Noodles, Sauces & Instant Food</h6>
                        <p>156 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/11.jpg" alt="">
                        <h6>Pet Care</h6>
                        <p>568 Items</p>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="category-item">
                    <a href="<%= Url("Shop_Vegetable_Products") %>">
                        <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/small/12.jpg" alt="">
                        <h6>Meats, Frozen & Seafood</h6>
                        <p>156 Items</p>
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="carousel-slider-main text-center border-top border-bottom bg-white">
    <div class="owl-carousel owl-carousel-slider">
        <div class="item">
            <a href="<%= Url("Shop_Vegetable_Products") %>">
                <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/slider/slider1.jpg" alt="First slide"></a>
        </div>
        <div class="item">
            <a href="<%= Url("Shop_Vegetable_Products") %>">
                <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/slider/slider2.jpg" alt="First slide"></a>
        </div>
    </div>
</section>
<section class="product-items-slider section-padding">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Top Savers Today <span class="badge badge-primary">20% OFF</span>
                <a class="float-right text-secondary" href="<%= Url("Shop_Vegetable_Products") %>">View All</a>
            </h5>
        </div>
        <div class="owl-carousel owl-carousel-featured">
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/1.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/2.jpg" alt="">
                            <span class="non-veg text-danger mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/3.jpg" alt="">
                            <span class="non-veg text-danger mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/4.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/5.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/6.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
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
                <a href="<%= Url("Shop_Vegetable_Products") %>">
                    <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/ad/1.jpg" alt=""></a>
            </div>
            <div class="col-md-6">
                <a href="<%= Url("Shop_Vegetable_Products") %>">
                    <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/ad/2.jpg" alt=""></a>
            </div>
        </div>
    </div>
</section>
<section class="product-items-slider section-padding">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Best Offers View <span class="badge badge-info">20% OFF</span>
                <a class="float-right text-secondary" href="<%= Url("Shop_Vegetable_Products") %>">View All</a>
            </h5>
        </div>
        <div class="owl-carousel owl-carousel-featured">
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/7.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/8.jpg" alt="">
                            <span class="non-veg text-danger mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/9.jpg" alt="">
                            <span class="non-veg text-danger mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/10.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/11.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/12.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="owl-carousel owl-carousel-featured">
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/7.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/8.jpg" alt="">
                            <span class="non-veg text-danger mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/9.jpg" alt="">
                            <span class="non-veg text-danger mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/10.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/11.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
                            <p class="offer-price mb-0">$450.99 <i class="mdi mdi-tag-outline"></i>
                                <br>
                                <span class="regular-price">$800.99</span></p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="item">
                <div class="product">
                    <a href="<%= Url("Shop_Vegetable_Product_Detail") %>">
                        <div class="product-header">
                            <span class="badge badge-success">50% OFF</span>
                            <img class="img-fluid" src="/Projects/Shops/Shop_Vegetable/Resources/img/item/12.jpg" alt="">
                            <span class="veg text-success mdi mdi-circle"></span>
                        </div>
                        <div class="product-body">
                            <h5>Product Title Here</h5>
                            <h6><strong><span class="mdi mdi-approval"></span>Available in</strong> - 500 gm</h6>
                        </div>
                        <div class="product-footer">
                            <button type="button" class="btn btn-secondary btn-sm float-right"><i class="mdi mdi-cart-outline"></i>Add To Cart</button>
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
<uc1:Feature_Box_Bottom runat="server" id="Feature_Box_Bottom" />
