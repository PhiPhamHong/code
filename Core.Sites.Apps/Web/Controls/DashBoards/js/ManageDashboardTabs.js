function ManageDashboardTabs()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));

    this.onBeforeInitGrid(function (table) 
    {
        table.fieldKey = "DashBoardTabId";
        table.entityName = Core.getLabel("Bảng tin");
    });
}