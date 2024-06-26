﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Clother_News.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Clother.Pages.Shop_Clother_News" %>
<%@ Register Src="~/Projects/Shops/Shop_Clother/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>

<div class="osahan-breadcrumb">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="<%= Url("Shop_Clother") %>"><i class="icofont icofont-ui-home"></i>Trang chủ</a></li>
                    <li class="breadcrumb-item active">Tin tức </li>
                </ol>
            </div>
        </div>
    </div>
</div>
<section class="blog_page">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <div class="widget blog-sidebar mb18">
                    <div class="sidebar-widget">
                        <div class="widget-search">
                            <div class="input-group">
                                <input type="text" class="form-control border-form-control" placeholder="Search Blog">
                                <span class="input-group-btn">
                                    <button class="btn btn-theme-round" type="button"><i class="icofont icofont-search-alt-2"></i></button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="sidebar-widget">
                        <h5>Categories</h5>
                        <ul class="widget-tag">
                            <li><a><i class="icofont icofont-square-right"></i>Photography</a></li>
                            <li><a><i class="icofont icofont-square-right"></i>Web Design <span class="badge badge-primary">74</span></a></li>
                            <li><a><i class="icofont icofont-square-right"></i>Lifestyle</a></li>
                            <li><a><i class="icofont icofont-square-right"></i>Responsive <span class="badge badge-success">332</span></a></li>
                            <li><a><i class="icofont icofont-square-right"></i>MultiPurpose Theme</a></li>
                            <li><a><i class="icofont icofont-square-right"></i>Agency</a></li>
                            <li><a><i class="icofont icofont-square-right"></i>Portfolio</a></li>
                        </ul>
                    </div>
                    <div class="sidebar-widget">
                        <h5>Top Posts</h5>
                        <ul class="widget-post">
                            <li>
                                <a href="<%= Url("Shop_Clother_NewDetail") %>" class="widget-post-media">
                                    <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/blog-01.jpg">
                                </a>
                                <div class="widget-post-info">
                                    <h6><a href="<%= Url("Shop_Clother_NewDetail") %>">Veritatis et quasi</a></h6>
                                    <span class="entry-meta"><i class="icofont icofont-ui-user"></i>by Olivia Reyes &nbsp; <i class="icofont icofont-calendar"></i>June 16, 2018</span>
                                </div>
                            </li>
                            <li>
                                <a href="<%= Url("Shop_Clother_NewDetail") %>" class="widget-post-media">
                                    <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/blog-02.jpg">
                                </a>
                                <div class="widget-post-info">
                                    <h6><a href="<%= Url("Shop_Clother_NewDetail") %>">Sed fringilla mauris</a></h6>
                                    <span class="entry-meta"><i class="icofont icofont-ui-user"></i>by Jon Beyes &nbsp; <i class="icofont icofont-calendar"></i>March 10, 2018</span>
                                </div>
                            </li>
                            <li>
                                <a href="<%= Url("Shop_Clother_NewDetail") %>" class="widget-post-media">
                                    <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/blog-03.jpg">
                                </a>
                                <div class="widget-post-info">
                                    <h6><a href="<%= Url("Shop_Clother_NewDetail") %>">Harum quidem rerum</a></h6>
                                    <span class="entry-meta"><i class="icofont icofont-ui-user"></i>by Osahan Singh &nbsp; <i class="icofont icofont-calendar"></i>June 27, 2018</span>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="sidebar-widget">
                        <h5>popular Tags</h5>
                        <ul class="widget-tag-btn">
                            <li><a href=""><i class="icofont icofont-square-right"></i>Art</a></li>
                            <li><a href=""><i class="icofont icofont-square-right"></i>Business</a></li>
                            <li><a href=""><i class="icofont icofont-square-right"></i>Design <span class="badge badge-success">55</span></a></li>
                            <li><a href=""><i class="icofont icofont-square-right"></i>Graphic</a></li>
                            <li><a href=""><i class="icofont icofont-square-right"></i>fashion</a></li>
                            <li><a href=""><i class="icofont icofont-square-right"></i>Model</a></li>
                            <li><a href=""><i class="icofont icofont-square-right"></i>Photography <span class="badge badge-info">32</span></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-md-9">
                <div class="row">
                    <div class="col-md-4">
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a3.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">Mike Smith</span> </small>
                                        <br>
                                        <small class="text-muted">21.03.2018, 06:45 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-image">
                                <img class="img-responsive" src="/Projects/Shops/Shop_Clother/Resources/images/blog/blog-01.jpg" alt="">
                                <div class="title">
                                    <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                        <h4>Article about new design</h4>
                                    </a>
                                    <small>Even slightly believable</small>
                                </div>
                            </div>
                            <div class="panel-body">
                                <p>
                                    There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in
                                 some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum...
                                </p>
                                <p>
                                    Praesent eget euismod nibh. Fusce ac tellus eu nisl lobortis maximus ac eget sapien. Nulla malesuada mauris non nulla imperdiet ullamcorper.
                                </p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>22 comments
                                </span>
                                <i class="fa fa-eye"></i>142 views
                            </div>
                        </div>
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a5.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">John Wilkins</span> </small>
                                        <br>
                                        <small class="text-muted">17.05.2018, 10:25 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                    <h4>Cras eleifend</h4>
                                </a>
                                <p>
                                    Donec malesuada diam sit amet arcu suscipit, nec lacinia nulla aliquet. Nullam non pellentesque ligula. Integer semper nulla ut nulla tristique, nec rhoncus sem mollis.
                                </p>
                                <p>
                                    Praesent eget euismod nibh. Fusce ac tellus eu nisl lobortis maximus ac eget sapien. Nulla malesuada mauris non nulla imperdiet ullamcorper.
                                </p>
                                <p><a href="<%= Url("Shop_Clother_NewDetail") %>" class="btn btn-primary btn-xs">Read more</a></p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>8 comments
                                </span>
                                <i class="fa fa-eye"></i>22 views
                            </div>
                        </div>
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a6.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">John Wilkins</span> </small>
                                        <br>
                                        <small class="text-muted">22.12.2018, 04:17 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                    <h4>Vivamus eu rutrum metus</h4>
                                </a>
                                <p>
                                    Duis ut iaculis ipsum, et viverra risus. Sed et risus fermentum, tempor ante vitae, faucibus libero. Curabitur ut cursus diam, at accumsan nibh.
                                 Cras feugiat iaculis massa vitae facilisis. Phasellus vestibulum nulla sed leo facilisis, sit amet sollicitudin leo porta.
                                </p>
                                <p>
                                    Aenean aliquet, nibh vitae auctor commodo, justo odio rutrum lorem, a suscipit massa justo at purus. Suspendisse ullamcorper eros est, in finibus justo dignissim nec.
                                </p>
                                <p><a href="<%= Url("Shop_Clother_NewDetail") %>" class="btn btn-primary btn-xs">Read more</a></p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>59 comments
                                </span>
                                <i class="fa fa-eye"></i>167 views
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a1.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">Mark Word</span> </small>
                                        <br>
                                        <small class="text-muted">22.04.2018, 10:15 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                    <h4>Many desktop publishing packages</h4>
                                </a>
                                <p>
                                    Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                                </p>
                                <p>
                                    Aenean aliquet, nibh vitae auctor commodo, justo odio rutrum lorem, a suscipit massa justo at purus. Suspendisse ullamcorper eros est, in finibus justo dignissim nec.
                                </p>
                                <p><a href="<%= Url("Shop_Clother_NewDetail") %>" class="btn btn-primary btn-xs">Read more</a></p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>56 comments
                                </span>
                                <i class="fa fa-eye"></i>144 views
                            </div>
                        </div>
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a7.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">Selena Jackson</span> </small>
                                        <br>
                                        <small class="text-muted">01.02.2018, 10:40 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                    <h4>Cras eleifend quam ipsum</h4>
                                </a>
                                <p>
                                    Donec nec nunc tempor, pulvinar lacus id, molestie nulla. Nam accumsan accumsan ex, non porta orci cursus ac. Pellentesque et pharetra libero.
                                </p>
                                <p>
                                    Nam sollicitudin ornare tincidunt. Nulla sit amet urna vitae lectus scelerisque sodales. Sed semper condimentum egestas.
                                </p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>32 comments
                                </span>
                                <i class="fa fa-eye"></i>98 views
                            </div>
                        </div>
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a4.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">Anna Smith</span> </small>
                                        <br>
                                        <small class="text-muted">10.07.2018, 02:12 am</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-image">
                                <img class="img-responsive" src="/Projects/Shops/Shop_Clother/Resources/images/blog/blog-01.jpg" alt="">
                                <div class="title">
                                    <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                        <h4>Standard chunk of Lorem Ipsum</h4>
                                    </a>
                                    <small>Even slightly believable</small>
                                </div>
                            </div>
                            <div class="panel-body">
                                <p>
                                    Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.
                                </p>
                                <p>
                                    Nam sollicitudin ornare tincidunt. Nulla sit amet urna vitae lectus scelerisque sodales. Sed semper condimentum egestas.
                                </p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>10 comments
                                </span>
                                <i class="fa fa-eye"></i>62 views
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a2.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">John Jackson</span> </small>
                                        <br>
                                        <small class="text-muted">11.10.2018, 11:46 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                    <h4>Latin professor at Hampden-Sydney College</h4>
                                </a>
                                <p>
                                    Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections
                                </p>
                                <p>
                                    Duis diam ipsum, ullamcorper in imperdiet eu, venenatis ac felis. Phasellus interdum tellus sed leo fringilla, id ornare nulla mollis.
                                </p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>66 comments
                                </span>
                                <i class="fa fa-eye"></i>250 views
                            </div>
                        </div>
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a8.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">Selena Jackson</span> </small>
                                        <br>
                                        <small class="text-muted">16.02.2018, 08:34 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-image">
                                <img class="img-responsive" src="/Projects/Shops/Shop_Clother/Resources/images/blog/blog-02.jpg" alt="">
                                <div class="title">
                                    <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                        <h4>Sed laoreet pulvinar mauris</h4>
                                    </a>
                                    <small>Even slightly believable</small>
                                </div>
                            </div>
                            <div class="panel-body">
                                <p>
                                    Aliquam varius, odio nec facilisis convallis, nulla augue efficitur enim, eu iaculis urna nisi id erat. Sed iaculis orci id diam porttitor, nec sagittis dui sodales. Quisque in libero erat. Etiam luctus
                                </p>
                                <p>
                                    Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Fusce ullamcorper nisl risus, a scelerisque dui hendrerit nec.
                                </p>
                                <p><a href="<%= Url("Shop_Clother_NewDetail") %>" class="btn btn-primary btn-xs">Read more</a></p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>10 comments
                                </span>
                                <i class="fa fa-eye"></i>183 views
                            </div>
                        </div>
                        <div class="panel blog-box">
                            <div class="panel-heading">
                                <div class="media clearfix">
                                    <a class="pull-left">
                                        <img src="/Projects/Shops/Shop_Clother/Resources/images/blog/user/a5.jpg" alt="profile-picture">
                                    </a>
                                    <div class="media-body">
                                        <small>Created by: <span class="font-bold">John Wilkins</span> </small>
                                        <br>
                                        <small class="text-muted">17.05.2018, 10:25 pm</small>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <a href="<%= Url("Shop_Clother_NewDetail") %>">
                                    <h4>Cras eleifend</h4>
                                </a>
                                <p>
                                    Donec malesuada diam sit amet arcu suscipit, nec lacinia nulla aliquet. Nullam non pellentesque ligula. Integer semper nulla ut nulla tristique, nec rhoncus sem mollis.
                                </p>
                                <p>
                                    Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Fusce ullamcorper nisl risus, a scelerisque dui hendrerit nec.
                                </p>
                            </div>
                            <div class="panel-footer">
                                <span class="pull-right">
                                    <i class="fa fa-comments-o"></i>8 comments
                                </span>
                                <i class="fa fa-eye"></i>22 views
                            </div>
                        </div>
                    </div>
                </div>
                <nav aria-label="Page navigation example">
                    <ul class="pagination justify-content-center">
                        <li class="page-item disabled"><a class="page-link" href=""><i class="fa fa-angle-left" aria-hidden="true"></i></a></li>
                        <li class="page-item active"><a class="page-link" href="">1</a></li>
                        <li class="page-item"><a class="page-link" href="">2</a></li>
                        <li class="page-item"><a class="page-link" href="">3</a></li>
                        <li class="page-item"><a class="page-link" href="">4</a></li>
                        <li class="page-item"><a class="page-link" href=""><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>
</section>
<uc1:Top_Brands runat="server" ID="Top_Brands" />
