using Aspose.Cells;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public partial class GridBinder : ExcelBinderBase
    {
        public override int Bind(Worksheet sheet, object data, object summary)
        {
            // Tạo Header
            var rowStart = BindHeader(sheet, RowBegin);

            // Bind nội dung
            return BindContent(sheet, data, summary, rowStart);
        }

        private class CellValue
        {
            private object value = null;
            public object Value
            {
                get { return value; }
                set { this.value = value ?? string.Empty; }
            }

            public int RowStart { set; get; }
        }
    }
}
