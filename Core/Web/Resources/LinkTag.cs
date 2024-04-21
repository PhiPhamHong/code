using System.Xml.Serialization;
namespace Core.Web.Resources
{
    public class LinkTag : ILinkResource
    {
        /// <summary>
        /// đường dẫn đến file css
        /// </summary>
        [XmlAttribute("href")]
        public string Href { set; get; }

        /// <summary>
        /// Site sử dụng tài nguyên này
        /// </summary>
        [XmlAttribute("site")]
        public string Site { set; get; }

        [XmlText]
        public string Content { set; get; }

        public string Path
        {
            get { return Href; }
        }
    }
}
