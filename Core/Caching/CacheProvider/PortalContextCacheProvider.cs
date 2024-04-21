using System.Collections.Generic;
using System.Web;
namespace Core.Caching.CacheProvider
{
    public class PortalContextCacheProvider : ICacheProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        public void Set<T>(string key, T value, System.TimeSpan time) where T : class
        {
            HttpContext.Current.Items[key] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            return HttpContext.Current.Items[key] as T;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patternKey"></param>
        public void Clear(List<string> patternKey) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Clear(string key) 
        {
            HttpContext.Current.Items[key] = null;
        }
    }
}
