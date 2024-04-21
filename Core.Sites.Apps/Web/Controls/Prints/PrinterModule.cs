using Core.Sites.Libraries.Utilities.Sites;
using Core.Extensions;
using Newtonsoft.Json;
using Core.Sites.Libraries.Business;
using System.Web.UI;
using System.Text;
using System.IO;

namespace Core.Sites.Apps.Web.Controls.Prints
{
    [Module]
    public abstract class PrinterModule<TSetting> : PortalModule, IPrinterModule, IPdfModule where TSetting : Printer.Setting, new()
    {
        public PrinterModule() => UseModuleTypeAction = false;

        protected TSetting Setting { set; get; }
        Printer.ISetting IPrinterModule.Setting => Setting;

        public void AfterLoadModule()
        {
            LoadSetting();
        }

        sealed protected override void OnInitData()
        {
            LoadSetting();
            OnInitPrint();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            var strBuilder = new StringBuilder();
            using (var strWriter = new StringWriter(strBuilder))
            {
                using (var htmlWriter = new HtmlTextWriter(strWriter))
                {
                    base.Render(htmlWriter);
                }
            }

            var html = strBuilder.ToString();
            var styleBuilder = new StringBuilder();
            styleBuilder.Append("<style>");
            styleBuilder.Append("@page{ " + Setting.GetPageStyle() + " }");
            styleBuilder.Append("@media print { html, body { " + Setting.GetBodyStyle() + " }}");
            styleBuilder.Append("</style>");

            writer.Write($"{styleBuilder.ToString()}{html}");
        }

        private void LoadSetting()
        {
            var module = GetType().BaseType.Name;
            var userPrintConfig = PortalContext.CurrentUser.GetConfig(module);
            if (userPrintConfig.Config.IsNull()) Setting = new TSetting { };
            else
            {
                try { Setting = JsonConvert.DeserializeObject<TSetting>(userPrintConfig.Config); }
                catch { Setting = new TSetting { }; }
            }
        }

        protected abstract void OnInitPrint();

        [Module]
        public class FormConfig : PortalModule<TSetting>
        {
            protected TSetting Setting
            {
                set { Entity = value; }
                get { return Entity; }
            }
        }
    }

    /// <summary>
    /// Dùng cho các module in không cần mở rộng tham số cấu hình => Dùng cấu hình mặc định luôn có
    /// </summary>
    public class PrinterModule : PrinterModule<Printer.Setting>
    {
        protected override void OnInitPrint()
        {
            
        }
    }
    public interface IPdfModule
    {
        void AfterLoadModule();
    }
}