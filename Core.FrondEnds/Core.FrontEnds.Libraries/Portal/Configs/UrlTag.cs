using System;
using System.Xml.Serialization;

namespace Core.FrontEnds.Libraries.Portal.Configs
{
    /// <summary>
    /// Tag để định nghĩa đường link của Page
    /// ví dụ: <url virtual="home" real="m=1" />
    /// virtual: Thông tin đường link ảo
    /// real: Tham số parameter QueryString
    /// </summary>
    [Serializable]
    public class UrlTag
    {
        [XmlAttribute("virtual")] public string ViturlPath { set; get; }
        [XmlAttribute("real")] public string Real { set; get; }
    }
}
