/// <reference path="../jQuery/jQuery-2.1.3.min.js" />
/// <reference path="../linq/linq.min.js" />
// Một giao diện dùng phím nóng
// Các giao diện sử dụng phím nóng phải kế thừa đến class này 
// và viết lại phương thức setKeys
function FormKeys(arrayForm) 
{
    var allKeyEvents = { };

    var doBind = function (target, shortcut_combination, func)
    {
        // Thực hiện Bind key
        $(target).bind(shortcut_combination, func);

        // Gán vào FormKeys.all để biết được toàn bộ keys của chương trình đang chạy
        allKeyEvents[shortcut_combination + "" + Math.random()] =
        {
            target: target,
            func: func,
            keys : shortcut_combination
        };

        target[shortcut_combination] = func;
    };

    // Thực hiện add một sự kiện bàn phím
    this.addKey = function (shortcut_combination, callback, target, clearBlackKey) 
    {
        if (target == null) target = document;

        // các function của sự kiện bàn phím luôn luôn trả về false
        // đảm bảo ngăn chặn được sự kiện bàn phím của trình duyệt
        var func = function (evt) 
        {
            // evt.handleObj.namespace
            callback(evt);
            return false;
        };

        // bind keys
        doBind(target, shortcut_combination, func);

        // Nếu như mà input textbox thì phải clear toàn bộ sự kiện bàn phím của trình duyệt đi
        // ví dụ như ctrl+t, ctrl+o
        if (clearBlackKey && $(target).is("input:text")) 
        {
            // phương thức rỗng
            var none = function(evt) 
            {
                var shortKey = evt.type + "." + evt.handleObj.namespace;
                if (document[shortKey] != null) document[shortKey](evt);
                return false; 
            };
            
            var shortKeyInDocuments = Object.getOwnPropertyNames(document).filter(function (property) { return typeof document[property] == 'function'; });
            var blackKeys = Enumerable.From(FormKeys.blackKeys).Select(function (bk) { return "keydown." + bk });
            blackKeys = blackKeys.Concat(shortKeyInDocuments).Distinct(function (key) { return key; }).Select(function (key) { return key;}).ToArray();

            // ngăn chặn keys của trình duyệt
            for (var i = 0; i < blackKeys.length; i++)
                doBind(target, blackKeys[i], none);
        }
    };

    // Định nghĩa phương thức vitual setKeys để thiết lập các sự kiện bàn phím
    // tùy theo yêu cầu của từng giao diện
    this.setKeys = function () 
    {
        var $this = this; $this.onSetKeys();

        Enumerable.From(arrayForm).ForEach(function(form)
        {
            form.find("[data-hot-keys]").each(function()
            {
                var thisInput = $(this);
                var keys = thisInput.attr("data-hot-keys");
                if (thisInput.is("input:text")) 
                {
                    $this.addKey(keys, function () { thisInput.focus(); });
                    var tabIndex = thisInput.attr("data-tab-index");
                    if(tabIndex != null)
                    {
                        tabIndex = parseInt(tabIndex);
                        $this.addKey("keydown.up", function () { form.find("[data-tab-index=" + (tabIndex - 1) + "]").focus(); }, this, true);
                        $this.addKey("keydown.down", function () { form.find("[data-tab-index=" + (tabIndex + 1) + "]").focus(); }, this, false);
                    }
                    else
                    {
                        $this.addKey("keydown.up", function () { }, this, true);
                        $this.addKey("keydown.down", function () { }, this, false);
                    }
                }
                else if (thisInput.prop("tagName") == "A" || thisInput.prop("tagName") == "BUTTON")
                {
                    $this.addKey(keys, function () { thisInput.click(); });
                }
            });
        });
    };

    this.onSetKeys = function() { }

    this.clearKeys = function()
    {
        for (var item in allKeyEvents) 
        {
            var itemInfo = allKeyEvents[item];
            $(itemInfo.target).unbind(itemInfo.keys, itemInfo.func);
            itemInfo.target[itemInfo.keys] = function () { };
        }
        allKeyEvents = { };
    }

    // Phục hồi lại sự kiện bàn phím
    this.restoreKeys = function () 
    {
        this.clearKeys();      // clear key và thực hiện
        this.setKeys();        // Hồi phục lại keys
    };

    // Thực hiện Bind key
    this.start = function()
    {
        this.setKeys();
    }
}

// black keys => các keys mà khi focus tại các input sẽ dễ bị lẫn với các keys của trình duyệt
// ví dụ ctrl+t => trùng với mở tab mới của trình duyệt
FormKeys.blackKeys = ['Ctrl_t', 'Ctrl_o', 'Ctrl_h', 'Ctrl_n','Alt_t', 'Ctrl_s', 'Ctrl_f'];