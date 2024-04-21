function FormUpdateGlobalConfig() 
{
    $.extend(this, new ModuleNormal());
    var $this = this;

    $this.onInit = function (res)
    {
        var form = new FormEditor();
        form.typeAction = this.typeAction;
        form.start($this.getMain(), res.Data.Entity);
    }
}