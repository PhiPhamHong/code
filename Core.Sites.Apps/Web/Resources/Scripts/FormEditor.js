/// <reference path="../Plugins/jQuery/jQuery-2.1.3.min.js" />
/// <reference path="../Plugins/linq/linq.min.js" />
/// <reference path="Core.js" />
/// <reference path="CoreAjax.js" />

function FormEditor()
{
    $.extend(this, new CoreAjax());

    this.buttons = [];
    var divMsg = null;
    var footer = null;

    this.buildDataSave = null;
    this.entity = null;
    this.formMain = null;

    this.start = function(main, entity, res)
    {
        var $this = this;
        $this.entity = entity;
        $this.formMain = main;

        footer = main.find(".data-main-footer");
        divMsg = $('<div class="box-body" style="padding-top:0px;padding-bottom:40px"><div class="row"><div class="col-xs-12"><div class="msg-area"></div></div></div></div>').insertBefore(footer);
        divMsg = divMsg.find(".msg-area");

        $this.buttons.push({ value: "Lưu(Crtl + S)", icon: "fas fa-save", cls: "", func: function (element, scope)
        {
            var dataKey = { };
            $.extend(dataKey, main.getValues("[data-form=languages]"));
            main.find("[data-form=languages] div[data-form^=entity-language-]").each(function () { dataKey[$(this).attr("data-form")] = $(this).getValues(); });

            if ($this.buildDataSave != null) dataKey = $this.buildDataSave(dataKey);

            $this.post("Save", dataKey,
                function (resSave)
                {
                    if ($this.afterSaveSuccess != null) $this.afterSaveSuccess(resSave);
                    else if (footer.attr("data-func-success") != null) $this[footer.attr("data-func-success")](resSave);
                    else if (footer.attr("data-url") != null) Core.go(footer.attr("data-url"));
                    else Core.alert("Cập nhật thành công");
                },
                function (resSave) { $this.showMsgError(resSave.Data.MessageError); })
        }});

        if(footer.attr("data-url-back") != null)
            $this.buttons.push({ value: "Thoát", icon: "fas fa-sign-out-alt", cls: "btn btn-default btn-back", func: function (element, scope) { Core.go(footer.attr("data-url-back")); } });
        
        Enumerable.From($this.buttons).ForEach(function (btnInfo)
        {
            var btn = $("<button type='button'> ");

            if (btnInfo.icon != null)
                btn.append("<span class='" + btnInfo.icon + "'></span> ");
            btn.append(Core.getLabel(btnInfo.value));

            btn.addClass(btnInfo.cls == null || btnInfo.cls == "" ? "btn btn-primary" : btnInfo.cls);
            btn.addClass("btn-flat btn-sm")
            btn.click(function () { btnInfo.func(this, $this); });
            footer.append(btn); footer.append(" ");
        });
        
        if(res != null && res.Data.EntityLanguages != null)
        {
            main.find("[data-form=languages]").each(function()
            {
                var formLanguages = $(this);

                Enumerable.From(res.Data.Languages).Join(res.Data.EntityLanguages,
                    function (language) { return language.LanguageId; },
                    function (entityLanguage) { return entityLanguage.LanguageId; },
                    function (language, entityLanguage) 
                    {
                        formLanguages.find("[data-form=entity-language-" + language.LanguageId + "]").fillForm(entityLanguage);
                    }).Count();
            });
        }

        main.fillForm(entity, true, "[data-form=languages]");
    }

    this.back = function () { footer.find(".btn-back").click(); }
    this.afterSaveSuccess = null; // res

    // Hiển thị thông báo
    this.showMsg = function (msg, title, timeOut, type)
    {
        divMsg.empty();
        divMsg.coreAlert(msg, title, timeOut, type);
    }

    this.showMsgSuccess = function (msg) { this.showMsg(msg, null, null, alertType.alertSuccess); }
    this.showMsgError = function (msg) { this.showMsg(msg, null, null, alertType.alertDanger); }
}

function ModuleEdit()
{
    $.extend(this, new ModuleBase()); this.typeAction = "";
    this.init = function(res)
    {
        var form = new FormEditor();
        if (this.typeAction != "") form.typeAction = this.typeAction;
        else
        {
            form.typeAction = res.Data.ModuleTypeAction;
            form.assembly = res.Data.ModuleProject;
        }

        this.beforeInitExtend(form);
        this.beforeInitForm(form);
        form.start(this.getMain(), res.Data.Entity, res);
        this.afterStart(form);
    }

    this.beforeInitForm = function(form) { }
    this.beforeInitExtend = function(form) { }

    this.afterStart = function(form) { }
    this.onAfterStart = function(func) 
    {
        var $this = this;
        var old = $this.afterStart;
        $this.afterStart = function(form)
        {
            old.bind($this)(form);
            func.bind($this)(form);
        }
    }
}

function ModuleEditTab()
{
    $.extend(this, new ModuleEdit());
    this.fieldKey = "";

    this.beforeInitExtend = function(form)
    {
        var $this = this;
        form.afterSaveSuccess = function(res)
        {
            if (form.entity == null || form.entity.Key == 0) 
            {
                var secondTab = $this.getMain().find('[data-form=true] a[data-toggle=tab]').eq(1);
                if(secondTab.length > 0)
                {
                    CoreAlertConfirm(Core.getLabel("Bạn có muốn cập nhật {0}?").format(secondTab.html()), function () 
                    {
                        if (form.entity == null) form.entity = { }; form.entity.Key = res.Data.EntityKey;
                        secondTab.click();
                    }, function () { form.back(); });
                }
                else form.back();
            }
            else form.back();
        }

        var firstTab = $this.getMain().find("[data-form=true]").find('a[data-toggle=tab]').eq(0);

        $this.getMain().find("[data-form=true]").find('a[data-toggle="tab"]').on('show.bs.tab', function (e) 
        {
            var target = $(e.target); var targetHref = target.attr("href");
            if(form.entity == null || form.entity.Key == 0)
            {                
                if (targetHref == firstTab.attr("href")) return;
                CoreAlert(Core.getLabel("Vui lòng cập nhật {0} trước!").format(target.html()), function () { firstTab.click(); });
            }
            else
            {
                if ($(e.target).attr("data-has-load") == "true") return;
                var control = $(e.target).attr("data-control");
                if (control == undefined || control == null || control == "") return;

                // Thực hiện tải module theo attribute data-control
                $this.getMain().find(targetHref).loadModule(control, function (res, module) 
                {
                    var eventBeforeInit = $(e.target).attr("data-before-init");
                    if (eventBeforeInit != undefined && eventBeforeInit != null && eventBeforeInit != "" && $this[eventBeforeInit] != null) $this[eventBeforeInit](module, res, form);
                    
                    switch(module.moduleType)
                    {
                        case "table":
                            module.onBeforeInitGrid(function(table)
                            {
                                table.extendDataSearch = table.extendDataSave = table.extendDataEdit = function () 
                                { 
                                    var data = { }; 
                                    data[$this.fieldKey] = form.entity.Key;
                                    return data;
                                };
                            });
                            break;
                    }

                    $(e.target).attr("data-has-load", "true");
                });
            }
        });
    }
}