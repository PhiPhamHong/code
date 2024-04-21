using Core.FrontEnds.Libraries.Web;
using System.Web.UI;

namespace Core.FrontEnds.Sites.MainPage.Projects.Blogspots.Video_Streaming
{
    public partial class Video_Streaming_Main : PageSite
    {
        protected override Control Container
        {
            get { return plcContainer; }
        }
    }
}