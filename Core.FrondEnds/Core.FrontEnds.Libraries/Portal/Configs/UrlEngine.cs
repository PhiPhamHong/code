using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Core.DataBase.ADOProvider;
using Core.Extensions;
using Core.FrontEnds.Libraries.Web;

namespace Core.FrontEnds.Libraries.Portal.Configs
{
    [Serializable]
    public class UrlEngine
    {
        public string Type { set; get; }

        [XmlAttribute("name")] public string Name { set; get; }
        [XmlAnyAttribute] public List<XmlAttribute> Settings { get; set; }

        public static string FindQuery(PageTag page, string path)
        {
            var result = new Result { };

            var engines = page.UrlEngines.Where(u => u.Type.IsNotNull());
            foreach (var u in engines)
            {
                var engine = u.Type.CreateInstance<IUrlEngine>();
                if (u.Settings != null) engine.Parse(u.Settings.ToDictionary(a => a.Name, a => (object)a.Value), true);
                result.Query = string.Empty;
                result.Meta = null;
                engine.FindQuery(result, page, path);

                if (result.Query.IsNotNull())
                {
                    FeContext.Page.SetPageMeta(result.Meta);
                    result.Query += "&UrlEngine=" + engine.GetType().Name;
                    return result.Query;
                }
            }

            return string.Empty;
        }

        public class Result
        {
            public string Query { set; get; }
            public IPageMeta Meta { set; get; }
        }
    }
}
