using Core.Utility.IO;
using System;
using System.Net.Sockets;

namespace Core.Utility.Sockets
{
    public partial class Connection
    {
        /// <summary>
        /// Start Connection =>
        /// Khởi tạo sự kiện Completed của socketAsync và gọi Receive() để thực hiện
        /// lắng nghe dữ liệu gửi về liên tục
        /// </summary>
        private void StartHelper()
        {
            LastTime = DateTime.Now;
            socketAsync.Completed += socketAsync_Completed;
            Receive();
        }

        /// <summary>
        /// Stop Connection =>
        /// 1. Nếu lệnh gửi đang được thực hiện thì kết thúc ngay lập tức
        /// 2. Shutdown cả 2 quá trình nhận và gửi dữ liệu
        /// 3. Close TcpClient
        /// </summary>
        private void StopHelper(bool lost = false)
        {
            if (ConnectState == ConnectState.CLOSED) return;

            ConnectState = ConnectState.CLOSED;
            try { sendDone.Set(); sendDone.Dispose(); }
            catch (ObjectDisposedException) { }

            try { TcpClient.Client.Shutdown(SocketShutdown.Both); }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }
            finally { if (TcpClient != null) { TcpClient.Close(); } }

            try { socketAsync.Dispose(); ClearBuffer(); }
            catch { }

            try { if (lost) OnLost(); }
            catch (Exception ex) { FileHelper.WriteLog("OnLost", ex); }

            try { OnStop(); }
            catch (Exception ex) { FileHelper.WriteLog("OnStop", ex); }
        }

        protected virtual void OnStop() { }
        protected virtual void OnLost() { }

        /// <summary>
        /// Thực hiện một hành động nào đó trên TcpClient
        /// Nhưng trước khi lấy được TcpClient để xử dụng thì nội tại hàm sẽ kiểm tra kết nối còn được giữ hay không
        /// Nếu kết nối không còn được giữ nữa thì return false và không thực hiện hành động gì cả
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool OnTcpClient(Action<TcpClient, Socket> action)
        {
            if (!IsConnecting()) return false;
            action(TcpClient, TcpClient.Client);
            return true;
        }

        /// <summary>
        /// Kiểm tra kết nối còn tốt hay không
        /// </summary>
        public bool IsConnecting()
        {
            if (ConnectState == ConnectState.CLOSED || TcpClient == null || TcpClient.Client == null || !TcpClient.Connected) return false;
            return true;
        }

        /// <summary>
        /// Ngày 24/12/2015
        /// Tính toán thời gian (giây) đã bao nhiêu lâu chưa nhận được dữ liệu. 
        /// </summary>
        public double LongtimeNotReceiveBytes
        {
            get { return (DateTime.Now - (LastTime == null ? DateCreated : LastTime.Value)).TotalSeconds; }
        }
    }
}
