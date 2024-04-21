using System;
using System.IO;
namespace Core.Forms
{
    public partial class FrmCenter
    {
        public class ContanaSendEmailWhenError : ContanaProcess
        {
            private bool hasSend = false;

            public override void Do()
            {
                if (Directory.Exists(Contana.Setting.FolderError))
                {
                    if (!hasSend)
                    {
                        var mailer = Contana.CreateMailer();
                        mailer.Mail.Body = "Xuất hiện lỗi lúc " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        mailer.Mail.Subject = "Server xuất hiện lỗi";
                        hasSend = mailer.Send(string.Empty);
                        hasSend = true;
                    }
                }
                else hasSend = false;
            }

            public override bool Run()
            {
                return Contana.FrmCenter.smiContanaSendEmailWhenError.Checked;
            }
        }
    }
}