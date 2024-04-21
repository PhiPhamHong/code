using Core.Attributes;
using Core.Extensions;
using System;
namespace Core.Utility.Sockets
{
    /// <summary>
    /// CommandInfo là bản tin cần truyền đi giữa các khối 
    /// Trong đó nội tại CommandInfo có thể tự Serialize và Deserialize theo một cách thức tổng quát theo tài liệu protocol
    /// Người lập trình chỉ việc kế thừa và khai báo lệnh cần truyền đi là CommandType là bao nhiêu
    /// Các thông tin lệnh là các property cần được đánh dấu PropertyIndex theo đúng thứ tự tài liệu protocol các bản tin
    /// </summary>
    [Serializable]
    public abstract class CommandInfo : ICommandInfo
    {
        ///// <summary>
        ///// Deserialize convert từ mảng byte nhận được từ một khối nào đó và
        ///// điền dữ liệu lên các properties trong đối tượng kế thừa đến CommandInfo.
        ///// Từ mảng byte sẽ lần lượt được đọc và thiết lập cho các property được đánh dấu bởi PropertyIndex
        ///// Cơ chế parse bản tin đọc tài liệu protocol
        ///// Deserialize có thể được overide lại ở lớp kế thừa. Tùy theo các lệnh được có mảng byte quá phức tạp mà PropertyIndex không đảm nhiệm được hết
        ///// </summary>
        //public virtual void Deserialize(IProtocolContent pc)
        //{
        //    pc.Deserialize(this);
        //}

        ///// <summary>
        ///// Serialize là convert thông tin lệnh thành mảng byte. Sau đó sẽ được truyền đi tới một khối nào đó
        ///// Serialize thực hiện đọc các properties được đánh dấu bởi PropertyIndex, convert giá trị của thuộc tính
        ///// ra mảng byte, rồi gộp các mảng byte lại theo đúng thứ tự được đánh theo PropertyIndex để ra được mảng byte truyền đi
        ///// Serialize có thể được overide lại ở lớp kế thừa. Tùy theo cấu trúc lệnh phức tạp. Không thể Serialize theo cách thông thường
        ///// </summary>
        //public virtual byte[] Serialize()
        //{
        //    return ObjectExtension.Serialize(this);
        //}

        /// <summary>
        /// Mã của một CommandInfo. Mỗi một bản tin đi đều phải có một Mã lệnh duy nhất để biết được mã lệnh đó truyền đi để làm gì và sẽ gồm những thông tin gì
        /// Các mã lệnh được quy định theo như tài liệu cấu trúc protocol
        /// Cấu trúc mã lệnh có dạng như sau: xyzz. Trong đó x là khối truyền bản tin đi, y là khối nhận bản tin và zz là mã bản tin
        /// Ví dụ 6200. Trong đó 6: Khối truyền đi (mobile), 2: Khối nhận (Server), 00: Mã bản tin (DriverLogin)
        /// </summary>
        public abstract short CommandType { get; }

        /// <summary>
        /// Tên của lệnh.
        /// CommandName dùng để ghi ra log cho người kiểm tra khi tra cứu log. 
        /// Thay vì xem CommandType là một số thì phải vào tài liệu tra cứu xem là lệnh gì thì đọc CommandName sẽ dễ hơn nhiều.
        /// Ví dụ: 6200 thì CommandName = "DriverLogin". Có nghĩa là. bản tin mã 6200 là bản tin truyền từ lái xe về server để thực hiện đăng nhập
        public abstract string CommandName { get; }

        /// <summary>
        /// Ngày giờ bản tin được tạo ở khối truyền đi. 
        /// Lưu ý ngày giờ này ở các khối có thể là sẽ không đồng bộ nhau
        /// </summary>
        public DateTime Date { set; get; }

        /// <summary>
        /// Đây là mảng byte được dùng để mã hóa và giải mã bản tin
        /// Mỗi bản tin gửi đi đều sẽ được mã hóa trước khi gửi đi, và MessageCode là mảng byte dùng để mã hóa
        /// Khi khối nhận được MessageCode thì dùng để thực hiện giải mã lại
        /// </summary>
        public byte[] MessageCode { set; get; }

        /// <summary>
        /// Tạo ra log từ thông tin lệnh. Log bao gồm cả thông tin loại lệnh và thông tin các trường trong lệnh
        /// Tham số date: được dùng tùy theo date là thời gian lệnh được tạo từ khối gửi đi hoặc nhận.
        /// Tùy theo nơi gọi hàm này
        /// </summary>
        public string CreateStringLog(DateTime date)
        {
            return FormatString.Frmat(CreatePrefixCommand(date), CreateString());
        }

        /// <summary>
        /// Hàm hỗ trợ cho việc tạo string để ghi ra log từ thông tin lệnh
        /// Hay nói cách khác là tạo Header của string log.
        /// Tạo ra chuỗi để cho biết là lệnh tên là gì vã mã lệnh là bao nhiêu.
        /// Ví dụ tạo ra string log: "DriverLogin@6200#05/10/2015 15:30:23" Có nghĩa là. đây là lệnh DriverLogin, mã lệnh 6200 vào thời điểm 05/10/2015 15:30:23
        /// </summary>
        /// <param name="date">Thời gian mong muốn ghi ra log. Tùy theo yêu cầu date có thể là thời gian từ khối gửi đi hoặc từ khối nhận về</param>        
        protected string CreatePrefixCommand(DateTime date)
        {
            return FormatCreatePrefixCommand.Frmat(CommandName, CommandType, date.ToString(FormatTime));
        }

        /// <summary>
        /// Hàm hỗ trợ cho việc tạo string để ghi ra log từ thông tin lệnh
        /// Đọc tất cả các properties của CommandInfo được đánh dấu bởi PropertyIndex
        /// Theo thứ ghi nối các giá trị của các property lại với nhau bằng dấu #
        /// </summary>
        protected string CreateString()
        {
            return this.SerializeFormatString();
        }

        /// <summary>
        /// Tạo ra string header của log.
        /// Với thời gian là ngày giờ lệnh được tạo theo khối gửi đi
        /// Ví dụ: DriverLogin@6200#05/10/2015 15:30:23 Có nghĩa là. đây là lệnh DriverLogin, mã lệnh 6200 vào thời điểm 05/10/2015 15:30:23 của phía mobile
        /// </summary>
        protected string PrefixCommand
        {
            get { return CreatePrefixCommand(Date); }
        }

        /// <summary>
        /// Lấy được log hoàn chỉnh của một lệnh để ghi ra file hoặc màn hình
        /// Log gồm: loại lệnh, ngày giờ ở khối gửi đi và các thông tin lệnh được ngăn cách bởi dấu #
        /// </summary>
        public override string ToString()
        {
            return FormatString.Frmat(PrefixCommand, CreateString());
        }

        ///// <summary>
        ///// Hàm hỗ trợ tạo log. Ghi các thuộc tính của CommandInfo được đánh dấu bởi PropertyIndex
        ///// Các giá trị được ngăn cách nhau bởi dấu #
        ///// Tuy nhiên sẽ loại bỏ một số trường không muốn hiển thị trong mảng notFields
        ///// </summary>
        ///// <param name="notFields">Mảng tên các property không mong muốn ghi log</param>        
        //protected string GetInfo(params string[] notFields)
        //{
        //    return TypePropertyIndex.Inst[GetType()].Where(p => !notFields.Contains(p.T1.Name)).JoinString(p => p.T1.GetValue(this), Sharp);
        //}

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public const string Sharp = "_";
        public const string FormatCreatePrefixCommand = "{0}@{1}_{2}_";
        public const string FormatTime = "dd/MM/yyyy HH:mm:ss.fff";
        public const string FormatString = "{0}{1}";

        public void CopyTo<TCommandInfo>(TCommandInfo commandInfo) where TCommandInfo : ICommandInfo
        {
            var pd = TypePropertyIndex.Inst[commandInfo.GetType()];
            var ps = TypePropertyIndex.Inst[GetType()];
            pd.SJoin(ps, pdi => pdi.T1.Name, psi => psi.T1.Name, (pdi, psi) => pdi.T1.SetValue(commandInfo, psi.T1.GetValue(this), null));
        }
    }
}
