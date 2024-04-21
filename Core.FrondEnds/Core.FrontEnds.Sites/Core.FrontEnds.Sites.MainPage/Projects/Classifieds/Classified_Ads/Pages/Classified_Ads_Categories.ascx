<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_Ads_Categories.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads.Pages.Classified_Ads_Categories" %>
<%@ Register Src="~/Projects/Classifieds/Classified_Ads/Modules/Categories.ascx" TagPrefix="uc1" TagName="Categories" %>
<%@ Register Src="~/Projects/Classifieds/Classified_Ads/Modules/Download.ascx" TagPrefix="uc1" TagName="Download" %>
<%@ Register Src="~/Projects/Classifieds/Classified_Ads/Modules/MainCategories.ascx" TagPrefix="uc1" TagName="MainCategories" %>



<uc1:Categories runat="server" id="Categories" />

<uc1:MainCategories runat="server" id="MainCategories" />


<uc1:Download runat="server" id="Download" />
