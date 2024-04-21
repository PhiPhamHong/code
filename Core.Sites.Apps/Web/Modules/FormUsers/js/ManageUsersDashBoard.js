function ManageUsersDashBoard()
{
    $.extend(this, new DashBoardControlTemplateOption());
    $.extend(this, new CoreAjax());
    this.typeAction = "Core.Sites.Apps.Web.Modules.FormUsers.ManageUsersDashBoard"; 
    this.prefix = "ManageUsersDashBoard";
    this.option = "OptionReportType";
}