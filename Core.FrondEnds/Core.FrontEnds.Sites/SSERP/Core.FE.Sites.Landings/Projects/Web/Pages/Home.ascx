<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Core.FE.Sites.Landings.Projects.Web.Pages.Home" %>

<%@ Register Src="~/Projects/Web/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Projects/Web/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<link type="text/css" href="/Projects/Web/Resources/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link type="text/css" href="/Projects/Web/Resources/vendor/font/css/fontawesome-all.css" media="all" rel="stylesheet" />
<link type="text/css" href="/Projects/Web/Resources/vendor/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" />
<link type="text/css" href="/Projects/Web/Resources/vendor/owlcarousel/assets/owl.theme.default.min.css" rel="stylesheet" />
<link type="text/css" href="/Projects/Web/Resources/css/animate.css" rel="stylesheet" />
<link type="text/css" href="/Projects/Web/Resources/css/style.css" rel="stylesheet" />



<%@ Register Src="~/Projects/Web/Modules/Features.ascx" TagPrefix="uc1" TagName="Features" %>
<%@ Register Src="~/Projects/Web/Modules/Videos.ascx" TagPrefix="uc1" TagName="Videos" %>
<%@ Register Src="~/Projects/Web/Modules/Screens.ascx" TagPrefix="uc1" TagName="Screens" %>
<%@ Register Src="~/Projects/Web/Modules/Testimonials.ascx" TagPrefix="uc1" TagName="Testimonials" %>
<%@ Register Src="~/Projects/Web/Modules/Pricing.ascx" TagPrefix="uc1" TagName="Pricing" %>
<%@ Register Src="~/Projects/Web/Modules/Team.ascx" TagPrefix="uc1" TagName="Team" %>
<%@ Register Src="~/Projects/Web/Modules/Comments.ascx" TagPrefix="uc1" TagName="Comments" %>
<%@ Register Src="~/Projects/Web/Modules/FreeTrial.ascx" TagPrefix="uc1" TagName="FreeTrial" %>





<uc1:Header runat="server" />


<uc1:Features runat="server" ID="Features" />
<uc1:Videos runat="server" ID="Videos" />
<uc1:Screens runat="server" ID="Screens" />
<uc1:Testimonials runat="server" ID="Testimonials" />
<uc1:Pricing runat="server" ID="Pricing" />
<uc1:Team runat="server" ID="Team" />
<uc1:Comments runat="server" ID="Comments" />
<uc1:FreeTrial runat="server" ID="FreeTrial" />



<uc1:Footer runat="server" />





<script type="text/javascript" src="/Projects/Web/Resources/vendor/jquery/jquery.min.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/jquery-easing/jquery.easing.min.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/scrolling-nav/scrolling-nav.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/contact/jqBootstrapValidation.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/contact/contact_me.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/particles/particles.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/owlcarousel/owl.carousel.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/animate/animate.js"></script>
<script type="text/javascript" src="/Projects/Web/Resources/vendor/custom/custom.js"></script>
