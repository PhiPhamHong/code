<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Web.Controls.Footer" %>

<div class="modal right fade" id="work-modal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header text-center">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h2> LỜI NHẮN </h2>
                <h6 style="color:white">Để lại lời nhắn, chúng tôi sẽ liên lạc lại với bạn</h6>
            </div>
            <form id="contactFormHide" novalidate>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Tên của bạn *</label>
                        <input type="text" id="name" class="form-control" name="Name" placeholder="Nhập tên của bạn" required="required">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Hòm thư số </label>
                        <input type="email" id="email" class="form-control" name="Email" placeholder="Nhập địa chỉ email">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Số điện thoại *</label>
                        <input type="tel" id="phone" class="form-control" name="Phone" placeholder="Nhập số điện thoại" required="required">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Công ty</label>
                        <input type="text" id="company" class="form-control" name="CompanyName" placeholder="Nhập tên công ty">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Lời nhắn *</label>
                        <textarea id="message" class="form-control" name="Message" rows="4" placeholder="Nhập lời nhắn của bạn" required></textarea>
                        <p class="help-block text-danger"></p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="fromHide" class="btn btn-custom btn-lg btn-block"> Gửi tin </button>
                </div>
            </form>
        </div>
    </div>
</div>
