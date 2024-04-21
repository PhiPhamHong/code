using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.FrontEnds.Libraries.Portal.Configs
{
    /// <summary>
    /// Định nghĩa một column ở trên web
    /// ví dụ:
    /// <column css="css" stt="0" name="Cột trái">    
    /// </column>
    /// css: css của cột đó
    /// stt: Số thứ tự của cột
    /// name: Tên cột
    /// column: các cột con
    /// module: các module thuộc cột đó
    /// </summary>
    public class ColumnTag
    {
        [XmlAttribute("id")] public string Id { set; get; }
        [XmlAttribute("class")] public string Css { set; get; }
        [XmlAttribute("stt")] public int Stt { set; get; }
        [XmlElement("div")] public List<ColumnTag> Columns { get; set; } = new List<ColumnTag>();
        [XmlElement("module")] public List<ModuleTag> Modules { get; set; } = new List<ModuleTag>();
        [XmlAttribute("tag")] public string Tag { set; get; }
    }
}
