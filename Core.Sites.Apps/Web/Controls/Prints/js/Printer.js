function Printer()
{
    $.extend(this, new ModuleNormal());

    this.onInit = function (res)
    {
        var $this = this;
    
        $this.getMain().find("#tabPdf").height($(window).height() - 210);

        if (res.Data.PrintScripts == null) res.Data.PrintScripts = [];
        Core.getScriptsNeedLoad(res.Data.PrintScripts, function ()
        {
            var modulePrint = null;
            eval(String.format("if(typeof({0}) != 'undefined') { modulePrint = new {0}(); }", res.Data.PrintModuleName));
            if (modulePrint != null)
            {
                var resForModule = $.extend(true, {}, res);
                resForModule.Data.ModuleTypeAction = res.Data.PrintModuleTypeAction;
                resForModule.Data.ModuleProject = res.Data.PrintModuleProject;
                modulePrint.main = $this.getMain().find("#tabHtml");
                modulePrint.init(resForModule);                
            }

            $this.afterLoadPrint();
        });
    }

    this.afterLoadPrint = function ()
    {
        this.popup.onCTab({ target: this, selector: "[data-form='tab-print']" });
    }

    this.tabPdfClicked = function (download)
    {
        if (download === true) this.downloadHelper(this.createUrl("Pdf", download), { httpMethod: "POST"});        
        else PDFObject.embed(this.createUrl("Pdf", download), this.getMain().find("#tabPdf"));
    }

    this.downloadPdf = function () { this.tabPdfClicked(true); };
    this.downloadWord = function () { this.downloadHelper(this.createUrl("Word", true), { httpMethod: "POST" }); };

    this.createUrl = function (document, download)
    {
        if (download == null) download = false;
        var query = Enumerable.From(this.popup.data).Where(function (kv) { return kv.Value != ""; });
        if (download === true) query = query.Concat([{ Key: "download", Value: true }]);
        query = query.ToString("&", function (kv) { return kv.Key + "=" + kv.Value; });
        var url = "/Services/" + document + ".aspx?" + query;
        return url;
    }

    this.print = function ()
    {
        var elementPrint = this.popup.popupBody;
        elementPrint = elementPrint.find("[data-content=html]");
        //$("<div>").html("<style>body { " + this.res.Data.StyleBody + " }</style>" + elementPrint.html()).print({ globalStyles: true, mediaPrint: false, stylesheet: '/css.axd?v=' + verJs, noPrintSelector: ".no-print", iframe: true, deferred: $.Deferred(), timeout: 750, });
        $("<div>").html("<style>body {margin:0mm;padding:0mm}</style>" + elementPrint.html()).print({ globalStyles: true, mediaPrint: false, stylesheet: '/css.axd?v=' + verJs, noPrintSelector: ".no-print", iframe: true, deferred: $.Deferred(), timeout: 750, });
        this.afterPrint();
    }
    this.afterPrint = function () { };
}