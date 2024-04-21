using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Extensions;
namespace Core.Web.Extensions
{
    public static class RepeaterExtension
    {
        public static void DoBind(this GridView grid, object source)
        {
            grid.DataSource = source;
            grid.DataBind();
        }

        public static void BindTo(this object source, GridView grid)
        {
            grid.DoBind(source);
        }

        public static void DoBind(this Repeater rp, object source)
        {
            rp.DataSource = source;
            rp.DataBind();
        }

        public static void BindTo(this object source, Repeater rp)
        {
            rp.DoBind(source);
        }

        public static void BindTo(this object source, params Repeater[] rps)
        {
            foreach (var rp in rps) rp.DoBind(source);
        }

        public static bool IsItem(this RepeaterItemEventArgs e)
        {
            return e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item;
        }

        public static T Find<T>(this RepeaterItemEventArgs e, string controlId) where T : Control
        {
            return e.Item.FindControl(controlId) as T;
        }

        public static T As<T>(this RepeaterItemEventArgs e)
        {
            return e.Item.DataItem.As<T>();
        }
    }
}
