/// <reference path="../../../Resources/Plugins/linq/linq.min.js" />

function ManagePackageServiceModules()
{
    $.extend(this, new ModuleBase());
    $.extend(this, new CoreAjax());

    this.typeAction = "Web.Modules.FormPackageServiceModules.ManagePackageServiceModules";

    this.init = function()
    {
        this.getMain().benice();
        this.getMain().bindfunc(this);
    }

    this.ChoosePagekage = function(value, target)
    {
        var url = target.attr("data-url");
        url = value == "0" ? url : (url + "?PackageServiceId=" + value);
        Core.go(url);
    }
    this.ChooseAllAll = function(target)
    {
        this.getMain().find("input").iCheck("check");
    }
    this.UnChooseAllAll = function(target)
    {
        this.getMain().find("input").iCheck("uncheck");
    }

    this.Save = function(value, target)
    {
        this.post("SavePermission", this.getMain().getValues(), function (res)
        {
            Core.alert("Cập nhật thành công");
        });
    }

    this.ChooseAll = function(target)
    {        
        var chks = target.parent().parent().find("input");
        if(chks.length != Enumerable.From(chks).Count("$.checked")) chks.iCheck("check");
        else chks.iCheck("uncheck");
    }
}