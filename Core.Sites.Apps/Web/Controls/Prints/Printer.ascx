<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Printer.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.Prints.Printer" %>
<div class="row">
    <div class="col-sm-12">
        <div class="nav-tabs-custom mb-0 box-shadow-none" data-form="tab">
            <ul class="nav nav-tabs" data-form="tab-print">
                <li class="active"><a data-hot-key="f6" class="font-12" href="#tabHtml" data-toggle="tab"><span class="fa fa-print"></span> <%= Label("Nội dung In") %></a></li>                
                <li><a data-hot-key="f7" class="font-12" href="#tabPdf" data-toggle="tab" data-event-show="tabPdfClicked"><span class="far fa-file-pdf"></span> <%= Label("Pdf") %></a></li>                
            </ul>
            <div class="tab-content p-0">
                <div class="active tab-pane" id="tabHtml" style="padding-bottom: 1px">
                    <div data-content="html">
                        <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
                    </div>
                </div>
                <div class="tab-pane" id="tabPdf" style="padding-bottom: 1px"></div>
            </div>
        </div>
    </div>
</div>

