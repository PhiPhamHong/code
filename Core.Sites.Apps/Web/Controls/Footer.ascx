<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.Footer" %>

<footer class="main-footer" style="padding:10px; background:white;bottom: 0;width: 100%;z-index: 99999;">
    <!-- Load Facebook SDK for JavaScript -->
    <div id="fb-root"></div>
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                xfbml: true,
                version: 'v7.0'
            });
        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = 'https://connect.facebook.net/en_US/sdk/xfbml.customerchat.js';
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));</script>

    <!-- Your Chat Plugin code -->
    <div class="fb-customerchat" attribution="setup_tool" page_id="102883081476230" theme_color="#13cf13" logged_in_greeting="Chúng tôi có thể giúp gì cho bạn?" logged_out_greeting="Chúng tôi có thể giúp gì cho bạn?"></div>
    <div class="pull-right hidden-xs">
        <b>Version</b> 1.0.6
    </div>
    <strong>Copyright &copy; <%= DateTime.Today.Year - 1 %> - <%= DateTime.Today.Year %> <a href="https://facebook.com/PGT.Zeus" target="_blank"> Smart ERP Sorfware (SSERP) </a>.</strong> All rights reserved.
</footer>
