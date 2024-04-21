<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Costs.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Pages.Costs" %>
<%@ Register Src="~/Projects/Web/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Projects/Web/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<uc1:Header runat="server" ID="Header" />
<div class="main" style="min-height: calc(100vh - 180px);">
    <div class="container">
        <div class="sidebar col-md-4">
            <h2><%= Target %></h2>
        </div>
        <div class="content col-md-8" style="display: ruby;">
            <div class="head">

                <div class="search">
                    <form action="">
                        <input type="text" placeholder="<%= Label("Nhập từ khóa") %>">
                        <button>
                            <div style="font-size: 14px; color: white;">
                                <%= Label("Tìm kiếm") %>
                            </div>
                        </button>
                    </form>
                </div>
            </div>
            <div class="main-content" id="main-content">
                <div class="row" style="padding-top: 70px;">
                    <div class="col-md-6" style="margin-bottom: 30px;">
                        <div class="head-select">
                            <div class="icon">
                                <img src="/Projects/Web/Resources/img/location.png" />
                            </div>
                            <div class="text-select">
                                <%= Label("Điểm bốc hàng") %>
                            </div>
                        </div>
                        <div class="jumbotron">
                            <select class="selectpicker show-menu-arrow" id="startPoint"
                                data-style="form-control"
                                data-live-search="true"
                                title="<%= Label("Chọn điểm bốc hàng") %>">
                                <asp:Repeater runat="server" ID="rpStart">
                                    <ItemTemplate>
                                        <option value="<%# Eval("DirectionId") %>" data-tokens="<%# Eval("DirectionName") %>"><%# Eval("DirectionName") %></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </div>
                        <!--.jumbotron-->
                    </div>
                    <div class="col-md-6" style="margin-bottom: 30px;">
                        <div class="head-select">
                            <div class="icon">
                                <img src="/Projects/Web/Resources/img/location.png" />
                            </div>
                            <div class="text-select">
                                <%= Label("Điểm dỡ hàng") %>
                            </div>
                        </div>
                        <div class="jumbotron">
                            <select class="selectpicker show-menu-arrow" id="endPoint"
                                data-style="form-control"
                                data-live-search="true"
                                title="<%= Label("Chọn điểm dỡ hàng") %>">
                                <asp:Repeater runat="server" ID="rpEnd">
                                    <ItemTemplate>
                                        <option value="<%# Eval("DirectionId") %>" data-tokens="<%# Eval("DirectionName") %>"><%# Eval("DirectionName") %></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </div>
                        <!--.jumbotron-->
                    </div>
                    <div class="col-md-6" style="margin-bottom: 30px;">
                        <div class="head-select">
                            <div class="icon">
                                <img src="/Projects/Web/Resources/img/mathang.png" />
                            </div>
                            <div class="text-select">
                                <%= Label("Loại hàng hóa") %>
                            </div>
                        </div>
                        <div class="jumbotron">
                            <select class="selectpicker show-menu-arrow" id="productType"
                                data-style="form-control"
                                data-live-search="true"
                                title="<%= Label("Chọn loại hàng hóa") %>">
                                <asp:Repeater runat="server" ID="rpType">
                                    <ItemTemplate>
                                        <option value="<%# Eval("TypeId") %>" data-tokens="<%# Eval("ProductTypeName") %>"><%# Eval("ProductTypeName") %></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </div>
                        <!--.jumbotron-->
                    </div>
                    <div class="col-md-6" style="margin-bottom: 30px;">
                        <div class="head-select">
                            <div class="icon">
                                <img src="/Projects/Web/Resources/img/mathang.png" />
                            </div>
                            <div class="text-select">
                                <%= Label("Loại container") %>
                            </div>
                        </div>
                        <div class="jumbotron">
                            <select class="selectpicker show-menu-arrow" id="containerType"
                                data-style="form-control"
                                data-live-search="true"
                                title="<%= Label("Chọn loại container") %>">
                                <option value="1" data-tokens="Container 20">Container 20"</option>
                                <option value="2" data-tokens="Container 40">Container 40"</option>
                            </select>
                        </div>
                        <!--.jumbotron-->
                    </div>
                    <div class="col-md-6">
                        <button class="btn-bg" onclick="CheckPrice(this)">
                            <%= Label("Lấy báo giá") %>
                        </button>
                    </div>
                    <div class="col-md-6">
                        <div class="btn-bg-2">
                            <label id="result"></label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<uc1:Footer runat="server" ID="Footer" />
