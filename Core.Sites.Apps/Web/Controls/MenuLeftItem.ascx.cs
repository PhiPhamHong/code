using System.Linq;
using Core.Sites.Libraries.Business;
namespace Core.Sites.Apps.Web.Controls
{
    /// <summary>
    /// Nếu một Group chỉ có 1 item thì lấy Item đó làm menu của cả group luôn
    /// </summary>
    public partial class MenuLeftItem : MenuLeftItemBase
    {
        /// <summary>
        /// MenuItem duy nhất của Group
        /// </summary>
        protected MenuItem MenuItem { set; get; }

        /// <summary>
        /// Khởi tạo dữ liệu
        /// </summary>
        public override void InitData()
        {
            MenuItem = GroupMenu.MenuItems.FirstOrDefault();
        }
    }
}