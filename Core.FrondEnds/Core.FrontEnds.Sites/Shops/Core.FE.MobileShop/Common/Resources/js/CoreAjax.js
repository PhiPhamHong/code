/*

post(methodServer, data, callback)
+ Ajax Post
- methodServer: Phương thức ở server cần được gọi
- data: dữ liệu cần truyền đi ví dụ: {name: "Nguyễn Văn A", age: 20}
- callback: phương thức xử lý sau khi thực hiện request thành công

get(methodServer, data, callback)
+ Ajax Get: giống Ajax Post, phương thức thực hiện là GET

doPostTimer(methodServer, data, timeInterval, process, waiting, endWhen)
+ Thực hiện một phương thức ajax mà lặp đi lặp lại theo một chu kỳ
- methodServer: Phương thức ở server cần được gọi
- data: dữ liệu cần gửi đi từ client
- timeInterval: chu kỳ cần lặp
- process: phương thức xử lý sau khi thực hiện request thành công
- waiting: phương thức để gợi ý là có thực hiện đợi một chờ một vấn đề gì đó khi thực hiện chu kỳ tiếp theo hay không
- endWhen: phương thức đưa ra điều kiện khi nào thì sẽ dừng, không lặp lại nữa

clearThreadGet(methodServer)
clearThreadPOST(methodServer)
+ Clear thread thực hiện methodServer

*/

/* Class để thực hiện các function ajax */
function CoreAjax(typeAction_)
{
    // Đây là Assembly chứa đối tượng có phương thức ajax
    // this.assembly = "Core.FrontEnd.ijvnTravel.com"; // Mặc định
    this.assembly = "";
    // Type của đối tượng chứa phương thức ajax trong Assembly
    this.typeAction = typeAction_;

    this.createRequestUrl = function(method)
    {
        return "/Common/Services/Ajax.aspx?_n=" + this.assembly + "&_o=" + encodeURIComponent(this.typeAction) + "&_m=" + method + "&lang=" + $("[data-language]").attr("data-language");
    }

    var DownloadResult = function()
    {
        this.request = null; this.popup = null; this.doing = false;
        var timeout = null;
        this.start = function()
        {
            var $this = this;
            $this.doing = true;
            timeout = setTimeout(function () { $this.popup = CoreAlert("Đang thực hiện tải tệp", function () { $this.abort(); }); }, 1000);            
        }
        this.abort = function()
        {
            if(this.request != null && this.doing) { this.request.abort(); this.end(); }
        }
        this.end = function()
        {
            if (timeout != null) { clearTimeout(timeout); timeout = null; }
            if (this.popup != null) { this.doing = false; this.popup.hide(); }
        }
    }

    // thực hiện method download file
    this.download = function(method, data, callback, onerror)
    {
        var result = new DownloadResult();
        result.start();

        var $this = this;
        result.request = $.fileDownload(this.createRequestUrl(method),
        {
            httpMethod: "POST",
            data: data,
            successCallback: function (url)
            {
                if (callback != null) callback(url); result.end();
            },
            failCallback: function (r)
            {
                eval("var res = " + arguments[0]);
                if (onerror != null) onerror(res);
                else Core.alert(res.Data.MessageError);
                result.end();
            }
        });

        return result;
    }

    // Timer để check việc hiển thị thông báo trong quá trình gọi ajax
    this.timer = null;
    this.currentOverlay = null;
    this.templateOverlay = "<div class='overlay-loading'><i class='fa fa-spinner fa-spin fa-2x'></i></div>";    
    this.userOverlay = true;
    this.alertWhenFail = true;

    this.post = function (methodServer, data, callback, onerror, options) { return this.doAjax("POST", methodServer, data, callback, onerror, options); }
    this.post2 = function (methodServer, data, callback, onerror, options)
    {
        if (data != null)
        {
            var newData = {};
            Enumerable.From(data).ForEach(function (item) { newData[item.Key] = JSON.stringify(item.Value); });
            data = newData;
        }
        this.post(methodServer, data, callback, onerror, options);
    }
    this.get = function (methodServer, data, callback, onerror, options) { return this.doAjax("GET", methodServer, data, callback, onerror, options); }

    this.clearOverlay = function()
    {
        if (this.timer != null) clearTimeout(this.timer);
        if (this.currentOverlay != null) this.currentOverlay.remove();
    }

    // Thực hiện một request ajax
    this.doAjax = function (methodAjax, methodServer, data, callback, onerror, options) 
    {
        // Url thực hiện request ajax
        var urlRequest = this.createRequestUrl(methodServer);
        return this.doAjaxHelper(methodAjax, "json", urlRequest, data, callback, onerror, options);
    }
    this.doAjaxHelper = function (methodAjax, dataType, urlRequest, data, callback, onerror, options)
    {
        var $this = this;

        // Clear việc đang chờ hiển thị message lúc trước đi
        $this.clearOverlay();

        if (options == null) options = {};

        // kiểm tra xem data có phải là một function lấy data hay không
        // nếu là một function lấy data thì thực hiện lấy data
        var dataPost = typeof (data) == "function" ? data() : data;
        if (dataPost == null) dataPost = {};
        //dataPost.path = window.location.pathname + window.location.search;
        var request = $.ajax({ url: urlRequest, type: methodAjax, data: dataPost, dataType: dataType });

        // Nếu như request thực hiện thành công
        request.done(function (res)
        {
            try
            {
                if (res.Data != null)
                {
                    if (res.Data.ErrorType == "EndException" || res.Data.ErrorTypeInner == "EndException");
                    else if (res.Data.MessageError != null) // Có lỗi về action trong method gọi đến
                    {
                        if (res.Data.ErrorType == "NotAuthenException" || res.Data.ErrorTypeInner == "NotAuthenException")
                        {
                            window.location.href = "/Login.aspx";
                            return;
                        }
                        if (onerror != null) onerror(res);
                        else Core.alert(res.Data.MessageError);
                        return;
                    }
                    eval(res.JavaScript); // Thực hiện xử lý javascript mà server gửi về cho client
                }
                if (callback != null) callback(res); // Nếu có xử lý sau khi kết thúc request theo ý người lập trình
            }
            catch (e) { }
            finally { $this.clearOverlay(); };
        }).fail(function (jqXHR, textStatus)
        {
            $this.clearOverlay();
            if (textStatus == "abort") return;

            if ($this.alertWhenFail) Core.notify("Không thể kết nối tới Server. Vui lòng thử lại", "error");
            if (onerror != null) onerror();
        });

        // Thực hiện hiển thị message, nếu như quá trình đang thực hiện request quá 500ms
        if ($this.userOverlay || options.userOverlay == true)
            $this.timer = setTimeout(function () { $('body').append($this.currentOverlay = $($this.templateOverlay)); }, 500);

        return request;
    }
        
    this.doPostTimer = function (methodServer, data, timeInterval, process, waiting, endWhen) { this.clearThread("POST", methodServer); this.doTimer("POST", methodServer, data, timeInterval, null, process, waiting, endWhen); };
    this.doGetTimer = function (methodServer, data, timeInterval, process, waiting, endWhen) { this.clearThread("GET", methodServer); this.doTimer("GET", methodServer, data, timeInterval, null, process, waiting, endWhen); };

    // ajax timer, dùng để thực hiện một phương thức theo một chu kỳ, có tính toán độ trễ qua từng request
    this.doTimer = function (methodAjax, methodServer, data, timeInterval, lastRequest, process, waiting, endWhen) 
    {
        this.threadDoAjax(methodAjax, methodServer, data, process, lastRequest, timeInterval, waiting, endWhen);
    }

    this.doPostTimeout = function(methodServer, data, timeInterval, process) { this.doTimeout("POST", methodServer, data, timeInterval, process); }
    this.doGetTimeout = function(methodServer, data, timeInterval, process) { this.doTimeout("GET", methodServer, data, timeInterval, process); }
    this.doTimeout = function (methodAjax, methodServer, data, timeInterval, process) { this.clearThread(methodAjax, methodServer); this.doTimer(methodAjax, methodServer, data, timeInterval, null, process, null, function () { return true; }); };

    // Lưu trữ các timer thread đang chạy
    this.threadTimer = {};
    this.threadTimerAjax = {};

    // Thực hiện xử lý cụ thể trong doTimer
    // endWhen: Khi phương thức trả về false thì kết thúc thread luôn
    this.threadDoAjax = function (methodAjax, methodServer, data, process, lastRequest, timeInterval, waiting, endWhen) 
    {
        // Đối tượng ShAjax đang được sử dụng
        var $this = this;

        // nếu có sự kiện thực hiện đợi chờ một việc gì đó thì dừng lại chờ
        if (waiting != null && waiting()) 
        {
            // request lại cho đến khi thoát khỏi waiting
            $this.smoothingThread(lastRequest, methodAjax, methodServer, data, timeInterval, process, waiting, endWhen);
            return;
        }

        // Thực hiện ajax
        $this.threadTimerAjax[methodAjax + "_" + methodServer] = $this.doAjax(methodAjax, methodServer, data, function (res) 
        {
            // Nếu có sử lý sau khi gọi phương thức ajax thì gọi process
            if (process != null) process(res);

            // nếu như có function để kiểm tra việc kết thúc thread thì gọi đến nó
            if (endWhen != null && endWhen(res)) 
            {
                $this.clearThread(methodAjax, methodServer);
                return;
            }

            // làm mượt chu kỳ thread
            $this.smoothingThread(lastRequest, methodAjax, methodServer, data, timeInterval, process, waiting, endWhen);
        });
    }
    // phương thức làm mượt thread
    this.smoothingThread = function (lastRequest, methodAjax, methodServer, data, timeInterval, process, waiting, endWhen) 
    {
        var $this = this;

        // clear lại timeout trước đó đi
        $this.clearThread(methodAjax, methodServer);

        // Tính toán lại thời gian thực hiện request
        // Đảm bảo cứ sau timeInterval sẽ thực hiện một lần
        var ti = lastRequest == null ? timeInterval : timeInterval - (new Date() - lastRequest);

        // Nếu mà thời gian thực hiện trước đó mà lớn hơn cả chu kỳ thì lấy lại là 20s
        ti = ti <= 0 ? timeInterval : ti;

        // thiết lập lại ngày giờ lần cuối cùng thực hiện request
        lastRequest = new Date();

        // setTimeout để chạy chu trình tiếp theo
        $this.threadTimer[methodAjax + "_" + methodServer] = setTimeout(function () { $this.doTimer(methodAjax, methodServer, data, timeInterval, lastRequest, process, waiting, endWhen); }, ti);
    }
    
    this.getTimerGetOf = function (methodServer) { return this.threadTimer["GET_" + methodServer]; };
    this.getTimerPostOf = function (methodServer) { return this.threadTimer["POST_" + methodServer]; };
    this.clearThreadGet = function (methodServer) { this.clearThread("GET", methodServer); }
    this.clearThreadPOST = function (methodServer) { this.clearThread("POST", methodServer); }

    // clear timer of thread 
    this.clearThread = function (methodAjax, methodServer)
    {
        var request = this.threadTimerAjax[methodAjax + "_" + methodServer];
        if (request != null)
        {
            request.abort();
            this.threadTimerAjax[methodAjax + "_" + methodServer] = null;
        }

        // Lấy ra timer của phương thức ajax đang gọi
        var thisTimer = this.threadTimer[methodAjax + "_" + methodServer];
        if (thisTimer != null) 
        {            
            clearTimeout(thisTimer);
            this.threadTimer[methodAjax + "_" + methodServer] = null;
        }
    }
}

jQuery.cachedScript = function (url, options) {

    // Allow user to set any option except for dataType, cache, and url
    options = $.extend(options || {}, {
        dataType: "script",
        //cache: true,
        cache: false,
        url: url
    });

    // Use $.ajax() since it is more flexible than $.getScript
    // Return the jqXHR object so we can chain callbacks
    return jQuery.ajax(options);
};

$.fn.serializeData = function()
{
    var form = $("<form>");
    return JSON.stringify(form.append(this.html()).serializeArray());
}