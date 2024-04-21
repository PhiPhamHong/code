/// <reference path="linq.js" />

function Popup() {
    this.template = '  <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true"> \
          <div class="modal-dialog"> \
            <div class="modal-content"> \
              <div class="modal-header"> \
                <h5 class="modal-title"></h5> \
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> \
              </div> \
              <div class="modal-body"></div> \
              <div class="modal-footer"></div> \
            </div> \
          </div> \
        </div>';

    this.modal = null;                                              // Biến lưu trữ modal đang mở
    this.popupBody = null;                                          // Biến lưu trữ element nội dung popup
    this.header = null;                                             // Biến lưu trữ header của popup
    this.footer = null;                                             // Biến lưu trữ footer của popup
    this.dialogType = "";
    this.loadContentWhenShow = false;                               // Định nghĩa xem là mỗi lần hiển thị thì có lấy lại nội dung hay không
    this.clearWhenHide = true;                                      // Có xóa toàn bộ modal khỏi body khi tắt không
    var ajax = new CoreAjax(); ajax.typeAction = "Common.Modules.ModuleLoader";  // Đối tượng gọi hàm trên server     
    this.data = {};                                                 // Dữ liệu cần gửi đi lên server để lấy nội dung popup

    // control,module,content là 3 thuộc tính quyết định nên nội dung của popup
    this.control = "";                                          // Control chứa nội dung popup ở trên server
    this.module = "";                                           // Module được cấu hình trong menu.config
    this.content = "";                                          // Nội dung của popup - có thể là một function
    this.currentRes = null;

    this.title = "";                                            // Tiêu đề của popup
    this.minimized = false;                                     // Có button thu nhỏ không
    this.canFullScreen = false;                                 // Có button phóng to form hay không
    this.fullScreen = false;                                    // Có phóng to lúc mở popup
    this.parentFormKeys = null;                                 // Form cha có sử dụng phím nóng
    this.formKeys = null;                                       // Đối tượng control phím nóng của popup

    this.whenToogleFullScreen = null;                           // Sự kiện khi thay đổi màn hình từ full sang bình thường, từ bình thường sang full

    var clsButtonDefault = "btn btn-primary";
    var btnCancel = { value: "Thoát", icon: "fa fa-sign-out", cls: "btn btn-secondary cmd-cancel", func: function (element, scope) { scope.modal.find(".modal-header .close").click(); } };
    this.buttons = []; //this.buttons.push(btnCancel);

    this.resetButtonDefault = function() { this.buttons = []; this.buttons.push(btnCancel); }
    this.resetButtonDefault();

    // Sự kiện luôn thực hiện mỗi lần hiển thị popup
    this.onAlwaysShow = null;
    var alwaysShow = function () 
    {
        if (this.onAlwaysShow != null) this.onAlwaysShow();
        
        this.popupBody.bindCmd(this);
        var firstInput = this.popupBody.find("input").eq(0);
        firstInput.focus();
    }

    // Sự kiện sau khi tải control
    this.afterLoadControl = null;

    // Sự kiện khi tắt popup
    this.onHide = null;
    var fireHide = function () 
    {
        if (this.onHide != null) this.onHide();
    }

    var currentTypeShowModal = true;
    var currentTop = null;
    var currentLeft = null;

    this.resetContent = function(content)
    {
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
                var data = typeof ($this.data) == "function" ? $this.data() : $this.data; $.extend(data, { control: $this.control });
                ajax.post("LoadModuleByControl", data, function (res)
                {
                    $this.resetContent(res.Data.ModuleContent)
                    $this.currentRes = res;
                    if ($this.afterLoadControl != null) $this.afterLoadControl(res);
                    doShow.bind($this)(true);
                });
            }

            // Load nội dung theo Module
            else if(this.module != "")
            {
                var $this = this;
                var data = typeof ($this.data) == "function" ? $this.data() : $this.data; $.extend(data, {});
                $this.popupBody.loadModule($this.module, function (res) 
                {
                    $this.popupBody.prepend("<div class='row'><div class='col-xs-12'><div class='popup-area-msg'></div></div></div>");
                    $this.currentRes = res;
                    if ($this.afterLoadControl != null) $this.afterLoadControl(res);
                    doShow.bind($this)(true);
                }, data);
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
            Core.notify(msg, type, 2000, this.popupBody);
        }
    }

    this.showMsgSuccess = function (msg) { this.showMsg(msg, null, null, alertType.alertSuccess); }
    this.showMsgError = function (msg) { this.showMsg(msg, null, null, alertType.alertDanger); }

    this.resetTitle = function()
    {
        this.setTitle(typeof (this.title) == "function" ? this.title() : (this.title == "" ? " " : this.title));        
    }

    this.setTitle = function (title) { this.header.html(title); };

    this.resetButtons = function()
    {
        var $this = this;
        $this.footer.empty();
        Enumerable.From($this.buttons).ForEach(function (btnInfo) { $this.appendButton(btnInfo); });
    }

    this.appendButton = function(btnInfo)
    {
        this.footer.append(this.createButton(btnInfo));
    }

    // Thực hiện hiển thị popup
    var doShow = function (first) 
    {
        var $this = this;
        if (first) this.resetButtons();
        this.resetTitle();
        
        if(this.minimized)
        {
            var buttonMinimized = $('<button class="close" data-widget="collapse" style="margin-right: 5px; font-size:15px; margin-top:1px"><span aria-hidden="true"><i class="fa fa-minus"></i></span></button>');
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
            var buttonFullScreen = $('<button class="close" data-widget="collapse" style="margin-right: 5px; font-size:15px; margin-top:2px"><span aria-hidden="true"><i class="fa fa-square-o"></i></span></button>');
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
        //$this.modal.find(".modal-content").draggable({ handle: $this.header }); $this.header.css("cursor", "move");
    }

    this.createButton = function(btnInfo)
    {
        var $this = this;
        var btn = $("<button type='button'>");
        // btn.attr("value", btnInfo.value);
        if (btnInfo.icon != null)
            btn.append("<span class='" + btnInfo.icon + "'></span> ");
        btn.append(Core.getLabel(btnInfo.value));
        btn.addClass(btnInfo.cls == null || btnInfo.cls == "" ? clsButtonDefault : btnInfo.cls);
        //btn.addClass("btn-flat btn-sm");
        btn.addClass("btn-flat");
        btn.btnClick(btnInfo.loading, function (button) { btnInfo.func(button, $this); });
        return btn;
    }

    var setFullScreen = function(onShow)
    {   
        if (Core.isMobile() || Core.isTablet()) return;
        this.modal.addClass("modal-fullscreen");
        var wHeight = this.modal.outerHeight();
        var hHeight = this.header.parent().outerHeight();
        var fHeight = this.footer.outerHeight();
        this.popupBody.outerHeight(wHeight - hHeight - fHeight);
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
        $this.modal = $($this.template); $("body").append($this.modal);
        if ($this.fullScreen && !(Core.isMobile() || Core.isTablet())) $this.modal.addClass("modal-fullscreen");

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
        });
        $this.modal.find(".modal-dialog").addClass($this.dialogType);
    });

    this.afterCreatePopupBody = function () { };

    var clearModal = function()
    {
        var $this = this;
        if($this.formKeys != null) { $this.formKeys.clearKeys(); $this.formKeys = null; }
        $this.modal.remove(); $this.modal = null; 
    }

    this.buttonNotifications = function(buttons)
    {
        this.popupBody.buttonNotifications(buttons);
    }
};

// Hiển thị thông báo
function CoreAlert(msg, callback) { return CoreAlertConfirm(Core.getLabel(msg), null, callback); }

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
    if (yes != null) popup.buttons.push({ value: Core.getLabel("Đồng ý"), icon: "fa fa-thumbs-o-up", cls: "btn btn-primary pull-left", func: function (element, scope) { yes(element, scope); yesClick = true; popup.hide(); } });
    popup.show();
    return popup;
}