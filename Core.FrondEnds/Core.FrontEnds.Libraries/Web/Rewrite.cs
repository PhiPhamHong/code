using Core.FrontEnds.Libraries.Portal;

namespace Core.FrontEnds.Libraries.Web
{
    [TargetCacheUrl(TargetCache = typeof(CacheUrl))]
    public class Rewrite : RewritePortal
    {
        public override string Extension
        {
            get { return Setting.Extension; }
        }
    }

    public class RewriteNoneExtension : Rewrite
    {
        public override string Extension
        {
            get { return string.Empty; }
        }
    }
}