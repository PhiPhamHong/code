using Core.Utility.Sockets.Crypts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.Sockets
{
    public partial class Connection
    {
        /// <summary>
        /// Khởi tạo ConnectionState
        /// Đây là phương thức virtual. Với mục đích từng loại Connection khác nhau thì ConnectionState có thể 
        /// lưu trữ các trạng thái khác nhau. 
        /// </summary>
        /// <returns></returns>
        protected virtual ConnectionState CreateConnectionState()
        {
            return new ConnectionState();
        }

        /// <summary>
        /// Tạo Cryter phục vụ việc mã hóa, giải mã bản tin khi send hoặc receive
        /// Đây là phương thức virtual. Với mục đích từng loại Connection khác nhau thì có Crypter riêng
        /// Mặc định các Connection dùng NoneCrypt => nghĩa là không có Crypter
        /// </summary>
        /// <returns></returns>
        protected virtual ICrypter CreateCrypter()
        {
            return Singleton<NoneCrypt>.Inst;
        }

        protected abstract Protocol CreateProtocol();

        protected Type Type = null;

        public Connection()
        {
            Crypter = CreateCrypter();
            State = CreateConnectionState();
            Protocol = CreateProtocol();
            Type = GetType();            
        }

        public virtual bool NeedShowMessage { get { return true; } }
        public virtual bool NeedLog { get { return false; } }
    }
}
