/// <reference path="../Plugins/linq/linq.min.js" />
// https://craftpip.github.io/jquery-confirm/#ajaxloading
// www.plumtheory.com/demos/document-viewer/pdf.html
// https://printjs.crabbly.com/
function Core() { }
Core.formatString = function (content, args) {
    if (!Array.isArray(args)) args = [args];

    for (var i = 0; i < args.length; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        content = content.replace(reg, args[i]);
    }
    return content;
}

Array.prototype.insert = function (index, item) { this.splice(index, 0, item); };
String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};
String.prototype.format = function () {
    var content = this;
    for (var i = 0; i < arguments.length; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        content = content.replace(reg, arguments[i]);
    }
    return content;
};

String.prototype.splice = function (idx, s) { return (this.slice(0, idx) + s + this.slice(idx)); };
String.prototype.toNoSign = function () {
    var str = this;
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    str = str.replace(/Đ/g, "D");
    return str;
};
String.prototype.firstLetterUpper = function () {
    return this.replace(/\b[a-z]/g, function (letter) { return letter.toUpperCase(); });
}
Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
};
Date.prototype.addMinutes = function (minutes) {
    var date = new Date(this.valueOf());
    date.setMinutes(date.getMinutes() + minutes);
    return date;
};
// Extend the default Number object with a formatMoney() method:
// usage: someVar.formatMoney(decimalPlaces, symbol, thousandsSeparator, decimalSeparator)
// defaults: (2, "$", ",", ".")
Number.prototype.formatMoney = function (places, symbol, thousand, decimal) {
    places = !isNaN(places = Math.abs(places)) ? places : 2;
    symbol = symbol !== undefined ? symbol : "";
    thousand = thousand || ",";
    decimal = decimal || ".";
    var number = this,
        negative = number < 0 ? "-" : "",
        i = parseInt(number = Math.abs(+number || 0).toFixed(places), 10) + "",
        j = (j = i.length) > 3 ? j % 3 : 0;
    return symbol + negative + (j ? i.substr(0, j) + thousand : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousand) + (places ? decimal + Math.abs(number - i).toFixed(places).slice(2) : "");
};

function CoreSession() { };
CoreSession.UserSession = function () {
    this.setCenterNotifycationProvider = function (center) { };
    this.gotoUrlListNotificationOfUser = function () { };
    this.cookieUser = function () { return ""; };
};
CoreSession.UserSession.Account = function () {
    $.extend(this, new CoreSession.UserSession());
    this.setCenterNotifycationProvider = function (center) { $.extend(center, new CoreAjax("Web.Modules.FormNotification.ManageNotifications")); };
    this.gotoUrlListNotificationOfUser = function () { Core.go2("thong-bao-cua-toi"); };
    this.cookieUser = function () { return "Core.Sites.Libraries.Business.AccountSession"; };
};

if (typeof (sessionType) != "undefined") {
    switch (sessionType) {
        default: Core.userSession = new CoreSession.UserSession.Account(); break;
    }
}
Core.userSession = new CoreSession.UserSession.Account();
Core.Icon = {};
Core.Icon.warning = "/Web/Resources/Images/warning.gif";
Core.Icon.alert = "/Web/Resources/Images/alert.gif";

// Thực hiện nhận thông báo từ server trả về
Core.receiverMessage = function (res) { eval(res.JavaScript); };
Core.isNull = function (obj) { return obj === undefined || obj === null; };
Core.goto = function (selector, delta) {
    if (delta == null) delta = 0;
    if (typeof (selector) == "string") selector = $(selector);
    $('html,body').animate({ scrollTop: selector.offset().top + delta + "px" }, 500);
};
Core.logout = function () {
    var ajax = new CoreAjax();
    ajax.typeAction = "Main";
    ajax.post("Logout");
};
Core.changeLanguage = function (languageId) {
    var ajax = new CoreAjax();
    ajax.typeAction = "Main";
    ajax.userOverlay = ajax.alertWhenFail = false;
    ajax.post("ChangeLanguage", { LanguageId: languageId }, function (res) {
        window.location.reload();
    });
};

Core.go = function (href) { $.pathchange.changeTo(href); };
Core.go2 = function (url) {
    Core.go(url + "." + $("li[data-top-url] a").attr("href").split('.')[1]);
};
Core.stringLower = function (str) { return str == null ? "" : str.toLowerCase(); };

Core.formatMoney = function (data) { return Core.formatMoneyHelper(data, 2, 0); };
Core.formatMoney2 = function (data) { return Core.formatMoneyHelper(data, 2, 2); };
Core.formatMoneyHelper = function (data, p1, p2) {
    if (data == null) return "";
    if (typeof (data) == "string") data = parseFloat(data);
    if (data % 1 != 0) return data.formatMoney(p1);
    return data.formatMoney(p2);
};
Core.formatDate = function (data) {
    if (data == null || data == "") return "";
    if (data.length == 10) return data;
    return data.substr(8, 2) + "/" + data.substr(5, 2) + "/" + data.substr(0, 4);
};
Core.formatFileSize = function (bytes) {
    if (bytes == 0) { return "0.00 B"; }
    var e = Math.floor(Math.log(bytes) / Math.log(1024));
    return (bytes / Math.pow(1024, e)).toFixed(2) + ' ' + ' KMGTP'.charAt(e) + 'B';
};

// data có dạng 2015-05-12T00:00:00
Core.getDate = function (data) {
    if (data == null) return null;
    data = data.replace(/-/g, "/").replace("T", "/").replace(/:/g, "/").split('/');
    var year = parseInt(data[0]);
    var month = parseInt(data[1]);
    var day = parseInt(data[2]);
    var hours = parseInt(data[3]);
    var minutes = parseInt(data[4]);
    var seconds = parseInt(data[5]);
    return new Date(year, month - 1, day, hours, minutes, seconds);
};
Core.getDateFormatVN = function (date) {
    if (date == undefined || date == "" || date == null) return null;
    var date = date.split('/'); if (date.length < 3) return null;
    var year = date[2].split(' ')[0];
    return new Date(parseInt(year), parseInt(date[1]) - 1, parseInt(date[0]));
};
Core.getYearMonthDay = function (date) {
    if (date == undefined || date == "" || date == null) return null;
    var date = date.split('/'); if (date.length < 3) return null;
    return date[2] + "/" + date[1] + "/" + date[0];
};
Core.getDayOfDate = function (date) {
    date = Core.getDateFormatVN(date);
    switch (date.getDay()) {
        case 0: return Core.getLabel("Chủ nhật");
        case 1: return Core.getLabel("Thứ 2");
        case 2: return Core.getLabel("Thứ 3");
        case 3: return Core.getLabel("Thứ 4");
        case 4: return Core.getLabel("Thứ 5");
        case 5: return Core.getLabel("Thứ 6");
        case 6: return Core.getLabel("Thứ 7");
    }
};

Core.formatTime = function (data) { return data; };
Core.formatTime2 = function (data) {
    if (data == null) return null;
    if (typeof (data) == "string") data = Core.getDate(data);
    return String.format("{0}:{1}", data.getHours() < 10 ? "0" + data.getHours() : data.getHours(), data.getMinutes() < 10 ? "0" + data.getMinutes() : data.getMinutes());
};
Core.formatDate2 = function (data) {
    if (typeof (data) == "string") data = Core.getDate(data);
    return String.format("{0}/{1}/{2} {3}:{4}",
        data.getDate() < 10 ? "0" + data.getDate() : data.getDate(),
        (data.getMonth() + 1) < 10 ? "0" + (data.getMonth() + 1) : (data.getMonth() + 1),
        data.getFullYear(),
        data.getHours() < 10 ? "0" + data.getHours() : data.getHours(),
        data.getMinutes() < 10 ? "0" + data.getMinutes() : data.getMinutes());
};
Core.formatDate3 = function (data) {
    if (data == null || data == "") return "";

    if (typeof (data) == "string") data = Core.getDate(data);
    return String.format("{0}/{1}/{2}",
        data.getDate() < 10 ? "0" + data.getDate() : data.getDate(),
        (data.getMonth() + 1) < 10 ? "0" + (data.getMonth() + 1) : (data.getMonth() + 1),
        data.getFullYear());
};
Core.formatForCountDown = function (time) {
    var strTimeFinal = String.format("{0}/{1}/{2} {3}:{4}:{5}",
        (time.getMonth() + 1) < 10 ? "0" + (time.getMonth() + 1) : (time.getMonth() + 1),
        time.getDate() < 10 ? "0" + time.getDate() : time.getDate(),
        time.getFullYear(),
        time.getHours() < 10 ? "0" + time.getHours() : time.getHours(),
        time.getMinutes() < 10 ? "0" + time.getMinutes() : time.getMinutes(),
        time.getSeconds() < 10 ? "0" + time.getSeconds() : time.getSeconds());

    return strTimeFinal;
};
Core.formatDateWithSeconds = function (data) {
    if (typeof (data) == "string") data = Core.getDate(data);
    return String.format("{0}/{1}/{2} {3}:{4}:{5}",
        data.getDate() < 10 ? "0" + data.getDate() : data.getDate(),
        (data.getMonth() + 1) < 10 ? "0" + (data.getMonth() + 1) : (data.getMonth() + 1),
        data.getFullYear(),
        data.getHours() < 10 ? "0" + data.getHours() : data.getHours(),
        data.getMinutes() < 10 ? "0" + data.getMinutes() : data.getMinutes(),
        data.getSeconds() < 10 ? "0" + data.getSeconds() : data.getSeconds());
};

// Chạy một cách tuần tự
Core.loadScripts = function (scripts, onfinish) {
    var length = scripts.length;
    if (length == 0) {
        onfinish();
        return;
    }
    var fload = function (i) {
        $.cachedScript(scripts[i], {
            success: function (js, status) {
                i++;
                if (i >= length) onfinish();
                else fload(i);
            }
        });
    };
    fload(0);
};
Core.cacheScripts = [];
Core.getScriptsNeedLoad = function (scripts, callback) {
    var paths = Enumerable.From(scripts).GroupJoin(Core.cacheScripts, function (s) { return s.Src; }, function ($) { return $; },
        function (s, cs) { return { s: s, cs: cs }; })
        .Where(function ($) { return $.cs.Count() == 0; }).Select(function ($) { return $.s.Src; }).Distinct().ToArray();

    Core.loadScripts(paths, function () {
        Core.cacheScripts = Enumerable.From(Core.cacheScripts).Concat(paths).ToArray();
        callback();
    });
};

// Hiển thị thông báo
Core.alert = function (content, formats, type) {
    if (type == null) type = "warning";
    Core.notify(content, formats, type);
};
Core.alert2 = function (content, type) {
    if (type == null) type = "warning";
    Core.notify2(content, type);
};
Core.confirm = function (content, formats, yes, no) { CoreAlertConfirm(content, formats, yes, no); };

Core.notify = function (content, formats, type, time, target) {
    content = Core.getLabel(content);
    if (formats != null) content = Core.formatString(content, formats);
    return new PNotify({ target: target, text: content, type: (type == null || type == '' ? 'success' : type), delay: (time == null ? 1000 : time) });
};
Core.notify2 = function (content, type, time, target) {
    return new PNotify({ target: target, text: content, type: (type == null || type == '' ? 'success' : type), delay: (time == null ? 1000 : time) });
};

Core.popup = function (url, event, width, height) {
    var w = width == null ? 800 : width;
    var h = height == null ? 600 : height;
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var windowName = "popUp";
    var params = "width=" + w + ",height=" + h + ",top=20,left=" + left;
    var newwin = window.open(url, windowName, params);
    //if (event)
    //    event.preventDefault();
    //if (window.focus) { newwin.focus() }
    newwin.focus();
    return newwin;
};
Core.fileManagerCallback = null;
Core.showFiles = function (type, multi, callback) {
    Core.fileManagerCallback = function (folder, files) {
        callback(folder, files);
        Core.fileManagerCallback = null;
    };
    Core.popup("/Web/Resources/ckfinder/filemanager.aspx?type=" + (type == null || type == "" ? "Images" : type) + "&multi=" + multi);
};
Core.subDateTotalMinutes = function (date2, date1) {
    return Core.subDate(date2, date1).totalMins;
};
Core.subDate = function (date2, date1) {
    if (date2 == null || date1 == null) return null;

    var diff = date2.getTime() - date1.getTime();

    var days = Math.floor(diff / (1000 * 60 * 60 * 24));
    diff -= days * (1000 * 60 * 60 * 24);

    var hours = Math.floor(diff / (1000 * 60 * 60));
    diff -= hours * (1000 * 60 * 60);

    var mins = Math.floor(diff / (1000 * 60));
    diff -= mins * (1000 * 60);

    var seconds = Math.floor(diff / (1000));
    diff -= seconds * (1000);

    var totalMins = days * 24 * 60 + hours * 60 + mins + seconds / 60;
    return { days: days, hours: hours, mins: mins, seconds: seconds, totalMins: totalMins };
};
Core.formatSubDate = function (date2, date1) {
    var result = Core.subDate(date2, date1);
    var display = [];
    if (result.days != 0) display.push(Core.getLabel("{0} ngày").format(result.days));
    if (result.hours != 0) display.push(Core.getLabel("{0} giờ").format(result.hours));
    if (result.mins != 0) display.push(Core.getLabel("{0} phút").format(result.mins));
    return { display: Enumerable.From(display).ToString(" "), result: result };
};
Core.getSizeName = function () {
    var screen_size = '', screen_w = jQuery(window).width();
    if (screen_w > 1170) screen_size = "desktop_wide";
    else if (screen_w > 960 && screen_w <= 1169) screen_size = "desktop";
    else if (screen_w >= 768 && screen_w <= 959) screen_size = "tablet";
    else if (screen_w > 300 && screen_w <= 767) screen_size = "mobile";
    else if (screen_w <= 300) screen_size = "mobile_portrait";
    return screen_size;
};
Core.isMobile = function () {
    var screen_size = Core.getSizeName();
    return screen_size == "mobile" || screen_size == "mobile_portrait";
};
Core.isTablet = function () { return Core.getSizeName() == "tablet"; }
$.fn.maintainState = function () {
    this.find("a[data-state]").removeAttr("data-state").click(function (e) {
        e.preventDefault(); Core.go($(this).attr("href"));
        if (Core.isMobile()) {
            var button = $("header.main-header button.navbar-toggle");
            if (!button.hasClass("collapsed")) button.click();
            $("body").removeClass("sidebar-open");
        }
    });
};
Core.maintainState = function (selector) { $(selector).maintainState(); };
Array.prototype.destroy = function (obj) {
    var destroyed = null;
    for (var i = 0; i < this.length; i++) {
        while (this[i] === obj) destroyed = this.splice(i, 1)[0];
    }
    return destroyed;
};
Core.replaceWhitespace = function (str) {
    while (str.indexOf("  ") !== -1) { str = str.replace(/  /g, " "); }
    return str;
};
Core.replace = function (str, s1, s2, ignore) {
    return str.replace(new RegExp(s1, ignore ? "gi" : "g"), s2);
};
Core.trim = function (str, char) {
    str = $.trim(str);
    while (str.charAt(0) == char) str = str.substring(1);
    while (str.charAt(str.length - 1) == char) str = str.substring(0, str.length - 1);
    return str;
};
Core.getQueryVariable = function (query, variable) {
    // var query = window.location.search.substring(1);
    var vars = query.split('&');
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split('=');
        if (decodeURIComponent(pair[0]) == variable) {
            return decodeURIComponent(pair[1]);
        }
    }
};
//Them tam vao day. mac du deo hieu lam. check lai core
Core.buildFormSearchByCompanyId = function (formSearch, options) {
    Core.buildSelectInputChange(formSearch);
};


Core.numberWhenNull = function (number, $default) {
    if ($default == null) $default = 0;
    return number == null || number == undefined || number == "" || number == NaN ? $default : number;
};
Core.numberWhenZezo = function (number, $default) {
    return number == 0 ? $default : number;
};
Core.labelItems = {};
Core.defaultLanguage = 2;
Core.newLabels = {};
Core.getLabel = function (lexicon) {
    var value = Langs[lexicon]; 
    if (value == null) {
        value = Langs[lexicon] = lexicon; 
        Core.newLabels[lexicon] = { lexicon: lexicon, send: false };
    }
    return value;
};
Core.loadControl = function (type, func, data) {
    var ajax = new CoreAjax(); ajax.typeAction = "Main";
    var dataPost = { boxtype: type };
    if (data != null) $.extend(dataPost, data);
    ajax.post("LoadBox", dataPost, func);
};
Core.project = '';
Core.createConcrete = function (module, defaultConcrete, target) {
    if (module == null || module == "") return null;
    var getDefault = function () { return typeof (window[module][defaultConcrete]) == 'undefined' ? null : new window[module][defaultConcrete](); };
    var concrete = null;
    if (Core.project == null || Core.project == "") concrete = getDefault();
    else concrete = typeof (window[module][Core.project]) == 'undefined' ? getDefault() : new window[module][Core.project]();
    concrete.target = target;
    concrete.start();
    return concrete;
};
Core.loadModule = function (main, module, func, data, options, userOverlay, alertWhenFail) {
    var ajax = new CoreAjax("Web.Controls.Content");

    if (userOverlay == null) userOverlay = true; ajax.userOverlay = userOverlay;
    if (alertWhenFail == null) alertWhenFail = true; ajax.alertWhenFail = alertWhenFail;

    var dataPost = { control: module };
    if (data != null) $.extend(dataPost, typeof (data) == "function" ? data() : data);

    if (options == null) options = {};
    ajax.post("LoadModuleByControl", dataPost, function (res) {
        var ok = true;
        if (options.checkOk != null) ok = options.checkOk(res);

        if (ok != true) return;
        if (main != null) {
            main.html(res.Data.ModuleContent);
            main.rebuilddiv();
        }
        Core.getScriptsNeedLoad(res.Data.Scripts, function () {
            var jsmodule = null;
            eval("if(typeof(" + module + ") != 'undefined') { jsmodule = new " + module + "(); }");
            if (jsmodule != null) {
                jsmodule.module = module;
                if (main != null) {
                    jsmodule.main = main;
                    jsmodule.getMain = function () { return main; };
                }
                if (func != null) func(res, jsmodule);
                jsmodule.init(res);

                if (options.afterInit != null)
                    options.afterInit(res, jsmodule);
            }
            else {
                if (func != null) func(res);
            }

            if (main != null) {
                HotKeys.inst.restart();
                main.maintainState();
            }
        });
    });
};
$.fn.loadModule = function (module, func, data, options, userOverlay, alertWhenFail) { Core.loadModule(this, module, func, data, options, userOverlay, alertWhenFail); }

Core.moduleScripts = {};
Core.loadScriptsByModule = function (module, finish) {
    if (Core.moduleScripts[module]) {
        if (finish != null) finish();
        return;
    }
    var ajax = new CoreAjax("Web.Controls.Content");
    ajax.post("LoadScriptByModule", { control: module }, function (res) {
        Core.getScriptsNeedLoad(res.Data.Scripts, function () {
            if (finish != null) finish();
            Core.moduleScripts[module] = true;
        });
    });
};
Core.getSessionCookie = function () {
    var value = $.cookie("SSDApps");
    if (value == undefined || value == null || value == "") {
        value = Core.random(999999);
        $.cookie("SSDApps", value, { expires: 360 });
    }
    return value;
};

function Grid(data, container) {
    this.data = data;
    this.container = container;
    this.hot = null;
    this.name = Core.getLabel("dòng");
    this.currentOptions = null; // fillHandle

    this.VNDUSD = null;

    var containerStyle = "";
    var containerCss = "";

    this.wtHolder = 1;

    this.columnKeyConfig = "";
    this.userColumnConfig = null;

    var ajaxUserHelper = null;
    var getAjaxUserHelper = function () {
        if (ajaxUserHelper == null) {
            ajaxUserHelper = new CoreAjax("Business.UserHelper");
            ajaxUserHelper.assembly = "Core.Sites.Libraries";
        }
        return ajaxUserHelper;
    };

    this.init = function (render) {
        if (render == null) render = true;
        var $this = this;

        //$this.columnKeyConfig = "";
        // Nếu lưới có cấu hình ẩn hiện cột thì thực hiện khởi tạo luôn
        if ($this.columnKeyConfig == "" || $this.userColumnConfig != null) initHelper.bind(this)(render);

        else {
            // Tải thông tin về cột cấu hình trước khi thực hiện khởi tạo lưới dữ liệu            
            getAjaxUserHelper().post("GetColumnConfigOfGridCanEdit", { columnKeyConfig: $this.columnKeyConfig }, function (res) {
                $this.userColumnConfig = res.Data.ColumnConfig;
                if ($this.userColumnConfig == null) $this.userColumnConfig = {};
                initHelper.bind($this)(render);
            });
        }
    };

    this.afterHotRender = function () { };
    var initHelper = function (render) {
        var $this = this;

        var options = $this.createOptions();
        $this.currentOptions = options;

        this.customContextMenu(options.contextMenu.items);

        if (Enumerable.From(options.contextMenu.items).Count() == 0)
            options.contextMenu = null;

        containerStyle = $this.container.attr("style");
        containerCss = $this.container.attr("class");

        $this.hot = new Handsontable(this.container[0], options);
        Handsontable.hooks.add('afterRender', function () {
            $this.container.find(".wtHolder").width($this.container.width() + $this.wtHolder);
            $this.afterHotRender();
        }, $this.hot);
        Handsontable.hooks.add('afterRenderer', function (td, row, col, prop, value, cellProperties) { $this.afterRenderer(td, row, col, prop, value, cellProperties); }, $this.hot);
        Handsontable.hooks.add('afterRemoveRow', function () { $this.fire(); $this.onAfterRemoveRow(); }, $this.hot);
        Handsontable.hooks.add('afterChange', function () {
            if (arguments[1] != "edit" && arguments[1] != "CopyPaste.paste" && arguments[1] != "Autofill.fill") return;
            var source = $this.getDataItems(); $this.afterChange(arguments[0], source); $this.fire(source);
        }, $this.hot);
        Handsontable.hooks.add('beforeKeyDown', function (evt) {
            if (evt.code != "Tab") return;
            var current = $this.hot.getSelected();
            if (($this.hot.countRows() - 1) == current[0] && ($this.hot.countCols() - 1) == current[1]) {
                $this.onTabLastCell();
                $this.hot.deselectCell();
            }
        }, $this.hot);
        Handsontable.hooks.add("afterSelection", function (r, p, r2, p2) {
            if ($this.afterSelection != null) {
                $this.afterSelection($this.getDataItems()[r], r);
            }
        }, $this.hot);
        // https://handsontable.com/docs/1.14.0/Hooks.html#event:afterAddChild : Các sự kiện Handsontable

        $this.onBeforeRender();

        if (render) $this.render();
        $this.hot.render();
        $this.onInit();
    };

    this.onBeforeRender = function () { };

    this.isRowNull = function (row) {
        return Enumerable.From(this.currentOptions.columns).All(function (c) { return row[c.data] == null || row[c.data] == ""; });
    }

    this.afterSelection = null; // đầu vào là item được chọn
    this.selectCell = function (r, c) {
        if (r == null) r = 0;
        if (c == null) c = 0;
        this.hot.selectCell(r, c);
    };

    this.reInit = function () {
        var $this = this;
        if (this.hot != null) this.hot.destroy();
        container.removeAttr("style").empty(); container.attr("style", containerStyle);
        container.removeAttr("class").empty(); container.attr("class", containerCss);
        $this.init();
    };

    this.onAfterRemoveRow = function () { };
    this.getCurrentRow = function () {
        var row = this.hot.getSelected();
        if (row == undefined || row == null) return null;
        return this.hot.getSourceDataAtRow(row[0]);
    };
    this.getCurrentValueInRow = function (field) {
        var row = this.getCurrentRow();
        if (row == null) return null;
        return row[field];
    };

    this.onTabLastCell = function () { }
    this.afterRender = function () { };
    this.afterRenderer = function (td, row, col, prop, value, cellProperties) { };

    this.focusFirstCell = function () { var $this = this; setTimeout(function () { $this.hot.selectCell(0, 0); }, 10); };

    this.setFocus = function (row, column) {
        var $this = this; setTimeout(function () { $this.hot.selectCell(row, column); }, 10);
    };

    this.createHeaders = function () { return null; };
    this.createColumns = function () { return null; };
    this.createContextMenu = function (options) {
        if (options.minSpareRows == null || options.minSpareRows == 0) return {};
        return this.getDefaultContext();
    };
    this.getDefaultContext = function () {
        var $this = this;
        return {
            row_above: {
                name: Core.getLabel("Thêm {0} phía trên").format($this.name), disabled: function () {
                    var selected = $this.hot.getSelected();
                    if (selected == null) return true;
                    return $this.rowAboveDisabled($this.getCurrentRow(), selected == null ? -1 : selected[0]);
                }
            },
            row_below: {
                name: Core.getLabel("Thêm {0} phía dưới").format($this.name), disabled: function () {
                    var selected = $this.hot.getSelected();
                    if (selected == null) return true;
                    var index = selected[0];
                    return $this.lastRowEmpty() || $this.hot.countRows() - 1 != index || $this.rowBelowDisabled($this.getCurrentRow(), index);
                }
            },
            remove_row: {
                name: Core.getLabel("Xóa {0}").format($this.name), disabled: function () {
                    var selected = $this.hot.getSelected();
                    if (selected == null) return true;
                    return $this.removeRowDisabled($this.getCurrentRow(), selected == null ? -1 : selected[0]);
                }
            }
        };
    };

    this.isNotSelected = function () {
        var selected = this.hot.getSelected();
        if (selected == null) return true;
        var index = selected == null ? -1 : selected[0];
        return index == -1;
    };

    this.rowAboveDisabled = function (row, index) { return false; };
    this.rowBelowDisabled = function (row, index) { return false; };
    this.removeRowDisabled = function (row, index) { return false; };

    this.afterCreateColumns = function () { };

    this.filterColumnCanShow = function (columns) {
        return Enumerable.From(columns).Where(function (c) {
            var show = c.show;
            if (show == null || show == true) return true;
            return typeof (show) == "function" ? show() : false;
        }).ToArray();
    };

    this.createOptions = function () {
        var $this = this;
        var options =
        {
            width: function () { return $this.container.width(); },
            stretchH: 'all', minSpareRows: 1, autoWrapRow: true, wordWrap: false, autoColumnSize: false, rowHeaders: true,
            formulas: true
        };
        options.colHeaders = $this.createHeaders();
        options.columns = $this.createColumns();

        // Check ẩn hiện cột theo phân quyền
        options.columns = $this.filterColumnCanShow(options.columns);

        // Check ẩn hiện cột theo người dùng cấu hình
        if ($this.userColumnConfig != null) {
            if ($this.userColumnConfig.ViewColumns != null && $this.userColumnConfig.ViewColumns.length > 0) {
                options.columns = Enumerable.From(options.columns)
                    .Join($this.userColumnConfig.ViewColumns, function (c) { return c.data; },
                        function (v) { return v; },
                        function (c, v) { return c; }).ToArray();
            }

            if ($this.userColumnConfig.RootSttColumns != null && $this.userColumnConfig.RootSttColumns.length > 0) {
                options.columns = Enumerable.From($this.userColumnConfig.RootSttColumns)
                    .Select(function (sc, index) { return { sc: sc, index: index }; })
                    .Join(options.columns, function (scindex) { return scindex.sc; },
                        function (c) { return c.data; },
                        function (scindex, c) { return { c: c, index: scindex.index }; })
                    .OrderBy(function (cindex) { return cindex.index; })
                    .Select(function (cindex) { return cindex.c; })
                    .ToArray();
            }
        }

        if (this.VNDUSD != null) {
            Enumerable.From(options.columns).ForEach(function (c) {
                if (c.data.indexOf("_VND") > 0) c.vnd = true;
                if (c.data.indexOf("_USD") > 0) c.usd = true;
            });

            var vndusd = this.VNDUSD;
            if (typeof (vndusd) == "function") vndusd = vndusd.bind($this)();
            vndusd = parseInt(vndusd);
            switch (vndusd) {
                case 1: options.columns = Enumerable.From(options.columns).Where(function (c) { return c.usd == null || c.usd != true; }).ToArray(); break;
                case 2: options.columns = Enumerable.From(options.columns).Where(function (c) { return c.vnd == null || c.vnd != true; }).ToArray(); break;
            }
        }

        this.afterCreateColumns(options);

        if (options.colHeaders == null)
            options.colHeaders = Enumerable.From(options.columns).Select(function (c) {
                if (c.translate == null) c.translate = true;
                if (c.translate) c.title = Core.getLabel(c.title);
                return c.title;
            }).ToArray();

        options.manualRowResize = true;

        options.cellClearWrap = Enumerable.From(options.columns)
            .Select(function (c, i) { return { c: c, i: i } })
            .Where(function (ci) { return ci.c.clearWrap; })
            .Select(function (ci) { return ci.i; }).ToArray();

        if (options.cellClearWrap != null && options.cellClearWrap.length > 0) {
            options.cells = function (row, col, prop) {
                // Tìm những cột chọn ngày, autocomplete thì bỏ dấu chọn
                if (Enumerable.From(options.cellClearWrap).Any(function (c) { return c == col; })) {
                    return { renderer: function (instance, td, row, col, prop, value, cellProperties) { Handsontable.renderers.TextRenderer.apply(this, arguments); } };
                }
                else return {};
            };
        }

        this.customerOption(options);
        var context = $this.createContextMenu(options);
        if (context != null) options.contextMenu = { items: context };
        else options.contextMenu = { items: {} };

        //if (Enumerable.From(options.contextMenu.items).Count() == 0)
        //    options.contextMenu.items = null;

        // Tạo menu cấu hình cột
        if (this.columnKeyConfig != null && this.columnKeyConfig != "") {
            options.contextMenu.items.configColumnInGrid = {
                name: Core.getLabel("Cấu hình cột"), callback: function () {
                    var popup = new Grid.PopupColumnConfig();
                    var nowConfig = {}; $.extend(nowConfig, $this.userColumnConfig);
                    popup.data = $this.getOptionColumnFromUserColumn(nowConfig);
                    popup.mainGrid = $this;
                    popup.show();
                }
            };
        }

        this.index = {};
        Enumerable.From(options.columns).ForEach(function (column, index) { $this.index[column.data] = index; });
        return options;
    };

    this.index = {};

    this.customContextMenu = function (items) { };

    this.doSaveConfig = function (data, callback) {
        var $this = this;
        var columns = Enumerable.From(data.dataColumns)
            .Where(function (c) { return c.Show == true; })
            .Select(function (c) { return c.ColumnField; });

        var rootSttColumns = Enumerable.From(data.dataColumns)
            .OrderBy(function (c) { return c.Stt; })
            .Select(function (c) { return c.ColumnField; });

        this.userColumnConfig.Module = this.columnKeyConfig;
        this.userColumnConfig.Columns = columns.Distinct().ToString(",");
        this.userColumnConfig.ColumnStt = rootSttColumns.Distinct().ToString(",");

        var dataPost = {}; $.extend(dataPost, this.userColumnConfig);
        dataPost.ViewColumns = null;
        dataPost.RootSttColumns = null;

        getAjaxUserHelper().post("SaveUserColumn", dataPost, function (res) {
            $this.userColumnConfig.ViewColumns = columns.Distinct().ToArray();
            $this.userColumnConfig.RootSttColumns = rootSttColumns.Distinct().ToArray();
            $this.userColumnConfig.UserColumnId = res.Data.UserColumnId;

            // 
            $this.reInit();

            callback();
        });
    };
    this.getOptionColumnFromUserColumn = function (userColumn) {
        var $this = this;
        var columns = userColumn.ViewColumns;                     // Danh sách các cột đang được hiển thị

        onUseColumnForConfig = true;
        var columnsOfGrid = $this.filterColumnCanShow($this.createColumns()); // Tất cả các cột của Grid mà được cấu hình nhưng cũng được lọc theo phân quyền hiển thị
        onUseColumnForConfig = false;

        // Tạo lưới cấu hình các cột
        var dataColumns = Enumerable.From(columnsOfGrid)
            .Select(function (c) { return { ColumnName: c.title, ColumnField: c.data, Width: c.width }; })
            .ToArray();

        // Nếu có cấu hình hiển thị cột thì thiết Show = true cho những trường đã chọn lưu trước đó
        if (columns != null && columns.length > 0) {
            Enumerable.From(dataColumns).Join(columns, function (dc) { return dc.ColumnField; },
                function (c) { return c; },
                function (dc, c) { dc.Show = true; }).Count();
        }

        // Còn không thì mặc định là hiển thị hết
        else {
            Enumerable.From(dataColumns).ForEach(function (dc) { dc.Show = true; });
        }

        // Thiết lập thứ tự các cột
        var columnStts = userColumn.RootSttColumns;
        if (columnStts != null && columnStts.length > 0) {
            Enumerable.From(columnStts).Select(function (cs, index) { return { cs: cs, index: index }; })
                .Join(dataColumns, function (csindex) { return csindex.cs; },
                    function (dc) { return dc.ColumnField; },
                    function (csindex, dc) { dc.Stt = csindex.index; }).Count();

            // Tìm xem những cột mới thì chưa có cấu hình sắp xếp nhưng cũng lấy mặc định index lúc người lập trình thêm để sắp xếp để chèn vô thì order
            Enumerable.From(dataColumns).Select(function (dc, index) { return { dc: dc, index: index } })
                .GroupJoin(columnStts, function (dcindex) { return dcindex.dc.ColumnField; },
                    function (cs) { return cs; },
                    function (dcindex, css) { return { dcindex: dcindex, total: css.Count() }; })
                .Where(function (t) { return t.total == 0; })
                .ForEach(function (t) { t.dcindex.dc.Stt = t.dcindex.index; });

            dataColumns = Enumerable.From(dataColumns).OrderBy(function (dc) { return dc.Stt; }).ToArray();
            Enumerable.From(dataColumns).ForEach(function (dc, index) { dc.index = index; });
        }
        else {
            Enumerable.From(dataColumns).ForEach(function (dc, index) { dc.Stt = index; dc.index = index; });
        }

        var data = {};
        data.dataColumns = dataColumns;

        return data;
    };
    this.getReportColumns = function () {
        //var headers = this.createHeaders();
        var columns = this.createColumns();

        //Enumerable.From(columns).ForEach(function (c, i) { c.Title = headers[i]; });
        return Enumerable.From(columns)
            .Where(function (c) { return c.report == null || c.report; })
            .Select(function (c) {
                return { Field: c.data, Title: c.title, Width: c.rWidth, Format: c.rFormat };
            }).ToArray();
    };

    this.customerOption = function (options) { }
    this.findOptionData = function (field) { return this["data-option-item-" + field]; }
    this.findOptionDataItem = function (field, value) {
        var data = this.findOptionData(field);
        var items = data.byFunction ? data.funcData(null) : data.items;
        if (items == null) items = [];
        return Enumerable.From(items).Where(function (item) { return item != null; }).FirstOrDefault(null, function (item) { return item[data.fieldName] == value; });
    };
    this.findOptionDataRemote = function (field, value, func) {
        var data = this.findOptionData(field);
        var dataPost = {}; dataPost[data.fieldId] = value;
        var ajax = new CoreAjax(data.typeAction);
        ajax.assembly = data.assembly;
        ajax.post("SearchingById", dataPost, function (res) {
            func(res.Data.Item);
            if (data.items == null) {
                data.items = [];
                if (res.Data.Item != null)
                    data.items.push(res.Data.Item);
            }
        });
    };
    this.findOptionDataRemoteByName = function (field, value, func) {
        var data = this.findOptionData(field);
        var dataPost = {}; dataPost["query"] = value;
        if (data.forQuery != null)
            data.forQuery(dataPost);

        var ajax = new CoreAjax(data.typeAction);
        ajax.assembly = data.assembly;
        ajax.post("Searching", dataPost, function (res) {
            var item = Enumerable.From(res.Data.Items).FirstOrDefault(null, function (t) { return t[data.fieldName] == value; });
            func(item);
            if (data.items == null) {
                data.items = [];
                if (item != null)
                    data.items.push(item);
            }
        });
    };

    this.findOptionDataItemByFieldId = function (field, value) {
        var data = this.findOptionData(field);
        var items = data.byFunction ? data.funcData(null) : data.items;
        return Enumerable.From(items).FirstOrDefault(null, function (item) { return item[data.fieldId] + "" == value + ""; });
    };
    this.findOptionDataItemComplex = function (field, value, func) {
        var item = this.findOptionDataItemByFieldId(field, value);
        if (item != null) { func(item); return; }
        this.findOptionDataRemote(field, value, function (item) { func(item); });
    };

    this.isChangeCell = function (t) { return t[2] !== t[3]; };
    this.ifChangeCell = function (t, field, action) {
        if (t[1] == field && this.isChangeCell(t)) { action(); return true; }
        return false;
    };
    this.ifChangeCells = function (t, fields, action) {
        if (Enumerable.From(fields).Any(function (item) { return item == t[1]; })) {
            action(t[1]);
            return true;
        }
        return false;
    };
    this.ifChangeCellFollow = function (t, field, rowIndex, row, cellIndex, fieldId, fieldIdFollow, cellIndexFollow, itemAction) {
        var $this = this;
        $this.ifChangeCell(t, field, function () {
            var item = $this.findOptionDataItem(field, row[field]);
            var data = $this.findOptionData(field);

            if (item == null) {
                if (data.clearWhenNotExit) $this.hot.setDataAtCell(rowIndex, cellIndex, "", field + "-Fail");
                if (fieldId != null) row[fieldId] = 0;
            }
            else {
                if (fieldId != null) row[fieldId] = item[fieldId];
            }

            if (itemAction != null) itemAction(item, data.clearWhenNotExit);

            if (fieldIdFollow != null) row[fieldIdFollow] = 0;
            if (cellIndexFollow != null) $this.hot.setDataAtCell(rowIndex, cellIndexFollow, "");
        });
    };
    this.ifChangeCellFollow2 = function (t, field, rowIndex, row, fieldId, fieldIdFollow, fieldFollow, itemAction, useFieldId) {
        var $this = this;
        return $this.ifChangeCell(t, field, function () {
            var option = $this.findOptionData(field);
            var rowFieldValue = row[field];

            var item = $this.findOptionDataItem(field, rowFieldValue);
            if (item == null) {
                if (rowFieldValue != null && rowFieldValue != "") {
                    if (!option.duplicate) {
                        if (Enumerable.From(data).Count(function (dataItem) { return dataItem[field] == rowFieldValue; }) >= 2) {
                            cellDropdownChange.bind($this)(null, field, rowIndex, row, fieldId, fieldIdFollow, fieldFollow, itemAction, useFieldId);
                            return;
                        }
                    }

                    if (option.byFunction) {
                        cellDropdownChange.bind($this)(null, field, rowIndex, row, fieldId, fieldIdFollow, fieldFollow, itemAction, useFieldId);
                        return;
                    }

                    $this.findOptionDataRemoteByName(field, rowFieldValue, function (item) {
                        cellDropdownChange.bind($this)(item, field, rowIndex, row, fieldId, fieldIdFollow, fieldFollow, itemAction, useFieldId);
                    });
                    return;
                }
            }
            cellDropdownChange.bind($this)(item, field, rowIndex, row, fieldId, fieldIdFollow, fieldFollow, itemAction, useFieldId);
        });
    };

    var cellDropdownChange = function (item, field, rowIndex, row, fieldId, fieldIdFollow, fieldFollow, itemAction, useFieldId) {
        var $this = this;
        var data = $this.findOptionData(field);

        if (useFieldId == null) useFieldId = true;

        if (item == null) {
            if (data.clearWhenNotExit) row[field] = "";
            if (useFieldId && fieldId != null) row[fieldId] = 0;
        }
        else {
            if (useFieldId && fieldId != null) row[fieldId] = item[data.fieldId];
        }

        if (itemAction != null) itemAction(item, data.clearWhenNotExit);
        if (fieldIdFollow != null) row[fieldIdFollow] = 0;
        if (fieldFollow != null) row[fieldFollow] = "";
        $this.hot.render();
    };

    // Biến để kiểm soát việc lấy cấu hình cột autocomplete
    // Thì sẽ không cần khởi tạo thuộc tính source cho column
    var onUseColumnForConfig = false;

    this.cacheData = {};
    this.newColumnAutocomplete = function (field, fieldId, fieldName, typeAction, forQuery, action, duplicate, clearWhenNotExit, cache) {
        var $this = this;
        if (cache == null) cache = true;

        var column =
        {
            type: 'autocomplete',
            data: field,
            //strict: true,
            allowInvalid: true,
            clearWrap: true
        };

        if (onUseColumnForConfig == true) {
            if (action != null) action(column);
            return column;
        }

        if (duplicate == null) duplicate = true;
        if (clearWhenNotExit == null) clearWhenNotExit = true;

        var byFunction = typeof (typeAction) == "function";

        var $typeOf = { type: "", assembly: "" };
        if (byFunction == false) $typeOf = CoreAjax.buildType(typeAction);

        var saveData = {
            cache: cache,
            fieldId: fieldId,
            duplicate: duplicate,
            forQuery: forQuery,
            fieldName: fieldName,
            assembly: $typeOf.assembly,
            funcData: typeAction,
            typeAction: $typeOf.type,
            clearWhenNotExit: clearWhenNotExit,
            byFunction: byFunction
        };
        saveData.getAjaxOption = function () {
            var ajaxOption = {};
            if (forQuery != null) forQuery(ajaxOption);
            return ajaxOption;
        }
        saveData.getKeyCache = function (ajaxOption) {
            if (ajaxOption == null) ajaxOption = saveData.getAjaxOption();
            return Enumerable.From($typeOf).ToString("_", "$.Value") + "_" + Enumerable.From(ajaxOption).ToString("_", "$.Value");
        }
        saveData.clearCache = function () { $this.cacheData[saveData.getKeyCache()] = null; };
        $this["data-option-item-" + field] = saveData;

        var toRequest = null;
        var request = null;
        var doRequest = function (query, process) {
            if (saveData.byFunction) doResult(process, saveData.funcData(query));
            else {
                if (request != null) { request.abort(); request = null; }

                var ajaxOption = saveData.getAjaxOption();

                var keyCache = null;
                if (cache === true) {
                    keyCache = saveData.getKeyCache(ajaxOption);
                    // Kiểm tra xem có dữ liệu trong cache không. Nếu có thì thực hiện xử lý luôn
                    if (!Core.isNull($this.cacheData[keyCache])) {
                        doResult(process, $this.cacheData[keyCache]);
                        return;
                    }
                }
                else ajaxOption.query = query;

                request = $.ajax({
                    url: "/Services/Ajax.aspx?_n=" + $typeOf.assembly + "&_o=" + $typeOf.type + "&_m=Searching", type: 'POST', dataType: 'json', data: ajaxOption,
                    success: function (res) {
                        if (res.Data.Items == null) return;
                        // Nếu có lưu cache thì vừa lưu cache đồng thời xử lý dữ liệu
                        if (cache === true) doResult(process, $this.cacheData[keyCache] = res.Data.Items);
                        else doResult(process, res.Data.Items);
                    }
                });
            }
        };
        var doResult = function (process, items) {
            saveData.items = items;

            if (duplicate) process(Enumerable.From(items).Select(function (item) { return item[fieldName]; }).ToArray());

            else {
                var currentItems = Enumerable.From(Enumerable.From($this.getDataItems()).Select(function (row) { return row[field]; }).ToArray());
                process(Enumerable.From(items).
                    Select(function (item) { return item[fieldName]; }).
                    Where(function (item) { return !currentItems.Contains(item); }).ToArray());
            }
        };
        column.source = function (query, process) {
            if (toRequest != null) clearTimeout(toRequest);
            toRequest = setTimeout(function () { doRequest(query, process); toRequest = null; request = null; }, 200);
        };

        if (action != null) action(column);
        return column;
    };

    this.columnAutocomplete = function (field, options) {
        var column = this.newColumnAutocomplete(field,
            options.fieldId,
            options.fieldName,
            options.typeAction,
            options.forQuery,
            options.action,
            options.duplicate,
            options.clearWhenNotExit);

        return column;
    };

    this.render = function () {
        if (this.hot == null) this.init();
        else { this.hot.loadData(this.data); this.afterRender(); }
    };
    this.lastRowEmpty = function () {
        if (this.hot == null) return false;
        var rowDatas = this.hot.getData();
        if (rowDatas == null || rowDatas.length == 0) return false;
        return this.isRowEmpty(rowDatas[rowDatas.length - 1]);
    };
    this.isRowEmpty = function (row) { return Core.isRowEmpty(row); };
    this.getData = function (name) {
        var $this = this;
        var data = {};
        if (this.hot == null) return data;
        Enumerable.From(this.getDataItems()).Where(function (row) { return !$this.concreteIsRowEmpty(row); }).Select(function (row, index) { data[name + "-" + index] = row; }).Count();
        return data;
    };
    this.getDataItems = function () { return this.hot.getSourceData(); };
    this.concreteIsRowEmpty = function (row) { return this.isRowEmpty(row); };
    this.onInit = function () { };
    this.fire = function (source) { };
    this.afterChange = function (data, source) {
        var $this = this;
        Enumerable.From(data).ForEach(function (t) {
            var rowIndex = t[0];
            var row = source[rowIndex];
            $this.onAfterChangeHelper(t, rowIndex, row);
        });
    };

    this.onAfterChangeHelper = function (t, rowIndex, row) {
        if (row.RandomId == null || row.RandomId == 0) row.RandomId = Core.random(99999);
        this.onAfterChange(t, rowIndex, row);
        row.Editted = true;
    };

    this.onAfterChange = function (t, rowIndex, row) { };
    // select2 => sẽ bỏ
    this.fillText = function (value, data, targetCell, arg, call) {
        if (value != null) call(value = Enumerable.From(data).FirstOrDefault({ text: "" }, function (t) { return t.id === parseInt(value); }).text);
        //Handsontable.TextCell.renderer.apply(targetCell, arg);
        Handsontable.renderers.TextRenderer.apply(targetCell, arg)
    };
    this.getSelect2Options = function (data) {
        return { data: data, dropdownAutoWidth: true, width: 'resolve' };
    };
    this.getSelectItems = function (field, items) {
        var row = this.hot.getSelected();
        var value = parseInt(this.hot.getSourceDataAtRow(row[0])[field]);
        return Enumerable.From(items).Where(function (item) { return item[field] == value; }).ToArray();
    };
    this.newColumnSelect = function (field, items, fitems, action) {
        var $this = this;
        var column = {
            data: field,
            editor: 'select2',
            renderer: function (instance, td, row, col, prop, value, cellProperties) { $this.fillText(value, items, this, arguments, function (v) { value = v; }); },
            select2Options:
            {
                data: function () { return { results: fitems == null ? items : fitems() }; },
                dropdownAutoWidth: true, width: 'resolve',
                //formatResult: function (data) { return data.text; }
            }
        };

        if (action != null) action(column);
        return column;
    };
    this.newColumnSelectFollowField = function (field, items, fieldFollow, action) {
        var $this = this;
        return this.newColumnSelect(field, items, function () { return $this.getSelectItems(fieldFollow, items); }, action);
    };

    // renderers
    this.columnNumberPositive = function (instance, td, row, col, prop, value, cellProperties) {
        Handsontable.renderers.TextRenderer.apply(this, arguments);
        if (value < 0) {
            td.style.backgroundColor = 'red';
            td.style.color = "white";
        }
    };
    this.loadData = function (data) {
        this.data = data;
        this.hot.loadData(data);
        this.hot.render();
    };
}

Grid.GridColumnConfig = function (data, area) {
    $.extend(this, new Grid(data, area));
    this.createColumns = function () {
        return [
            { data: "ColumnName", width: "350px", title: "Tên cột", readOnly: true },
            { data: "Width", width: "50px", title: "Độ rộng", readOnly: true },
            { data: "Stt", width: "50px", title: "Thứ tự", type: "numeric", format: '0,0' },
            { data: "Show", width: "50px", type: "checkbox", className: "htCenter htMiddle", title: "Hiển thị" },
        ];
    };
    this.customerOption = function (options) {
        options.height = 395;
        options.minSpareRows = 0;
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
Grid.PopupColumnConfig = function () {
    $.extend(this, new Popup());
    var $this = this;
    var html = '<div class="form-horizontal">';

    html += '<div class="row">';
    html += '   <div class="col-sm-12">';
    html += '       <div data-form="column" class="tb-no-left border-table-grid border-table-grid-bottom"></div>';
    html += '   </div>';
    html += '</div>';

    html += "</div>";

    this.content = html;
    this.title = Core.getLabel("Thiết lập cấu hình cột");

    this.clearWhenHide = true;
    this.dialogType = "modal-lg";

    this.buttons.push({
        value: "Thiết lập", hotKey: "Ctrl_s", icon: "fas fa-save", cls: "btn btn-success pull-left", func: function (element, scope) {
            $this.mainGrid.doSaveConfig($this.data, function () { $this.hide(); });
        }
    });
    this.buttons.push({
        value: "Sắp xếp", hotKey: "Ctrl_d", icon: "fa fa-navicon", cls: "btn bg-maroon pull-left", func: function (element, scope) {
            $this.data.dataColumns = Enumerable.From($this.data.dataColumns).OrderBy(function (c) { return c.Stt; }).ToArray();
            grid.loadData($this.data.dataColumns);
            grid.hot.render();
        }
    });
    this.buttons.push({
        value: "Trở về mặc định", hotKey: "Ctrl_f", icon: "fas fa-cog", cls: "btn bg-red pull-left", func: function (element, scope) {
            var newData = $this.mainGrid.getOptionColumnFromUserColumn({});
            $.extend($this.data, newData);
            grid.loadData($this.data.dataColumns);
            grid.hot.render();
        }
    });

    var switchRow = function (nowRow, step) {
        var nextIndex = nowRow.index + step;
        var nextRow = Enumerable.From($this.data.dataColumns).FirstOrDefault(null, function (c) { return c.index == nextIndex });
        var temp = nowRow.Stt;
        nowRow.Stt = nextRow.Stt;
        nextRow.Stt = temp;
        $this.data.dataColumns = Enumerable.From($this.data.dataColumns).OrderBy(function (c) { return c.Stt; }).ToArray();
        Enumerable.From($this.data.dataColumns).ForEach(function (c, index) { c.index = index; });
        grid.loadData($this.data.dataColumns);
        grid.hot.render();
        grid.setFocus(nextIndex, 0);
    };

    var upOne = function () {
        var nowRow = Enumerable.From($this.data.dataColumns).FirstOrDefault(null, function (c) { return c.selected == true; });
        if (nowRow == null || nowRow.index == 0) { Core.alert("Không thể dịch chuyển tiếp được"); return; };
        switchRow(nowRow, -1);
    };

    this.buttons.push({
        value: "Dịch lên", hotKey: "Ctrl_l", icon: "fa fa-angle-double-up", cls: "btn bg-light-blue pull-left", func: function (element, scope) {
            upOne();
        }
    });

    var downOne = function () {
        var nowRow = Enumerable.From($this.data.dataColumns).FirstOrDefault(null, function (c) { return c.selected == true; });
        if (nowRow == null || nowRow.index == $this.data.dataColumns.length - 1) { Core.alert("Không thể dịch chuyển tiếp được"); return; };
        switchRow(nowRow, 1);
    };

    this.buttons.push({
        value: "Dịch xuống", hotKey: "Ctrl_x", icon: "fa fa-angle-double-down", cls: "btn bg-blue pull-left", func: function (element, scope) {
            downOne();
        }
    });

    var grid = null;

    var setPositionItem = function (stt, focus) {
        var nowRow = Enumerable.From($this.data.dataColumns).FirstOrDefault(null, function (c) { return c.selected == true; });
        nowRow.Stt = stt;
        $this.data.dataColumns = Enumerable.From($this.data.dataColumns)
            .OrderBy(function (c) { return c.Stt; })
            .Select(function (c, index) { c.Stt = index; c.index = index; return c; })
            .ToArray();
        grid.loadData($this.data.dataColumns);
        grid.hot.render();
        grid.setFocus(focus, 0);
    };

    this.onAlwaysShow = function () {
        grid = new Grid.GridColumnConfig(this.data.dataColumns, this.popupBody.find("[data-form=column]"));
        grid.upToTop = function () { setPositionItem(-1, 0); };
        grid.downToBottom = function () { setPositionItem($this.data.dataColumns.length, $this.data.dataColumns.length - 1); };
        grid.upOne = function () { upOne(); };
        grid.downOne = function () { downOne(); };
        grid.init();
    };
};
Grid.buildData = function (name, data, onRow) {
    var result = {};
    Enumerable.From(data).Select(function (row, index) { result[name + "-" + index] = row; if (onRow != null) onRow(row); }).Count();
    return result;
};
Core.runToCondition = function (condition, timeout) {
    var to = null;
    var func = function () {
        if (to != null) {
            clearTimeout(to);
            to = null;
        }

        to = setTimeout(function () {
            var result = condition();
            if (result) {
                clearTimeout(to);
                to = null;
                return;
            }
            func();
        }, timeout);
    };
    func();
};
Core.roundNumber = function (num, scale) {
    if (num == null) return null;

    var powScale = Math.pow(10, scale);
    var powScale_1 = Math.pow(10, (scale + 1));

    var number = Math.round(num * powScale) / powScale;
    if (num - number > 0) {
        var number1 = number * powScale;
        var percent = (Math.floor(2 * Math.round((num - number) * powScale_1) / 10) / powScale) * powScale;

        return (number1 + percent) / powScale;
    }

    else return number;
};
Core.random = function (number) { return parseInt(Math.random() * number); };
Core.printModule = function (module, data, title, formats, width, height, buildPopup) {
    var popup = new Popup();

    popup.module = "Printer"; //module;
    if (data == null) data = {};
    data.ModulePrint = module;

    popup.data = data;
    popup.title = Core.getLabel(title);

    if (formats != null) popup.title = Core.formatString(popup.title, formats);

    var currentModule = null;
    popup.afterLoadControl = function (res, module) { currentModule = module; };
    if (buildPopup != null) buildPopup(popup);
    popup.buttons.push({
        value: "In", icon: "fa fa-print", hotKey: "Ctrl_p", cls: "btn btn-primary pull-left", func: function (element, scope) {
            currentModule.print();
        }
    });
    popup.buttons.push({
        value: "Cấu hình", icon: "fa fa-cogs", hotKey: "Ctrl_o", cls: "btn btn-success pull-left", func: function (element, scope) {
            Core.showPopupModule(module,
                function (popupConfig) {
                    popupConfig.title = Core.getLabel("Cấu hình in") + ": " + popup.title;
                    popupConfig.module = "PrinterConfig";
                    popupConfig.data = popup.data;
                },
                function (moduleConfig) {
                    moduleConfig.afterSaveConfig = function () {
                        popup.hide();
                        Core.printModule(module, data, title, formats, width, height, buildPopup);
                    };
                });
        }
    });
    popup.buttons.push({
        value: "Tải file Pdf", icon: "far fa-file-pdf", hotKey: "Ctrl_d", cls: "btn bg-maroon pull-left",
        func: function (element, scope) { currentModule.downloadPdf(); },

        childs: [{
            value: "Tải file Word", icon: "far fa-file-word", hotKey: "Ctrl_g", cls: "btn bg-purple pull-left",
            func: function (element, scope) { currentModule.downloadWord(); }
        }]
    });
    popup.afterCreatePopupBody = function () {
        if (popup.fullScreen != true) {
            if (height != null && height != 0) popup.popupBody.height(height);
            else popup.popupBody.height($(window).height() - 200);
            popup.popupBody.css("overflow", "auto");
        }
    };

    // http://www.jquery-plugins.hu/demo/37/print-element.html
    popup.onAlwaysShow = function () {
        if (popup.fullScreen != true && width != null && width != 0)
            popup.modal.find(".modal-dialog").width(width + 30);
    };
    popup.clearWhenHide = true;
    popup.show();
};
Core.getConfigPrintModule = function (config, defaultWidth, defaultHeight) {
    var sc = config.split(',');
    var module = sc[0];
    var width = null;
    if (sc.length > 1) width = sc[1];
    if (width == null || width == "") width = defaultWidth;
    else width = parseInt(width);

    var height = null;
    if (sc.length > 2) height = sc[1];
    if (height == null || height == "") height = defaultHeight;
    else height = parseInt(height);

    return { module: module, width: width, height: height };
};

Core.extensionIcons = "doc,gif,jpg,pdf,png,rar,xls";
Core.getPathIcon = function (extension) {
    if (Core.extensionIcons.indexOf(extension) < 0) extension = "other";
    return "/Web/Resources/Icons/files/" + extension + ".png";
};
Core.showModuleForChose = function (module, title, keyField, choseOne, buildPopup, withModule, eventChose) {
    var popup = new Popup();
    popup.dialogType = "modal-lg";
    popup.module = module;
    popup.title = title;
    popup.data = { Popup: true, ChoseOne: choseOne };
    if (buildPopup != null) buildPopup(popup);

    var currentModule = null;
    popup.afterLoadControl = function (res, module) { currentModule = module; if (withModule != null) withModule(res, module); };

    var selectorChosen = choseOne ? "[name=" + keyField + "]" : "[data-chk-name=" + keyField + "]";

    popup.buttons.push({
        value: "Chọn", icon: "fas fa-check", cls: "btn btn-primary pull-left", func: function (element, scope) {
            if (eventChose != null) {
                var itemIds = Enumerable.From(currentModule.table.gridContainer.find(selectorChosen))
                    .Where(function (chk) { return chk.checked; })
                    .ToString(",", function (chk) { return $(chk).val(); });

                var dataItems = Enumerable.From(currentModule.table.table.DataTable().data())
                    .Join(itemIds.split(','),
                        function (item) { return item[keyField] + ""; },
                        function (id) { return id; },
                        function (item, id) { return item; }).ToArray();

                eventChose(itemIds, dataItems);
            }
            popup.hide();
        }
    });
    popup.show();
};
Core.showPopupModule = function (module, withPopup, withModule) {
    var popup = new Popup();
    popup.module = module;
    popup.title = Core.getLabel("Không tiêu đề");
    popup.data = {};
    if (withPopup != null) withPopup(popup);
    popup.afterLoadControl = function (res, module) { if (withModule != null) withModule(module, popup); };
    popup.show();
};
Core.showPopupModule2 = function (module, title) {
    var popup = new Popup();
    popup.module = module;
    popup.title = Core.getLabel(title);
    popup.show();
};
Core.callEditOfModule = function (moduleName, options) // afterSaveEntity, method, dataPost, dataLoadModule, onloadModule, extendDataSave
{
    if (options == null) options = {};
    if (options.dataLoadModule == null) options.dataLoadModule = {};
    if (options.method == null || options.method == "") options.method = "Edit";

    Core.loadModule(null, moduleName, function (res, module) {
        module.onBeforeInitGrid(function (table) {
            table.showMessageWhenSaveEntitySuccess = true;
            table.hasButtonContinue = false;
        });
        module.afterSaveEntity = function (popupTab, msg, $continue, dataKey, res, data) {
            if (options.afterSaveEntity != null) options.afterSaveEntity(res, msg, module);
        };

        if (options.onLoadModule != null)
            options.onLoadModule(res, module);
    },
        options.dataLoadModule, {
        afterInit: function (res, module) {
            module.table[options.method](options.dataPost, null, null, null, null,
                {
                    extendDataSave: function () {
                        var extendData = { SaleMain: true };
                        if (options.extendDataSave != null) $.extend(extendData, options.extendDataSave);
                        return extendData;
                    }
                });
        }
    });
};
Core.callMethodOfModule = function (moduleName, options) {
    if (options == null) options = {};
    if (options.method == null || options.method == "") return;
    if (options.dataLoadModule == null) options.dataLoadModule = {};

    Core.loadModule(null, moduleName, function (res, module) {
        module.onBeforeInitGrid(function (table) {
            if (module[options.method] == null && table[options.method] == null) table[options.method] = table.createFunction(options.method);
            if (options.onBeforeInit != null) options.onBeforeInit(table);
        });
        module.afterSaveEntity = function (popupTab, msg, $continue, dataKey, res, data) {
            if (options.afterSaveEntity != null) options.afterSaveEntity(res, msg, module);
        };
        if (options.onLoadModule != null) options.onLoadModule(res, module);
    },
        options.dataLoadModule, {
        afterInit: function (res, module) {
            if (module[options.method] != null) module[options.method](options.dataPost);
            else module.table[options.method](options.dataPost);
        }
    });
};
Core.queryFromList = function (data, query, field) {
    if (field == null) field = "Name";
    if (query == null) return data;
    query = query.toLowerCase();
    return Enumerable.From(data).Where(function (item) { return item[field].toLowerCase().indexOf(query) >= 0; }).ToArray();
};
Core.addOnMethod = function (target, funcName, params) {
    var funcNameFirstLetterUpper = funcName.replace(/\b[a-z]/g, function (letter) { return letter.toUpperCase(); });
    target["on" + funcNameFirstLetterUpper] = function (func) {
        var $this = this;
        var oldEvent = $this[funcName];
        var f = "$this." + funcName + " = function(" + params + ")";
        f += "{";
        f += "  ";
        f += " oldEvent.bind($this)(" + params + "); ";
        f += " func.bind($this)(" + params + "); ";
        f += "}";
        eval(f);
    };
};
Core.getTextWidth = function (text, fontsize) {
    if (fontsize == null || fontsize == 0) fontsize = 12;
    var span = $("<span style='font-size:" + fontsize + "px; position:absolute; left:-10000px'>" + text + "</span>");
    $("body").append(span);
    var width = span.width();
    span.remove();
    return width;
};
Core.getBrowser = function () {
    try {
        // Opera 8.0+
        var isOpera = (!!window.opr && !!opr.addons) || !!window.opera || navigator.userAgent.indexOf(' OPR/') >= 0;

        // Firefox 1.0+
        var isFirefox = typeof InstallTrigger !== 'undefined';

        // Safari 3.0+ "[object HTMLElementConstructor]" 
        var isSafari = /constructor/i.test(window.HTMLElement) || (function (p) { return p.toString() === "[object SafariRemoteNotification]"; })(!window['safari'] || safari.pushNotification);

        // Internet Explorer 6-11
        var isIE = /*@cc_on!@*/false || !!document.documentMode;

        // Edge 20+
        var isEdge = !isIE && !!window.StyleMedia;

        // Chrome 1+
        var isChrome = !!window.chrome && !!window.chrome.webstore;

        // Blink engine detection
        var isBlink = (isChrome || isOpera) && !!window.CSS;

        return isOpera ? 'Opera' :
            isFirefox ? 'Firefox' :
                isSafari ? 'Safari' :
                    isChrome ? 'Chrome' :
                        isIE ? 'IE' :
                            isEdge ? 'Edge' :
                                isBlink ? 'Blink' :
                                    "Don't know";
    }
    catch (e) {
        return "Don't know";
    }
};
Core.getYoutubeId = function (url) {
    var regExp = /^.*((youtu.be\/)|(v\/)|(\/u\/\w\/)|(embed\/)|(watch\?))\??v?=?([^#\&\?]*).*/;
    var match = url.match(regExp);
    return (match && match[7].length == 11) ? match[7] : false;
};
Core.showPopupPlayYoutube = function (youtubeId, title) {
    var popup = new Popup();
    popup.title = title;
    popup.content = '<div style="overflow:hidden; text-align:center"><iframe width="560" height="315" src="https://www.youtube.com/embed/' + youtubeId + '" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe></div>';
    popup.show();
};

function Screen() { };
Screen.xsm = "xsm";
Screen.sm = "sm";
Screen.md = "md";
Screen.lg = "lg";
Screen.xl = "xl";

Core.screen = function () {
    var screen = jQuery(window).width();
    if (screen <= 575) return Screen.xsm;
    else if (screen >= 576 && screen <= 767) return Screen.sm;
    else if (screen >= 768 && screen <= 991) return Screen.md;
    else if (screen >= 992 && screen <= 1199) return Screen.lg;
    else if (screen >= 1200) return Screen.xl;
};
Core.onScreen = function (screens) {
    return (function () {
        this.run = function (func) {
            for (var i = 0; i < screens.length; i++) {
                if (screens[i] == Core.screen()) {
                    func();
                    break;
                }
            }
        };
        return this;
    })();
};
!function (a) { a.jCarouselLite = { version: "1.1" }, a.fn.jCarouselLite = function (b) { return b = a.extend({}, a.fn.jCarouselLite.options, b || {}), this.each(function () { function c(a) { return n || (clearTimeout(A), z = a, b.beforeStart && b.beforeStart.call(this, i()), b.circular ? j(a) : k(a), m({ start: function () { n = !0 }, done: function () { b.afterEnd && b.afterEnd.call(this, i()), b.auto && h(), n = !1 } }), b.circular || l()), !1 } function d() { if (n = !1, o = b.vertical ? "top" : "left", p = b.vertical ? "height" : "width", q = B.find(">ul"), r = q.find(">li"), x = r.size(), w = x < b.visible ? x : b.visible, b.circular) { var c = r.slice(x - w).clone(), d = r.slice(0, w).clone(); q.prepend(c).append(d), b.start += w } s = a("li", q), y = s.size(), z = b.start } function e() { B.css("visibility", "visible"), s.css({ overflow: "hidden", "float": b.vertical ? "none" : "left" }), q.css({ margin: "0", padding: "0", position: "relative", "list-style": "none", "z-index": "1" }), B.css({ overflow: "hidden", position: "relative", "z-index": "2", left: "0px" }), !b.circular && b.btnPrev && 0 == b.start && a(b.btnPrev).addClass("disabled") } function f() { t = b.vertical ? s.outerHeight(!0) : s.outerWidth(!0), u = t * y, v = t * w, s.css({ width: s.width(), height: s.height() }), q.css(p, u + "px").css(o, -(z * t)), B.css(p, v + "px") } function g() { b.btnPrev && a(b.btnPrev).click(function () { return c(z - b.scroll) }), b.btnNext && a(b.btnNext).click(function () { return c(z + b.scroll) }), b.btnGo && a.each(b.btnGo, function (d, e) { a(e).click(function () { return c(b.circular ? w + d : d) }) }), b.mouseWheel && B.mousewheel && B.mousewheel(function (a, d) { return c(d > 0 ? z - b.scroll : z + b.scroll) }), b.auto && h() } function h() { A = setTimeout(function () { c(z + b.scroll) }, b.auto) } function i() { return s.slice(z).slice(0, w) } function j(a) { var c; a <= b.start - w - 1 ? (c = a + x + b.scroll, q.css(o, -(c * t) + "px"), z = c - b.scroll) : a >= y - w + 1 && (c = a - x - b.scroll, q.css(o, -(c * t) + "px"), z = c + b.scroll) } function k(a) { 0 > a ? z = 0 : a > y - w && (z = y - w) } function l() { a(b.btnPrev + "," + b.btnNext).removeClass("disabled"), a(z - b.scroll < 0 && b.btnPrev || z + b.scroll > y - w && b.btnNext || []).addClass("disabled") } function m(c) { n = !0, q.animate("left" == o ? { left: -(z * t) } : { top: -(z * t) }, a.extend({ duration: b.speed, easing: b.easing }, c)) } var n, o, p, q, r, s, t, u, v, w, x, y, z, A, B = a(this); d(), e(), f(), g() }) }, a.fn.jCarouselLite.options = { btnPrev: null, btnNext: null, btnGo: null, mouseWheel: !1, auto: null, speed: 200, easing: null, vertical: !1, circular: !0, visible: 3, start: 0, scroll: 1, beforeStart: null, afterEnd: null } }(jQuery);

Core.buildSelectInputChange = function (form) {
    var fire = function (value, changeName) {
        var arr = Enumerable.From(form).ToArray();
        if (form.smallContainer != null) arr = Enumerable.From(arr).Concat(form.smallContainer).ToArray();

        var selects = $(arr).find("select[data-" + changeName + "]");
        selects.each(function () {
            var $this2 = $(this);
            var v = value;
            if (v == null) v = "";
            $this2.attr("data-" + changeName, v);
        });

        var dicSelects = Enumerable.From(selects)
            .Select(function (select, index) { return { select: $(select), index: index, changeName: $(select).attr("data-fire-change"), exclude: false }; }).ToArray();

        // Duyệt tìm những select mà phụ thuộc sẽ loại bỏ không reload
        Enumerable.From(dicSelects)
            .Where(function (dic) { return dic.changeName != null && dic.changeName != ""; })
            .ForEach(function (dic) {
                Enumerable.From(dicSelects).ForEach(function (dic2) {
                    if (dic.index == dic2.index) return;
                    if (dic2.select.attr("data-" + dic.changeName) != null)
                        dic2.exclude = true;
                });
            });

        Enumerable.From(dicSelects)
            .Where(function (dic) { return dic.exclude == false; })
            .ForEach(function (dic) {
                dic.select.reloadSelectInput(null, function () {
                    dic.select.change();
                    dic.select.trigger("after-fire-reload");
                });
            });
    };

    // Các thẻ select change
    form.find("select[data-fire-change]").each(function () {
        var $t = $(this);
        if ($t.attr("data-build-fire-change") == "true") return;
        $t.attr("data-build-fire-change", "true");
        $t.change(function () {
            var $thisValue = $t.val();
            var changeName = $t.attr("data-fire-change"); // Ví dụ là: CompanyId
            fire($thisValue, changeName);
            $t.fireTriggerSearch();
        });
    });

    // Kiểm tra các input date change
    form.find("[data-control-date=true][data-fire-change]").each(function () {
        var $t = $(this);
        if ($t.attr("data-build-fire-change") == "true") return;
        $t.attr("data-build-fire-change", "true");

        var trigger = function () {
            var value = $t.inputDateGetValue();
            var changeNames = $t.attr("data-fire-change").split(',');
            Enumerable.From(changeNames).ForEach(function (changeName) {
                fire(value, changeName);
            });
            $t.fireTriggerSearch();
        };

        $t.inputDateChange(function () { trigger(); });
    });
};
$.fn.fireTriggerSearch = function () {
    this.each(function () {
        var $this = $(this);
        if (this.toFireTriggerSearch != null) clearTimeout(this.toFireTriggerSearch);
        this.toFireTriggerSearch = setTimeout(function () {
            if ($this.attr("data-form-search") != "true") return;
            $this.trigger("form-search");
        });
    });
};

Core.createButton = function (btnInfo, target) {
    var btn = $("<button type='button'>");
    // btn.attr("value", btnInfo.value);
    if (btnInfo.icon != null) btn.append("<span data-button='icon' class='" + btnInfo.icon + "'></span> ");
    btn.append("<span data-button='text'>" + Core.getLabel(btnInfo.value) + "</span>");
    btn.addClass(btnInfo.cls == null || btnInfo.cls == "" ? clsButtonDefault : btnInfo.cls);
    btn.addClass("btn-flat btn-footer");

    if (btnInfo.cssSize == null || btnInfo.cssSize == "") btnInfo.cssSize = "btn-sm";
    btn.addClass(btnInfo.cssSize);
    if (btnInfo.style != null && btnInfo.style != "") btn.attr("style", btnInfo.style);
    if (btnInfo.hotKey != null && btnInfo.hotKey != "") btn.attr("data-hot-key", btnInfo.hotKey);

    btn.btnClick(btnInfo.loading, function (button) { btnInfo.func(button, target); });
    return btn;
};
Core.appendButton = function (element, btnInfo, target) {
    var button = Core.createButton(btnInfo, target);
    if (btnInfo.childs != null && btnInfo.childs.length > 0) {
        var divBtnGroup = $("<div class='btn-group pull-left btn-footer'>");
        divBtnGroup.append(button);

        if (btnInfo.variation != null)
            divBtnGroup.addClass(btnInfo.variation);

        var divBtnGroup2 = $("<div class='btn-group'>");
        divBtnGroup.append(divBtnGroup2);

        var btnCaret = $("<button type='button' class='dropdown-toggle' data-toggle='dropdown' aria-expanded='false'>");
        btnCaret.addClass(btnInfo.cls == null || btnInfo.cls == "" ? clsButtonDefault : btnInfo.cls);
        btnCaret.addClass("btn-flat");

        if (btnInfo.cssSize == null || btnInfo.cssSize == "") btnInfo.cssSize = "btn-sm";
        btnCaret.addClass(btnInfo.cssSize);

        btnCaret.append('<span class="caret"></span>');
        divBtnGroup2.append(btnCaret);

        var ul = $('<ul class="dropdown-menu sub-btn-popup-footer">');
        divBtnGroup2.append(ul);

        for (var i = 0; i < btnInfo.childs.length; i++) {
            var li = $("<li>"); if (i != btnInfo.childs.length - 1) li.css("padding-bottom", "1px");
            ul.append(li);
            var btn = Core.createButton(btnInfo.childs[i], target);
            btn.addClass("cmd-sub-hidden");
            li.append(btn);
        }

        element.append(divBtnGroup);

        button.on("btn-created", function () {
            if (btnInfo.withElement != null)
                btnInfo.withElement(button, ul);
        });
        button.trigger("btn-created");

    }
    else element.append(button);
};
Core.buildButtons = function (element, buttons, target) {
    element.empty();
    Enumerable.From(buttons).ForEach(function (btnInfo, index) {
        if (target.beforeAppendButton != null) target.beforeAppendButton(btnInfo, index);
        Core.appendButton(element, btnInfo, target);
    });
};

var HotKeys = function () {
    var currentHotKeys = [];
    var $document = $(document);

    var blackKeys = ['Ctrl_t', 'Ctrl_o', 'Ctrl_h', 'Ctrl_n', 'Alt_t', 'Ctrl_s', 'Ctrl_f', 'f5', 'f1']; // , 'backspace': Chưa xử lý được ở trên Input
    var aliasKeys = [{ key: "return", alias: "enter" }];

    var timeout = null;
    this.restart = function () {
        if (timeout != null) {
            clearTimeout(timeout);
            timeout == null;
        }

        var $this = this;
        timeout = setTimeout(function () { $this.restartHelper(); timeout = null; }, 1);
    };

    this.binding = false;
    this.restartHelper = function () {
        if (this.binding) return;
        this.binding = true;

        //console.log("restartHelper HotKey");

        Enumerable.From(currentHotKeys).ForEach(function (hotKey) { $document.unbind(hotKey.fullKey); });

        var content = $(".modal[data-popup=true]");
        if (content.length == 0) content = $("body");
        else content = $(content[content.length - 1]);

        var eHotKeys = content.find("[data-hot-key]");
        currentHotKeys = Enumerable.From(eHotKeys)
            .Select(function (ehk) {
                ehk = $(ehk);
                var hotKey = {};
                hotKey.type = ehk.attr("data-type-key");
                switch (hotKey.type) {
                    case "keypress": break;
                    case "keyup": break;
                    case "keydown": break;
                    default: ehk.attr("data-type-key", hotKey.type = "keydown"); break;
                }
                hotKey.key = ehk.attr("data-hot-key");
                hotKey.fullKey = hotKey.type + "." + hotKey.key;

                var textKey = Enumerable.From(hotKey.key.split('_')).Select(function (t) {
                    var findAlias = Enumerable.From(aliasKeys).FirstOrDefault(null, function (ak) { return ak.key == t; });
                    if (findAlias != null) return findAlias.alias.firstLetterUpper();
                    return t.firstLetterUpper();
                }).ToString("+");
                ehk.find('[data-text-key]').remove();
                ehk.html(ehk.html() + "<span data-text-key='true'> (" + textKey + ")</span>");

                ehk.trigger("btn-created");
                return hotKey;
            })
            .GroupBy(function (hotKey) { return hotKey.fullKey; })
            .Select(function (gHotKey) {
                var hotKey = gHotKey.First();
                $document.bind(hotKey.fullKey, function (e) {
                    fire(content, hotKey);

                    e.preventDefault();
                    e.stopPropagation();
                });
                return hotKey;
            })
            .ToArray();

        // Tìm những blackKeys không có trong currentHotKeys => chặn hot key của trình duyệt
        var blackKeysOfNow = Enumerable.From(blackKeys).GroupJoin(currentHotKeys, function (bk) { return "keydown." + bk },
            function (hk) { return hk.fullKey; },
            function (bk, hks) { return { bk: bk, hks: hks }; })
            .Where(function (t) { return t.hks.Count() == 0 })
            .Select(function (t) {
                var hotKey = { fullKey: "keydown." + t.bk, key: t.bk, type: "keydown" };
                $document.bind(hotKey.fullKey, function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                });
                return hotKey;
            }).ToArray();

        currentHotKeys = Enumerable.From(currentHotKeys).Concat(blackKeysOfNow).ToArray();
        this.binding = false;
    };

    var fire = function (content, hotKey) {
        var attr = "[data-hot-key=" + hotKey.key + "][data-type-key=" + hotKey.type + "]";
        var ele = content.find(attr + ":visible");
        if (ele.length > 0) ele.eq(0).click();
        else {
            var ele = content.find(attr + ".cmd-sub-hidden").eq(0);
            if (ele.attr("data-not-allow-key-hidden") != "true")
                ele.click();
        }
        //content.find(attr + ".cmd-sub-hidden," + attr + ":visible").eq(0).click();
    };
};
HotKeys.inst = new HotKeys();

/*
    PDFObject v2.1.1
    https://github.com/pipwerks/PDFObject
    Copyright (c) 2008-2018 Philip Hutchison
    MIT-style license: http://pipwerks.mit-license.org/
    UMD module pattern from https://github.com/umdjs/umd/blob/master/templates/returnExports.js
*/

(function (root, factory) { if (typeof define === 'function' && define.amd) { define([], factory); } else if (typeof module === 'object' && module.exports) { module.exports = factory(); } else { root.PDFObject = factory(); } }(this, function () {
    "use strict"; if (typeof window === "undefined" || typeof navigator === "undefined") { return false; }
    var pdfobjectversion = "2.1.1", ua = window.navigator.userAgent, supportsPDFs, isIE, supportsPdfMimeType = (typeof navigator.mimeTypes['application/pdf'] !== "undefined"), supportsPdfActiveX, isModernBrowser = (function () { return (typeof window.Promise !== "undefined"); })(), isFirefox = (function () { return (ua.indexOf("irefox") !== -1); })(), isFirefoxWithPDFJS = (function () {
        if (!isFirefox) { return false; }
        return (parseInt(ua.split("rv:")[1].split(".")[0], 10) > 18);
    })(), isIOS = (function () { return (/iphone|ipad|ipod/i.test(ua.toLowerCase())); })(), createAXO, buildFragmentString, log, embedError, embed, getTargetElement, generatePDFJSiframe, generateEmbedElement; createAXO = function (type) {
        var ax; try { ax = new ActiveXObject(type); } catch (e) { ax = null; }
        return ax;
    }; isIE = function () { return !!(window.ActiveXObject || "ActiveXObject" in window); }; supportsPdfActiveX = function () { return !!(createAXO("AcroPDF.PDF") || createAXO("PDF.PdfCtrl")); }; supportsPDFs = (!isIOS && (isFirefoxWithPDFJS || supportsPdfMimeType || (isIE() && supportsPdfActiveX()))); buildFragmentString = function (pdfParams) {
        var string = "", prop; if (pdfParams) {
            for (prop in pdfParams) { if (pdfParams.hasOwnProperty(prop)) { string += encodeURIComponent(prop) + "=" + encodeURIComponent(pdfParams[prop]) + "&"; } }
            if (string) { string = "#" + string; string = string.slice(0, string.length - 1); }
        }
        return string;
    }; log = function (msg) { if (typeof console !== "undefined" && console.log) { console.log("[PDFObject] " + msg); } }; embedError = function (msg) { log(msg); return false; }; getTargetElement = function (targetSelector) {
        var targetNode = document.body; if (typeof targetSelector === "string") { targetNode = document.querySelector(targetSelector); } else if (typeof jQuery !== "undefined" && targetSelector instanceof jQuery && targetSelector.length) { targetNode = targetSelector.get(0); } else if (typeof targetSelector.nodeType !== "undefined" && targetSelector.nodeType === 1) { targetNode = targetSelector; }
        return targetNode;
    }; generatePDFJSiframe = function (targetNode, url, pdfOpenFragment, PDFJS_URL, id) { var fullURL = PDFJS_URL + "?file=" + encodeURIComponent(url) + pdfOpenFragment; var scrollfix = (isIOS) ? "-webkit-overflow-scrolling: touch; overflow-y: scroll; " : "overflow: hidden; "; var iframe = "<div style='" + scrollfix + "position: absolute; top: 0; right: 0; bottom: 0; left: 0;'><iframe  " + id + " src='" + fullURL + "' style='border: none; width: 100%; height: 100%;' frameborder='0'></iframe></div>"; targetNode.className += " pdfobject-container"; targetNode.style.position = "relative"; targetNode.style.overflow = "auto"; targetNode.innerHTML = iframe; return targetNode.getElementsByTagName("iframe")[0]; }; generateEmbedElement = function (targetNode, targetSelector, url, pdfOpenFragment, width, height, id) {
        var style = ""; if (targetSelector && targetSelector !== document.body) { style = "width: " + width + "; height: " + height + ";"; } else { style = "position: absolute; top: 0; right: 0; bottom: 0; left: 0; width: 100%; height: 100%;"; }
        targetNode.className += " pdfobject-container"; targetNode.innerHTML = "<embed " + id + " class='pdfobject' src='" + url + pdfOpenFragment + "' type='application/pdf' style='overflow: auto; " + style + "'/>"; return targetNode.getElementsByTagName("embed")[0];
    }; embed = function (url, targetSelector, options) {
        if (typeof url !== "string") { return embedError("URL is not valid"); }
        targetSelector = (typeof targetSelector !== "undefined") ? targetSelector : false; options = (typeof options !== "undefined") ? options : {}; var id = (options.id && typeof options.id === "string") ? "id='" + options.id + "'" : "", page = (options.page) ? options.page : false, pdfOpenParams = (options.pdfOpenParams) ? options.pdfOpenParams : {}, fallbackLink = (typeof options.fallbackLink !== "undefined") ? options.fallbackLink : true, width = (options.width) ? options.width : "100%", height = (options.height) ? options.height : "100%", assumptionMode = (typeof options.assumptionMode === "boolean") ? options.assumptionMode : true, forcePDFJS = (typeof options.forcePDFJS === "boolean") ? options.forcePDFJS : false, PDFJS_URL = (options.PDFJS_URL) ? options.PDFJS_URL : false, targetNode = getTargetElement(targetSelector), fallbackHTML = "", pdfOpenFragment = "", fallbackHTML_default = "<p>This browser does not support inline PDFs. Please download the PDF to view it: <a href='[url]'>Download PDF</a></p>"; if (!targetNode) { return embedError("Target element cannot be determined"); }
        if (page) { pdfOpenParams.page = page; }
        pdfOpenFragment = buildFragmentString(pdfOpenParams); if (forcePDFJS && PDFJS_URL) { return generatePDFJSiframe(targetNode, url, pdfOpenFragment, PDFJS_URL, id); } else if (supportsPDFs || (assumptionMode && isModernBrowser && !isIOS)) { return generateEmbedElement(targetNode, targetSelector, url, pdfOpenFragment, width, height, id); } else if (PDFJS_URL) { return generatePDFJSiframe(targetNode, url, pdfOpenFragment, PDFJS_URL, id); } else {
            if (fallbackLink) { fallbackHTML = (typeof fallbackLink === "string") ? fallbackLink : fallbackHTML_default; targetNode.innerHTML = fallbackHTML.replace(/\[url\]/g, url); }
            return embedError("This browser does not support embedded PDFs");
        }
    }; return { embed: function (a, b, c) { return embed(a, b, c); }, pdfobjectversion: (function () { return pdfobjectversion; })(), supportsPDFs: (function () { return supportsPDFs; })() };
}));

Core.Timer = function (option) {
    if (option == null) option = {};
    if (option.time == null) option.time = 500;

    var to = null;
    this.isRunning = false;

    this.setOption = function (withOption) { if (withOption != null) withOption(option); };

    this.start = function () {
        var $this = this;

        if (this.isRunning) return;
        this.isRunning = true;
        this.onStart();
        var func = function () {
            stopHelper();
            to = setTimeout(function () {
                var result = option.conditionStop != null && option.conditionStop();
                if (result) { clearTimeout(to); to = null; return; };

                if (option.onTimer != null) option.onTimer();
                if ($this.isRunning === true) func();
            }, option.time);
        }
        func();
    }
    this.onStart = function () { }
    this.stop = function () {
        if (this.isRunning == false) return;
        this.isRunning = false;
        stopHelper();
    };
    var stopHelper = function () { if (to != null) { clearTimeout(to); to = null; }; };
}

Core.Tour = function (option) {
    var steps = Enumerable.From(option.area.find("[data-tour]")).Select(function (ele) {
        $ele = $(ele);
        return {
            element: ele,
            title: $ele.attr("data-tour-header"),
            content: $ele.attr("data-tour"),
            placement: $ele.attr("data-tour-position"),
            label: option.area.find("label[data-tour-id=" + $ele.attr("data-tour-ref-id") + "]")
        };
    }).ToArray();

    this.hasTour = function () { return steps.length > 0; };
    var tour = null;
    var createTour = function () {
        if (tour != null) { tour.end(); tour = null; };
        tour = new Tour({
            steps: steps, storage: null, backdrop: true, delay: 100, animation: false, template: function () {
                return '<div class="popover" role="tooltip" style="min-width:250px"> <div class="arrow"></div> <h3 class="popover-title"></h3> <div class="popover-content"></div> <div class="popover-navigation"> <div class="btn-group"> <button class="btn btn-sm btn-default" data-role="prev">&laquo; ' + Core.getLabel("Trước") + '</button> <button class="btn btn-sm btn-default" data-role="next">' + Core.getLabel("Tiếp") + ' &raquo;</button> <button class="btn btn-sm btn-default" data-role="pause-resume" data-pause-text="Pause" data-resume-text="Resume">' + Core.getLabel("Dừng") + '</button> </div> <button class="btn btn-sm btn-default" data-role="end">' + Core.getLabel("Kết thúc") + '</button> </div> </div>';
            }
        });
        tour.init();
    }

    this.init = function () {
        Enumerable.From(steps).ForEach(function (step, index) {
            step.label.click(function () {
                createTour();
                tour.goTo(index);
            });
        });
    }
    this.start = function () {
        createTour();
        tour.start();
    }
    this.end = function () {
        if (tour != null) { tour.end(); tour = null; };
    }
}
Core.color = function (color, opacity) {
    return Chart.helpers.color(color).alpha(opacity).rgbString();
}
Core.isRowEmpty = function (row) { if (row == null) return false; return Enumerable.From(row).All(function (t) { return t == null; }); };
Core.createButtonShowConfigModule = function (module, entityName, options) {
    if (options == null) options = {};
    if (options.bgCss == null) options.bgCss = "bg-maroon";
    if (options.pullCss == null) options.pullCss = "pull-left";

    return {
        value: "Cấu hình", hotKey: "Ctrl_o", icon: "fa fa-cogs", cls: "btn {0} {1}".format(options.bgCss, options.pullCss), func: function (element, scope) {
            Core.showPopupModule("FormSaveConfig",
                function (popupConfig) {
                    popupConfig.title = Core.getLabel("Cấu hình {0}").format(entityName.toLowerCase());
                    popupConfig.data.Module = module;
                },
                function (moduleConfig) {
                    moduleConfig.afterSaveConfig = function (res) {
                        if (options.afterSaveConfig != null) options.afterSaveConfig(res);
                    };
                });
        }
    };
}