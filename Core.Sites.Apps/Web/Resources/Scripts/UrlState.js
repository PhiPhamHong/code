/// <reference path="../Plugins/linq/linq.min.js" />
/// <reference path="../Plugins/jQuery/jQuery-2.1.3.min.js" />

function App() { }
App.windowActive = true;
App.defaultImageAvatar = "/Web/Resources/Images/avatar160x160.png";

// Phương thức restart khi người dùng thay đổi cấu hình.
App.restart = function()
{
    
}

$(function () 
{

    $(".user-avatar").bind("error", function () {
        var target = $(this);
        var t = target.attr("t");
        if (t == null || t == "") target.attr("t", "1");
        else target.attr("t", eval(t) + 1);
        if (eval(target.attr("t")) >= 2) return;
        target.attr("src", App.defaultImageAvatar);
    });

    $(".user-avatar").each(function () {
        var $this = $(this);
        $this.attr("src", $this.attr("data-src"));
    });


    var avs = new CoreAjax("Login");
    avs.userOverlay = avs.alertWhenFail = false;
    avs.post("LoadNotification", {}, function (res) 
    {
        var notification = res.Data.Notification;
        if (notification == null) return;

        var html = "";
        if (notification.YoutubeId != null && notification.YoutubeId != "")
            html = "<div class=\"loadcontent embed-responsive embed-responsive-16by9\"><iframe class=\"embed-responsive-item\" frameborder=\"0\" scrolling=\"no\" src=\"https://www.youtube.com/embed/" + notification.YoutubeId + "?feature=oembed&autoplay=1\" allowfullscreen ></iframe></div>";
        else if (notification.Avatar != null && notification.Avatar != "")
            html = "<p><a href='" + notification.Link + "' target='_blank'><img class=\"loadcontent\" src=\"" + notification.Avatar + "\"></a></p>";
        else if (notification.Messeger != null && notification.Messeger != "")
            html = "<div class=\"loadcontent\">" + notification.Messeger + "</div>";

        $("#loginload").html(html);
    });

    $("a[data-language-id]").click(function () { Core.changeLanguage($(this).attr("data-language-id")); });
    $(".navbar-custom-menu a.goto-user").click(function () { Core.showPopupModule2("FormGotoUser", "Đăng nhập thay người dùng"); });
    $(".navbar-custom-menu a.config-runtime-user").click(function () { Core.showPopupModule2("FormUserUpdateConfigRuntime", "Cấu hình cá nhân"); });


});

function UrlState()
{
    $.extend(this, new CoreAjax()); var $this = this;
    $this.typeAction = "Web.Controls.Content";           // object thao tác trên server  
    var request = null;                                  // request thực hiện load module khi chuyển trang
    var elementContent = $("#js-page-content .content");            // Vùng nội dung
    $this.getElementContent = function () { return elementContent; }

    $this.elementHeader = $("#js-page-content .content-header");      // Vùng tiêu đề
    var currentModule = null;                            // Lưu trữ đối tượng xử lý module hiện tại
    var currentMenuTop = null;                           // Lưu trữ thông tin menu top hiện tại
    var currentMenuItem = null;                          // Lưu trữ thông tin menu trái hiện tại    

    // Khởi tạo UrlState
    $this.init = function ()
    {
        $.pathchange.init();
        $(window).bind("pathchange", function (e)
        {
            if (request != null) request.abort();
            request = $this.post("LoadModule", {}, function (res) { $this.receive(res, false); }, function (res) 
            { 
                Core.notify(res.Data.MessageError, "error");
                // window.history.back(); 
            });
        });
    }

    //var moduleTabs = [];

    // Nhận dữ liệu mới
    $this.receive = function (res, onload)
    {
        
        // Kết thúc module cũ
        if (currentModule != null)
        {
            currentModule.end(); elementContent.removeAttr("data-has-be-nice");
            currentModule = null;
        }

        // Cập nhật nội dung của module mới
        if (!onload)
        {
            if (res.Data.ModuleContent == null)
            {
                elementContent.html(Core.getLabel("Không tìm thấy nội dung mong muốn"));
                return;
            }
            elementContent.html(res.Data.ModuleContent);
        }
        elementContent.rebuilddiv();        

        // navi header
        
        var navi = $this.elementHeader.find("ol.breadcrumb"); navi.find("li.naviheader").remove();
        bindNaviInHeader(navi, res.Data.CurrentMenuTop, true);
        if (res.Data.CurrentMenuTop.UrlVirtual != res.Data.CurrentMenuItem.UrlVirtual) bindNaviInHeader(navi, res.Data.CurrentMenuItem, false);

        // Lưu trữ thông tin menu của module vừa được tải
        currentMenuTop = res.Data.CurrentMenuTop;
        currentMenuItem = res.Data.CurrentMenuItem;
        document.title = Core.getLabel(currentMenuItem.Title);

        $("[data-top-url]").addClass("collapsed");
        $("[data-top-url=" + currentMenuTop.UrlVirtual + "]").removeClass("collapsed");
        $("[id=" + currentMenuTop.UrlVirtual + "]").addClass("in");
        
        // Thông tin module chính đang tải
        if (res.Data.CurrentMenuItem != null)
        {
            var title = res.Data.PageTitle != null && res.Data.PageTitle != "" ? res.Data.PageTitle : res.Data.CurrentMenuItem.Title;
            $this.elementHeader.find("h1").html("<i class='" + res.Data.CurrentMenuItem.Icon + "'></i> " + Core.getLabel(title));  // Tiêu đề

            // Thực hiện tải các js mà module này cần.
            // Sau khi tải js xong sẽ tạo đối tượng quản lý module vừa tải
            Core.getScriptsNeedLoad(res.Data.Scripts, function ()
            {   
                if(onload)
                {
                    try { if (Notification && Notification.permission !== "granted") Notification.requestPermission(); } catch (e) { };
                    setTimeout(function () { Hub.app.start(); }, 1);
                }

                eval("if(typeof(" + res.Data.CurrentMenuItem.Module + ") != 'undefined') { currentModule = new " + res.Data.CurrentMenuItem.Module + "(); currentModule.module = res.Data.CurrentMenuItem.Module; currentModule.main = $this; currentModule.res = res; currentModule.init(res); }");
                    
                HotKeys.inst.restart();
                maintainState();

                if (!onload) Hub.app.sendUserState();
            });
        }

        //elementContent.benice();
        maintainState();
    }

    // Start => Khởi tạo và nhận dữ liệu lần đầu khi tải module
    $this.start = function (res)
    {
        
        $this.init();
        $this.receive(res, true);

        if (res.Data.NeedShowInvoice)
            Invoice.showAndReload();

        $(window).blur(function () { App.windowActive = false; Hub.app.sendUserState(); });
        $(window).focusout(function () { App.windowActive = false; Hub.app.sendUserState(); });
        $(window).focus(function () { App.windowActive = true; Hub.app.sendUserState(); });
        $(document).blur(function () { App.windowActive = false; Hub.app.sendUserState(); });
        $(document).focusout(function () { App.windowActive = false; Hub.app.sendUserState(); });
        $(document).focus(function () { App.windowActive = true; Hub.app.sendUserState(); });
    }

    // binding navigator ở header content
    var bindNaviInHeader = function (navi, menuItem, first)
    {
        
        if (menuItem != null)
        {
            if(!first) navi.append("<li class='naviheader'>»</li>");
            navi.append('<li class="naviheader"><a href="' + menuItem.Url + '" data-state="true"><i class="' + menuItem.Icon + '"></i> ' + Core.getLabel(menuItem.Title) + '</a></li>');
        }
    }

    // maintain url
    var maintainState = function () { Core.maintainState("body"); }
}
function ModuleBase()
{
    this.main = null;
    this.init = function (res) { }
    this.end = function () { }

    this.msgError = function(element, msg, timeOut)
    {
        element.coreAlert(msg, null, timeOut, alertType.alertDanger);
    }
    this.getMain = function()
    {
        if (this.main == null) return null;
        return this.main.getElementContent == undefined ? this.main : this.main.getElementContent();
    }
    this.find = function (selector) { return this.getMain().find(selector); };
    this.moduleType = "unknown";
}
function ModuleNormal()
{
    $.extend(this, new ModuleBase());
    $.extend(this, new CoreAjax());
    this.res = null;

    this.init = function(res)
    {
        this.res = res;
        this.typeAction = res.Data.ModuleTypeAction;
        this.assembly = res.Data.ModuleProject;
        this.onInit(res);
    }

    this.onInit = function(res) { }
    this.moduleType = "Normal";
}
function ModuleGrid(option)
{
    $.extend(this, new ModuleBase());
    this.typeAction = "";
    this.table = null;

    // Mỗi một hãng có xử lý riêng thì sẽ khởi tạo xử lý riêng
    // Rồi tùy theo sự kiện ở đâu mà sẽ tạo method riêng rẽ cho từng công ty
    this.formEdit = "";

    this.init = function(res)
    {
        this.table = new CoreDataTable();
        this.table.res = res;

        if (this.typeAction != "") 
        {
            this.table.typeAction = this.typeAction;
            this.table.assembly = this.assembly;
        }
        else
        {
            this.table.typeAction = this.table.res.Data.ModuleTypeAction;
            this.table.assembly = this.table.res.Data.ModuleProject;
        }

        this.table.main = this.getMain();

        var fieldKey = this.table.getFieldKey();
        var entityName = this.table.getDataEntityName();

        if (fieldKey == null) this.table.getFieldKey = function () { return res.Data.TableFieldKeyName; };
        if (entityName == null) this.table.getDataEntityName = function () { return res.Data.TableEntityName; };
        this.beforeInit(res);
        this.mainBeforeInit(res);
        
        buildButtons.bind(this)();
        this.beforeInitGrid(this.table);
        this.table.cellColorBg = function (td, cellData, data, row, col) {
            $(td).css("background-color", data.ColorBg).css("color", data.ColorText);
        };
        if (option == null) option = { };
        if (this.table.main != null) this.table.init(option);
    }
    this.end = function()
    {
        if (this.table != null)
            this.table.end();
    }

    this.beforeInit = function (res) { };
    this.beforeInitGrid = function(table) { }
    Core.addOnMethod(this, "beforeInitGrid", "table");

    this.moduleType = "table";

    this.bodyFormEdit = function(popup)
    {
        return popup.popupBody;
    }

    this.mainBeforeInit = function (res) 
    {
        var $this = this;
        this.table.afterShowFormEdit = function (popup, res) 
        {
            var edit = $this.getFormEdit(res);
            if (edit != null && edit != "") 
            {
                eval("var formEdit = " + edit + ";");
                if (formEdit != null && formEdit != undefined)
                {
                    var cp = new formEdit($this, res, $this.bodyFormEdit(popup));
                    cp.popup = popup;
                    cp.module = $this;
                    if (cp.start != undefined && cp.start != null && typeof (cp.start) == "function") cp.start();
                    popup.controller = cp;
                }
            }
            $this.afterShowFormEdit(popup, res);
        };
        this.onBeforeInitGrid(function (table) 
        { 
            if ($this.formEdit != "")
                table.extendDataSave = function (popup) { if (popup.controller != null && popup.controller.extendDataSave != null) return popup.controller.extendDataSave(); return {}; };
        });
        this.onBeforeInitGrid(function (table) 
        {
            var $this = this;
            table.afterSaveEntity = function (popup, msg, $continue, dataKey, res, data) { $this.afterSaveEntity(popup, msg, $continue, dataKey, res, data); };
        });
    };

    this.getFormEdit = function (res) { return this.formEdit; }
    this.afterShowFormEdit = function (popup, res) { };
    this.afterSaveEntity = function (popup, msg, $continue, dataKey, res, data) { };

    var buildButtons = function()
    {
        var $this = this;
        $this.onBeforeInitGrid(function (table) 
        {
            var buttons = null;
            var getButtons = function (res) 
            {
                if (buttons != null) return buttons;
                buttons = $this.createButtons(res);
                Enumerable.From(buttons).ForEach(function (b) { b.main = $this });
                return buttons;
            }
            table.onBuildOnButton = function (popup, res) 
            { 
                Enumerable.From(getButtons(res)).ForEach(function (b) { if (b.condition(popup, res)) popup.buttons.push(b.build(popup, res)); }); 
            };
        });
    }
    this.createButtons = function (res) { return []; };
}
function ModuleGridListSystem(options)
{
    if (options == null) options = { scrollY: $(window).height() - 340 };

    $.extend(this, new ModuleGrid(options));

    this.onBeforeInitGrid(function (table)
    {
        table.createdCell = function (td, cellData, rowData, row, co)
        {
            if (rowData.IsSystem) $(td).addClass("sh-green");
        };
    });
}