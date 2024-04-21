using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Core.Extensions;

namespace Core.Forms
{
    public class ShDataGridView : DataGridView
    {
        public ShDataGridView()
        {
            this.CellFormatting += dgData_CellFormatting;
        }

        private void dgData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var propertyName = this.Columns[e.ColumnIndex].DataPropertyName;
            if (propertyName.Contains("."))
                e.Value = this.Rows[e.RowIndex].DataBoundItem.Eval(propertyName);
        }

        public List<T> GetSelectedRows<T>()
        {
            return this.SelectedRows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem.As<T>()).ToList();
        }
    }
}
