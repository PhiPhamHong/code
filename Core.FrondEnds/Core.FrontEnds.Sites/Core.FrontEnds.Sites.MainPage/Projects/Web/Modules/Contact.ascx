<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Web.Modules.Contact" %>


<!-- Contact Section -->
<div id="contact" class="text-center">
    <div class="container">
        <div class="section-title text-center">
            <h2><b>Hãy liên hệ với chúng tôi </b></h2>
            <hr>
            <p>Chúng tôi luôn trực tuyến để giải đáp bất kì câu hỏi nào.</p>
            <p>Gửi cho chúng tôi yêu cầu của bạn, chúng tôi sẽ phản hồi nhanh nhất có thể </p>
        </div>
        <div class="col-md-10 col-md-offset-1">
            <form name="sentMessage" id="contactForm" novalidate>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="name" name="Name" class="form-control" placeholder="Tên của bạn" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="company" name="CompanyName" class="form-control" placeholder="Tên công ty">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="address" name="Address" class="form-control" placeholder="Địa chỉ" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="phone" name="Phone" class="form-control" placeholder="Số điện thoại" required="required">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <input type="email" id="email" name="Email" class="form-control" placeholder="Hòm thư số">
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <textarea name="message" id="message" name="Message" class="form-control" rows="4" placeholder="Nội dung" required></textarea>
                    <p class="help-block text-danger"></p>
                </div>
                <div id="success"></div>
                <button type="submit" id="fromContact" class="btn btn-custom btn-lg">Gửi phản hồi </button>
            </form>
        </div>
    </div>
</div>
<!-- Footer Section -->
<div id="footer">
    <div class="container text-center">
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-location-arrow" aria-hidden="true"></i>
                <p>167A/63 Lê Đức Thọ - Mỹ Đình - Hà Nội - Việt Nam </p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-phone" aria-hidden="true"></i>
                <p>0392-669-545 / +84-392-669-545</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="contact-item">
                <i class="fa fa-envelope-o" aria-hidden="true"></i>
                <p>cskh.teamdesign@gmail.com</p>
            </div>
        </div>
    </div>
</div>
<div class="footer-bottom">
    <div class="col-sm-12 text-center">
        <div class="footer-social text-center">
            <div class="social-share-new">
                <a href="" class="btn-social btn-behance"><i class="fa fa-behance"></i></a>
                <a href="" class="btn-social btn-dribbble"><i class="fa fa-dribbble"></i></a>
                <a href="" class="btn-social btn-facebook"><i class="fa fa-facebook"></i></a>
                <a href="" class="btn-social btn-google-plus"><i class="fa fa-google-plus"></i></a>
                <a href="" class="btn-social btn-instagram"><i class="fa fa-instagram"></i></a>
                <a href="" class="btn-social btn-linkedin"><i class="fa fa-linkedin"></i></a>
                <a href="" class="btn-social btn-pinterest"><i class="fa fa-pinterest"></i></a>
                <a href="" class="btn-social btn-skype"><i class="fa fa-skype"></i></a>
                <a href="" class="btn-social btn-twitter"><i class="fa fa-twitter"></i></a>
                <a href="" class="btn-social btn-youtube"><i class="fa fa-youtube"></i></a>
                <a href="" class="btn-social btn-email"><i class="fa fa-envelope-o"></i></a>
            </div>
        </div>
        <div class="text-center">
            &copy; Copyright 2017 Team Design. All Rights Reserved
              
            <div class="rfloat heartline">
                Made with<i class="fa fa-heart hearticon"></i>by
                 
                <a target="_blank" href="https://facebook.com/PGTZeus">APhi Bụng Bự </a>
            </div>
        </div>
    </div>
</div>
