function DashBoardMain()
{
    $.extend(this, new ModuleBase());
    var $this = this;
    $this.dashboard = new DashBoard();
    $this.init = function (res)
    {
        Core.getScriptsNeedLoad(res.Data.DashBoardScripts, function ()
        {
            $this.dashboard.load($this.getMain());
        });
    }

    $this.end = function ()
    {
        $this.dashboard.end();
    }
}