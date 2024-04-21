function ManageNews()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));
    this.formEdit = "FormMainEditNews";

    this.newType = null;
    this.beforeInit = function (res) {
        var $this = this;
        if (this.newType == null) this.newType = res.Data.NewType;
        this.onBeforeInitGrid(function (table) {
            table.dialogEditType = "modal-lg-super";
            table.selectorNotGetValues = "#infoNewsRelate";
            table.lengthBar = "4";

            table.extendDataSearch = table.extendDataSave = table.extendDataEdit = function () { return { Type: $this.newType }; };
        });
    }
}

function FormMainEditNews(target, res, popupBody)
{
    this.start = function ()
    {
        var $this = this;
        this.popup.header.parent().attr("data-form", "tab-header");
        this.popup.header.parent().append(popupBody.find("[data-form=tab-of-news]"));
        this.popup.header.parent().onCTab(this, { entity: this.popup.getData, fieldKey: "NewsId", entityName: "Bài viết", contentContainer: popupBody.find("[data-form=tab-news]") });

        popupBody.find("[name=NewsContent]").height($(window).height() - 750);
        popupBody.buildEditor("[name=NewsContent]");
        popupBody.find("[name=Sapo]").textAreaLength({ max: 180 });
        popupBody.find("[name=SapoShort]").textAreaLength({ max: 90 });
    }
    this.infoNewsRelate_BeforeInit = function (module, res) { this.moduleCalHeight(module, 540); };
    this.infoFiles_BeforeInit = function (module, res) { this.moduleCalHeight(module, 540); };
    this.infoNewsRelate_CustomerData = function (data) { };

    this.moduleCalHeight = function (module, height)
    {
        module.onBeforeInitGrid(function (table) { table.customerOptions = function (options) { options.scrollY = $(window).height() - height; }; });
    }
    
    this.infoFaceBookTool_CustomerData = function (data) { data.TypeModule = 1; }
    this.infoGoogleTool_CustomerData = function (data) { data.TypeModule = 2; }
}