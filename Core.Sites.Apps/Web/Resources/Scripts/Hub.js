/// <reference path="../Plugins/linq/linq.js" />

function Hub(hubUrl)
{
    this.state = -1;
    
    this.start = function()
    {
        var $this = this;
        var userToken = $.cookie(Core.userSession.cookieUser());
        if (userToken == null || userToken == "") return;

        $.connection.hub.url = hubUrl;
        $.connection.hub.qs = { 'token': userToken, browser: Core.getBrowser(), appSession: Core.getSessionCookie(), sessionType: SessionType };

        doHubStart.bind(this)();

        // Nếu bị mất kết nối thì 2s sau sẽ kết nối lại
        $.connection.hub.disconnected(function ()
        {
            $this.state = 1; // Bị mất kết nối
            var t = setInterval(function () 
            {
                doHubStart.bind($this)();
                clearInterval(t);
            }, 2000);
        });

        $(window).off("unload").on('unload', function()
        {
            $.connection.hub.stop();
        });
    }

    var doHubStart = function()
    {
        var $this = this;
        $.connection.hub.start().done(function () 
        {
            $this.state = 2; // Đã kết nối thành công
            $this.startDone();
            $this.actionStart.do(function (func) { func(); });
        })
        .fail(function () 
        {
            $this.state = 0; // Kết nối thất bại
        });
    }

    this.actionStart = new Hub.ActionRegistry();
    this.startDone = function() { }

    this.waitStartDone = function(func, funcWait)
    {
        if(this.state == 2)
        {
            func();
            return;
        }
        var $this = this;
        var t = setTimeout(function () 
        {
            $this.waitStartDone(func, funcWait);
        }, 1000);

        if (funcWait != null) funcWait(t);
    }

    this.withStarted = function(func)
    {
        if(this.state == 2)
            func();
    }
}

Hub.ActionRegistry = function()
{
    var action = [];
    this.registry = function(func)
    {
        var at = { id: Core.random(99999), func: func };
        action.push(at);
        return at.id;
    }
    this.unRegistry = function(id)
    {
        action = Enumerable.From(action).Where(function (a) { return a.id != id; }).ToArray();
    }
    this.do = function(func)
    {
        Enumerable.From(action).ForEach(function (a) { func(a.func); });
    }
}
function AppHub()
{
    
    $.extend(this, new Hub(HubServer + "/signalr"));
    this.hub = $.connection["appHub"];
    var $this = this;
    if (this.hub == null || this.hub.client == null) return;

    this.hub.client.receiveNotification = function (notification) { NotificationCenter.inst.receiveNotification(notification); };

    this.actionNotifyUserState = new Hub.ActionRegistry();
    this.hub.client.notifyUserStateChange = function (userState, remove) { $this.actionNotifyUserState.do(function (func) { func(userState, remove); }); };
    
    this.hub.client.logout = function (msg) 
    {
        if (msg == undefined || msg == null || msg == "") Core.logout();
        else Core.alert(msg, function () { Core.logout(); });
    };
    this.hub.client.receiveMessage = function (msg) { Core.alert(msg); };

    this.startDone = function () { this.sendUserState(); };
    this.sendUserState = function () 
    {
        this.withStarted(function () { $this.hub.server.sendUserState(App.windowActive, document.title).fail(function () { }); });
    };
    this.sendRegistryRoomViewUserState = function (callback) 
    { 
        this.withStarted(function () { $this.hub.server.sendRegistryRoomViewUserState().done(callback).fail(function () { }); });
    };
    this.sendUnRegistryRoomViewUserState = function () 
    { 
        this.withStarted(function () { $this.hub.server.sendUnRegistryRoomViewUserState().fail(function () { }); });
    };
    this.logoutClient = function(connectionIds, msg)
    {
        this.withStarted(function () { $this.hub.server.logoutClient(connectionIds, msg).fail(function () { }); });
    }
    this.sendMessage = function(connectionIds, msg)
    {
        this.withStarted(function () { $this.hub.server.sendMessage(connectionIds, msg).fail(function () { }); });
    }
    this.sendAllUserMessage = function (msg) { this.withStarted(function () { $this.hub.server.sendAllUserMessage(msg).fail(function () { }); }); };
}