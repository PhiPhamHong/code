using System.Drawing;
using Aspose.Cells;
namespace Core.Sites.Libraries.Utilities.Sites.Reports
{
    /// <summary>
    /// Cung cấp phương thức Binder
    /// </summary>
    public abstract class ExcelBinderBase
    {
        public IFormTarget Target { set; get; }

        private int rowBegin = 10;
        /// <summary>
        /// Thiết lập Row bắt đầu thực hiện bind dữ liệu
        /// Mặc định là bắt đầu từ Row thứ 7
        /// </summary>
        public int RowBegin
        {
            get { return rowBegin; }
            set { rowBegin = value; }
        }

        private int cellStart = -1;
        /// <summary>
        /// Vị trí cell bắt đầu fill
        /// </summary>
        public int CellStart
        {
            get { return cellStart; }
            set { cellStart = value; }
        }

        public abstract int Bind(Worksheet sheet, object data, object summary);
        public static void EditStyleSummary(Aspose.Cells.Style style)
        {
            EditStyleBase(style);
            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = Color.FromArgb(191, 191, 191);
            style.HorizontalAlignment = TextAlignmentType.Right;
            style.Font.IsBold = true;
        }
        public static void EditStyleCellRight(Aspose.Cells.Style style)
        {
            EditStyleBase(style);
            style.HorizontalAlignment = TextAlignmentType.Right;
        }
        public static void EditStyleCellLeft(Aspose.Cells.Style style)
        {
            EditStyleBase(style);
            style.HorizontalAlignment = TextAlignmentType.Left;
        }
        public static void EditStyleHeader(Aspose.Cells.Style style)
        {
            EditStyleBase(style);

            style.Pattern = BackgroundType.Solid;
            style.ForegroundColor = Color.FromArgb(191, 191, 191);
            style.Font.IsBold = true;
        }
        public static void EditStyleBase(Aspose.Cells.Style style)
        {
            style.SetBorder(BorderType.BottomBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.RightBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.LeftBorder, CellBorderType.Thin, Color.Black);
            style.SetBorder(BorderType.TopBorder, CellBorderType.Thin, Color.Black);
            style.IsTextWrapped = false;
            //style.ShrinkToFit = true;
            style.HorizontalAlignment = TextAlignmentType.Center;
        }
    }
}
