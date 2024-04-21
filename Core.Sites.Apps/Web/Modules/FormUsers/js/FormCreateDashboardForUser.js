function FormCreateDashboardForUser()
{
    $.extend(this, new ModuleNormal());

    this.onInit = function(res)
    {
        this.getMain().benice();
        this.popup.appendButton(this.createDashboard());
        this.popup.appendButton(this.createPermission());
    }

    this.createDashboard = function () 
    {
        var $this = this;
        return {
            cls: "btn bg-maroon pull-left", icon: "fas fa-copyright", value: "Sao chép bảng tin", func: function (element, scope) 
            {
                var data = $this.getMain().getValues();
                data.UserIdNeedCopyTo = $this.popup.UserId;
                $this.post("CopyDashboard", data, function (res)
                {
                    Core.alert("Sap chép bảng tin thành công");
                    $this.popup.hide();
                });
            }
        };
    };

    this.createPermission = function ()
    {
        var $this = this;
        return {
            cls: "btn bg-red pull-left", icon: "fas fa-key", value: "Sao chép quyền", func: function (element, scope)
            {
                var data = $this.getMain().getValues();
                data.UserIdNeedCopyTo = $this.popup.UserId;
                $this.post("CopyPermission", data, function (res)
                {
                    Core.alert("Sap chép quyền thành công");
                    $this.popup.hide();
                });
            }
        };
    };
}