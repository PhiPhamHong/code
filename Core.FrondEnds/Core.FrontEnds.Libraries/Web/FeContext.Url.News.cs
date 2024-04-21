using Core.Business.Entities.Websites;

namespace Core.FrontEnds.Libraries.Web
{
    public partial class FeContext
    {
        public partial class UrlContext
        {
            private NewsContext news = null;
            public NewsContext News
            {
                get
                {
                    if (news == null) news = new NewsContext();
                    return news;
                }
            }

            public class NewsContext
            {
                public int NewsId { set; get; }
                public string Alias { set; get; }
                public News.Fe Entity { set; get; }
            }
        }
    }
}
