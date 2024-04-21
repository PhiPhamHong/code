<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Classified_All_Post.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Classifieds.Classified_All.Pages.Profile.Classified_All_Post" %>
<section class="breadcumb_area">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 text-center">
                <div class="breadcumb_section">
                    <div class="page_title">
                        <h3>Post Your Ad</h3>
                    </div>
                    <div class="page_pagination">
                        <ul>
                            <li><a href="<%= Url("Classified_All") %>">Home</a></li>
                            <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                            <li>Post Your Ad</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Breadcumb -->

<!-- Create Post -->
<section class="create-post">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <div class="login-panel widget margin-bottom-none">
                    <div class="login-body">
                        <form>
                            <div class="form-group">
                                <label class="control-label">Ad Title <span class="required">*</span></label>
                                <input type="text" placeholder="e.g. Apple iPhone SE 2017" required="required" value="" class="form-control border-form">
                            </div>
                            <div class="form-group">
                                <label class="control-label">Category <span class="required">*</span></label>
                                <select class="form-control border-form">
                                    <option selected="">All Category</option>
                                    <option>Hand Phone</option>
                                    <option>Motorcycle</option>
                                    <option>Properti</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <label class="col-sm-3 control-label">Condition <span class="required">*</span></label>
                                    <div class="col-sm-9">
                                        <div class="radio radio-info radio-inline">
                                            <input type="radio" id="inlineRadio1" value="option1" name="radioInline" checked="">
                                            <label for="inlineRadio1">Brand New </label>
                                        </div>
                                        <div class="radio radio-info radio-inline">
                                            <input type="radio" id="inlineRadio2" value="option1" name="radioInline">
                                            <label for="inlineRadio2">Used </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Price <span class="required">*</span></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                    <input type="text" placeholder="e.g. 999" required="required" value="" class="form-control border-form">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Add Photos</label>
                                <input type="file" class="filestyle">
                                <span class="help-block"></span>
                                <input type="file" class="filestyle">
                                <span class="help-block"></span>
                                <input type="file" class="filestyle">
                                <span class="help-block"></span>
                                <input type="file" class="filestyle">
                                <span class="help-block"></span>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Location <span class="required">*</span></label>
                                <select class="form-control border-form">
                                    <option selected="">All Location</option>
                                    <option>New York</option>
                                    <option>Washington</option>
                                    <option>California</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Ad Description <span class="required">*</span></label>
                                <textarea placeholder="Include the brand, model, age and any included accessories." class="form-control border-form"></textarea>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Your Name <span class="required">*</span></label>
                                <input type="text" placeholder="e.g. Jhone Doe" required="required" value="" class="form-control border-form">
                            </div>
                            <div class="form-group">
                                <label class="control-label">Your email <span class="required">*</span></label>
                                <input type="text" placeholder="e.g. jon@gmail.com" required="required" value="" class="form-control border-form">
                            </div>
                            <div class="form-group">
                                <label class="control-label">Phone number <span class="required">*</span></label>
                                <div class="input-group">
                                    <span class="input-group-addon">+44</span>
                                    <input type="text" placeholder="e.g. 123456789" required="required" value="" class="form-control border-form">
                                </div>
                            </div>
                            <div class="form-group text-right margin-bottom-none">
                                <button type="submit" class="btn btn-success"><i class="fa fa-save"></i>Create ad</button>
                                <button type="submit" class="btn btn-danger"><i class="fa fa-close"></i>Cancel</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Create Post -->
