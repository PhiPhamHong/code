using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using Aspose.Cells;

using Core.Extensions;
using Core.Utility;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders;
using Core.Business.Entities;
using System.IO;

namespace Core.Sites.Libraries.Utilities.Sites.Reports
{
    public class ReportCenter
    {
        public IFormTarget Target { set; get; }

        public AppSetting.ReportExcelConfig Config
        {
            get { return config; }
            set { config = value; }
        }
        private AppSetting.ReportExcelConfig config = AppSetting.ReportExcel;

        public Pair<Workbook, string, int> Export(object data, object summary)
        {
            // Tiêu đề báo cáo và thông số để lấy ra dữ liệu của báo cáo
            // reportInfo == null ? "Chưa có tiêu đề" : reportInfo.Title;
            var title = Target.Excel_GetTitle();
            var subtitle = Target.Excel_GetSubtitle();

            if (title.IsNull()) title = "Chưa có tiêu đề";

            var fileName = (title + "." + subtitle).UnicodeFormat();
            if (fileName.Length > 100) fileName = fileName.Substring(0, 99);

            var workbook = CreateWorkbook();

            return new Pair<Workbook, string, int> { T1 = workbook, T2 = fileName, T3 = FillSheet(title, subtitle, data, summary, workbook.Worksheets[0]) };
        }
        public event Action<ExcelBinderBase, Worksheet, ReportCenter> BeforeFill;
        public event Action<Worksheet, int, ISheetItem> AfterFillSheet = null;
        public Workbook Export<TSheetItem>(List<TSheetItem> sheets) where TSheetItem : ISheetItem
        {
            var workbook = CreateWorkbook();

            // Copy các Sheet sau giống như Sheet đầu tiên
            while (sheets.Count > workbook.Worksheets.Count)
            {
                workbook.Worksheets.Add();
            }

            for (var i = 1; i < sheets.Count; i++)
            {
                workbook.Worksheets[i].Copy(workbook.Worksheets[0]);
            }

            // Điền dữ liệu từng Sheet
            sheets.Select((sheetItem, i) =>
            {
                var sheet = workbook.Worksheets[i];
                sheet.Name =  "Excel Order"; //sheetItem.Title;
                var lastRow = FillSheet(sheetItem.Title, sheetItem.SubTitle, sheetItem.Data, sheetItem.Summary, sheet);
                if (AfterFillSheet != null) AfterFillSheet(sheet, lastRow, sheetItem);
                sheet.AutoFitColumns();
                sheet.AutoFitRows();
                return lastRow;
            }).Count();

            workbook.Worksheets.ActiveSheetIndex = 0;
            return workbook;
        }
        protected int FillSheet(string title, string subTitle, object data, object summary, Worksheet sheet)
        {
            var StartRow = Target.Excel_StartRow; if (StartRow == null) StartRow = Config.StartRow;

            if (Target.Excel_FillTitle == null || Target.Excel_FillTitle.Value)
            {
                var Y_Title = Target.Excel_Y_Title; if (Y_Title == null) Y_Title = Config.Y_Title;
                var X_Title = Target.Excel_X_Title; if (X_Title == null) X_Title = Config.X_Title;
                var Y_SubTitle = Target.Excel_Y_SubTitle; if (Y_SubTitle == null) Y_SubTitle = Config.Y_SubTitle;
                var X_SubTitle = Target.Excel_X_SubTitle; if (X_SubTitle == null) X_SubTitle = Config.X_SubTitle;
                sheet.Cells[Y_Title.Value, X_Title.Value].PutValue(title);
                sheet.Cells[Y_SubTitle.Value, X_SubTitle.Value].PutValue(subTitle);
            }
            return FillSheet(sheet, data, summary, StartRow);
        }
        public int FillSheet(Worksheet sheet, object data, object summary, int? startRow = null)
        {
            ExcelBinderBase binder = null;

            if (Target == null || Target.GetReportInfo() == null) binder = new GridBinder();
            else
                switch (Target.GetReportInfo().BinderType)
                {
                    case ExcelBinderType.Grid: binder = new GridBinder(); break;
                }

            if (binder == null) return 0;

            // Ở đây thông số chung nhất cho các binder là Target => đang thực hiện binder trên form nào
            binder.Target = Target;

            // if (BeforeFill != null) BeforeFill(binder, sheet);
            if (startRow != null) binder.RowBegin = startRow.Value;
            if (BeforeFill != null) BeforeFill(binder, sheet, this);
            return binder.Bind(sheet, data, summary);
        }
        protected int FillSheetByList<T>(Worksheet sheet, List<T> data, List<T> summary, int? startRow = null) { return FillSheet(sheet, data, summary, startRow); }

        private const string FileDefault = "~/Web/Resources/ExcelTemplates/Report.xls";

        private Workbook CreateWorkbook()
        {
            //Longtq sửa lại chỗ này lấy template excel theo công ty
            var fileTemplate = Target.Excel_FileTemplate;
            if (fileTemplate.IsNull())
                fileTemplate = string.IsNullOrEmpty(PortalContext.Config.TemplateExcel) ? FileDefault : PortalContext.Config.TemplateExcel;            

            var map = HttpContext.Current.Server.MapPath(fileTemplate);
            if (!File.Exists(map))
                map = HttpContext.Current.Server.MapPath(FileDefault);

            //var loadOptions = new HTMLLoadOptions(LoadFormat.Excel97To2003) { SupportDivTag = true };
            //return new Workbook(HttpContext.Current.Server.MapPath(fileTemplate), loadOptions);
            return new Workbook(map);
        }
        public interface ISheetItem
        {
            string Title { get; }
            string SubTitle { get; }
            object Data { get; }
            object Summary { get; }
        }
        public class SheetItem : ISheetItem
        {
            public string Title { set; get; }
            public string SubTitle { set; get; }
            public object Data { set; get; }
            public object Summary { set; get; }
        }
    }
}