<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Shop_details.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Shop_details" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="/trang-chu"><i class="icofont icofont-ui-home"></i>Home</a></li>
                    <li class="breadcrumb-item active"><%= Entity.Name %></li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="products_page">
    <div class="container">
        <div class="row">
            <div class="col-lg-5 col-md-5">
                <div class="shop-detail-left">
                    <div class="item-img-grid">
                        <div class="favourite-icon">
                            <a class="fav-btn" title="" data-placement="bottom" data-toggle="tooltip" href="" data-original-title="Save Ad">115 <i class="fa fa-heart"></i></a>
                        </div>
                        <div id="sync1" class="owl-carousel">
                            <asp:Repeater runat="server" ID="rpL1">
                                <ItemTemplate>
                                    <div class="item">
                                        <img alt="" src="<%# Eval("Thumb") %>" class="img-responsive img-center">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div id="sync2" class="owl-carousel">
                            <asp:Repeater runat="server" ID="rpL2">
                                <ItemTemplate>
                                    <div class="item">
                                        <img alt="" src="<%# Eval("Thumb") %>" class="img-responsive img-center">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-7 col-md-7">
                <div class="shop-detail-right">
                    <div class="widget">
                        <div class="product-name">
                            <p class="text-danger text-uppercase">
                                <i class="icofont icofont-laptop"></i>
                                Laptop 
                            </p>
                            <h1><%= Entity.Name %></h1>
                            <span>Mã sản phẩm : <b><%= Entity.Code %></b> | Sold by: <strong class="text-info">Admin </strong>( Supplied By Partner )</span>
                        </div>
                        <div class="price-box">
                            <h5>
                                <span class="product-desc-price"><%= Entity.PriceOld != null ? "Giá cũ: " + Entity.PriceOld.Value.ToString("###,###") : "" %></span>
                                <span class="product-price text-danger">Giá bán: <i class="icofont icofont-price"></i><%= Entity.PriceSale.Value.ToString("###,###") %></span>
                                <span class="badge badge-default"><%= Entity.PriceOld != null ? (int) (((Entity.PriceOld - Entity.PriceSale)/ Entity.PriceOld) * 100) : 0 %> % Off</span>
                            </h5>
                        </div>
                        <div class="ratings">
                            <div class="stars-rating">
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star active"></i>
                                <i class="icofont icofont-star"></i><span>(613)</span>
                                <span class="rating-links pull-right"><a href="">1 Đánh giá(s)</a> <span class="separator"></span><a href=""><i class="icofont icofont-comment"></i>Để lại đánh giá</a> </span>
                            </div>
                        </div>
                        <div class="short-description">
                            <h4>Mô tả ngắn
                           <span class="pull-right">Trạng thái: <strong class="badge badge-success">Còn hàng</strong></span>
                            </h4>
                            <p>
                                <b><%= Entity.Sapo %></b>
                            </p>
                             <p><%= Entity.Description %> </p>
                        </div>
                        <%--<div class="product-color-size-area row">
                        <div class="color-area col-lg-6 col-md-6">
                           <h4>Color</h4>
                           <div class="color">
                              <ul class="osahan-select-color">
                                 <li>
                                    <a class="color-bg bg-blue" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Blue"></a>
                                    <a class="color-bg bg-navy" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Navy"></a>
                                    <a class="color-bg bg-red" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Red"></a>
                                    <a class="color-bg bg-maroon" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Maroon"></a>
                                    <a class="color-bg bg-pink" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Pink"></a>
                                    <a class="color-bg bg-yellow" data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Yellow"></a>
                                 </li>
                              </ul>
                           </div>
                        </div>
                        <div class="size-area col-lg-6 col-md-6">
                           <h4>Size</h4>
                           <div class="size">
                              <ul class="list-inline">
                                 <li class="list-inline-item"><a href="">S</a></li>
                                 <li class="list-inline-item"><a href="">L</a></li>
                                 <li class="list-inline-item"><a href="">M</a></li>
                                 <li class="list-inline-item"><a href="">XL</a></li>
                                 <li class="list-inline-item"><a href="">XXL</a></li>
                              </ul>
                           </div>
                        </div>
                     </div>--%>
                        <div class="product-variation">

                            <div class="input-group quantity-input" id="Quantity">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-theme-round btn-number btn-lg" data-cmd="Minus" data-type="minus">
                                        <span class="fa fa-minus"></span>
                                    </button>
                                </span>
                                <input type="text" name="quantity" class="text-center form-control border-form-control form-control-sm input-number" value="1">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-theme-round btn-number btn-lg" data-cmd="Plus" data-type="plus">
                                        <span class="fa fa-plus"></span>
                                    </button>
                                </span>
                            </div>

                            <button type="button" class="btn btn-outline-success btn-lg"><i class="icofont icofont-heart"></i>+ Ưa thích</button>
                            <button type="button" class="btn btn-theme-round btn-lg"  data-cmd="AddToCart" data-id="<%= Entity.ProductId %>" ><i class="icofont icofont-shopping-cart"></i>Thêm vào giỏ hàng</button>

                        </div>
                        <%--<div class="product-cart-option">
                        <ul class="list-inline">
                           <li class="list-inline-item"><a href="wishlist.html"><i class="icofont icofont-heart"></i> <span>Add to Wishlist</span></a></li>
                           <li class="list-inline-item"><a href=""><i class="icofont icofont-retweet"></i> <span>Add to Compare</span></a></li>
                           <li class="list-inline-item"><a href=""><i class="icofont icofont-send-mail"></i> <span>Email to a Friend</span></a></li>
                        </ul>
                     </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="reviews-section">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Review và đánh giá 
            </h5>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-4">
                <div class="widget reviews-section-average">
                    <h4>Trung bình đánh giá</h4>
                    <h2 class="bold"><span class="text-primary">4.0</span><small> /5</small> <a href="">Xem tất cả đánh giá</a></h2>
                    <button type="button" class="btn btn-outline-warning btn-sm" aria-label="Left Align">
                        <span class="icofont icofont-star" aria-hidden="true"></span>
                    </button>
                    <button type="button" class="btn btn-outline-warning btn-sm" aria-label="Left Align">
                        <span class="icofont icofont-star" aria-hidden="true"></span>
                    </button>
                    <button type="button" class="btn btn-outline-warning btn-sm" aria-label="Left Align">
                        <span class="icofont icofont-star" aria-hidden="true"></span>
                    </button>
                    <button type="button" class="btn btn-outline-warning btn-sm" aria-label="Left Align">
                        <span class="icofont icofont-star" aria-hidden="true"></span>
                    </button>
                    <button type="button" class="btn btn-outline-primary btn-sm" aria-label="Left Align">
                        <span class="icofont icofont-star" aria-hidden="true"></span>
                    </button>
                </div>
            </div>
            <div class="col-sm-12 col-md-4">
                <div class="widget reviews-section-rating mb18">
                    <h4>Phân tích xếp hạng</h4>
                    <div class="rating-list">
                        <div class="rating-list-left">
                            5 <span class="icofont icofont-star text-warning"></span>
                        </div>
                        <div class="rating-list-center">
                            <div class="progress">
                                <div class="progress-bar bg-success" role="progressbar" aria-valuenow="5" aria-valuemin="0" aria-valuemax="5" style="width: 1000%">
                                    <span class="sr-only">80% Complete (danger)</span>
                                </div>
                            </div>
                        </div>
                        <div class="rating-list-right text-success">100</div>
                    </div>
                    <div class="rating-list">
                        <div class="rating-list-left">
                            4 <span class="icofont icofont-star text-warning"></span>
                        </div>
                        <div class="rating-list-center">
                            <div class="progress">
                                <div class="progress-bar bg-primary" role="progressbar" aria-valuenow="4" aria-valuemin="0" aria-valuemax="5" style="width: 80%">
                                    <span class="sr-only">80% Complete (danger)</span>
                                </div>
                            </div>
                        </div>
                        <div class="rating-list-right text-primary">75</div>
                    </div>
                    <div class="rating-list">
                        <div class="rating-list-left">
                            3 <span class="icofont icofont-star text-warning"></span>
                        </div>
                        <div class="rating-list-center">
                            <div class="progress">
                                <div class="progress-bar bg-info" role="progressbar" aria-valuenow="3" aria-valuemin="0" aria-valuemax="5" style="width: 60%">
                                    <span class="sr-only">80% Complete (danger)</span>
                                </div>
                            </div>
                        </div>
                        <div class="rating-list-right text-info">50</div>
                    </div>
                    <div class="rating-list">
                        <div class="rating-list-left">
                            2 <span class="icofont icofont-star text-warning"></span>
                        </div>
                        <div class="rating-list-center">
                            <div class="progress">
                                <div class="progress-bar bg-warning" role="progressbar" aria-valuenow="2" aria-valuemin="0" aria-valuemax="5" style="width: 40%">
                                    <span class="sr-only">80% Complete (danger)</span>
                                </div>
                            </div>
                        </div>
                        <div class="rating-list-right text-warning">25</div>
                    </div>
                    <div class="rating-list">
                        <div class="rating-list-left">
                            1 <span class="icofont icofont-star text-warning"></span>
                        </div>
                        <div class="rating-list-center">
                            <div class="progress">
                                <div class="progress-bar bg-danger" role="progressbar" aria-valuenow="1" aria-valuemin="0" aria-valuemax="5" style="width: 20%">
                                    <span class="sr-only">80% Complete (danger)</span>
                                </div>
                            </div>
                        </div>
                        <div class="rating-list-right text-danger">00</div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-4">
                <div class="widget reviews-section-add-review">
                    <h4>Đánh giá</h4>
                    <h2 class="bold">Bạn đã sử dụng sản phẩm này chưa?</h2>
                    <button type="button" class="btn btn-outline-info btn-lg">
                        <i class="icofont icofont-comment"></i>
                        Viết đánh giá của bạn</button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="widget reviews-section-comment mb18">
                    <div class="row">
                        <div class="col-sm-3">
                            <img class="review-block-image img-rounded" src="/Projects/Web/Resources/images/users/1.jpg" alt="alt">
                            <div class="review-block-name"><a href=""><i class="icofont icofont-ui-user"></i>Khách hàng </a></div>
                            <div class="review-block-date"><i class="icofont icofont-ui-calendar"></i>January 29, 2019 | 1 Day ago</div>
                        </div>
                        <div class="col-sm-9">
                            <div class="review-block-title">
                                <span class="stars-rating"><i class="icofont icofont-star active"></i><i class="icofont icofont-star"></i><i class="icofont icofont-star"></i><i class="icofont icofont-star"></i><i class="icofont icofont-star"></i></span>
                                Sản phẩm hơi tệ <span class="text-success"><i class="icofont icofont-check-circled"></i>Đã xác thực </span>
                            </div>
                            <div class="review-block-description">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-3">
                            <img class="review-block-image img-rounded" src="/Projects/Web/Resources/images/users/2.jpg" alt="alt">
                            <div class="review-block-name"><a href=""><i class="icofont icofont-ui-user"></i>Khách hàng </a></div>
                            <div class="review-block-date"><i class="icofont icofont-ui-calendar"></i>June 16, 2019 | 5 Day ago</div>
                        </div>
                        <div class="col-sm-9">
                            <div class="review-block-title">
                                <span class="stars-rating"><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star"></i><i class="icofont icofont-star"></i><i class="icofont icofont-star"></i></span>
                                Tạm ổn <span class="text-success"><i class="icofont icofont-check-circled"></i>Đã xác thực </span>
                            </div>
                            <div class="review-block-description">Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia,</div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-3">
                            <img class="review-block-image img-rounded" src="/Projects/Web/Resources/images/users/3.jpg" alt="alt">
                            <div class="review-block-name"><a href=""><i class="icofont icofont-ui-user"></i>Khách hàng </a></div>
                            <div class="review-block-date"><i class="icofont icofont-ui-calendar"></i>July 02, 2019 | 2 Day ago</div>
                        </div>
                        <div class="col-sm-9">
                            <div class="review-block-title">
                                <span class="stars-rating"><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star"></i></span>
                                Sản phẩm tuyệt vời <span class="text-success"><i class="icofont icofont-check-circled"></i>Đã xác thực</span>
                            </div>
                            <div class="review-block-description">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters</div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-3">
                            <img class="review-block-image img-rounded" src="/Projects/Web/Resources/images/users/2.jpg" alt="alt">
                            <div class="review-block-name"><a href=""><i class="icofont icofont-ui-user"></i>Khách hàng</a></div>
                            <div class="review-block-date"><i class="icofont icofont-ui-calendar"></i>June 16, 2019 | 5 Day ago</div>
                        </div>
                        <div class="col-sm-9">
                            <div class="review-block-title">
                                <span class="stars-rating"><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star"></i><i class="icofont icofont-star"></i><i class="icofont icofont-star"></i></span>
                                Dùng được <span class="text-success"><i class="icofont icofont-check-circled"></i>Đã xác thực</span>
                            </div>
                            <div class="review-block-description">Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia,</div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-3">
                            <img class="review-block-image img-rounded" src="/Projects/Web/Resources/images/users/3.jpg" alt="alt">
                            <div class="review-block-name"><a href=""><i class="icofont icofont-ui-user"></i>Khách hàng </a></div>
                            <div class="review-block-date"><i class="icofont icofont-ui-calendar"></i>July 02, 2019 | 2 Day ago</div>
                        </div>
                        <div class="col-sm-9">
                            <div class="review-block-title">
                                <span class="stars-rating"><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star active"></i><i class="icofont icofont-star"></i></span>
                                Sản phẩm tuyệt vời <span class="text-success"><i class="icofont icofont-check-circled"></i>Đã xác thực</span>
                            </div>
                            <div class="review-block-description">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="widget">
                    <div class="section-header">
                        <h5 class="heading-design-h5">Để lại đánh giá
                        </h5>
                    </div>
                    <form>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label class="control-label">Tên bạn <span class="required">*</span></label>
                                    <input class="form-control border-form-control" value="" placeholder="Enter Name" type="text">
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label class="control-label">Địa chỉ mail <span class="required">*</span></label>
                                    <input class="form-control border-form-control " value="" placeholder="ex@gmail.com" type="email">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label class="control-label">Tiêu đề <span class="required">*</span></label>
                                    <input class="form-control border-form-control" value="" placeholder="Subject" type="text">
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label class="control-label">Đánh giá <span class="required">*</span></label>
                                    <select class="select2 form-control border-form-control">
                                        <option value="">5 Sao</option>
                                        <option value="">4 Sao</option>
                                        <option value="">3 Sao</option>
                                        <option value="">2 Sao</option>
                                        <option value="">1 SAo</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label class="control-label">Đánh giá <span class="required">*</span></label>
                                    <textarea class="form-control border-form-control"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 text-right">
                                <button type="button" class="btn btn-outline-danger btn-lg">Hủy </button>
                                <button type="button" class="btn btn-outline-success btn-lg">Gửi đánh giá </button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="deals-of-the-day">
    <div class="container">
        <div class="section-header">
            <h5 class="heading-design-h5">Sản phẩm liên quan
            </h5>
        </div>
        <div class="row">
            <asp:Repeater runat="server" ID="rpHots">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-3 col-sm-6">
                        <div class="h-100">
                            <div class="product-item">
                                <span class="badge badge-danger offer-badge">HOT</span>
                                <div class="product-item-image">
                                    <span class="like-icon"><a href=""><i class="icofont icofont-heart"></i></a></span>
                                    <a href="<%# Eval("UrlFormat") %>">
                                        <img class="card-img-top img-fluid" src="<%# Eval("Avatar") %>" alt="<%# Eval("Name") %>"></a>
                                </div>
                                <div class="product-item-body">
                                    <div class="product-item-action">
                                        <a data-toggle="tooltip" data-placement="top" title="Add To Cart" class="btn btn-theme-round btn-sm"  data-cmd="AddToCart" data-id="<%# Eval("ProductId") %>"><i class="icofont icofont-shopping-cart"></i></a>
                                        <a data-toggle="tooltip" data-placement="top" title="View Detail" class="btn btn-theme-round btn-sm" href="<%# Eval("UrlFormat") %>"><i class="icofont icofont-search-alt-2"></i></a>
                                    </div>
                                    <p class="card-title"><a href="<%= Url("Shop_Mobile_Shop_details") %>"><%# Eval("Name") %></a></p>
                                    <p>
                                        <span class="product-desc-price"><%# Eval("PriceOld","{0:0,0}") %></span>
                                        <span class="product-price"><%# Eval("PriceSale","{0:0,0}") %></span>
                                        <%--<span class="product-discount">30% Off</span>--%>
                                    </p>
                                </div>
                                <div class="product-item-footer">
                                    <div class="product-item-size">
                                        <strong>Colors: </strong><span>ONE COLOR</span>
                                    </div>
                                    <div class="stars-rating">
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star active"></i>
                                        <i class="icofont icofont-star"></i><%--<span>(415)</span>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
