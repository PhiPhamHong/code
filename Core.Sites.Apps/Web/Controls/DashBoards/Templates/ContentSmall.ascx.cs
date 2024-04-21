namespace Core.Sites.Apps.Web.Controls.DashBoards.Templates
{
    public partial class ContentSmall : DashBoardTemplateBase
    {
        public string Icon1 { set; get; }
        public string Icon2 { set; get; }
        public string Icon3 { set; get; }

        private bool useLinkModule = true;
        public bool UseLinkModule
        {
            get { return useLinkModule; }
            set { useLinkModule = value; }
        }
    }
}