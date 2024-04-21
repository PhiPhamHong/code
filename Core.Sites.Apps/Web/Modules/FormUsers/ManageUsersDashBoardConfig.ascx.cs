using Core.Attributes;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    [Script(Src = "/Web/Modules/FormUsers/js/ManageUsersDashBoardConfig.js")]
    public partial class ManageUsersDashBoardConfig : DashBoardConfig<ManageUsersDashBoardConfig.ConfigModel>
    {   
        public class ConfigModel
        {
            [PropertyInfo(Name = "Loại hiển thị")]
            public OptionReportType OptionReportType { set; get; }
        }

        public enum OptionReportType
        {
            [FieldInfo(Name = "Chỉ công ty cha")] OnlyCompany = 0,
            [FieldInfo(Name = "Tất cả hệ thống")] AllCompany = 1
        }

        public class OptionReportTypeInput : SelectEnum<OptionReportType, OptionReportTypeInput> { }
    }
}