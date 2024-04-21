using Core.Sites.Apps.Web.Controls.DashBoards.BoxType;
using Core.Sites.Libraries.Business;
using Core.Utility;
namespace Core.Sites.Apps.Web.Controls.DashBoards.Extensions
{
    public static class DashBoardItemExtension
    {
        public static DbBoxType DbBoxType(this DashBoardItem dbi)
        {
            return EnumHelper<BoxTypeInput.BoxType, BoxTypeInput.BoxTypeInfoAttribute>.Inst.GetAttribute((BoxTypeInput.BoxType)dbi.TypeBox).DbBoxType;
        }
    }
}