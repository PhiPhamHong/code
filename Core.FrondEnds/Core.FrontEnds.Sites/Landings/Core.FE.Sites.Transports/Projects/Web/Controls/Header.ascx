<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Controls.Header" %>
<header>
    <div class="wrapper" style="background: #603813BF; height: 90px">
        <div class="container" style="padding: 1.5em; text-align: center;">
            <div class="col-md-2">
                <div class="logo">
                    <a href="<%= Url("Home") %>">
                        <img src="/Projects/Web/Resources/img/logo.png" alt="">
                    </a>
                </div>
            </div>
            <div class="col-md-9" style="padding-top: 10px">
                <div class="menu-md">
                    <asp:Repeater runat="server" ID="rpsmallcate">
                        <ItemTemplate>
                            <a href="<%# Eval("UrlFormat") %>" class="item-mn">
                                <span><%# Eval("Title")%></span>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

            </div>
            <div class="col-md-1">
                <div class="lang" style="display: ruby">
                    <div style="padding: 1px">
                        <a href="<%= url_jp %>" class="item-l">
                            <img src="/Projects/Web/Resources/img/jp.png" style="width: 27px; height: 27px; border-radius: 50%" alt="">
                        </a>
                    </div>
                    <div style="padding: 1px">
                        <a href="<%= url_kr %>" class="item-l">
                            <img src="/Projects/Web/Resources/img/kr.png" style="width: 27px; height: 27px; border-radius: 50%" alt="">
                        </a>
                    </div>

                    <div style="padding: 1px">
                        <a href="<%= url_cn %>" class="item-l">
                            <img src="/Projects/Web/Resources/img/cn.png" style="width: 27px; height: 27px; border-radius: 50%" alt="">
                        </a>
                    </div>

                    <div style="padding: 1px">
                        <a href="<%= url_en %>" class="item-l">
                            <img src="/Projects/Web/Resources/img/en.png" style="width: 27px; height: 27px; border-radius: 50%" alt="">
                        </a>
                    </div>

                </div>
            </div>
        </div>
        <%--<button class="touch-menu"></button>
        <div class="menu-mb">
            <ul>
                <asp:Repeater runat="server" ID="rpcate">
                    <ItemTemplate>
                        <a href="<%# Eval("UrlFormat") %>" class="item-mb">
                            <span><%# Eval("Title")%></span>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>
        </div>--%>
    </div>
</header>
