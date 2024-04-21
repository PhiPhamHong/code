using System.ComponentModel;
using System.Text;
using Core.Extensions;
using System.Linq;
namespace Core.Utility.Sockets
{
    /// <summary>
    /// Lưu trữ trạng thái của một Connection
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ConnectionState //: IDisposable
    {
        /// <summary>
        /// Mỗi một Connection bao giờ cũng cần có một SessionKey để phục vụ cho việc mã hóa và giải mã bản tin trong quá trình truyền và nhận
        /// Những connection đến từ lái xe, khách hàng và điều hành thì SessionKey này sẽ được khởi tạo sau khi thực hiện Login
        /// SessionKey sẽ lưu trữ trong toàn bộ quá trình kết nối giữa các khối với nhau
        /// SessionKey sẽ được sinh ra bởi IStaxiCrypt.CreateSessionKey(byte[] messageCode)
        /// </summary>
        public string SessionKey
        {
            set
            {
                sessionKey = value;
                var bytes = Encoding.UTF8.GetBytes(sessionKey);
                sumSessionKey = bytes.Sum(b => b);
                sessionKeyBytes = bytes.JoinString(b => b);
            }
            get { return sessionKey; }
        }

        private string sessionKey = string.Empty;
        private string sessionKeyBytes = string.Empty;
        private int sumSessionKey = 0;

        public int SumSessionKey { get { return sumSessionKey; } }
        public string SessionKeyBytes { get { return sessionKeyBytes; } }

        ///// <summary>
        ///// Lưu lại mảng byte (bản tin) cuối cùng mà Connection thực hiện gửi đi
        ///// Nhằm mục đích lưu lại bản tin cuối gửi lỗi và để thực hiện gửi lại trong lần sau
        ///// </summary>
        //public byte[] LastBytes { set; get; }

        /// <summary>
        /// Cổng mà Connection kết nối đến
        /// </summary>
        public int Port { set; get; }

        //public virtual void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}
    }
}
