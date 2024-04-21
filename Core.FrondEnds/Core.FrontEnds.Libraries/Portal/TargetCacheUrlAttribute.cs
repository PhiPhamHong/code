using Core.Attributes;
using System;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Portal
{
    public class TargetCacheUrlAttribute : ClassInfoAttribute
    {
        public Type TargetCache { set; get; }

        public ICacheUrl GetCacheUrl()
        {
            return TargetCache.CreateInstance<ICacheUrl>();
        }
    }
}
