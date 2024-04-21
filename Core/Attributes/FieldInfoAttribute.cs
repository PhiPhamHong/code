using Core.Utility.Language;
using System;
using System.Reflection;
using Newtonsoft.Json;
namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldInfoAttribute : Attribute
    {
        [JsonIgnore] public FieldInfo FieldInfo { set; get; }
        [JsonProperty("id")] public object RawValue { set; get; }
        public object FieldValue { set; get; }
        [JsonProperty("text")] public string Name
        {
            get { return LanguageHelper.GetLabel(name); }
            set { name = value; }
        }
        private string name = string.Empty;
    }
}