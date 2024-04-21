/// <reference path="../Plugins/linq/linq.js" />

function NotificationCenter() {
    var notifications = []; // Danh sách các thông báo. Không hiển thị quá 10. Quá 10 xin mời click vào xem thêm

    this.userOverlay = false;
    this.alertWhenFail = false;

    this.receiveNotification = function (notification) {
        notification.Known = false;
        notification.Viewed = false;

        var $this = this;
        var nn = Enumerable.From(notifications).FirstOrDefault(null, function (n) { return n.NotificationId == notification.NotificationId; });
        if (nn != null) {
            nn.Name = notification.Name;
            nn.Content = notification.Content;
            nn.UpdatedDate = notification.UpdatedDate;
            nn.Known = notification.Known;
            nn.Viewed = notification.Viewed;
            nn.TypeNotify = notification.TypeNotify;
        }
        else notifications = Enumerable.From([notification]).Concat(notifications).ToArray();
        this.showLabel();

        var title = ""; var icon = "";
        switch (notification.TypeNotify) {
            case 0: title = Core.getLabel("Thông báo"); icon = "far fa-bell text-aqua"; break;
            case 1: title = Core.getLabel("Cảnh báo"); icon = "fas fa-exclamation-triangle text-maroon"; break;
            case 2: title = Core.getLabel("Tin tức"); icon = "far fa-newspaper text-green"; break;
        }

        (new PNotify({ title: title, text: notification.Name, icon: icon, delay: 3000, stack: { dir1: 'up', dir2: 'left' }, addclass: 'stack-bottomleft' })).get().click(function () {
            $this.show(notification);

            var nn = Enumerable.From(notifications).FirstOrDefault(null, function (n) { return n.NotificationId == notification.NotificationId; });
            if (nn != null)
                nn.Known = true;
            $this.showLabel();
        });
    };

    var notificationsMenu = null;
    var label = null, header = null, footer = null, content = null, aBell = null;

    this.start = function () {
        var $this = this;
        Core.userSession.setCenterNotifycationProvider(this);

        notificationsMenu = $(".notifications-menu");
        label = notificationsMenu.find("[data-notification=label]");
        header = notificationsMenu.find("[data-notification=header]");
        footer = notificationsMenu.find("[data-notification=footer]");
        content = notificationsMenu.find("[data-notification=content]");
        aBell = notificationsMenu.find("[data-notification=bell]");

        aBell.click(function () { $this.build(); });
        footer.find("a").click(function () { Core.userSession.gotoUrlListNotificationOfUser(); });

        // Tải danh sách cảnh báo
        if (this.post != null)
            this.post("LoadNotifications", {}, function (res) {
                notifications = res.Data.Items;
                $this.showLabel();

                // Nếu có thông báo nào bắt buộc phải xem thì hiển thị ngay lập tức
                var notification = Enumerable.From(notifications).FirstOrDefault(null, function (n) { return n.MustView && n.Viewed != true; });
                if (notification != null)
                    $this.show(notification);
            });
    };
    this.showLabel = function () {
        var total = Enumerable.From(notifications).Count(function (n) { return n.Known == false; });
        if (total > 10) label.html("10+");
        else if (total > 0) label.html(total);
        else label.html("");
    };
    this.build = function () {
        var $this = this;

        var total = Enumerable.From(notifications).Count(function (n) { return n.Known == false; });
        header.html(Core.getLabel("Bạn có <span class='text-red'>{0}</span> thông báo mới").format(total));

        if (total > 0 && this.post != null) this.post("UpdateKnown");

        content.empty();
        Enumerable.From(notifications).ForEach(function (notification) {
            if (notification.Known == false) {
                notification.New = true;
                notification.Known = true;
            }
            var icon = "";
            var libg = notification.New == true ? "bg-gray" : "";

            switch (notification.TypeNotify) {
                case 0: icon = "far fa-bell text-aqua"; break;
                case 1: icon = "fas fa-exclamation-triangle text-maroon"; break;
                case 2: icon = "far fa-newspaper text-green"; break;
            }

            var li = $('<li class="' + libg + '"><a href="javascript:void(0)"><i class="' + icon + '"></i> ' + notification.Name + '</a></li>');
            content.append(li);
            li.find("a").click(function () {
                $this.show(notification);
            });
        });

        label.html("");
    };
    this.show = function (notification) {
        if (this.post != null) this.post("UpdateViewed", { id: notification.NotificationId });

        var popup = new Popup();
        popup.dialogType = "modal-lg";
        popup.title = notification.Name;
        popup.content = notification.Content;
        popup.afterCreatePopupBody = function () {
            popup.popupBody.css("max-height", $(window).height() - 220);
            popup.popupBody.css("overflow", "auto");
        };
        popup.show();
    };
}

NotificationCenter.inst = new NotificationCenter();

function WorkerCreateNewLabel() {
    this.sending = false;

    this.start = function () {
        var $this = this;

        var start = null;
        var request = null;

        var endSendNewLabel = function (items, newLabels) {
            if (newLabels != null) Enumerable.From(newLabels).ForEach(function (label) {
                Langs[label.Lexicon] = label.Value;
                delete Core.newLabels[label.Lexicon];
            });
            else Enumerable.From(items).ForEach(function (lexicon) { Core.newLabels[lexicon].send = false; });
            $this.sending = false;
            request = null;
        };

        var ajax = new CoreAjax("Business.LabelHelper");
        ajax.assembly = "Core.Sites.Libraries";
        ajax.userOverlay = false;
        ajax.alertWhenFail = false;

        var timer = new Core.Timer({
            time: 30000,
            onTimer: function () {
                if ($this.sending) {
                    var subDate = Core.subDate(new Date(), start);
                    if (subDate.totalMins <= 1) return;
                    if (request != null) request.abort();
                }
                $this.sending = true;
                start = new Date();

                var items = Enumerable.From(Core.newLabels)
                    .Where(function (nl) { return nl.Value.send == false; })
                    .Select(function (nl) {
                        nl.Value.send = true;
                        return nl.Value.lexicon;
                    }).ToArray();

                if (items.length > 0)
                    request = ajax.post2("SendNewLabel", { items: items },
                        function (res) { endSendNewLabel(items, res.Data.Labels); },
                        function () { endSendNewLabel(items, null); });
            }
        });
        timer.start();
    };
}
WorkerCreateNewLabel.inst = new WorkerCreateNewLabel();

$(function () {
    if ($("html.app").length > 0) {
        NotificationCenter.inst.start();
        WorkerCreateNewLabel.inst.start();
    }
});