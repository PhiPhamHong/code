using Manage.Timekeeper.Tools.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;
using Manage.Timekeeper.Tools.Extensions;
using System.Collections.Generic;

namespace Manage.Timekeeper.Tools
{
    public partial class Tool : Form
    {
        DeviceManipulator manipulator = new DeviceManipulator();
        public DeviceClient objZkeeper;
        private bool isDeviceConnected = false;
        private void ToggleControls(bool value)
        {
            btnRing.Enabled = value;
            btnGetAllUsers.Enabled = value;
            btnGetData.Enabled = value;
            btnOff.Enabled = value;
            btnRestart.Enabled = value;
            btnOpen.Enabled = value;
            btnLock.Enabled = value;
            btnAdd.Enabled = value;
            btnSave.Enabled = value;
            btnSaveAndDelete.Enabled = value;
            txtMachineNumber.Enabled = !value;
            txtPort.Enabled = !value;
            txtIP.Enabled = !value;

        }
        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                        ShowStatusBar("The device is switched off", true);
                        DisplayEmpty();
                        btnConnect.Text = "Connect";
                        ToggleControls(false);
                        break;
                    }
                default:
                    break;
            }
        }
        private void ClearGrid()
        {
            if (dgvResult.Controls.Count > 2)
            { dgvResult.Controls.RemoveAt(2); }


            dgvResult.DataSource = null;
            dgvResult.Controls.Clear();
            dgvResult.Rows.Clear();
            dgvResult.Columns.Clear();
        }
        private void DisplayEmpty()
        {
            ClearGrid();
            btnGetAllUsers.Hide();
            btnGetData.Hide();
            lblUserId.Hide();
            lblFrom.Hide();
            lblTo.Hide();
            txtUserId.Hide();
            dpkFrom.Hide();
            dpkTo.Hide();
            groupBox3.Hide();
            dgvResult.Dock = DockStyle.Fill;
            dgvResult.Controls.Add(new DataEmpty());
        }
        private void ShowContent()
        {
            btnGetAllUsers.Show();
            btnGetData.Show();
            lblUserId.Show();
            lblFrom.Show();
            lblTo.Show();
            txtUserId.Show();
            dpkFrom.Show();
            dpkTo.Show();
            groupBox3.Show();
            dgvResult.Dock = DockStyle.None;
        }
        public bool IsDeviceConnected
        {
            get { return isDeviceConnected; }
            set
            {
                isDeviceConnected = value;
                if (isDeviceConnected)
                {
                    ShowStatusBar("The device is connected !!", true);
                    btnConnect.Text = "Disconnect";
                    ToggleControls(true);
                }
                else
                {
                    ShowStatusBar("The device is diconnected !!", true);
                    objZkeeper.Disconnect();
                    btnConnect.Text = "Connect";
                    ToggleControls(false);
                }
            }
        }
        public Tool()
        {
            InitializeComponent();
            ToggleControls(false);
            ShowStatusBar(string.Empty, true);
            DisplayEmpty();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            bool deviceEnabled = objZkeeper.EnableDevice(int.Parse(txtMachineNumber.Text.Trim()), true);
        }
        public void ShowStatusBar(string message, bool type)
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.White;

            if (type)
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            else
                lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ShowStatusBar(string.Empty, true);
                if (IsDeviceConnected)
                {
                    IsDeviceConnected = false;
                    Cursor = Cursors.Default;
                    return;
                }
                string ipAddress = txtIP.Text.Trim();
                string port = txtPort.Text.Trim();
                if (ipAddress == string.Empty || port == string.Empty)
                    throw new Exception("The Device IP Address and Port is mandotory !!");
                int portNumber = 4370;
                if (!int.TryParse(port, out portNumber))
                    throw new Exception("Not a valid port number");

                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The Device IP is invalid !!");

                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The device at " + ipAddress + ":" + port + " did not respond!!");

                objZkeeper = new DeviceClient(RaiseDeviceEvent);
                IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);

                if (IsDeviceConnected)
                {
                    ShowContent();
                    string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, int.Parse(txtMachineNumber.Text.Trim()));
                    lblDeviceInfo.Text = deviceInfo + "            Device time: " + GetDeviceTime();
                }

            }
            catch (Exception ex)
            {
                ShowStatusBar(ex.Message, false);
            }
            Cursor = Cursors.Default;
        }

        private string GetDeviceTime()
        {
            int machineNumber = int.Parse(txtMachineNumber.Text.Trim());
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            bool result = objZkeeper.GetDeviceTime(machineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);
            return new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();
        }
        private void GetAllUserId()
        {
            try
            {
                ICollection<UserIDInfo> lstUserIDInfo = manipulator.GetAllUserID(objZkeeper, int.Parse(txtMachineNumber.Text.Trim()));

                if (lstUserIDInfo != null && lstUserIDInfo.Count > 0)
                {
                    BindToGridView(lstUserIDInfo);
                    ShowStatusBar(lstUserIDInfo.Count + " records found !!", true);
                }
                else
                {
                    DisplayEmpty();
                    DisplayListOutput("No records found");
                }

            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }
        }
        private void Tool_Load(object sender, EventArgs e)
        {
        //Máy 1 172.16.6.200, tên máy: Ronald Jack F18 || Máy2: 172.16.3.213(vp mới), tên máy: ronad jack
            txtIP.Text = "172.16.6.200";
            txtMachineNumber.Text = "1"; // Test máy 1 thì cái này là 1
            txtPort.Text = "4370"; // mặc định
            dpkFrom.Value = DateTime.Now;
            dpkTo.Value = DateTime.Now;
        }

        private void btnGetAllUsers_Click(object sender, EventArgs e)
        {
            try
            {
                ShowStatusBar(string.Empty, true);

                ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(txtMachineNumber.Text.Trim()));
                if (lstFingerPrintTemplates != null && lstFingerPrintTemplates.Count > 0)
                {
                    BindToGridView(lstFingerPrintTemplates);
                    ShowStatusBar(lstFingerPrintTemplates.Count + " records found !!", true);
                }
                else
                    DisplayListOutput("No records found");
            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }
        }
        private void DisplayListOutput(string message)
        {
            if (dgvResult.Controls.Count > 2)
            { dgvResult.Controls.RemoveAt(2); }
            ShowStatusBar(message, false);
        }
        private void BindToGridView(object list)
        {
            ClearGrid();
            dgvResult.DataSource = list;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UniversalStatic.ChangeGridProperties(dgvResult);
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                ShowStatusBar(string.Empty, true);

                ICollection<MachineInfo> lstMachineInfo = manipulator.GetLogData(objZkeeper, int.Parse(txtMachineNumber.Text.Trim()));

                if (lstMachineInfo != null && lstMachineInfo.Count > 0)
                {
                    BindToGridView(lstMachineInfo);
                    ShowStatusBar(lstMachineInfo.Count + " records found !!", true);
                }
                else
                    DisplayListOutput("No records found");
            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = txtIP.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                throw new Exception("The Device IP is invalid !!");

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("The device is active", true);
            else
                ShowStatusBar("Could not read any response", false);
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            bool deviceDisabled = objZkeeper.DisableDeviceWithTimeOut(int.Parse(txtMachineNumber.Text.Trim()), 3000);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            DialogResult rslt = MessageBox.Show("Do you want to restart the device now?", "Restart Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rslt == DialogResult.Yes)
            {
                if (objZkeeper.RestartDevice(int.Parse(txtMachineNumber.Text.Trim())))
                    ShowStatusBar("The device is being restarted, Please wait...", true);
                else
                    ShowStatusBar("Operation failed, please try again!", false);
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var resultDia = DialogResult.None;
            resultDia = MessageBox.Show("Do you want to Power Off the Device?", "Power Off Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDia == DialogResult.Yes)
            {
                bool deviceOff = objZkeeper.PowerOffDevice(int.Parse(txtMachineNumber.Text.Trim()));
            }
            Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add you new UserInfo Here and  uncomment the below code
            //List<UserInfo> lstUserInfo = new List<UserInfo>();
            //manipulator.UploadFTPTemplate(objZkeeper, int.Parse(tbxMachineNumber.Text.Trim()), lstUserInfo);
        }

        private void btnRing_Click(object sender, EventArgs e)
        {
            objZkeeper.Beep(100);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAndDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
