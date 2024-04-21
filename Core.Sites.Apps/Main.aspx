<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" EnableViewState="false" Inherits="Core.Sites.Apps.Main" %>

<!DOCTYPE html>

<html class="app">
<head>
    <meta charset="UTF-8">
    <title>Quản lý hệ thống</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <meta property="og:image" content="<%= AppSetting.BrandFavicon %>" />
    <!-- Bootstrap 3.3.2 -->
    <link href="/css.axd?v=<%= AppSetting.VerJs %>" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="<%= AppSetting.BrandFavicon %>" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <% if (PortalContext.GlobalConfig.GoogleMapKey.IsNotNull()) %>
    <% { %>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=<%= PortalContext.GlobalConfig.GoogleMapKey %>"></script>
    <% } %>
    <%--<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?"></script>--%>
    <link href="https://fonts.googleapis.com/css2?family=PT+Sans&display=swap" rel="stylesheet">
</head>
<body class="<%= PortalContext.SessionType == Core.Business.Enums.SessionType.Account ? "skin-blue" : "skin-purple" %> header-function-fixed pace-done pace-done nav-function-fixed nav-mobile-push" id="page-top" >
    <div class="wrapper">
        <div class="content-wrapper" id="main">
            <div class="page-wrapper">
                <div class="page-inner">
                    <aside class="page-sidebar list-filter-active">
                        <div class="page-logo">
                            <a href="" class="page-logo-link press-scale-down d-flex align-items-center position-relative" style="padding: 10px;">
                                <img src="/Web/Resources/Images/favicon.png" alt="Logo" style="height: 70px;" />
                            </a>
                        </div>
                        <nav id="js-primary-nav" class="primary-nav js-list-filter" role="navigation" style="font-family: 'PT Sans', sans-serif;">
                            <div class="nav-filter">
                                <div class="position-relative">
                                    <input type="text" id="nav_filter_input" placeholder="Tìm kiếm tính năng" class="form-control" tabindex="0">
                                    <a href="" class="btn-search-close js-waves-off" data-action="toggle" data-class="list-filter-active" data-target=".page-sidebar">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </div>
                            </div>
                            <ul id="js-nav-menu" class="nav-menu sidebar accordion" style="width: 100% !important;">
                                <asp:Repeater runat="server" ID="menuTop" OnItemDataBound="menuTop_ItemDataBound">
                                    <ItemTemplate>
                                        <li class="nav-item">
                                            <a class="nav-link collapsed" data-top-url="<%# Eval("UrlVirtual") %>" data-toggle="collapse" data-target="#<%# Eval("UrlVirtual") %>" aria-expanded="true" aria-controls="collapseTwo">
                                                <i class="<%# Eval("Icon") %>"></i>
                                                <span>&nbsp <%# FromMenuItem(Container.DataItem) %></span>
                                                <%# Container.DataItem.As<MenuTop>().Groups.Count != 0 ? "":"" %>
                                            </a>
                                            <div id="<%# Eval("UrlVirtual") %>" class="collapse" aria-labelledby="<%# Eval("UrlVirtual") %>" data-parent="#js-primary-nav">
                                                <asp:PlaceHolder runat="server" ID="plcGroup"></asp:PlaceHolder>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>

                        </nav>
                    </aside>
                    <div class="page-content-wrapper d-flex flex-column" id="content-wrapper">
                        <header class="page-header" role="banner">
                            <div class="hidden-lg-up dropdown-icon-menu position-relative">
                                <a class="header-btn btn press-scale-down waves-effect waves-themed" onclick="OpenMenu(this)" data-action="toggle" data-class="nav-function-hidden"><i class="fa fa-bars"></i></a>
                            </div>

                            <div class="ml-auto d-flex">
                                <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow" style="height: 4.125rem;">
                                    <ul class="navbar-nav ml-auto">
                                        <li class="nav-item dropdown no-arrow notifications-menu">
                                            <a href="javascript:void(0)" data-notification="bell" class="dropdown-toggle  nav-link" data-toggle="dropdown" style="padding-bottom: 10px; padding-top: 10px; text-align: center;" aria-haspopup="true" aria-expanded="false">
                                                <i class="fas fa-bell fa-2x"></i>
                                                <label class="label label-danger faa-pulse animated" data-notification="label" style="top: 8px; right: 0px;"></label>
                                            </a>
                                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                                                <a class="header dropdown-item" data-notification="header"><%= PortalContext.GetLabel("Đang tải") %></a>
                                                <a class="dropdown-item">
                                                    <ul class="menu" data-notification="content" style="list-style-type:none;padding-left: 0;line-height: 2;"></ul>
                                                </a>
                                                <div style="text-align:center;">
                                                    <a class="footer dropdown-item" data-notification="footer"><a href="/thong-bao-cua-toi.html"><%= PortalContext.GetLabel("Xem tất cả") %></a></a>
                                                </div>
                                            </div>
                                        </li>

                                        <li class="nav-item dropdown no-arrow navbar-custom-menu">
                                            <a href="" class="dropdown-toggle nav-link" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <img class="img-profile rounded-circle" src="/Web/Resources/Images/avatar160x160.png" data-src="<%= PortalContext.CurrentUser.User.Avatar.WhenEmpty(()=> "/Web/Resources/Images/avatar160x160.png")  %>" class="user-avatar user-image" alt="<%= PortalContext.CurrentUser.User.FullName %>" />
                                                <span class="mr-2 d-none d-lg-inline text-gray-600 small hidden-xs<%= PortalContext.Session.IAccountInfo.User_2() != 0 ? " text-yellow" : "" %>"><%= PortalContext.CurrentUser.User.FullName %></span>
                                            </a>


                                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                                                <a class="dropdown-item" href="<%= UrlHelper.UpdateInfoUser %>">
                                                    <i class="fa fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                                                    <%= PortalContext.GetLabel("Thông tin") %></a>
                                                <a class="dropdown-item config-runtime-user" href="javascript:void(0)">
                                                    <i class="fa fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                                                    <%= PortalContext.GetLabel("Cấu hình cá nhân") %></a>
                                                <div class="dropdown-divider"></div>
                                                <% if (PortalContext.CurrentUser.CanSignInOtherAccount || (PortalContext.Session.IAccountInfo != null && PortalContext.Session.IAccountInfo.UserLogin2 != null)) %>
                                                <%{ %>
                                                <a href="javascript:void(0)" class="dropdown-item dropdown-toggle goto-user" data-toggle="dropdown">
                                                    <i class="fa fa-users fa-sm fa-fw mr-2 text-gray-400"></i>
                                                    <%= PortalContext.GetLabel("Đăng nhập tài khoản khác") %></a>
                                                <%} %>
                                                <a class="dropdown-item" href="javascript:void(0)" onclick="Core.logout()" data-toggle="modal">
                                                    <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                                    Logout </a>
                                            </div>
                                        </li>

                                        <li class="nav-item dropdown no-arrow">
                                            <a href="" class="dropdown-toggle nav-link" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <img class="img-profile rounded-circle" src="<%= "/Web/Resources/Images/" + CurrentLanguage.Icon %>" alt="<%= CurrentLanguage.Name %>" /></a>
                                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown" style="width: 130px !important">
                                                <asp:Repeater runat="server" ID="rpLanguages">
                                                    <ItemTemplate>
                                                        <a class="dropdown-item" data-language-id="<%# Eval("LanguageId") %>" style="padding: 3px 10px; font-size: 12px; cursor: pointer">
                                                            <img src="<%# "/Web/Resources/Images/" + Eval("Icon") %>" alt="<%# Eval("Name") %>" />
                                                            <span><%# Eval("Name") %></span></a>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </li>
                                    </ul>
                                </nav>

                            </div>



                        </header>
                        <main id="js-page-content" role="main" class="page-content" onclick="HideMenu()">
                            <web:Content runat="server" />
                        </main>
                    </div>

                </div>
            </div>
        </div>
        <web:Footer runat="server" ID="Footer" />
    </div>

    <script src="/Services/JsLabel.aspx?lang=<%= PortalContext.DefaultLanguage %>"></script>
    <script src="/js.axd?v=<%= AppSetting.VerJs %>" type="text/javascript"></script>
    <script src="<%= AppSetting.HubServer %>/signalr/hubs"></script>
    <script src="/Web/Resources/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript">CKEDITOR.timestamp ='<%= AppSetting.VerJs %>';</script>
    <script src="/Web/Resources/ckeditor/adapters/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        Core.receiverMessage(<%= ResponseMessage.Current.ToJson() %>);
        Core.project = '<%= ConfigurationManager.AppSettings["Project"] %>';
    </script>


    <script type="text/javascript">
        function OpenMenu(form) {
            var body = $(document).find("#page-top");
            if (body.hasClass("mobile-nav-on")) {
                body.removeClass("mobile-nav-on");
            }
            else {
                body.addClass("mobile-nav-on");
            }
        }
        function HideMenu() {
            var body = $(document).find("#page-top");
            if (body.hasClass("mobile-nav-on")) {
                body.removeClass("mobile-nav-on");
            }
        }
    </script>

    <style>
        .in {
            display: block !important;
        }
    </style>
</body>
</html>
