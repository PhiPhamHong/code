<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shop_Mobile_Viewcart.ascx.cs" Inherits="Core.FrontEnds.Sites.MainPage.Projects.Shops.Shop_Mobile.Pages.Shop_Mobile_Viewcart" %>
<%@ Register Src="~/Projects/Shops/Shop_Mobile/Modules/Top_Brands.ascx" TagPrefix="uc1" TagName="Top_Brands" %>


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
         <div class="container">
            <div class="row">
               <div class="col-lg-8 col-md-8 mx-auto">
                  <div class="widget">
                     <div class="section-header">
                        <h3 class="heading-design-h5">
                           Cart
                        </h3>
                     </div>
                     <div class="table-responsive">
                        <table class="table cart_summary">
                           <thead>
                              <tr>
                                 <th class="cart_product">Product</th>
                                 <th>Description</th>
                                 <th>Avail.</th>
                                 <th>Unit price</th>
                                 <th>Qty</th>
                                 <th>Total</th>
                                 <th class="action"><i class="fa fa-trash-o"></i></th>
                              </tr>
                           </thead>
                           <tbody>
                              <tr>
                                 <td class="cart_product"><a href=""><img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/small/3.jpg" alt="Product"></a></td>
                                 <td class="cart_description">
                                    <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                    <small><a href="">Color : Red</a></small>
                                    <small><a href="">Size : M</a></small>
                                 </td>
                                 <td class="availability in-stock"><span class="badge badge-success">In stock</span></td>
                                 <td class="price"><span>$49.88</span></td>
                                 <td class="qty">
                                    <div class="input-group">
                                       <span class="input-group-btn">
                                       <button type="button" class="btn btn-theme-round btn-number" disabled="disabled" data-type="minus" data-field="quant[1]">
                                       <span class="fa fa-minus"></span>
                                       </button>
                                       </span>
                                       <input name="quant[1]" class="form-control border-form-control form-control-sm input-number" value="1" type="text">
                                       <span class="input-group-btn">
                                       <button type="button" class="btn btn-theme-round btn-number" data-type="plus" data-field="quant[1]">
                                       <span class="fa fa-plus"></span>
                                       </button>
                                       </span>
                                    </div>
                                 </td>
                                 <td class="price"><span>$49.88</span></td>
                                 <td class="action">
                                    <a data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove"><i class="fa fa-trash-o"></i></a>
                                 </td>
                              </tr>
                              <tr>
                                 <td class="cart_product"><a href=""><img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/small/2.jpg" alt="Product"></a></td>
                                 <td class="cart_description">
                                    <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                    <small><a href="">Color : Green</a></small><br>
                                    <small><a href="">Size : XL</a></small>
                                 </td>
                                 <td class="availability out-of-stock"><span class="badge badge-primary">No stock</span></td>
                                 <td class="price"><span>$00.00</span></td>
                                 <td class="qty">
                                    <div class="input-group">
                                       <span class="input-group-btn">
                                       <button type="button" class="btn btn-theme-round btn-number" disabled="disabled" data-type="minus" data-field="quant[1]">
                                       <span class="fa fa-minus"></span>
                                       </button>
                                       </span>
                                       <input name="quant[1]" class="form-control border-form-control form-control-sm input-number" value="1" type="text">
                                       <span class="input-group-btn">
                                       <button type="button" class="btn btn-theme-round btn-number" data-type="plus" data-field="quant[1]">
                                       <span class="fa fa-plus"></span>
                                       </button>
                                       </span>
                                    </div>
                                 </td>
                                 <td class="price"><span>00.00</span></td>
                                 <td class="action">
                                    <a data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove"><i class="fa fa-trash-o"></i></a>
                                 </td>
                              </tr>
                              <tr>
                                 <td class="cart_product"><a href=""><img class="img-fluid" src="/Projects/Shops/Shop_Mobile/Resources/images/all-products/small/1.jpg" alt="Product"></a></td>
                                 <td class="cart_description">
                                    <p class="product-name"><a href="">Ipsums Dolors Untra </a></p>
                                    <small><a href="">Color : Blue</a></small><br>
                                    <small><a href="">Size : S</a></small>
                                 </td>
                                 <td class="availability in-stock"><span class="badge badge-warning">In stock</span></td>
                                 <td class="price"><span>$99.00</span></td>
                                 <td class="qty">
                                    <div class="input-group">
                                       <span class="input-group-btn">
                                       <button type="button" class="btn btn-theme-round btn-number" disabled="disabled" data-type="minus" data-field="quant[1]">
                                       <span class="fa fa-minus"></span>
                                       </button>
                                       </span>
                                       <input name="quant[1]" class="form-control border-form-control form-control-sm input-number" value="1" type="text">
                                       <span class="input-group-btn">
                                       <button type="button" class="btn btn-theme-round btn-number" data-type="plus" data-field="quant[1]">
                                       <span class="fa fa-plus"></span>
                                       </button>
                                       </span>
                                    </div>
                                 </td>
                                 <td class="price"><span>$188.00</span></td>
                                 <td class="action">
                                    <a data-toggle="tooltip" data-placement="top" title="" href="" data-original-title="Remove"><i class="fa fa-trash-o"></i></a>
                                 </td>
                              </tr>
                           </tbody>
                           <tfoot>
                              <tr>
                                 <td colspan="1"></td>
                                 <td colspan="4">
                                    <form class="form-inline pull-right">
                                       <div class="form-group">
                                          <input class="form-control border-form-control form-control-sm" placeholder="Enter discount code" type="text">
                                       </div>
                                       &nbsp;
                                       <button type="submit" class="btn btn-success pull-left btn-sm">Apply</button>
                                    </form>
                                 </td>
                                 <td colspan="2">Discount : $237.88 </td>
                              </tr>
                              <tr>
                                 <td colspan="2"></td>
                                 <td colspan="3">Total products (tax incl.)</td>
                                 <td colspan="2">$437.88 </td>
                              </tr>
                              <tr>
                                 <td colspan="5"><strong>Total</strong></td>
                                 <td colspan="2"><strong>$337.88 </strong></td>
                              </tr>
                           </tfoot>
                        </table>
                     </div>
                     <a href="<%= Url("Shop_Mobile_Cartcheckout") %>" class="btn btn-theme-round btn-lg pull-right">NEXT</a>
                  </div>
               </div>
            </div>
         </div>
      </section>
<uc1:Top_Brands runat="server" id="Top_Brands" />
