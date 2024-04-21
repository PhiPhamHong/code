using Core.Utility.Xml;
namespace Core.Forms
{
    public partial class FrmConfigContana
    {
        public class Setting : ConfigBase
        {
            public int Interval { set; get; }
            public string FolderError { set; get; }
            public int ClearConsole { set; get; }
            public string Email { set; get; }
            public string PasswordEmail { set; get; }
            public string SendBy { set; get; }
            public string EmailTo { set; get; }
            public int GCInterval { set; get; }
            public string PhoneReceiveSms { set; get; }

            public override string GetPath()
            {
                return "FrmConfigContana.Setting.config";
            }
        }
    }
}