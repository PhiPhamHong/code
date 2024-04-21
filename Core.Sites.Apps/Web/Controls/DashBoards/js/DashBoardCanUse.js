function DashBoardCanUse()
{
    $.extend(this, new ModuleBase());

    this.init = function (res)
    {
        var table = new CoreDataTable();
        table.typeAction = "Web.Controls.DashBoards.DashBoardCanUse";
        table.res = res;
        table.main = this.getMain();
        table.ShowAddDashBoard = function (data, target, column)
        {            
            DashBoard.ShowConfig(data.UrlVirtual, "", function ()
            {
                table.showMsgSuccess("Thêm bảng điều khiển thành công");
                table.bind(0);
            });
        }
        table.init();
    }
}