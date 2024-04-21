using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Controls.MenuGroupHome
{
    public partial class MenuGroupHomeMainItem : MenuGroupHomeMainItemBase
    {
        public override void InitData()
        {
            if (MenuItem.LabelText.IsNull() && MenuItem.LabelTexts.IsNull()) return;

            //var label = MenuItem.LabelText.IsNull() ? (MenuGroupHomeMainItemBase)Control<MenuGroupHomeMainItemListLabel>.Create() : Control<MenuGroupHomeMainItemLabel>.Create();
            //label.MenuItem = MenuItem;
            //label.InitData();

            MenuGroupHomeMainItemBase label = null;

            if (MenuItem.LabelText.IsNotNull()) label = Control<MenuGroupHomeMainItemLabel>.Create();
            else if (MenuItem.LabelTexts != null) label = Control<MenuGroupHomeMainItemListLabel>.Create();

            if (label == null) return;

            label.MenuItem = MenuItem;
            label.InitData();
            plc.Controls.Add(label);
        }
    }

    public class MenuGroupHomeMainItemBase : ControlBase
    {
        public MenuItem MenuItem { set; get; }
    }
}