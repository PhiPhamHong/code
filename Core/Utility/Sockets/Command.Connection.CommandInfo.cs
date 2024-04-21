using System;
using System.Text;
using Core.Extensions;
using Core.Utility.MsgSerialize;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Cụ thể hóa Command sẽ thuộc Connection nào và sẽ xử lý bản tin nào được được gửi đến
    /// Tại Class này, command sẽ không quan tâm tới mảng byte nhận về nữa
    /// Thay vào đó nhờ TCommandInfo đã có phương thức Deserialize
    /// Vì vậy khi mảng byte được nhận về thì ngay lập tức được Parse ra thông tin đối tượng TCommandInfo.
    /// Việc xử lý bản tin nhận về sẽ làm việc hoàn toàn với đối tượng thông qua phương thức DoCommand
    /// </summary>
    /// <typeparam name="TConnection">Loại Connection</typeparam>
    /// <typeparam name="TCommandInfo">Loại bản tin mà Command sẽ nhận để xử lý</typeparam>    
    public abstract class Command<TConnection, TCommandInfo> : Command<TConnection>
        where TConnection : Connection
        where TCommandInfo : ICommandInfo, new()
    {
        /// <summary>
        /// Xử lý CommandInfo
        /// Đây là phương thức người lập trình cuối không cần quan tâm mảng byte nhận về
        /// Chỉ việc làm việc với đối tượng TCommandInfo
        /// </summary>
        /// <param name="cmd"></param>
        protected abstract void DoCommand(TCommandInfo cmd);

        /// <summary>
        /// Bản thân TCommandInfo đã có mã bản tin CommandType
        /// Vì vậy tại Class này CommandID sẽ dùng luôn CommandType để map giữa Command và CommandInfo
        /// Có nghĩa là map Command nào thì xử lý CommandInfo nào được gửi đến
        /// </summary>
        public override short CommandId
        {
            get { return Singleton<TCommandInfo>.Inst.CommandType; }
        }

        /// <summary>
        /// Xử lý dữ liệu nhận về
        /// </summary>
        sealed public override void Process(IProtocolContent pc)
        {            
            using (var cmd = new TCommandInfo())
            {
                try { pc.Deserialize(cmd); }
                catch (SerializeException se)
                {
                    Connection.OnErrorDeserialize(se.Type, se.Value);
                    return;
                }

                cmd.Date = pc.Date;
                cmd.MessageCode = pc.Code;

                DoCommand(cmd);
            }
        }

        /// <summary>
        /// Key để thực hiện log
        /// </summary>
        protected virtual string KeyLog
        {
            get { return null; }
        }
    }
}
