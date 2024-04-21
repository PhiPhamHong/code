function ManageNotifications()
{
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));
    this.beforeInit = function (res)
    {
        this.onBeforeInitGrid(function (table)
        {
            table.dialogEditType = "modal-lg";
        });
    };
}