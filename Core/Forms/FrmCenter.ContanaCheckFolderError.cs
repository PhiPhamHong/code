using System.Drawing;
using System.IO;
namespace Core.Forms
{
    public partial class FrmCenter
    {
        public class ContanaCheckFolderError : ContanaProcess
        {
            public override void Do()
            {
                if (Directory.Exists(Contana.Setting.FolderError))
                {
                    Contana.FrmCenter.Invoke(() => 
                    {
                        Contana.FrmCenter.slError.Text = "Đã xuất hiện Error";
                        Contana.FrmCenter.slError.IsLink = true;
                    });                    
                }
                else
                {
                    Contana.FrmCenter.Invoke(() => 
                    {
                        Contana.FrmCenter.slError.Text = "Chưa phát hiện thấy lỗi";
                        Contana.FrmCenter.slError.IsLink = false;
                    });                    
                }
            }

            public override bool Run()
            {
                return Contana.FrmCenter.smiContanaCheckFolderError.Checked;
            }
        }
    }
}