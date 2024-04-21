<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Web.Pages.Home" %>
<%@ Register Src="~/Projects/Web/Modules/About.ascx" TagPrefix="uc1" TagName="About" %>
<%@ Register Src="~/Projects/Web/Modules/Services.ascx" TagPrefix="uc1" TagName="Services" %>
<%@ Register Src="~/Projects/Web/Modules/Portfodio.ascx" TagPrefix="uc1" TagName="Portfodio" %>
<%@ Register Src="~/Projects/Web/Modules/Team.ascx" TagPrefix="uc1" TagName="Team" %>
<%@ Register Src="~/Projects/Web/Modules/Contact.ascx" TagPrefix="uc1" TagName="Contact" %>


<header id="header">
    <div class="intro">
        <div class="overlay overlay-none">
            <!-- muted -->
            <video loop="loop" muted="muted" autoplay  poster="/Projects/Web/Resources/images/screenshot.jpg" id="background">
                <source src="/Projects/Web/Resources/images/video.mp4" type="video/mp4">
            </video>
            <div class="container">
                <div class="row"> 
                    <div class="intro-text">
                        <h3><b style="font-weight:400">TEAM</b></h3>
                        <h1>Design</h1>
                        <p>Thiết kế website chuẩn SEO</p>
                        <button type="button" class="btn btn-custom btn-lg" data-toggle="modal" data-target="#work-modal"> Liên hệ ngay! </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>
<uc1:About runat="server" ID="About" />
<uc1:Services runat="server" ID="Services" />
<uc1:Portfodio runat="server" ID="Portfodio" />
<uc1:Team runat="server" ID="Team" />
<uc1:Contact runat="server" ID="Contact" />
