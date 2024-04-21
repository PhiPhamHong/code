using Core.Web.Extensions;
namespace Core.Sites.Apps.Web.Controls
{
    public partial class MenuLeftGroupItem : MenuLeftItemBase
    {
        public override void InitData()
        {
            rpItem.DoBind(GroupMenu.MenuItems);
        }
    }
}