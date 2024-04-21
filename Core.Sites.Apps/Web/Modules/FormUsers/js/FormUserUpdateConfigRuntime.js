function FormUserUpdateConfigRuntime()
{
    $.extend(this, new ModuleNormal());

    this.onInit = function (res)
    {
        this.getMain().find("[name=ColorMenuGroup]").attr("data-template-func", "colorResult");

        this.getMain().fillForm(res.Data.Config, null, null, this);
        this.popup.appendButton(this.createButton());
    }

    this.createButton = function ()
    {
        var $this = this;
        return {
            cls: "btn btn-success pull-left", icon: "fas fa-save", value: "Lưu lại", func: function (element, scope)
            {
                var data = $this.getMain().getValues();
                $this.post("SaveConfig", data, function (res)
                {
                    Core.notify("Cập nhật cấu hình thành công");
                    $this.popup.hide();

                    UserMenuDropDown = data.UseMenuDropdown;
                    Config.Data = data;

                    App.restart();
                });
            }
        };
    };

    this.colorResult = function(item)
    {
        if (item.element == null) return item.text;
        var css = $(item.element).attr("data-css");
        return $("<span class='btn-block bg-" + css + "' style='padding:5px'>" + item.text + "</span>");
    }
}