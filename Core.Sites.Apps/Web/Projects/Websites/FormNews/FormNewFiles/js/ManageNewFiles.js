function ManageNewFiles() {
    $.extend(this, new ModuleGrid({ fixedColumns: { leftColumns: 1, rightColumns: 1 }, scrollX: true, scrollY: $(window).height() - 340 }));
    this.onBeforeInitGrid(function (table) {
        table.createdRow = function (row, data, dataIndex) {
            $(row).find("td.file-extension").html("<img src='" + Core.getPathIcon(data.FileExtension) + "'>");
            $(row).find("td.file-download").html("<a href='" + data.Path + "' target='_blank'>" + Core.getLabel("Tải tệp") + "</a>");
        };
    });
}