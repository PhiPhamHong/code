using Core.Business.Entities.Websites;
using Core.Extensions;
using Core.Utility.Spiders;

namespace Core.FrontEnds.Libraries.Extensions
{
    public static class NewExtension
    {
        public static News.Fe FormatContent(this News.Fe news)
        {
            if (news == null || news.NewsId == 0) return null;
            var spider = new Spider { Html = news.NewsContent };
            spider.SelectList("img").ForEach(img =>
            {
                var srcAttr = img.Attributes["src"];
                if (srcAttr == null) return;
                var src = srcAttr.Value;
                if (src.IsNull()) return;
                if (src.StartsWith("http")) return;
                srcAttr.Value = Setting.ServerImage + src;
            });
            news.NewsContent = spider.Html;
            return news;
        }
    }
}
