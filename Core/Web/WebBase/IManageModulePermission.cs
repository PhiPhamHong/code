namespace Core.Web.WebBase
{
    public interface IManageModulePermission
    {
        bool CanAdd { get; }
        bool CanEdit { get; }
    }

    public interface IManageModule
    {
        string GetTableEntityName();
        string GetTableFieldKeyName();
    }
}
