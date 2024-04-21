using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace Core.Forms
{
    [DefaultEvent("ShClick")]
    public class ShButtonConfirm : Button
    {
        public event EventHandler ShClick;
        private string messageConfirm = "Bạn chắc chắn muốn thực hiện?";
        public string MessageConfirm
        {
            get { return messageConfirm; }
            set { messageConfirm = value; }
        }

        sealed protected override void OnClick(EventArgs e)
        {
            if (this.Confirm(MessageConfirm) && ShClick != null)
                ShClick(this, e);
        }
    }
}
