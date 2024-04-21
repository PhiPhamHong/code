using System;
using System.Text;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web
{
    public partial class Pager
    {
        public class Number : Pager
        {
            private int number = 4;
            protected override string HandlerPage(int totalPage, string url)
            {
                var builder = new StringBuilder();
                builder.Append(BEGIN);

                if (PageIndex > 1) builder.Append(CreateLink(PageIndex - 1, "Previous", url, TypeLink.First, false));

                if (totalPage <= number)
                {
                    for (int i = 1; i <= totalPage; i++)
                        builder.Append(CreateLink(i, i, url));
                }
                else
                {
                    if (PageIndex == 1)
                    {
                        for (int i = 1; i <= number - 1; i++) builder.Append(CreateLink(i, i, url));
                        builder.Append(CreateLink(totalPage - 1, "...", url));
                        builder.Append(CreateLink(totalPage, totalPage, url));
                    }

                    else if (PageIndex > 1 && PageIndex < totalPage)
                    {
                        // biên độ
                        int anpha = (int)Math.Ceiling((decimal)(number - 3) / 2);

                        if (PageIndex > anpha + 1)
                        {
                            if (PageIndex != 2) builder.Append(CreateLink(1, 1, url));
                            if (PageIndex > 2) builder.Append(CreateLink(2, "...", url));

                            for (int i = PageIndex - anpha; i <= PageIndex + anpha; i++)
                                if (i < totalPage)
                                    builder.Append(CreateLink(i, i, url));
                        }
                        else
                        {
                            for (int i = 1; i <= number - 1; i++)
                                builder.Append(CreateLink(i, i, url));
                        }

                        if (PageIndex <= totalPage - 2)
                        {
                            builder.Append(CreateLink(PageIndex + 2, "...", url));
                            builder.Append(CreateLink(totalPage, totalPage, url));
                        }

                        if (PageIndex == totalPage - 1) builder.Append(CreateLink(totalPage, totalPage, url));

                    }

                    else if (PageIndex == totalPage)
                    {
                        builder.Append(CreateLink(1, 1, url));
                        builder.Append(CreateLink(2, "...", url));
                        for (int i = totalPage - number + 2; i <= totalPage; i++)
                            builder.Append(CreateLink(i, i, url));
                    }
                }

                if (PageIndex < totalPage) builder.Append(CreateLink(PageIndex + 1, "Next", url, TypeLink.Last, false));

                builder.Append(END);
                return builder.ToString();
            }
            private string CreateLink(int page, object text, string href, TypeLink link = TypeLink.Between, bool checkcurrent = true)
            {
                switch (link)
                {
                    case TypeLink.First: return PREVIOUS.Frmat(href.Replace("{page}", page.ToString()));
                    case TypeLink.Last: return NEXT.Frmat(href.Replace("{page}", page.ToString()));
                    default:
                        if (page == PageIndex && checkcurrent) return CURRENT.Frmat(page);
                        else return LINK.Frmat(page, href.Replace("{page}", page.ToString()));
                }
            }

            protected virtual string PREVIOUS
            {
                get { return "<li><a class=\"next i-previous\" href=\"{0}\" title=\"Previous\"><span>«</span></a> </li>"; }
            }
            protected virtual string NEXT
            {
                get { return "<li><a class=\"next i-next\" href=\"{0}\" title=\"Next\"><span>»</span></a></li>"; }
            }
            protected virtual string CURRENT
            {
                get { return "<li class=\"current\">{0}</li>"; }
            }
            protected virtual string LINK
            {
                get { return "<li><a href=\"{1}\">{0}</a></li>"; }
            }
            protected virtual string BEGIN
            {
                get { return "<div class=\"toolbar\"><div class=\"toolbar-inner\" style=\"padding: 5px 10px 5px;\"><div class=\"sortby-limiter\"><div class=\"pager\"><div class=\"pages\"><ol>"; }
            }
            protected virtual string END
            {
                get { return "</ol></div></div></div></div></div>"; }
            }
        }
    }
}
