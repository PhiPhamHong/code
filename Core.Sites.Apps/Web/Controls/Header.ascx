<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.Header" %>
<%@ Register Src="~/Web/Controls/MenuLeft.ascx" TagPrefix="web" TagName="MenuLeft" %>

<header class="main-header">
    <!-- Logo -->
    <a class="logo hidden-xs">
        <!-- mini logo for sidebar mini 50x50 pixels -->
        <span class="logo-mini">
            <img style="width: 45px; height: 40px;" src="<%= (PortalContext.Config.Logo == string.Empty || PortalContext.Config.Logo == "") ? "/Web/Resources/Images/small-logo.png" : PortalContext.Config.Logo %>" />
        </span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top" role="navigation">
        <!-- Sidebar toggle button-->
        <button data-target="#navbar-collapse" data-toggle="collapse" class="navbar-toggle collapsed hidden-md-up" type="button" aria-expanded="false"><i class="fa fa-bars"></i></button>
        <div id="navbar-collapse" class="sh-menu-top navbar-collapse pull-left collapse" aria-expanded="false" style="height: 1px;">
            <ul class="nav navbar-nav">
                <asp:Repeater runat="server" ID="menuTop" OnItemDataBound="menuTop_ItemDataBound">
                    <ItemTemplate>
                        <li data-top-url="<%# Eval("UrlVirtual") %>" <%# Container.DataItem.As<MenuTop>().Groups.Count != 0 ? "class='dropdown vimenu'":"" %>>
                            <a href="<%# Eval("Url") %>" data-state="true" <%# Container.DataItem.As<MenuTop>().Groups.Count != 0 ? "class='dropdown-toggle' data-toggle='dropdown' aria-expanded='false'":"" %>>
                                <i class="<%# Eval("Icon") %>"></i><span>&nbsp <%# FromMenuItem(Container.DataItem) %></span>
                                <%# Container.DataItem.As<MenuTop>().Groups.Count != 0 ? "<span class='caret'></span>":"" %>
                            </a>
                            <asp:PlaceHolder runat="server" ID="plcGroup"></asp:PlaceHolder>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                
                <li>
                    <h4 style="color:#ffffff8c"> |::::| </h4>
                </li>

                <li>
                    <a href="https://teamdesign.info" target="_blank">
                        <i class="fab fa-internet-explorer"></i><span>&nbsp Kho giao diện</span>
                    </a>
                </li>

                <li>
                    <a href="<%= PortalContext.Config.Documents %>" target="_blank">
                        <i class="fas fa-tasks"></i><span>&nbsp Hướng dẫn sử dụng</span>
                    </a>
                </li>

            </ul>
        </div>
        <div class="navbar-custom-menu">
            <ul class="nav navbar-nav">
                <li class="dropdown notifications-menu">
                    <a href="javascript:void(0)" data-notification="bell" class="dropdown-toggle" data-toggle="dropdown" style="padding-bottom: 10px; padding-top: 10px; text-align: center;">
                        <i class="fas fa-bell fa-2x"></i>
                        <label class="label label-danger faa-pulse animated" data-notification="label" style="top: 8px; right: 0px;"></label>
                    </a>
                    <ul class="dropdown-menu">
                        <li class="header" data-notification="header"><%= PortalContext.GetLabel("Đang tải") %></li>
                        <li>
                            <ul class="menu" data-notification="content"></ul>
                        </li>
                        <li class="footer" data-notification="footer"><a href="javascript:void(0)"><%= PortalContext.GetLabel("Xem tất cả") %></a></li>
                    </ul>
                </li>
                <!-- User Account: style can be found in dropdown.less -->
                <li class="dropdown user user-menu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <img src="/Web/Resources/Images/avatar160x160.png" data-src="<%= PortalContext.CurrentUser.User.Avatar.WhenEmpty(()=> "/Web/Resources/Images/avatar160x160.png")  %>" class="user-avatar user-image" alt="<%= PortalContext.CurrentUser.User.FullName %>" />
                        <span class="hidden-xs<%= PortalContext.Session.IAccountInfo.User_2() != 0 ? " text-yellow" : "" %>"><%= PortalContext.CurrentUser.User.FullName %></span>
                    </a>
                    <ul class="dropdown-menu">
                        <!-- User image -->
                        <li class="user-header">
                            <img src="/Web/Resources/Images/avatar160x160.png" data-src="<%= PortalContext.CurrentUser.User.Avatar.WhenEmpty(()=> "/Web/Resources/Images/avatar160x160.png")  %>" class="user-avatar img-circle" alt="<%= PortalContext.CurrentUser.User.FullName %>" />
                            <p><%= PortalContext.GetLabel("Quản lý bán hàng") %><small><%= PortalContext.GetLabel("Nhân viên") %></small></p>
                        </li>

                        <!-- Menu Footer-->
                        <li class="user-footer">
                            <div class="pull-left"><a href="<%= UrlHelper.UpdateInfoUser %>" data-state="true" class="btn btn-default btn-flat"><i class="fa fa-user"></i><%= PortalContext.GetLabel("Thông tin") %></a></div>
                            <div class="pull-right"><a href="javascript:void(0)" onclick="Core.logout()" class="btn btn-default btn-flat"><i class="fa fa-sign-out"></i><%= PortalContext.GetLabel("Thoát") %></a></div>
                        </li>
                    </ul>
                </li>
                <% if (PortalContext.CurrentUser.CanSignInOtherAccount || (PortalContext.Session.IAccountInfo != null && PortalContext.Session.IAccountInfo.UserLogin2 != null)) %>
                <% { %>
                <li class="dropdown vimenu">
                    <a href="javascript:void(0)" class="dropdown-toggle goto-user" data-toggle="dropdown">
                        <img style="height: 18px" src="/Web/Resources/Images/swith_user.png" /></a>
                    <ul class="dropdown-menu">
                        <li><a href="javascript:void(0)" class="config-runtime-user"><i class="fa fa-cog"></i><%= PortalContext.GetLabel("Cấu hình cá nhân") %></a></li>
                    </ul>
                </li>
                <% } %>
                <% else %>
                <% { %>
                <li class="dropdown"><a href="javascript:void(0)" class="dropdown-toggle config-runtime-user" data-toggle="dropdown"><i class="fa fa-cog"></i></a></li>
                <% } %>
                <!-- Tasks: style can be found in dropdown.less -->
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <img src="<%= "/Web/Resources/Images/" + CurrentLanguage.Icon %>" alt="<%= CurrentLanguage.Name %>" /></a>
                    <ul class="dropdown-menu" style="min-width: 130px">
                        <asp:Repeater runat="server" ID="rpLanguages">
                            <ItemTemplate>
                                <li class="dropdown"><a data-language-id="<%# Eval("LanguageId") %>" style="padding: 3px 10px; font-size: 12px; cursor: pointer">
                                    <img src="<%# "/Web/Resources/Images/" + Eval("Icon") %>" alt="<%# Eval("Name") %>" />
                                    <span><%# Eval("Name") %></span></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>
                <!-- Control Sidebar Toggle Button -->

            </ul>
        </div>
    </nav>
</header>
<!-- Left side column. contains the logo and sidebar -->
<aside class="main-sidebar hide">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
        <!-- search form -->
        <%--        <div class="sidebar-form">
            <div class="input-group">
                <input type="text" name="q" class="form-control" placeholder="Tìm chức năng..." />
                <span class="input-group-btn"><button type="button" name='search' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button></span>
            </div>
        </div>--%>
        <!-- /.search form -->
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <div id="areaMenuLeft">
            <web:MenuLeft runat="server" ID="menuLeft" />
        </div>
    </section>
    <!-- /.sidebar -->
</aside>
