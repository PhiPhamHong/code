using Core.Web.Extensions;
using System.Web.UI.WebControls;

namespace Core.Sites.Apps.Web.Controls.MenuGroupHome
{
    public partial class MenuGroupHomeMainItemListLabel : MenuGroupHomeMainItemBase
    {
        bool ok = false;
        public override void InitData()
        {
            rpLabels.DoBind(MenuItem.LabelTexts);
            rpLabels.Visible = ok;
        }

        protected void rpLabels_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            ok = true;
        }
    }
}