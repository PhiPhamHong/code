using Core.Utility.IO;
using Core.Extensions;
using System;
using System.Net.Sockets;

namespace Core.Utility.Sockets
{
    public partial class Connection
    {
        /// <summary>
        /// socketAsync điều khiển các hoạt động không đồng bộ của socket
        /// Cụ thể ở đây là điều khiển việc nhận dữ liệu.
        /// Mỗi lần nhận dữ liệu thành công thì sự kiện Completed sẽ được gọi
        /// </summary>
        private SocketAsyncEventArgs socketAsync = new SocketAsyncEventArgs();

        private void Receive()
        {
            try
            {
                if (buffer == null) buffer = new byte[BufferSize];
                else Array.Clear(buffer, 0, buffer.Length);
            }
            catch (ArgumentNullException) { buffer = new byte[BufferSize]; }
            catch (IndexOutOfRangeException) { buffer = new byte[BufferSize]; }

            try { socketAsync.SetBuffer(buffer, 0, BufferSize); }
            catch { Stop(); return; }

            OnTcpClient((tcp, socket) =>
            {
                try { socket.ReceiveAsync(socketAsync); }
                catch (ObjectDisposedException) { Stop(); }
                catch (SocketException) { Stop(); }
            });
        }

        /// <summary>
        /// Lắng nghe các hoạt động của socket được thực hiện xong
        /// Ở đây chỉ bắt sự kiện nhận dữ liệu thành công thôi
        /// </summary>
        private void socketAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive: ProcessReceive(); break;
                case SocketAsyncOperation.Disconnect: Stop(true); break;
            }
        }

        /// <summary>
        /// Xử lý mảng byte được nhận về.
        /// 1. Nếu mà không có byte nào được nhận về thì nguy cơ Connection bị disconnect => Stop Connection lại luôn
        /// 2. Nhận được mảng byte sẽ gộp với dữ liệu còn xót lại của lần trước nếu có => đề phòng bản tin lần trước checksum bị sai do bản tin bị cắt
        /// 3. Split các bản tin được ngăn cách nhau bởi $DATA
        /// 4. Đưa các bản tin vào xử lý. Bản tin cuối cùng nếu checksum bị sai thì sẽ được lưu lại để cộng với dữ liệu lần sau.
        /// 
        /// Ngày 1/12/2015: Phát hiện lỗi IndexOutOfRangeException gây lỗi chết server
        /// Đã kiểm tra các thư viện gây ra lỗi IndexOutOfRangeException và chỉ thấy ở các thư viện Array mới có Exception này
        /// Nghi ngờ các hàm MessageProtocol.Split có duyệt mảng byte gây ra lỗi
        /// => Try catch tại dòng 67 để log lỗi và theo dõi
        /// Tham khảo Link về IndexOutOfRangeException: https://msdn.microsoft.com/en-us/library/system.indexoutofrangeexception%28v=vs.110%29.aspx
        /// 
        /// Ngày 4/12/2015: Đã ghi được Log lỗi IndexOutOfRangeException. Xác định được nguyên nhân lỗi ngày 1/12/2015
        /// Đã thực hiện Test lỗi log ghi được ở Staxi.Test.Modules.TestReceiveBytes
        /// Nguyên nhân: do bản tin cuối cùng nhận được chỉ có 8 byte, trong đó 5 byte đầu là $DATA, còn 3 byte. Không đủ một bản tin. Nhưng vẫn thực hiện checksum thành công
        /// Như vậy Hàm MessageProtocol.Split có thể vẫn đúng và chưa chạy sai.
        /// Khi nhận được bản tin 8 bytes, sau đó xác định Id bản tin thì bị lỗi IndexOutOfRangeException vì Id bản tin từ byte 17,18
        /// Cách khắc phục: Hàm BinaryLibrary.ValidChecksum sẽ kiểm tra bản tin trên 24 byte mới thực hiện checksum.
        /// Bản tin cuối cùng bị lỗi sẽ được lưu lại để ghép với lần nhận dữ liệu tiếp theo như trường hợp bản tin bị cắt
        /// Trong lần ghi log này đã kiểm nghiệm được bản tin bị cắt, có lưu lại để ghép với lần nhận dữ liệu sau nên bản tin không bị mất.
        /// </summary>
        private void ProcessReceive()
        {
            try
            {
                if (socketAsync.BytesTransferred == 0) { Stop(true); return; }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("ProcessReceive.BytesTransferred = 0", ex);
                Stop();
            }

            LastTime = DateTime.Now;
            byte[] last = null, value = null;

            try
            {
                value = buffer.SubArray(0, socketAsync.BytesTransferred);
                int oldLen = currentData.Length;
                if (oldLen == 0) currentData = value;
                else value.AppendTo(ref currentData);
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("ProcessReceive.Buffer", ex);
                Stop();
            }

            try
            {
                var packets = Protocol.Split(currentData);

                foreach (var packet in packets)
                {
                    last = null;
                    if (Protocol.ValidChecksum(packet)) Process(packet);
                    else last = packet;
                }
            }
            catch (Exception ex)
            {
                last = null; // Lỗi thì cho nhận lại từ đầu
                FileHelper.WriteLog("ProcessReceive: " + Environment.NewLine + "Data nhận được: " + value.JoinString(b => b) + Environment.NewLine + "Data hiện tại: " + currentData.JoinString(b => b) + Environment.NewLine, ex);
            }

            // Tiếp tục nhận dữ liệu cho lần tiếp theo
            // Array.Clear(currentData, 0, currentData.Length);
            currentData = last ?? new byte[] { };
            Receive();
        }

        private byte[] currentData = new byte[] { };
        public const int BufferSize = 1024;
        private byte[] buffer = null;

        private void ClearBuffer() { }
    }
}
