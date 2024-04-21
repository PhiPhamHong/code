<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Design.Controls.Footer" %>
<div class="modal right fade" id="work-modal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header text-center">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h2> MESSAGE </h2>
                <h6 style="color:white">Leave a message, we will get back to you</h6>
            </div>
            <form id="contactFormHide" novalidate>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Your name *</label>
                        <input type="text" id="name" class="form-control" placeholder="Your name" required="required">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Email </label>
                        <input type="email" id="email" class="form-control" placeholder="Your email address">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Phone number *</label>
                        <input type="tel" id="phone" class="form-control" placeholder="Your phone number" required="required">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Company</label>
                        <input type="text" id="company" class="form-control" placeholder="Your company name">
                        <p class="help-block text-danger"></p>
                    </div>
                    <div class="form-group">
                        <label>Message *</label>
                        <textarea name="message" id="message" class="form-control" rows="4" placeholder="Write your message" required></textarea>
                        <p class="help-block text-danger"></p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-custom btn-lg btn-block"> Send message </button>
                </div>
            </form>
        </div>
    </div>
</div>
