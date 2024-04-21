using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

using Core.Attributes;
using Core.Sites.Libraries.Utilities;
using Core.Web.Extensions;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Business
{
    [Serializable]
    public class DashBoardItem
    {
        [XmlAttribute("id")] public Guid Id { set; get; }
        [XmlAttribute("url")] public string Url { set; get; }
        [XmlAttribute("title"), PropertyInfo(Name = "Tiêu đề")] public string Title { set; get; }
        [XmlAttribute("stt"), PropertyInfo(Name = "Thứ tự")] public int Stt { set; get; }

        private int col = 3;
        [XmlAttribute("col")] public int Col { set { col = value; } get { return col; } }
        [XmlAttribute("tab")] public int TabId { set; get; }

        [XmlAttribute("boxtype")] public int TypeBox { set; get; }
        [XmlAnyAttribute] public List<XmlAttribute> Settings { get; set; }
    }

    public static class DashBoardItemExtend
    {
        public static CacheUrl.CacheUrlData GetCacheDataUrl(this DashBoardItem dbi, SessionType sessionType)
        {
            return CacheUrl.GetDataNoneExtension(dbi.Url, sessionType);
        }
    }
}