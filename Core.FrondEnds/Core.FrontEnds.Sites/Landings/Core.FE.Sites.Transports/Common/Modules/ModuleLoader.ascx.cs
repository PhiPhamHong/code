using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.Web.WebBase;
using Core.Extensions;
namespace Core.FE.Sites.Transports.Common.Modules
{
    [Module]
    public partial class ModuleLoader : Module, IAjax
    {
        public string ModuleName { set; get; }

        protected override void OnInitData()
        {
            var module = LoadByName(ModuleName);
            if (module == null) return;
            plc.Controls.Add(module);
        }

        public void LoadModuleByControl()
        {
            var module = LoadByName(this.Query<string>("control"));
            if (module != null) this.SetData("ModuleContent", module.Html);
        }

        protected ControlBase LoadByName(string name)
        {
            if (name.IsNull()) return null;
            var module = FeContext.PagesConfig.LoadControl(name);
            if (module == null) return null;
            return module;
        }
    }
}