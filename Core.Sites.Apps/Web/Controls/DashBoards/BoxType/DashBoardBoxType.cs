using System.Linq;

using Core.Web.WebBase;
using Core.Web.Extensions;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Utilities;
using Core.Sites.Libraries.Business;
namespace Core.Sites.Apps.Web.Controls.DashBoards.BoxType
{
    public class DashBoardBoxType : ControlBase
    {
        public DashBoardItem DashBoardItem { set; get; }
        public CacheUrl.CacheUrlData UrlData { set; get; }
    }

    public enum DbBoxType
    {
        Unknown = 0,
        Small1 = 1,
        Small2 = 2,
        Small3 = 3,
        Large1 = 10
    }

    public class DashBoardBoxTypeExtend : DashBoardBoxType
    {
        public override void InitData()
        {
            var box = this.FindAllChildrenByType<DashBoardBoxType>().FirstOrDefault();
            box.DashBoardItem = DashBoardItem;
            box.UrlData = UrlData;
        }
    }
}