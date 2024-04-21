using System;
namespace Core.Utility.Sockets
{
    /// <summary>
    /// ICommandInfo là interface định nghĩa các phương thức và thuộc tính cho một thông tin lệnh
    /// được gửi đi giữa các khối với nhau.
    /// Để các thông tin lệnh được truyền đi giữa các khối với nhau thì thông tinh lệnh phải được Serialize ra mảng byte để truyền đi
    /// Và sau đó khối nhận sẽ phải Deserialize để biết được thông tin lệnh gồm những dữ liệu gì
    /// </summary>
    public interface ICommandInfo : IDisposable
    {
        ///// <summary>
        ///// Deserialize convert từ mảng byte nhận được từ một khối nào đó và
        ///// điền dữ liệu lên các properties trong đối tượng kế thừa đến ICommandInfo
        ///// </summary>
        //void Deserialize(IProtocolContent pc);

        ///// <summary>
        ///// Serialize là convert thông tin lệnh thành mảng byte. Sau đó sẽ được truyền đi tới một khối nào đó
        ///// Serialize thực hiện đọc các properties trong đối tượng kế thừa đến ICommandInfo        
        ///// </summary>
        //byte[] Serialize();

        /// <summary>
        /// Mã của một CommandInfo. Mỗi một bản tin đi đều phải có một Mã lệnh duy nhất để biết được mã lệnh đó truyền đi để làm gì và sẽ gồm những thông tin gì
        /// Các mã lệnh được quy định theo như tài liệu cấu trúc protocol
        /// Cấu trúc mã lệnh có dạng như sau: xyzz. Trong đó x là khối truyền bản tin đi, y là khối nhận bản tin và zz là mã bản tin
        /// Ví dụ 6200. Trong đó 6: Khối truyền đi (mobile), 2: Khối nhận (Server), 00: Mã bản tin (DriverLogin)
        /// </summary>
        short CommandType { get; }

        /// <summary>
        /// Tên của lệnh.
        /// CommandName dùng để ghi ra log cho người kiểm tra khi tra cứu log. 
        /// Thay vì xem CommandType là một số thì phải vào tài liệu tra cứu xem là lệnh gì thì đọc CommandName sẽ dễ hơn nhiều.
        /// Ví dụ: 6200 thì CommandName = "DriverLogin". Có nghĩa là. bản tin mã 6200 là bản tin truyền từ lái xe về server để thực hiện đăng nhập
        /// </summary>
        string CommandName { get; }

        /// <summary>
        /// Ngày giờ bản tin được tạo ở khối truyền đi. 
        /// Lưu ý ngày giờ này ở các khối có thể là sẽ không đồng bộ nhau
        /// </summary>
        DateTime Date { set; get; }

        /// <summary>
        /// Đây là mảng byte được dùng để mã hóa và giải mã bản tin
        /// Mỗi bản tin gửi đi đều sẽ được mã hóa trước khi gửi đi, và MessageCode là mảng byte dùng để mã hóa
        /// Khi khối nhận được MessageCode thì dùng để thực hiện giải mã lại
        /// </summary>
        byte[] MessageCode { set; get; }

        /// <summary>
        /// Convert đối tượng lệnh thành string để ghi ra log
        /// </summary>
        /// <param name="date">Date có thể là giờ ở khối gửi đi hoặc ở khối nhận tùy theo nơi hàm được gọi</param>
        string CreateStringLog(DateTime date);
    }
}
