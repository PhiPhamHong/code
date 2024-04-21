namespace Core.Utility.Sockets
{
    /// <summary>
    /// Đánh dấu xem CommandInfo nào là lệnh Ping.
    /// Mục đích các lệnh Ping thì không ghi ra log màn hình
    /// Để tiện việc theo dõi. 
    /// </summary>
    public interface ICommandPing
    {
    }

    /// <summary>
    /// Đánh đâu CommandInfo nào là để thực hiện đăng nhập
    /// </summary>
    public interface ICommandLogin
    {

    }
}
