using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Aspose.Cells;
using Core.Extensions;
using Core.Sites.Libraries.Utilities.Sites.Reports.Extensions;
using Core.Sites.Libraries.Business;
using System.Drawing;
namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public partial class GridBinder
    {
        private List<ReportColumnInfoAttribute> listReportColumnInfo = null;
        /// <summary>
        /// Danh sách các thông tin về cột của báo cáo
        /// </summary>
        public List<ReportColumnInfoAttribute> ListReportColumnInfo
        {
            get
            {
                if (listReportColumnInfo == null)
                {
                    if (Target != null)
                        listReportColumnInfo = Target.GetListReportColumnInfo();
                    if (listReportColumnInfo == null) listReportColumnInfo = new List<ReportColumnInfoAttribute>();
                }
                return listReportColumnInfo;
            }
            set { listReportColumnInfo = value; }
        }

        private ColumnConfig columnConfig = null;
        /// <summary>
        /// Thực hiện lấy thông tin về các cột trong grid
        /// Đang chờ viết
        /// </summary>
        public ColumnConfig ColumnConfig
        {
            get
            {
                if (columnConfig == null)
                {
                    columnConfig = Target.As<IFormGridTarget>().ColumnConfig;
                    if (Target.GetReportInfo() != null && Target.GetReportInfo().AutoAscending)
                    {
                        columnConfig.Columns.Insert(0, new ColumnConfig { Caption = "STT", FieldName = "STT", Width = 40 });
                    }
                }
                return columnConfig;
            }
        }

        private List<ColumnConfig> allColumns = null;
        /// <summary>
        /// Tất cả các cột cần bind
        /// </summary>
        public List<ColumnConfig> AllColumns
        {
            get
            {
                if (allColumns == null)
                    allColumns = ColumnConfig.FindColumn(columnConfig).ToList();
                return allColumns;
            }
        }

        protected int BindHeader(Worksheet sheet, int start)
        {
            if (Target.Excel_CreateHeader != null && Target.Excel_CreateHeader.Value == false) return start;

            // Thông số config cho header
            var configHeader = ColumnConfig.GetColumnRanges();

            // Row bắt đầu fill dữ liệu
            var rowStart = start;

            // Lưu trữ row và column hiện thời đang fill dữ liệu
            int row = 0, column = 0;

            // Khởi tạo Header
            foreach (var rowConfig in configHeader)
            {
                var cells = rowConfig.Value.Where(c => c.Right).ToList();

                for (int i = 0; i < cells.Count; i++)
                {
                    var cellConfig = cells[i];

                    row = rowStart + rowConfig.Key;
                    column = cellConfig.From + CellStart;

                    // Thiết lập tiêu đề cho cột
                    sheet.Cells[row, column].PutValue(PortalContext.GetLabel(cellConfig.ColumnConfig.Caption).Replace("<br />","\n"));
                    sheet.Cells[row, column].EditStyle(EditStyleHeader);

                    // Thực hiện merge cột
                    // if (cellConfig.Row != 1 || cellConfig.To - cellConfig.From != 0)
                    if (cellConfig.Row != 0 && cellConfig.TotalMerge - cellConfig.From != 0)
                    {
                        for (var z = 0; z < cellConfig.TotalMerge - cellConfig.From; z++)
                            sheet.Cells[row, column + z].EditStyle(EditStyleHeader);
                        try
                        {
                            sheet.Cells.Merge(row, column, cellConfig.Row, cellConfig.TotalMerge - cellConfig.From);
                        }
                        catch { }
                    }

                    // Merge row
                    if (cellConfig.Row > 1)
                    {
                        for (var z = 0; z < cellConfig.Row; z++)
                            sheet.Cells[row + z, column].EditStyle(EditStyleHeader);
                        try
                        {
                            sheet.Cells.Merge(row, column, cellConfig.Row, 1);
                            sheet.Cells.CreateRange(row, column, cellConfig.Row, 1).Value = PortalContext.GetLabel(cellConfig.ColumnConfig.Caption);
                        }
                        catch { }
                    }

                    // Thiết lập độ rộng cho cột
                    if (cellConfig.From == cellConfig.TotalMerge) sheet.Cells.SetColumnWidthPixel(column, cellConfig.Width);
                }
            }

            rowStart += configHeader.Max(d => d.Key) + 1;

            // 
            return rowStart;
        }
        protected int BindContent(Worksheet sheet, object data, object summary, int rowStart)
        {
            #region Điền dữ liệu Data
            var list = data.CastToList(); if (list == null) list = new List<object>();

            // Khởi tạo dic lưu các cell cần thực hiện RowSpan
            var cellRowSpans = ListReportColumnInfo.Where(rc => rc.CellSpan == CellSpan.Row).ToDictionary(rc => rc.Column, rc => new CellValue { Value = null });

            // Lưu trữ row và column hiện thời đang fill dữ liệu
            int row = 0, column = 0;

            // Lấy các cột được hiển thị thôi
            var columnVisibles = AllColumns.Where(c => c.Visible).ToList();

            for (var i = 0; i < list.Count; i++)
            {
                if (i > 0)
                    sheet.Cells.InsertRows(rowStart, 1, false);

                var dataItem = list[i];
                row = rowStart;

                column = CellStart + 1;

                foreach (var cellConfig in columnVisibles)
                {
                    var value = cellConfig.FieldName.Equals("STT") ? (i + 1) : cellConfig.GetValue(dataItem);
                    var cell = sheet.Cells[row, column];

                    // Điền dữ liệu lên cell
                    cellConfig.SetValueToCell(cell, value);

                    //// Căn cột
                    switch (cellConfig.HorizontalAlign)
                    {
                        case HorizontalAlign.Center: cell.EditStyle(cellConfig.EditStyleCenter); break;
                        case HorizontalAlign.Right: cell.EditStyle(cellConfig.EditStyleRight); break;
                        case HorizontalAlign.Left: cell.EditStyle(cellConfig.EditStyleLeft); break;
                        default: cell.EditStyle(cellConfig.EditStyleDefault); break;
                    }

                    // Tìm cell rowspan
                    if (cellRowSpans.ContainsKey(cellConfig.FieldName))
                    {
                        var cellValue = cellRowSpans[cellConfig.FieldName];
                        if (cellValue.RowStart == 0)
                        {
                            cellValue.Value = value;
                            cellValue.RowStart = row;
                        }
                        else
                        {
                            // Nếu thay đổi giá trị thì bắt đầu thiết lập rowspan
                            if (!cellValue.Value.Equals(value))
                            {
                                cellValue.RowStart = row;
                                cellValue.Value = value;
                            }
                            else sheet.Cells.Merge(cellValue.RowStart, column, row - cellValue.RowStart + 1, 1);
                        }
                    }

                    column++;
                }

                rowStart++;

            }
            #endregion

            if (Target.Excel_BindSummary == null || Target.Excel_BindSummary.Value)
            {
                #region Điều dữ liệu Thống kê
                // Nếu có Summary
                if (summary == null) return rowStart;
                var dataSummary = summary.CastToList();
                if (dataSummary == null) return rowStart;

                for (var i = 0; i < dataSummary.Count; i++)
                {
                    var dataItem = dataSummary[i];
                    row = rowStart;
                    column = CellStart + 1;

                    foreach (var cellConfig in columnVisibles)
                    {
                        var value = cellConfig.FieldName.Equals("STT") ? string.Empty : (cellConfig.SummaryTitle.IsNotNull() ? dataItem.Eval(cellConfig.SummaryTitle) : cellConfig.GetValue(dataItem));
                        // Điền dữ liệu lên cell
                        sheet.Cells[row, column].PutValue(value);

                        if (Target.Excel_UseStyleTemplate == null || !Target.Excel_UseStyleTemplate.Value)
                        {
                            sheet.Cells[row, column].EditStyle(cellConfig.EditStyleSummary);
                            sheet.Cells[row, column].SetBold();
                        }
                        column++;
                    }

                    rowStart++;
                }
                #endregion
            }

            // Trả về Row cuối cùng
            return rowStart;
        }
    }
}