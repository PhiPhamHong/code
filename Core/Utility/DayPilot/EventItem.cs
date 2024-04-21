using System;
using Newtonsoft.Json;
namespace Core.Utility.DayPilot
{
    public abstract class EventItem
    {
        public virtual DateTime FromDate { set; get; }
        public virtual DateTime ToDate { set; get; }

        [JsonProperty("id")] public string EIId { get { return GetId(); } }
        protected abstract string GetId();

        [JsonProperty("resource")] public string EIResource { get { return GetResourceId(); } }
        protected abstract string GetResourceId();

        [JsonProperty("text")] public string EIText { get { return GetText(); } }
        protected abstract string GetText();

        public string FromDateString
        {
            get { return FromDate.ToString("yyyy-MM-ddTHH:mm:ss"); }
        }
        public string ToDateString
        {
            get { return ToDate.ToString("yyyy-MM-ddTHH:mm:ss"); }
        }
        public string ToDateString1
        {
            get { return ToDate.ToString("yyyy/MM/dd"); }
        }
    }
}