using Core.Utility.Xml;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.FrontEnds.Libraries.Portal.Configs
{
    [Serializable, XmlRoot("root")]
    public abstract class PagesConfig : ConfigBase
    {
        [XmlElement("page")] public List<PageTag> Pages { set; get; }
    }
}
