namespace Core.Sites.Apps.Web.Controls.DashBoards.BoxType
{
    public partial class BoxLarge : DashBoardBoxType
    {
        public string BoxClass { set; get; }

        private string buttonClass = "btn-box-tool";
        /// <summary>
        /// Button class
        /// </summary>
        public string ButtonClass
        {
            get { return buttonClass; }
            set { buttonClass = value; }
        }

        private bool withBorder = true;
        public bool WithBorder
        {
            get { return withBorder; }
            set { withBorder = value; }
        }
    }
}