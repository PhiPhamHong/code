using Core.Web;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Portal
{
    public class UrlMapping
    {
        public static UrlMappingResult Map(string url, bool multi, params UrlParam[] dps)
        {
            var umr = new UrlMappingResult { Paths = new List<IUrlPath> { } };
            var current = string.Empty;

            for (int i = 0; i < dps.Length; i++)
            {
                foreach (var v in dps[i].Paths)
                {
                    if (current.IsNull() && url == v.Path)
                    {
                        umr.HasFull = true;
                        umr.Paths.Add(v);
                        break;
                    }
                    else
                    {
                        var next = current + v.Path;
                        if (url.StartsWith(next))
                        {
                            current = next + "-";

                            umr.HasFull = url == next;
                            umr.Paths.Add(v);

                            if (multi) continue;
                            break;
                        }
                    }
                }

                if (umr.HasFull) break;
            }

            return umr;
        }
    }

    public class UrlMappingResult
    {
        public bool HasFull { set; get; }
        public List<IUrlPath> Paths { set; get; }
    }

    public class UrlParam
    {
        public List<IUrlPath> Paths { set; get; }
        public static implicit operator UrlParam(List<IUrlPath> paths)
        {
            return new UrlParam { Paths = paths };
        }
    }

    public class UrlParam<T> : UrlParam where T : IUrlPath
    {
        new public List<T> Paths
        {
            set { base.Paths = value.Cast<IUrlPath>().ToList(); }
            get { return base.Paths.Cast<T>().ToList(); }
        }
        public static implicit operator UrlParam<T>(List<T> paths)
        {
            return new UrlParam<T> { Paths = paths };
        }
    }
}
