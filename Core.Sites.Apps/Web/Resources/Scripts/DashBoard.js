/// <reference path="../Plugins/linq/linq.min.js" />

function DashBoard()
{
    var dashboardControls = { };
    var mainBoard = null;
    this.tabId = 0;
    this.load = function(main)
    {
        if (!(Core.isMobile() || Core.isTablet()))
        {
            //Make the dashboard widgets sortable Using jquery UI
            main.find("[data-dashboard-sort=true]").sortable({ placeholder: "sort-highlight", handle: ".box-header,.core-box-small", connectWith: "[data-dashboard-sort=true]", forcePlaceholderSize: true, zIndex: 999999 });
            main.find("[data-dashboard-sort=true]").on("sortreceive", function (event, ui) {
                var newDbId = ui.item.attr("data-main");
                var oldDb = $(this).find("[data-main][data-main!='" + newDbId + "']");
                ui.sender.append(oldDb);

                // Hoán đổi độ rộng giữa 2 dashboard
                var thisCol = $(this).attr("data-col");
                var uiSenderCol = ui.sender.attr("data-col");
                updateCol($(this), uiSenderCol);
                updateCol(ui.sender, thisCol);

                // Cập nhật cấu hình vị trí 2 dashboard vừa thay đổi
                DashBoard.ajaxMain().post("SwithDashBoard", { db1: newDbId, db2: oldDb.attr("data-main") });
                updateGrid();
            });
        }
        var $this = this;
        (mainBoard = main).find("[data-main]").each(function () { loadInMain.bind($this)($(this)); });
    }

    this.onDashBoardChangeTab = null;

    // Thực hiện làm mới lại dashboard
    var reload = function(dbId, newConfig)
    {
        var $this = this;
        var main = mainBoard.find("[data-main=" + dbId + "]");

        if(newConfig != null)
        {
            if((newConfig.TabId + "") != ($this.tabId + ""))
            {
                main.remove();
                updateGrid();
                if ($this.onDashBoardChangeTab != null) $this.onDashBoardChangeTab(newConfig.TabId);
                return;
            }
        }

        DashBoard.ajaxMain().post("LoadBoxDashBoard", { db: dbId }, function (res)
        {
            if (dashboardControls[dbId] != null)
                clearDashBoard(dashboardControls[dbId]);

            main.html(res.Data.BoxTypeHtml);
            updateCol(main.parent(), res.Data.DashBoardItem.Col);
            loadInMain.bind($this)(main);
        });
    }

    this.f5 = function () { updateGrid(); };

    var timeUpdateGrid = null;
    var updateGrid = function()
    {
        if (timeUpdateGrid != null) clearTimeout(timeUpdateGrid);
        timeUpdateGrid = setTimeout(function () 
        {
            if (!(Core.isMobile() || Core.isTablet()))
                mainBoard.find(".connectedSortable").masonry({ itemSelector: '[data-dashboard-sort=true]', columnWidth: ".col-lg-1", percentPosition: true });
            timeUpdateGrid = null;
        }, 500);
    }
    var updateCol = function(element, newCol)
    {
        var oldColClass = "col-lg-" + element.attr("data-col");
        element.removeClass(oldColClass).addClass("col-lg-" + newCol).attr("data-col", newCol);
    }
    var loadInMain = function(main)
    {   
        var $this = this;
        var dbId = main.attr("data-main");
        var control = { };

        dashboardControls[dbId] = control;

        control.request = DashBoard.ajaxMain().post("LoadDashBoard", { db: dbId }, function (res)
        {
            main.find("[data-box-dashboard=content]").html(res.Data.Html);
            var js = "if(typeof({0}) != 'undefined')";
            js += "   {";
            js += "         control.dashboard = new {0}();";
            js += "         control.dashboard.center = $this;";
            js += "         control.dashboard.main = main;";
            js += "         control.dashboard.init(res);";
            js += "   }";
            eval(String.format(js, res.Data.DashBoardMain));
            main.find("[data-box-dashboard=content]").maintainState();
            updateGrid();
        });

        // Thiết lập toolbox
        main.find("[data-db-cmd=config]").attr("data-original-title", Core.getLabel("Thiết lập cấu hình")).tooltip().click(function () { DashBoard.ShowConfig(main.attr("data-main-url"), dbId, function (res) { reload.bind($this)(dbId, res.Data.Config); }); });
        main.find("[data-db-cmd=minus]").attr("data-original-title", Core.getLabel("Ẩn/hiện")).tooltip().click(function () { Core.alert("Đang làm"); });
        main.find("[data-db-cmd=remove]").attr("data-original-title", Core.getLabel("Xóa")).tooltip().click(function () { DashBoard.Delete(dbId, function () { main.remove(); updateGrid(); }); });
        main.find("[data-db-cmd=reload]").attr("data-original-title", Core.getLabel("Làm mới")).tooltip().click(function () { reload.bind($this)(dbId); });;
    }
    this.end = function()
    {
        Enumerable.From(dashboardControls).ForEach(function (dc) { clearDashBoard(dc.Value); });
    }
    var clearDashBoard = function(db)
    {
        db.request.abort();
        if (db.dashboard != null)
            db.dashboard.end();
    }
}

DashBoard.ajaxConfig = function()
{
    var ajax = new CoreAjax();
    ajax.typeAction = "Web.Controls.DashBoards.DashBoardMainConfig";
    return ajax;
}
DashBoard.ajaxMain = function()
{
    var ajax = new CoreAjax();
    ajax.typeAction = "Web.Controls.DashBoards.DashBoardMain";
    ajax.userOverlay = false;
    ajax.alertWhenFail = false;
    return ajax;
}
DashBoard.ShowConfig = function(moduleUrl, id, updated)
{
    var data = { moduleUrl: moduleUrl, db : id };
    var popup = new Popup();
    popup.title = Core.getLabel("Cấu hình bảng điều khiển");
    popup.control = "Core.Sites.Apps.Web.Controls.DashBoards.DashBoardMainConfig,Core.Sites.Apps";
    popup.data = data;
    popup.loadContentWhenShow = popup.clearWhenHide = true;
    popup.buttons.push({ value: "Cập nhật", hotKey: "Ctrl_s", icon: "fas fa-save", cls: "btn btn-primary pull-left", func: function (element, scope)
    {
        DashBoard.ajaxConfig().post("Save", $.extend(data, popup.popupBody.getValues()),
            function (res)
            {
                popup.hide();
                if (updated != null) updated(res);
            },
            function (res) { popup.showMsgError(res.Data.MessageError); });
    }});

    var resData = { };
    popup.afterLoadControl = function (res) { resData = res; };
    popup.onAlwaysShow = function ()
    {
        popup.popupBody.fillForm(resData.Data.ModelConfig, false);
        popup.popupBody.fillForm(resData.Data.CommonConfig, true);
        Core.getScriptsNeedLoad(resData.Data.Scripts, function ()
        {
            eval(String.format("if(typeof({0}) != 'undefined') { new {0}().init(resData, popup.popupBody); }", resData.Data.ControlDashBoardConfig));
        });
    };
    popup.show();
}
DashBoard.Delete = function(id, deleted)
{
    Core.confirm("Bạn chắc chắn muốn xóa theo dõi này?", function ()
    {
        DashBoard.ajaxMain().post("DeleteDashBoard", { db: id }, function () { if (deleted != null) deleted(); });
    });
}

function DashBoardControl()
{
    $.extend(this, new CoreAjax()); 
    this.init = function (res) { }
    this.end = function(){ }
    this.userOverlay = false;
    this.alertWhenFail = false;
}
function DashBoardControlTemplateOption()
{
    $.extend(this, new DashBoardControl());
    this.prefix = "DashBoard";
    this.option = "OptionReportType";

    var dashboard = null;

    this.init = function(res)
    {
        this.typeAction = res.Data.ModuleTypeAction;
        this.assembly = res.Data.ModuleProject;
        eval("dashboard = new "+ this.prefix +"_" + res.Data.DashBoardConfig[this.option] + "();");
        $.extend(dashboard, new CoreAjax());
        dashboard.target = this;
        dashboard.alertWhenFail = false;
        dashboard.userOverlay = false;
        dashboard.typeAction = res.Data.DashBoardModule;
        dashboard.assembly = res.Data.DashBoardModuleProject;
        dashboard.config = res.Data.DashBoardConfig;
        dashboard.init(res);
    }

    this.end = function ()
    {
        if (dashboard != null && dashboard.end != null) dashboard.end();
    }
}
function DashBoardModuleTimer()
{
    this.findContentToFill = function() { return this.target.main.find("[data-form=content]"); }
    this.createContent = function (res) { return res.Data.Total; }
    this.method = "InitData";
    this.fillData = function(element, content, res) { element.html(content); }
    this.init = function(res)
    {
        var $this = this;
        setDataToView.bind($this)(res);

        var data = $this.config; if (data == null) data = {};
        this.doPostTimer($this.method, data, 3600000, function (res) { setDataToView.bind($this)(res); });
    }
    this.end = function() { this.clearThreadPOST(this.method); }
    var setDataToView = function(res)
    {
        var element = this.findContentToFill();
        var content = this.createContent(res);
        this.fillData(element, content, res);
    }
}
function DashBoardControlOptionConfig()
{    
    this.nameOption = "OptionReportType";
    this.init = function(res, popupBody)
    {
        popupBody.buildToogleOption(this.nameOption);
        this.onInit();
    }

    this.onInit = function() { }
}

function DashBoardModuleList()
{
    this.moduleList = "";
    this.init = function (res) 
    {
        var $this = this;
        this.target.main.find("[data-form=content]").loadModule($this.moduleList, function (rs, module) 
        {
            module.onBeforeInitGrid(function (table) { table.extendDataSearch = function () { return $this.config; }; });
        }, null, null, false, false);
    }
}


DashBoard.ControlByOption = function () {
    this.method = "InitData";                       // Tên phương thức của trên Server của DashBoard để load dữ liệu
    this.fillWhenInit = true;

    this.init = function (res) {
        var $this = this;
        $this.target.main.fillForm(res.Data);
        $this.target.main.find("select[name]").change(function () { $this.reload(); });
        $this.target.main.attr("data-has-be-nice", false);
        $this.target.main.benice();

        if (this.fillWhenInit) this.doBindData(res);
    }
    this.reload = function () {
        var $this = this;
        var data = $this.config;
        if (data == null) data = {};
        $.extend(data, $this.target.main.getValues());
        $this.post($this.method, data, function (res) { $this.doBindData(res); });
    };

    this.doBindData = function (res) {
        this.beforeBindData(res);
        this.bindData(res);
    }

    this.beforeBindData = function (res) { }
    this.bindData = function (res) { }
}