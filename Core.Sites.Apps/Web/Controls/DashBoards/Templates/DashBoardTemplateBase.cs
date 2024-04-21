using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
namespace Core.Sites.Apps.Web.Controls.DashBoards.Templates
{
    public class DashBoardTemplateBase : ControlBase
    {
        public IDashBoard DashBoard { private set; get; }

        sealed public override void InitData()
        {
            DashBoard = (this.Parent as IDashBoardModule).DashBoard;
            LoadTemplate();
        }

        protected virtual void LoadTemplate() { }
    }
}