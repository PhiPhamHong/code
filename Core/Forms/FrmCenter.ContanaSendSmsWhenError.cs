using System;
using System.IO;
using Core.Extensions;
namespace Core.Forms
{
    public partial class FrmCenter
    {
        public class ContanaSendSmsWhenError : ContanaProcess
        {
            private bool hasSend = false;

            public override void Do()
            {
                if (Directory.Exists(Contana.Setting.FolderError))
                {
                    if (!hasSend)
                    {
                        var content = Contana.Setting.SendBy +  ": xuat hien loi luc " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        Contana.Setting.PhoneReceiveSms.Split(',').ForEach(p => Contana.FrmCenter.SendSms(p, content));
                        hasSend = true;
                    }
                }
                else hasSend = false;
            }

            public override bool Run()
            {
                return Contana.FrmCenter.smiContanaSendSmsWhenError.Checked;
            }
        }

        protected virtual void SendSms(string phone, string content) { }
    }
}
