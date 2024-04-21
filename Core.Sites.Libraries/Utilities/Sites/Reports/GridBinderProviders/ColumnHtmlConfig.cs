using System;
using Aspose.Cells;
namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class ColumnHtmlConfig : ColumnConfig
    {
        public override void SetValueToCell(Cell cell, object value)
        {
            cell.HtmlString = Convert.ToString(value);
        }
    }
}
