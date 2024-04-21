using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    /// <summary>
    /// Đối tượng có thể ghi ra Message
    /// </summary>
    public abstract class Messagable
    {
        /// <summary>
        /// Sự kiện Message
        /// </summary>
        public event Action<string> Message;

        /// <summary>
        /// Thực hiện hiển thị Message
        /// </summary>
        /// <param name="msg"></param>
        public virtual void ShowMessage(string msg)
        {
            if (Message != null)
                Message(msg);
        }
    }
}
