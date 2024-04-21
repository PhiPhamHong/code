using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Core.Utility;
using Core.Extensions;
using Core.Utility.Xml;
namespace Core.Forms
{
    public partial class FrmCenter
    {
        public class Contana : ShBackgroundWorker
        {
            public FrmCenter FrmCenter { set; get; }

            protected override void DoWork()
            {
                processes.Where(p => p.Run()).ForEach(p => p.Do());
            }

            protected override bool OnPrepare(object sender)
            {
                ResetSetting();
                AddContana<ContanaCheckFolderError>();
                AddContana<ContanaMessage>();
                AddContana<ContanaCheckRam>();
                AddContana<ContanaAutoGC>();
                AddContana<ContanaSendEmailWhenError>();
                AddContana<ContanaSendSmsWhenError>();
                Thread.Sleep(Interval);
                return true;
            }

            private List<ContanaProcess> processes = new List<ContanaProcess>();

            public void AddContana<TContanaProcess>() where TContanaProcess : ContanaProcess, new()
            {
                processes.Add(new TContanaProcess { Contana = this });
            }

            private FrmConfigContana.Setting setting = null;
            public FrmConfigContana.Setting Setting
            {
                get { return setting; }
            }

            public Func<FrmConfigContana.Setting> CreateSetting;

            public void ResetSetting()
            {
                setting = CreateSetting != null ? CreateSetting() : ReadConfig<FrmConfigContana.Setting>.Load();
                Interval = new TimeSpan(0, 0, Setting.Interval);
            }

            public ShMailer CreateMailer()
            {
                var mailer = new ShMailer { EmailFrom = Setting.Email, PasswordEmailFrom = Setting.PasswordEmail, SendBy = Setting.SendBy };
                Setting.EmailTo.Split(',').Where(m => m.IsNotNull()).ForEach(m => mailer.Mail.To.Add(m));
                return mailer;
            }
        }

        public abstract class ContanaProcess
        {
            public Contana Contana { set; get; }
            public abstract void Do();
            public abstract bool Run();
        }
    }
}