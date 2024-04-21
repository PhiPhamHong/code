using Core.Utility.IO;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Core.Extensions;
namespace Core.Utility.Sockets
{
    public partial class Connection
    {
        /// <summary>
        /// Điều khiển việc gửi dữ liệu một cách tuần tự
        /// Sau khi socket gọi BeginSend thì sendDone.WaitOne() được gọi.
        /// Tại Hàm AsynCallback sendDone.Set() được gọi để giải phóng block code để lần gửi sau được tiếp tục
        /// </summary>
        private readonly ManualResetEvent sendDone = new ManualResetEvent(false);
        private readonly object sendObj = new object();

        /// <summary>
        /// Thực hiện gửi đi một mảng bytes.
        /// Phương thức SendBytes sử dụng socket.BeginSend. 
        /// Trước khi việc gửi được hoàn tất thì ManualResetEvent sendDone sẽ block code bởi phương thức WaitOne.         
        /// Vì vậy kết quả của việc gửi sẽ được biết trong SendCallback thông qua tổng số byte được gửi đi
        /// và ManualResetEvent sendDone phải gọi phương thức Set để Connection có thể
        /// thực hiện lần gửi dữ liệu tiếp theo và lúc này phương thức SendBytes mới được kết thúc
        /// </summary>
        /// <param name="bytes">Mảng bytes cần gửi đi</param>
        /// <returns>true: Nếu thực hiện gửi thành công. false: Gửi thất bại</returns>
        public bool SendBytes(byte[] bytes)
        {
            try
            {
                lock (sendObj)
                {
                    Socket socket = null; OnTcpClient((tcp, sk) => socket = sk);
                    if (socket == null) return false;

                    int bytesSent = 0;
                    sendDone.Reset();
                    socket.BeginSend(bytes, 0, bytes.Length, 0, ar => SendCallback(ar, out bytesSent), this);
                    sendDone.WaitOne(); // Block code, đợi SendCallback sendDone.Set()

                    return bytesSent != 0;
                }
            }
            catch (ObjectDisposedException) { return false; }
            catch (AbandonedMutexException) { return false; }
            catch (InvalidOperationException) { return false; }
            catch (SocketException) { Stop(); return false; }
            catch (Exception ex)
            {
                FileHelper.WriteLog(GetType().FullName + ".SendBytes", ex);
                return false;
            }
        }

        public void LockSend(Action action)
        {
            lock (sendObj) { action(); }
        }

        /// <summary>
        /// SendCallback đc gọi khi việc gửi dữ liệu đi được thực hiện thành công        
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="bytesSent">Tổng số byte đã được gửi đi</param>
        private void SendCallback(IAsyncResult ar, out int bytesSent)
        {
            try
            {
                int _bytesSent = 0;
                OnTcpClient((tcp, socket) => _bytesSent = socket.EndSend(ar));
                bytesSent = _bytesSent;

                // Giải phóng block code => WaitOne được vượt qua để kết thúc phương thức SendBytes
                try { sendDone.Set(); }
                catch (ObjectDisposedException) { }
            }
            catch (Exception ex)
            {
                bytesSent = 0;
                FileHelper.WriteLog(GetType().FullName + ".SendCallback", ex);
            }
        }

        /// <summary>
        /// Thực hiện gửi đi một mảng bytes. Tuy nhiên có được yêu cầu
        /// lưu lại mảng bytes được gửi đi vào State.LastBytes trước khi gửi hay không.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="saveState"></param>
        public bool Send(byte[] bytes, bool saveState = true)
        {
            // if (saveState) State.LastBytes = bytes;
            return SendBytes(bytes);
        }

        /// <summary>
        /// Thực hiện gửi một CommandInfo đi. CommandInfo là một ICommandInfo nên có phương thức Serialize để lấy 
        /// được các thuộc tính của CommandInfo convert ra mảng bytes. Tiếp đó nhờ Crypter mã hóa
        /// rùi đóng gói vào protocol.
        /// Sau đó gọi hàm SendBytes để gửi đi
        /// </summary>
        /// <typeparam name="TCommandInfo">ICommandInfo => để có thể sử dụng được phương thức Serialize, biết được CommandType để đóng gói vào protocol</typeparam>
        /// <param name="commandInfo"></param>
        /// <param name="saveState">Có lưu mảng byte cần gửi đi không</param>
        /// <param name="userSessionKey">Có sử dụng sessionKey để thực hiện mã hóa bản tin hay không. Nếu true sessionKey được lấy trong ConnectionState</param>
        public virtual bool Send<TCommandInfo>(TCommandInfo commandInfo, bool saveState = true, bool userSessionKey = true) where TCommandInfo : ICommandInfo
        {
            commandInfo.Date = DateTime.Now;
            var packet = Protocol.CreatePacket(commandInfo, Crypter, userSessionKey ? State.SessionKey : string.Empty);
            var result = Send(packet, saveState);

            if (!(commandInfo is ICommandPing) || !result)
            {
                // Có hiển thị thông báo gửi Message thành công lên màn hình Console
                if (NeedShowMessage) ShowMessage("Đã gửi " + State + ": " + commandInfo + " - Kết quả: " + result);

                // Ghi log bản tin gửi đi => test gửi sai lệch byte
                if (NeedLog);
            }

            return result;
        }

        public virtual bool Send<TCommandInfo>(Action<TCommandInfo> with, bool saveState = true, bool userSessionKey = true) where TCommandInfo : ICommandInfo, new()
        {
            using (var msg = new TCommandInfo())
            {
                with(msg);
                return Send(msg, saveState, userSessionKey);
            }
        }
    }
}
