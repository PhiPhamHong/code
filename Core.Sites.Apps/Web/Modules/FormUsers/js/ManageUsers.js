function ManageUsers()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));
    this.formEdit = "MainFormEditUser";

    this.beforeInitGrid = function(table)
    {
        var $this = this;

        table.createdRow = function (row, data, dataIndex)
        {
            if (data.IsAdmin) $(row).addClass("warning");
        };

        table.createDashBoard = function(data)
        {
            $this.createDashBoard(data);
        }

        table.resetLogin = function(data)
        {
            $this.resetLogin(data);
        }

        table.createdUserName = function(td, cellData, rowData, row, col)
        {
            if (rowData.IsBoss == true) $(td).addClass("bg-green");
        }

        table.AssignPermission = function (data)
        {
            $this.assignPermission(data);
        }
    }

    this.createDashBoard = function(data)
    {
        Core.showPopupModule("FormCreateDashboardForUser",
            function (popup) {
                popup.title = Core.getLabel("Sao chép cho {0}".format(data.UserName));
            },
            function (module, popup) {
                popup.UserId = data.UserId;
            });
    }

    this.resetLogin = function(data)
    {
        var $this = this;
        this.table.post("ResetLogin", { UserId: data.UserId }, function () {
            $this.table.showMsgSuccess("Reset trạng thái đăng nhập thành công");
        });
    }

    this.assignPermission = function(data)
    {
        Core.showPopupModule("ManageUserPermissions", function (popup) {
            popup.title = Core.getLabel("Phân quyền cho tài khoản \"{0}\"".format(data.UserName));
            popup.data.UserId = data.UserId;
            popup.fullScreen = true;
            popup.fullScreenHeightScroll = true;
        },
        function (module) {

        });
    }
}

function MainFormEditUser(pBody, res, target)
{
    this.start = function () 
    {
        var $this = this;
        pBody.find("[name=CompanyId]").change(function () 
        {
            target.table.post("GetSubDomain", { CompanyId: $(this).val() }, function (res) 
            {
                pBody.find(".sub-domain").html(res.Data.SubDomain);
            });
        });
    };
}