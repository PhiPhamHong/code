using Core.Sites.Libraries.Business;
using System.Linq;
using Core.Web.WebBase;
using Core.Extensions;
using System;
using System.Web.UI;
using Core.Business.Entities;
namespace Core.Sites.Libraries.Utilities.Sites
{
    public class DashBoard<TConfig> : DashBoard<TConfig, TConfig> where TConfig : class, new() { }

    public class DashBoardByModule<TModel, TConfig> : DashBoard<TModel, TConfig>
        where TModel : class, new()
        where TConfig : class, IDashBoardConfigByModule, new()
    {
        sealed protected override void InitDashBoard()
        {
            var module = this.LoadModule(Config.ModuleType);
            if (module != null)
            {
                Controls.Add(module);
                module.DataBind();
                this.SetData("DashBoardModule", (module as ControlBase).ControlName);
                this.SetData("DashBoardModuleProject", module.GetType().BaseType.Assembly.FullName.Split(',')[0]);
            }
        }
        public class Module : PortalModule<TModel>, IDashBoardModule<TConfig>
        {
            public TConfig Config { set; get; }
            public IDashBoard DashBoard { set; get; }

            sealed protected override void OnInitData()
            {
                if (Config == null) Config = this.ParseParamTo<TConfig>(true);
                if (Config.Is<ICompanyNeedValidate>())
                    Config.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCompanyId(Config.As<ICompanyNeedValidate>().CompanyId);

                DashBoardInit();
            }

            protected virtual void DashBoardInit() { }
        }
    }

    public class DashBoardByModule<TConfig> : DashBoardByModule<TConfig, TConfig> where TConfig : class, IDashBoardConfigByModule, new() { }

    public interface IDashBoardConfigByModule
    {
        Enum ModuleType { get; }
    }

    public class DashBoard<TModel, TConfig> : PortalModule<TModel>, IDashBoard<TConfig>, IDashBoard
        where TModel : class, new()
        where TConfig : class, new()
    {
        public object ModelConfig => Config;
        public TConfig Config { get; } = new TConfig();
        public DashBoardItem DashBoardItem { get; private set; } = null;

        public void LoadItem(DashBoardItem item)
        {
            DashBoardItem = item;
            if (item.Settings != null)
                Config.Parse(item.Settings.ToDictionary(a => a.Name, a => (object)a.Value), false);

            if (Config.Is<ICompanyNeedValidate>())
                Config.As<ICompanyNeedValidate>().CompanyId = PortalContext.CurrentUser.GetCompanyId(Config.As<ICompanyNeedValidate>().CompanyId);
        }

        public CacheUrl.CacheUrlData UrlData { set; get; }

        sealed protected override void OnInitData()
        {
            this.SetData("DashBoardConfig", Config);
            InitDashBoard();
        }

        protected virtual void InitDashBoard() { }
    }

    public static class IDashBoardExtension
    {
        public static Control LoadModule<TConfig>(this IDashBoard<TConfig> dashboard, Enum e) where TConfig : class, new()
        {
            var attr = e.GetType().GetMember(e.ToString()).Select(m => m.GetAttribute<DashBoardTypeAttribute>()).FirstOrDefault();
            if (attr == null) return null;
            var module = ControlBase.DoLoad(attr.TypeModule);
            (module as IDashBoardModule<TConfig>).Config = dashboard.Config;
            (module as IDashBoardModule<TConfig>).DashBoard = dashboard;
            module.InitData();
            return module;
        }
    }
}