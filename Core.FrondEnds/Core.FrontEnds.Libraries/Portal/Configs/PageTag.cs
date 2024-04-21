using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.FrontEnds.Libraries.Portal.Configs
{
    /// <summary>
    /// Định nghĩa một PageTag 
    /// ví dụ:
    /// <page title="Trang chủ">    
    /// </page>
    /// </summary>
    [Serializable]
    public class PageTag
    {
        [XmlElement("div")] public List<ColumnTag> Columns { set; get; } = new List<ColumnTag>();
        [XmlElement("url")] public List<UrlTag> Urls { get; set; } = new List<UrlTag>();
        [XmlElement("urlengine")] public List<UrlEngine> UrlEngines { get; set; } = new List<UrlEngine>();

        [XmlAttribute("title")] public string Title { set; get; }
        [XmlAttribute("master")] public string Master { set; get; }
        [XmlAttribute("site")] public string Site { set; get; }
    }
}
