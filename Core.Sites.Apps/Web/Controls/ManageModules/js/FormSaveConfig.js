function FormSaveConfig()
{
    $.extend(this, new ModuleNormal());

    this.onInit = function (res)
    {
        var $this = this;
        if (res.Data.ModuleConfigScripts == null) res.Data.ModuleConfigScripts = [];
        Core.getScriptsNeedLoad(res.Data.ModuleConfigScripts, function ()
        {
            var module = null;
            eval(String.format("if(typeof({0}) != 'undefined') { module = new {0}(); }", res.Data.ModuleConfigName));
            if (module != null)
            {
                var resForModule = $.extend(true, {}, res);
                resForModule.Data.ModuleTypeAction = res.Data.ModuleConfigTypeAction;
                resForModule.Data.ModuleProject = res.Data.ModuleConfigProject;
                module.main = $this.getMain();
                module.init(resForModule);
            }
        });

        this.popup.appendButton(this.createButtonSaveConfig());
    }

    this.onPopupLoadModule = function (res)
    {
        var $this = this;
        this.popup.onAlwaysShow = function ()
        {
            $this.getMain().fillForm(res.Data.Setting);
        }
    }

    this.afterSaveConfig = function () { };    

    this.createButtonSaveConfig = function () {
        var $this = this;
        return {
            cls: "btn btn-success pull-left", hotKey: "Ctrl_s", icon: "fas fa-save", value: "Lưu lại", func: function (element, scope)
            {
                var data = $this.getMain().getValues();
                data.Module = $this.popup.data.Module;
                $this.post("SaveConfig", data, function (res)
                {
                    Core.notify("Cập nhật cấu hình thành công");
                    $this.popup.hide();
                    $this.afterSaveConfig(res);
                });
            }
        };
    };
}