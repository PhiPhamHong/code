using Core.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;
using Core.Utility.IO;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Cụ thể lại Connection là Connection này sẽ chỉ chấp nhận những tập lệnh TCommand xử lý riêng cho Connection này.    
    /// Center cũng có nhiều loại ví dụ như Center dành cho các kết nối từ lái xe
    /// Center dành cho những kết nối từ khách hàng.
    /// Vì vậy Connection cũng phải xác định sẽ nó là nằm trên Center nào. Ví dụ Connection từ Driver đến thì nó chỉ được khai báo tại Center driver
    /// => Connection từ Driver sẽ không thể được khai báo sử dụng tại Center Customer hay tại một Center nào khác
    /// Hiểu nôm na là Connection có tập lệnh TCommand phục vụ cho chính nó và được khai báo trên TCenter
    /// </summary>
    /// <typeparam name="TCommand">Loại lệnh cần xử lý bản tin gửi về</typeparam>
    /// <typeparam name="TConnection">Loại connection mà TCommand phụ thuộc</typeparam>
    /// <typeparam name="TCenter">Center mà Connection được khai báo</typeparam>
    public abstract class Connection<TCommand, TConnection, TCenter> : Connection<TCenter>
        where TCommand : Command<TConnection>
        where TConnection : Connection
        where TCenter : ICenter
    {
        public Connection() : base()
        {
            CreateCommands();
        }

        /// <summary>
        /// Hiển thị thông báo lên màn hình của Center.
        /// Mỗi một Center đều có Console để hiển thị msg => các nơi muốn bắn thông báo lên console
        /// có thể gọi phương thức này. Tuy nhiên. Nếu tại các Center không bật lựa chọn hiển thị thông báo
        /// thì việc gọi phương thức này là vô nghĩa.
        /// => Hạn chế dùng và chỉ gọi khi nào cần thiết vì nhiều Thread cùng truy xuất lên console sẽ gây chậm và đơ chương trình
        /// </summary>
        /// <param name="msg"></param>
        public override void ShowMessage(string msg)
        {
            Center.ShowMessage(msg);
        }

        /// <summary>
        /// Danh sách các Command được Connection lưu trữ chờ đợi bản tin nhận về để xử lý
        /// Mỗi một Command đã được xác định bởi key (short) chính là mã bản tin
        /// Khi một bản tin được gửi về. Đúng mã bản tin nào thì Command sẽ được lấy từ dictionary ra và xử lý.
        /// </summary>
        private Dictionary<short, TCommand> commands = new Dictionary<short, TCommand>();

        /// <summary>
        /// Khởi tạo và đưa command vào danh sách commands
        /// Chú ý phương thức này nên được gọi trong CreateCommands của class kế thừa.
        /// Tuy nhiên đây là phương thức đã lỗi thời từ phiên bản staxi và sẽ không được sử dụng nữa.
        /// Vì đã được cải tiến cho việc tự nhận biết Connection từ luồng nào thì sẽ có những Command nào rồi.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        protected void AddCommand<TCommandCrete>() where TCommandCrete : TCommand, new()
        {
            var command = new TCommandCrete { };
            AddCommand(command);
        }

        /// <summary>
        /// Đưa một Command cụ thể vào dictionary commands
        /// Trước khi thêm command, gán commnad.Connection = this => lúc đó Command<TConnection> phát huy tác dụng
        /// Là biết được tôi là Command xử lý cho Connection này. 
        /// Việc tham chiếu này là vô cùng quan trọng. Để trong xử lý của Command có thể truy xuất ngược lên Connection
        /// Và từ đó mà có thể kiểm tra được trạng thái của Connection, đọc được các tham số của Center v.v...
        /// </summary>
        /// <typeparam name="TCommandCrete"></typeparam>
        /// <param name="command"></param>
        protected void AddCommand<TCommandCrete>(TCommandCrete command) where TCommandCrete : TCommand
        {
            command.Connection = this as TConnection;
            commands[command.CommandId] = command;
        }

        /// <summary>
        /// CreateCommands sẽ nhận biết luồng bản tin và tạo được tập commands tương ứng
        /// Phương thức này có thể overide lại. Tuy nhiên ko cần thiết.
        /// Chú ý một điều cực kỳ quan trọng. 
        /// 1. các Command cho dù có đánh Attribute CommandAttribute, nhưng là Astract sẽ không được gọi.
        /// 2. các Command là Generic không phải abstract thì CreateCommands sẽ bắn ra Exception
        /// </summary>
        protected virtual void CreateCommands()
        {
            var commandByFrom = CommandFrom.GetCommands().Select(t => t.CreateInstance<TCommand>());
            commandByFrom.ForEach(command => AddCommand(command));
        }

        /// <summary>
        /// Chỉ định Connection đến từ luồng nào. Ví dụ
        /// Connection đến từ Mobile lái xe tới server => 
        /// khi đó CreateCommands sẽ nhận biết luồng bản tin và tạo được tập commands tương ứng
        /// </summary>
        protected abstract CommandFrom CommandFrom { get; }

        /// <summary>
        /// Xử lý bản tin được gửi đến
        /// Các bước xử lý gồm: 
        /// 1. Xác định được mã bản tin để từ đó tìm được command xử lý phù hợp trong dictonary commands
        /// 2. Lấy được nội dung bản tin
        /// 3. Trước khi đưa bản tin vào command xử lý phải thực hiện giải mã
        /// </summary>
        /// <param name="packet"></param>
        sealed protected override void Process(byte[] packet)
        {
            var pc = Protocol.CreateProtocolContent(packet);
            if (pc == null) return;

            var command = commands.TryGet(pc.Id);
            if (command == null) return;

            pc.Crypter = Crypter;
            pc.SessionKey = command.UseSessionKey ? State.SessionKey : string.Empty;

            try { command.Process(pc); }
            catch (Exception ex)
            {
                FileHelper.WriteLog("Process",
                      "Crypter: " + Crypter.GetType().FullName + Environment.NewLine
                    + " - DateCreated: " + DateCreated + Environment.NewLine
                    + " - SessionKey: " + (State.SessionKey.IsNull() ? string.Empty : Encoding.UTF8.GetBytes(State.SessionKey).JoinString(b => b)) + Environment.NewLine
                    + " - ConnectionState: " + State + Environment.NewLine
                    + " - Command: " + pc.Id + Environment.NewLine
                    + " - MessageCode: " + pc.Code.JoinString(b => b) + Environment.NewLine
                    + " - Exception: " + ex.Message + Environment.NewLine
                    + " - StackTrace: " + ex.StackTrace + Environment.NewLine
                    + " - SessionKey IsNull: " + State.SessionKey.IsNull() + Environment.NewLine
                    + " - Exception Type: " + ex.GetType() + Environment.NewLine);
            }
        }

        public override void Dispose()
        {
            try { commands.ForEach(c => c.Value.Dispose()); }
            catch (Exception ex) { FileHelper.WriteLog("Connection.Command.Center.Dispose", ex); }
            base.Dispose();
        }
    }
}