function DashBoardUsing()
{
    $.extend(this, new ModuleBase());

    this.init = function (res)
    {
        var table = new CoreDataTable();
        table.main = this.getMain();
        table.res = res;
        table.typeAction = "Web.Controls.DashBoards.DashBoardUsing";
        table.EditDashBoard = function (data, target, column)
        {
            DashBoard.ShowConfig(data.Url, data.Id, function ()
            {
                table.showMsgSuccess("Cập nhật bảng điều khiển thành công");
                table.bind(0);
            });
        }
        table.init();
    }
}