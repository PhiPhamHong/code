namespace Core.Utility.Sockets
{
    /// <summary>
    /// Cụ thể hóa là Command này sẽ phải thuộc Connection nào và chỉ xử lý dữ liệu nhận về Connection ấy
    /// Ví dụ Connection từ mobile lái xe kết nối tới server thì sẽ chỉ có riêng Command cho Connection này.
    /// <example>
    /// Command<MobileDriverClient> => nghĩa là Command dành cho MobileDriver kết nối tới
    /// Khi đó 
    /// Command<MobileDriverClient> không thể dùng cho Connection khác, ví dụ như MobileCustomerClient (Connection từ phía khách hàng)
    /// </example>
    /// </summary>
    /// <typeparam name="TConnection">Loại kết nối</typeparam>
    public abstract class Command<TConnection> : Command where TConnection : Connection
    {
        public TConnection Connection { set; get; }

        /// <summary>
        /// Có thực hiện giải mã bằng sessionKey để lấy được data content hay không?
        /// </summary>
        public virtual bool UseSessionKey
        {
            get { return true; }
        }
    }
}
