using System;
using System.Text;
using Core.Extensions;
using Core.Utility.Language;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class DatePicker<T, TChain> : InputBase<T, TChain> where TChain : DatePicker<T, TChain>
    {
        private DateTime? value = null; public TChain Value(DateTime? date) { return Chain(t => t.value = date); }
        public TChain StartMonth() { return Chain(t => t.value = DateTime.Now.StartMonth()); }
        public TChain EndMonth() { return Chain(t => t.value = DateTime.Now.EndMonth()); }
        public TChain ToDay() { return Chain(t => t.value = DateTime.Now); }
        protected int? widthTime = null; public TChain WidthTime(int? widthTime) => Chain(t => t.widthTime = widthTime);
        private bool hasTime = false; public TChain HasTime(bool hasTime = true) { return Chain(t => t.hasTime = hasTime); }
        protected string inputSize = "input-sm"; public TChain InputSize(string inputSize) { return Chain(t => t.inputSize = inputSize); }
        public TChain EndDate() { return Data("end-date", "true"); }
        protected string width = string.Empty; public TChain Width(string width) { return Chain(t => t.width = width); }

        private string fireChange = "";
        public TChain SetFireChange(string field)
        {
            return Chain(t => t.fireChange = field);            
        }

        public override string ToString()
        {
            Data("type-date", "true");
            Init();

            var html = new StringBuilder();

            if (hasTime)
            {
                html.Append("<div class=\"bootstrap-timepicker timepicker\">");
                if (widthTime == null) widthTime = 54;
                if (FormGroup != null)
                {
                    if (FormGroup.GetCol() == 0) FormGroup.SetInputStyle("width: 180px");
                    else FormGroup.SetColStyle("width: 180px");
                }
            }
            else
            {
                if (FormGroup != null)
                {
                    if (FormGroup.GetCol() == 0) FormGroup.SetInputStyle("width: 125px");
                    else FormGroup.SetColStyle("width: 125px");
                }
            }

            html.Append("<div class=\"input-group\" data-control-date='true' data-name='" + name + "' " + (width.IsNull() ? string.Empty : "style='width:" + width + "' "));
            if (fireChange.IsNotNull())
                html.AppendFormat(" data-fire-change='{0}'", fireChange);
            html.Append(">");

            if (hasTime)
            {
                html.AppendFormat("<input data-type-time-indate='true' placeholder='" + LanguageHelper.GetLabel("Giờ:Phút") + "' type='text' style='{0}' ", widthTime.IsNull() ? "width: 50%" : "width:" + widthTime + "px");
                html.AppendFormat("class = '{0} " + inputSize + "' ", inputCss);
                if (!enable) html.Append("disabled='disabled' ");
                if (value != null) html.AppendFormat("value='{0:HH:mm}' ", value);
                html.Append("/>");
            }

            html.Append("<input type='text' ");
            if (hasTime)
            {
                html.AppendFormat("style='width: {0};margin-left: 1px' ", widthTime.IsNull() ? "calc(50% - 1px)" : "calc(100% - " + (widthTime + 1) + "px)");
            }

            html.AppendFormat("class = '{0} " + inputSize + "' ", inputCss);
            if (!enable) html.Append("disabled='disabled' ");
            html.Append(GetDataAttribute());

            if (placeholder.IsNotNull()) html.AppendFormat("placeholder = '{0}' ", placeholder);
            if (value != null) html.AppendFormat("value='{0:dd/MM/yyyy}' ", value);

            html.Append("/>");

            html.Append("<div class=\"input-group-addon\">");
            html.Append("<i class=\"fas fa-calendar-alt\"></i>");
            html.Append("</div>");
            html.Append("</div>");

            if (hasTime) html.Append("</div>");
            return html.ToString();
        }
    }

    public class DatePicker<T> : DatePicker<T, DatePicker<T>> { }
    public class DatePicker : DatePicker<ModelNone> { }
}
