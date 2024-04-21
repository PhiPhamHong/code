namespace Core.Utility.Sockets
{
    /// <summary>
    /// Định nghĩa Key cho Connection. Ngoài ConnectionId thì interface này sẽ quy định cho các đối tượng Connection Key khác nhau
    /// Ví dụ như Connection từ Khách hàng thì KeyConnection sẽ là điện thoại
    /// Connection đến từ lái xe thì KeyConnection sẽ là biển số xe
    /// Connection đến từ các trung tâm điều hành thì KeyConnection sẽ là CompanyId
    /// V.v..
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu của KeyConnection. có thể là string (Số điện thoại, Biển số xe) hoặc Int (Mã công ty)</typeparam>
    public interface TConnectionKey<T>
    {
        T KeyConnection { get; }

        void OnLogout();
    }
}
