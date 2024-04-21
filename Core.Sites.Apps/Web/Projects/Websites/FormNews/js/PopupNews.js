function PopupNews()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 560 }));

    this.onBeforeInitGrid(function (table)
    {
        table.lengthBar = "5";
    });
}