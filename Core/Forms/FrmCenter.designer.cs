using System;
using System.Windows.Forms;
using Core.Extensions;
namespace Core.Forms
{
    partial class FrmCenter
    {
        public FrmCenter()
        {
            InitializeComponent();
        }

        protected DialogResult OpenFormDialog(string type)
        {
            var form = type.CreateInstance<Form>();
            return form.ShowDialog();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCenter));
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.console = new UILibrary.ShellControl();
            this.chkShowMessage = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtColor = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssbtnContana = new System.Windows.Forms.ToolStripSplitButton();
            this.smiStopContana = new System.Windows.Forms.ToolStripMenuItem();
            this.smiStartContana = new System.Windows.Forms.ToolStripMenuItem();
            this.smiConfigContana = new System.Windows.Forms.ToolStripMenuItem();
            this.smiContanaMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.smiContanaCheckRam = new System.Windows.Forms.ToolStripMenuItem();
            this.smiContanaCheckFolderError = new System.Windows.Forms.ToolStripMenuItem();
            this.smiAutoGc = new System.Windows.Forms.ToolStripMenuItem();
            this.smiContanaSendEmailWhenError = new System.Windows.Forms.ToolStripMenuItem();
            this.smiContanaSendSmsWhenError = new System.Windows.Forms.ToolStripMenuItem();
            this.slTimeStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slError = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sstbtnColor = new ExHtmlEditor.ColorPicker.ThemeColorPickerToolStripSplitButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.smiClearConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.smiGC = new System.Windows.Forms.ToolStripMenuItem();
            this.smiLock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slMem = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.panelLock = new Core.Forms.TransparentPanel();
            this.statusStrip.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(595, 393);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 29);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(514, 393);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 29);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(12, 189);
            this.console.Name = "console";
            this.console.Prompt = "S: ";
            this.console.ShellTextBackColor = System.Drawing.Color.Black;
            this.console.ShellTextFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.ShellTextForeColor = System.Drawing.Color.LawnGreen;
            this.console.Size = new System.Drawing.Size(658, 197);
            this.console.TabIndex = 7;
            // 
            // chkShowMessage
            // 
            this.chkShowMessage.AutoSize = true;
            this.chkShowMessage.Checked = true;
            this.chkShowMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowMessage.Location = new System.Drawing.Point(14, 397);
            this.chkShowMessage.Name = "chkShowMessage";
            this.chkShowMessage.Size = new System.Drawing.Size(112, 18);
            this.chkShowMessage.TabIndex = 8;
            this.chkShowMessage.Text = "Hiển thị thông báo";
            this.chkShowMessage.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // txtColor
            // 
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.Enabled = false;
            this.txtColor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.Location = new System.Drawing.Point(543, 244);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(94, 23);
            this.txtColor.TabIndex = 30;
            this.txtColor.Tag = "ConsoleColor";
            this.txtColor.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbtnContana,
            this.slTimeStart,
            this.toolStripStatusLabel1,
            this.slError,
            this.toolStripStatusLabel2,
            this.sstbtnColor,
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel3,
            this.slMem});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(682, 27);
            this.statusStrip.TabIndex = 31;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tssbtnContana
            // 
            this.tssbtnContana.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbtnContana.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiStopContana,
            this.smiStartContana,
            this.smiConfigContana,
            this.smiContanaMessage,
            this.smiContanaCheckRam,
            this.smiContanaCheckFolderError,
            this.smiAutoGc,
            this.smiContanaSendEmailWhenError,
            this.smiContanaSendSmsWhenError});
            this.tssbtnContana.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnContana.Image")));
            this.tssbtnContana.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnContana.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tssbtnContana.Name = "tssbtnContana";
            this.tssbtnContana.Padding = new System.Windows.Forms.Padding(3);
            this.tssbtnContana.Size = new System.Drawing.Size(38, 21);
            this.tssbtnContana.Text = "toolStripSplitButton1";
            // 
            // smiStopContana
            // 
            this.smiStopContana.Checked = true;
            this.smiStopContana.CheckOnClick = true;
            this.smiStopContana.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smiStopContana.Name = "smiStopContana";
            this.smiStopContana.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.smiStopContana.Size = new System.Drawing.Size(230, 22);
            this.smiStopContana.Text = "Stop Contana";
            this.smiStopContana.Click += new System.EventHandler(this.stopContanaToolStripMenuItem_Click);
            // 
            // smiStartContana
            // 
            this.smiStartContana.CheckOnClick = true;
            this.smiStartContana.Name = "smiStartContana";
            this.smiStartContana.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.smiStartContana.Size = new System.Drawing.Size(230, 22);
            this.smiStartContana.Text = "Start Contana";
            this.smiStartContana.Click += new System.EventHandler(this.startContanaToolStripMenuItem_Click);
            // 
            // smiConfigContana
            // 
            this.smiConfigContana.Name = "smiConfigContana";
            this.smiConfigContana.Size = new System.Drawing.Size(230, 22);
            this.smiConfigContana.Tag = "";
            this.smiConfigContana.Text = "Thiết lập cấu hình Contana";
            this.smiConfigContana.Click += new System.EventHandler(this.smiConfigContana_Click);
            // 
            // smiContanaMessage
            // 
            this.smiContanaMessage.Checked = true;
            this.smiContanaMessage.CheckOnClick = true;
            this.smiContanaMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smiContanaMessage.Name = "smiContanaMessage";
            this.smiContanaMessage.Size = new System.Drawing.Size(230, 22);
            this.smiContanaMessage.Text = "Hiển thị lời nhắn";
            // 
            // smiContanaCheckRam
            // 
            this.smiContanaCheckRam.Checked = true;
            this.smiContanaCheckRam.CheckOnClick = true;
            this.smiContanaCheckRam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smiContanaCheckRam.Name = "smiContanaCheckRam";
            this.smiContanaCheckRam.Size = new System.Drawing.Size(230, 22);
            this.smiContanaCheckRam.Text = "Kiểm tra bộ nhớ";
            // 
            // smiContanaCheckFolderError
            // 
            this.smiContanaCheckFolderError.Checked = true;
            this.smiContanaCheckFolderError.CheckOnClick = true;
            this.smiContanaCheckFolderError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smiContanaCheckFolderError.Name = "smiContanaCheckFolderError";
            this.smiContanaCheckFolderError.Size = new System.Drawing.Size(230, 22);
            this.smiContanaCheckFolderError.Text = "Kiểm tra thư mục Error";
            // 
            // smiAutoGc
            // 
            this.smiAutoGc.CheckOnClick = true;
            this.smiAutoGc.Name = "smiAutoGc";
            this.smiAutoGc.Size = new System.Drawing.Size(230, 22);
            this.smiAutoGc.Text = "Thực hiện GC tự động";
            // 
            // smiContanaSendEmailWhenError
            // 
            this.smiContanaSendEmailWhenError.Checked = true;
            this.smiContanaSendEmailWhenError.CheckOnClick = true;
            this.smiContanaSendEmailWhenError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smiContanaSendEmailWhenError.Name = "smiContanaSendEmailWhenError";
            this.smiContanaSendEmailWhenError.Size = new System.Drawing.Size(230, 22);
            this.smiContanaSendEmailWhenError.Text = "Thực hiện gửi Email khi có lỗi";
            // 
            // smiContanaSendSmsWhenError
            // 
            this.smiContanaSendSmsWhenError.CheckOnClick = true;
            this.smiContanaSendSmsWhenError.Name = "smiContanaSendSmsWhenError";
            this.smiContanaSendSmsWhenError.Size = new System.Drawing.Size(230, 22);
            this.smiContanaSendSmsWhenError.Text = "Thực hiện gửi Sms khi có lỗi";
            // 
            // slTimeStart
            // 
            this.slTimeStart.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.slTimeStart.Name = "slTimeStart";
            this.slTimeStart.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.slTimeStart.Size = new System.Drawing.Size(161, 21);
            this.slTimeStart.Text = "Start: 25/04/2016 03:16:30 PM";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 22);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // slError
            // 
            this.slError.LinkColor = System.Drawing.Color.Red;
            this.slError.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.slError.Name = "slError";
            this.slError.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.slError.Size = new System.Drawing.Size(130, 21);
            this.slError.Text = "Chưa phát hiện thấy lỗi";
            this.slError.Click += new System.EventHandler(this.slError_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 21);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // sstbtnColor
            // 
            this.sstbtnColor.Color = System.Drawing.Color.White;
            this.sstbtnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sstbtnColor.Image = ((System.Drawing.Image)(resources.GetObject("sstbtnColor.Image")));
            this.sstbtnColor.ImageHeight = 16;
            this.sstbtnColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sstbtnColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sstbtnColor.ImageWidth = 35;
            this.sstbtnColor.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.sstbtnColor.Name = "sstbtnColor";
            this.sstbtnColor.Padding = new System.Windows.Forms.Padding(3);
            this.sstbtnColor.Size = new System.Drawing.Size(54, 21);
            this.sstbtnColor.Text = "themeColorPickerToolStripSplitButton1";
            this.sstbtnColor.ColorSelected += new ExHtmlEditor.ColorPicker.ThemeColorPickerToolStripSplitButton.colorSelected(this.sstbtnColor_ColorSelected);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiClearConsole,
            this.smiGC,
            this.smiLock});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 21);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // smiClearConsole
            // 
            this.smiClearConsole.Name = "smiClearConsole";
            this.smiClearConsole.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.smiClearConsole.Size = new System.Drawing.Size(261, 22);
            this.smiClearConsole.Text = "Làm mới màn hình Console";
            this.smiClearConsole.Click += new System.EventHandler(this.smiClearConsole_Click);
            // 
            // smiGC
            // 
            this.smiGC.Name = "smiGC";
            this.smiGC.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.smiGC.Size = new System.Drawing.Size(261, 22);
            this.smiGC.Text = "Làm mới bộ nhớ (GC)";
            this.smiGC.Click += new System.EventHandler(this.smiGC_Click);
            // 
            // smiLock
            // 
            this.smiLock.Name = "smiLock";
            this.smiLock.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.smiLock.Size = new System.Drawing.Size(261, 22);
            this.smiLock.Text = "Khóa màn hình";
            this.smiLock.Click += new System.EventHandler(this.smiLock_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 21);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // slMem
            // 
            this.slMem.Name = "slMem";
            this.slMem.Size = new System.Drawing.Size(68, 22);
            this.slMem.Text = "Mem: 0 Mb";
            // 
            // panelLogin
            // 
            this.panelLogin.AllowDrop = true;
            this.panelLogin.Controls.Add(this.gbLogin);
            this.panelLogin.Location = new System.Drawing.Point(390, 193);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(6);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Padding = new System.Windows.Forms.Padding(6);
            this.panelLogin.Size = new System.Drawing.Size(258, 65);
            this.panelLogin.TabIndex = 32;
            this.panelLogin.Visible = false;
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.txtPass);
            this.gbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogin.Location = new System.Drawing.Point(6, 6);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(246, 53);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Vui lòng nhập mật khẩu";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(189, 18);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(51, 25);
            this.btnLogin.TabIndex = 32;
            this.btnLogin.Text = "Ok";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(8, 19);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '$';
            this.txtPass.Size = new System.Drawing.Size(177, 23);
            this.txtPass.TabIndex = 31;
            this.txtPass.Tag = "";
            // 
            // panelLock
            // 
            this.panelLock.Location = new System.Drawing.Point(-1000, 3);
            this.panelLock.Name = "panelLock";
            this.panelLock.Size = new System.Drawing.Size(273, 200);
            this.panelLock.TabIndex = 0;
            this.panelLock.Visible = false;
            // 
            // FrmCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 455);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelLock);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.chkShowMessage);
            this.Controls.Add(this.console);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "FrmCenter";
            this.Text = "FrmCenter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCenter_FormClosing);
            this.Shown += new System.EventHandler(this.FrmCenter_Shown);
            this.Resize += new System.EventHandler(this.FrmCenter_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnStop;
        protected System.Windows.Forms.Button btnStart;
        protected UILibrary.ShellControl console;
        protected System.Windows.Forms.CheckBox chkShowMessage;
        protected System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.ToolStripStatusLabel slTimeStart;
        protected System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel slError;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem smiStopContana;
        private System.Windows.Forms.ToolStripMenuItem smiStartContana;
        private ExHtmlEditor.ColorPicker.ThemeColorPickerToolStripSplitButton sstbtnColor;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem smiLock;
        private System.Windows.Forms.ToolStripMenuItem smiClearConsole;
        private System.Windows.Forms.ToolStripMenuItem smiGC;
        protected TransparentPanel panelLock;
        private System.Windows.Forms.GroupBox gbLogin;
        protected System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox txtPass;
        protected System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel slMem;
        private System.Windows.Forms.ToolStripMenuItem smiContanaMessage;
        private System.Windows.Forms.ToolStripMenuItem smiContanaCheckRam;
        private System.Windows.Forms.ToolStripMenuItem smiContanaCheckFolderError;
        private System.Windows.Forms.ToolStripMenuItem smiAutoGc;
        protected System.Windows.Forms.ToolStripSplitButton tssbtnContana;
        protected ToolStripMenuItem smiConfigContana;
        private ToolStripMenuItem smiContanaSendEmailWhenError;
        private ToolStripMenuItem smiContanaSendSmsWhenError;

    }
}