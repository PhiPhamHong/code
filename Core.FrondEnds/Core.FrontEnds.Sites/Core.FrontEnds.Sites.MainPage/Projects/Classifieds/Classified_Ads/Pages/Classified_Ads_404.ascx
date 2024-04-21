<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_Ads_404.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads.Pages.Classified_Ads_404" %>
<section class="not-found">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3 text-center">
                <div class="error-page">
                    <h1 class="error">404 </h1>
                    <h2>Not Found</h2>
                    <div class="error-details">
                        Sorry, an error has occured. Requested page not found!
                    </div>
                    <form class="form-search">
                        <div class="form-group">
                            <input type="text" class="form-control found-search" placeholder="Search">
                        </div>
                        <a href="<%= Url("Classified_Ads") %>" class="btn btn-default btn-large btn-lg">Go Home</a>
                        <button type="submit" class="btn btn-default btn-large btn-lg">Search</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</section>
