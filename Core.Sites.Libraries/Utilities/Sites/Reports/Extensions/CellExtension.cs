using System;
using Aspose.Cells;
namespace Core.Sites.Libraries.Utilities.Sites.Reports.Extensions
{
    public static class CellExtension
    {
        public static Cell SetBold(this Cell cell)
        {
            return cell.EditStyle(style => style.Font.IsBold = true);
        }
        public static Cell SetMoney(this Cell cell)
        {
            return cell.EditStyle(style => style.Number = 4);
        }
        public static Cell EditStyle(this Cell cell, Action<Style> edit)
        {
            var style = cell.GetStyle();
            edit(style);
            cell.SetStyle(style);
            return cell;
        }
        public static Cell PutValue(this Worksheet sheet, object value, int firstRow, int firstColumn, int totalRows = 0, int totalColumns = 0)
        {
            if(totalRows != 0 || totalColumns != 0)
            {
                sheet.Cells.Merge(firstRow, firstColumn, totalRows, totalColumns);
                sheet.Cells.CreateRange(firstRow, firstColumn, totalRows, totalColumns);
            }

            var cell = sheet.Cells[firstRow, firstColumn];
            cell.PutValue(value);
            return cell;
        }
        public static void EditStyleRange(this Worksheet sheet, int firstRow, int firstColumn, int totalRows, int totalColumns, Action<Style> edit)
        {
            for(var row = firstRow; row < totalRows + firstRow; row++)
                for(var column = firstColumn; column < totalColumns + firstColumn; column++)
                {
                    sheet.Cells[row, column].EditStyle(edit);
                }
        }
    }
}
