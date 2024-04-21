PageBase.DefaultPageLoadBase = function () {
    $.extend(this, new PageBase.DefaultPageLoad());
};

PageBase.PageLoad = function () {
    $.extend(this, new PageBase.DefaultPageLoadBase());
    this.Minus = function (btn) {
        var parent = btn.parents("#Quantity");
        var dataip = parent.find("[name=quantity]").val();
        if (parseInt(dataip) > 1) {
            parent.find("[name=quantity]").val(parseInt(dataip) - 1);
            if ((parseInt(dataip) - 1) <= 1)
                btn.attr("disabled", "disabled");
        }
        else {
            btn.attr("disabled", "disabled");
        }
    }
    this.Plus = function (btn) {
        var parent = btn.parents("#Quantity");
        var dataip = parent.find("[name=quantity]").val();
        parent.find("[name=quantity]").val(parseInt(dataip) + 1);
        parent.find("[data-cmd=Minus]").removeAttr("disabled");
    }
    var $this = this;
    this.AddToCart = function (btn) {
        var productId = btn.attr("data-id");
        $this.Add(productId, 1);
    }

    this.Add = function (productId, quantity) {
        var ajax = new CoreAjax("Projects.Web.Tools.ShCart");

        ajax.post("AddItem", {
            productId: productId,
            quantity: quantity,
            update: false
        },
            function (res) {
                Core.alert("Thêm vào giỏ hàng thành công!");
                $("#Cartheader").html(res.Data.Cart);
            });
    }
    this.clickTimkiem = function (btn) {
        var parent = btn.parents("#FromTim");
        var text = parent.find("#Input").val();
        var url = "/timkiem=" + text;
        window.location.replace(url);
    }

    this.Dathang = function (btn) {

        var parent = btn.parents("#FromInfo");
        var name = parent.find("#name").val();
        var sdt = parent.find("#sdt").val();
        var email = parent.find("#mail").val();
        var address = parent.find("#address").val();


        if (name == "") {
            Core.alert("Tên không được để trống!");
            return;
        }
        if (address == "") {
            Core.alert("Địa chỉ của bạn không được để trống!");
            return;
        }
        if (sdt == "") {
            Core.alert("Số điện thoại không được để trống!");
            return;
        }
       

        var ajax = new CoreAjax("Projects.Web.Tools.ShCart");
        ajax.post2("CheckOut", {
            name: name,
            sdt: sdt,
            address: address,
            mail: email
        },
            function (res) {
                $("#Cartheader").html(res.Data.Cart);
                $("#deliverytab").removeClass("active");
                $("#donetab").addClass("active");

            });
    }

    this.Register = function (btn) {
        var parent = btn.parents("#register");
        var resname = parent.find("#resname").val();
        var resaddress = parent.find("#resaddress").val();
        var resphone = parent.find("#resphone").val();
        var resmail = parent.find("#resmail").val();
        var resusername = parent.find("#resusername").val();
        var respassword = parent.find("#respassword").val();
        var resconfirm = parent.find("#resconfirm").val();

        if (resconfirm != respassword) {
            Core.alert("Hai mật khẩu không trùng khớp!");
            return;
        }
        if (resusername == "") {
            Core.alert("Tên tài khoản không được để trống!");
            return;
        }
        if (resname == "") {
            Core.alert("Tên bạn không được để trống!");
            return;
        }
        if (resaddress == "") {
            Core.alert("Địa chỉ của bạn không được để trống!");
            return;
        }
        if (resphone == "") {
            Core.alert("Số điện thoại không được để trống!");
            return;
        }
        if (respassword == "" || respassword.length < 6) {
            Core.alert("Mật khẩu không đúng định dạng! Mật khâu phải chứa ít nhất 6 ký tự!");
            return;
        }


        var ajax = new CoreAjax("Projects.Web.Tools.UserLogin");
        ajax.post2("Register", {
            resname: resname,
            resaddress: resaddress,
            resphone: resphone,
            resmail: resmail,
            resusername: resusername,
            respassword: respassword
        },
            function (res) {
                Core.alert("Đăng ký thành công! hãy chọn đăng nhập!");
            });
    }

    this.Login = function (btn) {
        var parent = btn.parents("#login");
        var username = parent.find("#username").val();
        var password = parent.find("#password").val();

        if (username == "") {
            Core.alert("Tên tài khoản không được để trống!");
            return;
        }

        if (password == "") {
            Core.alert("Mật khẩu không được để trống!");
            return;
        }

        var ajax = new CoreAjax("Projects.Web.Tools.UserLogin");
        ajax.post2("Login", {
            username: username,
            password: password
        },
            function (res) {
                if (res.Data.KQ == 1 || res.Data.KQ == "1") {
                    window.location.replace("/trang-chu");
                    window.location.replace("/trang-chu");
                }
            });
    }

    this.Logout = function (btn) {
        var ajax = new CoreAjax("Projects.Web.Tools.UserLogin");
        ajax.post("Logout", {},
            function (res) {
                if (res.Data.KQ == 1 || res.Data.KQ == "1") {
                    window.location.replace("/trang-chu");
                    window.location.replace("/trang-chu");
                }
            });
    }
}

PageBase.DefaultPageLoadInstance = function () { return new PageBase.PageLoad(); };