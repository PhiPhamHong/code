<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Land_Contruction_Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Contruction.Pages.Land_Contruction_Home" %>
<%@ Register Src="~/Projects/Landings/Landing_Contruction/Modules/About.ascx" TagPrefix="uc1" TagName="About" %>
<%@ Register Src="~/Projects/Landings/Landing_Contruction/Modules/Services.ascx" TagPrefix="uc1" TagName="Services" %>
<%@ Register Src="~/Projects/Landings/Landing_Contruction/Modules/Portfolio.ascx" TagPrefix="uc1" TagName="Portfolio" %>
<%@ Register Src="~/Projects/Landings/Landing_Contruction/Modules/Testimonials.ascx" TagPrefix="uc1" TagName="Testimonials" %>
<%@ Register Src="~/Projects/Landings/Landing_Contruction/Modules/Plans.ascx" TagPrefix="uc1" TagName="Plans" %>
<%@ Register Src="~/Projects/Landings/Landing_Contruction/Modules/Contact.ascx" TagPrefix="uc1" TagName="Contact" %>






<uc1:About runat="server" id="About" />
<uc1:Services runat="server" id="Services" />
<uc1:Portfolio runat="server" id="Portfolio" />
<uc1:Testimonials runat="server" id="Testimonials" />
<uc1:Plans runat="server" id="Plans" />
<uc1:Contact runat="server" id="Contact" />
