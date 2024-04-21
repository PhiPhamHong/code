﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SEO_EmailTemplate.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother.Pages.Features.SEO_EmailTemplate" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script type="text/javascript" async src="https://www.googletagmanager.com/gtag/js?id=UA-120909275-1"></script>
    <script type="text/javascript">
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-120909275-1');
    </script>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <meta name="description" content="Osahan Fashion - Bootstrap 4 E-Commerce Theme" />
    <meta name="keywords" content="Osahan, fashion, Bootstrap4, shop, e-commerce, modern, flat style, responsive, online store, business, mobile, blog, bootstrap 4, html5, css3, jquery, js, gallery, slider, touch, creative, clean" />
    <meta name="author" content="Askbootstrap" />
    <title>Osahan Fashion - Bootstrap 4 E-Commerce Theme</title>
    <!-- Favicon Icon -->
    <link rel="apple-touch-icon" sizes="76x76" href="/Projects/Web/Resources/images/apple-icon.png">
    <link rel="icon" type="image/png" href="/Projects/Web/Resources/images/favicon.png">
    <link type="text/css" href="https://fonts.googleapis.com/css?family=Roboto+Condensed:300,400,700" rel="stylesheet">
    <style type="text/css">
        img {
            max-width: 100%;
        }

        .collapse {
            padding-right: 15px;
            padding: 0;
        }

        body {
            -webkit-font-smoothing: antialiased;
            -webkit-text-size-adjust: none;
            width: 100% !important;
            height: 100%;
            margin: 0px;
            padding: 0px;
            font-family: 'Roboto Condensed', sans-serif;
        }

        a {
            color: #aaaaaa;
            font-size: 12px;
        }

        .bt {
            padding-top: 10px;
        }

        p.callout {
            padding: 9px;
            font-size: 12px;
        }

        p.text {
            padding-left: 5px;
            font-size: 12px;
        }

        .prod.img-border img {
            border: 1px solid rgba(193, 193, 193, 0.62);
            border-radius: 9px;
            padding: 18px 0 0;
        }

        p.left {
            padding: 5px;
            font-size: 12px;
            text-align: left;
        }

        .prod {
            margin: 0;
            padding: 0;
            color: #aaaaaa;
        }

        .callout a {
            font-weight: bold;
            color: #aaaaaa;
        }

        table.head-wrap {
            width: 100%;
        }

        .header.container table td.logo {
            padding: 15px;
        }

        .header.container table td.label {
            padding: 15px;
            padding-left: 0px;
        }

        table.body-wrap {
            width: 100%;
        }

        table.footer-wrap {
            width: 100%;
            background-color: #f5f5f5;
            height: 50px;
        }

        table.footer-wrap2 {
            width: 100%;
        }

        }

        h1, h2, h3, h4, h5, h6 {
            font-family: "Helvetica Neue",Helvetica,Arial,"Lucida Grande",sans-serif;
            line-height: 1.1;
            margin-bottom: 5px;
            color: #000;
        }

            h1 small, h2 small, h3 small, h4 small, h5 small, h6 small {
                font-size: 60%;
                color: #6f6f6f;
                line-height: 0;
                text-transform: none;
            }

        h1 {
            font-weight: 200;
            font-size: 18px;
            padding: 20px;
            letter-spacing: 3px;
            font-weight: 300;
        }

        h2 {
            font-weight: 200;
            font-size: 37px;
        }

        h3 {
            font-weight: 500;
            font-size: 27px;
        }

        h4 {
            font-weight: 500;
            font-size: 23px;
        }

        h5 {
            font-weight: 900;
            font-size: 13px;
            color: #c2a67e;
        }

        h6 {
            font-weight: 900;
            font-size: 14px;
            text-transform: uppercase;
            color: #444;
        }

        h7 {
            font-weight: 900;
            font-size: 14px;
            text-transform: uppercase;
            color: #444;
            padding: 5px;
        }

        .collapse {
            margin: 0 !important;
        }

        p, ul {
            margin-bottom: 2px;
            font-weight: normal;
            font-size: 11px;
            line-height: 1.6;
        }

            p.lead {
                font-size: 13px;
            }

            p.last {
                margin-bottom: 0px;
            }

            ul li {
                margin-left: 5px;
                list-style-position: inside;
            }

        .container {
            box-shadow: 0 0 6px rgba(193, 193, 193, 0.62);
            clear: both;
            display: block;
            margin: 0 auto;
            max-width: 600px;
            padding: 12px 20px;
        }

        .content {
            padding: 5px;
            max-width: 600px;
            margin: 0 auto;
            display: block;
        }

            .content table {
                width: 100%;
            }

        .column {
            width: 300px;
            float: left;
        }

            .column tr td {
                padding: 5px;
            }

        .column-wrap {
            padding: 0 !important;
            margin: 0 auto;
            max-width: 600px !important;
        }

        .column table {
            width: 100%;
        }

        .social .column {
            width: 280px;
            min-width: 279px;
            float: left;
        }

        .column3 {
            width: 300px;
            float: left;
        }

            .column3 tr td {
                padding: 1px;
            }

        .column3-wrap {
            padding: 0 !important;
            margin: 0 auto;
            max-width: 600px !important;
        }

        .column3 table {
            width: 100%;
        }

        .column2 {
            width: 240px;
            float: left;
        }

            .column2 tr td {
                padding: 5px;
            }

        .column2-wrap {
            padding: 0 !important;
            margin: 0 auto;
            max-width: 600px !important;
        }

        .column2 table {
            width: 100%;
        }

        .social .column {
            width: 280px;
            min-width: 279px;
            float: left;
        }

        .prod {
            width: 200px;
            float: left;
        }

            .prod tr td {
                padding: 5px;
            }

        .prod-wrap {
            padding: 0 !important;
            margin: 0 auto;
            max-width: 600px !important;
        }

        .prod table {
            width: 100%;
        }

        .prod .column {
            width: 200px;
            min-width: 200px;
            float: left;
        }

        .clear {
            display: block;
            clear: both;
        }

        @media only screen and (max-width:600px) {
            a[class="btn"] {
                display: block !important;
                margin-bottom: 10px !important;
                background-image: none !important;
                margin-right: 0 !important;
            }

            div[class="column"] {
                width: auto !important;
                float: none !important;
            }

            div[class="column2"] {
                width: auto !important;
                float: none !important;
            }

            div[class="column3"] {
                width: auto !important;
                float: none !important;
            }

            table[class="top"] {
                width: auto !important;
                float: none !important;
            }

            .prod {
                width: 150px;
                float: left;
            }

            table.social div[class="column"] {
                width: auto !important;
            }
        }
    </style>
</head>
<body bgcolor="#f5f8fc" topmargin="0" leftmargin="0" marginheight="0" marginwidth="0">
    <img editable="true" />
    <table class="head-wrap" bgcolor="#f5f5f5">
        <tr>
            <td></td>
            <td class="header container">
                <div class="content">
                    <table bgcolor="#f5f5f5" class="">
                        <tr>
                            <td>
                                <a href="index.html">
                                    <img src="/Projects/Web/Resources/images/email/logo.png" /></a>
                            </td>
                            <td align="right">
                                <h6 class="collapse">End Of Reason Sale- Get Min <strong>40- 80%</strong> off!
                                </h6>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td></td>
        </tr>
    </table>
    <!------------------------------------ ---- BODY -------------------------- ------------------------------------->
    <table class="body-wrap">
        <tr>
            <td></td>
            <td class="container" bgcolor="#FFFFFF">
                <!-- content -->
                <div class="content">
                    <table bgcolor="" class="social" width="100%">
                        <tr>
                            <td align="center">
                                <h1>CLOTHING <strong>MEN'S</strong> AND <strong>WOMEN'S</strong>
                                </h1>
                                <a href="#">
                                    <img src="/Projects/Web/Resources/images/email/slider1.jpg" /></a>
                                <a href="#">
                                    <img src="/Projects/Web/Resources/images/email/slider2.jpg" /></a>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- COLUMN WRAP -->
                <div class="column-wrap">
                    <div class="column">
                        <table bgcolor="" class="social" width="100%">
                            <tr>
                                <td>
                                    <p>
                                        <a href="#">
                                            <img src="/Projects/Web/Resources/images/email/small1.png" /></a>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="left" width="100%">
                                        <tr>
                                            <p class="text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500.
                                            </p>
                                            <p class="bt">
                                                <a href="#">
                                                    <img src="/Projects/Web/Resources/images/email/btn_shop.jpg" /></a>
                                            </p>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="column">
                        <table bgcolor="" class="social" width="100%">
                            <tr>
                                <td>
                                    <p>
                                        <a href="#">
                                            <img src="/Projects/Web/Resources/images/email/small2.png" /></a>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="left" width="100%">
                                        <tr>
                                            <p class="text">
                                                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500.
                                            </p>
                                            <p class="bt">
                                                <a href="#">
                                                    <img src="/Projects/Web/Resources/images/email/btn_shop.jpg" /></a>
                                            </p>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="content">
                        <!-- Line -->
                        <table width="18" height="81">
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="1150" style="border-bottom: 1px solid #e5e5e5;"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                            <!-- DIVIDER TITLE -->
                            <td align="center" valign="middle">
                                <tr>
                                    <td height="0" border="5px" cellspacing="0" cellpadding="0">
                                        <h6>Featured Items </h6>
                                    </td>
                                </tr>
                            </td>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="1150" style="border-bottom: 1px solid #e5e5e5;"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </table>
                    </div>
                    <!------------------------------------ ---- PRODUCT LINE ONE -------------------------- ------------------------------------->
                    <div class="prod img-border">
                        <table bgcolor="" class="social" width="100%">
                            <tr>
                                <td>
                                    <p>
                                        <a href="#">
                                            <img src="/Projects/Web/Resources/images/email/prod.jpg" /></a>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="left" width="100%">
                                        <p>
                                            <h6>Ipsums Dolors Untra</h6>
                                        </p>
                                        <p>
                                            TOMMY
                                        </p>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="prod img-border">
                        <table bgcolor="" class="social" width="100%">
                            <tr>
                                <td>
                                    <p>
                                        <a href="#">
                                            <img src="/Projects/Web/Resources/images/email/prod2.jpg" /></a>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="left" width="100%">
                                        <p>
                                            <h6>Ipsums Dolors Untra </h6>
                                        </p>
                                        <p>
                                            NIKE
                                        </p>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="prod img-border">
                        <table bgcolor="" class="social" width="100%">
                            <tr>
                                <td>
                                    <p>
                                        <a href="#">
                                            <img src="/Projects/Web/Resources/images/email/prod3.jpg" /></a>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="left" width="100%">
                                        <h6>Ipsums Dolors Untra</h6>
                                        <p>
                                            POLO
                                        </p>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!------------------------------------ ---- BTN IPHONE -------------------------- ------------------------------------->
                    <div class="content">
                        <table align="center" width="100%">
                            <tr>
                                <td align="center">
                                    <br>
                                    <a href="#">
                                        <img src="/Projects/Web/Resources/images/email/btn_shop.jpg" /></a>
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <br>
                    </div>
                    <!------------------------------------ ---- BOTTOM BANNER -------------------------- ------------------------------------->
                    <div class="content">
                        <table>
                            <tr>
                                <td align="center">
                                    <p>
                                        <a href="#">
                                            <img src="/Projects/Web/Resources/images/email/top_banner.gif" /></a>
                                    </p>
                                    <!-- /hero -->
                                    <!-- Callout Panel -->
                                    <p class="left">
                                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500.
                                        <br>
                                        <a href="#">Read more</a>
                                    </p>
                                    <p>
                                        <a href="#">
                                            <img src="/Projects/Web/Resources/images/email/app.jpg" /></a>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </td>
            <td></td>
        </tr>
    </table>
    <!-- FOOTER -->
    <table class="footer-wrap">
        <tr>
            <td></td>
            <td class="container">
                <!-- content -->
                <div class="content">
                    <table>
                        <tr>
                            <td align="center">
                                <p>
                                    <a href="#">Terms</a> | <a href="#">Privacy</a> | <a href="#">Unsubscribe</a>
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- /content -->
            </td>
            <td></td>
        </tr>
    </table>
    <!-- /FOOTER -->
</body>
</html>

