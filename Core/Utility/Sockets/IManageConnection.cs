using System;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// interface định nghĩa phương thức quản lý một nhóm Connection
    /// Đối tượng quản lý một nhóm Connection nhằm mục đích phân tải. 
    /// Nếu để hết Connection cho một đối tượng quản lý thì khi tìm kiếm một Connection theo key sẽ mất thời gian
    /// </summary>
    /// <typeparam name="TConnection">Loại Connection cần quản lý</typeparam>
    public interface IManageConnection<TConnection> where TConnection : Connection
    {
        /// <summary>
        /// Phương thức tạo mới Connection
        /// </summary>
        /// <returns></returns>
        TConnection NewConnection();

        /// <summary>
        /// Thực hiện Logout một connection
        /// </summary>
        /// <param name="connection"></param>
        void Logout(TConnection connection, bool dispose = true);

        /// <summary>
        /// Thực hiện Login một connection
        /// </summary>
        /// <param name="connection">Connection đang login</param>
        /// <param name="oldnew">Xử lý hành động khi Connection cũ trùng key với Connection mới</param>
        bool Login(TConnection connection, Action<TConnection, TConnection> oldnew = null);

        /// <summary>
        /// Port của các connection đang kết nối đến
        /// </summary>
        int Port { get; set; }
    }
}