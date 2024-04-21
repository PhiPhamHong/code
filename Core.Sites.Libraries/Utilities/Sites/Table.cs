using Core.Web.WebBase.HtmlBuilders;
using Core.Extensions;
using Core.Sites.Libraries.Business;

namespace Core.Sites.Libraries.Utilities.Sites
{
    public class Table<T> : Table<T, Table<T>>
    {
        protected bool dashBoard = false;
        protected string urlDashBoard = string.Empty;
        public Table<T> DashBoard(bool dashBoard = true, string urlDashBoard = "")
        {
            return Chain(t => { t.dashBoard = dashBoard; t.urlDashBoard = urlDashBoard; });
        }

        public override bool HasPermission(params int[] permission)
        {
            return PortalContext.HasPermission(permission);
        }

        public override string ToString()
        {
            if (dashBoard)
            {
                var bar = new BarButton { Table = this };
                bar.Icon("fas fa-tachometer-alt");
                bar.Text("Bảng tin");
                bar.Keydown(Utility.Key.f2);
                bar.CssBg("bg-purple");
                bar.Data("module-url", urlDashBoard.IsNull() ? PortalContext.CurrentPage.UrlData.MenuItem.UrlVirtual : urlDashBoard);
                bar.Func("ShowConfigDashBoard");
                bars.Add(bar);
            }

            return base.ToString();
        }
    }
}
