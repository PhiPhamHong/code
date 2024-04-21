function ManageDirections() {
    $.extend(this, new ModuleGrid({ fixedColumns: { leftColumns: 1, rightColumns: 1 }, scrollX: true, scrollY: $(window).height() - 310 }));
}