<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Core.FE.Suns.Projects.Web.Pages.Home" %>
<%@ Register Src="~/Projects/Web/Modules/About.ascx" TagPrefix="uc1" TagName="About" %>
<%@ Register Src="~/Projects/Web/Modules/Services.ascx" TagPrefix="uc1" TagName="Services" %>
<%@ Register Src="~/Projects/Web/Modules/Portfolio.ascx" TagPrefix="uc1" TagName="Portfolio" %>
<%@ Register Src="~/Projects/Web/Modules/Testimonials.ascx" TagPrefix="uc1" TagName="Testimonials" %>
<%@ Register Src="~/Projects/Web/Modules/Plans.ascx" TagPrefix="uc1" TagName="Plans" %>
<%@ Register Src="~/Projects/Web/Modules/Contact.ascx" TagPrefix="uc1" TagName="Contact" %>






<uc1:About runat="server" id="About" />
<uc1:Services runat="server" id="Services" />
<uc1:Portfolio runat="server" id="Portfolio" />
<uc1:Testimonials runat="server" id="Testimonials" />
<%--<uc1:Plans runat="server" id="Plans" />--%>
<uc1:Contact runat="server" id="Contact" />
