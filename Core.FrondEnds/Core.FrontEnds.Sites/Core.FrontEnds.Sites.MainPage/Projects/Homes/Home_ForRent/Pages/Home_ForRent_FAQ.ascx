<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_ForRent_FAQ.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Homes.Home_ForRent.Pages.Home_ForRent_FAQ" %>
<%@ Register Src="~/Projects/Homes/Home_ForRent/Modules/JoinTeam.ascx" TagPrefix="uc1" TagName="JoinTeam" %>

<section class="section-padding bg-dark inner-header">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <h1 class="mt-0 mb-3">FAQ</h1>
                <div class="breadcrumbs">
                    <p class="mb-0"><a href="<%= Url("Home_ForRent") %>"><i class="mdi mdi-home-outline"></i>Home</a> / FAQ</p>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End Inner Header -->
<!-- FAQ -->
<section class="section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-7 col-md-7">
                <div class="card padding-card">
                    <div class="card-body">
                        <div id="accordion" role="tablist" aria-multiselectable="true">
                            <div class="faq-card mb-4">
                                <div class="faq-card-header mb-2" role="tab" id="headingThreed">
                                    <h5 class="mb-0">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                            <i class="mdi mdi-arrow-right-bold-box"></i>I get access to case studies? 
                                        </a>
                                    </h5>
                                </div>
                                <div id="collapseThree" class="collapse" role="tabpanel" aria-labelledby="headingThreed">
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </p>
                                </div>
                            </div>
                            <div class="faq-card mb-4">
                                <div class="faq-card-header mb-2" role="tab" id="headingOne">
                                    <h5 class="mb-0">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                            <i class="mdi mdi-arrow-right-bold-box"></i>Where can I get access to Capital IQ? 
                                        </a>
                                    </h5>
                                </div>
                                <div id="collapseOne" class="collapse show" role="tabpanel" aria-labelledby="headingOne">
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.<br>
                                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </p>
                                </div>
                            </div>
                            <div class="faq-card mb-4">
                                <div class="faq-card-header mb-2" role="tab" id="headingTwo">
                                    <h5 class="mb-0">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                            <i class="mdi mdi-arrow-right-bold-box"></i>Where can I find market research reports? 
                                        </a>
                                    </h5>
                                </div>
                                <div id="collapseTwo" class="collapse" role="tabpanel" aria-labelledby="headingTwo">
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </p>
                                </div>
                            </div>
                            <div class="faq-card mb-4">
                                <div class="faq-card-header mb-2" role="tab" id="headingThree">
                                    <h5 class="mb-0">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                            <i class="mdi mdi-arrow-right-bold-box"></i>How do I get access to case studies? 
                                        </a>
                                    </h5>
                                </div>
                                <div id="collapseThree" class="collapse" role="tabpanel" aria-labelledby="headingThree">
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </p>
                                </div>
                            </div>
                            <div class="faq-card">
                                <div class="faq-card-header mb-2" role="tab" id="headingThree">
                                    <h5 class="mb-0">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                            <i class="mdi mdi-arrow-right-bold-box"></i>How much should I capitalize?  
                                        </a>
                                    </h5>
                                </div>
                                <div id="collapseThree" class="collapse" role="tabpanel" aria-labelledby="headingThree">
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-5 col-md-5">
                <div class="card padding-card">
                    <div class="card-body">
                        <h5 class="card-title mb-4">Ask us question</h5>
                        <form name="sentMessage">
                            <div class="row">
                                <div class="control-group form-group col-lg-6 col-md-6">
                                    <div class="controls">
                                        <label>Your Name <span class="text-danger">*</span></label>
                                        <input class="form-control" required="" type="text">
                                    </div>
                                </div>
                                <div class="control-group form-group col-lg-6 col-md-6">
                                    <div class="controls">
                                        <label>Your Email <span class="text-danger">*</span></label>
                                        <input class="form-control" required="" type="email">
                                    </div>
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <label>Your Message <span class="text-danger">*</span></label>
                                    <textarea rows="5" cols="100" class="form-control"></textarea>
                                </div>
                            </div>
                            <button type="submit" class="btn btn-primary btn-lg">SUBMIT</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- End FAQ -->
<!-- Join Team -->
<uc1:JoinTeam runat="server" id="JoinTeam" />
