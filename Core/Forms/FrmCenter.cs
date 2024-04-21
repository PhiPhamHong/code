using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Core.Attributes;
using Core.Reflectors;
using Core.Utility;
using Core.Extensions;
using Core.Utility.IO;
namespace Core.Forms
{
    public partial class FrmCenter : Form
    {
        private ICenter center = null;
        public bool CenterIsNull
        {
            get { return center == null; }
        }
        private int totalLine = 0;
        protected ICenter Center
        {
            get 
            {
                if (center == null)
                {
                    center = CreateCenter();
                    Action<string> actionMsg = (msg) =>
                    {
                        if (!chkShowMessage.Checked) return;
                        totalLine++;
                        if (totalLine >= 100) smiClearConsole_Click(smiClearConsole, EventArgs.Empty);
                        ConsoleWrite(msg);                        
                    };

                    (center as Messagable).Message += msg => { if (!this.IsDisposed) this.Invoke(actionMsg, msg); };
                }
                return center; 
            }
        }
        protected void ConsoleWrite(string msg)
        {
            console.WriteText(msg);
            console.NewLine();
        }
        protected virtual ICenter CreateCenter() 
        { 
            return null; 
        }
        protected bool On<TCenter>(Action<TCenter> action, bool hasAlert = false) where TCenter : class, ICenter
        {
            try
            {
                if (center != null)
                {
                    action(center as TCenter);
                    return true;
                }

                if (hasAlert) this.Alert("Server chưa được bật");
                return false;
            }
            catch
            {
                this.Alert("Có lỗi");
                return false;
            }
        }
        private Contana contana = new Contana();
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                contana.FrmCenter = this;
                console.Clear();
                try
                {
                    if (center != null)
                    {
                        center.Stop();
                        center = null;
                    }
                }
                catch { }
                Center.Start();
                btnStart.Enabled = false; btnStop.Enabled = true;
                AfterStart();
                slTimeStart.Text = "Start: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                CopyFormInfoToNotify();
            }
            catch(Exception ex)
            {
                ConsoleWrite(ex.Message);
                if (ex.InnerException != null)
                {
                    ConsoleWrite(ex.InnerException.Message);
                    ConsoleWrite(ex.InnerException.StackTrace);
                }                
            }
        }
        protected virtual void AfterStart() { }
        private void btnStop_Click(object sender, EventArgs e)
        {            
            if (center != null)
            {
                center.Stop();
                center = null;
            }
            btnStart.Enabled = true; btnStop.Enabled = false;
            AfterStop();
        }
        protected virtual void AfterStop() { }
        private void FrmCenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CannotCloseForm)
            {
                MessageBox.Show("Bạn không thể tắt được ứng dụng này. Xin cảm ơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            var dr = MessageBox.Show("Bạn chắc chắn muốn tắt?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if ( dr != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            try { btnStop_Click(sender, e); } finally { }
        }
        public void Invoke(Action action)
        {
            this.Invoke(action, new object[] { });
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            contanaMessages = CreateContanaMessages();
            OnCreateContana(contana);

            if (StartOnLoad)
                DoStart();

            try
            {
                if (txtColor.Text.IsNotNull())
                    console.ShellTextForeColor = Color.FromArgb(Convert.ToInt32(txtColor.Text));
            }
            catch { txtColor.Text = console.ShellTextForeColor.ToArgb().ToString(); }
            sstbtnColor.Color = console.ShellTextForeColor;

            panelLock.BringToFront();
            panelLogin.BringToFront();
        }
        protected virtual void OnCreateContana(Contana contana) { }
        protected virtual void DoStart()
        {
            btnStart_Click(btnStart, EventArgs.Empty);
        }
        public bool StartOnLoad { set; get; }
        public bool CannotCloseForm { set; get; }
        protected void OnColorSelected(Color color) { txtColor.Text = color.ToArgb().ToString(); }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        private void FrmCenter_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.ShowBalloonTip(1000);
                notifyIcon1.Visible = true;
            }
        }
        private void FrmCenter_Shown(object sender, EventArgs e)
        {
            CopyFormInfoToNotify();
        }
        private void CopyFormInfoToNotify()
        {
            notifyIcon1.Icon = Icon;
            notifyIcon1.Text = Text;
            notifyIcon1.BalloonTipTitle = Text;
            notifyIcon1.BalloonTipText = Text + ", tôi đang ở đây";
        }
        private List<string> contanaMessages = null;
        protected virtual List<string> CreateContanaMessages() 
        { 
            return new List<string> 
            { 
                "Contana đang suy nghĩ...",                
                "Nếu có thắc mắc gì xin vui lòng liên hệ với quản trị",
                "Xin vui lòng không được động chạm vô chương trình khi không được phép của quản trị",
                "Các tab cấu hình rất quan trọng. Vui lòng không cập nhật ngoài quản trị",
                "Nếu vô tình bạn đi qua đây và thấy lỗi thì hãy vui lòng báo với quản trị",
                "Nếu có tắt server hãy liên hệ với quản trị",
                "Bạn có thể dùng chức năng chọn màu để console nhìn dịu mắt hơn theo ý của bạn",                
                "Tất cả cấu hình không bị Disable đều có thể cập nhật được trong lúc chương trình đang chạy",
                "Button GC được dùng để clear lại bộ nhớ",
                "Button Stop dùng để dừng chương trình Server đang chạy, tuy nhiên bạn không nên tùy tiện sử dụng khi chưa được phép của quản trị",
                "Nếu có lỗi Log sẽ được ghi vào thư mục Error"
            }; 
        }
        private void startContanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smiStopContana.Checked = false;
            contana.Start();
        }
        private void stopContanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smiStartContana.Checked = false;
            contana.Stop();
        }
        private void sstbtnColor_ColorSelected(object sender, ColorSelectedArg e)
        {
            OnColorSelected(console.ShellTextForeColor = e.Color);
        }
        private void slError_Click(object sender, EventArgs e)
        {
            if (!slError.IsLink) return;
            try { Process.Start(@"Error"); }
            catch (Exception ex) { this.Alert(ex.Message); }
        }
        private void smiGC_Click(object sender, EventArgs e)
        {
            try { GC.Collect(); } catch { }
        }
        private void smiClearConsole_Click(object sender, EventArgs e)
        {
            console.Clear();
            totalLine = 0;
        }
        private void smiLock_Click(object sender, EventArgs e)
        {
            panelLock.Visible = panelLogin.Visible = true;
            txtPass.Text = string.Empty;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "iadmin123!@#")
                panelLogin.Visible = panelLock.Visible = false;
            else
                this.Alert("Mật khẩu không đúng!!!!");
        }
        private void smiConfigContana_Click(object sender, EventArgs e)
        {            
            if (GetFrmConfigContana().ShowDialog() == DialogResult.OK) contana.ResetSetting();
        }
        protected virtual FrmConfigContana GetFrmConfigContana()
        {
            return new FrmConfigContana();
        }
    }

    public interface ICenter
    {
        void ShowMessage(string msg);
        void Start();
        void Stop();
        bool IsDebug { set; get; }
        bool IsNeedShowMessage { set; get; }
        bool NeedWriteLogError { set; get; }
    }

    public interface IOneSecondControl { }
    public interface IWorkerOneSecond 
    {
        List<IOneSecondControl> GetControls();
        void ResetWorkersCanRun();
        bool ResetWorkers { set; get; }
    }

    public abstract class CenterThread<TCenter> : ShBackgroundWorker where TCenter : ICenter
    {
        public TCenter Center { set; get; }

        public abstract class WorkerOneSecond : CenterThread<TCenter>, IWorkerOneSecond
        {
            public abstract class Control : IOneSecondControl
            {
                public WorkerOneSecond Worker { set; get; }

                private int seconds = 0;
                public void DoWork()
                {
                    seconds++;
                    if (seconds >= Time)
                    {
                        try { Work(); }
                        finally { seconds = 0; }
                    }
                }

                protected abstract void Work();
                protected abstract int Time { get; }
                public virtual void ChangeDate(DateTime oldDate) { }

                public virtual void Prepare() { }
                public virtual bool Condition { get { return true; } }
                
                public virtual void RunInFirst()
                {
                    //if (Condition) Work();
                }
            }
            public abstract class Control<TWorkerOneSecond> : Control where TWorkerOneSecond : WorkerOneSecond
            {
                new public TWorkerOneSecond Worker
                {
                    set { base.Worker = value; }
                    get { return base.Worker as TWorkerOneSecond; }
                }
            }

            private List<Control> controls = new List<Control>();       // Tổng tất cả các control có thể chạy
            private List<Control> controlsNotRun = new List<Control>(); // Tất cả các control chưa đủ điều kiện chạy
            private List<Control> controlsRun = new List<Control>();    // Tất cả các control được phép chạy
            public void Add<TControl>(Action<TControl> action = null) where TControl : Control, new()
            {
                var control = new TControl { Worker = this };
                if (action != null) action(control);
                controls.Add(control);
            }

            public DateTime CurrentDate = DateTime.Today;
            public bool RunFromWeb { set; get; }
            private int secondToReset = 0;
            public bool ResetWorkers { set; get; }

            protected override void DoWork()
            {
                if(CurrentDate != DateTime.Today)
                {
                    controlsRun.ForEach(c => 
                    {
                        try { c.ChangeDate(CurrentDate); }
                        catch (Exception ex) { WriteLogByControl(c, ex); }
                    });
                    CurrentDate = DateTime.Today;
                    return;
                }

                controlsRun.ForEach(c =>
                {
                    try { c.DoWork(); }
                    catch (Exception ex) { WriteLogByControl(c, ex); }
                });

                // Reset lại những worker control đủ điều kiện chạy
                secondToReset++;
                if(secondToReset == 60 || ResetWorkers)
                {
                    secondToReset = 0;
                    ResetWorkers = false;
                    ResetWorkersCanRun();
                }
            }
            public void ResetWorkersCanRun()
            {
                controlsNotRun.Clear();
                controlsRun.Clear();
                controls.ForEach(c => 
                {
                    if (c.Condition) controlsRun.Add(c);
                    else controlsNotRun.Add(c);
                });
            }

            protected override void BeforeRun()
            {
                Interval = new TimeSpan(0, 0, 1);
            }
            sealed protected override bool OnPrepare(object sender)
            {
                ResetWorkersCanRun();
                DoPrepare();
                controlsRun.ForEach(c => c.Prepare());
                controlsRun.ForEach(c => 
                {
                    try { c.RunInFirst(); }
                    catch (Exception ex) { WriteLogByControl(c, ex); }
                });
                return true;
            }

            private void WriteLogByControl(Control c, Exception ex)
            {
                if (ex.Message == "Thread was being aborted") return;
                if (Center.NeedWriteLogError)
                    FileHelper.WriteLog(c.GetType().FullName, ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + "----------------------------" + Environment.NewLine, "Worker/" + c.GetType().FullName, string.Empty, RunFromWeb);
            }

            protected virtual void DoPrepare() { }
            public List<IOneSecondControl> GetControls()
            {
                return controls.OfType<IOneSecondControl>().ToList();
            }
        }
    }

    public abstract class Center<TThread, TCenter> : Messagable, ICenter, ICenterMessage
        where TThread : CenterThread<TCenter>
        where TCenter : class, ICenter
    {
        private List<ShBackgroundWorker> workers = new List<ShBackgroundWorker>();
        public List<ShBackgroundWorker> Workers
        {
            get { return workers; }
        }

        protected void AddWorker<TWorker>(Action<TWorker> aWroker = null) where TWorker : CenterThread<TCenter>, new()
        {
            var worker = new TWorker { Center = this as TCenter };
            if (aWroker != null) aWroker(worker);
            AddWorker(worker);
        }

        protected void AddWorker<TWorkerConcrete>(TWorkerConcrete worker) where TWorkerConcrete : CenterThread<TCenter>
        {
            worker.Center = this as TCenter;
            worker.Message += msg => ShowMessage(msg);
            workers.Add(worker);
        }

        public void Start() { StartHelper(); OnStart(); }
        protected virtual void OnStart() { StartWorkers(); }

        public void Stop() { OnStop(); StopHelper(); }
        protected virtual void OnStop() { StopWorkers(); }

        protected void StartWorkers() { workers.ForEach(worker => worker.Start()); }
        protected void StopWorkers() { workers.ForEach(worker => worker.Stop()); }
        protected void StartHelper() { RunMethod<CenterStartAttribute>(); }
        protected void StopHelper() { RunMethod<CenterStopAttribute>(); }

        private void RunMethod<TActionAttribute>() where TActionAttribute : MethodInfoAttribute, ICenterMethodAttribute
        {
            ReflectTypeListMethodInfo<TActionAttribute>.Inst[this.GetType()].OrderBy(t => t.Stt).ToList().ForEach(method => method.MethodInfo.Invoke(this, new object[] { }));
        }

        public static TCenter Instance = null;

        [CenterStart] protected void SetInstance() { Instance = this as TCenter; }
        [CenterStop] protected void RemoveInstance() { Instance = null; }
        public bool IsDebug { set; get; }
        public bool IsNeedShowMessage { set; get; }
        public bool NeedWriteLogError { set; get; }
    }

    public class CenterStartAttribute : MethodInfoAttribute, ICenterMethodAttribute
    {
        public int Stt { set; get; }
    }
    public class CenterStopAttribute : MethodInfoAttribute, ICenterMethodAttribute
    {
        public int Stt { set; get; }
    }

    public interface ICenterMethodAttribute
    {
        int Stt { set; get; }
    }
    public interface ICenterMessage
    {
        bool IsNeedShowMessage { set; get; }
    }
}