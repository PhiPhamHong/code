<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Land_Edu_Home.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Edu.Pages.Land_Edu_Home" %>

<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/About_Us.ascx" TagPrefix="uc1" TagName="About_Us" %>
<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/Courses.ascx" TagPrefix="uc1" TagName="Courses" %>
<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/Demo.ascx" TagPrefix="uc1" TagName="Demo" %>
<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/Testimonials.ascx" TagPrefix="uc1" TagName="Testimonials" %>
<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/Pricing.ascx" TagPrefix="uc1" TagName="Pricing" %>
<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/Team.ascx" TagPrefix="uc1" TagName="Team" %>
<%@ Register Src="~/Projects/Landings/Landing_Edu/Modules/Contact_Us.ascx" TagPrefix="uc1" TagName="Contact_Us" %>







<uc1:About_Us runat="server" id="About_Us" />


<uc1:Courses runat="server" id="Courses" />
<uc1:Demo runat="server" id="Demo" />
<uc1:Testimonials runat="server" id="Testimonials" />
<uc1:Pricing runat="server" id="Pricing" />
<uc1:Team runat="server" id="Team" />
<uc1:Contact_Us runat="server" id="Contact_Us" />
