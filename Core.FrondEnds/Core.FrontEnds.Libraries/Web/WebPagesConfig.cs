using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.Web.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Serialization;
using Core.Extensions;
using Core.Reflectors;

namespace Core.FrontEnds.Libraries.Web
{
    [Serializable, XmlRoot("root")]
    public class WebPagesConfig : PagesConfig
    {
        public List<ModuleDefine> ModuleDefines { set; get; }

        public Control LoadControlByName(string name)
        {
            var module = ModuleDefines.FirstOrDefault(md => md.Name == name);
            if (module == null) return null;
            var page = HttpContext.Current.CurrentHandler as Page;
            var control = page.LoadControl(module.Path);

            var conditions = control.GetType().GetAttributes<Module.ConditionAttribute>().OrderBy(c => c.Stt).ToList();
            if (conditions.Count != 0)
            {
                var condition = conditions.FirstOrDefault(c => !c.Condition);
                if (condition != null)
                {
                    if (control is IModuleHasControlError)
                    {
                        control = control.As<IModuleHasControlError>().ControlError;
                        if (control.Is<IModuleError>())
                        {
                            control.As<IModuleError>().Title = "Thông báo".Translate();
                            control.As<IModuleError>().Content = condition.Msg;
                        }
                        return control;
                    }
                    else throw new Exception(condition.Msg);
                }
            }

            control.Parse(page.Request.Params, false);
            return control;
        }
        public TControl LoadControl<TControl>(string name, Action<TControl> func = null) where TControl : ControlBase
        {
            var control = LoadControlByName(name) as TControl;
            if (func != null) func(control);
            if (!control.Is<IModuleError>()) control.InitData();
            return control;
        }
        public TControl LoadControl<TControl>(Action<TControl> func = null) where TControl : ControlBase
        {
            return LoadControl(typeof(TControl).Name, func);
        }
        public ControlBase LoadControl(string name, Action<ControlBase> func = null)
        {
            return LoadControl<ControlBase>(name, func);
        }
        public TModule LoadModule<TModule>(string name, Action<TModule> func = null) where TModule : Module
        {
            return LoadControl(name, func);
        }
        public TModule LoadModule<TModule>(Action<TModule> func = null) where TModule : Module
        {
            return LoadModule(typeof(TModule).Name, func);
        }
        public Module LoadModule(string name, Action<Module> func = null)
        {
            return LoadModule<Module>(name, func);
        }
        public override string GetPath()
        {
            return HttpContext.Current.Server.MapPath("~/Projects/" + Setting.Project + "/Settings/Pages.config");
        }
        public override void AfterLoad()
        {
            ModuleDefines = Setting.Assemblies.SelectMany(a => ReflectAssemblyClassInfoAttribute<ModuleAttribute>.Inst[a].Select(m => new ModuleDefine
            {
                Name = m.Type.Name,
                Path = m.GetPath()
            }))
            //.Where(md => md.Path.IndexOf("~/Common/Modules/") >= 0 || md.Path.IndexOf(Setting.Project) >= 0)
            .ToList();

            var urlEngines = GetType().Assembly.GetTypes().Where(t => t.HasInterface(typeof(IUrlEngine)) && !t.IsAbstract).Select(t => new ModuleDefine
            {
                Name = t.Name,
                Path = t.GetTypeNameWithAssembly()
            }).ToList();

            Pages.ForEach(page =>
            {
                page.Columns.ForEach(c => BuildModuleOfColumn(ModuleDefines, c));
                if (page.UrlEngines != null)
                    EnumerableExtension.SJoin(page.UrlEngines, urlEngines, ue => ue.Name, md => md.Name, (ue, md) => ue.Type = md.Path);
            });
        }

        private void BuildModuleOfColumn(List<ModuleDefine> moduleDefines, ColumnTag column)
        {
            EnumerableExtension.SJoin(column.Modules, moduleDefines, m => m.Name, md => md.Name, (m, md) => m.Path = md.Path);
            column.Columns.ForEach(c => BuildModuleOfColumn(moduleDefines, c));
        }

        public class ModuleDefine
        {
            public string Path { set; get; }
            public string Name { set; get; }
        }
    }
}
