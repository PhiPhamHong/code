using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class FileInput<T, TChain> : InputBase<T, TChain> where TChain : FileInput<T, TChain>
    {
        public FileInput()
        {
            Data("type-file-input", "true");
            Data("file-type", "Images");
        }

        public TChain TypeFile(string typeFile) { return Chain(t => t.Data("file-type", typeFile)); }
        public TChain Multi(bool multi = true) { return Chain(t => t.Data("multi", multi)); }
        public TChain ShowImages(bool showImages = true, int width = 100, int height = 100)
        {
            return Chain(t => t.Data("show-images", showImages).Data("image-width", width).Data("image-height", height));
        }

        public override string ToString()
        {
            Init();

            var html = new StringBuilder();
            html.Append("<div data-input-file='true'>");
            html.Append("   <div class=\"input-group\" style=\"" + style + "\">");
            html.Append("       <input type='text' ");
            html.AppendFormat("class = '{0} input-sm' ", inputCss);
            // if (!enable) 
                html.Append("disabled='disabled' ");
            html.Append(GetDataAttribute());

            if (name.IsNotNull()) html.AppendFormat("name = '{0}' ", name);
            if (placeholder.IsNotNull()) html.AppendFormat("placeholder = '{0}' ", placeholder);

            html.Append("/>");

            html.Append("       <div class=\"input-group-addon\">");
            html.Append("           <i class=\"fa fa-folder\"></i>");
            html.Append("       </div>");
            html.Append("   </div>");
            html.Append("</div>");
            return html.ToString();
        }
    }
}
