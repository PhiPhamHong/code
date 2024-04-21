namespace Core.Utility.Sockets
{
    /// <summary>
    /// interface IConnectionWithManager cho biết hiện TConnection này đang được quản lý bởi ManageConnection nào
    /// </summary>
    /// <typeparam name="TConnection"></typeparam>
    public interface IConnectionWithManager<TConnection> where TConnection : Connection
    {
        IManageConnection<TConnection> ManageConnection { set; get; }
    }
}
