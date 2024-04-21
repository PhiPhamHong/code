using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Linq;
namespace Core.Web.Extensions
{
    public static class ControlExtension
    {
        public static string GetHtml(this Control ctrl)
        {
            var sb = new StringBuilder();
            using (var tw = new StringWriter(sb))
            {
                using (var hw = new HtmlTextWriter(tw)) ctrl.RenderControl(hw);
                return sb.ToString();
            }
        }

        public static IEnumerable<T> FindAllChildrenByType<T>(this Control control)
        {
            var controls = control.Controls.Cast<Control>();
            var enumerable = controls as Control[] ?? controls.ToArray();
            return enumerable.OfType<T>().Concat(enumerable.SelectMany(ctrl => ctrl.FindAllChildrenByType<T>()));
        }
    }
}
