namespace Manage.Timekeeper.Tools
{
    partial class Tool
    {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtMachineNumber = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDeviceInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRing = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.dpkTo = new System.Windows.Forms.DateTimePicker();
            this.dpkFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnGetAllUsers = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveAndDelete = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPing);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtMachineNumber);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target:";
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(685, 20);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(75, 23);
            this.btnPing.TabIndex = 7;
            this.btnPing.Text = "Ping device";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(588, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtMachineNumber
            // 
            this.txtMachineNumber.Location = new System.Drawing.Point(513, 22);
            this.txtMachineNumber.Name = "txtMachineNumber";
            this.txtMachineNumber.Size = new System.Drawing.Size(48, 20);
            this.txtMachineNumber.TabIndex = 7;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(338, 22);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(68, 20);
            this.txtPort.TabIndex = 6;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(101, 22);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(171, 20);
            this.txtIP.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Machine number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Device infomation:";
            // 
            // lblDeviceInfo
            // 
            this.lblDeviceInfo.AutoSize = true;
            this.lblDeviceInfo.Location = new System.Drawing.Point(119, 85);
            this.lblDeviceInfo.Name = "lblDeviceInfo";
            this.lblDeviceInfo.Size = new System.Drawing.Size(16, 13);
            this.lblDeviceInfo.TabIndex = 4;
            this.lblDeviceInfo.Text = "---";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtUserId);
            this.groupBox2.Controls.Add(this.dpkTo);
            this.groupBox2.Controls.Add(this.dpkFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.lblUserId);
            this.groupBox2.Controls.Add(this.btnGetData);
            this.groupBox2.Controls.Add(this.btnGetAllUsers);
            this.groupBox2.Controls.Add(this.dgvResult);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 372);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From function:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnRing);
            this.groupBox3.Controls.Add(this.btnOpen);
            this.groupBox3.Controls.Add(this.btnLock);
            this.groupBox3.Controls.Add(this.btnOff);
            this.groupBox3.Controls.Add(this.btnRestart);
            this.groupBox3.Location = new System.Drawing.Point(383, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 110);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Utilities:";
            // 
            // btnRing
            // 
            this.btnRing.Location = new System.Drawing.Point(47, 67);
            this.btnRing.Name = "btnRing";
            this.btnRing.Size = new System.Drawing.Size(91, 35);
            this.btnRing.TabIndex = 3;
            this.btnRing.Text = "Ring";
            this.btnRing.UseVisualStyleBackColor = true;
            this.btnRing.Click += new System.EventHandler(this.btnRing_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(47, 22);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(91, 35);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open device";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(144, 22);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(91, 35);
            this.btnLock.TabIndex = 5;
            this.btnLock.Text = "Lock device";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnOff
            // 
            this.btnOff.Location = new System.Drawing.Point(144, 67);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(91, 35);
            this.btnOff.TabIndex = 7;
            this.btnOff.Text = "Power off";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(241, 22);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(91, 35);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "Restart device";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(153, 27);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(56, 20);
            this.txtUserId.TabIndex = 13;
            // 
            // dpkTo
            // 
            this.dpkTo.CustomFormat = "dd/MM/yyyy";
            this.dpkTo.Location = new System.Drawing.Point(153, 86);
            this.dpkTo.Name = "dpkTo";
            this.dpkTo.Size = new System.Drawing.Size(119, 20);
            this.dpkTo.TabIndex = 12;
            // 
            // dpkFrom
            // 
            this.dpkFrom.CustomFormat = "dd/MM/yyyy";
            this.dpkFrom.Location = new System.Drawing.Point(153, 56);
            this.dpkFrom.Name = "dpkFrom";
            this.dpkFrom.Size = new System.Drawing.Size(119, 20);
            this.dpkFrom.TabIndex = 11;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(101, 89);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(101, 59);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "From:";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(101, 30);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(46, 13);
            this.lblUserId.TabIndex = 8;
            this.lblUserId.Text = "User ID:";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(15, 69);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(80, 35);
            this.btnGetData.TabIndex = 2;
            this.btnGetData.Text = "Get data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnGetAllUsers
            // 
            this.btnGetAllUsers.Location = new System.Drawing.Point(15, 29);
            this.btnGetAllUsers.Name = "btnGetAllUsers";
            this.btnGetAllUsers.Size = new System.Drawing.Size(80, 35);
            this.btnGetAllUsers.TabIndex = 1;
            this.btnGetAllUsers.Text = "Get all users";
            this.btnGetAllUsers.UseVisualStyleBackColor = true;
            this.btnGetAllUsers.Click += new System.EventHandler(this.btnGetAllUsers_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(15, 135);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(745, 231);
            this.dgvResult.TabIndex = 883;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(536, 519);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 35);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAndDelete
            // 
            this.btnSaveAndDelete.Location = new System.Drawing.Point(664, 519);
            this.btnSaveAndDelete.Name = "btnSaveAndDelete";
            this.btnSaveAndDelete.Size = new System.Drawing.Size(105, 35);
            this.btnSaveAndDelete.TabIndex = 9;
            this.btnSaveAndDelete.Text = "Save and delete";
            this.btnSaveAndDelete.UseVisualStyleBackColor = true;
            this.btnSaveAndDelete.Click += new System.EventHandler(this.btnSaveAndDelete_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(9, 491);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblStatus.Size = new System.Drawing.Size(776, 25);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Result:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(241, 67);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 35);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 559);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSaveAndDelete);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblDeviceInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Tool";
            this.Text = "Device Management Tool";
            this.Load += new System.EventHandler(this.Tool_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtMachineNumber;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDeviceInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRing;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnGetAllUsers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.DateTimePicker dpkTo;
        private System.Windows.Forms.DateTimePicker dpkFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAndDelete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAdd;
    }
}

