String.prototype.format = function ()
{
    var content = this;
    for (var i = 0; i < arguments.length; i++)
    {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        content = content.replace(reg, arguments[i]);
    }
    return content;
};
String.format = function ()
{
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};
String.prototype.toNoSign = function ()
{
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
}
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
Date.prototype.addDays = function (days)
{
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}
Date.prototype.addMinutes = function (minutes)
{
    var date = new Date(this.valueOf());
    date.setMinutes(date.getMinutes() + minutes);
    return date;
}

function Core() { }
Core.goto = function (selector, delta)
{
    if (delta == null) delta = 0;
    if (typeof (selector) == "string") selector = $(selector);
    $('html,body').animate({ scrollTop: selector.offset().top + delta + "px" }, 500);
}
Core.formatDate3 = function (data)
{
    if (data == null || data == "") return "";

    if (typeof (data) == "string") data = Core.getDate(data);
    return String.format("{0}/{1}/{2}",
        data.getDate() < 10 ? "0" + data.getDate() : data.getDate(),
        (data.getMonth() + 1) < 10 ? "0" + (data.getMonth() + 1) : (data.getMonth() + 1),
        data.getFullYear());
}
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
}

Core.random = function (number) { return parseInt(Math.random() * number); };
Core.replace = function (str, s1, s2, ignore) { return str.replace(new RegExp(s1, ignore ? "gi" : "g"), s2); };
Core.getSizeName = function () {
    var screen_size = '', screen_w = jQuery(window).width();
    if (screen_w > 1170) screen_size = "desktop_wide";
    else if (screen_w > 960 && screen_w <= 1169) screen_size = "desktop";
    else if (screen_w > 768 && screen_w <= 959) screen_size = "tablet";
    else if (screen_w > 300 && screen_w <= 767) screen_size = "mobile";
    else if (screen_w <= 300) screen_size = "mobile_portrait";
    return screen_size;
}
Core.isMobile = function ()
{
    var screen_size = Core.getSizeName();
    return screen_size == "mobile" || screen_size == "mobile_portrait";
}
Core.isEmail = function(email) {
    var regex = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return regex.test(email);
}
Core.isPhoneNumber = function(phone) {
    var regex = /[0-9\-\(\)\s]+/;
    return regex.test(phone);
}
Core.getDateFormatVN = function (date)
{
    if (date == undefined || date == "" || date == null) return null;
    var date = date.split('/'); if (date.length < 3) return null;
    var year = date[2].split(' ')[0];
    return new Date(parseInt(year), parseInt(date[1]) - 1, parseInt(date[0]));
}
Core.replace = function (str, s1, s2, ignore)
{
    return str.replace(new RegExp(s1, ignore ? "gi" : "g"), s2)
}
Core.isTablet = function () { return Core.getSizeName() == "tablet"; }
Core.loadModule = function (main, module, func, data, userOverlay, alertWhenFail)
{
    var ajax = new CoreAjax("Common.Modules.ModuleLoader");

    if (userOverlay == null) userOverlay = true; ajax.userOverlay = userOverlay;
    if (alertWhenFail == null) alertWhenFail = true; ajax.alertWhenFail = alertWhenFail;

    var dataPost = { control: module };
    if (data != null) $.extend(dataPost, data);

    ajax.post("LoadModuleByControl", dataPost, function (res)
    {
        if (main != null) main.html(res.Data.ModuleContent);
        Core.getScriptsNeedLoad(res.Data.Scripts, function () { if (func != null) func(res); });
    });
}
$.fn.loadModule = function (module, func, data, options, userOverlay, alertWhenFail) { Core.loadModule(this, module, func, data, options, userOverlay, alertWhenFail); };
Core.notify = function (content, type, time, target) { return new PNotify({ target: target, text: Core.getLabel(content), type: (type == null || type == '' ? 'success' : type), delay: (time == null ? 1000 : time) }); };
Core.alert = function (content, func) { CoreAlert(content, func); };
Core.confirm = function (content, yes, no) { CoreAlertConfirm(content, yes, no); };
Core.getLabel = function(lexicon)
{
    return lexicon;
}
$.fn.btnClick = function (loading, action)
{
    var $this = this;
    this.click(function (e)
    {
        e.preventDefault();
        if (loading) $this.button('loading');
        action($this); // https://bootsnipp.com/snippets/featured/loading-button
    });
    this.done = function () { $this.button('reset'); };
}
Core.cacheScripts = [];
Core.getScriptsNeedLoad = function (scripts, callback)
{
    var paths = Enumerable.From(scripts).GroupJoin(Core.cacheScripts, function (s) { return s.Src; }, function ($) { return $; },
        function (s, cs) { return { s: s, cs: cs }; })
        .Where(function ($) { return $.cs.Count() == 0; }).Select(function ($) { return $.s.Src; }).Distinct().ToArray();

    Core.loadScripts(paths, function () {
        Core.cacheScripts = Enumerable.From(Core.cacheScripts).Concat(paths).ToArray();
        callback();
    });
}
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
    }
    fload(0);
}
Core.buildData = function (name, data, onRow)
{
    var result = {};
    Enumerable.From(data).Select(function (row, index) { result[name + "-" + index] = row; if (onRow != null) onRow(row); }).Count();
    return result;
}
Core.runToCondition = function (condition, timeout)
{
    var to = null;
    var func = function ()
    {
        if (to != null)
        {
            clearTimeout(to);
            to = null;
        }

        to = setTimeout(function ()
        {
            var result = condition();
            if (result)
            {
                clearTimeout(to);
                to = null;
                return;
            }
            func();
        }, timeout);
    }

    func();
}
Core.Module = { ajax: new CoreAjax("Common.Modules.ModuleLoader") };
Core.Module.load = function(module, data, func)
{
    var dataPost = { control: module };
    if (data != null) $.extend(dataPost, data);
    Core.Module.ajax.post("LoadModuleByControl", dataPost, func);
}

function Screen() { };
Screen.xsm = "xsm";
Screen.sm = "sm";
Screen.md = "md";
Screen.lg = "lg";
Screen.xl = "xl";

Core.popup = function (url, event, width, height)
{
    var w = width == null ? 800 : width;
    var h = height == null ? 600 : height;
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var windowName = "popUp";
    var params = "width=" + w + ",height=" + h + ",top=" + top + ",left=" + left;
    var newwin = window.open(url, windowName, params);
    if (event)
        event.preventDefault();
    if (window.focus) { newwin.focus() }
    return newwin;
};
Core.screen = function ()
{
    var screen = jQuery(window).width();
    if (screen <= 575) return Screen.xsm;
    else if (screen >= 576 && screen <= 767) return Screen.sm;
    else if (screen >= 768 && screen <= 991) return Screen.md;
    else if (screen >= 992 && screen <= 1199) return Screen.lg;
    else if (screen >= 1200) return Screen.xl;
};
Core.onScreen = function (screens)
{
    return (function ()
    {
        this.run = function (func)
        {
            for (var i = 0; i < screens.length; i++)
            {
                if (screens[i] == Core.screen())
                {
                    func();
                    break;
                }
            }
        };
        return this;
    })();
};

Core.formatMoney = function (data) {
    if (data == null) return "";
    if (typeof (data) == "string") data = parseFloat(data);
    if (data % 1 != 0) return data.formatMoney(2);
    return data.formatMoney(0);
}
Core.formatMoney2 = function (data) {
    if (data == null) return "";
    if (typeof (data) == "string") data = parseFloat(data);
    if (data % 1 != 0) return data.formatMoney(2);
    return data.formatMoney(2);
}

$.fn.getValues = function (notSelector)
{
    var params = {};

    if (notSelector == undefined || notSelector == null) notSelector = "";

    var normalInput = this.find("input[type='text'][name], input[type='hidden'][name], input[type='password'][name], select[name], textarea[name]");
    if (notSelector != "") normalInput = normalInput.filter(function () { return $(this).parents(notSelector).length == 0; });
    normalInput.each(function () { params[$(this).attr("name")] = $(this).val(); });

    return params;
};
$.fn.fillForm = function (values, notSelector)
{
    if (notSelector == undefined || notSelector == null) notSelector = "";
    for (var key in values)
    {
        var inputNormal = this.find("input[type='hidden'][name='" + key + "'], input[type='text'][name='" + key + "']:not([data-type-date]), input[type='password'][name='" + key + "'], select[name='" + key + "'], textarea[name='" + key + "']");
        if (notSelector != "") inputNormal = inputNormal.filter(function () { return $(this).parents(notSelector).length == 0; });
        inputNormal.val(values[key]);
    }
    return this;
};

$.fn.inputKeypress = function (func, options)
{
    var $this = this;
    var t = null;

    if (options == null) options = {};
    if (options.time == null) options.time = 200;

    var run = function (input) {
        if (t != null) clearTimeout(t);
        t = setTimeout(function () {
            if (input.attr("data-text-current") != input.val()) {
                func($this, input);
                input.attr("data-text-current", input.val());
                input.trigger("sh-text-change");
            }
            t = null;
        }, options.time);
    };

    if (options.onFocus == null) options.onFocus = function ($this) { };
    if (options.onBlur == null) options.onBlur = function ($this) { run($this); };

    //this.on("input", function () { run(); });
    this.focus(function () {
        var $this = $(this);
        $this.attr("data-text-current", $this.val());
        options.onFocus($this);
    });
    this.blur(function () { options.onBlur($(this)); });
    this.keypress(function (event) { run($(this)); });
    this.keyup(function (event) {
        if (event.keyCode == 8 || event.keyCode == 46)
            run($(this));
    });
    this.on("t-back", function () { run($(this)); });
}

$.fn.getValueNumber = function ()
{
    if (this.length == 0) return 0;
    var value = Core.replace(this.val(), ",", "");
    value = $.trim(value);
    if (value == "") return 0;
    return parseFloat(value);
}
$.fn.thumb = function (now) {
    var imgs = this.find("img[data-src]").bind("error", function ()
    {
        var target = $(this);
        var t = target.attr("t");
        if (t == null || t == "") target.attr("t", "1");
        else target.attr("t", eval(t) + 1);

        if (eval(target.attr("t")) >= 2)
        {
            //target.error(function () { });
            target.attr("src", "/Projects/Web/Resources/images/noimage.png");
            var width = target.attr("data-width"); if (width != null && width != "" && width != "0" && width != 0) { width = parseInt(width); target.width(width); }
            var height = target.attr("data-height"); if (height != null && height != "" && height != "0" && height != 0) { height = parseInt(height); target.height(height); }
        }
        else
        {
            // http://images.site.com/thumb/Share/2012/3/25/nbxe_1366033055_w230_h174.jpg
            // /thumb/Share/2012/3/25/nbxe_1366033055_w230_h174.jpg
            var saveFolder = "Thumb";
            var sf = "/" + saveFolder + "/";
            var rex = new RegExp(sf + "(.*)_w([0-9]+)_h([0-9]+)_(c|n).(.*)", "g");

            var path = target.attr("src");
            var path = path.replace(rex, "/w$2h$3/$4_$1.$5");
            target.attr("src", path);
        }
    });

    if (now)
    {
        imgs.each(function ()
        {
            var $this = $(this);
            $this.attr("src", $this.attr("data-src")); $this.removeAttr("data-src");
        });
    }
}
$.fn.reBuildLinkHref = function ()
{
    this.find("a").click(function ()
    {
        var a = $(this);
        var href = a.attr("href");
        if (href == null || href == "") return true;
        if (href.charAt(0) == "/") { ViSon.goto(href); return false; }
        return true;
    });
    return this;
}
// https://stackoverflow.com/questions/995183/how-to-allow-only-numeric-0-9-in-html-inputbox-using-jquery
$.fn.inputFilter = function (inputFilter)
{
    return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function ()
    {
        if (inputFilter(this.value))
        {
            this.oldValue = this.value;
            this.oldSelectionStart = this.selectionStart;
            this.oldSelectionEnd = this.selectionEnd;
        }
        else if (this.hasOwnProperty("oldValue"))
        {
            this.value = this.oldValue;
            this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
        }
        $(this).trigger("input-filter-change");
    });
};
$.fn.bindCmd = function(target, cmd)
{
    if (cmd == null || cmd == "") cmd = "data-cmd";
    this.find('[' + cmd + ']').off("click").click(function () { target[$(this).attr(cmd)].bind(target)($(this)); });
    this.find('select[' + cmd + ']').off("change").change(function () { target[$(this).attr(cmd)].bind(target)($(this)); });
    //this.find('a[' + cmd + '],button[' + cmd + ']').click(function () { target[$(this).attr(cmd)].bind(target)($(this)); });
}

Core.addFbSDK = function()
{
    var sdk = $("script#facebook-jssdk");
    if (sdk.length == 0)
    {
        (function (d, s, id)
        {
            var language = $("[data-language-flag]").attr("data-language-flag");
            if (language == "vn") language = "vi_VN";
            else language = "en_US";

            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/" + language + "/sdk.js#xfbml=1&version=v3.2&appId=513667488723899";
            fjs.parentNode.insertBefore(js, fjs);
        }
        (document, 'script', 'facebook-jssdk'));
        window.fbAsyncInit = function ()
        {
            FB.init({
                appId: "513667488723899",
                status: true,
                xfbml: true,
                cookie: true,
                version: 'v3.2'
            });
        };
    }
}
Core.personType = ["Adult", "Child", "Inf"];

Core.withPersonType = function (action) {
    Enumerable.From(Core.personType).ForEach(function (pt) { action(pt); });
}

$.fn.getQuery = function()
{
    var query = null;
    eval("query = " + this.find("[data-query=page]").html());
    return query;
}

$(function ()
{
    //Core.addFbSDK();
});
$(function ()
{
});

function ViSon() { };
ViSon.goto = function (url) { $.pathchange.changeTo(url); };
ViSon.DefaultPageLoad = function ()
{
    this.container = null;
    this.content = null;
    this.page = null;
    this.query = null;
    this.load = function ()
    {
        if (this.content != null)
        {
            var fbroot = this.container.find("#fb-root");
            this.container.html(this.content.html());
            //this.container.attr("data-time-" + Core.random(9999), new Date());
            this.container.prepend(fbroot);
            this.container.removeAttr("class").removeAttr("style");

            var head = $("head");
            head.find("meta").remove();
            head.append(this.page.find("meta"));

            var gaid = head.find("meta[name=gaid]").attr("content");
            try { gtag('config', gaid, { 'page_title': document.title, 'page_path': window.location.pathname + window.location.search }); }
            catch(e) {}
        }
        //$('html,body').animate({ scrollTop: 0 });
        $(window).scrollTop(0);

        this.container.reBuildLinkHref();
        this.container.thumb(true);

        var $this = this;
        
        this.container.find("[data-control-load]").each(function ()
        {
            var $$this = $(this);
            var ff = $this[$$this.attr("data-control-load")];
            if (ff != null) setTimeout(function () { ff.bind($this)($$this); });
        });
        
        this.container.bindCmd(this);
        this.onLoad();

        this.container.find("[data-control-afterLoad]").each(function ()
        {
            var $$this = $(this);
            var ff = $this[$$this.attr("data-control-afterLoad")];
            if (ff != null) setTimeout(function () { ff.bind($this)($$this); });
        });
    }
    this.onLoad = function () { }
    this.unLoad = function ()
    {
        var $this = this;
        this.container.find("[data-control-unLoad]").each(function ()
        {
            var $$this = $(this);
            var ff = $this[$$this.attr("data-control-unLoad")];
            if (ff != null) ff($$this);
        });
    }
    this.afterUnload = function () { };
    this.commentFb = function (element) { if (this.ajaxLoading) FB.XFBML.parse(element[0]); };
}
ViSon.DefaultPageLoadInstance = function () { return new ViSon.DefaultPageLoad(); }
ViSon.reloadPage = function()
{
    $(window).trigger("pathchange");
}
// https://developers.google.com/analytics/devguides/collection/gtagjs/pages
$.fn.shScrollHeader = function (options)
{
    if (options == null) options = {};

    var $window = $(window), $stickies;

    this.each(function ()
    {
        var $thisSticky = $(this);
        var parents = $thisSticky.parents(".sh-stick-followWrap");
        if (parents.length > 0)
        {
            parents.after($thisSticky);
            parents.remove();
        }

        $thisSticky.css("top", "");
        $thisSticky.removeClass("sh-follow");
        $thisSticky.removeClass("sh-fixed");
        $thisSticky.removeClass("sh-absolute");
        $thisSticky.css("width", "");
        $thisSticky.attr("data-sticky-width", "");
    });

    $stickies = this.each(function ()
    {
        var $thisSticky = $(this).addClass("sh-follow");

        var aWidth = $thisSticky.attr("data-sticky-width");
        if (aWidth == null || aWidth == "")
        {
            var aWidth = $thisSticky.width();
            $thisSticky.attr("data-sticky-width", aWidth);
            $thisSticky.width(aWidth);
        }

        $thisSticky = $thisSticky.wrap('<div class="sh-stick-followWrap" />');
        $thisSticky
            .data('originalPosition', $thisSticky.offset().top)
            .data('originalHeight', $thisSticky.outerHeight())
            .parent()
            .height($thisSticky.outerHeight());
    });

    if (options.offsetTop == null) options.offsetTop = this.eq(0).offset().top + 3;

    var _whenScrolling = function ()
    {
        $stickies.each(function (i)
        {
            var $thisSticky = $(this), $stickyPosition = $thisSticky.data('originalPosition');
            if ($stickyPosition <= $window.scrollTop()) // Kéo xuống
            {
                var $nextSticky = $stickies.eq(i + 1), $nextStickyPosition = $nextSticky.data('originalPosition') - $thisSticky.data('originalHeight') - options.offsetTop;                
                $thisSticky.addClass("sh-fixed");
                if ($nextSticky.length > 0 && $thisSticky.offset().top >= $nextStickyPosition)
                {
                    $thisSticky.addClass("sh-absolute").css("top", $nextStickyPosition);
                }
            }
            else
            {
                var $prevSticky = $stickies.eq(i - 1);
                $thisSticky.removeClass("sh-fixed");
                if ($prevSticky.length > 0 && $window.scrollTop() <= $thisSticky.data('originalPosition') - $thisSticky.data('originalHeight'))
                {
                    $prevSticky.removeClass("sh-absolute").css("top", "");
                }
            }
        });
    };

    $window.off("scroll.stickies").on("scroll.stickies", function () { _whenScrolling(); });

    _whenScrolling();
}

$.fn.shUnScrollHeader = function ()
{
    $(window).off("scroll.stickies");

    this.each(function ()
    {
        var $thisSticky = $(this);
        var parents = $thisSticky.parents(".sh-stick-followWrap");
        if (parents.length > 0)
        {
            parents.after($thisSticky);
            parents.remove();
        }

        $thisSticky.removeClass("sh-follow");
        $thisSticky.removeClass("sh-fixed");
        $thisSticky.removeClass("sh-absolute");

        $thisSticky.css("top", "");
        $thisSticky.attr("data-op", $thisSticky.offset().top);
    });
}