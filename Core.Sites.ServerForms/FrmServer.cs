using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Core.Forms;
using Core.Sites.ServerForms.Utilities;
using Core.Utility;
using Core.Utility.Xml;
using Core.Extensions;
namespace Core.Sites.ServerForms
{
    public partial class FrmServer : FrmCenter
    {
        private void FrmServer_Load(object sender, EventArgs e)
        {
            panelLock.Location = new Point(0, 3);
            this.FillValues(ReadConfig<FormServer.Setting>.Load(), false);
            WriteNote();
        }

        protected override ICenter CreateCenter()
        {
            var center = new FormServer();
            this.ParseTo(center.Config);
            return center;
        }
        protected override void AfterStart()
        {
            On<FormServer>(center =>
            {
                Text = Text + " - " + txtServerName.Text;
                ConsoleWrite("Khởi động Server thành công");
                //try { Icon = new System.Drawing.Icon(center.ServerLogo, 16, 16); }
                //catch { ConsoleWrite("Không xác định được biểu tượng của Server"); }
            });
            FormState(true);
        }
        protected override void AfterStop()
        {
            FormState(false);
            var timeout = new Timeout();
            timeout.Finish += th => this.Invoke(() => { console.Clear(); WriteNote(); });
            timeout.Start();
        }
        #region FormState
        private void FormState(bool start)
        {
            txtSignalRSelfHostIP.Enabled = 
            txtSignalRSelfHostPort.Enabled = 
            txtWCFAddress.Enabled = 
                txtWCFPortHttp.Enabled = 
                txtWCFPortTcp.Enabled = 
                txtServerName.Enabled = !start;
        }
        #endregion
        private void WriteNote()
        {
            this.ConsoleWrite("CHÀO MỪNG TỚI SERVER - TÁC GIẢ Bill Phạm");
        }
        private void miSaveConfig_Click(object sender, System.EventArgs e)
        {
            ReadConfig<FormServer.Setting>.Save(this.ParseTo<FormServer.Setting>());
            this.AlertInformation("Cập nhật setting thành công");
        }
        private void miOpenFolder(object sender, EventArgs e)
        {
            try
            {
                var folder = Convert.ToString((sender as ToolStripMenuItem).Tag);
                if (folder.IsNull()) folder = Directory.GetCurrentDirectory();
                Process.Start(folder);
            }
            catch (Exception ex) { this.Alert(ex.Message); }
        }

        private void btnResetConfig_Click(object sender, EventArgs e)
        {
            On<FormServer>(center =>
            {
                this.ParseTo(center.Config);
                center.ResetConfig();
            });
        }
    }
}