using System.Collections.Generic;
namespace Core.Caching
{
    public interface IClearCache
    {
        void ClearWith(List<PropertyCacheAttribute> pcs);
    }
}
