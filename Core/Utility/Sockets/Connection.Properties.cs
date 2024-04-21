using Core.Utility.Sockets.Crypts;
using System;
using System.ComponentModel;
using System.Data;
using System.Net.Sockets;

namespace Core.Utility.Sockets
{
    public partial class Connection
    {
        [Browsable(false)] public TcpClient TcpClient { set; get; } // Socket đã nhận kết nối hoặc đã kết nối

        public ConnectionState State { protected set; get; } // Lưu trữ trạng thái của Connection

        /// <summary>
        /// Trạng thái kết nối của Connection
        /// Khi Khởi tạo và phương thức Start được gọi thì ConnectState = OPENNED
        /// Khi phương thức Stop được gọi thì ConnectState = CLOSED
        /// </summary>
        public ConnectState ConnectState { protected set; get; }

        /// <summary>
        /// Thời điểm mà Connection này nhận dữ liệu gần nhất là khi nào
        /// Mỗi lần Hàm Process được gọi thì LasteTime sẽ cập nhật lại thời gian này
        /// LastTime sẽ giúp các Manager biết được trạng thái Connection là có kết nối hoặc đã mất kết nối thật sự hay không
        /// </summary>
        public DateTime? LastTime { get; private set; }

        public ICrypter Crypter { get; private set; } // Provider cung cấp hàm mã hóa và giải mã các bản tin gửi đi hoặc nhận về
        public Protocol Protocol { get; private set; } // Protocol định nghĩa cấu trúc bản tin gửi và nhận

        private readonly Guid connectionId = Guid.NewGuid();
        public Guid ConnectionId { get { return connectionId; } }

        private readonly DateTime dateCreated = DateTime.Now;
        public DateTime DateCreated { get { return dateCreated; } } // Thời gian Connection được tạo
    }

    /// <summary>
    /// Định nghĩa trạng thái kết nối của Connection
    /// </summary>
    public enum ConnectState
    {
        OPENNED = 0,
        CLOSED = 1
    }
}