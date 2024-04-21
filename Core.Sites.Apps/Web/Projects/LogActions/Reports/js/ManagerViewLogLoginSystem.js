function ManagerViewLogLoginSystem() {
    var $this = this;
    $.extend(this, new ModuleGrid({ scrollY: $(window).height() - 310 }));
    $this.onBeforeInitGrid(function (table) {
        table.topInputSearch = 4;
        table.lengthBar = "3";

        table.cellColor = function (td, cellData, data, row, col) {
            if (data.Success == false)
                $(td).css("background-color", "red").css("color", "white");
        }
    });
}