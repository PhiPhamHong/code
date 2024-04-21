using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Core.FrontEnds.Libraries.Portal.Configs
{
    [Serializable]
    public class ModuleTag
    {
        [XmlAttribute("stt")] public int Stt { set; get; }
        [XmlAttribute("name")] public string Name { set; get; }
        [XmlAnyAttribute] public List<XmlAttribute> Settings { get; set; }

        [XmlIgnore] public string Path { set; get; }
    }
}
