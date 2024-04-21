function FormUpdateCompanyConfig() 
{
    $.extend(this, new ModuleBase());
    var $this = this;

    $this.init = function (res)
    {
        var form = new FormEditor();
        form.typeAction = "Web.Modules.FormCompanyConfigs.FormUpdateCompanyConfig";
        form.start($this.getMain(), res.Data.Entity);

        $this.getMain().find("select[name=CompanyId]").change(function ()
        {
            form.post("ReloadByCompanyId", { CompanyId: $(this).val() }, function (res) 
            {
                var content = $(res.Data.Html);
                $this.getMain().find("[data-form=config-body]").html(content.find("[data-form=config-body]").html());
                $this.getMain().removeAttr("data-has-be-nice");
                $this.getMain().fillForm(res.Data.Entity);
            });
        });

        var selectOrderTypes = $this.getMain().find("[name=ShowOrderTypes]");
        selectOrderTypes.on('select2:select', function(e)
        {
            var elm = e.params.data.element;
            $elm = jQuery(elm);
            $t = jQuery(this);
            $t.append($elm);
            $t.trigger('change.select2');
        });
    }
}