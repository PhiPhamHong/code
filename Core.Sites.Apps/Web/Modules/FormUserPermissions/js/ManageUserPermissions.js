function ManageUserPermissions()
{
    $.extend(this, new ModuleNormal());

    this.onInit = function (res) {
        this.getMain().benice();

        this.popup.appendButton(this.createButtonSave());
        this.popup.appendButton(this.createButtonCheckAll());
        this.popup.appendButton(this.createButtonUnCheckAll());

        this.find("a[data-parent]").eq(0).click();
        this.getMain().bindfunc(this);
    };

    this.createButtonCheckAll = function () {
        var $this = this;
        return {
            cls: "btn btn-success pull-left", icon: "fas fa-check-double", value: "Chọn tất cả", func: function (element, scope) {
                $this.find("input").iCheck("check");
            }
        };
    };

    this.createButtonUnCheckAll = function () {
        var $this = this;
        return {
            cls: "btn btn-danger pull-left", icon: "fas fa-calendar-times", value: "Bỏ chọn tất cả", func: function (element, scope) {
                $this.find("input").iCheck("uncheck");
            }
        };
    };

    this.createButtonSave = function () {
        var $this = this;
        return {
            cls: "btn btn-primary pull-left", icon: "fas fa-save", value: "Lưu lại", func: function (element, scope) {
                var values = $this.getMain().getValues();
                $this.post("SavePermission", $.extend(values, { UserId: $this.res.Data.UserId }), function (res) {
                    Core.alert("Cập nhật quyền của <b>{0}</b> thành công".format($this.res.Data.UserName));
                    $this.popup.hide();
                });
            }
        };
    };

    this.ChooseAll = function (target) {
        var chks = target.parent().parent().find("input");
        if (chks.length != Enumerable.From(chks).Count("$.checked")) chks.iCheck("check");
        else chks.iCheck("uncheck");
    }
}