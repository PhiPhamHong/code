function ManageHashtags() {
    $.extend(this, new ModuleGrid({ fixedColumns: { leftColumns: 1 }, scrollX: true, scrollY: $(window).height() - 310 }));

    this.onBeforeInitGrid(function (table) {
        table.cellColor = function (td, cellData, data, row, col) { $(td).css("background-color", data.Color).css("color", data.TextColor); };
    });
}