/// <reference path="../../../../Resources/Plugins/linq/linq.js" />

function FromViewLogActionDetail()
{
    $.extend(this, new ModuleNormal());
    this.onInit = function (res)
    {
        var main = this.getMain();
        main.find("[data-form=main-log]").css("max-height", $(window).height() - 200).css("overflow","auto");
        FromViewLogActionDetail.build(main);
    }
}

FromViewLogActionDetail.build = function(main)
{
    var ajax = new CoreAjax("Web.Projects.LogActions.Reports.FromViewLogActionDetail");
    ajax.userOverlay = ajax.alertWhenFail = false;
    Enumerable.From(main.find("[data-type]"))
                .Select(function (ele) { return $(ele).attr("data-type"); })
                .Distinct()
                .ForEach(function (type) 
                {
                    var areaType = main.find("[data-type='" + type + "']");

                    var values = Enumerable.From(areaType.find("[data-o]")).ToString(",", function (ele) { return $(ele).attr("data-o"); });
                    ajax.post("GetLogField", { type: type, values: values }, function (res) 
                    {
                        if (res.Data.Results == null) return;

                        areaType.find("[data-o]").each(function () 
                        {
                            var ele = $(this);
                            var ids = ele.attr("data-o").split(',');
                            var valueText = Enumerable.From(res.Data.Results).Join(ids,
                                function (kv) { return kv.Key + ""; },
                                function (id) { return id; },
                                function (kv, id) { return kv; }).ToString(",", function (kv) { return kv.Value; });
                            ele.html(valueText);
                        });
                    });
                });

    main.find("[data-o]").each(function () 
    {
        var td = $(this);
        var parent = td.parent();
        if(parent.attr("data-type") == null)
        {
            var value = td.html();
            if ($.isNumeric(value))
                td.html(Core.formatMoney(parseFloat(value)));
        }
    });
}