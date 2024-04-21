using Aspose.Cells;
namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class ColumnMoneyConfig : ColumnConfig
    {
        public override System.Web.UI.WebControls.HorizontalAlign HorizontalAlign
        {
            get { return System.Web.UI.WebControls.HorizontalAlign.Right; }
            set { base.HorizontalAlign = value; }
        }
        public override void EditStyleSummary(Style style)
        {
            EditSummary(style);
        }
        public override void EditStyleRight(Style style)
        {
            EditRight(style);
        }
        public static void EditRight(Style style)
        {
            ExcelBinderBase.EditStyleCellRight(style);
            style.Number = 4;
        }
        public static void EditSummary(Style style)
        {
            ExcelBinderBase.EditStyleSummary(style);
            style.Number = 4;
        }
    }
}