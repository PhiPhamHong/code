function WebManageLabels()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310, fixedColumns: { leftColumns: 1 }, scrollX: true }));
}