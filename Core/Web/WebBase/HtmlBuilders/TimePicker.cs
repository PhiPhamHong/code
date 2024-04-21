using System;
using System.Text;
using Core.Extensions;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class TimePicker<T, TChain> : InputBase<T, TChain> where TChain : TimePicker<T, TChain>
    {
        public TimePicker()
        {   
            Data("type-time", "true");
        }

        private TimeSpan? value = null;
        public TChain Value(TimeSpan value)
        {
            return Chain(t => t.value = value);
        }

        public override string ToString()
        {
            Init();

            var html = new StringBuilder();
            html.Append("<div class=\"bootstrap-timepicker\">");
            html.Append("<div class=\"input-group\">");
            html.AppendFormat("  <input type=\"text\" class=\"form-control timepicker {0} input-sm\" ", inputCss);

            if (!enable) html.Append("disabled='disabled' ");
            html.Append(this.GetDataAttribute());

            if (name.IsNotNull()) html.AppendFormat("name = '{0}' ", name);
            if (placeholder.IsNotNull()) html.AppendFormat("placeholder = '{0}' ", placeholder);
            if (value != null)
            {
                if (value == TimeSpan.Zero) html.Append("value='00:00' ");
                else html.AppendFormat("value='{0}' ", value.Value.ToString(@"hh\:mm"));
            }
            html.Append("/>");
            html.Append("<div class=\"input-group-addon\"><i class=\"fa fa-clock-o\"></i></div>");
            html.Append("</div>");
            html.Append("</div>");

            return html.ToString();
        }
    }

    public class TimePicker<T> : TimePicker<T, TimePicker<T>> { }
    public class TimePicker : TimePicker<ModelNone> { }
}
