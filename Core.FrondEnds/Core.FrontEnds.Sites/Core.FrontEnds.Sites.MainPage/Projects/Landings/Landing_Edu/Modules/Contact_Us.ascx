<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact_Us.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Landings.Landing_Edu.Modules.Contact_Us" %>

<section id="contact">
    <div class="container">
        <h2 class="text-center">Contact Us</h2>
        <div class="section-title text-center">
            <span class="badge badge-info">No Spam Please</span>
            <h3>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</h3>
        </div>
        <div class="row">
            <div class="col-md-8 mx-auto">
                <form name="sentMessage" id="contactForm" novalidate="">
                    <div class="control-group form-group">
                        <div class="controls">
                            <input placeholder="Full Name" class="form-control" id="name" required="" data-validation-required-message="Please enter your name." type="text">
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-group form-group col-md-6">
                            <div class="controls">
                                <input placeholder="Phone Number" class="form-control" id="phone" required="" data-validation-required-message="Please enter your phone number." type="tel">
                                <div class="help-block"></div>
                            </div>
                        </div>
                        <div class="control-group form-group col-md-6">
                            <div class="controls">
                                <input placeholder="Email Address" class="form-control" id="email" required="" data-validation-required-message="Please enter your email address." type="email">
                                <div class="help-block"></div>
                            </div>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <textarea rows="4" cols="100" placeholder="Message" class="form-control" id="message" required="" data-validation-required-message="Please enter your message" maxlength="999" style="resize: none"></textarea>
                            <div class="help-block"></div>
                        </div>
                    </div>
                    <div id="success"></div>

                    <button type="submit" class="btn btn-success btn-lg btn-block">SUBMIT NOW</button>
                </form>
                <p class="mt-3 text-center mb-0">Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
            </div>
        </div>
    </div>
</section>

<section>
    <div class="land-full land-4-loca-full">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2>Location</h2>
                    <p><i class="fas fa-map-marker-alt"></i><strong>Address:</strong> 141001 Diana, Patheon, Shen</p>
                    <p><i class="fas fa-mobile-alt"></i><strong>Phone:</strong> +01 2345 6788</p>
                    <p><i class="fas fa-envelope"></i><strong>Email:</strong> <a href="cskh@gmail.com"></a></p>
                </div>
                <div class="col-md-6">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3501889.0795673826!2d73.15687918966267!3d31.00357561172526!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391964aa569e7355%3A0x8fbd263103a38861!2sPunjab!5e0!3m2!1sen!2sin!4v1503422781241" allowfullscreen="" height="100%" width="100%"></iframe>
                </div>
            </div>
        </div>
    </div>
</section>
