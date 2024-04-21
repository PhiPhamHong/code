function Popup()
{
    this.template = '<div class="modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-popup="true"> \
          <div class="modal-dialog"> \
            <div class="modal-content"> \
              <div class="modal-header"> \
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> \
                <h4 class="modal-title"></h4> \
              </div> \
              <div class="modal-body"></div> \
              <div class="modal-footer"></div> \
            </div> \
          </div> \
        </div>';

    this.modal = null;                                          // Biến lưu trữ modal đang mở
    this.popupBody = null;                                      // Biến lưu trữ element nội dung popup
    this.header = null;                                         // Biến lưu trữ header của popup
    this.footer = null;                                         // Biến lưu trữ footer của popup
    this.dialogType = "";
    this.loadContentWhenShow = false;                           // Định nghĩa xem là mỗi lần hiển thị thì có lấy lại nội dung hay không
    this.clearWhenHide = true;                                  // Có xóa toàn bộ modal khỏi body khi tắt không
    var ajax = new CoreAjax(); ajax.typeAction = "Main";        // Đối tượng gọi hàm trên server     
    this.data = {};                                             // Dữ liệu cần gửi đi lên server để lấy nội dung popup

    // control,module,content là 3 thuộc tính quyết định nên nội dung của popup
    this.control = "";                                          // Control chứa nội dung popup ở trên server
    this.module = "";                                           // Module được cấu hình trong menu.config
    this.content = "";                                          // Nội dung của popup - có thể là một function

    this.title = "";                                            // Tiêu đề của popup
    this.minimized = false;                                     // Có button thu nhỏ không
    this.canFullScreen = false;                                 // Có button phóng to form hay không
    this.fullScreen = false;                                    // Có phóng to lúc mở popup
    this.fullScreenHeightScroll = false;
    this.parentFormKeys = null;                                 // Form cha có sử dụng phím nóng
    this.formKeys = null;                                       // Đối tượng control phím nóng của popup

    this.whenToogleFullScreen = null;                           // Sự kiện khi thay đổi màn hình từ full sang bình thường, từ bình thường sang full

    var clsButtonDefault = "btn btn-primary";
    var btnCancel = { value: "Thoát", hotKey: "esc", icon: "fas fa-times-circle", cls: "btn bg-purple cmd-cancel", func: function (element, scope) { scope.modal.find(".modal-header .close").click(); } };
    this.buttons = []; //this.buttons.push(btnCancel);

    this.resetButtonDefault = function() { this.buttons = []; this.buttons.push(btnCancel); }
    this.resetButtonDefault();

    // Sự kiện luôn thực hiện mỗi lần hiển thị popup
    this.onAlwaysShow = null;
    var alwaysShow = function () 
    {
        if (this.onAlwaysShow != null) this.onAlwaysShow();

        if (this.module == "") // Load module xong tự restart key rồi
            HotKeys.inst.restart(); // Restart key

        var firstInput = this.popupBody.find("input").eq(0);
        if (firstInput.attr("data-type-date") != "true") firstInput.focus();

        this.popupBody.buildAllToogleOption();
        Core.buildFormSearchByCompanyId(this.popupBody);
        this.popupBody.buildInputCurrencyMoney(this.popupBody);

        var tour = new Core.Tour({ area: this.popupBody });
        if (tour.hasTour()) {
            tour.init();

            var aTour = $("<a title='" + Core.getLabel("Trợ giúp") + "' style='position: absolute;right: 70px;top: 12px;font-size: 18px;'><i class='fa fa-question-circle text-purple'></i></a>"); this.header.append(aTour);
            aTour.click(function () { tour.start(); });
        }
    }

    // Sự kiện sau khi tải control
    this.afterLoadControl = null;

    // Sự kiện khi tắt popup
    this.onHide = null;
    this.dataAfterHide = null;
    this.beforHide = function () {

    }
    var fireHide = function () 
    {
        this.beforHide();
        if (this.onHide != null) this.onHide();   
    }

    var currentTypeShowModal = true;
    var currentTop = null;
    var currentLeft = null;

    this.resetContent = function(content)
    {
        this.popupBody.removeAttr("data-has-be-nice");
        this.popupBody.html("");
        this.popupBody.append("<div class='row'><div class='col-xs-12'><div class='popup-area-msg'></div></div></div>");
        this.popupBody.append(content);
    }

    // Hiển thị Popup
    this.show = function (isModal, top, left) 
    {
        if (isModal == null || isModal) isModal = true;
        currentTypeShowModal = isModal;

        // Vị trí popup cần hiển thị
        currentTop = top;
        currentLeft = left;

        // clear lại toàn bộ nếu như có yêu cầu tạo mới lại nội dung mỗi lần hiển thị
        if (this.loadContentWhenShow && this.modal != null) clearModal.bind(this)();
        getModal.bind(this)();

        if (this.loadContentWhenShow || this.popupBody.html() == "") 
        {
            // Load nội dung theo control
            if (this.control != "") 
            {
                var $this = this;
                var data = typeof ($this.data) == "function" ? $this.data() : $this.data; $.extend(data, { boxtype: $this.control });
                ajax.post("LoadBox", data, function (res)
                {
                    $this.resetContent(res.Data.BoxContent)
                    if ($this.afterLoadControl != null) $this.afterLoadControl(res);
                    $this.popupBody.buildInputCurrencyMoney($this.popupBody);
                    doShow.bind($this)(true);
                });
            }

            // Load nội dung theo Module
            else if(this.module != "")
            {
                var $this = this;
                var data = typeof ($this.data) == "function" ? $this.data() : $this.data; $.extend(data, { boxtype: $this.control });
                $this.popupBody.loadModule($this.module, function (res, module) 
                {
                    if (module != null)
                    {
                        module.typeAction = res.Data.ModuleTypeAction;
                        module.assembly = res.Data.ModuleProject;
                        module.popup = $this;
                    }
                    $this.popupBody.prepend("<div class='row'><div class='col-xs-12'><div class='popup-area-msg'></div></div></div>");
                    if ($this.afterLoadControl != null) $this.afterLoadControl(res, module);
                    
                    doShow.bind($this)(true);
                }, data, {
                    afterInit: function ()
                    {
                        $this.popupBody.buildInputCurrencyMoney($this.popupBody);
                    }
                });
            }

            // Theo nội dung có sẵn
            else
            {
                this.popupBody.append("<div class='row'><div class='col-xs-12'><div class='popup-area-msg'></div></div></div>");
                this.popupBody.append(typeof (this.content) == "function" ? this.content() : (this.content == "" ? " " : this.content));
                doShow.bind(this)(true);
            }
        }
        else doShow.bind(this)(false);
    }

    // Tắt Popup
    this.hide = function () 
    {
        if (this.modal == null) return;
        this.modal.modal('hide'); 
    }

    // Hiển thị thông báo
    this.showMsg = function (msg, title, timeOut, type)
    {
        if(this.fullScreen)
        {
            Core.notify(msg, type, 2000, this.popupBody);
        }
        else
        {
            //var divMsg = this.popupBody.find(".popup-area-msg");
            //divMsg.empty();
            //divMsg.coreAlert(msg, title, timeOut, type);
            Core.notify(msg, type, 2000, this.popupBody);
        }
    }

    this.showMsgSuccess = function (msg) { this.showMsg(msg, null, null, alertType.alertSuccess); }
    this.showMsgError = function (msg) { this.showMsg(msg, null, null, alertType.alertDanger); }

    this.resetTitle = function()
    {
        this.header.html(typeof (this.title) == "function" ? this.title() : (this.title == "" ? " " : this.title));
    }

    this.setTitle = function(title)
    {
        this.title = title;
        this.resetTitle();
    }

    this.resetButtons = function()
    {
        var $this = this;
        $this.footer.empty();
        Enumerable.From($this.buttons).ForEach(function (btnInfo) { $this.appendButton(btnInfo); });
    }

    this.appendButton = function(btnInfo)
    {
        var button = this.createButton(btnInfo);
        if (btnInfo.childs != null && btnInfo.childs.length > 0)
        {
            var divBtnGroup = $("<div class='btn-group pull-left' style='margin-right: 5px'>");
            divBtnGroup.append(button);

            var divBtnGroup2 = $("<div class='btn-group'>");
            divBtnGroup.append(divBtnGroup2);

            var btnCaret = $("<button type='button' class='dropdown-toggle' data-toggle='dropdown' aria-expanded='false'>");
            btnCaret.addClass(btnInfo.cls == null || btnInfo.cls == "" ? clsButtonDefault : btnInfo.cls);
            btnCaret.addClass("btn-flat btn-sm");
            btnCaret.append('<span class="caret"></span>');
            divBtnGroup2.append(btnCaret);

            var ul = $('<ul class="dropdown-menu sub-btn-popup-footer">');
            divBtnGroup2.append(ul);

            for (var i = 0; i < btnInfo.childs.length; i++)
            {
                var li = $("<li>"); if (i != btnInfo.childs.length - 1) li.css("padding-bottom", "1px");
                ul.append(li);
                var btn = this.createButton(btnInfo.childs[i]);
                btn.addClass("cmd-sub-hidden");
                li.append(btn);
            }

            this.footer.append(divBtnGroup);
        }
        else this.footer.append(button);
    }

    // Thực hiện hiển thị popup
    var doShow = function (first) 
    {
        var $this = this;
        if (first) this.resetButtons();
        this.resetTitle();
        
        if(this.minimized)
        {
            var buttonMinimized = $('<button class="close" data-widget="collapse" style="margin-right: 5px; font-size:15px; margin-top:1px"><span aria-hidden="true"><i class="fas fa-minus"></i></span></button>');
            buttonMinimized.click(function()
            {
                if($(this).find("i").hasClass("fa-minus"))
                {
                    $(this).find("i").removeClass("fa-minus").addClass("fa-plus");
                    $this.modal.attr("data-height", $this.modal.find(".modal-content").height());
                    $this.modal.height($this.header.parent().height());

                    $this.popupBody.hide(); $this.footer.hide();
                }
                else
                {
                    $(this).find("i").removeClass("fa-plus").addClass("fa-minus");
                    $this.popupBody.show(); $this.footer.show();
                    $this.modal.height($this.modal.attr("data-height"));
                    $this.modal.removeAttr("data-height");
                }
            });
            buttonMinimized.insertBefore(this.header);
        }

        if(this.canFullScreen)
        {
            var buttonFullScreen = $('<button class="close" data-widget="collapse" style="margin-right: 5px; font-size:15px; margin-top:2px"><span aria-hidden="true"><i class="fas fa-plus"></i></span></button>');
            buttonFullScreen.click(function () 
            {
                if ($this.modal.hasClass("modal-fullscreen")) setUnFullScreen.bind($this)();
                else setFullScreen.bind($this)();
                if ($this.whenToogleFullScreen != null) $this.whenToogleFullScreen();
            });
            buttonFullScreen.insertBefore(this.header);
        }

        if (currentTypeShowModal) 
        {
            if(this.fullScreen)
                $this.modal.modal({ backdrop: false }).modal('show');
            else 
                $this.modal.modal({ backdrop: "static" }).modal('show');
        }
        else
        {
            // Tính toán cho ra giữa nếu như không có tọa độ ban đầu
            
            $this.modal.removeClass("modal").css("position", "fixed");
            if (currentTop == null) currentTop = ($(window).height() - $this.modal.height()) / 2;
            if (currentLeft == null) currentLeft = ($(window).width() - $this.modal.width()) / 2;

            $this.modal.css("top", currentTop).css("left", currentLeft).css("z-index", 10000);
            $this.modal.trigger("shown.bs.modal");
            $this.modal.find('[data-dismiss="modal"]').click(function()
            {
                $this.modal.hide();
                $this.modal.trigger("hidden.bs.modal");
            });

            $this.modal.find(".modal-content").attr("style", "box-shadow:0 3px 9px rgba(0,0,0, 0.8) !important");
        }

        if ($this.fullScreen != true)
            $this.modal.find(".modal-content").draggable({ handle: $this.header }); $this.header.css("cursor", "move");
    }

    this.createButton = function(btnInfo)
    {
        var $this = this;
        var btn = $("<button type='button'>");
        // btn.attr("value", btnInfo.value);
        if (btnInfo.icon != null) btn.append("<span class='" + btnInfo.icon + "'></span> ");
        btn.append(Core.getLabel(btnInfo.value));
        btn.addClass(btnInfo.cls == null || btnInfo.cls == "" ? clsButtonDefault : btnInfo.cls);
        btn.addClass("btn-flat btn-sm");

        if (btnInfo.hotKey != null && btnInfo.hotKey != "") btn.attr("data-hot-key", btnInfo.hotKey);

        btn.btnClick(btnInfo.loading, function (button) { btnInfo.func(button, $this); });
        return btn;
    }

    var setFullScreen = function(onShow)
    {   
        if (Core.isMobile() || Core.isTablet()) return;

        if (this.fullScreenHeightScroll)
        {
            this.modal.css("width", "100%").css("top", "0px").css("right", "0px").css("position", "absolute").css("margin", "0px");
            this.modal.find(".modal-content").attr("data-abc", $(window).height());

            this.modal.find(".modal-dialog").css("width", "100%").css("top", "0px").css("left", "0px").css("position", "absolute").css("margin", "0px");
            this.modal.height("height", $(window).height());
            this.popupBody.css("overflow", "auto").css("height", $(window).height() - 46 - 26 - 35).css("padding-bottom", "0px");
        }
        else
        {
            this.modal.addClass("modal-fullscreen");
            var wHeight = this.modal.outerHeight();
            var hHeight = this.header.parent().outerHeight();
            var fHeight = this.footer.outerHeight();
            this.popupBody.outerHeight(wHeight - hHeight - fHeight);
        }
    }

    var setUnFullScreen = function()
    {
        if (Core.isMobile() || Core.isTablet()) return;
        this.modal.removeClass("modal-fullscreen");
        this.popupBody.height("auto");
    }

    // Hàm thực hiện khởi tạo modal
    var getModal = (function ()
    {
        var $this = this;
        if ($this.modal != null) return;
        $this.modal = $($this.template); $this.modal.attr("data-popup-id", Core.random(9999));
        $("body").append($this.modal);
        $this.popupBody = $this.modal.find(".modal-body");
        
        $this.afterCreatePopupBody();

        $this.header = $this.modal.find(".modal-title");
        $this.footer = $this.modal.find(".modal-footer");
        $this.modal.on("shown.bs.modal", function () 
        { 
            if ($this.fullScreen) setFullScreen.bind($this)(true);
            alwaysShow.bind($this)(); 
        });
        $this.modal.on("hidden.bs.modal", function () 
        { 
            fireHide.bind($this)(); 
            if ($this.clearWhenHide) clearModal.bind($this)();
            HotKeys.inst.restart();
        });
        $this.modal.find(".modal-dialog").addClass($this.dialogType);
    });

    this.afterCreatePopupBody = function () { };

    var clearModal = function()
    {
        var $this = this;        
        $this.modal.remove(); $this.modal = null; 
    }
};

// Hiển thị thông báo
function CoreAlert(msg, callback) { return CoreAlertConfirm(Core.getLabel(msg), null, callback); }

Popup.NewButton = function (value, cls, icon, func)
{
    return { value: value, cls: cls, icon: icon, func: func };
}

// Hiển thị confirm
function CoreAlertConfirm(msg, yes, no)
{
    var popup = new Popup();
    popup.title = Core.getLabel("Thông báo");
    popup.content = Core.getLabel(msg);
    popup.clearWhenHide = true;
    popup.dialogType = "modal-sm";
    var yesClick = false;
    if (no != null) popup.onHide = function () { if (!yesClick) no(); };
    if (yes != null) popup.buttons.push({ value: Core.getLabel("Đồng ý"), hotKey: "return", icon: "fa fa-thumbs-o-up", cls: "btn btn-primary pull-left", func: function (element, scope) { yes(element, scope); yesClick = true; popup.hide(); } });
    popup.show();
    return popup;
}

function Panel(option)
{
    if (option == null) option = {};

    this.panel = null;
    this.header = null;
    this.content = null;
    this.footer = null;

    this.showing = false;

    this.show = function()
    {
        if (this.panel != null) 
        {
            this.panel.show();
            afterShow.bind(this)();
            return;
        }
        this.build();
        afterPanelCreated.bind(this)(this.header, this.content, this.footer);
        this.panel.benice();

        afterShow.bind(this)();
    }

    this.hide = function ()
    {
        if (this.panel != null)
        {
            this.panel.hide();
        }
        this.showing = false;
    }

    this.afterExit = function () {}

    this.build = function()
    {
        var $this = this;
        this.panel = $("<div style='width: " + this.getOption("width", 600) + "px; position: absolute; background-color: white;z-index: 99999;border: solid 1px #cecece; font-size: 12px'>");;
        if (option.container == null) option.container = $("body");
        option.container.append(this.panel);
        
        var top = this.getOption("top", "-"); if (top != "-") this.panel.css("top", top);
        var right = this.getOption("right", "-"); if (right != "-") this.panel.css("right", right);
        var left = this.getOption("left", "-"); if (left != "-") this.panel.css("left", left);
        var bottom = this.getOption("bottom", "-"); if (bottom != "-") this.panel.css("bottom", bottom);

        var divHeader = $("<div style='overflow:hidden;border-bottom: solid 1px cecece;cursor:move'>"); 
        this.panel.append(divHeader);
        divHeader.append("<h5 style='margin: 5px; font-weight:bold; font-size: 12px'>" + this.getOption("title", Core.getLabel("Chưa có tiêu đề")) + "</h5>");

        this.panel.draggable({ handle: divHeader });
        var divContent = $("<div style='float:left;width:100%;border-bottom: solid 1px cecece;padding:10px'>"); 
        this.panel.append(divContent);

        divContent.append(this.getOption("content"));
        var divFooter = $("<div style='float:left;width:100%'>"); 
        this.panel.append(divFooter);
        divFooter.append("<input type='button' class='btn btn-xs btn-primary' style='float:right; margin: 2px' value='"+ Core.getLabel("Thoát") +"' />");
        divFooter.find("input").click(function () { $this.panel.hide(); $this.afterExit(); });

        this.header = divHeader;
        this.content = divContent;

        if (this.getOption("showFooter", true) == false) divFooter.hide();
        this.footer = divFooter;
    }

    var afterShow = function()
    {
        this.showing = true;
        if (option.shown != null) option.shown();
        if (this.shown != null) this.shown();
    }
    var afterPanelCreated = function(header, content, footer)
    {
        if (option.created != null) option.created(header, content, footer);
    }
    this.getOption = function(name, defaultValue)
    {
        var value = option[name];
        if (value == null) return (defaultValue == null ? "" : defaultValue);
        if (typeof (value) == "function") return value();
        return value;
    }
}

function BoxPanel(option)
{
    $.extend(this, new Panel(option));

    this.build = function()
    {
        var $this = this;

        this.panel = $('<div style="width:' + this.getOption("width", 453) + 'px;position: absolute; z-index:99999"></div>');
        if (option.container == null) option.container = $("body");
        option.container.append(this.panel);

        var top = this.getOption("top", "-"); if(top != "-") this.panel.css("top", top);
        var right = this.getOption("right", "-"); if(right != "-") this.panel.css("right", right);
        var left = this.getOption("left", "-"); if(left != "-") this.panel.css("left", left);
        var bottom = this.getOption("bottom", "-"); if(bottom != "-") this.panel.css("bottom", bottom);

        var divBox = $('<div class="box box-danger box-solid"></div>'); this.panel.append(divBox);

        // Header 
        var divHeader = $('<div class="box-header with-border">'); 
        divBox.append(divHeader);

        divHeader.append('<h3 class="box-title">' + this.getOption("title", Core.getLabel("Chưa có tiêu đề")) + '</h3>');
        var divHeaderBoxTools = $('<div class="box-tools pull-right">'); divHeader.append(divHeaderBoxTools);
        var btnCollapse = $('<button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>'); divHeaderBoxTools.append(btnCollapse);

        if(this.getOption("btnRemove", true))
        {
            var btnRemove = $('<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>'); 
            divHeaderBoxTools.append(btnRemove);
            btnRemove.data("confirm", this.getOption("confirmRemove", ""));
            btnRemove.on("box-panel-removed", function () 
            { 
                if (option.afterRemoved != null) option.afterRemoved(); 
            });
        }

        this.panel.draggable({ handle: divHeader });

        // Content
        var divContent = $('<div class="box-body">'); 
        divBox.append(divContent);
        divContent.append(this.getOption("content"));

        // Footer
        var divFooter = $('<div class="box-footer">'); 
        divBox.append(divFooter);

        $.AdminLTE.boxWidget.activate(this.panel);

        this.header = divHeader;
        this.content = divContent;
        this.footer = divFooter;
    }
}