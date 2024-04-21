using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
using Core.Extensions;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using System.Web.UI;
using Core.Business.Enums;
using Core.Attributes;
using System.Collections.Generic;
using Core.Utility;

namespace Core.Sites.Apps.Web.Controls.Prints
{
    [Script(Src = "/Web/Controls/Prints/js/Printer.js", Index = -2)]
    [Module]
    public partial class Printer : PortalModule<Printer.Setting>, IAjax
    {
        protected override void OnInitData()
        {
            var modulePrintName = this.Query("ModulePrint"); 
            var modulePrintConfigName = IsConfig ? $"{modulePrintName}Config" : string.Empty;

            var modulePrintPathItem = PortalContext.PathImageForMenuConfig.FirstOrDefault(pi => pi.Name == modulePrintName);
            object setting = null;

            var propertySetting = modulePrintPathItem.Type.GetProperty("Setting", BindingFlags.Instance | BindingFlags.NonPublic);
            if (propertySetting != null)
            {
                // Tải thông tin cấu hình của người dùng theo module
                var userPrintConfig = PortalContext.CurrentUser.GetConfig(modulePrintName);
                if (userPrintConfig.Config.IsNotNull())
                    try { setting = JsonConvert.DeserializeObject(userPrintConfig.Config, propertySetting.PropertyType); }
                    catch { }

                if (setting == null) setting = propertySetting.PropertyType.CreateInstance();
            }

            if (modulePrintConfigName.IsNotNull())
            {
                var modulePrintPathItemConfig = PortalContext.PathImageForMenuConfig.FirstOrDefault(pi => pi.Name == modulePrintConfigName);
                if (modulePrintPathItemConfig != null) modulePrintPathItem = modulePrintPathItemConfig;
                else
                {
                    modulePrintPathItem = null;
                    modulePrintConfigName = string.Empty;
                }
            }
            if (modulePrintPathItem != null)
            {
                var modulePrint = LoadControl(modulePrintPathItem.GetPathControl());
                modulePrint.Parse(Request.Params, false);

                if (modulePrintConfigName.IsNotNull())
                    propertySetting = modulePrintPathItem.Type.GetProperty("Setting", BindingFlags.Instance | BindingFlags.NonPublic);

                propertySetting.SetValue(modulePrint, setting);
                modulePrint.As<PortalModule>().InitData();

                GetControl().Controls.Add(modulePrint);
                this.SetData("PrintScripts", ReflectTypeListScriptAttribute.Inst[modulePrint.GetType()].GetScriptItems());
                this.SetData("PrintModuleName", modulePrintPathItem.Name);
                this.SetData("PrintModuleTypeAction", modulePrint.As<PortalModule>().ControlName);
                this.SetData("PrintModuleProject", modulePrint.As<PortalModule>().ModuleProject);
            }

            this.SetData("Setting", Entity = (Setting)setting);
            this.SetData("StyleBody", ((Setting)setting).GetBodyStyle());
        }
        
        protected virtual Control GetControl() => plc;
        protected virtual bool IsConfig => false;

        public class Setting : ISetting
        {
            #region Margin
            [PropertyInfo(Name = "Lề trên")] public decimal? MarginTop { set; get; }
            public Gallon MarginTopGallon { set; get; }

            [PropertyInfo(Name = "Lề trái")] public decimal? MarginLeft { set; get; }
            public Gallon MarginLeftGallon { set; get; }

            [PropertyInfo(Name = "Lề phải")] public decimal? MarginRight { set; get; }
            public Gallon MarginRightGallon { set; get; }

            [PropertyInfo(Name = "Lề dưới")] public decimal? MarginBottom { set; get; }
            public Gallon MarginBottomGallon { set; get; }
            #endregion
            #region Padding
            [PropertyInfo(Name = "Đệm trên")] public decimal? PaddingTop { set; get; }
            public Gallon PaddingTopGallon { set; get; }

            [PropertyInfo(Name = "Đệm trái")] public decimal? PaddingLeft { set; get; }
            public Gallon PaddingLeftGallon { set; get; }

            [PropertyInfo(Name = "Đệm phải")] public decimal? PaddingRight { set; get; }
            public Gallon PaddingRightGallon { set; get; }

            [PropertyInfo(Name = "Đệm dưới")] public decimal? PaddingBottom { set; get; }
            public Gallon PaddingBottomGallon { set; get; }
            #endregion

            [PropertyInfo(Name = "Khổ giấy")] public PrinterConfig.PageSize PageSize { set; get; }
            [PropertyInfo(Name = "Tùy chỉnh")] public string PageSizeCustomer { set; get; }

            private IEnumerable<string> GetBodyStyleHelper()
            {
                if (MarginTop != null) yield return $"margin-top:{MarginTop}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(MarginTopGallon).Name}";
                if (MarginLeft != null) yield return $"margin-left:{MarginLeft}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(MarginLeftGallon).Name}";
                if (MarginRight != null) yield return $"margin-right:{MarginRight}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(MarginRightGallon).Name}";
                if (MarginBottom != null) yield return $"margin-bottom:{MarginBottom}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(MarginBottomGallon).Name}";

                if (PaddingTop != null) yield return $"padding-top:{PaddingTop}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(PaddingTopGallon).Name}";
                if (PaddingLeft != null) yield return $"padding-left:{PaddingLeft}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(PaddingLeftGallon).Name}";
                if (PaddingRight != null) yield return $"padding-right:{PaddingRight}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(PaddingRightGallon).Name}";
                if (PaddingBottom != null) yield return $"padding-bottom:{PaddingBottom}{EnumHelper<Gallon, FieldInfoAttribute>.Inst.GetAttribute(PaddingBottomGallon).Name}";

                var styles = GetStyles();
                foreach (var style in styles) yield return style;
            }
            public string GetBodyStyle() => GetBodyStyleHelper().JoinString(s => s, ";");

            private IEnumerable<string> GetPageStyleHelper()
            {
                var styles = GetBodyStyleHelper();
                foreach (var style in styles) yield return style;

                if(PageSize == PrinterConfig.PageSize.Customer)
                {
                    if (PageSizeCustomer.IsNotNull()) yield return $"size:{PageSizeCustomer}";
                }
                else
                {
                    yield return EnumHelper<PrinterConfig.PageSize, FieldInfoAttribute>.Inst.GetAttribute(PageSize).Name;
                }
            }
            public string GetPageStyle() => GetPageStyleHelper().JoinString(s => s, ";");

            protected virtual IEnumerable<string> GetStyles() => Enumerable.Empty<string>();
        }

        public interface ISetting
        {
            string GetPageStyle();
            string GetBodyStyle();
        }
        public enum Gallon : byte
        {
            [FieldInfo(Name = "px")] Px = 0,
            [FieldInfo(Name = "cm")] Cm = 1,
            [FieldInfo(Name = "mm")] Mm = 2
        }
    }
}