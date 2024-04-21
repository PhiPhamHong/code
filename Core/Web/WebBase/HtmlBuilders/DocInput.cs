using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class DocInput<T, TChain> : InputBase<T, TChain> where TChain : DocInput<T, TChain>
    {
        public DocInput()
        {
            Data("type-file-input", "true");
            Data("file-type", "Docs");
        }

        public TChain TypeFile(string typeFile) { return Chain(t => t.Data("file-type", typeFile)); }
        public TChain Multi(bool multi) { return Chain(t => t.Data("multi", multi)); }

        public override string ToString()
        {
            Init();

            var html = new StringBuilder();
            html.Append("<div class=\"input-group\">");
            html.Append("<input type='text' ");
            html.AppendFormat("class = '{0} input-sm' ", inputCss);
            if (!enable) html.Append("disabled='disabled' ");
            html.Append(this.GetDataAttribute());

            if (name.IsNotNull()) html.AppendFormat("name = '{0}' ", name);
            if (placeholder.IsNotNull()) html.AppendFormat("placeholder = '{0}' ", placeholder);

            html.Append("/>");

            html.Append("<div class=\"input-group-addon\">");
            html.Append("<i class=\"fa fa-folder\"></i>");
            html.Append("</div>");
            html.Append("</div>");
            return html.ToString();
        }
    }
}
