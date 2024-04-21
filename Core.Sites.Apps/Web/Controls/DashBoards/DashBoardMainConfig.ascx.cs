using System;
using System.Web;
using System.Web.UI;

using Core.Attributes;
using Core.Attributes.Validators;

using Core.Web.WebBase;
using Core.Web.Extensions;
using Core.Web.WebBase.HtmlBuilders;
using Core.Utility;
using Core.Extensions;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Utilities;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Sites.Apps.Web.Controls.DashBoards.BoxType;
using Core.Business.Enums;

namespace Core.Sites.Apps.Web.Controls.DashBoards
{
    public partial class DashBoardMainConfig : PortalModule<DashBoardMainConfig.Model>
    {
        protected override void OnInitData()
        {
            var dashboard = LoadControlDashBoard(PortalContext.SessionType);
            dashboard.T1.LoadItem(dashboard.T2);

            // Add module config lên form
            (dashboard.T1 as ControlBase).InitData();
            plc.Controls.Add(dashboard.T1 as Control);

            // Điền thông tin config xuống client để js điền lên form
            this.SetData("ModelConfig", dashboard.T1.ModelConfig);
            this.SetData("CommonConfig", dashboard.T2);
            this.SetData("Scripts", ReflectTypeListScriptAttribute.Inst[dashboard.T1.GetType()].GetScriptItems());
            this.SetData("ControlDashBoardConfig", dashboard.T1.GetType().BaseType.Name);
        }

        public void Save()
        {
            var dashboard = LoadControlDashBoard(PortalContext.SessionType);
            Entity = new Model();
            this.ParseParamTo(Entity, true);                     // Lấy thông tin cấu hình chung
            this.ParseParamTo(dashboard.T1.ModelConfig, true);   // Lấy thông tin cấu hình của từng dashboard
            this.ParseParamTo(dashboard.T2, true);

            dashboard.T2.Url = ModuleUrl;
            dashboard.T2.Id = DashBoardId.ToGuid();
            if (dashboard.T2.Id == Guid.Empty) dashboard.T2.Id = Guid.NewGuid();

            // Thiết lập thông tin cấu hình từng dashboard riêng
            dashboard.T2.Settings = dashboard.T1.GetConfig();

            // Lưu lại vào file cấu hình theo từng User
            MainDashBoard.Save(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType, dashboard.T2);
            this.SetData("Config", Entity);
        }

        public class Model
        {
            [PropertyInfo(Name = "Tiêu đề"), ValidatorRequire] public string Title { set; get; }
            [PropertyInfo(Name = "Số thứ tự"), ValidatorRequire, ValidatorRange(RangeType.Greater, Min = 0)] public int Stt { set; get; }
            [PropertyInfo(Name = "Độ rộng")] public int Col { set; get; }
            [PropertyInfo(Name = "Loại khung")] public BoxTypeInput.BoxType TypeBox { set; get; }
            [PropertyInfo(Name = "Bảng điều khiển"), ValidatorDenyValue("0")] public int TabId { set; get; }
        }

        #region ColInput
        public class ColInput : SelectEnum<Col, ColInput> { }

        public enum Col
        {
            [FieldInfo(Name = "3 cột")] Col3 = 3,
            [FieldInfo(Name = "4 cột")] Col4 = 4,
            [FieldInfo(Name = "5 cột")] Col5 = 5,
            [FieldInfo(Name = "6 cột")] Col6 = 6,
            [FieldInfo(Name = "7 cột")] Col7 = 7,
            [FieldInfo(Name = "8 cột")] Col8 = 8,
            [FieldInfo(Name = "9 cột")] Col9 = 9,
            [FieldInfo(Name = "10 cột")] Col10 = 10,
            [FieldInfo(Name = "11 cột")] Col11 = 11,
            [FieldInfo(Name = "12 cột")] Col12 = 12
        }
        #endregion

        private Pair<IDashBoardConfig, DashBoardItem> LoadControlDashBoard(SessionType sessionType)
        {
            // Load module config
            var cacheDataUrl = CacheUrl.GetDataNoneExtension(ModuleUrl, sessionType);
            if (!PortalContext.Session.HasPermission(cacheDataUrl.MenuItem.Pers)) throw new ErrorMessageException("Bạn không có quyền chỉnh sửa theo dõi này");

            var moduleConfig = LoadControl(cacheDataUrl.MenuItem.ModulePath.GetDashBoardConfig()) as IDashBoardConfig;

            // Load lại thông số đã lưu trước đó
            var dashBoardItem = MainDashBoard.LoadConfig(PortalContext.CurrentUser.User.UserId, DashBoardId, sessionType);
            if (dashBoardItem.Stt == 0) dashBoardItem.Stt = MainDashBoard.GetNextStt(PortalContext.CurrentUser.User.UserId, sessionType);

            return new Pair<IDashBoardConfig, DashBoardItem> { T1 = moduleConfig, T2 = dashBoardItem };
        }

        protected string ModuleUrl => GetParam<string>("moduleUrl");
        protected string DashBoardId => GetParam<string>("db");
    }
}