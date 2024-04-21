using System;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Định nghĩa một xử lý trong một Connection khi nhận mảng byte từ các khối gửi đến
    /// Mỗi một Connection sẽ có nhiều Command. Ứng với mỗi một CommandInfo thì sẽ có một Command để xử lý
    /// Vì vậy mỗi Command cần xác định rõ CommandId => để xác định được CommandInfo nhận xử lý.
    /// </summary>
    public abstract class Command : IDisposable
    {
        /// <summary>
        /// Mã lệnh => hay còn gọi là loại lệnh
        /// </summary>
        public abstract short CommandId { get; }

        /// <summary>
        /// Xử lý mảng byte nhận được 
        /// </summary>
        /// <param name="msgCode">Bảng byte dùng để giải mã</param>
        /// <param name="time">Ngày giờ khối kia gửi bản tin đi</param>
        /// <param name="data">Dữ liệu cần Desialize để lấy được thông tin lệnh</param>
        /// <param name="protocol">Toàn bộ mảng byte mà khối kia gửi đến</param>
        /// <param name="dataCryted">Là dữ liệu data trước khi được giải mã</param>
        // public abstract void Process(byte[] msgCode, DateTime time, byte[] data, byte[] protocol, byte[] dataCryted);
        public abstract void Process(IProtocolContent pc);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
