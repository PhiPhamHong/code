function ManageNotifycationByUser()
{
    $.extend(this, new ModuleGrid());

    this.beforeInit = function (res)
    {
        this.onBeforeInitGrid(function (table)
        {
            table.knownCell = function (td, cellData, rowData, row, col)
            {
                $(td).html(Core.getLabel(rowData.Known == true ? "Đã biết" : "Chưa biết"));
                if (rowData.Known != true) $(td).addClass("bg-red");
            }

            table.viewedCell = function (td, cellData, rowData, row, col)
            {
                $(td).html(Core.getLabel(rowData.Viewed == true ? "Đã xem" : "Chưa xem"));
                if (rowData.Viewed != true) $(td).addClass("bg-red");
            }

            table.ViewNotification = function(data)
            {
                NotificationCenter.inst.show(data);
            }
        });
    };
}