using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class ColorPicker<T, TChain> : InputBase<T, TChain> where TChain : ColorPicker<T, TChain>
    {
        private string value = null;
        public TChain Value(string value)
        {
            return Chain(t => t.value = value);
        }

        public override string ToString()
        {
            Init();

            var html = new StringBuilder();

            html.Append("<div class=\"input-group core-color-picker\">");
            html.AppendFormat("  <input type=\"text\" class=\"form-control {0} input-sm\" ", inputCss);

            if (!enable) html.Append("disabled='disabled' ");
            html.Append(this.GetDataAttribute());

            if (name.IsNotNull()) html.AppendFormat("name = '{0}' ", name);
            if (placeholder.IsNotNull()) html.AppendFormat("placeholder = '{0}' ", placeholder);
            if (value != null) html.AppendFormat("value='{0}' ", value);

            html.Append("/>");
            html.Append("<div class=\"input-group-addon\"><i></i></div>");
            html.Append("</div>");
            

            return html.ToString();
        }
    }
}
