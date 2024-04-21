namespace Manage.Timekeeper.Tools
{
    internal class UserInfo
    {

        public int MachineNumber { get; set; } // Mã máy
        public string EnrollNumber { get; set; } //UserId
        public string Name { get; set; }
        public int FingerIndex { get; set; } // 0->9 : Fingerprint Template 0 - 9, 10 = Password
        public string TmpData { get; set; } // Vân tay được mã hóa dạng text
        public int Privelage { get; set; } //Quyền: 0 = bình thường, 1 = Admin full, 2 = Admin quản lý users, 3 = Admin settings thiết bị 
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public string iFlag { get; set; }

    }
}
