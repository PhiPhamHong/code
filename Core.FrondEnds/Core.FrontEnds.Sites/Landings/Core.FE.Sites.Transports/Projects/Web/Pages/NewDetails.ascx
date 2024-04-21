<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewDetails.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Pages.NewDetails" %>
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
        <div class="content col-md-8" style="padding-top: 90px">
            <button class="head-select" style="background: none; margin-bottom: 30px" onclick="history.back()">
                <div class="icon" style="padding: 5px;">
                    <img src="/Projects/Web/Resources/img/right.png" />
                </div>
                <div class="text-select">
                    <%= Label("Quay lại") %>
                </div>
            </button>
            <div class="title-detail">
                <h2><%= CurrentNew.Title %></h2>
                <span><%= CurrentNew.DateString %></span>
            </div>

            <div class="detail">
                <%= CurrentNew.NewsContent %>
            </div>

            <%if (IsHaveRelate) %>
            <%{ %>

            <div class="orther">
                <h3><%= Label("Tin liên quan") %></h3>
                <div class="list-new">
                    <div class="row" style="padding-top: 25px;">
                        <asp:Repeater runat="server" ID="rprelate">
                            <ItemTemplate>

                                <div class="col-md-4" style="padding-bottom: 20px">
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
            </div>

            <%} %>
        </div>
    </div>

</div>
