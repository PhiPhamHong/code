﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_Ads_BlogDetail.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads.Pages.Classified_Ads_BlogDetail" %>
<%@ Register Src="~/Projects/Classifieds/Classified_Ads/Modules/Download.ascx" TagPrefix="uc1" TagName="Download" %>

<section class="breadcumb_area">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 text-center">
                <div class="breadcumb_section">
                    <div class="page_title">
                        <h3>Blog Details</h3>
                    </div>
                    <div class="page_pagination">
                        <ul>
                            <li><a href="<%= Url("Classified_Ads") %>">Home</a></li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>Blog Details</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Breadcumb -->

<!-- Blog Details -->
<section class="blog-details">
    <div class="container">
        <div class="row">
            <div class="col-sm-10 col-sm-offset-1">
                <div class="panel blog-article-box">
                    <div class="panel-heading">
                        <h4>Maecenas placerat facilisis </h4>
                        <small>There are many variations of passages of Lorem Ipsum available</small>
                        <div class="text-muted small">
                            Created by: <span class="font-bold">Mike Smith</span>
                            21.03.2017, 06:45 pm
                        </div>
                    </div>
                    <div class="panel-image">
                        <img class="img-responsive" src="/Projects/Classifieds/Classified_Ads/Resources/images/blog/blog-01.jpg" alt="">
                    </div>
                    <div class="panel-body">
                        <p>
                            Maecenas placerat facilisis interdum. Mauris eu dolor nisi. Suspendisse ullamcorper purus nec nibh maximus, ut sollicitudin enim venenatis.
                           Nullam interdum, odio sit amet dapibus mollis, ligula diam pretium sapien, eget suscipit felis ipsum sed lorem.
                            <br>
                            <br>
                            Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur ultrices aliquam nisi, vel semper augue auctor eu. Pellentesque a
                           sollicitudin tellus. Aenean posuere pharetra ipsum, ornare pretium lorem convallis non. Vivamus ac sodales sem. Nunc congue dolor ut dui maximus, imperdiet sollicitudin
                           velit auctor. Integer tincidunt iaculis vehicula. Nunc faucibus orci non imperdiet ultricies. Nunc pellentesque dui nisi, vel convallis quam malesuada ornare. Nunc ac purus
                           velit. Cras aliquet porta sodales. Proin blandit ornare bibendum.
                        </p>
                        <br>
                        <blockquote class="pull-left" style="max-width: 250px">
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        </blockquote>
                        <p>
                            There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in
                           some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum...
                        </p>
                        <br>
                        <p>
                            Duis rutrum felis at lorem scelerisque, vel iaculis risus viverra. Integer sed gravida libero. Maecenas sit amet lacus et erat rhoncus sodales quis non nunc. Morbi in
                           mattis massa. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Phasellus bibendum posuere sapien eget vehicula. Nulla sit amet
                           laoreet ante, sed ornare mauris. In interdum ex et leo suscipit sagittis. Pellentesque ac eleifend quam. Nam eu lacinia lacus. Vestibulum lacinia nisl lectus, fringilla
                           molestie diam imperdiet dignissim.
                        </p>
                        <p>
                            In scelerisque urna ut neque imperdiet, sit amet pretium eros suscipit. Cras efficitur ante sit amet mi porta, varius volutpat nulla hendrerit. Pellentesque nec risus
                           malesuada, scelerisque libero at, lacinia magna. Aliquam tellus nunc, viverra in ipsum sed, tristique finibus nibh. Proin gravida lobortis erat, nec aliquam lorem eleifend
                           eget. Integer quis augue id felis ultricies finibus. Curabitur et ligula mauris. Suspendisse vel fringilla quam. Quisque quis metus rhoncus, eleifend leo in, sagittis
                           libero. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Fusce ullamcorper nisl risus, a scelerisque dui hendrerit nec.
                        </p>
                        <br>
                        <blockquote class="pull-right" style="max-width: 250px">
                            <p>Fusce ac tellus eu nisl lobortis maximus</p>
                        </blockquote>
                        <p>
                            Praesent eget euismod nibh. Fusce ac tellus eu nisl lobortis maximus ac eget sapien. Nulla malesuada mauris non nulla imperdiet ullamcorper.
                        </p>
                        <br>
                        <p>
                            Sed porta libero metus, nec feugiat enim pharetra vel. Sed vel sagittis augue. Donec hendrerit nibh ac dolor lobortis, eu varius odio sollicitudin. Proin non condimentum
                           nulla, quis dictum leo. Vestibulum lobortis urna eu mauris viverra porttitor. Cras consequat leo condimentum lacus viverra sollicitudin. Donec dignissim ornare est, nec
                           scelerisque purus mollis eu. Phasellus dictum suscipit ligula. Donec malesuada gravida velit. Nulla egestas diam in ligula mollis, nec tincidunt diam porta. Proin eleifend
                           lacinia diam quis pretium. Sed lacinia varius nisi et euismod. Ut ac arcu vulputate, porta nibh non, ultricies erat. Nulla facilisi.
                        </p>
                    </div>
                </div>
                <div class="text-center">
                    <ul class="pager">
                        <li class="previous disabled"><a href="">&larr; Previous</a></li>
                        <li class="next"><a href="">Next &rarr;</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Blog Details -->
<uc1:Download runat="server" id="Download" />