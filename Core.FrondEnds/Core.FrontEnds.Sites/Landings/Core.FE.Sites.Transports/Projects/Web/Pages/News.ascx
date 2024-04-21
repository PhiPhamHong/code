<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Pages.News" %>
<%@ Register Src="~/Projects/Web/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>

<uc1:Header runat="server" ID="Header" />
<div class="main">
    <div class="container">
        <div class="sidebar col-md-4">
            <h2><%= Target %></h2>
            <ul>
                <asp:Repeater runat="server" ID="rpcate">
                    <ItemTemplate>
                        <li class="<%# Eval("Class") %>">
                            <a href="<%# Eval("UrlFormat") %>"><%# Eval("Title") %></a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="content col-md-8">
            <div class="head">

                <div class="search">
                    <div id="form-search">
                        <input id="keyword" type="text" placeholder="<%= Label("Nhập từ khóa") %>">
                        <button onclick="SearchNew(this)">
                            <div style="font-size: 14px; color: white;">
                                <%= Label("Tìm kiếm") %>
                            </div>
                        </button>
                    </div>
                </div>
            </div>
            <div class="list-new" data-current-catId="<%= CurrentCatId %>"">

                <div class="row" style="padding-top: 25px;">
                    <%if (IsNot) %>
                    <%{ %>
                    <h2>Updating...</h2>
                    <%} %>
                    <asp:Repeater runat="server" ID="rpnews">
                        <ItemTemplate>

                            <div class="col-md-4 data-new" style="padding-bottom: 20px" data-id="<%# Eval("NewsId") %>">
                                <div class="new-head">
                                    <a href="<%# Eval("UrlFormat") %>" target="">
                                        <%--<img src="<%# GetFullImage(Eval("Avatar")) %>" alt="">--%>
                                        <img src="/Projects/Web/Resources/img/banner.jpg" alt="" style="height: 100%; border-radius: 8px;">
                                    </a>
                                </div>
                                <div class="new-body">
                                    <div class="new-title">
                                        <a href="<%# Eval("UrlFormat") %>" target="">
                                            <p style="color: #262626;"><%# Eval("Title") %></p>
                                        </a>
                                    </div>
                                    <div class="new-date">
                                        <h4 style="color: #696868;"><%# Eval("CreatedDate") %> </h4>
                                    </div>
                                    <div class="new-sapo">
                                        <h4 style="color: #696868;">
                                            <p>
                                                <%# Eval("Sapo") %>
                                        </h4>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="pager"><%= pager.RenderPager() %></div>
        </div>
    </div>

</div>
