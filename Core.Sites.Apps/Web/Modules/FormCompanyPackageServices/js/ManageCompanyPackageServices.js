function ManageCompanyPackageServices()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));
    this.beforeInitGrid = function(table)
    {
        table.createdRow = function (row, data, dataIndex)
        {
            if (table.dataSearch.ShowHistory && data.Id != -1)
                $(row).addClass("warning");
        };
    }
}