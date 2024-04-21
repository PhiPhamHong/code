/// <reference path="../../../Resources/Plugins/linq/linq.js" />
function ViewUserState()
{
    $.extend(this, new ModuleNormal());

    var actionNotifyUserStateId = null
    var timeWaitStartDone = null;
    var actionHubStartId = null;

    this.onInit = function(res)
    {
        var $this = this;

        Hub.app.waitStartDone(function () 
        {
            actionNotifyUserStateId = Hub.app.actionNotifyUserState.registry(function (userState, remove) { $this.receiveUserState(userState, remove); });
            actionHubStartId = Hub.app.actionStart.registry(function () { $this.sendRegistryRoomViewUserState(); });
            $this.sendRegistryRoomViewUserState();
        }, 
        function (t) 
        {
            timeWaitStartDone = t;
        });

        new BootstrapMenu("[data-user-id]",
        {
            container: $this.getMain(),
            fetchElementData: function ($rowElem) { return $($rowElem); },
            actionsGroups: [],
            actions: {
                sendM1: { name: function ($rowElem) { return "Gửi tin nhắn cho người dùng <b>" + $rowElem.find("[data-text=t1]").html() + "</b>"; }, iconClass: 'fa-user', onClick: function ($rowElem) { $this.showPopupSendMessage($rowElem, false); } },
                sendM2: { name: "Gửi tin nhắn cho người dùng toàn hệ thống", iconClass: 'fa-sticky-note', onClick: function ($rowElem) { $this.showPopupSendMessage($rowElem, true); } }
            }
        });
    }

    this.showPopupSendMessage = function($rowElem, all)
    {
        var $this = this;
        var popup = new Popup();
        popup.title = all ? "Gửi tin nhắn toàn hệ thống" : "Gửi tin nhắn tới <b>" + $rowElem.find("[data-text=t1]").html() + "</b>";
        popup.content = "<div class=\"form-horizontal\">";
        popup.content += "  <div class='form-group'>";
        popup.content += "      <label class='control-label col-sm-2-5'>Nội dung</label>";
        popup.content += "      <div class=' col-sm-9'>";
        popup.content += "          <textarea data-text-area-type=\"textarea\" class=\"form-control input-sm\" name=\"Message\" placeholder=\"Ghi chú\"></textarea>";
        popup.content += "      </div>";
        popup.content += "  </div>";
        popup.content += "</div>";

        popup.buttons.push({
            value: Core.getLabel("Gửi tin nhắn"), cls: "btn btn-primary pull-left", func: function (element, scope) 
            {
                if (all) Hub.app.sendAllUserMessage(popup.popupBody.find("[name=Message]").val());
                else Hub.app.sendMessage($this.getConnectionIdsOfPanel($rowElem), popup.popupBody.find("[name=Message]").val());
                popup.hide();
            }
        });
        popup.show();
        return popup;
    }

    this.sendRegistryRoomViewUserState = function()
    {
        var $this = this;
        Hub.app.sendRegistryRoomViewUserState(function (userSates) 
        {
            Enumerable.From(userSates).ForEach(function (userState) { $this.receiveUserState(userState, false); });
        });
    }

    this.end = function()
    {
        Hub.app.waitStartDone(function () 
        {
            Hub.app.actionNotifyUserState.unRegistry(actionNotifyUserStateId);
            Hub.app.actionStart.unRegistry(actionHubStartId);
            Hub.app.sendUnRegistryRoomViewUserState();
        });
    }

    this.receiveUserState = function(userState, remove)
    {
        var $this = this;

        var panelUserState = this.getMain().find("[data-user-id={0}]".format(userState.UserId));
        if(panelUserState.length == 0)
        {
            if (remove) return;

            panelUserState = $(boxTemplate.format(userState.UserId, userState.Avatar, userState.UserName));
            this.getMain().find(".box-view-user").append(panelUserState);
            panelUserState.find(".info-box-icon img").errorImage("/Web/Resources/Images/avatar160x160.png");
            panelUserState.find("[data-original-title]").tooltip();
            panelUserState.find("[data-cmd]").click(function () 
            {
                $this[$(this).attr("data-cmd")](panelUserState);
            });
        }

        var statusItem = panelUserState.find("[data-connection-id={0}]".format(userState.ConnectionId));
        if(remove) 
        {
            statusItem.remove();
            if (panelUserState.find("[data-connection-id]").length == 0)
            {
                panelUserState.remove();
                panelUserState = null;
            }
            return;
        }

        if(statusItem.length == 0)
        {
            statusItem = $(itemTemplate1.format(userState.ConnectionId));
            panelUserState.find(".info-box-content").append(statusItem);
        }

        statusItem.setHtml("{0} - {1} ({2})".format(userState.Browser, userState.ModuleName, userState.Ip));
        if(userState.WindowFocus)
        {
            panelUserState.find("[data-connection-id]").removeClass("bold");
            statusItem.addClass("bold");
        }
    }

    this.LogoutClient = function (panelUserState) { Hub.app.logoutClient(this.getConnectionIdsOfPanel(panelUserState), "Quản trị đã ngắt kết nối của bạn!"); };

    this.getConnectionIdsOfPanel = function(panelUserState)
    {
        return Enumerable.From(panelUserState.find("[data-connection-id]")).Select(function (c) { return $(c).attr("data-connection-id"); }).ToArray();
    }

    var boxTemplate = '<div class="col-md-6 col-sm-6 col-xs-12" data-user-id="{0}">\
        <div class="info-box">\
            <span class="info-box-icon"><img src="{1}" style="width: 75px; height: 74px;"></span>\
            <div class="info-box-content">\
                <span class="info-box-text" data-text="t1">{2}</span>\
            </div>\
            <div class="box-tools">\
                <button class="btn btn-danger" data-original-title="Đăng xuất" data-cmd="LogoutClient"><i class="fa fa-times"></i></button>\
            </div>\
        </div>\
    </div>';

    var itemTemplate1 = '<span class="info-box-number" data-text="t2" data-connection-id="{0}"></span>';
    var itemTemplate2 = '<span class="info-box-text-1" data-text="t3" data-connection-id="{0}"></span>';
}