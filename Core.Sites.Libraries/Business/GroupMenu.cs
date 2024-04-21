using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Core.Utility.Language;

namespace Core.Sites.Libraries.Business
{
    [Serializable]
    public class GroupMenu : MenuItemBase<GroupMenu>
    {
        [XmlAttribute("name")] public string Name { set; get; }
        [XmlAttribute("name2")] public string Name2 { set; get; }
        [XmlAttribute("bg-color")] public string BgColor { set; get; }

        [XmlAttribute("icon")] public string Icon { set; get; }
        [XmlElement("item")] public List<MenuItem> MenuItems { set; get; }
    }
}