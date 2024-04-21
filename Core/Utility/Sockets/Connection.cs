using System;
namespace Core.Utility.Sockets
{
    /// <summary>
    /// Định nghĩa một kết nối giữa các khối với nhau
    /// Mỗi một Connection chứa một TcpClient.
    /// Nhiệm vụ Connection sẽ nghe ngóng nhận dữ liệu gửi về 
    /// và thực hiện gửi dữ liệu đi thông qua TcpClient
    /// </summary>
    public abstract partial class Connection : Messagable, IDisposable
    {
        /// <summary>
        /// Xử lý dữ liệu nhận về
        /// data nhận về là đầy đủ cấu trúc của một bản tin. Gồm $DATA MessageCode Date CommandId DataLength Data Checksum
        /// </summary>
        protected abstract void Process(byte[] data);

        /// <summary>
        /// Phương thức bắt đầu connection.
        /// Khi một Tcp được khởi tạo hoặc được Apcept. Connection sẽ được khởi tạo. và chạy phương thức này
        /// Sau khi Start() được gọi thì Connection bắt đầu nghe ngóng dữ liệu gửi về
        /// </summary>
        public void Start()
        {
            if (TcpClient == null) return;
            StartHelper();
        }

        /// <summary>
        /// Stop() được gọi sẽ ngừng nghe ngóng dữ liệu gửi về
        /// Đóng TcpClient, socket Các hành động gửi và nhận dữ liệu sẽ không thực hiện được nữa
        /// </summary>
        public void Stop(bool lost = false)
        {
            StopHelper(lost);
        }

        public virtual void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }

        public virtual void OnErrorDeserialize(Type type, object value) { }
    }
}
