using Core.Forms;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Worker dành cho việc nghe ngóng có kết nối đến từ một Port
    /// Sau khi có kết nối đến đối tượng ManageConnection sẽ khởi tạo Connection và thực hiện gọi phương thức Connection.Start()
    /// </summary>
    /// <typeparam name="TCenter"></typeparam>
    public abstract class ConnectionAcceptLisener<TCenter, TConnection, TKey> : CenterThread<TCenter>, IConnectionAcceptLisener<TConnection, TKey>
        where TCenter : ICenter
        where TConnection : Connection<TCenter>, TConnectionKey<TKey>, IConnectionWithManager<TConnection>, new()
    {
        public ManageConnection<TKey, TConnection> ManageConnection { set; get; }

        /// <summary>
        /// Port cần nghe ngóng TcpClient kết nối đến
        /// </summary>
        public int Port { set; get; }

        sealed protected override void DoWork()
        {
            var client = server.AcceptTcpClient();
            Thread.Sleep(30);

            client.LingerState = new LingerOption(true, 0);
            client.NoDelay = true;

            var connection = ManageConnection.NewConnection();
            connection.TcpClient = client;
            connection.Center = Center;
            connection.State.Port = Port;

            connection.Start();
        }

        protected override bool OnPrepare(object sender)
        {
            this.WithThrow<SocketException>(ex => ShowMessage("Đã dừng server, không thể nghe ngóng " + typeof(TConnection).Name + " gửi đến cổng " + Port));

            server = new TcpListener(IPAddress.Any, Port);
            server.Start();
            Center.ShowMessage("Bắt đầu lắng " + typeof(TConnection).Name + " nghe trên cổng " + Port);

            return true;
        }

        protected override void OnFinish(object sender)
        {
            if (server != null)
            {
                server.Stop();
                server = null;
            }

            if (ManageConnection != null) ManageConnection.Stop();
        }

        private TcpListener server = null;
    }

    public interface IConnectionAcceptLisener<TConnection, TKey>
        where TConnection : Connection, TConnectionKey<TKey>, IConnectionWithManager<TConnection>, new()
    {
        ManageConnection<TKey, TConnection> ManageConnection { set; get; }
        int Port { set; get; }
    }
}
