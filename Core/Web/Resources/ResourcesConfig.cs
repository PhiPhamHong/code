using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using System.Configuration;
using Core.Utility.Xml;
using Core.Extensions;
using Core.Web.Extensions;
using Core.Utility;
using Core.Utility.IO;

namespace Core.Web.Resources
{
    [Serializable]
    [XmlRoot("root")]
    public class ResourcesConfig : ConfigBase
    {
        [XmlElement("script")]
        public List<ScriptTag> Scripts { set; get; }

        [XmlElement("link")]
        public List<LinkTag> Links { set; get; }

        public override string GetPath()
        {
            // return HttpContext.Current.Server.MapPath("~/Settings/Projects/" + ConfigurationManager.AppSettings["Project"] + "/Resources.config");
            return HttpContext.Current.Server.MapPath("~/Settings/Projects/Resources.config");
        }

        /// <summary>
        /// Thực hiện tải nội dung toàn bộ file của một resource
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string LoadContent(HandlerResourceBase.HandlerType type)
        {
            // 
            var rt = type == HandlerResourceBase.HandlerType.Css ? Links.Cast<ILinkResource>() : Scripts.Cast<ILinkResource>();

            // site yêu cầu
            var site = HttpContext.Current.Request.Query<string>("site").WhenEmpty(() => HttpContext.Current.Request.Query<string>("sites"));

            // StringBuilder để tạo nội dung file
            var sbContent = new StringBuilder();

            // Duyệt qua từng file mà trong ResourceType quy định
            rt.ForEach(f =>
            {
                // Nếu là site được yêu cầu thì mới tải
                if (!(f.Site.IsNull() || f.Site.Split(',').Contains(site))) return;

                // Tạo nhãn để nhận biết là bắt đầu từ file nào
                // sbContent.AppendLine("\n/*---- file: {0} ----*/\n".Frmat(f.Src));

                // Lấy nội dung file
                if(f.Path.IsNotNull()) sbContent.AppendLine(f.Path.GetFileContent());

                // Lấy nội dung thẻ
                if (f.Content.IsNotNull()) sbContent.AppendLine(f.Content);
            });

            // 
            return sbContent.ToString();
        }
    }
}
