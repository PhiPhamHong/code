using Core.Forms;
using System;
using System.ComponentModel;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Center cũng có nhiều loại ví dụ như Center dành cho các kết nối từ lái xe
    /// Center dành cho những kết nối từ khách hàng.
    /// Vì vậy Connection cũng phải xác định sẽ nó là nằm trên Center nào. 
    /// Ví dụ Connection từ Driver đến thì nó chỉ được khai báo tại Center driver
    /// => Connection từ Driver sẽ không thể được khai báo sử dụng tại Center Customer hay tại một Center nào khác
    /// </summary>
    /// <typeparam name="TCenter"></typeparam>
    public abstract class Connection<TCenter> : Connection where TCenter : ICenter
    {
        /// <summary>
        /// Center: nơi mà Connection được khai báo.
        /// Việc tham chiếu đến Center giúp Connection đọc được đầy đủ tham số, cấu hình trên giao diện
        /// </summary>
        [Browsable(false)]
        public TCenter Center { set; get; }

        sealed public override bool NeedShowMessage
        {
            get { return Center.IsNeedShowMessage; }
        }
    }
}