using System.Xml.Linq;
using System.Linq;
namespace Core.Extensions
{
    public static class XElementExtension
    {
        public static XElement First(this XElement ele, XName tag)
        {
            return ele.Elements(tag).FirstOrDefault();
        }

        public static string FirstForAttribute(this XElement ele, string attrName)
        {
            if (ele == null) return string.Empty;
            var attr = ele.Attribute(attrName);
            return attr == null ? string.Empty : attr.Value;
        }

        public static string FirstForAttribute(this XElement ele, XName tag, string attrName)
        {
            return ele.First(tag).FirstForAttribute(attrName);
        }
    }
}
