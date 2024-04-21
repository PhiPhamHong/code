using System.Collections.Generic;
using Newtonsoft.Json;
namespace Core.Utility.DayPilot
{
    public class Column
    {
        [JsonProperty("html")] public string Html { set; get; }
        [JsonProperty("backColor")] public string BackColor { set; get; }
        [JsonProperty("cssClass")] public string CssClass { set; get; }
    }

    public abstract class DPResource
    {
        [JsonProperty("id")] public string RId { get { return GetId(); } }
        [JsonProperty("name")] public string RName { get { return GetName(); } }
        [JsonProperty("html")] public string RHtml { get { return GetHtml(); } }
        [JsonProperty("toolTip")] public string RToolTip { get { return GetToolTip(); } }
        [JsonProperty("backColor")] public string RBackColor { get { return GetBackColor(); } }
        [JsonProperty("cssClass")] public string RCssClass { get { return GetCssClass(); } }
        [JsonProperty("dynamicChildren")] public bool RDynamicChildren { get { return GetDynamicChildren(); } }
        [JsonProperty("expanded")] public bool RExpanded { get { return GetExpanded(); } }

        private List<DPResource> children = null;
        [JsonProperty("children")] public List<DPResource> RChildren 
        { 
            get 
            {
                if (children == null) children = GetChildren();
                return children; 
            } 
        }
        [JsonProperty("columns")] public List<Column> RColumns { get { return GetColumns(); } }

        protected abstract string GetId();
        protected abstract string GetName();
        protected virtual string GetHtml() { return string.Empty; }
        protected virtual string GetToolTip() { return string.Empty; }
        protected virtual string GetBackColor() { return string.Empty; }
        protected virtual string GetCssClass() { return string.Empty; }
        protected virtual bool GetDynamicChildren() { return false; }
        protected virtual bool GetExpanded() { return RChildren != null && RChildren.Count != 0; }
        protected virtual List<DPResource> GetChildren() { return null; }
        protected virtual List<Column> GetColumns() { return null; }
    }
}