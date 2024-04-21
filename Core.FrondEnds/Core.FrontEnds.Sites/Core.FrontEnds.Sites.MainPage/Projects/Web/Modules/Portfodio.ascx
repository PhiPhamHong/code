<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Portfodio.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Web.Modules.Portfodio" %>

<div id="portfolio">
    <div class="section-title text-center center">
        <div class="overlay">
            <h2><b>Danh Mục Sản Phẩm</b></h2>
            <hr>
            <p>Chúng tôi đang sở hữu một lượng lớn các Website với quy mô lớn nhỏ thuộc nhiều loại hình và chi phí khác nhau, </p>
            <p>giúp bạn có thể dễ dàng lựa chọn cho mình một Website phù hợp với chi phí và nhu cầu sử dụng.</p>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="categories">
                <ul class="cat">
                    <li>
                        <ol class="type">
                            <li><a data-filter="*" class="active">Tất cả</a></li>
                            <li><a data-filter=".shop">Bán hàng</a></li>
                            <li><a data-filter=".tmdt">Rao vặt</a></li>
                            <li><a data-filter=".bds">Nhà đất</a></li>
                            <li><a data-filter=".res">Nhà hàng</a></li>
                            <li><a data-filter=".blog">Blogspot</a></li>
                            <li><a data-filter=".landing">Landings</a></li>
                        </ol>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
        </div>
        <div class="row">
            <div class="portfolio-items">

                <asp:Repeater runat="server" ID="rpWebs">
                    <ItemTemplate>

                        <div class="col-sm-6 col-md-4 col-lg-4 <%# Eval("Target") %>">
                            <div class="portfolio-item">
                                <div class="hover-bg">
                                    <a  target="<%# Eval("Url").ToString() != "" ? "_blank" : "" %>" href="<%# Eval("Url") %>" title="<%# Eval("Title") %>" data-lightbox-gallery="gallery1">
                                        <div class="hover-text">
                                            <h4><small><b>TEAM Design</b></small> <br /></h4>
                                                <h5><%# Eval("Intro") %></h5> <h4> Mã: <b> <%# Eval("Code") %> </b></h4>
                                        </div>
                                        <img src="<%# Eval("Avatar") %>" class="img-responsive">
                                    </a>
                                </div>
                            </div>
                        </div>


                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</div>
