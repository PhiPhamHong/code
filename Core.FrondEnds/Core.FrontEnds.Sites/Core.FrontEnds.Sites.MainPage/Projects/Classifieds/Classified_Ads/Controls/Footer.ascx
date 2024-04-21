<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_Ads.Controls.Footer" %>
<footer>
    <section class="footer-Content">
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="footer-widget">
                        <h3 class="block-title">About</h3>
                        <div class="textwidget">
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque lobortis tincidunt est, et euismod purus suscipit quis. Etiam euismod ornare elementum. Sed ex est,  Sed ex est, consectetur eget consectetur, Lorem ipsum dolor sit amet...</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="footer-widget">
                        <h3 class="block-title">Categories</h3>
                        <ul class="menu">
                            <li><a href=""><span>562</span> Restaurant</a></li>
                            <li><a href=""><span>451</span> Real Estate</a></li>
                            <li><a href=""><span>352</span> Cars</a></li>
                            <li><a href=""><span>312</span> Shopping</a></li>
                            <li><a href=""><span>262</span> Job</a></li>
                            <li><a href=""><span>152</span> Hotels</a></li>
                            <li><a href=""><span>102</span> Services</a></li>
                            <li><a href=""><span>100</span> Pets</a></li>
                            <li><a href=""><span>95</span> Cars</a></li>
                            <li><a href=""><span>85</span> Shopping</a></li>
                            <li><a href=""><span>50</span> Job</a></li>
                            <li><a href=""><span>25</span> Hotels</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="footer-widget">
                        <h3 class="block-title">Latest Post</h3>
                        <ul class="blog-footer">
                            <li>
                                <a href="">Lorem ipsum dolor sit amet, quem...</a>
                                <span class="post-date"><i class="fa fa-calendar" aria-hidden="true"></i>March 12, 2017</span>
                            </li>
                            <li>
                                <a href="">Full Width Media Post Lorem ipsum..</a>
                                <span class="post-date"><i class="fa fa-calendar" aria-hidden="true"></i>September 25, 2017</span>
                            </li>
                            <li>
                                <a href="">Perfect Video Post Lorem ipsum..</a>
                                <span class="post-date"><i class="fa fa-calendar" aria-hidden="true"></i>November 19, 2017</span>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="footer-widget">
                        <h3 class="block-title">Quick Links</h3>
                        <ul class="menu">
                            <li><a href="">Home</a></li>
                            <li><a href="">About</a></li>
                            <li><a href="">FAQ</a></li>
                            <li><a href="">Careers</a></li>
                            <li><a href="">Pricing Plans</a></li>
                            <li><a href="">Categories</a></li>
                            <li><a href="">Services</a></li>
                            <li><a href="">Team</a></li>
                            <li><a href="">Contact</a></li>
                            <li><a href="">Blog</a></li>
                            <li><a href="">Help</a></li>
                            <li><a href="">Advertise With Us</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="copyright">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="bottom-social-icons social-icon text-center">
                        <a href="" target="_blank" class="facebook"><i class="fa fa-facebook"></i></a>
                        <a href="" target="_blank" class="twitter"><i class="fa fa-twitter"></i></a>
                        <a href="" target="_blank" class="dribble"><i class="fa fa-dribbble"></i></a>
                        <a href="" target="_blank" class="youtube"><i class="fa fa-youtube"></i></a>
                        <a href="" target="_blank" class="google-plus"><i class="fa fa-google-plus"></i></a>
                        <a href="" target="_blank" class="linkedin"><i class="fa fa-linkedin"></i></a>
                    </div>
                    <div class="site-info text-center">
                        <p>&copy; Copyright 2017 Osahan - Ads . All Rights Reserved<br>
                            Made with <i class="fa fa-heart"></i>by <a target="_blank" href="https://www.facebook.com/PGT.Zeus"><strong>APhi Bụng Bự</strong></a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</footer>
<!-- End Footer -->

<!-- Post Ad -->
<a href="<%= Url("Classified_Ads_Post") %>" data-toggle="tooltip" data-placement="left" title="Post Your Ad" class="btn btn-primary btn-lg post-free-add-btn"><i class="fa fa-pencil"></i></a>
<!-- End Post Ad -->

<!-- Back To Top -->
<a href="" id="back-to-top" data-toggle="tooltip" data-placement="left" title="Back To Top" class="btn btn-default btn-md"><i class="fa fa-chevron-up"></i></a>
<!-- End Back To Top -->

<!-- Chat Popup -->
<div id="accordion">
    <div class="popup-box chat-popup">
        <div class="popup-head">
            <div class="popup-head-left pull-left">
                <a data-toggle="collapse" data-parent="#accordion" href="#popup">
                    <img src="/Projects/Classifieds/Classified_Ads/Resources/images/user.jpg" alt="">
                    John Doe
					<small>Online</small>
                </a>
            </div>
            <div class="popup-head-right pull-right">
                <div class="btn-group">
                    <button class="chat-header-button" data-toggle="dropdown" type="button" aria-expanded="false">
                        <i class="fa fa-cog"></i>
                    </button>
                    <ul role="menu" class="dropdown-menu pull-right">
                        <li><a href="">Media</a></li>
                        <li><a href="">Block</a></li>
                        <li><a href="">Clear Chat</a></li>
                        <li><a href="">Email Chat</a></li>
                    </ul>
                </div>
                <button data-toggle="collapse" data-parent="#accordion" href="#popup" class="chat-header-button pull-right" type="button"><i class="fa fa-power-off"></i></button>
            </div>
        </div>
        <div id="popup" class="collapse">
            <div class="popup-messages">
                <div class="direct-chat-messages">
                    <div class="chat-box-single-line">
                        <abbr class="timestamp">October 8th, 2015</abbr>
                    </div>
                    <!-- Message. Default to the left -->
                    <div class="direct-chat-msg doted-border">
                        <div class="direct-chat-info clearfix">
                            <span class="direct-chat-name pull-left">Osahan</span>
                        </div>
                        <!-- /.direct-chat-info -->
                        <img alt="message user image" src="/Projects/Classifieds/Classified_Ads/Resources/images/user.jpg" class="direct-chat-img"><!-- /.direct-chat-img -->
                        <div class="direct-chat-text">
                            Hey bro, how’s everything going ?
                        </div>
                        <div class="direct-chat-info clearfix">
                            <span class="direct-chat-timestamp pull-right">3.36 PM</span>
                        </div>
                        <div class="direct-chat-info clearfix">
                            <span class="direct-chat-img-reply-small pull-left"></span>
                            <span class="direct-chat-reply-name">Singh</span>
                        </div>
                        <!-- /.direct-chat-text -->
                    </div>
                    <!-- /.direct-chat-msg -->
                    <div class="chat-box-single-line">
                        <abbr class="timestamp">October 9th, 2015</abbr>
                    </div>
                    <!-- Message. Default to the left -->
                    <div class="direct-chat-msg doted-border">
                        <div class="direct-chat-info clearfix">
                            <span class="direct-chat-name pull-left">Osahan</span>
                        </div>
                        <!-- /.direct-chat-info -->
                        <img alt="" src="/Projects/Classifieds/Classified_Ads/Resources/images/user.jpg" class="direct-chat-img"><!-- /.direct-chat-img -->
                        <div class="direct-chat-text">
                            Hey bro, how’s everything going ?
                        </div>
                        <div class="direct-chat-info clearfix">
                            <span class="direct-chat-timestamp pull-right">3.36 PM</span>
                        </div>
                        <div class="direct-chat-info clearfix">
                            <img alt="" src="/Projects/Classifieds/Classified_Ads/Resources/images/blog/user/a3.jpg" class="direct-chat-img big-round">
                            <span class="direct-chat-reply-name">Singh</span>
                        </div>
                        <!-- /.direct-chat-text -->
                    </div>
                    <!-- /.direct-chat-msg -->
                </div>
            </div>
            <div class="popup-messages-footer">
                <textarea id="status_message" placeholder="Type a message..." rows="10" cols="40" name="message"></textarea>
                <div class="btn-footer">
                    <button class="bg_none"><i class="fa fa-film"></i></button>
                    <button class="bg_none"><i class="fa fa-camera"></i></button>
                    <button class="bg_none"><i class="fa fa-paperclip"></i></button>
                    <button class="bg_none pull-right"><i class="fa fa-paper-plane"></i></button>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End Chat Popup -->
