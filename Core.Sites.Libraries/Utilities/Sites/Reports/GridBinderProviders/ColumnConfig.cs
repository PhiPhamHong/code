using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using System.Linq;
using Core.Extensions;
using Core.Utility;
using Aspose.Cells;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    /// <summary>
    /// Thông tin config của cột
    /// </summary>
    public class ColumnConfig
    {
        public class ExtractValue { public virtual object GetValue(object dataItem, string field) { return dataItem.Eval(field); } }
        public class ExtractValuePair : ExtractValue { public override object GetValue(object dataItem, string field) { return (dataItem as Dictionary<string, object>)[field]; } }

        private Collection<ColumnConfig> columns = new Collection<ColumnConfig>();
        public Collection<ColumnConfig> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private ExtractValue extractProvider = Singleton<ExtractValue>.Inst;
        public ExtractValue ExtractProvider { set { extractProvider = value; } }

        public virtual HorizontalAlign HorizontalAlign { set; get; }
        public string Caption { set; get; }

        private bool visible = true;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public string FieldName { set; get; }

        private int width = 80;
        public int Width
        {
            get { return width; }
            set { if(value != 0) width = value; }
        }

        private int groupIndex = -1;
        public int GroupIndex
        {
            get { return groupIndex; }
            set { groupIndex = value; }
        }

        public string SummaryTitle { set; get; }
        public object GetValue(object dataItem) { return Format(extractProvider.GetValue(dataItem, FieldName)); }
        protected virtual object Format(object value) { return value; }
        public virtual void SetValueToCell(Cell cell, object value) { cell.PutValue(value); }

        public virtual void EditStyleLeft(Aspose.Cells.Style style) { ExcelBinderBase.EditStyleCellLeft(style); }
        public virtual void EditStyleRight(Aspose.Cells.Style style) { ExcelBinderBase.EditStyleCellRight(style); }
        public virtual void EditStyleDefault(Aspose.Cells.Style style) { ExcelBinderBase.EditStyleBase(style); }
        public virtual void EditStyleCenter(Aspose.Cells.Style style) { ExcelBinderBase.EditStyleBase(style); }
        public virtual void EditStyleSummary(Aspose.Cells.Style style) { ExcelBinderBase.EditStyleSummary(style); }

        /// <summary>
        /// Lấy ra thông tin cột
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<ColumnRange>> GetColumnRanges()
        {
            var rows = new Dictionary<int, List<ColumnRange>>();
            var dicStart = new Dictionary<int, int>();

            // Lấy những cột được hiển thị
            // var columnsVisibles = Columns.Where(c => c.Visible).ToList();
            var columnsVisibles = Columns.Where(c => CheckVisible(c)).ToList();

            for (var i = 0; i < columnsVisibles.Count; i++)
                DoGetColumns(rows, 1, columnsVisibles[i], dicStart);

            var dic = new Dictionary<string, List<ColumnRange>>();

            // Tìm rowspan cho từng cột
            if (rows.Count > 1)
            {
                var listRows = rows.ToList();
                for (var i = 0; i < listRows.Count - 1; i++)
                {
                    var row = listRows[i];
                    for (var j = i + 1; j < listRows.Count; j++)
                    {
                        var rowBelow = listRows[j];
                        for (var k = 0; k < row.Value.Count; k++)
                        {
                            var column = row.Value[k];
                            if (column.ColumnConfig.FieldName == "STT")
                            {
                                column.Row = rows.Count;
                                continue;
                            }

                            //if (!(rowBelow.Value.Count(rb => rb.From == column.From) > 0 && rowBelow.Value.Count(rb => rb.To == column.To) > 0))
                            //    column.Row++;

                            // => xem đoạn comment đánh dấu xxxxx
                            foreach (var columnBelow in rowBelow.Value)
                            {
                                if (column.From == columnBelow.From && column.To == columnBelow.To)
                                {
                                    var key = column.From + "_" + column.To;
                                    List<ColumnRange> list = null;
                                    if (!dic.ContainsKey(key)) dic[key] = list = new List<ColumnRange>();
                                    else list = dic[key];

                                    list.Add(column); list.Add(columnBelow);
                                    column.Right = columnBelow.Right = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //fix đoạn này, sau này thằng nào giỏi hơn thì vào sửa 
            foreach (var di in dic)
            {
                if (di.Value.Count(c => !string.IsNullOrEmpty(c.ColumnConfig.Caption)) == di.Value.Count)
                {
                    di.Value.ForEach(c => c.Right = true);
                }
                else
                {
                    var c0 = di.Value.First();
                    var c1 = di.Value.First(dt => !string.IsNullOrEmpty(dt.ColumnConfig.Caption));
                    c0.Right = true;
                    c0.ColumnConfig.Caption = c1.ColumnConfig.Caption;
                    c0.Row = rows.Count;
                    c0.ColumnConfig.Width = c1.ColumnConfig.Width;
                    c0.TotalMerge = c0.From;
                }
            }

            return rows;
        }

        private void DoGetColumns(Dictionary<int, List<ColumnRange>> dic, int row, ColumnConfig column, Dictionary<int, int> start)
        {
            List<ColumnRange> crs = null;
            if (!dic.ContainsKey(row)) dic[row] = crs = new List<ColumnRange>();
            else crs = dic[row];

            if (!start.ContainsKey(row)) start[row] = 1;

            var cr = new ColumnRange();
            cr.From = start[row];
            var totalColumns = FindColumn(column).Where(c => c.Visible);
            var countColumn = totalColumns.Count();

            if (countColumn > 1) cr.TotalMerge = start[row] + countColumn;
            else cr.TotalMerge = start[row] + countColumn;

            cr.Width = totalColumns.Sum(c => c.Width);
            if (cr.Width == 0) cr.Width = column.Width;
            cr.Row = 1;
            cr.ColumnConfig = column;
            crs.Add(cr);

            var beginRowAfter = start[row];

            // if (countColumn > 1) start[row] = cr.TotalMerge;
            if (countColumn >= 1) start[row] = cr.TotalMerge;
            else start[row] = cr.TotalMerge + 1;

            // Chỉ lấy những cột được hiển thị
            // var columnVisibles = column.Columns.Where(c => c.Visible).ToList();
            var columnVisibles = column.Columns.Where(c => CheckVisible(c)).ToList();

            for (int i = 0; i < columnVisibles.Count; i++)
            {
                if (!start.ContainsKey(row + 1)) start[row + 1] = beginRowAfter;
                DoGetColumns(dic, row + 1, columnVisibles[i], start);
            }
        }
        public IEnumerable<ColumnConfig> FindColumn(ColumnConfig column, bool first = true)
        {
            if (!first && column.Columns.Count == 0) yield return column;

            else
            {
                foreach (var c in column.Columns)
                {
                    var min = FindColumn(c, false);
                    foreach (var cm in min)
                        yield return cm;
                }
            }

            //var columns = column.Columns;
            //return columns.Concat(columns.SelectMany(ctrl => FindColumn(ctrl)));
        }

        private bool CheckVisible(ColumnConfig c)
        {
            if (c.Columns.Count > 0)
            {
                var total = 0;
                for (int i = 0; i < c.Columns.Count; i++)
                {
                    if (!CheckVisible(c.Columns[i])) total++;
                }

                if (total == c.columns.Count) return false;
            }

            return c.Visible;
        }
    }

    public class ColumnRange
    {
        public int From { set; get; }
        public int TotalMerge { set; get; }
        public int To
        {
            get
            {
                return TotalMerge == From ? From : TotalMerge - 1;
            }
        }
        public int Row { set; get; }
        public int Width { set; get; }

        public ColumnConfig ColumnConfig { set; get; }

        private bool right = true;
        public bool Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}