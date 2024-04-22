<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Controls.Footer" %>
<footer>
    <div class="row" style="    align-items: center;">
        <div class="col-md-2 col-sm-12">
            <div>
                <a href="#" target="_blank" style="color: white; padding: 5px">
                    <svg xmlns="http://www.w3.org/2000/svg" width="33" height="33" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" stroke="currentColor">
                        <path d="M6.5 10v4h3v7h4v-7h3l1-4h-4V8c0-.545.455-1 1-1h3V3h-3c-2.723 0-5 2.277-5 5v2z" />
                    </svg>
                </a>
                <a href="#" target="_blank" style="color: white; padding: 5px">
                    <svg xmlns="http://www.w3.org/2000/svg" width="33" height="33" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" stroke="currentColor">
                        <path d="M15.6 14.522c-2.395 2.52-8.504-3.534-6.1-6.064 1.468-1.545-.19-3.31-1.108-4.609-1.723-2.435-5.504.927-5.39 3.066.363 6.746 7.66 14.74 14.726 14.042 2.21-.218 4.75-4.21 2.214-5.669-1.267-.73-3.008-2.17-4.342-.767" />
                    </svg></a>
                <a href="#" target="_blank" style="color: white;">
                    <svg xmlns="http://www.w3.org/2000/svg" width="33" height="33" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" stroke="currentColor">
                        <path d="m2.357 7.714 6.98 4.654c.963.641 1.444.962 1.964 1.087a3 3 0 0 0 1.398 0c.52-.125 1.001-.446 1.963-1.087l6.98-4.654M7.158 19.5h9.686c1.68 0 2.52 0 3.162-.327a3 3 0 0 0 1.31-1.311c.328-.642.328-1.482.328-3.162V9.3c0-1.68 0-2.52-.327-3.162a3 3 0 0 0-1.311-1.311c-.642-.327-1.482-.327-3.162-.327H7.157c-1.68 0-2.52 0-3.162.327a3 3 0 0 0-1.31 1.311c-.328.642-.328 1.482-.328 3.162v5.4c0 1.68 0 2.52.327 3.162a3 3 0 0 0 1.311 1.311c.642.327 1.482.327 3.162.327" />
                    </svg>
                </a>
            </div>

        </div>
        <div class="col-md-7">
            <section class="carousel-slider-main text-center" style="padding:10px;">
                <div class="owl-carousel-category owl-theme owl-carousel">
                    <asp:Repeater runat="server" ID="rpPartner">
                        <ItemTemplate>
                            <div class="item">
                                <a href="<%# Eval("Link") %>" target="_blank">
                                    <img src="<%# Eval("Logo") %>" alt="<%# Eval("Name") %>" style="height: 67px; width: 67px; border-radius: 50%">
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </section>
        </div>
        <div class="col-md-2 col-sm-12">
            <div class="icon">
                <img src="/Projects/Web/Resources/img/truck.png" alt="">
            </div>
        </div>
    </div>
</footer>
