using System.Xml.Serialization;
namespace Core.Web.Resources
{
    public class ScriptTag : ILinkResource
    {
        [XmlAttribute("src")]
        public string Src { set; get; }

        /// <summary>
        /// Site sử dụng tài nguyên này
        /// </summary>
        [XmlAttribute("site")]        
        public string Site { set; get; }

        [XmlText]
        public string Content { set; get; }

        public string Path
        {
            get { return Src; }
        }
    }
}
