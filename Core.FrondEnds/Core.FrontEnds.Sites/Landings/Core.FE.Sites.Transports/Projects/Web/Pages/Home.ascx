<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Pages.Home" %>
<%@ Register Src="~/Projects/Web/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Projects/Web/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<uc1:Header runat="server" ID="Header" />
<div class="banner">
    <div class="img">
        <section class="text-center ">
            <div class="owl-carousel-featured owl-theme owl-carousel">

                <div class="item">
                    <img src="/Projects/Web/Resources/img/banner.png" alt="">
                </div>
                <div class="item">
                    <img src="/Projects/Web/Resources/img/banner.jpg" alt="">
                </div>

                <asp:Repeater runat="server" ID="rpbanner">
                    <ItemTemplate>
                        <%--<div class="item">
                            <img src="<%# GetFullImage(Eval("Picture")) %>" alt="">
                        </div>--%>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>
    </div>
</div>
<uc1:Footer runat="server" ID="Footer" />
