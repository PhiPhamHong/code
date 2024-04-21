function ManageGroupUsers()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));
    this.formEdit = "ManageGroupUsers.FormEdit";
    this.onBeforeInitGrid(function (table) { table.dialogEditType = "modal-lg"; });
}

ManageGroupUsers.FormEdit = function (module, res)
{
    this.start = function ()
    {
        this.popup.popupBody.onCTab(this, { entity: this.popup.getData, fieldKey: "GroupId", fields: ["CompanyId"], entityName: Core.getLabel("Nhóm") });

        var gridLeader = new ManageGroupUsers.FormEdit.Leader(res.Data.Leaders, this.popup.popupBody.find("[data-form=leader]"));
        gridLeader.formEdit = this;
        gridLeader.init();
    };

    this.getCompanyId = function () { return this.popup.popupBody.find("[name=CompanyId]").val(); };
    this.extendDataSave = function ()
    {
        var data = {};
        $.extend(data, Grid.buildData("leader", res.Data.Leaders));
        return data;
    }

    this.infoUsers_BeforeInit = function (module, res) { this.moduleCalHeight(module, 430); };    

    this.moduleCalHeight = function (module, height)
    {
        module.onBeforeInitGrid(function (table)
        {
            table.customerOptions = function (options) { options.scrollY = $(window).height() - height; };
        });
    }
}

ManageGroupUsers.FormEdit.Leader = function (sourceData, containerArea)
{
    $.extend(this, new Grid.TPO(sourceData, containerArea));
    this.createColumns = function ()
    {
        return [this.createColumnUser({width: "100px"}),
            { data: "Note", width: "300px", title: "Ghi chú" }];
    }

    this.customerOption = function (options)
    {
        options.height = 150;
    }
}