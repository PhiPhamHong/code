<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Orderstatus.ascx.cs" Inherits="Core.FE.MobileShop.Projects.Web.Pages.Shop_Mobile_Orderstatus" %>
<%@ Register Src="~/Projects/Web/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>



<div class="osahan-breadcrumb">
         <div class="container">
            <div class="row">
               <div class="col-lg-12 col-md-12">
                  <ol class="breadcrumb">
                     <li class="breadcrumb-item"><a href=""><i class="icofont icofont-ui-home"></i> Home</a></li>
                     <li class="breadcrumb-item"><a href="">Pages</a></li>
                     <li class="breadcrumb-item active">Page Name</li>
                  </ol>
               </div>
            </div>
         </div>
      </div>
      <section class="shopping_cart_page">
         <h6 class="sr-only">validator.w3</h6>
         <div class="container">
            <div class="row">
               <div class="col-lg-4 col-md-4 col-sm-5">
                  <div class="user-account-sidebar">
                     <aside class="user-info-wrapper">
                        <div class="user-cover" style="background-image: url(/Projects/Web/Resources/images/user-cover-img.jpg);">
                           <div class="info-label" data-toggle="tooltip" title="" data-original-title="Verified Account"><i class="icofont icofont-check-circled"></i></div>
                        </div>
                        <div class="user-info">
                           <div class="user-avatar"><a class="edit-avatar" href=""><i class="icofont icofont-edit"></i></a><img src="/Projects/Web/Resources/images/user-ava.jpg" alt="User"></div>
                           <div class="user-data">
                              <h4>Osahan Singh</h4>
                              <span><i class="icofont icofont-ui-calendar"></i> Joined February 06, 2017</span>
                           </div>
                        </div>
                     </aside>
                     <nav class="list-group">
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Profile") %>"><i class="icofont icofont-ui-user fa-fw"></i>My Profile</a>
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Address") %>"><i class="icofont icofont-location-pin fa-fw"></i>My Address</a>
                        <a class="list-group-item justify-content-between" href="<%= Url("Shop_Mobile_Wishlist_user") %>"><span><i class="icofont icofont-heart-alt fa-fw"></i>Wish List</span> <span class="badge badge-danger">35 Items</span></a>
                        <a class="list-group-item justify-content-between" href="<%= Url("Shop_Mobile_Orderlist") %>"><span><i class="icofont icofont-list fa-fw"></i>Order List</span> <span class="badge badge-warning">6 Items</span></a>
                        <a class="list-group-item active justify-content-between" href="<%= Url("Shop_Mobile_Orderstatus") %>"><span><i class="icofont icofont-truck-loaded fa-fw"></i>Order Status</span> <span class="badge badge-success">4</span></a>
                        <a class="list-group-item" href="<%= Url("Shop_Mobile_Login") %>"><i class="icofont icofont-logout fa-fw"></i>Logout</a>
                    </nav>
                  </div>
				  <div class="left-ad mt-4">
					  <img class="rounded img-fluid" src="http://via.placeholder.com/350x563" alt="">
				  </div>
               </div>
               <div class="col-lg-8 col-md-8 col-sm-7">
                  <div class="widget">
                     <div class="section-header">
                        <h5 class="heading-design-h5">
                           Order Status
                        </h5>
                     </div>
                     <div class="status-main">
                        <div class="row">
                           <div class="col-lg-12 col-md-12">
                              <h4 class="block-title-border"> Your Order Status </h4>
                           </div>
                           <div class="col-lg-12 col-md-12">
                              <div class="statustop">
                                 <p><strong>Status:</strong> OnHold</p>
                                 <p><strong>Order Date:</strong> Saturday, April 09,2015</p>
                                 <p><strong>Order Number:</strong> #6469 </p>
                                 <br>	
                              </div>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-lg-6 col-md-6">
                              <div class="card">
                                 <div class="card-header">
                                    Billing Address 
                                 </div>
                                 <div class="card-body">
                                    <p class="card-text"><strong>TITLE</strong></p>
                                    <p class="card-text"><strong>Gurdeep Singh Osahan</strong></p>
                                    <p class="card-text"> 4894 Burke Street<br>
                                       North Billerica, MA 01862 
                                    </p>
                                 </div>
                              </div>
                           </div>
                           <div class="col-lg-6 col-md-6">
                              <div class="card">
                                 <div class="card-header">
                                    Shipping Address  
                                 </div>
                                 <div class="card-body">
                                    <p class="card-text"><strong>TITLE</strong></p>
                                    <p class="card-text"><strong>Gurdeep Singh Osahan</strong></p>
                                    <p class="card-text"> 4894 Burke Street<br>
                                       North Billerica, MA 01862 
                                    </p>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-lg-6 col-md-6">
                              <div class="card">
                                 <div class="card-header">
                                    Payment Method  
                                 </div>
                                 <div class="card-body">
                                    <p class="card-text">Payment via Master Card  <strong><span class="badge badge-success">Paid</span></strong></p>
                                    <p class="card-text"><strong>Name Of card </strong>: Gurdeep Osahan</p>
                                    <p class="card-text"><strong>Card Number </strong>:  00335 251 124</p>
                                 </div>
                              </div>
                           </div>
                           <div class="col-lg-6 col-md-6">
                              <div class="card">
                                 <div class="card-header">
                                    Shipping Method   
                                 </div>
                                 <div class="card-body">
                                    <p class="card-text"> via Post Air Mail #4502</p>
                                    <p class="card-text"><strong>Gurdeep Singh Osahan</strong></p>
                                    <p class="card-text"> 4894 Burke Street North Billerica</p>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-lg-12 col-md-12">
                              <div class="card">
                                 <div class="card-header">
                                    Order Items  
                                 </div>
                                 <div class="card-block padding-none">
                                    <table class="table cart_summary table-responsive">
                                       <thead>
                                          <tr>
                                             <th class="cart_product">Product</th>
                                             <th>Description</th>
                                             <th>Avail.</th>
                                             <th>Unit price</th>
                                             <th>Total</th>
                                          </tr>
                                       </thead>
                                       <tbody>
                                          <tr>
                                             <td class="cart_product"><a href=""><img class="img-fluid" src="/Projects/Web/Resources/images/all-products/small/3.jpg" alt="Product"></a></td>
                                             <td class="cart_description">
                                                <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                                <small><a href="">Color : Red</a></small>
                                                <small><a href="">Size : M</a></small>
                                             </td>
                                             <td class="availability in-stock"><span class="badge badge-success">In stock</span></td>
                                             <td class="price"><span>$49.88</span></td>
                                             <td class="price"><span>$49.88</span></td>
                                          </tr>
                                          <tr>
                                             <td class="cart_product"><a href=""><img class="img-fluid" src="/Projects/Web/Resources/images/all-products/small/2.jpg" alt="Product"></a></td>
                                             <td class="cart_description">
                                                <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                                <small><a href="">Color : Green</a></small><br>
                                                <small><a href="">Size : XL</a></small>
                                             </td>
                                             <td class="availability out-of-stock"><span class="badge badge-primary">No stock</span></td>
                                             <td class="price"><span>$00.00</span></td>
                                             <td class="price"><span>00.00</span></td>
                                          </tr>
                                          <tr>
                                             <td class="cart_product"><a href=""><img class="img-fluid" src="/Projects/Web/Resources/images/all-products/small/1.jpg" alt="Product"></a></td>
                                             <td class="cart_description">
                                                <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                                <small><a href="">Color : Blue</a></small><br>
                                                <small><a href="">Size : S</a></small>
                                             </td>
                                             <td class="availability in-stock"><span class="badge badge-warning">In stock</span></td>
                                             <td class="price"><span>$99.00</span></td>
                                             <td class="price"><span>$188.00</span></td>
                                          </tr>
                                       </tbody>
                                       <tfoot>
                                          <tr>
                                             <td colspan="4">Total products (tax incl.)</td>
                                             <td colspan="1">$437.88 </td>
                                          </tr>
                                          <tr>
                                             <td colspan="4"><strong>Total</strong></td>
                                             <td colspan="1"><strong>$337.88 </strong></td>
                                          </tr>
                                       </tfoot>
                                    </table>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </section>
<uc1:Top_Brands runat="server" id="Top_Brands" />
