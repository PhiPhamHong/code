using Core.Web.Resources;
using System;
using System.Web;
using System.Xml.Serialization;

namespace Core.FrontEnds.Libraries.Web
{
    public class Resource
    {
        [Serializable, XmlRoot("root")]
        public class Path : ResourcesConfig
        {
            public override string GetPath()
            {
                return HttpContext.Current.Server.MapPath("~/Projects/" + Setting.Project + "/Settings/Resources.config");
            }
        }
        public class Css : ResourceHandler<Path>
        {
            protected override HandlerType ContentType
            {
                get { return HandlerType.Css; }
            }
        }
        public class Js : ResourceHandler<Path>
        {
            protected override HandlerType ContentType
            {
                get { return HandlerType.Js; }
            }
        }
    }
}
