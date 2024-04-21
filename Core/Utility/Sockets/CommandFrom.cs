namespace Core.Utility.Sockets
{
    /// <summary>
    /// Enum định nghĩa các luồng bản tin trong hệ thống
    /// Các Command sẽ được đánh dấu là sẽ xử lý ICommandInfo được đi từ khối nào đến
    /// Việc đánh dấu này sẽ tránh cho sự nhầm lẫn xử lý nhầm các CommandInfo từ các khối khác. 
    /// Và chỉ định là Command này sẽ chỉ xử lý cho các CommandInfo đến từ một khối duy nhất
    /// </summary>
    public enum CommandFrom
    {
        DeviceToServer = 0
    }
}
