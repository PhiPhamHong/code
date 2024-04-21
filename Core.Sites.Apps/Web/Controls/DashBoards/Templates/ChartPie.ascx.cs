
namespace Core.Sites.Apps.Web.Controls.DashBoards.Templates
{
    public partial class ChartPie : DashBoardTemplateBase
    {
        public string Title { set; get; }
        public string Title2 { set; get; }

        public bool UseProgressBar { set; get; } = true;
        public bool ShowTotal { set; get; } = true;
    }
}