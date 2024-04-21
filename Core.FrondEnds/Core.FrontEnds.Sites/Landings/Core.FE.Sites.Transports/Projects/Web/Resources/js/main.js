function CheckPrice(element) {
    var btn = $(element);
    var modal = btn.parents(".main-content");
    var startpoint = modal.find("[id=startPoint]").val();
    var endpoint = modal.find("[id=endPoint]").val();
    var producttype = modal.find("[id=productType]").val();
    var containertype = modal.find("[id=containerType]").val();
    var language = $("[data-language]").attr("data-language");
    var ajax = new CoreAjax();
    ajax.typeAction = "Projects.Web.Ajax.PriceHelper";
    ajax.assembly = "Core.FE.Sites.Transports";
    ajax.post2("GetPrice", { startPoint: startpoint, endPoint: endpoint, productType: producttype, containerType: containertype, languageId: language }, function (res) {
        if (res.Data.Error == true) {
            alert(res.Data.Message);
        }
        else {
            modal.find("[id=result]").html(res.Data.Result);
        }

    });
}

function SearchDoc(element) {
    var btn = $(element);
    var modal = btn.parents(".main");
    var keyword = modal.find("[id=keyword]").val();
    if (keyword == "") {
        modal.find(".data-doc").removeClass("hidden");
        return;
    }
    var ajax = new CoreAjax();
    ajax.typeAction = "Projects.Web.Ajax.SearchHelper";
    ajax.assembly = "Core.FE.Sites.Transports";
    var language = $("[data-language]").attr("data-language");

    ajax.post2("Search", { keyword: keyword, searchType: 1, languageId: language }, function (res) {
        modal.find(".data-doc").addClass("hidden");
        debugger;
        res.Data.ShowIds.forEach((id) => {
            var formant = "[data-id=" + id + "]";
            modal.find(formant).removeClass("hidden");
        });

    });
}

function SearchNew(element) {
    var btn = $(element);
    var modal = btn.parents(".main");
    var keyword = modal.find("[id=keyword]").val();
    if (keyword == "") {
        modal.find(".data-new").removeClass("hidden");
        return;
    }
    var ajax = new CoreAjax();
    ajax.typeAction = "Projects.Web.Ajax.SearchHelper";
    ajax.assembly = "Core.FE.Sites.Transports";
    var language = $("[data-language]").attr("data-language");
    var currentCatId = modal.find("[data-current-catId]").attr("data-current-catId");
    ajax.post2("Search", { keyword: keyword, searchType: 2, languageId: language, catId: currentCatId }, function (res) {
        modal.find(".data-new").addClass("hidden");
        debugger;
        res.Data.ShowIds.forEach((id) => {
            var formant = "[data-id=" + id + "]";
            modal.find(formant).removeClass("hidden");
        });

    });
}