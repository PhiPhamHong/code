function PrinterConfig()
{
    $.extend(this, new Printer());

    this.afterLoadPrint = function ()
    {   
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

    this.createButtonSaveConfig = function ()
    {
        var $this = this;
        return {
            cls: "btn btn-success pull-left", hotKey: "Ctrl_s", icon: "fas fa-save", value: "Lưu lại", func: function (element, scope)
            {
                var data = $this.getMain().getValues();
                data.ModulePrint = $this.popup.data.ModulePrint;
                $this.post("SaveConfig", data, function (res)
                {
                    Core.notify("Cập nhật cấu hình thành công");
                    $this.popup.hide();
                    $this.afterSaveConfig();
                });
            }
        };
    };

    this.afterSaveConfig = function () { };
}