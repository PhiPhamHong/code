function FormGotoUser()
{
    $.extend(this, new ModuleNormal());

    this.onInit = function(res)
    {
        this.getMain().benice();
        Core.buildSelectInputChange(this.getMain());
        this.popup.appendButton(this.createButtonLogin());
        if(res.Data.InOtherUser == true)
            this.popup.appendButton(this.createButtonLogout());
    }

    this.createButtonLogin = function ()
    {
        var $this = this;
        return {
            cls: "btn bg-maroon pull-left", icon: "fas fa-sign-in-alt", value: "Đăng nhập", func: function (element, scope)
            {
                $this.post("Goto", $this.getMain().getValues(), function (res)
                {

                });
            }
        };
    };
    this.createButtonLogout = function () {
        var $this = this;
        return {
            cls: "btn btn-danger pull-left", icon: "fas fa-sign-out-alt", value: "Đăng xuất", func: function (element, scope) {
                $this.post("UnGoto", { }, function (res) {

                });
            }
        };
    };
}