namespace Core.Sites.ServerForms
{
    partial class FrmServer
    {
        public FrmServer()
        {
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenFolderRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenFolderError = new System.Windows.Forms.ToolStripMenuItem();
            this.miAboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtSignalRSelfHostIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtSignalRSelfHostPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWCFAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWCFPortTcp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWCFPortHttp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetConfig = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShowMessage
            // 
            this.chkShowMessage.Tag = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Server cho công ty gộp chung, tôi đang ở đây";
            this.notifyIcon1.BalloonTipTitle = "Server cho công ty gộp chung";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Server cho công ty gộp chung";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miProgram});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miProgram
            // 
            this.miProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSaveConfig,
            this.miOpenFolderRoot,
            this.miOpenFolderError,
            this.miAboutUs,
            this.miExit});
            this.miProgram.Name = "miProgram";
            this.miProgram.Size = new System.Drawing.Size(90, 20);
            this.miProgram.Text = "Chương trình";
            // 
            // miSaveConfig
            // 
            this.miSaveConfig.Name = "miSaveConfig";
            this.miSaveConfig.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.miSaveConfig.Size = new System.Drawing.Size(255, 22);
            this.miSaveConfig.Text = "Lưu cấu hình";
            this.miSaveConfig.Click += new System.EventHandler(this.miSaveConfig_Click);
            // 
            // miOpenFolderRoot
            // 
            this.miOpenFolderRoot.Name = "miOpenFolderRoot";
            this.miOpenFolderRoot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpenFolderRoot.Size = new System.Drawing.Size(255, 22);
            this.miOpenFolderRoot.Tag = "";
            this.miOpenFolderRoot.Text = "Mở thư mục chương trình";
            this.miOpenFolderRoot.Click += new System.EventHandler(this.miOpenFolder);
            // 
            // miOpenFolderError
            // 
            this.miOpenFolderError.Name = "miOpenFolderError";
            this.miOpenFolderError.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.miOpenFolderError.Size = new System.Drawing.Size(255, 22);
            this.miOpenFolderError.Tag = "Error";
            this.miOpenFolderError.Text = "Mở thư mục Error";
            this.miOpenFolderError.Click += new System.EventHandler(this.miOpenFolder);
            // 
            // miAboutUs
            // 
            this.miAboutUs.Name = "miAboutUs";
            this.miAboutUs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.miAboutUs.Size = new System.Drawing.Size(255, 22);
            this.miAboutUs.Text = "Giới thiệu";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(255, 22);
            this.miExit.Text = "Thoát";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(14, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 158);
            this.tabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtServerName);
            this.tabPage1.Controls.Add(this.txtSignalRSelfHostIP);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.txtSignalRSelfHostPort);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtWCFAddress);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtWCFPortTcp);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtWCFPortHttp);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(648, 132);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cấu hình";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(400, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tên Server";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(465, 89);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(177, 20);
            this.txtServerName.TabIndex = 7;
            this.txtServerName.Tag = "ServerName";
            this.txtServerName.Text = "Gộp chung thật";
            // 
            // txtSignalRSelfHostIP
            // 
            this.txtSignalRSelfHostIP.Location = new System.Drawing.Point(81, 63);
            this.txtSignalRSelfHostIP.Name = "txtSignalRSelfHostIP";
            this.txtSignalRSelfHostIP.Size = new System.Drawing.Size(177, 20);
            this.txtSignalRSelfHostIP.TabIndex = 3;
            this.txtSignalRSelfHostIP.Tag = "SignalRSelfHostIP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "SignalR IP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "http://{SignalR IP}:{SignalR Port}/signalr/hubs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "http://{WCF IP}:{WCF Http}/ServerFormService";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(561, 36);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Tag = "NeedWriteLogError";
            this.checkBox2.Text = "Ghi log lỗi";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(561, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Tag = "IsDebug";
            this.checkBox1.Text = "Debug";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtSignalRSelfHostPort
            // 
            this.txtSignalRSelfHostPort.Location = new System.Drawing.Point(81, 89);
            this.txtSignalRSelfHostPort.Name = "txtSignalRSelfHostPort";
            this.txtSignalRSelfHostPort.Size = new System.Drawing.Size(54, 20);
            this.txtSignalRSelfHostPort.TabIndex = 4;
            this.txtSignalRSelfHostPort.Tag = "SignalRSelfHostPort";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "SignalR Port";
            // 
            // txtWCFAddress
            // 
            this.txtWCFAddress.Location = new System.Drawing.Point(81, 11);
            this.txtWCFAddress.Name = "txtWCFAddress";
            this.txtWCFAddress.Size = new System.Drawing.Size(177, 20);
            this.txtWCFAddress.TabIndex = 0;
            this.txtWCFAddress.Tag = "WCFAddress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "WCF IP";
            // 
            // txtWCFPortTcp
            // 
            this.txtWCFPortTcp.Location = new System.Drawing.Point(204, 37);
            this.txtWCFPortTcp.Name = "txtWCFPortTcp";
            this.txtWCFPortTcp.Size = new System.Drawing.Size(54, 20);
            this.txtWCFPortTcp.TabIndex = 2;
            this.txtWCFPortTcp.Tag = "WCFPortTcp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "WCF Tcp";
            // 
            // txtWCFPortHttp
            // 
            this.txtWCFPortHttp.Location = new System.Drawing.Point(81, 37);
            this.txtWCFPortHttp.Name = "txtWCFPortHttp";
            this.txtWCFPortHttp.Size = new System.Drawing.Size(54, 20);
            this.txtWCFPortHttp.TabIndex = 1;
            this.txtWCFPortHttp.Tag = "WCFPortHttp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WCF Http";
            // 
            // btnResetConfig
            // 
            this.btnResetConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetConfig.Location = new System.Drawing.Point(371, 393);
            this.btnResetConfig.Name = "btnResetConfig";
            this.btnResetConfig.Size = new System.Drawing.Size(137, 29);
            this.btnResetConfig.TabIndex = 36;
            this.btnResetConfig.Text = "Thiết lập lại cấu hình";
            this.btnResetConfig.UseVisualStyleBackColor = true;
            this.btnResetConfig.Click += new System.EventHandler(this.btnResetConfig_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 455);
            this.Controls.Add(this.btnResetConfig);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmServer";
            this.Text = "Server cho công ty gộp chung";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.btnStart, 0);
            this.Controls.SetChildIndex(this.btnStop, 0);
            this.Controls.SetChildIndex(this.console, 0);
            this.Controls.SetChildIndex(this.chkShowMessage, 0);
            this.Controls.SetChildIndex(this.panelLock, 0);
            this.Controls.SetChildIndex(this.panelLogin, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnResetConfig, 0);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miProgram;
        private System.Windows.Forms.ToolStripMenuItem miSaveConfig;
        private System.Windows.Forms.ToolStripMenuItem miOpenFolderRoot;
        private System.Windows.Forms.ToolStripMenuItem miOpenFolderError;
        private System.Windows.Forms.ToolStripMenuItem miAboutUs;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtWCFPortHttp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWCFPortTcp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWCFAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSignalRSelfHostPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSignalRSelfHostIP;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Button btnResetConfig;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label8;
    }
}

