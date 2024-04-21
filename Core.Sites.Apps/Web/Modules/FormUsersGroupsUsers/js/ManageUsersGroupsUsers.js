function ManageUsersGroupsUsers()
{
    $.extend(this, new ModuleGrid());
    this.beforeInitGrid = function (table) { table.lengthBar = "5"; };
}