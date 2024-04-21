using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Business
{
    [Serializable]
    public class MenuTop : MenuItem
    {
        [JsonIgnore, XmlElement("group")] public List<GroupMenu> Groups { set; get; }

        private bool hideWhenNoItem = true;
        [XmlAttribute("hideWhenNoItem")]
        public bool HideWhenNoItem
        {
            get { return hideWhenNoItem; }
            set { hideWhenNoItem = value; }
        }

        [JsonIgnore, XmlAttribute("type")] public byte SType
        {
            set { SessionType = (SessionType)value; }
            get { return (byte)SessionType; }
        }

        [JsonIgnore] public SessionType SessionType { set; get; }
    }
}