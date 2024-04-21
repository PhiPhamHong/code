function ManageCategories()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));

    this.catType = null;
    this.beforeInit = function(res)
    {
        var $this = this;
        if (this.catType == null) this.catType = res.Data.CatType;

        this.onBeforeInitGrid(function (table)
        {
            table.extendDataSearch = table.extendDataSave = table.extendDataEdit = function () { return { CatType: $this.catType }; };
        });
    }
}