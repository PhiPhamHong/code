using System;
using System.Windows.Forms;
using Core.Utility.Xml;
namespace Core.Forms
{
    public partial class FrmConfigContana : Form
    {        
        private void FrmConfigContana_Load(object sender, EventArgs e)
        {
            ThatLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSave();
            this.DialogResult = DialogResult.OK;
        }

        protected virtual void ThatLoad()
        {
            this.FillValues(ReadConfig<Setting>.Load(), false);
        }

        protected virtual void OnSave()
        {
            ReadConfig<Setting>.Save(this.ParseTo<Setting>());
        }
    }
}