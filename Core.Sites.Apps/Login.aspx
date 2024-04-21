<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="Core.Sites.Apps.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= PortalContext.GetLabel("SSERP | Phần mềm quản lý doanh nghiệp") %></title>
    <meta charset="UTF-8" />
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <link runat="server" id="fvc_Login" rel="shortcut icon" title="SSERP | Phần mềm quản lý doanh nghiệp" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed:300,400&display=swap&subset=vietnamese" rel="stylesheet" />
    <link rel="stylesheet" href="/Web/Resources/Login/css/animate.css" />
    <link rel="stylesheet" href="/Web/Resources/Login/css/style.css" />
    <link rel="stylesheet" href="/Web/Resources/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Web/Resources/bootstrap/fontawesome/css/fontawesome.min.css" />
    <link rel="stylesheet" href="/Web/Resources/plugins/owlcarousel2/assets/owl.carousel.min.css" />
    <link rel="stylesheet" href="/Web/Resources/plugins/owlcarousel2/assets/owl.theme.default.min.css" />
    <link rel="stylesheet" href="/Web/Resources/scss/auth-login.min.css" />
    <link href="/Web/Resources/Plugins/pnotify/pnotify.custom.min.css" rel="stylesheet" />
</head>
<body class="login-page h-100">
    <form id="form1" runat="server" class="bg-primary">
        <section class="login-section">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-4 bg-white">
                        <nav class="navbar osahan-navbar navbar-expand-lg navbar-dark wow animated fadeInDown" style="display: block;" id="mainNav" data-wow-delay="0.5s">
                            <div class="login-box">
                                <div class="login-logo pl-5 pr-5">
                                    <a href="#">
                                        <%--<img alt="LOGIN ADMIN SYSTEM" src="<%= AppSetting.BrandLogo %>" /></a>--%>
                                        <img alt="LOGIN ADMIN SYSTEM" src="/Web/Resources/Login/img/logo.jpg" /></a>
                                </div>
                                <div class="login-box-body">
                                    <div class="form-group text-center">
                                        <h3 class="text-uppercase text-primary mb-0 pb-2 pt-2"><%= PortalContext.GetLabel("Đăng nhập hệ thống") %></h3>
                                        <div id="message"></div>
                                    </div>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-user-circle" style="font-size: 18px"></i></span>
                                        </div>
                                        <input type="text" class="form-control" id="UserName" name="UserName" placeholder="<%= PortalContext.GetLabel("Tài khoản") %>" autocomplete="off" autofocus="autofocus" maxlength="100" />
                                    </div>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-unlock-alt" style="font-size: 18px"></i></span>
                                        </div>
                                        <input type="password" class="form-control" id="Password" name="Password" placeholder="<%= PortalContext.GetLabel("Mật khẩu") %>" autocomplete="off" maxlength="150" />
                                    </div>
                                    <style>
                                        .input-group-prepend {
                                            width: 45px;
                                            display: inline-grid;
                                        }
                                    </style>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-language"></i></span>
                                        </div>
                                        <asp:DropDownList CssClass="custom-select" AutoPostBack="false" runat="server" ID="dllLanguage" DataTextField="Name" DataValueField="LanguageId"></asp:DropDownList>
                                    </div>
                                    <div class="form-group d-flex justify-content-between align-items-center">
                                        <div class="custom-control custom-radio">
                                            <input type="radio" id="rememberMe" name="remember" class="custom-control-input" />
                                            <label class="custom-control-label font-weight-light" for="rememberMe"><%= PortalContext.GetLabel("Lưu mật khẩu") %></label>
                                        </div>
                                        <a href="#" class="font-weight-light"><%= PortalContext.GetLabel("Quên mật khẩu?") %></a>
                                    </div>
                                    <div class="form-group text-center">
                                        <asp:LinkButton runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-block btn-login btn-radius" OnClick="DoLogin">
                                        <i class="fas fa-sign-in-alt"></i> <%= PortalContext.GetLabel("Đăng nhập") %>
                                        </asp:LinkButton>
                                        <a href="#" class="font-weight-light d-block mt-3"><%= PortalContext.GetLabel("Đăng ký dùng thử") %></a>
                                    </div>
                                    <div class="form-group">
                                        <div id="loginload" class="text-center font-weight-bold"></div>
                                    </div>
                                    <div class="form-group text-center">
                                        <ul class="social-icons">
                                            <li><a class="s-icon facebook" href="#"><i class="fab fa-facebook-square"></i></a></li>
                                            <li><a class="s-icon youtube" href="#"><i class="fab fa-youtube-square"></i></a></li>
                                            <li><a class="s-icon instagram" href="#"><i class="fab fa-instagram"></i></a></li>
                                            <li><a class="s-icon email" href="#"><i class="fas fa-envelope"></i></a></li>
                                            <li><a class="s-icon phone" href="#"><i class="fas fa-phone-square"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- /.login-box-body -->
                            </div>
                        </nav>
                    </div>
                    <div class="col-md-8 info-box d-none d-sm-block">
                        <div id="particles-js"></div>
                        <section class="banner-block pb-0" id="banner">
                            <div class="container">
                                <div class="row">
                                    <div class="col-lg-12 text-center wow animated fadeInUp" data-wow-delay="0.5s">
                                        <h1 class="text-white"><strong>SSERP</strong> Software</h1>
                                        <p class="lead text-white"><%= PortalContext.GetLabel("SSERP là phần mềm hoạch định nguồn lực doanh nghiệp (ERP)") %>  </p>
                                        <p class="lead text-white"><%= PortalContext.GetLabel("Là một mô hình ứng dụng công nghệ thông tin vào quản lý hoạt động kinh doanh, thu thập dữ liệu, lưu trữ, phân tích diễn giải") %>   </p>
                                        <p class="lead text-white"><%= PortalContext.GetLabel("Tích hợp công cụ: kế hoạch sản phẩm, chi phí sản xuất hay dịch vụ giao hàng, tiếp thị và bán hàng, quản lý kho quỹ, kế toán, CRM...") %>   </p>
                                        <p class="mb-0">
                                            <button type="button" class="btn btn-light btn-lg">LIVE DEMO</button>
                                            &nbsp;
                                            <button type="button" class="btn btn-outline-light btn-lg">READ MORE</button>
                                        </p>
                                        <div class="col-xs-12 col-sm-12">
                                            <div class="life-cycle-wrapper">
                                                <div class="life-cycle">
                                                    <div class="life-cycle-cicle-wrapper">
                                                        <img class="life-cycle-circle" src="/Web/Resources/Login/img/life-cycle-circle.png" alt="" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>

            </div>
        </section>
        <%--<%= Request.Url.Authority %>--%>
        <script src="/Services/JsLabel.aspx?lang=<%= PortalContext.DefaultLanguage %>"></script>
        <script src="/js.axd?v=<%= AppSetting.VerJs %>" type="text/javascript"></script>
        <script src="/Web/Resources/Login/js/particles.js"></script>
        <script type="text/javascript">
            particlesJS("particles-js", { "particles": { "number": { "value": 80, "density": { "enable": true, "value_area": 800 } }, "color": { "value": "#ffffff" }, "shape": { "type": "circle", "stroke": { "width": 0, "color": "#000000" }, "polygon": { "nb_sides": 5 }, "image": { "src": "img/github.svg", "width": 100, "height": 100 } }, "opacity": { "value": 0.5, "random": false, "anim": { "enable": false, "speed": 1, "opacity_min": 0.1, "sync": false } }, "size": { "value": 3, "random": true, "anim": { "enable": false, "speed": 40, "size_min": 0.1, "sync": false } }, "line_linked": { "enable": true, "distance": 150, "color": "#ffffff", "opacity": 0.4, "width": 1 }, "move": { "enable": true, "speed": 6, "direction": "none", "random": false, "straight": false, "out_mode": "out", "bounce": false, "attract": { "enable": false, "rotateX": 600, "rotateY": 1200 } } }, "interactivity": { "detect_on": "canvas", "events": { "onhover": { "enable": true, "mode": "repulse" }, "onclick": { "enable": true, "mode": "push" }, "resize": true }, "modes": { "grab": { "distance": 400, "line_linked": { "opacity": 1 } }, "bubble": { "distance": 400, "size": 40, "duration": 2, "opacity": 8, "speed": 3 }, "repulse": { "distance": 200, "duration": 0.4 }, "push": { "particles_nb": 4 }, "remove": { "particles_nb": 2 } } }, "retina_detect": true });
        </script>
        <script type="text/javascript">Core.receiverMessage(<%= ResponseMessage.Current.ToJson() %>)</script>
        <script type="text/javascript" src="/Web/Resources/plugins/owlcarousel2/owl.carousel.min.js"></script>
        <script type="text/javascript" src="/Web/Resources/Scripts/auth-login.es5.min.js"></script>
        <script src="/Web/Resources/Plugins/pnotify/pnotify.custom.min.js"></script>
        <script type="text/javascript">
            $(function () {
                
                var userNameInput = document.getElementById("UserName");

                userNameInput.addEventListener("keydown", function (event) {
                    if (event.key === "Enter") {
                        if (userNameInput.val() != "") passwordInput.focus();
                    }
                });
                var passwordInput = document.getElementById("Password");
                passwordInput.addEventListener("keydown", function (event) {
                    if (event.key === "Enter") {
                        __doPostBack('btnLogin', '');
                    }
                });
            });
        </script>

    </form>
</body>
</html>
