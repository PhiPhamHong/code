using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
using Core.Extensions;
using System.Linq;
using System.Reflection;
using Core.Business.Entities;

namespace Core.Sites.Apps.Web.Controls.ManageModules
{
    [Module]
    [Script(Src = "/Web/Controls/ManageModules/js/FormSaveConfig.js")]
    public partial class FormSaveConfig : PortalModule<FormSaveConfigSetting>, IAjax
    {
        protected override void OnInitData()
        {
            var moduleInfo = ModuleConfigInfo.Get(this.Query("Module"));

            var module = LoadControl(moduleInfo.PathItem.GetPathControl());
            module.Parse(Request.Params, false);

            if (moduleInfo.PropertySetting != null)
                moduleInfo.PropertySetting.SetValue(module, moduleInfo.Setting);

            module.As<PortalModule>().InitData();

            plc.Controls.Add(module);
            this.SetData("ModuleConfigScripts", ReflectTypeListScriptAttribute.Inst[module.GetType()].GetScriptItems());
            this.SetData("ModuleConfigName", moduleInfo.PathItem.Name);
            this.SetData("ModuleConfigTypeAction", module.As<PortalModule>().ControlName);
            this.SetData("ModuleConfigProject", module.As<PortalModule>().ModuleProject);
            this.SetData("Setting", moduleInfo.Setting);
        }

        public void SaveConfig()
        {
            var moduleName = $"{this.Query("Module")}Config";
            var modulePathItem = PortalContext.PathImageForMenuConfig.FirstOrDefault(pi => pi.Name == moduleName);
            var propertySetting = modulePathItem.Type.GetProperty("Setting", BindingFlags.Instance | BindingFlags.NonPublic);
            var setting = propertySetting.PropertyType.CreateInstance();

            this.ParseParamTo(setting, true);

            var userConfig = PortalContext.CurrentUser.GetConfig(moduleName);
            userConfig.Config = setting.ToJson2();
            userConfig.Upsert();

            this.SetData("Setting", setting);
        }

        [Module]
        public class FormConfigModule<TSetting> : PortalModule<TSetting> where TSetting: FormSaveConfigSetting, new()
        {
            protected TSetting Setting
            {
                set { Entity = value; }
                get { return Entity; }
            }
        }

        public class Module<TEntity, TSetting> : PortalModule<TEntity>
            where TEntity : class, new()
            where TSetting : FormSaveConfigSetting, new()
        {
            protected TSetting Setting { set; get; }

            sealed protected override void OnInitData()
            {
                OnInitDataBeforeLoadSetting();
                var moduleInfo = ModuleConfigInfo.Get(GetType().BaseType.Name);
                Setting = moduleInfo.Setting as TSetting;
                if (Entity != null) FillSaveConfig.FillSetting(Entity, moduleInfo.PropertySetting, Setting);
                OnInitDataAfterLoadSetting();

                this.SetData("Setting", Setting);
            }

            protected virtual void OnInitDataBeforeLoadSetting() { }
            protected virtual void OnInitDataAfterLoadSetting() { }
        }
    }
}