/// <reference path="../../Plugins/linq/linq.min.js" />
/// <reference path="../../Plugins/jQuery/jQuery-2.1.3.min.js" />

//import { debug } from "webpack";

$.fn.getValues = function (notSelector)
{
    var params = {};

    if (notSelector == undefined || notSelector == null) notSelector = "";

    var normalInput = this.find("input[type='text'][name], input[type='hidden'][name], input[type='password'][name], select[name], textarea[name]");
    if (notSelector != "") normalInput = normalInput.filter(function () { return $(this).parents(notSelector).length == 0; });
    normalInput.each(function ()
    {
        var $thisInput = $(this);
        if ($thisInput.attr("data-format") == "Numeric")
            params[$thisInput.attr("name")] = $thisInput.inputmask('unmaskedvalue');
        else
            params[$thisInput.attr("name")] = $thisInput.val();
    });

    var selectInput = this.find("select[name]");
    if (notSelector != "") selectInput = selectInput.filter(function () { return $(this).parents(notSelector).length == 0; });
    selectInput.each(function () 
    { 
        params[$(this).attr("name")] = Enumerable.From($(this).find(":selected")).Select(function (t) { return $(t).attr("value"); }).ToString(",");
    });
    var checkbox = this.find("input[type='checkbox'][name]:not([data-group])")
    if (notSelector != "") checkbox = checkbox.filter(function () { return $(this).parents(notSelector).length == 0; });
    checkbox.each(function () { params[$(this).attr("name")] = this.checked; });

    var chks = this.find("input[type='checkbox'][name][data-group]");
    if (notSelector != "") chks = chks.filter(function () { return $(this).parents(notSelector).length == 0; });
    Enumerable.From(chks).GroupBy("jQuery($).attr('name')")
        .Select(function (g) { params[g.Key()] = g.Where("$.checked").Select("jQuery($).attr('data-value')").ToString(','); }).Count();

    var date = this.find("[data-control-date][data-name]");
    if (notSelector != "") date = date.filter(function () { return $(this).parents(notSelector).length == 0; });
    date.each(function () { params[$(this).attr("data-name")] = $(this).inputDateGetValue(); });

    return params;
};
$.fn.inputDateGetValue = function()
{
    var inputDate = $(this).find("[data-type-date]");
    var date = inputDate.val();
    if (inputDate.attr("data-end-date") == "true")
    {
        if (date != "")
            date = date + " 23:59";
    }
    else {
        var timeinput = $(this).find("[data-type-time-indate]");
        if (timeinput.length > 0) 
        {
            if (date != "")
                date = date + " " + timeinput.val();
        }
    }
    return date;
}
$.fn.fillForm = function (values, niceform, notSelector, target)
{
    if (niceform == null) niceform = true;
    if (notSelector == undefined || notSelector == null) notSelector = "";

    for (var key in values)
    {
        var inputNormal = this.find("input[type='hidden'][name='" + key + "'], input[type='text'][name='" + key + "']:not([data-type-date]), input[type='password'][name='" + key + "'], textarea[name='" + key + "']");
        if (notSelector != "") inputNormal = inputNormal.filter(function () { return $(this).parents(notSelector).length == 0; });
        inputNormal.val(values[key]);
        
        var select = this.find("select[name='" + key + "']");
        if(notSelector != "") select = select.filter(function () { return $(this).parents(notSelector).length == 0; });
        if(select.length > 0)
        {
            var selectVal = values[key];
            if (selectVal != null) selectVal = selectVal + "";

            if (selectVal != null && selectVal != "") 
            {
                selectVal = (selectVal + "").split(',');
                select.val(selectVal);
            }

            if (select.attr("data-select-type") == "select2") { }
            else select.trigger("chosen:updated");
        }

        var checkbox = this.find("input[type='checkbox'][name='" + key + "']:not([data-group])");
        if(notSelector != "") checkbox = checkbox.filter(function () { return $(this).parents(notSelector).length == 0; });
        checkbox.attr("checked", values[key]); checkbox.iCheck("update");

        // bind checkbox group
        var chks = this.find("input[type='checkbox'][name='" + key + "'][data-group]");
        if(notSelector != "") chks = chks.filter(function () { return $(this).parents(notSelector).length == 0; });
        if (chks.length > 0 && values[key] != null)
            Enumerable.From(chks).Join(values[key].split(','), "jQuery($).attr('data-value')", "", "$i,$o => jQuery($i).attr('checked',true)").Count();

        // bind datepicker        
        var datepicker = this.find("[data-name='" + key + "'] input[type='text'][data-type-date]");
        if(notSelector != "") datepicker = datepicker.filter(function () { return $(this).parents(notSelector).length == 0; });
        if (datepicker.length > 0) 
        {
            var valdate = values[key];
            if (typeof (valdate) == "object") datepicker.val(Core.formatDate3(valdate));
            else datepicker.val(Core.formatDate(values[key]));
        }

        var timeIndatepicker = this.find("[data-name='" + key + "'] input[type='text'][data-type-time-indate]");
        if(notSelector != "") timeIndatepicker = timeIndatepicker.filter(function () { return $(this).parents(notSelector).length == 0; });
        if (timeIndatepicker.length > 0)
        {
            timeIndatepicker.val(Core.formatTime2(values[key]));
            timeIndatepicker.attr("data-current", Core.formatTime2(values[key]));
        }

        var timepicker = this.find("input[type='text'][name='" + key + "'][data-type-time]");
        if(notSelector != "") timepicker = timepicker.filter(function () { return $(this).parents(notSelector).length == 0; });
        if (timepicker.length > 0)
        {
            timepicker.val(Core.formatTime(values[key]));
            timepicker.attr("data-current", Core.formatTime(values[key]));
        }
    }

    if (niceform) this.benice(null, target);
    return this;
};
$.fn.clearForm = function()
{
    this.find("input[type='hidden'][name],input[type='text'][name]:not([data-type-date]), input[type='password'][name],textarea[name]").val("");
    this.find("select[name][multiple]").val([]).trigger("chosen:updated").trigger('change.select2');;
    this.find("select[name]:not([multiple])").val("0").trigger("chosen:updated").trigger('change.select2');;
    this.find("input[type='checkbox'][name]").attr("checked", false);
    this.find("[data-name] input[type='text'][data-type-date]").val("");
    this.find("[data-name] input[type='text'][data-type-time-indate]").val("");
    this.find("input[type='text'][name][data-type-time]").val("");
}
$.fn.deleteChosen = function () 
{
    this.find('select').each(function () 
    {
        var $this = $(this);
        var selectType = $this.attr("data-select-type");
        if(selectType == "select2")
        {

        }
        else
        {
            $this.chosen("destroy");
        }
    });
    return this;
};
$.fn.makeChosen = function (target) 
{
    this.find('select').each(function () 
    {
        var $this = $(this);

        var selectType = $this.attr("data-select-type");
        if(selectType == "select2")
        {
            var options = { dropdownAutoWidth: false, width: $this.attr("data-width"), theme: "bootstrap" };
            var ds = $this.attr('data-disable-search');
            if (ds != null && ds.toLowerCase() == 'true') options.minimumResultsForSearch = Infinity;
            var multiple = $this.attr("multiple");
            if(multiple != null && multiple != "")
            {
                var placeholder_text_multiple = $this.attr("data-placeholder_text_multiple");
                if (placeholder_text_multiple == null || placeholder_text_multiple == "") placeholder_text_multiple = Core.getLabel("Chọn");
                options.placeholder = placeholder_text_multiple;
            }

            options.maximumSelectionLength = $this.attr("data-maximumSelectionLength");
            if (options.maximumSelectionLength != null && options.maximumSelectionLength != "")
                options.maximumSelectionLength = parseInt(options.maximumSelectionLength);

            var ajax = $this.attr("data-select2-use-ajax");
            if(ajax != null && ajax.toLowerCase() == "true")
            {
                options.ajax = 
                {
                    url: "/Services/Ajax.aspx?_n=Core.Sites.Apps&_o=" + $this.attr("data-type-action") + "&_m=GetDataAjax",
                    data : function(params)
                    {
                        var query = { query: params.term, alias: $this.attr("data-alias") };
                        var dataFields = $this.attr("data-data-ajax");
                        if (dataFields != null && dataFields != "")
                            Enumerable.From(dataFields.split(',')).ForEach(function (field) 
                            {
                                query[field] = $this.attr("data-" + field);
                            });
                        return query;
                    },
                    dataType: "json" ,
                    delay: 250,
                    processResults : function(data)
                    {
                        var items = Enumerable.From(data.Data.ListItem).Select(function(item)
                            {
                                return { "id": item[data.Data.DataValueField.T1.Name], "text": item[data.Data.DataTextField.T1.Name] };
                            }).ToArray();
                        return { 
                            results: items
                        };
                    },

                };
                options.templateResult = function (item) 
                {
                    return item.text;
                };
                options.templateSelection = function (item) 
                {
                    return item.text;
                };
                options.minimumInputLength = 1;
                options.allowClear = true;
                options.placeholder = $this.attr("data-text-default");
            }
            else
            {
                var templateResult = $this.attr("data-template-func");
                if(templateResult != null && target != null)
                {
                    options.templateResult = function(item)
                    {
                        return target[templateResult](item);
                    }
                }
            }

            $this.select2(options);
        }
        else
        {
            var options = {};
            var ds = $this.attr('data-disable-search');
            if (ds != null && ds.toLowerCase() == 'true') options["disable_search"] = true;
            var placeholder_text_multiple = $this.attr("data-placeholder_text_multiple");
            if (placeholder_text_multiple == null || placeholder_text_multiple == "") placeholder_text_multiple = Core.getLabel("Chọn");
            options["placeholder_text_multiple"] = placeholder_text_multiple;

            if ($this.attr("data-width") != null) $this.css("width", $this.attr("data-width"));
            $this.chosen(options);
        }

        var parent = $this.parents(".input-group");
        parent.on("shown.bs.dropdown", function ()
        {
            parent.find("[data-toggle=dropdown]").find("i").removeClass("fa-plus").addClass("fa-minus");
            parent.find(".input-group-addon").removeClass("label-primary").addClass("bg-blue");
        });
        parent.on("hidden.bs.dropdown", function ()
        {
            parent.find("[data-toggle=dropdown]").find("i").removeClass("fa-minus").addClass("fa-plus");
            parent.find(".input-group-addon").removeClass("bg-blue").addClass("label-primary");
        });
    });
    return this;
};
$.fn.remakeChosen = function () 
{    
    
    this.deleteChosen();
    this.makeChosen();
};
$.fn.benice = function(check, target)
{
    
    if (check == null) check = true;
    if (!check) this.removeAttr("data-has-be-nice");

    if (this.attr("data-has-be-nice") == "true") return this;
    this.attr("data-has-be-nice","true");

    this.makeChosen(target);
    this.find("input[type=checkbox],input[type=radio]").iCheck({ checkboxClass: "icheckbox_flat-blue", radioClass: "iradio_flat-blue" }).on("ifChanged", function (e) { $(this).trigger("change", e); });;
    this.find("input[data-type-date=true]")
        .each(function()
        {
            var $this = $(this);
            $this.datepicker({
                language: "vi", format: "dd/mm/yyyy", autoclose: true, beforeShowDay: function (date)
                {
                    var res = { date: date, result: true };
                    $this.trigger("before-show-day", [res]);
                    return res.result;
                }
            });

            $this.parent().find(".input-group-addon").click(function ()
            { $this.focus(); });
        });

    this.find("input[data-type-date=true]:not([data-has-bind])").each(function () { $(this).inputmask("dd/mm/yyyy"); $(this).attr("data-has-bind", true); });
    this.find("input[data-format=Numeric]:not([data-has-bind])").each(function () 
    {
        //var groupSeparator = $(this).attr("data-groupSeparator");
        //if (groupSeparator == null) groupSeparator = ",";

        //// $(this).attr("data-inputmask", "'alias': 'numeric', 'groupSeparator': ',', 'autoGroup': true, 'digits': 4, 'digitsOptional': true, 'prefix': '$ ', 'placeholder': '0'");

        //$(this).inputmask('numeric', { groupSeparator: groupSeparator });

        var $thisInput = $(this);
        if ($thisInput.attr("data-inputmask") == null)
            $thisInput.attr("data-inputmask", "'alias': 'numeric', 'groupSeparator': ',', 'autoGroup': true, 'digits': 2, 'digitsOptional': true");

        $thisInput.inputmask();
        $thisInput.attr("data-has-bind", true);
    });

    //this.find("input[data-format=Numeric]:not([data-has-bind])").each(function () { $(this).maskMoney({thousands:',', decimal:'.', allowZero:true, suffix: ' đ', allowNegative : true}); $(this).attr("data-has-bind", true); });

    this.find("input[data-type-time=true],input[data-type-time-indate=true]").each(function()
    {
        var $this = $(this);
        $this.timepicker({ showMeridian: false, explicitMode: true, defaultTime: false }).on("changeTime.timepicker", function ()
        {
            var current = $this.attr("data-current");
            var now = $this.val();

            if (current != now)
            {
                $this.attr("data-current", now);

                if ($this.timeoutChange != null)
                {
                    clearTimeout($this.timeoutChange);
                    $this.timeoutChange = null;
                }
                $this.timeoutChange = setTimeout(function () { $this.trigger("sh-changeTime.timepicker"); }, 500);
            }
        }).on('blur', function (e)
        {
            if ($(e.target).hasClass('tp-start') || $(e.target).hasClass('tp-end')) {
                // do nothing or other thing you wanna do.
            } else {
                $(this).timepicker('hideWidget');
            }
        });

        //.inputmask("hh:mm");

        $this.parent().find(".fa.fa-clock-o").parent().click(function ()
        {
            $this.focus();
        });
    });

    this.beniceFileInput();    

    this.find("[data-type-latlng=true]").find(".input-group-addon").click(function ()
    {
        var pi = $(this).parent();
        var popup = new PopupPickerLatLng();
        popup.lat = pi.find("[data-lat=true]").val();
        popup.lat = popup.lat == null || popup.lat == "" ? 0 : parseFloat(popup.lat);
        popup.lng = pi.find("[data-lng=true]").val();
        popup.lng = popup.lng == null || popup.lng == "" ? 0 : parseFloat(popup.lng);
        popup.receiveLatlng = function (lat, lng) 
        { 
            pi.find("[data-lat=true]").val(lat); 
            pi.find("[data-lng=true]").val(lng); 
            pi.trigger("latLangChange");
        };
        popup.show();
    });
    this.find(".core-color-picker").colorpicker();
    this.buildEditor("textarea[data-text-area-type=editor]");

    return this;
}
$.fn.beniceFileInput = function(rebuild)
{
    this.find("[data-input-file]").each(function () 
    {
        if (rebuild == true && this.buildListImage != null)
        {
            this.buildListImage();
            return;
        }

        var $thisInput = $(this);
        var input = $thisInput.find("input"); 
        var dataInput = input.data();
        var divImages = null;
        var ul = null;
        var width = dataInput.imageWidth == null || dataInput.imageWidth == 0 ? 40 : dataInput.imageWidth;
        var height = dataInput.imageHeight;
        var randomCss = "c_" + Core.random(999999);

        var next = null;
        var pre = null;

        var buildListImage = function()
        {            
            if (dataInput.showImages != "True") return;

            ul.empty();
            ul.removeAttr("style"); ul.attr("style", "list-style: none; margin:0px;padding:0px");

            next.hide(); pre.hide();
            divImages.removeAttr("style");

            var i = 0;

            Enumerable.From(input.val().split(',')).ForEach(function(file)
            {
                if (file == '') return;

                var li = $("<li style='margin-right:3px;margin-left:3px;float:left;cursor:pointer'><img src='" + file + "' style='width: " + (width + "px") + "; height: " + height + "px;' /></li>");
                ul.append(li);

                i++;
            });

            if (i == 0) divImages.css("margin-top", "0px");
            else 
            {
                var max = divImages.width() / (width + 6);
                if (i > max) {
                    divImages.jCarouselLite({
                        visible: max,
                        scroll:1,
                        btnNext: ".next." + randomCss,
                        btnPrev: ".pre." + randomCss
                    });
                    next.show();
                    pre.show();
                }
                divImages.css("margin-top", "10px");

                ul.find("li").click(function ()
                {                    
                    Core.popup($(this).find("img").attr("src"), null, 600, 300);
                });
            }
        }

        this.buildListImage = buildListImage;

        if (dataInput.showImages)
        {
            var div = $("<div style='position:relative'>"); $thisInput.append(div);
            next = $("<a class='next " + randomCss + "' style='position:absolute;right:-13px'><i class='fas fa-arrow-circle-right'></i></a>"); div.append(next);
            pre = $("<a class='pre " + randomCss + "' style='position:absolute;left:-15px'><i class='fas fa-arrow-circle-left'></i></a>"); div.append(pre);

            next.css("top", (height - next.height()) / 2);
            pre.css("top", (height - next.height()) / 2);

            next.hide();
            pre.hide();

            divImages = $("<div class='form-images'>"); div.append(divImages);
            ul = $("<ul style='list-style: none; margin:0px;padding:0px'>"); divImages.append(ul);
            buildListImage();
        }

        var btnUpload = $thisInput.find(".input-group-addon");
        btnUpload.click(function ()
        {
            Core.showFiles(input.attr("data-file-type"), dataInput.multi, function (folder, files) 
            {                
                var newsFiles = Enumerable.From(files).Select(function (file) { return folder + file; });
                if(dataInput.multi)
                {
                    var oldFiles = input.val().split(',');
                    newsFiles = newsFiles.Concat(oldFiles).Distinct();
                }
                input.val(newsFiles.Where(function(file){ return file != '' }).ToString(','));
                input.trigger("sh-input-file-change");
                buildListImage();
            });
        });

        // Menu context mở rộng
        var btn2 = $("<span class='input-group-addon label-primary' style='border-left: 0px; border-color:#0081c5' data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>");
        btn2.append("<i class='fas fa-plus'></i>");
        btnUpload.after(btn2);

        var menuDropdown = $("<ul class='dropdown-menu' style='left:unset;right:0px'>"); btn2.after(menuDropdown);

        var liFolder = $("<li><a><i class='fas fa-folder'></i><span>" + Core.getLabel("Chọn tệp") + "</span></a></li>"); menuDropdown.append(liFolder);
        liFolder.click(function () { btnUpload.click(); });

        if (dataInput.multi != true)
        {
            var liDownload = $("<li><a><i class='fas fa-cloud-download-alt'></i><span>" + Core.getLabel("Tải tệp") + "</span></a></li>"); menuDropdown.append(liDownload);
            liDownload.click(function ()
            {
                if (input.val() != "") Core.popup(input.val(), null, 600, 300);
                else Core.alert("Không tìm thấy tệp cần tải");
            });
        }
        
        if (dataInput.fileType == "Images")
        {
            var liSearchPlus = $("<li><a><i class='fas fa-search-plus'></i><span>" + Core.getLabel("Sắp xếp, lựa chọn ảnh") + "</span></a></li>"); menuDropdown.append(liSearchPlus);
            liSearchPlus.click(function ()
            {
                var html = "<table class='handsontable table-core-sh dataTable' style='width:100%' id='tableImage_" + Core.random(99999) + "'></table>";

                var popup = new Popup();
                popup.title = Core.getLabel("Sắp xếp, lựa chọn ảnh");
                popup.content = "";
                popup.clearWhenHide = true;
                popup.dialogType = "modal-lg";

                var data = Enumerable.From(input.val().split(','))
                          .Where(function (file) { return file != ''; })
                          .Select(function (file, index) { return { file: file, index: index + 1, id: Core.random(99999) }; }).ToArray();

                popup.buttons.push({
                    value: Core.getLabel("Thiết lập"), icon: "far fa-save", cls: "btn btn-success pull-left", func: function (element, scope) {
                        input.val(Enumerable.From(data).Select(function (item) { return item.file; }).ToString(","));
                        buildListImage();
                        popup.hide();
                    }
                });
                var table = null;
                popup.buttons.push({
                    value: Core.getLabel("Thêm ảnh"), icon: "fas fa-folder", cls: "btn btn-primary pull-left", func: function (element, scope) {
                        Core.showFiles(input.attr("data-file-type"), dataInput.multi, function (folder, files)
                        {
                            var newsFiles = Enumerable.From(files).Select(function (file, index) { return { file: folder + file, index: data.length + index, id: Core.random(99999) }; })
                                                                  .GroupJoin(data, function (n) { return n.file; },
                                                                                   function (o) { return o.file; },
                                                                                   function (n, os)
                                                                                   {
                                                                                       return { n: n, total: os.Count() };
                                                                                   })
                                                                  .Where(function (t) { return t.total == 0; })
                                                                  .Select(function (t) { return t.n; }).ToArray();

                            data = Enumerable.From(data).Concat(newsFiles)
                                                        .OrderBy(function (item) { return item.index; })
                                                        .Select(function (item, index) { item.index = index + 1; return item; })
                                                        .ToArray();

                            table.clear();
                            table.rows.add(data);
                            table.draw();
                        });
                    }
                });

                popup.onAlwaysShow = function()
                {
                    popup.popupBody.empty();
                    popup.popupBody.append(html);

                    table = popup.popupBody.find("table").DataTable({
                        scrollY: 390, paging: false, searching: false, info: false, order:[[2,"asc"]],
                         data: data, columns: [
                            {
                                data: "file", title: Core.getLabel("Đường dẫn"), orderable: false, createdCell: function (td, cellData, rowData, row, col)
                                {
                                    $(td).html("<a>" + cellData + "</a>");
                                    $(td).find("a").click(function ()
                                    {
                                        Core.popup(cellData, null, 600, 300);
                                    });
                                }
                            },
                            {
                                data: "file", title: Core.getLabel("Ảnh"), orderable: false, width: "54px", createdCell: function (td, cellData, rowData, row, col)
                                {
                                    $(td).addClass("text-center").html("<img src='" + cellData + "' style='width:44px; height: 30px;margin-top:4px;margin-bottom:4px' />");
                                }
                            },
                            {
                                data: "index", title: Core.getLabel("Sắp xếp"), orderable: true, width: "100px", createdCell: function (td, cellData, rowData, row, col)
                                {
                                    $(td).addClass("text-center").html('<input class="form-control input-sm" data-format="Numeric" style="text-align:center; width:100%;height:30px" value="' + (cellData) + '" />');
                                    $(td).benice();
                                    $(td).find("input").css("text-align", "center").change(function ()
                                    {   
                                        rowData.index = $(this).getMoney();
                                        table.clear();
                                        table.rows.add(data);
                                        table.draw();
                                    });
                                }
                            },
                            {
                                data: "file", title: Core.getLabel("Xóa"), orderable: false, width: "54px", createdCell: function (td, cellData, rowData, row, col)
                                {
                                    $(td).addClass("text-center").html('<a href="javascript:void(0)" data-cmd="true" data-col="3"><i class="fas fa-trash-alt fa-2x "></i> </a>');
                                    $(td).find("a").click(function ()
                                    {
                                        data = Enumerable.From(data).Where(function (item) { return item.id != rowData.id; })
                                                                    .Select(function (item, index) { item.index = index + 1; return item; })
                                                                    .ToArray();
                                        table.clear();
                                        table.rows.add(data);
                                        table.draw();
                                    });
                                }
                            }
                        ]
                    });
                }

                popup.show();
            });
        }

        var liEmpty = $("<li><a><i class='fas fa-sync-alt'></i><span>" + Core.getLabel("Làm mới") + "</span></a></li>"); menuDropdown.append(liEmpty);
        liEmpty.click(function ()
        {
            input.val("");
            buildListImage();
        });

        menuDropdown.parent().on("shown.bs.dropdown", function ()
        {
            menuDropdown.parent().find("[data-toggle=dropdown]").find("i").removeClass("fa-plus").addClass("fa-minus");
            menuDropdown.parent().find("[data-toggle=dropdown]").removeClass("label-primary").addClass("bg-blue");
        });
        menuDropdown.parent().on("hidden.bs.dropdown", function ()
        {
            menuDropdown.parent().find("[data-toggle=dropdown]").find("i").removeClass("fa-minus").addClass("fa-plus");
            menuDropdown.parent().find("[data-toggle=dropdown]").removeClass("bg-blue").addClass("label-primary");
        });
    });
}
$.fn.bindfunc = function(target)
{
    this.find('select[data-func]').change(function () { target[$(this).attr('data-func')].bind(target)($(this).val(), $(this)); });
    this.find('input[data-func][type=button]').click(function () { target[$(this).attr('data-func')].bind(target)($(this).val(), $(this)); });
    this.find('a[data-func][data-type=button]').click(function () { target[$(this).attr('data-func')].bind(target)($(this)); });
    this.find('button[data-func]').click(function () { target[$(this).attr('data-func')].bind(target)($(this)); });
}

$.fn.getDataContextOfSelect = function()
{
    var $this = this;

    var contextData = {};
    var dataFields = $this.attr("data-data-ajax");
    if (dataFields != null && dataFields != "")
        Enumerable.From(dataFields.split(',')).ForEach(function (field) {
            contextData[field] = $this.attr("data-" + field);
        });
    contextData.alias = $this.attr("data-alias");
    return contextData;
}
$.fn.reloadSelectInput = function(data, callback, cRes)
{
    if (this.length == 0) return;
    if (data == null) data = {};
    var $this = this;

    if ($this.attr("data-loading") == "true") return;
    $this.attr("data-loading", "true");

    var contextData = $this.getDataContextOfSelect();
    $.extend(data, contextData);

    var selectType = $this.attr("data-select-type");
    var isajax = $this.attr("data-select2-use-ajax");
    isajax = isajax != null && isajax.toLowerCase() == "true";

    if(selectType != "select2" || (selectType == "select2" && !isajax))
    {
        var currentValue = $this.val(); // Giá hiện thời trước khi tải lại dữ liệu
        var hasCurrentValue = false;

        var ajax = new CoreAjax();
        ajax.typeAction = $this.attr("data-type-action");
        ajax.assembly = $this.attr("data-assembly");
        ajax.post("GetDataAjax", data, function (res)
        {
            $this.find("option").remove();
            if (cRes != null) cRes(res);

            var htmlOption = "";
            if ($this.attr("multiple") != "multiple" && ($this.attr("data-use-default") == "True" || res.Data.ListItem.length == 0))
            {
                var valueDefault = $this.attr("data-value-default");
                var textDefault = $this.attr("data-text-default");
                htmlOption += "<option value='" + valueDefault + "'>" + textDefault + "</option>";
                //$this.append("<option value='" + valueDefault + "'>" + textDefault + "</option>");
            }
            var fieldValue = res.Data.DataValueField.T1.Name;
            var fieldText = res.Data.DataTextField.T1.Name;
            Enumerable.From(res.Data.ListItem).ForEach(function (item)
            {
                htmlOption += "<option value='" + item[fieldValue] + "'>" + item[fieldText] + "</option>";
                //$this.append("<option value='" + item[fieldValue] + "'>" + item[fieldText] + "</option>");
                if (hasCurrentValue != true && (item[fieldValue] + "") == currentValue)
                    hasCurrentValue = true;
            });

            $this.append(htmlOption);

            // trả lại dữ liệu trước khi thực hiện tải
            // Kiểm tra currentValue có nằm trong danh sách dữ liệu vừa thực hiện lấy về hay không
            if (hasCurrentValue) $this.val(currentValue);

            if (callback != null) callback(res);

            if (selectType != "select2") $this.trigger("chosen:updated");
            $this.removeAttr("data-loading");
        });
    }
    else if(selectType == "select2" && isajax)
    {
        $this.find("option").remove();
        if (callback != null) callback();
        $this.removeAttr("data-loading");
    }
}
$.fn.docolor = function (color)
{
    if (color == null) color = "red";
    var oldColor = this.css("color");
    this.animate({ color: color }, 1000, function ()
    {
        $(this).animate({ color: oldColor }, 1000, function ()
        {
            $(this).css({ color: "" });
        });
    });
}
$.fn.setHtml = function (value, color)
{    
    if (this.html() == $("<div>" + value + "</div>").html()) return this;
    this.html(value).docolor(color);
}
$.fn.inputKeypress = function(func, options)
{
    var $this = this;
    var t = null;

    if (options == null) options = {};
    if (options.time == null) options.time = 200;

    var run = function (input) 
    {
        if (t != null) clearTimeout(t);
        t = setTimeout(function () 
        {
            if (input.attr("data-text-current") != input.val()) 
            {
                func($this); 
                input.attr("data-text-current", input.val());
                input.trigger("sh-text-change");
            }
            t = null;
        }, options.time);
    };
    
    if (options.onFocus == null) options.onFocus = function ($this) { };
    if (options.onBlur == null) options.onBlur = function ($this) { run($this); };

    //this.on("input", function () { run(); });
    this.focus(function ()
    {
        var $this = $(this);
        $this.attr("data-text-current", $this.val());
        options.onFocus($this);
    });
    this.blur(function () { options.onBlur($(this)); });
    this.keypress(function (event) { run($(this)); });
    this.keyup(function (event)
    {
        if (event.keyCode == 8 || event.keyCode == 46)
            run($(this));
    });
    this.on("t-back", function () { run($(this)); });
}
$.fn.selectGetText = function()
{
    return this.find("option:selected").text();
}
$.fn.selectSetText = function(text)
{
    this.find("option").attr('selected', false);
    var option = this.find("option").filter(function () 
    { 
        return $.trim(this.text) == $.trim(text);
    });
    
    if (option.length == 0) return false;
    // option.attr('selected', true);
    this.val(option[0].value);
    return true;
}
$.fn.onTab = function(func)
{    
    this.keypress(function (event) 
    {
        if(event.key == "Tab")
        {
            func.bind(this)();
            return false;
        }
    });
}
$.fn.onEnter = function (func)
{
    this.unbind("keypress");
    this.keypress(function (event)
    {
        if (event.keyCode == "13")
        {
            func.bind(this)();
        }
    });
}
$.fn.onBTab = function(target)
{
    this.find('a[data-toggle="tab"]').on('shown.bs.tab', function (e) 
    {
        var aTab = $(e.target); var targetHref = aTab.attr("href");
        var tabData = aTab.data();
        var func = tabData.eventShow == null || tabData.eventShow == "" ? null : target[tabData.eventShow];
        if (func == null) func = target[targetHref];
        if (func != null) func.bind(target)(e, aTab);
    });
}

// options { entity, fieldKey, entityName}
$.fn.onCTab = function(target, options)
{
    var $this = this;
    if (options == null) options = {};
    var contentContainer = options.contentContainer;
    if (contentContainer == null) contentContainer = $this;

    var firstTab = this.find("[data-form]").find('a[data-toggle=tab]').eq(0);
    this.find('a[data-toggle="tab"]').on('shown.bs.tab', function (e) 
    {
        var aTab = $(e.target); var targetHref = aTab.attr("href");
        var tabData = aTab.data();
        var func = tabData.eventShow == null || tabData.eventShow == "" ? null : target[tabData.eventShow];
        if (func == null) func = target[targetHref];

        $.data(aTab[0], "hasClick", true); // Đánh dấu là Tab này đã được click
        if(tabData.needEntityExit)
        {
            if(options.entity() == null || options.entity()[options.fieldKey] == null || options.entity()[options.fieldKey] == 0)
            {
                Core.alert(Core.getLabel("Vui lòng cập nhật ") + options.entityName + Core.getLabel(" trước!!!"));
                firstTab.click();
                return;
            }
        }

        if (func != null) func.bind(target)(aTab, targetHref, e);
        else if(!(tabData.module == null || tabData.module == ""))
        {
            if (tabData.reloadWhenClick == null) tabData.reloadWhenClick = false;
            if (!tabData.reloadWhenClick && tabData.hasLoad) return;
            contentContainer.find(targetHref).html("");

            var data = { ByTab: true };

            var entity = options.entity == null ? {} : options.entity();

            if (options.fieldKey != null) data[options.fieldKey] = entity[options.fieldKey];
            if (options.fields != null)
                Enumerable.From(options.fields).ForEach(function (field) { data[field] = entity[field]; });

            var customerData = tabData.customerData;
            if (customerData != undefined && customerData != null && customerData != "" && target[customerData] != null) target[customerData](data, aTab);


            if (options.formatData != null) data = options.formatData(data);

            contentContainer.find(targetHref).loadModule(tabData.module, function (res, module) 
            {
                switch (module.moduleType) 
                {
                    case "table": module.onBeforeInitGrid(function (table) 
                    {
                        table.extendDataSearch = table.extendDataSave = table.extendDataEdit = function () { return data; };
                    }); break;
                }

                module.doCountForTab = function()
                {
                    if (tabData.methodCount == null) return;
                    module.table.post(tabData.methodCount, module.table.getParams(), function (res) { aTab.find("span").html("(" + res.Data.Total + ")"); });
                }

                module.afterSaveEntity = function(popup, msg, $continue, dataKey, res, data)
                {
                    if (dataKey[module.table.getFieldKey()] == null || dataKey[module.table.getFieldKey()] == 0)
                        module.doCountForTab();
                }

                var eventBeforeInit = tabData.beforeInit;
                if (eventBeforeInit != undefined && eventBeforeInit != null && eventBeforeInit != "" && target[eventBeforeInit] != null) target[eventBeforeInit](module, res, aTab);

                $.data(aTab[0], "hasLoad", true);
            }, data);
        }
    });
}
$.fn.onCTabFindTabNeedUpdateByKeyClicked = function()
{
    return Enumerable.From(this.find('a[data-toggle="tab"]')).FirstOrDefault(null, function (tab) 
    {
        var data = $(tab).data();
        return data.needEntityExit && data.hasClick;
    });
}
$.fn.getMoney = function()
{
    if (this.length == 0) return 0;
    var value = Core.replace(this.val(), ",", "");
    value = $.trim(value);
    if (value == "") return 0;
    return parseFloat(value);
}
$.fn.pushInput = function (values, prefix) { var value = this.val(); value = $.trim(value); if (value != "") values.push(prefix + value); };
$.fn.pushSelect = function (values, prefix) { if (this.val() != "0") values.push(prefix + this.selectGetText()); };
$.fn.BuildBoxSearch = function(option)
{
    if(option != null)
    {
        switch(option.cmd)
        {
            case "GetValues": 
                var values = {};
                var smallContainer = this.smallContainer;
                if (smallContainer != null && smallContainer.is(":visible")) $.extend(values, smallContainer.getValues());
                $.extend(values, this.getValues());
                return values;
        }
    }

    this.find("[data-search-for-table]").unbind("click");
    this.find("[data-search-for-table]").click(function () 
    {
        if (option.click != null) option.click();
    });
    
    return this;
}

$.fn.BuildBoxSearchInToolBar = function(option)
{
    var $this = this;

    if (Core.isMobile()) { $this.show(); return; };

    var buttonSearchRoot = $this.find("[data-search-for-table]");

    var barSmallSearch = option.containerSmallSearch;
    this.smallContainer = barSmallSearch;

    //var formGroups = Enumerable
    //    .From(this.find(".form-group"))
    //    //.Where(function (input) { return !$(input).hasClass("hide"); })
    //    .ToArray();

    var formGroups = Enumerable.From(this.find("[data-search-toolbar=true] .form-group")).ToArray();
    var topInputs = Enumerable.From(formGroups)
                              //.Take(option.topInputSearch)
                              .Select(function (input) { return { input: input, parent: $(input).parent() }; })
                              .ToArray();
    if (topInputs.length == 0) return;

    var divButton = $("<div class='form-group col-sm-1-5 pull-right' style='width:130px'>");
    var divGroupButton = $("<div class='btn-group'>"); divButton.append(divGroupButton);
    var buttonSearch = $("<button class='btn btn-flat btn-primary btn-sm'>");
    buttonSearch.html("<i class='fas fa-search' style='margin-right:10px;'></i>" + Core.getLabel("Tìm kiếm")); divGroupButton.append(buttonSearch);

    var divBtnGroup2 = $("<div class='btn-group'>"); divGroupButton.append(divBtnGroup2);

    var buttonDown = $("<button data-toggle='dropdown' aria-expanded='false' class='btn btn-flat btn-primary btn-sm dropdown-toggle' style='border-top-right-radius:0px; border-bottom-right-radius: 0px'>"); divBtnGroup2.append(buttonDown);
    buttonDown.append("<span class='fas fa-caret-down'></span>");

    var searchMore = this.find("[data-search-more=true]");
    if (searchMore.length > 0)
    {
        var ul = $('<ul class="dropdown-menu" style="right:0px;left:unset;box-shadow:none;padding:0px;width: 500px">'); var li = $("<li>"); ul.append(li);
        ul.click(function (e) { e.stopPropagation(); });

        var box = $('<div class="box box-success box-solid">'); li.append(box);
        var boxHeader = $('<div class="box-header with-border"><h3 class="box-title">' + Core.getLabel("Tìm kiếm mở rộng") + '</h3></div>'); box.append(boxHeader);
        var boxBody = $('<div class="box-body">'); box.append(boxBody);

        Enumerable.From(searchMore).ForEach(function (form)
        {
            boxBody.append($(form));
        });

        divBtnGroup2.append(ul);
    }

    barSmallSearch.append(divButton);

    buttonSearch.click(function () { buttonSearchRoot.click(); });

    var smallSearching = false;
    var funcBuildInputInToolBar = function()
    {
        for (var i = topInputs.length - 1; i >= 0; i--)
        {
            var t = $(topInputs[i].input);
            t.addClass("pull-right");
            barSmallSearch.append(t);
        }
        smallSearching = true;
    }
    funcBuildInputInToolBar();

    //var funcBuildInputInRootSearch = function ()
    //{
    //    for (var i = topInputs.length - 1; i >= 0; i--)
    //    {
    //        var p = $(topInputs[i].parent);
    //        var t = $(topInputs[i].input);
    //        t.removeClass("pull-right");
    //        p.prepend(t);
    //    }
    //    smallSearching = false;
    //}

    //buttonSearch.click(function () { buttonSearchRoot.click(); });

    //$this.restoreInput = function ()
    //{
    //    if (smallSearching == false) return;
    //    $this.hide();
    //    funcBuildInputInRootSearch();
    //}

    //var divGroupButtonRoot = $("<div class='btn-group'>"); buttonSearchRoot.parent().append(divGroupButtonRoot); divGroupButtonRoot.append(buttonSearchRoot);
    //var buttonDown = $("<button class='btn btn-primary btn-sm' style='border-top-right-radius:0px; border-bottom-right-radius: 0px'>"); divGroupButtonRoot.append(buttonDown);
    //buttonDown.append("<span class='fa fa-caret-down'></span>");
    //buttonDown.click(function () 
    //{
    //    $this.fadeOut(function () 
    //    {
    //        funcBuildInputInToolBar();
    //        divButton.show();
    //    });
    //});

    //funcBuildInputInToolBar();
}

$.fn.btnClick = function(loading, action)
{
    var $this = this;
    this.click(function (e) 
    {
        e.preventDefault();
        if (loading)
            $this.button('loading');
        // https://bootsnipp.com/snippets/featured/loading-button
        action($this);
    });
    this.done = function()
    {
        $this.button('reset');
    }
}
$.fn.selectVal = function(id, text, signChange)
{
    var option = this.find("option[value=" + id + "]");
    if (option.length == 0)
        this.append("<option value='" + id + "'>" + text + "</option>");

    //this.select2('data', { id: id, text: text });
    if (signChange == true)
        this.val(id + "").attr("data-select2-change", true).trigger('change').removeAttr("data-select2-change");
    else
        this.val(id + "").trigger('change');
}

$.fn.buildToogleOption = function(nameOption)
{
    var $this = this;
    var toogleOptionBind = $this.attr("data-toogle-option-bind-1");
    if (toogleOptionBind == "true") return;
    $this.attr("data-toogle-option-bind-1", "true");

    $this.find("[name=" + nameOption + "]").change(function () 
    {
        $this.find(".op").addClass("hide");
        $this.find(".op-" + $(this).val()).removeClass("hide");
    }).change();
}
$.fn.buildAllToogleOption = function()
{
    var $this = this;
    
    var toogleOptionBind = $this.attr("data-toogle-option-bind");
    if (toogleOptionBind == "true") return;
    $this.attr("data-toogle-option-bind", "true");

    var selectOptions = $this.find("select[data-option-key]");
    if (selectOptions.length > 0) $this.attr("data-has-select-option", "true");

    selectOptions.change(function ()
    {
        var select = $(this);
        var op = select.attr("data-option-key");

        var array = Enumerable.From($this).ToArray();
        if ($this.smallContainer != null) array = Enumerable.From(array).Concat($this.smallContainer).ToArray();
        var $thisF = $(array);

        $thisF.find("." + op).addClass("hide");
        $thisF.find("." + op + "-" + select.val()).removeClass("hide");

    }).change();
}

$.fn.errorImage = function(defaultImage)
{
    this.bind("error", function () 
    {
        var target = $(this);
        var t = target.attr("t");
        if (t == null || t == "") target.attr("t", "1");
        else target.attr("t", eval(t) + 1);
        if (eval(target.attr("t")) >= 2) return;
        target.attr("src", defaultImage);
    });

    this.each(function()
    {
        var $this = $(this);
        $this.attr("src", $this.attr("data-src"));
    });
}
$.fn.textAreaLength = function (option)
{
    if (option == null) option = { max: 90 };
    this.each(function () {
        var input = $(this);
        var span = $("<span style='float:right; font-size:11px'>");
        input.parent().append(span);
        input.keyup(function () {
            span.text(input.val().length + "/" + option.max);
            if (input.val().length > option.max) span.css("color", "red");
            else span.css("color", "inherit");
        }).keyup();
    });
}
$.fn.buildEditor = function (selector) {
    this.find(selector).each(function () {
        var editor = $(this);
        var data = { height: $(this).height() }; 
        if (data.height < 200) data.height = 200;
        editor.ckeditor(data).editor.on('change', function (e) {
            // var output = e.editor.getData();
            editor.trigger("core.editor.change");
        });
    });
}

$.fn.shScrollHeader = function (options)
{
    if (options == null) options = {};

    var $window = $(window), $stickies;

    this.each(function ()
    {
        var $thisSticky = $(this);
        var parents = $thisSticky.parents(".sh-stick-followWrap");
        if(parents.length > 0)
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

    var _whenScrolling = function () {
        $stickies.each(function (i) {
            var $thisSticky = $(this), $stickyPosition = $thisSticky.data('originalPosition');
            if ($stickyPosition <= $window.scrollTop()) // Kéo xuống
            {
                var $nextSticky = $stickies.eq(i + 1), $nextStickyPosition = $nextSticky.data('originalPosition') - $thisSticky.data('originalHeight') - options.offsetTop;
                // var $nextSticky = $stickies.eq(i + 1), $nextStickyPosition = $nextSticky.data('originalPosition') - $thisSticky.outerHeight() - options.offsetTop;
                $thisSticky.addClass("sh-fixed");
                if ($nextSticky.length > 0 && $thisSticky.offset().top >= $nextStickyPosition) {
                    $thisSticky.addClass("sh-absolute").css("top", $nextStickyPosition);
                }
            }
            else {
                var $prevSticky = $stickies.eq(i - 1);
                $thisSticky.removeClass("sh-fixed");
                if ($prevSticky.length > 0 && $window.scrollTop() <= $thisSticky.data('originalPosition') - $thisSticky.data('originalHeight'))
                //if ($prevSticky.length > 0 && $window.scrollTop() <= $thisSticky.data('originalPosition') - $thisSticky.outerHeight())
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
    $(window).off("scroll");

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

// Thiết lập click vào các nút thêm, sửa trên input
$(function ()
{
    $(window).on("click.input-select.cmd", function (event)
    {
        var target = $(event.target);
        var attr = target.attr("data-input-cmd");
        if (attr == null || attr == "")
        {
            target = target.parents("[data-input-cmd]");
            attr = target.attr("data-input-cmd");
        }
        
        if (attr == null || attr == "") return true;

        // Tìm đến select
        var select = target.parents(".vi-input-select").find("select");
        var ids = select.val();
        var texts = select.selectGetText();
        var isMulti = select.prop('multiple'); //ids.constructor === Array;

        var data = select.getDataContextOfSelect();

        if (attr == "Refresh")
        {
            select.reloadSelectInput(null, function (ress) { select.val(ids); });
            return;
        }

        var module = select.attr("data-module-manage");
        var fieldKey = select.attr("data-table-key");
        var textKey = select.attr("data-text-field");
        var defaultValue = select.attr("data-value-default");
        var entityName = select.attr("data-table-entity-name");

        var doAction = function(id, text)
        {
            var dataPost = { FromInput: true };

            switch (attr) {
                case "Add":
                    if (select.is(":disabled") == true) {
                        Core.alert("Không thể thêm dữ liệu khi lựa chọn bị khóa");
                        return;
                    }
                    break;
                default:
                    if (id == defaultValue)
                    {
                        Core.alert("Không thể thực hiện khi chưa xác định được <b>" + entityName + "</b>");
                        return;
                    }

                    dataPost[fieldKey] = id;
                    dataPost[textKey] = text;
                    break;
            }

            $.extend(dataPost, data);

            switch (attr) {
                case "Add":
                case "Edit":
                    Core.callEditOfModule(module, {
                        dataPost: dataPost,
                        afterSaveEntity: function (res, msg, _module)
                        {
                            select.reloadSelectInput(null, function (ress)
                            {
                                if (isMulti == true) select.val(Enumerable.From(ids).Concat([res.Data[fieldKey] + ""]).Distinct().ToArray()).change();                                
                                else select.val(res.Data[fieldKey] + "").change();
                            });

                            if (_module.afterAddOrEdit != null)
                                _module.afterAddOrEdit(res, select);
                        }
                    });
                    break;
                default: Core.loadModule(null, module, null, data, { afterInit: function (res, module) { module[attr](dataPost, select); } }); break;
            }
        }

        if (attr == "Add") doAction();
        else if (isMulti == false) doAction(ids, texts);
        else
        {
            if (ids.length == 1) doAction(ids[0], select.find("option:selected").eq(0).text());
            else
            {
                var popup = new Popup();
                var html = '<div class="form-horizontal">';
                html += '<div class="row">';
                html += '   <div class="col-sm-12">';
                html += '       <div data-form="entity" class="tb-no-left border-table-grid border-table-grid-bottom"></div>';
                html += '   </div>';
                html += '</div>'
                html += "</div>";
                popup.content = html;
                popup.title = Core.getLabel("Chọn <b>" + entityName + "</b>");

                var dataEntity = Enumerable.From(select.find("option:selected")).Select(function (option) {
                    return { EntityName: $(option).text(), EntityId: $(option).attr("value") };
                }).ToArray();

                var css = Enumerable.From(target.find("i").attr("class").split(' ')).Where(function (c) { return c.indexOf("fa") >= 0; }).ToString(" ");
                var cssColor = Enumerable.From(target.find("i").attr("class").split(' ')).Where(function (c) { return c.indexOf("text") >= 0; }).FirstOrDefault(null);
                if (cssColor == null) cssColor = "btn-succes";
                else cssColor = cssColor.replace("text", "bg");
                popup.buttons.push({
                    value: target.find("span").text(), icon: css, cls: "btn " + cssColor + " pull-left", func: function (element, scope) {
                        var entity = Enumerable.From(dataEntity).FirstOrDefault(null, function (item) { return item.selected == true; });
                        if(entity == null)
                        {
                            Core.alert("Vui lòng chọn chọn <b>" + entityName + "</b> trước khi thực hiện");
                            return;
                        }
                        doAction(entity.EntityId, entity.EntityName);
                        popup.hide();
                    }
                });
                popup.onAlwaysShow = function () {
                    var grid = new GridEntity(dataEntity, this.popupBody.find("[data-form=entity]"));
                    grid.entityName = entityName;
                    grid.init();
                };
                popup.show();
            }
        }

        return false;
    });

    var GridEntity = function(data, area)
    {
        $.extend(this, new Grid(data, area));
        this.wtHolder = 2;
        this.entityName = "Tên đối tượng";

        this.createColumns = function ()
        {
            return [{ data: "EntityName", width: "350px", title: this.entityName, readOnly: true }];
        }
        this.customerOption = function (options)
        {
            options.height = 200;
            options.minSpareRows = 0;
        }
        this.createContextMenu = function () { return null; };
        this.onInit = function () {
            var $this = this;
            Handsontable.hooks.add("afterSelection", function (r, p, r2, p2) {
                Enumerable.From($this.data).ForEach(function (c) { c.selected = false; });
                $this.getCurrentRow().selected = true;
            },
            this.hot);
        }
    }
});

$.fn.buildInputCurrencyMoney = function(main)
{
    var ajax = new CoreAjax("Web.Projects.ERP.FormCurrencies.ManageCurrencies");
    ajax.assembly = "Core.Sites.Apps";

    var allMoneyInput = this.find("[data-input=money-input]");

    allMoneyInput.each(function ()
    {
        var $this = $(this);

        var rateInput = $this.find("[data-input-element='rate'] input");
        var moneyInput = $this.find("[data-input-element='money'] input");
        var span = $this.find("[data-label=show-change] span");
        var currencyInput = $this.find("[data-input-element='currency'] select");

        var cache = {};

        var cal = function (save)
        {
            var rate = rateInput.getMoney();
            var money = moneyInput.getMoney();
            span.text(" = " + Core.formatMoney((rate * money)) + " đ ");

            if (save) cache["C_" + currencyInput.val()] = rate;
        }

        if ($this.attr("data-build") == "true")
        {
            cal();
            return;
        }

        var selectorDependencyDate = $this.attr("data-date");
        if (selectorDependencyDate != null) selectorDependencyDate = main.find(selectorDependencyDate);
        var getDate = function()
        {
            return selectorDependencyDate == null || selectorDependencyDate.length == 0 ? null : selectorDependencyDate.inputDateGetValue();
        }

        rateInput.inputKeypress(function ()
        {
            cal(true);
        });
        moneyInput.inputKeypress(function ()
        {
            cal();
        });

        var postToGetRate = function(date)
        {
            if (cache["C_" + currencyInput.val()] != null) {
                rateInput.val(cache["C_" + currencyInput.val()]);
                cal();
            }
            else ajax.post("GetExchangeRate", { CurrencyId: currencyInput.val(), Date: date }, function (res)
            {
                rateInput.val(res.Data.ExchangeRate);
                cal();
            });
        }

        currencyInput.change(function () { postToGetRate(getDate()); });
        $this.on("money-input-change-date", function (evt, date)
        {
            postToGetRate(date);
        });
        cal(true);

        $this.attr("data-build", "true");
    });

    Enumerable.From(this.find("[data-input=money-input][data-date]"))
              .GroupBy(function (ip) { return $(ip).attr("data-date"); })
              .ForEach(function (g)
              {
                  var selectorDependencyDate = g.Key();
                  if (selectorDependencyDate == null || selectorDependencyDate == "") return;
                  if (selectorDependencyDate != null) selectorDependencyDate = main.find(selectorDependencyDate);
                  if (selectorDependencyDate.length == 0) return;

                  selectorDependencyDate.find("input[data-type-date]").datepicker().on("changeDate", function ()
                  {
                      g.ForEach(function (ip)
                      {
                          $(ip).trigger("money-input-change-date", [selectorDependencyDate.inputDateGetValue()]);
                      });
                  });
              });
}

//$(function ()
//{
//    // Các phím nóng của trình duyệt cần được ngăn chặn
//    var blackKeys = ['Ctrl_t', 'Ctrl_o', 'Ctrl_h', 'Ctrl_n', 'Alt_t', 'Ctrl_s', 'Ctrl_f'];

//    var $document = $(document);
//    Enumerable.From(blackKeys).ForEach(function (bk) { $document.bind("keydown." + bk, function () { return false; }); });
//});