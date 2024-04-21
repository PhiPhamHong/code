<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Land_Design_Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Design.Pages.Land_Design_Home" %>
<%@ Register Src="~/Projects/Landings/Landing_Design/Modules/About.ascx" TagPrefix="uc1" TagName="About" %>
<%@ Register Src="~/Projects/Landings/Landing_Design/Modules/Services.ascx" TagPrefix="uc1" TagName="Services" %>
<%@ Register Src="~/Projects/Landings/Landing_Design/Modules/Portfodio.ascx" TagPrefix="uc1" TagName="Portfodio" %>
<%@ Register Src="~/Projects/Landings/Landing_Design/Modules/Team.ascx" TagPrefix="uc1" TagName="Team" %>
<%@ Register Src="~/Projects/Landings/Landing_Design/Modules/Contact.ascx" TagPrefix="uc1" TagName="Contact" %>





<uc1:About runat="server" ID="About" />
<uc1:Services runat="server" ID="Services" />
<uc1:Portfodio runat="server" ID="Portfodio" />
<uc1:Team runat="server" ID="Team" />
<uc1:Contact runat="server" ID="Contact" />
