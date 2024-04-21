/// <reference path="../Plugins/linq/linq.min.js" />
/// <reference path="../Plugins/jQuery/jQuery-2.1.3.min.js" />
/// <reference path="Popup.js" />
/// <reference path="Core.js" />

// "createdCell": function (td, cellData, rowData, row, col)
// data-func: function (data, target, column)
function CoreDataTable() 
{
    $.extend(this, new CoreAjax());
    this.selectorTable = "#table";
    this.typeAction = "... Nhập object chứa action tại đây ..";
    this.res = null;                     // Dữ liệu ban đầu khi tải module

    // Cấu hình thông số khi hiển thị form popup cập nhật    
    this.dialogEditType = "";            // Loại dialog là to hay nhỏ
    this.hasButtonContinue = true;      // Có nút tiếp tục khi cập nhật hay không
    this.confirmWhenContinue = true;

    this.reloadFormWhenContinue = true;  // Tải mới toàn bộ lại form khi cập nhật?

    this.dialogModal = true;             // Có hiển thị là modal hay không
    this.dialogTop = null;               // position top của dialog
    this.dialogLeft = null;              // position left của dialog
    this.dialogMinimized = false;        //

    this.main = null;                    // Đây là selector main, chứa table
    this.table = null;
    this.formSearch = null;
    this.onInitDT = null;
    this.dataSearch = {};
    this.selectorNotGetValues = "";
    this.currentPopup = null;
    this.lengthBar = "4"; // 4 ô
    this.topInputSearch = 3;

    //var getTable = function () { return this.main == null ? $(this.selectorTable) : this.main.find(this.selectorTable); }
    var getTable = function () { return this.main == null ? null : this.main.find(this.selectorTable); }
    var getFormSearch = function () { var selector = "[data-for-table]"; return this.main == null ? null : this.main.find(selector); }

    var divMsg = null; // Vùng hiển thị thông báo

    var selectTrButtons = "thead tr[data-type=buttons]";
    //var selectTrThButtons = "thead tr[data-type=buttons] th[data-can=true],thead tr[data-type=buttons] th[data-can=True]";
    var selectTrThButtons2 = "th[data-can=true],th[data-can=True]";
    var selectTdCanViewFalse = "thead th[data-view=false],thead th[data-view=False]";

    this.afterShowFormEdit = null;       // Sự kiện sau khi mở form thêm mới (popup, res)
    this.afterSaveEntity = null;         // Sự kiện sau khi cập nhật entity   
    this.extendDataSearch = null;        // Mở rộng thêm data tìm kiếm
    this.extendDataSave = null;          // Mở rộng thêm data khi cập nhật
    this.extendDataEdit = null;          // Mở rộng thêm data khi mở form cập nhật
    this.onCreatePopupEdit = null;       // Sự kiện khi tạo Popup chỉnh sửa
    this.showMessageWhenSaveEntitySuccess = true; // 
    this.hidePopupSaveEntitySuccess = true;
    this.createdRow = null;              //function (row, data, dataIndex) { } // Sự kiện sau khi tạo row => nếu có thiết lập mới gọi
    this.afterDraw = null;               // Sự kiện sau khi bind xong dữ liệu trên table
    this.fillFormEdit = null;            // Sự kiện điền dữ liệu vào form edit
    this.onClickSearch = null;           // Sự kiện nút tìm kiếm được click
    this.onBuildOnButton = null;         // Sự kiện khi add thêm các button vào biến buttons của popup khi cập nhật. function (popup, res) : popup: form đang chỉnh sửa, res: dữ liệu của form chỉnh sửa
    this.hasButtonSave = true;           // Tự động build button cập nhật
    this.newDataWhenSaveContinue = null; // Sự kiện khi lưu xong, Form nhảy sang trạng thái tiếp tục cập nhật. Lúc này data(đối tượng cần cập nhật) sẽ reset về null (để coi như thêm mới). Tuy nhiên có thể tạo data != null với mục đích thêm mới khác nhau (Dành cho form thêm mới nhiều loại form trên 1 danh sách)
    this.onInitFormSearch = null;        // Sự kiện khởi tạo Form Search
    this.onRowClickSelected = null;      // Sự kiện khi một row được click chọn (tr, index)
    this.decidedHidePopupWhenSaveEntity = function (popup, msg, dataKey, resSave) {
        return dataKey[this.getFieldKey()] != 0 || popup.popupBody.onCTabFindTabNeedUpdateByKeyClicked() == null;
    };

    var reportSummary = null;
    this.getReportSummary = function () { return reportSummary; }

    this.fieldKey = null;
    this.entityName = null;

    this.getFieldKey = function () {
        var table = this.main == null ? null : this.main.find("table");
        return this.fieldKey == null ? (table == null ? null : table.attr("data-key")) : this.fieldKey;
    };

    this.getDataEntityName = function () {
        var table = this.main == null ? null : this.main.find("table");
        return this.entityName == null ? (table == null ? null : table.attr("data-entity-name")) : this.entityName;
    };

    this.customerOptions = function(options) { } // Mở rộng Options trước khi table được khởi tạo
    Core.addOnMethod(this, "customerOptions", "options");

    var currentData = null;
    this.totalFooterRow = 1;           // Tổng số Summary ở Footer. Mặc định là 1 Row
    this.gridContainer = null;
    this.tableOptions = null;

    var toolbar = null;

    var initOptions = null;
    var tableContent = null;

    this.parentTable = null;

    this.init = function (options) {
        var $this = this;
        //return;
        $this.selectorTable = "#" + $this.main.find("table").attr("id");

        var opts = createOptions.bind(this)();

        if (options == null) options = initOptions;
        else initOptions = options;

        if (options != null) $.extend(opts, options);
        // this.table = getTable.bind(this)().addClass("table table-bordered table-hover table-condensed table-striped"); // handsontable
        this.table = getTable.bind(this)().addClass("handsontable table-core-sh");

        this.parentTable = this.table.parent();

        //tableContent = this.table.children();
        // tableContent = this.table.html();
        tableContent = this.parentTable.html();

        createEventCreatedRow.bind(this)(opts);
        //addFormSearch.bind(this)(opts);

        // Tạo columns
        // Xóa cột không được phép hiển thị
        $this.table.find(selectTdCanViewFalse).remove();

        // Tạo Footer nếu có Summary
        createFooterSummary.bind(this)();

        addFormSearch.bind(this)(opts);

        createEventInitDT.bind(this)(opts);
        createEventDrawDT.bind(this)();

        this.tableOptions = opts;
        this.customerOptions(opts);

        ///////

        // Thiết lập định cột theo ý người dùng
        // $this.res.Data.UserColumn.FixedLeft
        // $this.res.Data.UserColumn.FixedRight
        if ($this.res.Data.UserColumn.FixedLeft != null && $this.res.Data.UserColumn.FixedLeft > 0) {
            if (opts.fixedColumns == null) opts.fixedColumns = {};
            opts.fixedColumns.leftColumns = $this.res.Data.UserColumn.FixedLeft;
        }
        if ($this.res.Data.UserColumn.FixedRight != null && $this.res.Data.UserColumn.FixedRight > 0) {
            if (opts.fixedColumns == null) opts.fixedColumns = {};
            opts.fixedColumns.rightColumns = $this.res.Data.UserColumn.FixedRight;
        }

        // Kiểm tra tính hợp lệ của các cột xem có thể thực hiện fixcolumns được hay không
        // Nếu fix được

        if (Core.isMobile() || Core.isTablet() || this.table.attr("data-scrollX") == "True") {
            opts.scrollX = true;
            this.table.addClass("core-table-scroll");
            opts.fixedColumns = null;
        }
        else {
            // Nếu độ rộng quá bé so với 
            if (this.table.show().width() < this.table.parent().width()) {
                opts.fixedColumns = null;
                if (opts.scrollY > 0)
                    opts.scrollX = false;
            }
        }

        //this.table.css("width", "100%");
        this.table.attr("width", "100%");
        ///////

        this.table = this.table.show().dataTable(opts);
    };

    this.end = function () {
        if (this.currentPopup != null)
            this.currentPopup.hide();
    };

    this.resData = null;

    var createOptions = function () {
        var $this = this;
        return {
            processing: true, serverSide: true, searching: false, //autoWidth: false,
            ajax:
            {
                url: "/Services/Ajax.aspx?_n=" + this.assembly + "&_o=" + this.typeAction + "&_m=LoadData", type: "POST",
                dataSrc: function (res) {
                    if (res.Data.MessageError != null) { $this.showMsgError(res.Data.MessageError); return []; }
                    reportSummary = res.Data.ReportSummary;
                    if ($this.table.find("tfoot").length > 0) currentData = res.Data.objects;

                    $this.resData = res.Data;
                    return res.Data.objects;
                }
            },
            dom: 'r<"toolbar">t<"bottom"lp><"clear">',
            lengthMenu: [[100, 50, 25, 20], [100, 50, 25, 20]],
            language:
            {
                "emptyTable": "",//Core.getLabel("Không có dữ liệu"),
                "info": Core.getLabel("Hiển thị _START_ đến _END_ trong tổng số _TOTAL_ bản ghi"),
                "infoEmpty": "",
                "infoFiltered": "(filtered from _MAX_ total entries)", "infoPostFix": "",
                "thousands": ",", "lengthMenu": Core.getLabel("Hiển thị _MENU_ bản ghi"),
                "loadingRecords": Core.getLabel("Đang tải"),
                "processing": Core.getLabel("Đang xử lý"),
                "search": Core.getLabel("Tìm kiếm") + ":",
                "zeroRecords": "",//Core.getLabel("Không bản ghi được tìm thấy"),
                "paginate": { "first": Core.getLabel("Đầu"), "last": Core.getLabel("Cuối"), "next": Core.getLabel("Tiếp"), "previous": Core.getLabel("Trước") },
                "aria": { "sortAscending": ":" + Core.getLabel("Giảm dần"), "sortDescending": ": " + Core.getLabel("Tăng dần") }
            }
        };
    };

    this.determineColumnShow = function (column, search) {
        if (column.data == null || column.data == "") return true;
        var readSetting = this.res.Data.UserColumn.ViewColumns;// true; // sau này muốn người dùng tự cấu hình hiển thị cột mong muốn
        if (readSetting.length > 0) readSetting = Enumerable.From(readSetting).Any(function (v) { return v == column.data; });
        else readSetting = true;

        return this.onDetermineColumnShow(column, search) && readSetting;
    };
    this.onDetermineColumnShow = function (column, search) {
        return true;
    };

    this.getOptionColumnFromUserColumn = function (userColumn) {
        var $this = this;
        var data = {};
        var columnShowings = userColumn.ViewColumns;
        if (columnShowings == null) columnShowings = [];

        var orderCol = $this.table.attr("data-order-col");
        var orderColDir = $this.table.attr("data-order-col-dir");

        //data.SortColumn = $this.res.Data.UserColumn.SortColumn;

        data.SortColumn = userColumn.SortColumn;
        data.SortDir = userColumn.SortDir;

        if (data.SortColumn == null || data.SortColumn == "") {
            var sortInfo = $this.getSortInfo();
            if (sortInfo != null) {
                data.SortColumn = sortInfo.fieldSort;
                data.SortDir = sortInfo.dirSort;
            }
        }

        data.dataColumns = Enumerable
            .From(this.tableOptions.columns)
            .Where(function (column, index) {
                var field = column.data;

                // Nếu không có cấu hình sắp xếp thì lấy theo mặc định ban đầu
                if (data.SortColumn == null || data.SortColumn == "") {
                    if (orderCol == index + "" && column.orderable == true) {
                        data.SortColumn = field;
                        data.SortDir = orderColDir;
                    }
                }
                //return field != null;
                return true;
            })
            .Select(function (column, index) {
                return { column: column, index: index, top: index < 1 };
            })
            .GroupBy(function (ci) { return parseInt(ci.index / 4); })
            .SelectMany(function (g) {
                return g.Select(function (ci) {
                    var text = ci.column.th.text();
                    var name = ci.column.th.attr("data-field");

                    var rs = { ColumnName: text, ColumnField: name, ColumnRootText: ci.column.th.attr("data-root-text"), Stt: 0, index: ci.index };
                    if (name != null && name != "" && ci.column.orderable == true) rs.sortOption = "<option value='" + name + "'>" + text + "</option>";

                    if (name == null || name == "" || columnShowings.length == 0) rs.Show = true;
                    else rs.Show = Enumerable.From(columnShowings).Any(function (c) { return c == name; });

                    rs.rootIndex = parseInt(ci.column.th.attr("data-root-index"));

                    rs.DataType = rs.ColumnField == null || rs.ColumnField == "" ? Core.getLabel("Chức năng") : Core.getLabel("Dữ liệu");

                    return rs;
                });
            }).ToArray();

        data.columnStts = userColumn.RootSttColumns;
        if (data.columnStts == null || data.columnStts.length == 0) {
            data.dataColumns = Enumerable.From(data.dataColumns).OrderBy(function (c) { return c.rootIndex; }).ToArray();
            Enumerable.From(data.dataColumns).ForEach(function (c, index) { c.Stt = (index + 1); });
        }
        else {
            data.dataColumns = Enumerable.From(data.columnStts)
                .Select(function (cs, index) { return { cs: cs, index: index }; })
                .Join(data.dataColumns,
                    function (csindex) { return csindex.cs; },
                    function (c) { return c.ColumnRootText; },
                    function (csindex, c) { c.Stt = csindex.index + 1; return c; }).OrderBy(function (c) { return c.Stt; }).ToArray();
        }

        data.FixedLeft = userColumn.FixedLeft;
        data.FixedRight = userColumn.FixedRight;

        if (data.FixedLeft == null || data.FixedLeft == 0) {
            if (initOptions.fixedColumns != null && initOptions.fixedColumns.leftColumns != null)
                data.FixedLeft = initOptions.fixedColumns.leftColumns;
        }
        if (data.FixedRight == null || data.FixedRight == 0) {
            if (initOptions.fixedColumns != null && initOptions.fixedColumns.rightColumns != null)
                data.FixedRight = initOptions.fixedColumns.rightColumns;
        }

        return data;
    };

    this.showPopupConfigColumns = function () {
        var $this = this;

        var data = this.getOptionColumnFromUserColumn($this.res.Data.UserColumn);

        var html = '<div class="form-horizontal">';

        html += '<div class="row" style="margin-bottom: 10px;">';
        html += '   <div class="col-sm-12">';
        html += '       <div data-form="column" class="tb-no-left border-table-grid border-table-grid-bottom"></div>';
        html += '   </div>';
        html += '</div>';
        html += '</div>';

        html += '<div class="form-horizontal form-no-pm">';
        html += "<div class='form-group'>";
        html += '   <label class="control-label col-sm-1">' + Core.getLabel("Định cột trái") + '</label>';
        html += '   <div class=" col-sm-1"><input autocomplete="off" type="text" class="form-control input-sm" name="FixedLeft" placeholder="' + Core.getLabel("Định cột trái") + '"></div>';
        html += '   <label class="control-label col-sm-1-25">' + Core.getLabel("Định cột phải") + '</label>';
        html += '   <div class=" col-sm-1"><input autocomplete="off" type="text" class="form-control input-sm" name="FixedRight" placeholder="' + Core.getLabel("Định cột phải") + '"></div>';
        html += '   <label class="control-label col-sm-0-75">' + Core.getLabel("Sắp xếp") + '</label>';
        html += '   <div class=" col-sm-3"><select name="SortColumn" data-width="100%" data-disable-search="True" data-select-type="select2"></select></div>';
        html += '   <div class=" col-sm-1-5"><select name="SortDir" data-width="100%" data-disable-search="True" data-select-type="select2"><option value="asc">Tăng dần</option><option value="desc">Giảm dần</option></select></div>';
        html += "</div>";
        html += "</div>";

        var grid = null;

        var popup = new Popup();
        popup.title = Core.getLabel("Thiếp lập cấu hình cột");
        popup.content = html;
        popup.clearWhenHide = true;
        popup.dialogType = "modal-lg";

        popup.buttons.push({
            value: Core.getLabel("Thiết lập"), hotKey: "Ctrl_s", icon: "fas fa-save", cls: "btn btn-success pull-left", func: function (element, scope) {
                var values = popup.popupBody.getValues();

                // Thực hiện validate
                // Cần chọn ít nhất một cột trường dữ liệu để hiển thị
                // Tổng số cột hiển thị phải >= tổng số định cột
                var totalFieldDataToShow = Enumerable.From(data.dataColumns).Count(function (c) {
                    return c.ColumnField != null && c.ColumnField != "" && c.Show == true;
                });

                if (totalFieldDataToShow == 0) {
                    Core.alert("Cần phải chọn ít nhất một cột trường dữ liệu để hiển thị");
                    return;
                }

                var fixedLeft = values.FixedLeft == null || values.FixedLeft == "" ? 0 : parseInt(values.FixedLeft);
                var fixedRight = values.FixedRight == null || values.FixedRight == "" ? 0 : parseInt(values.FixedRight);

                totalFieldDataToShow = Enumerable.From(data.dataColumns).Count(function (c) { return c.Show == true; });
                if (totalFieldDataToShow < fixedLeft + fixedRight) {
                    Core.alert("Tổng số cột được hiển thị phải >= tổng số định cột");
                    return;
                }

                var columns = Enumerable.From(data.dataColumns).Where(function (c) { return c.ColumnField != null && c.ColumnField != "" && c.Show == true; }).Select(function (c) { return c.ColumnField; });

                var rootSttColumns = Enumerable.From(data.dataColumns)
                    .OrderBy(function (c) { return c.Stt; })
                    .Select(function (c) { return c.ColumnRootText; });


                $this.res.Data.UserColumn.Module = $this.typeAction + $this.res.Data.ConcreteModuleId;
                $this.res.Data.UserColumn.Columns = columns.Distinct().ToString(",");
                $this.res.Data.UserColumn.ColumnStt = rootSttColumns.Distinct().ToString(",");
                $this.res.Data.UserColumn.FixedLeft = values.FixedLeft;
                $this.res.Data.UserColumn.FixedRight = values.FixedRight;
                $this.res.Data.UserColumn.SortColumn = values.SortColumn;
                $this.res.Data.UserColumn.SortDir = values.SortDir;

                var dataPost = {}; $.extend(dataPost, $this.res.Data.UserColumn);
                dataPost.ViewColumns = null;
                dataPost.RootSttColumns = null;

                $this.post("SaveUserColumn", dataPost, function (res) {
                    popup.hide();
                    $this.res.Data.UserColumn.ViewColumns = columns.Distinct().ToArray();
                    $this.res.Data.UserColumn.RootSttColumns = rootSttColumns.Distinct().ToArray();
                    $this.res.Data.UserColumn.UserColumnId = res.Data.UserColumnId;
                    $this.res.Data.UserColumn.mustRebuild = true;
                    $this.formSearch.search();
                });
            }
        });
        popup.buttons.push({
            value: Core.getLabel("Sắp xếp"), hotKey: "Ctrl_d", icon: "fas fa-sort", cls: "btn bg-maroon pull-left", func: function (element, scope) {
                data.dataColumns = Enumerable.From(data.dataColumns).OrderBy(function (c) { return c.Stt; }).ToArray();
                grid.loadData(data.dataColumns);
                grid.hot.render();
            }
        });
        popup.buttons.push({
            value: Core.getLabel("Trở về mặc định"), hotKey: "Ctrl_f", icon: "fas fa-undo", cls: "btn bg-red pull-left", func: function (element, scope) {
                data = $this.getOptionColumnFromUserColumn({});
                popup.popupBody.fillForm(data);
                popup.popupBody.find("[name=SortColumn]").trigger("change");
                popup.popupBody.find("[name=SortDir]").trigger("change");
                grid.loadData(data.dataColumns);
                grid.hot.render();
            }
        });

        var switchRow = function (nowRow, step) {
            var nextIndex = nowRow.index + step;
            var nextRow = Enumerable.From(data.dataColumns).FirstOrDefault(null, function (c) { return c.index == nextIndex });
            var temp = nowRow.Stt;
            nowRow.Stt = nextRow.Stt;
            nextRow.Stt = temp;
            data.dataColumns = Enumerable.From(data.dataColumns).OrderBy(function (c) { return c.Stt; }).ToArray();
            Enumerable.From(data.dataColumns).ForEach(function (c, index) { c.index = index; });
            grid.loadData(data.dataColumns);
            grid.hot.render();
            grid.setFocus(nextIndex, 0);
        };

        var upOne = function () {
            var nowRow = Enumerable.From(data.dataColumns).FirstOrDefault(null, function (c) { return c.selected == true; });
            if (nowRow == null || nowRow.index == 0) { Core.alert("Không thể dịch chuyển tiếp được"); return; };
            switchRow(nowRow, -1);
        };

        popup.buttons.push({
            value: Core.getLabel("Dịch lên"), hotKey: "Ctrl_l", icon: "fas fa-angle-double-up", cls: "btn bg-light-blue pull-left", func: function (element, scope) {
                upOne();
            }
        });

        var downOne = function () {
            var nowRow = Enumerable.From(data.dataColumns).FirstOrDefault(null, function (c) { return c.selected == true; });
            if (nowRow == null || nowRow.index == data.dataColumns.length - 1) { Core.alert("Không thể dịch chuyển tiếp được"); return; };
            switchRow(nowRow, 1);
        };

        popup.buttons.push({
            value: Core.getLabel("Dịch xuống"), hotKey: "Ctrl_x", icon: "fas fa-angle-double-down", cls: "btn bg-blue pull-left", func: function (element, scope) {
                downOne();
            }
        });

        var setPositionItem = function (stt, focus) {
            var nowRow = Enumerable.From(data.dataColumns).FirstOrDefault(null, function (c) { return c.selected == true; });
            nowRow.Stt = stt;
            data.dataColumns = Enumerable.From(data.dataColumns)
                .OrderBy(function (c) { return c.Stt; })
                .Select(function (c, index) { c.Stt = index; c.index = index; return c; })
                .ToArray();
            grid.loadData(data.dataColumns);
            grid.hot.render();
            grid.setFocus(focus, 0);
        };

        popup.onAlwaysShow = function () {
            var selectSortColumn = popup.popupBody.find("[name=SortColumn]");
            selectSortColumn.html(Enumerable.From(data.dataColumns).Where(function (c) { return c.sortOption != null; }).ToString("", function (c) { return c.sortOption; }));

            popup.popupBody.fillForm(data);
            grid = new CoreDataTable.GridColumnConfig(data.dataColumns, popup.popupBody.find("[data-form=column]"));
            grid.upToTop = function () { setPositionItem(-1, 0); };
            grid.downToBottom = function () { setPositionItem(data.dataColumns.length, data.dataColumns.length - 1); };
            grid.upOne = function () { upOne(); };
            grid.downOne = function () { downOne(); };
            grid.init();
        };

        popup.show();
    };

    var createEventInitDT = function (opts) {
        var $this = this;

        // buttons ở header
        var buttons = [];

        var trButtons = $this.table.find(selectTrButtons);

        if (Core.stringLower(trButtons.attr("data-button-add")) == "true") buttons.push({ text: Core.getLabel("Thêm mới"), hotKey: "f1", bgCss: "bg-green", icon: "fas fa-plus-square", func: function () { $this.AddNew(null); } });
        buttons = buttons.concat(Enumerable.From(trButtons.find(selectTrThButtons2)).Select(function (th)
        {
            var $th = $(th);
            return { text: $th.html(), hotKey: $th.attr("data-hot-keys"), bgCss: $th.attr("data-cssBg"), icon: $th.attr("data-icon"), func: $this[$th.attr("data-func")].bind($this), th: th };
        }).ToArray());

        var trColspan = $this.table.find("[data-row-colspan]");

        if (trColspan.length == 0)
            buttons.push({ text: Core.getLabel("Cấu hình cột"), hotKey: "f4", bgCss: "bg-purple", icon: "fas fa-keyboard", func: function () { $this.showPopupConfigColumns(); } });

        trButtons.remove();
        trColspan.remove();

        var ths = $this.table.find("thead tr[data-column-real] th");
        //Enumerable.From(ths).ForEach(function (th, index) { $(th).attr("data-root-index", index); });

        var columnStts = $this.res.Data.UserColumn.RootSttColumns
        if (columnStts != null && columnStts.length > 0) {
            var trReal = $this.table.find("thead tr[data-column-real]");
            trReal.empty();
            var thindexes1 = Enumerable.From(columnStts)
                .Select(function (cs, index) { return { cs: cs, index: index }; })
                .Join(ths, function (csindex) { return csindex.cs; },
                    function (th) { return $(th).attr("data-root-text"); },
                    function (csindex, th) { return { th: th, index: csindex.index }; });

            // Tìm những cột mà lập trình thêm => từ đó chèn cột thêm đó vào đúng vị trí mặc định
            var thindexes2 = Enumerable.From(ths).Select(function (th, index) { return { th: th, index: index } })
                .GroupJoin(columnStts, function (thindex) { return $(thindex.th).attr("data-root-text"); },
                    function (cs) { return cs; },
                    function (thindex, css) {
                        return { thindex: thindex, total: css.Count() };
                    })
                .Where(function (t) { return t.total == 0; })
                .Select(function (t) { return t.thindex; });

            //var thindexes =
                thindexes1.Concat(thindexes2)
                .OrderBy(function (thindex) { return thindex.index; })
                .ForEach(function (thindex) {
                    trReal.append($(thindex.th).clone());
                });
        }

        ths = $this.table.find("thead tr[data-column-real] th");

        var sortInfo = $this.getSortInfo(ths);
        if (sortInfo != null) opts.order = [[sortInfo.indexSort, sortInfo.dirSort]];

        opts["columns"] = Enumerable.From(ths).Select(function (th, index) {
            var $th = $(th);

            var optionColumn = { data: $th.attr("data-field"), orderable: Core.stringLower($th.attr("data-order")) == "true" };
            optionColumn.visible = $this.determineColumnShow(optionColumn, $this.dataFormSearch());

            optionColumn.index = index;
            optionColumn.th = $th;

            if (optionColumn.visible == false) $th.hide();
            else $th.show();

            var widthTh = $th.width();
            if (widthTh > 0 && optionColumn.orderable == true) {
                var widthText = Core.getTextWidth($th.text());
                if ((widthTh - widthText) / 2 < 20) {
                    widthTh = 25 * 2 + widthText;
                    $th.css("width", widthTh);
                }
            }
            //$th.css("width", "");

            if (widthTh > 0) optionColumn.width = widthTh + "px";

            if ($th.attr("data-type") == "button") optionColumn["render"] = createColumnRender.bind($this)($th);
            else if ($th.attr("data-type") == "text-edit") optionColumn["render"] = createColumnRenderTextEdit.bind($this)($th);
            else if ($th.attr("data-type") == "checkbox") optionColumn["render"] = createColumnRenderCheckbox.bind($this)($th);
            else if ($th.attr("data-type") == "radio") optionColumn["render"] = createColumnRenderRadio.bind($this)($th);
            else if ($th.attr("data-format") == "true") optionColumn["render"] = createColumnFormat.bind($this)($th);
            else optionColumn["render"] = createColumFormat_Normal.bind($this)($th);

            if ($th.attr("data-class") != null) optionColumn["className"] = $th.attr("data-class");
            if ($th.attr("data-created-cell") != null) optionColumn["createdCell"] = $this[$th.attr("data-created-cell")];

            return optionColumn;
        }).ToArray();

        this.table.unbind("init.dt");
        this.table.on("init.dt", function ()
        {   
            var container = $($this.table.DataTable().table().container());
            $this.gridContainer = container;
            $($this.table.DataTable().table().header()).prepend(trColspan);

            // Cho cái chọn số lượng bản ghi hiển thị thành chosen cho nó đẹp
            // container.find(".dataTables_length select").chosen({ disable_search: true });
            container.find(".dataTables_length select").select2({ minimumResultsForSearch: Infinity });

            // Tìm bên trái để đặt các buttons
            container.find(".dataTables_length ").addClass("pull-left");
            //container.find(".dataTables_paginate ").addClass("pull-left");

            // var bar = $("<div class='row'><div class='col-xs-12'><div class='table-bar' style='background-color:#f1f2ec;overflow:hidden;padding-bottom:5px;margin-bottom:5px'></div></div></div>");
            var bar = $("<div class='row frm-search-toolbar form-inline' style='margin-bottom: 6px'><div class='col-sm-" + $this.lengthBar + "'><div class='table-bar' style='overflow:hidden;'></div></div></div>");
            divMsg = $("<div class='row'><div class='col-xs-12'><div class='msg-area'></div></div></div>");
            bar.insertBefore(container.find(".toolbar"));
            divMsg.insertAfter(bar);
            bar = bar.find('.table-bar');
            divMsg = divMsg.find(".msg-area");

            if (buttons.length == 0) bar.hide();
            Enumerable.From(buttons).ForEach(function (button) {
                // var abutton = $("<a href='javascript:void(0)' class='pull-left' style='margin-left:10px; margin-top:5px'><i style='color:black' class='" + button.icon + "'></i><b> " + button.text + "</b></a>");
                if (button.bgCss == null || button.bgCss == "") button.bgCss = "bg-olive";

                var abutton = $("<button class='btn " + button.bgCss + " btn-flat btn-sm pull-left' style='margin-right:5px'><span class='" + button.icon + "'></span> " + button.text + "</button>");
                if (button.hotKey != null && button.hotKey != "")
                    abutton.attr("data-hot-key", button.hotKey);

                if (button.func != null) abutton.click(function (e) { e.preventDefault(); button.func(abutton, button, $this); });
                bar.append(abutton);
            });

            // BuildBoxSearchInToolBar
            $this.formSearch.BuildBoxSearchInToolBar({ topInputSearch: $this.topInputSearch, containerSmallSearch: bar.parent().parent() });

            if (opts.paging == false) container.find(".bottom").css("margin-top", "0px");
            else container.find(".bottom").css("margin-top", "10px");
            if ($this.onInitDT != null) $this.onInitDT();

            bindTextEdit.bind($this)();
            withAfterDraw.bind($this)();

            $this.parentTable.find("div.corver-module-grid").remove();

            //
            HotKeys.inst.restart();
        });
    };

    this.getSortInfo = function (ths) {
        var $this = this;

        if (ths == null)
            ths = $this.table.find("thead tr[data-column-real] th");

        var indexSort = null;
        var dirSort = null;
        var fieldSort = $this.res.Data.UserColumn.SortColumn;
        if ($this.res.Data.UserColumn.SortColumn != null) {
            var indexFieldSort = Enumerable.From(ths).Select(function (th, index) {
                var $th = $(th);
                var field = $th.attr("data-field");

                if (field != $this.res.Data.UserColumn.SortColumn) return null;
                var orderable = Core.stringLower($th.attr("data-order")) == "true";
                if (orderable != true) return null;

                return { index: index, field: field };
            }).FirstOrDefault(null, function (t) { return t != null; });

            if (indexFieldSort != null) {
                indexSort = indexFieldSort.index;
                fieldSort = indexFieldSort.field;
            }
        }

        dirSort = $this.res.Data.UserColumn.SortDir != null ? $this.res.Data.UserColumn.SortDir : $this.table.attr("data-order-col-dir");
        if (dirSort == null || dirSort == "") dirSort = "asc";

        if (indexSort == null) {
            indexSort = $this.table.attr("data-order-col");
            if (indexSort != null) indexSort = parseInt(indexSort);
        }

        if (indexSort != null) return { indexSort: indexSort, dirSort: dirSort, fieldSort: fieldSort };
        return null;
    };

    this.scrollTo = function (index, selected) {
        var tr = $(this.table.DataTable().row(index).node());
        var divScroll = this.gridContainer.find(".dataTables_scrollBody");
        var st = tr.position().top; //- divScroll.height() / 2 + tr.height() / 2;

        if (tr.position().top > divScroll.height() / 2)
            st = st - divScroll.height() / 2 + tr.height() / 2; // + divScroll.scrollTop();

        divScroll.animate({ scrollTop: st }, 500, 'swing');
        //divScroll.scrollTop(divScroll.scrollTop() + tr.position().top - divScroll.height() / 2 + tr.height() / 2);

        if (selected == true)
            this.setToogleRowSelected(index, true, false);
    };

    var load = 0;
    this.allDrawn = null;
    var withAfterDraw = function () {
        var $this = this;
        if ($this.afterDraw != null) $this.afterDraw();

        if ($this.table.find("tfoot").length > 0) buildFooterSummary.bind($this)();

        Core.runToCondition(function () {
            var result = $this.tableOptions.fixedColumns == null || $this.gridContainer.find(".dataTable.DTFC_Cloned,.DTFC_ScrollWrapper").length != 0;
            if (result) {
                $this.buildContextAndHover();
                $this.gridContainer.find("table").each(function () {
                    $(this).removeAttr("data-has-be-nice").benice();
                });

                if ($this.allDrawn != null) $this.allDrawn();
            }
            return result;
        }, 100);
    };

    this.buildContextAndHover = function () {
        var $this = this;
        var actions = {};
        if (this.useContextMenuEdit)
            actions.editEntity = { name: Core.getLabel('Chỉnh sửa'), iconClass: 'fa-pencil', onClick: function (row) { $this.Edit(row); }, isEnabled: function (row) { return true; }, isShown: function (row) { return true; } };
        if (this.onCreateActionsContextMenu != null) this.onCreateActionsContextMenu(actions);

        if (Enumerable.From(actions).Count() != 0) {
            var menu = new BootstrapMenu("tr",
                {
                    container: $this.table,
                    fetchElementData: function ($rowElem) {
                        return $this.table.DataTable().row($rowElem).data();
                    },
                    actionsGroups: [],
                    actions: actions
                });
        }

        $this.gridContainer.find("table").find("tbody").find("tr").hover(
            function () {
                var row = $(this).parent().find("tr").index(this);
                $this.gridContainer.find("table").find("tbody").each(function () { $(this).find("tr").removeClass("hover").eq(row).addClass("hover"); });
            },
            function () {
                var row = $(this).parent().find("tr").index(this);
                $this.gridContainer.find("table").find("tbody").each(function () { $(this).find("tr").eq(row).removeClass("hover"); });
            })
            .click(function () {
                var row = $(this).parent().find("tr").index(this);
                $this.setToogleRowSelected(row, false, true);

                // Thiết lập click vào row thì sẽ hiển thị Popup cập nhật luôn

            });
    };

    this.setToogleRowSelected = function (index, allwaysSelected, fireRowClickSelected) {
        var $this = this;
        var trs = [];
        $this.gridContainer.find("table").find("tbody").each(function () {
            Enumerable.From($(this).find("tr")).ForEach(function (tr, i) {
                if (index != i) {
                    $(tr).removeClass("selected");
                }
                else {
                    if (fireRowClickSelected == true) {
                        if ($this.onRowClickSelected != null && !$(tr).hasClass("selected")) trs.push(tr);
                    }

                    if (allwaysSelected == true) $(tr).addClass("selected");
                    else $(tr).toggleClass("selected");
                }
            });
        });
        if (fireRowClickSelected == true) {
            if ($this.onRowClickSelected != null)
                if (trs.length > 0)
                    $this.onRowClickSelected(trs, index);
        }
    };

    this.useContextMenuEdit = false;
    this.onCreateActionsContextMenu = null;

    // Sự kiện khi mỗi lần vẽ table
    var createEventDrawDT = function () {
        var $this = this;
        this.table.unbind("draw.dt");
        this.table.on("draw.dt", function () {
            if (load == 0 || (load == 1 && $this.tableOptions.fixedColumns != null)) {
                load++;
                return;
            }

            bindTextEdit.bind($this)();
            withAfterDraw.bind($this)();
        });
    };
    var buildFooterSummary = function () {
        buildFooterSummaryWhenAuto.bind(this)();
        buildFooterSummaryBy.bind(this)();
    };
    var buildFooterSummaryWhenAuto = function () {
        if (reportSummary != null) return;
        var $this = this;
        $this.table.find("tfoot tr td").each(function () {
            var td = $(this); var data = td.data().tr;
            if (data == null) return;
            if (data.summary) td.html("<b>" + Core.formatMoney(Enumerable.From(currentData).Sum(function (d) { return d[data.field]; })) + "</b>");
        });
        $this.table.find("tfoot tr td").eq(0).html("<b>" + Core.getLabel("Tổng") + "</b>");
    };
    var buildFooterSummaryBy = function () {
        if (reportSummary == null) return;
        var $this = this;
        //var trs = Enumerable.From($this.table.find("tfoot tr")).Select(function (tr, i) { return { tr: tr, i: i }; });
        var trs = Enumerable.From($($this.table.DataTable().table().footer()).find("tr")).Select(function (tr, i) { return { tr: tr, i: i }; });
        var summaries = Enumerable.From(reportSummary).Select(function (summary, i) { return { summary: summary, i: i }; });

        trs.Join(summaries, function (tr) { return tr.i; }, function (summary) { return summary.i; }, function (t, s) {
            var tr = t.tr;
            var summary = s.summary;
            $(tr).find("td").each(function () {
                var td = $(this); var data = td.data().tr;
                if (data == null) return;
                if (data.summary) td.html("<b>" + (summary[data.field] == null ? "" : Core.formatMoney(summary[data.field])) + "</b>");
                else if (data.summaryTitle == "TitleSummary") td.html("<b>" + (summary["TitleSummary"] == null ? Core.getLabel("Tổng") : summary["TitleSummary"]) + "</b>");
            });
        }).Count();
    };
    var createFooterSummary = function () {
        var $this = this;
        var ths = $this.table.find("thead tr[data-column-real] th");
        var thSummaries = $this.table.find("thead tr[data-column-real] th[data-summary]");
        if (thSummaries.length <= 0) return;

        var tfoot = $("<tfoot>");
        $this.table.append(tfoot);

        for (var i = 0; i < $this.totalFooterRow; i++) {
            var tr = $("<tr>"); tfoot.append(tr);
            Enumerable.From(ths).ForEach(function (th) {
                var td = $("<td>"); td.addClass($(th).attr("data-class")); td.data("tr", $(th).data()); tr.append(td);
            });
        }
    };

    // tùy theo cột có định dạng nào thì tạo phương thức tạo ra định dạng đó
    var createColumnFormat = function ($th) {
        switch ($th.attr("data-format-type")) {
            case "date": return createColumFormat_Date.bind(this)($th);
            case "time": return createColumFormat_Time.bind(this)($th);
            case "image": return createColumnFormat_Image.bind(this)($th);
            case "date-time": return createColumFormat_DateTime.bind(this)($th);
            case "span": return createColumFormat_Span.bind(this)($th);
            case "money": return createColumFormat_Money.bind(this)($th);
            case "money2": return createColumFormat_Money2.bind(this)($th);
            default: return createColumFormat_Normal.bind(this)($th);
        }
    };
    var createColumFormat_Normal = function ($th) { return function (data, type, full, meta) { return data == null ? "" : data; }; };
    var createColumFormat_Money = function ($th) { return function (data, type, full, meta) { return data == null ? null : Core.formatMoney(data); }; };
    var createColumFormat_Money2 = function ($th) { return function (data, type, full, meta) { return data == null ? null : Core.formatMoney2(data); }; };

    // tạo phương thức cho cột có định dạng ngày tháng
    var createColumFormat_Date = function ($th) { return function (data, type, full, meta) { return data == null ? "" : Core.formatDate(data); }; }
    var createColumFormat_DateTime = function ($th) { return function (data, type, full, meta) { return data == null ? "" : (Core.formatTime2(data) + " " + Core.formatDate(data)); }; }

    // tạo phương thức cho cột có định dạng ngày giờ
    var createColumFormat_Time = function ($th) { return function (data, type, full, meta) { return Core.formatTime2(data); }; }
    var createColumFormat_Span = function ($th) 
    { 
        var width = parseInt($th.attr("data-span-width").replace("px", ""));
        var css = $th.attr("data-span-class"); 
        return function (data, type, full, meta) 
        { 
            var wByTh = $th.width();
            if (data == null) data = ""; 
            return "<span title='" + $('<div/>').text(data).html() + "' style='width:" + (width > wByTh ? width : (wByTh - 20)) + "px' class='" + css + "'>" + data + "</span>";
            //return "<span title='" + $('<div/>').text(data).html() + "' style='width:" + width + "px' class='" + css + "'>" + data + "</span>";
        }; 
    };
    var createColumnFormat_Image = function ($th) {
        var width = $th.attr("data-image-width"); if (width != undefined && width != null && width != "") width = "width='" + width + "'"; else width = "";
        var height = $th.attr("data-image-height"); if (height != undefined && height != null && height != "") height = "height='" + height + "'"; else height = "";
        var styleClass = $th.attr("data-image-class");
        if (styleClass != undefined && styleClass != null && styleClass != "") styleClass = "class='" + styleClass + "'";
        else styleClass = "";
        return function (data, type, full, meta) { if (data == null || data == "") return ""; return "<img src='" + data + "' " + width + " " + height + " " + styleClass + " />"; };
    };
    // Hàm dùng để khởi tạo phương thức render cho các button nên lưới
    var createColumnRender = function ($th) {
        if ($th.attr("data-text-true") != null) return createColumnRenderButtonTrueFalse.bind(this)($th);
        else if ($th.attr("data-url") != null) return createColumnRenderButtonRedirect.bind(this)($th);
        else return createColumnRender_1.bind(this)($th, false);
    };
    // render button thông thường
    var createColumnRender_1 = function ($th, link) {
        var $this = this;
        return function (data, type, full, meta) {
            var dataIcon = $th.attr("data-icon");
            dataIcon = dataIcon != null ? "<i class='" + $th.attr("data-icon") + "'></i> " : "";

            var href = link ? createUrlForLinkRedirect.bind($this)(full, $th) : "javascript:void(0)";
            var text = data != null ? data : $th.html();
            if ($th.attr("data-format") == "true")
                text = createColumnFormat.bind($this)($th)(data, type, full, meta);

            var target = $th.attr("data-target");
            if (target != null && target != "") target = "target='" + target + "'"; else target = "data-cmd='true'";
            return "<a href='" + href + "' " + target + " data-col='" + meta.col + "'>" + (dataIcon != "" ? dataIcon : text) + "</a>";
        };
    };
    // render button true false
    var createColumnRenderButtonTrueFalse = function ($th) {
        if ($th.attr("data-func") == null) $th.attr("data-func", "UpdateFieldTrueFalse");

        return function (data, type, full, meta) {
            var text = ""; var icon = "";
            if (data) {
                text = $th.attr("data-text-true"); text = getTextTrue(text);
                icon = $th.attr("data-icon-true"); icon = icon == null || icon == "" ? "fas fa-unlock-alt" : icon;
            }
            else {
                text = $th.attr("data-text-false"); text = getTextFalse(text);
                icon = $th.attr("data-icon-false"); icon = icon == null || icon == "" ? "fas fa-lock" : icon;
            }

            var dataIcon = "<i class='" + icon + "'></i> ";
            //return "<a href='javascript:void(0)' data-cmd='true' data-value-field='" + data + "' data-col='" + meta.col + "'>" + dataIcon + text + "</a>";
            return "<a href='javascript:void(0)' data-cmd='true' data-value-field='" + data + "' data-col='" + meta.col + "'>" + dataIcon + "</a>";
        };
    };
    // render button redirect
    var createColumnRenderButtonRedirect = function ($th) {
        var target = $th.attr("data-target");
        if (target == null || target == "") $th.attr("data-func", "ColumnRedirect");
        return createColumnRender_1.bind(this)($th, true);
    };
    // render text edit cập nhật dữ liệu
    var createColumnRenderTextEdit = function ($th) { return function (data, type, full, meta) { return "<textedit data-text-edit-func='" + $th.attr("data-text-edit-func") + "' data-col='" + meta.col + "'>" + (data == null ? "" : data) + "</textedit>"; }; };
    var createColumnRenderCheckbox = function ($th) { return function (data, type, full, meta) { return "<input type='checkbox' data-chk-name='" + $th.attr("data-field") + "' value='" + data + "' data-col='" + meta.col + "' />"; }; };
    var createColumnRenderRadio = function ($th) { return function (data, type, full, meta) { return "<input type='radio' name='" + $th.attr("data-field") + "' value='" + data + "' data-col='" + meta.col + "' />"; }; };
    var getTextTrue = function (text) { return text == null || text == "" ? Core.getLabel("Đóng") : text; };
    var getTextFalse = function (text) { return text == null || text == "" ? Core.getLabel("Mở") : text; };

    // Tìm kiếm xem có form search hay không. Nếu có thì tạo dữ liệu cho 
    // mỗi lần tìm kiếm
    var addFormSearch = function (options) {
        var $this = this;
        var formSearch = getFormSearch.bind($this)();
        var optionSearch = {
            click: function () {
                // Nếu click nút search sẽ kiểm tra xem có sự thay đổi về hiển thị các cột hay không
                // Nếu thay đổi sự hiển thị các cột thì sẽ khởi tạo lưới
                // Chứ không thực hiện bind luôn
                var columns = $this.tableOptions.columns;
                var oldShowColumns = Enumerable.From(columns).Where(function (column) { return column.visible == true; }).ToArray();

                var newShowColumns = [];

                Enumerable.From(columns).ForEach(function (column) {
                    var visible = $this.determineColumnShow(column, $this.dataFormSearch());
                    if (visible) newShowColumns.push(column);
                });

                var needRebuildcolumn = oldShowColumns.length != newShowColumns.length || $this.res.Data.UserColumn.mustRebuild == true;
                if (needRebuildcolumn) {
                    $this.res.Data.UserColumn.mustRebuild = false;

                    // cần phải trả lại các element của form search
                    if ($this.formSearch.restoreInput != null)
                        $this.formSearch.restoreInput();

                    $this.parentTable.empty();
                    $this.parentTable.html(tableContent);

                    $this.init();
                }
                else {
                    $this.bindData();
                    if ($this.onClickSearch != null) $this.onClickSearch();
                }
            }
        };
        formSearch.BuildBoxSearch(optionSearch);
        formSearch.buildAllToogleOption(); // Khởi tạo chức năng chọn theo option => có một select => tùy theo giá trị được chọn mà đóng mở input cần thiết
        $this.formSearch = formSearch;
        $this.formSearch.benice();

        $this.formSearch.find("input[type=text]").onEnter(function () { optionSearch.click(); });
        $this.formSearch.search = function () { optionSearch.click(); };

        if ($this.onInitFormSearch != null) $this.onInitFormSearch();
        Core.buildFormSearchByCompanyId($this.formSearch);

        options.ajax["data"] = function (d) {
            $this.dataSearch = formSearch.length == 0 ? {} : formSearch.BuildBoxSearch({ cmd: "GetValues" }); //formSearch.getValues();
            $this.dataSearch.path = window.location.pathname + window.location.search;
            $.extend(d, $this.dataSearch);
            if ($this.extendDataSearch != null) $.extend(d, $this.extendDataSearch());
        };
    };
    this.bindData = function (pagecurrent) {
        if (this.table == null) return;

        if (pagecurrent == true) {
            var page = this.table.DataTable().page();
            this.table.DataTable().page(page).draw(false);
        }
        else {
            this.table.DataTable().draw();
        }
    };
    var bindCmdInRow = function (row, selector, data, event) {
        var $this = this;
        $(row).find(selector).each(function () {
            $(this).trRow = row;
        });
        $(row).find(selector).on(event, function (e) {
            e.preventDefault();

            var column = $($this.table.DataTable().column(parseInt($(this).attr("data-col"))).header());
            var func = column.attr("data-func");
            if (func == null) return;

            if (column.attr("data-can") != null && Core.stringLower(column.attr("data-can")) != "true") { Core.alert(Core.getLabel("Bạn không có quyền thực hiện chức năng này!")); return; }
            if ($this[func] == null) $this[func] = $this.createFunction(func);

            var acmd = this;
            var confirm = column.attr("data-confirm");
            var autoconfirm = column.attr("data-auto-confirm");
            if (autoconfirm == "true") {
                var textrue = column.attr("data-text-true");
                var textfalse = column.attr("data-text-false");

                confirm = Core.getLabel("Bạn chắc chắn muốn {0} {1}");
                confirm = String.format(confirm, textrue != null || textfalse != null ? Core.stringLower($(acmd).attr("data-value-field") == "true" ? getTextTrue(textrue) : getTextFalse(textfalse)) : Core.stringLower(column.html()), $this.getDataEntityName());
            }

            if (confirm != null) Core.confirm(confirm, function () { $this[func](data, acmd, column, $this.getDataEntityName(), $this.getFieldKey()); });
            else $this[func](data, acmd, column, $this.getDataEntityName(), $this.getFieldKey());
            return false;
        });
    };
    // Bind các element có thể cập nhật được trên lưới
    var bindTextEdit = function () {
        var $this = this;
        $this.table.find("textedit").each(function () {
            var input = $("<input class='form-control input-sm' style='text-align:center; width:100%'>"); input.val($(this).html());
            var tr = $(this).parents("td").addClass("text-edit").parent();
            var data = $this.table.DataTable().row(tr).data();
            var column = $($this.table.DataTable().column(parseInt($(this).attr("data-col"))).header());
            $(this).parent().empty().append(input);
            var func = $(this).attr("data-text-edit-func");
            if (func == null || func == "") func = "UpdateField";

            var field = column.attr("data-field");
            input.attr("data-field", field);
            input.change(function () {
                data[field] = input.val();
                $this.post(func, $.extend(data, { field: field }),
                    // function (res) { $this.showMsgSuccess(Core.getLabel("CAPNHATTHANHCONG")); },
                    function (res) {
                        Core.notify("Cập nhật thành công");
                        var f = $this["callback_" + func];
                        if (f != null) f(res, field);
                    },
                    // function (res) { $this.showMsgError(res.Data.MessageError); });
                    function (res) { Core.notify(res.Data.MessageError, 'error'); });
            });

            var f = $this["inputEdit_" + field + "_Created"];
            if (f != null)
                f(input, column, data);
        });
    };
    this.createFunction = function (func) {
        var $this = this;
        return $this[func] = function (data, target, column, entityName, dataKey) {
            var method = column.attr("data-func-method"); method = method == null ? func : method;
            $this.post(method, data,
                function (res) {
                    $this.bindData();
                    var f = $this["callback_" + method];
                    if (f != null) f(res);
                },
                function (res) { $this.showMsgError(res.Data.MessageError); });
        };
    };
    // Tạo sự kiện sau khi một row đc tạo
    var createEventCreatedRow = function (options) {
        var $this = this;
        options["createdRow"] = function (row, data, dataIndex) {
            if ($this.createdRow != null) $this.createdRow(row, data, dataIndex);
            bindCmdInRow.bind($this)(row, "a[data-cmd=true]", data, "click");
            bindCmdInRow.bind($this)(row, "input[type=checkbox][data-col]", data, "change");
            bindCmdInRow.bind($this)(row, "input[type=radio][data-col]", data, "change");
        };
    };

    this.AddNew = function (data)
    {        
        //this.table.DataTable().column(2).visible(true);
        this.Edit(data, this);
    };
    // Hàm gọi hiển thị form cập nhật
    // extend {buildTitle,hasButtonContinue,afterShowEdit,extendDataSave}
    this.Edit = function (data, target, column, entityName, dataKeyName, extend) {
        if (this.currentPopup != null) return;

        if (extend == null) extend = {};
        if (extend.hasButtonContinue == null) extend.hasButtonContinue = true;

        var $this = this; var popup = this.currentPopup = new Popup();
        var funcTitle = ""; var currentRes = null; // 

        if (entityName == null) entityName = this.getDataEntityName();
        if (dataKeyName == null) dataKeyName = this.getFieldKey();

        var buildTitle = function () {
            if (extend.buildTitle != null) return extend.buildTitle();
            return data == null || data[dataKeyName] == null ? Core.getLabel("Thêm mới") : Core.getLabel("Cập nhật");
        };
        var funcBuildTitle = function () {
            funcTitle = buildTitle();
            popup.loadContentWhenShow = popup.clearWhenHide = true;
            popup.dialogType = $this.dialogEditType;
            popup.title = funcTitle + " " + entityName.toLowerCase();
        };
        var funcSave = function (element, scope, $continue, endSave, beforeSave) {
            var dataKey = {};
            dataKey[dataKeyName] = data == null ? 0 : data[dataKeyName];
            dataKey["FormAdd"] = data == null || data[dataKeyName] == null || data[dataKeyName] == 0;

            var selectorNotGetValues = "[data-form=languages],[data-not-fill=true]";
            if ($this.selectorNotGetValues != "") selectorNotGetValues += ("," + $this.selectorNotGetValues);

            $.extend(dataKey, popup.popupBody.getValues($this.selectorNotGetValues));

            // Lấy dữ liệu cập nhật theo ngôn ngữ
            popup.popupBody.find("[data-form=languages] div[data-form^=entity-language-]").each(function () {
                var dataLanguage = dataKey[$(this).attr("data-form")];
                if (dataLanguage == null) dataLanguage = dataKey[$(this).attr("data-form")] = {};

                $.extend(dataLanguage, $(this).getValues());

                // dataKey[$(this).attr("data-form")] = $(this).getValues(); 
            });

            // Mở rộng tham số nếu có
            if ($this.extendDataSave != null) $.extend(dataKey, $this.extendDataSave(popup));
            if (beforeSave != null) beforeSave(dataKey);
            if (extend.extendDataSave != null) $.extend(dataKey, extend.extendDataSave(popup));

            $this.post("Save", dataKey, function (resSave) {
                var needHidePopup = null;

                var msgSave = Core.getLabel("{0} thành công").format(popup.title);

                if ($continue == "remainFormEdit") {
                    data = {};
                    data[$this.getFieldKey()] = resSave.Data[$this.getFieldKey()];
                    resetForm();
                }
                else if ($continue)
                {
                    if ($this.showMessageWhenSaveEntitySuccess) popup.showMsgSuccess(msgSave);
                    data = $this.newDataWhenSaveContinue == null ? null : $this.newDataWhenSaveContinue(popup, resSave);
                    if ($this.reloadFormWhenContinue)
                    {
                        var dataPost = {}; if ($this.extendDataEdit != null) { $.extend(dataPost, $this.extendDataEdit()); }
                        dataPost["FormAdd"] = dataPost[dataKeyName] == null;
                        popup.hide();
                        $this.Edit(null);
                    }
                    else
                    {
                        popup.popupBody.clearForm();
                        resetForm();
                    }
                }
                else
                {
                    if ($this.showMessageWhenSaveEntitySuccess) $this.showMsgSuccess(msgSave);
                    var hidePopupSaveEntitySuccess = $this.hidePopupSaveEntitySuccess;
                    if (hidePopupSaveEntitySuccess == null) hidePopupSaveEntitySuccess = true;
                    else if (typeof (hidePopupSaveEntitySuccess) == "function") hidePopupSaveEntitySuccess = hidePopupSaveEntitySuccess(popup, msgSave, dataKey, resSave);

                    // Hành động quyết định thực sự có muốn tắt popup hay không
                    decidedHidePopupWhenSaveEntity = $this.decidedHidePopupWhenSaveEntity;
                    if (decidedHidePopupWhenSaveEntity == null) decidedHidePopupWhenSaveEntity = true;
                    else decidedHidePopupWhenSaveEntity = decidedHidePopupWhenSaveEntity.bind($this)(popup, msgSave, dataKey, resSave);

                    needHidePopup = hidePopupSaveEntitySuccess && decidedHidePopupWhenSaveEntity;
                    if (needHidePopup) popup.hide();
                }

                if ($this.table != null) $this.bindData(data == null ? false : true);                
                if ($this.afterSaveEntity != null) $this.afterSaveEntity(popup, msgSave, $continue, dataKey, resSave, data);

                if (needHidePopup != null && !$continue && !needHidePopup) {
                    var tabClick = popup.popupBody.onCTabFindTabNeedUpdateByKeyClicked();
                    if (tabClick == null) {
                        popup.hide();
                        return;
                    }

                    Core.confirm(Core.getLabel("Bạn có muốn cập nhật {0}?").format($(tabClick).clone().children().remove().end().text()), function () {
                        if (data == null) data = {};
                        data[$this.getFieldKey()] = resSave.Data.EntityData[$this.getFieldKey()];
                        popup.resetForm();
                        funcFillForm(resSave);
                        $(tabClick).click();
                    },
                        function () { popup.hide(); });
                }

                if (endSave != null) endSave(resSave, msgSave);
            },
                function (resSave) {
                    popup.showMsgError(resSave.Data.MessageError);
                    element.done();
                });
        };
        var funcFillForm = function (res) {
            // Nếu có fill dữ liệu đa ngôn ngữ
            if (res.Data.EntityLanguages != null) {
                popup.popupBody.find("[data-form=languages]").each(function () {
                    var formLanguages = $(this);

                    Enumerable.From(res.Data.Languages).Join(res.Data.EntityLanguages,
                        function (language) { return language.LanguageId; },
                        function (entityLanguage) { return entityLanguage.LanguageId; },
                        function (language, entityLanguage) { formLanguages.find("[data-form=entity-language-" + language.LanguageId + "]").fillForm(entityLanguage, false); }).Count();
                });
            }

            popup.popupBody.fillForm(res.Data.EntityData, null, "[data-form=languages],[data-not-fill=true]");

            if ($this.fillFormEdit != null) $this.fillFormEdit(popup, res);
        };
        var funcBuildButton = function () {
            if ($this.hasButtonSave)
            {
                var btnSave = { value: "Lưu", hotKey: "Ctrl_s", icon: "fas fa-save", loading: true, cls: "btn btn-primary cmd-save pull-left", func: function (element, scope) { funcSave(element, scope, false); } };
                popup.buttons.push(btnSave);
                if ($this.hasButtonContinue && extend.hasButtonContinue)
                {
                    btnSave.childs = [];
                    btnSave.childs.push({
                        value: "Lưu và thêm mới",
                        hotKey: "Ctrl_f",
                        icon: "fas fa-pen-square",
                        loading: true,
                        cls: "btn btn-warning cmd-save-continue",
                        func: function (element, scope) { funcSave(element, scope, false, function (res) { $this.Edit(null); }); }
                    });
                    btnSave.childs.push({
                        value: "Lưu và sửa tiếp",
                        hotKey: "Ctrl_d",
                        icon: "fas fa-pen-square",
                        loading: true,
                        cls: "btn btn-success cmd-save-continue",
                        func: function (element, scope) { funcSave(element, scope, false, function (res) { $this.Edit(res.Data.EntityData); }); }
                    });
                }
            }
            if ($this.onBuildOnButton != null) $this.onBuildOnButton(popup, currentRes);
        };
        var resetForm = function () {
            funcBuildTitle();
            popup.resetButtonDefault();
            funcBuildButton();
            popup.resetButtons();
            popup.resetTitle();
        };

        popup.save = function (element, scope, $continue, beforeSave, endSave) { funcSave(element, scope, $continue, endSave, beforeSave); };
        popup.buildTitle = function () { return buildTitle(); };
        popup.resetForm = function () { resetForm(); };
        popup.getData = function () { return data; };

        funcBuildTitle();

        var dataPost = {}; if (data != null) $.extend(dataPost, data);
        if ($this.extendDataEdit != null) { $.extend(dataPost, $this.extendDataEdit()); }
        dataPost["FormAdd"] = dataPost[dataKeyName] == null;

        $this.post("Edit", dataPost, function (res) {
            currentRes = res;
            popup.content = res.Data.FormEdit;
            funcBuildButton();
            popup.onAlwaysShow = function () {
                funcFillForm(res);
                if ($this.afterShowFormEdit != null) $this.afterShowFormEdit(popup, res);
                if (extend.afterShowEdit != null) extend.afterShowEdit(popup, res);
            };
            popup.onHide = function () {
                $this.currentPopup = null;
            };
            popup.minimized = $this.dialogMinimized;
            if ($this.onCreatePopupEdit != null) $this.onCreatePopupEdit(popup, res);
            popup.show($this.dialogModal, $this.dialogTop, $this.dialogLeft);
        },
            function (res) {
                if (res.Data != null && res.Data.MessageError != null)
                    Core.alert(res.Data.MessageError);
                $this.currentPopup = null;
            });
        return popup;
    };
    this.getParams = function () { return this.table.DataTable().ajax.params(); };
    // Xuất báo cáo Excel
    this.ExportExcel = function (abutton, button, targetTable) {
        var param = this.ExportExcelHelper(targetTable);
        targetTable.download("ExportExcel", param);
    };

    this.ExportExcelHelper = function (targetTable) {
        var $thistable = targetTable.table.DataTable();
        var param = $thistable.ajax.params();
        param.ReportTitle = targetTable.table.attr("data-entity-name");

        var fields = targetTable.table.find("th[data-field]");
        var columns = targetTable.tableOptions.columns;

        Enumerable.From(columns).ForEach(function (column, index) {
            if (column.visible == false) return;
            //var $th = $(th);
            var $th = column.th;

            var field = $th.attr("data-field");
            var width = $th.attr("data-report-width");
            param["W_" + field] = width == null ? parseInt($th.width() + 30) : parseInt(width);

            if ($th.hasClass("text-right")) param["Align_" + field] = 3;
            else if ($th.hasClass("text-center")) param["Align_" + field] = 2;
            else param["Align_" + field] = 1;

            if ($th.attr("data-summary-title") != null) param["ST_" + field] = $th.attr("data-summary-title");
            if ($th.attr("data-text-false") != null || $th.attr("data-text-true") != null) {
                param["TF_" + field] = true;
                param["TF_" + field + "_False"] = getTextFalse($th.attr("data-text-false"));
                param["TF_" + field + "_True"] = getTextTrue($th.attr("data-text-true"));

                param["DataFormatType_" + field] = "TrueFalse";
            }
            if ($th.attr("data-format-type") != null) param["DataFormatType_" + field] = $th.attr("data-format-type");
        });

        // param.TotalFields = fields.length;
        //param.TotalFields = Enumerable.From(columns).Count(function (column) { return column.visible == true; });
        param.TotalFields = Enumerable.From(columns)
            .Select(function (column, index) { return { c: column, i: index } })
            .Where(function (ci) {
                return ci.c.visible == true;
            })
            .ToString(",", function (ci) { return ci.i; });

        Enumerable.From(targetTable.table.find("[data-row-colspan]")).Select(function (row, index) { Enumerable.From($(row).find("th")).Select(function (th, thIndex) { param["row-span-" + index + "-col-" + thIndex + "-sp-" + $(th).attr("colspan")] = $(th).text(); }).Count(); }).Count();
        return param;
    };

    // Cập nhật trường true, false
    this.UpdateFieldTrueFalse = function (data, target, column) {
        var field = column.attr("data-field");
        data[field] = !($(target).attr("data-value-field") == "true");
        var $this = this;
        var method = column.attr("data-func-method"); method = method == null ? "UpdateField" : method;
        this.post(method, $.extend(data, { field: field }), function (res) {
            var func = createColumnRenderButtonTrueFalse(column);
            var col = $(target).attr("data-col");
            var newa = func(data[field], null, null, { col: col });
            $(target).attr("data-value-field", data[field]);
            $(target).html(newa);
            Core.notify("Cập nhật thành công");
        }, function (res) { $this.showMsgError(res.Data.MessageError); });
    };
    // Column thực hiện redirect
    this.ColumnRedirect = function (data, target, column) { var $this = this; Core.go(createUrlForLinkRedirect.bind($this)(data, column)); }
    var createUrlForLinkRedirect = function (data, column) {
        var fields = column.attr("data-param-url");
        if (fields == null || fields == "") return "";
        var params = Enumerable.From(fields.split(',')).Join(data, function ($) { return $; }, function ($) { return $.Key; }, function (f, k) { return k.Key + '=' + k.Value }).ToString("&");
        var search = column.attr("data-form-search") == "true" ? "&" + Enumerable.From(this.formSearch.BuildBoxSearch({ cmd: "GetValues" })).ToString("&", function (v) { return v.Key + "=" + v.Value; }) : "";
        var url = column.attr("data-url"); url = params == "" ? url : url + "?" + params + search;
        return url;
    };
    // Hiển thị thông báo
    this.showMsg = function (msg, title, timeOut, type) {
        if (divMsg == null) { Core.alert(msg); return; }
        divMsg.empty();
        divMsg.coreAlert(msg, title, timeOut, type);
    };
    this.showMsgSuccess = function (msg) {
        Core.notify(msg, alertType.alertSuccess.type);
        //this.showMsg(msg, null, null, alertType.alertSuccess); 
    };
    this.showMsgError = function (msg) {
        Core.notify(msg, alertType.alertDanger.type);
        //this.showMsg(msg, null, null, alertType.alertDanger); 
    };
    // Hiển thị cấu hình DashBoard
    this.ShowConfigDashBoard = function (abutton, button) {
        var $this = this;
        DashBoard.ShowConfig($(button.th).attr("data-module-url"), "", function () { $this.showMsgSuccess(Core.getLabel("Thêm vào bảng điều khiển thành công")); });
    };

    this.dataFormSearch = function () {
        return this.formSearch == null ? {} : this.formSearch.BuildBoxSearch({ cmd: "GetValues" });
    };
}

CoreDataTable.GridColumnConfig = function (data, area) {
    $.extend(this, new Grid(data, area));

    this.createColumns = function () {
        return [
            { data: "ColumnName", width: "340px", title: "Tên cột", readOnly: true },
            { data: "DataType", width: "60px", title: "Cột", readOnly: true },
            { data: "Stt", width: "50px", title: "Thứ tự", type: "numeric", format: '0,0' },
            { data: "Show", width: "50px", type: "checkbox", className: "htCenter htMiddle", title: "Hiển thị" },
        ];
    };

    this.customerOption = function (options) {
        options.height = 395;
        options.minSpareRows = 0;
    };

    this.afterRenderer = function (td, row, col, prop, value, cellProperties) {
        //if (row == 0) cellProperties.readOnly = true;
        //else
        //{
        var data = cellProperties.instance.getSourceDataAtRow(row);
        if ((data.ColumnField == null || data.ColumnField == "")) {
            switch (col) {
                case 1: $(td).addClass("bg-yellow"); break;
                case 3: cellProperties.readOnly = true; break;
            }
        }
        //}
    };

    this.createContextMenu = function () {
        var $this = this;
        return {
            upToTop: { name: Core.getLabel("Dịch lên trên cùng"), callback: function () { $this.upToTop(); } },
            upOne: { name: Core.getLabel("Dịch lên"), callback: function () { $this.upOne(); } },
            downToBottom: { name: Core.getLabel("Dịch xuống dưới cùng"), callback: function () { $this.downToBottom(); } },
            downOne: { name: Core.getLabel("Dịch xuống"), callback: function () { $this.downOne(); } },
        };
    };

    this.onInit = function () {
        var $this = this;
        Handsontable.hooks.add("afterSelection", function (r, p, r2, p2) {
            Enumerable.From($this.data).ForEach(function (c) { c.selected = false; });
            $this.getCurrentRow().selected = true;
        },
            this.hot);
    };
};