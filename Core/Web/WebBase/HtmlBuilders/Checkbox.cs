using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class Checkbox<T, TChain> : InputBase<T, TChain> where TChain : Checkbox<T, TChain>
    {
        public Checkbox() { inputCss = string.Empty; }

        /// <summary>
        /// Dùng cho radio kế thừa 
        /// </summary>
        protected virtual string Type { get { return "checkbox"; } }

        #region properties
        protected bool inline = false; public TChain Inline(bool inline) { return Chain(t => t.inline = inline); }
        protected bool @checked = false; public TChain Checked(bool @checked) { return Chain(t => t.@checked = @checked); }
        public TChain Value(object value) { return Chain(t => t.Data("value", value)); }
        protected string labelCss = string.Empty; public TChain LabelCss(string labelCss) { return Chain(t => t.labelCss = labelCss); }
        #endregion

        public override string ToString()
        {
            Init();
            var html = new StringBuilder();

            // if (!inline) html.Append("<div class='" + Type + "'>");
            if (!inline) html.Append("<div>");

            html.Append("<label ");
            // if (inline) html.Append("class='" + Type + "-inline'");
            if (labelCss.IsNotNull()) html.AppendFormat("class='{0}' ", labelCss);
            if (inline) Style("margin-right:10px");
            if (style.IsNotNull()) html.AppendFormat("style='{0}' ", style);
            html.Append(">");

            html.AppendFormat("<input type='{0}' ", Type);
            html.AppendFormat("placeholder='{0}' ", placeholder);
            if (name.IsNotNull()) html.AppendFormat("name='{0}' ", name);
            if (!enable) html.Append("disabled='disabled' ");
            if (@checked) html.Append("checked='checked' ");
            html.Append(this.GetDataAttribute());

            if (inputCss.IsNotNull()) html.AppendFormat("class='{0} input-sm' ", inputCss);
            html.Append("/>&nbsp;&nbsp;");

            html.Append(placeholder);
            html.Append("</label>");

            if (!inline) html.Append("</div>");

            return html.ToString();
        }
    }

    public class Checkbox<T> : Checkbox<T, Checkbox<T>> { }
}
