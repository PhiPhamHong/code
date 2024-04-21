using System;
using System.Web;
using Core.Extensions;
using Core.FrontEnds.Libraries.Web;

namespace Core.FrontEnds.Libraries.Images
{
    public class PathImage
    {
        public const string IMG = "<img data-src='{0}' data-width='{4}' data-height='{5}' src='{3}' title=\"{1}\" class=\"{2}\" />";
        public const string IMG_NO = "<img data-src='{0}' {4} {5} src='{3}' title=\"{1}\" class=\"{2}\" />";

        public const string IMG2 = "<img data-src='{0}' src='{5}' title=\"{1}\" class=\"{2}\" {3} {4} />";
        public const string IMGFULL = "<img src='{3}{0}' title=\"{1}\" class=\"{2}\" {4} />";
        public const string PATH = "/{0}/{1}";
        public const string SRC = "{0}_w{1}_h{2}_{4}{3}";
        public const string DOT = ".";
        public const char srcPath = '/';

        public static string GetPath(string src, int w, int h, bool crop = false)
        {
            if (src.IsNotNull() && src.Length > 0 && src.LastIndexOf(DOT) != -1)
            {
                var strFirst = src.Substring(0, src.LastIndexOf(DOT));
                var strLast = src.Substring(src.LastIndexOf(DOT), src.Length - src.LastIndexOf(DOT));
                src = SRC.Frmat(strFirst, w, h, strLast, crop ? "c" : "n");
                return PATH.Frmat(Setting.SaveFolder, src.TrimStart(srcPath));
            }
            return string.Empty;
        }
        public static string GetRewrite(string src, int w, int h, bool crop = false)
        {
            if (src.IsNotNull() && src.Length > 0 && src.LastIndexOf(DOT) != -1)
            {
                var strFirst = src.Substring(0, src.LastIndexOf(DOT));
                var strLast = src.Substring(src.LastIndexOf(DOT), src.Length - src.LastIndexOf(DOT));
                return "/w{0}h{1}/{2}_{3}{4}".Frmat(w, h, crop ? "c" : "n", strFirst, strLast);
            }
            return string.Empty;
        }

        public static string GetTagFullImage(object src, object title, string css = "", string id = "")
        {
            if (src.ToString().IsNull()) return string.Empty;
            return IMGFULL.Frmat(src, HttpUtility.HtmlEncode(title), css, Setting.ServerImage, id.IsNull() ? string.Empty : "id='" + id + "'");
        }
        public static string GetFullImage(object src)
        {
            return Setting.ServerImage + src;
        }
        public static string GetImageTag(object src, int w, int h, object title, bool isFix = false, bool crop = false, string cls = "")
        {
            var path = GetPath(Convert.ToString(src), w, h, crop);
            if (path.IsNull()) return IMG_NO.Frmat(FeContext.Image.NoImage, HttpUtility.HtmlEncode(title), cls, FeContext.Image.NoImage, w == 0 ? string.Empty : "width=\"" + w + "\"", h == 0 ? string.Empty : "height=\"" + h + "\"");
            return isFix ?
                string.Format(IMG2, path, HttpUtility.HtmlEncode(title), cls, w == 0 ? string.Empty : "width=\"" + w + "\"", h == 0 ? string.Empty : "height=\"" + h + "\"", FeContext.Image.NoImage) :
                string.Format(IMG, path, HttpUtility.HtmlEncode(title), cls, FeContext.Image.NoImage, w, h);
        }
    }
}
