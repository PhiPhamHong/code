<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteHead.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Controls.SiteHead" %>
<header>
    <div class="wrapper hide-menu" style="background:#ffffff65">
        <button class="touch-menu"></button>
        <div class="left">
            <div class="logo">
                <a href="<%= Url("Home") %>">
                    <img src="<%= GetFullImage(Com.SiteImage) %>" alt="">
                </a>
            </div>
            <div class="navigation">
                <button class="back" onclick="goBack()">Back </button>
                <button class="forward" onclick="goNext()">Forward </button>

            </div>
        </div>
        
            <div class="sologan">
                <marquee>
                    <h2><%= Label("Hiệu quả - Tin cậy - An toàn") %></h2>
                </marquee>
            </div>
       
        
    </div>
</header>

<script>

    function goBack() {
        window.history.back();
    }
    function goNext() {
        window.history.forward();
    }
</script>
