using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
using Core.Extensions;
using System.Reflection;
using System.Web.UI;
using System.Linq;
using Core.Attributes;
using Core.Web.WebBase.HtmlBuilders;

namespace Core.Sites.Apps.Web.Controls.Prints
{
    [Script(Src = "/Web/Controls/Prints/js/PrinterConfig.js", Index = -1)]
    public partial class PrinterConfig : Printer
    {
        protected override bool IsConfig => true;
        protected override Control GetControl() => plcConfig;

        public void SaveConfig()
        {
            var modulePrintName = this.Query("ModulePrint");
            var modulePrintPathItem = PortalContext.PathImageForMenuConfig.FirstOrDefault(pi => pi.Name == modulePrintName);
            var propertySetting = modulePrintPathItem.Type.GetProperty("Setting", BindingFlags.Instance | BindingFlags.NonPublic);
            var setting = propertySetting.PropertyType.CreateInstance();

            this.ParseParamTo(setting, true);

            var userPrintConfig = PortalContext.CurrentUser.GetConfig(modulePrintName);
            userPrintConfig.Config = setting.ToJson2();
            userPrintConfig.Upsert();
        }

        public enum PageSize : byte
        {
            [FieldInfo(Name = "Tùy chỉnh")] Customer = 0,
            [FieldInfo(Name = "A3")] A3 = 1,
            [FieldInfo(Name = "A4")] A4 = 2,
            [FieldInfo(Name = "A5")] A5 = 3,
            [FieldInfo(Name = "Auto")] Auto = 4,
            [FieldInfo(Name = "B4")] B4 = 5,
            [FieldInfo(Name = "B5")] B5 = 6,
            [FieldInfo(Name = "Landscape")] Landscape = 7,
            [FieldInfo(Name = "Ledger")] Ledger = 8,
            [FieldInfo(Name = "Legal")] Legal = 9,
            [FieldInfo(Name = "Letter")] Letter = 10,
            [FieldInfo(Name = "Portrait")] Portrait = 11
        }

        public class PageSizeInput : SelectEnum<PageSize, PageSizeInput> { }
    }
}