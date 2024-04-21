using System;
using System.Linq;
using System.Collections.Generic;
using Core.Extensions;
using Core.Utility;
namespace Core.Caching
{
    /// <summary>
    /// Định nghĩa một CacheEntry
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CacheEntry<T> : IClearCache where T : class
    {
        private ICacheProvider cacheProvider = null;
        /// <summary>
        /// CacheEntry này sử dụng CacheProvider nào
        /// </summary>
        public ICacheProvider CacheProvider
        {
            get
            {
                if (cacheProvider == null)
                {
                    // Khởi tạo cacheProvider cho CacheEntry
                    cacheProvider = this.GetType().GetAttribute<CacheFactoryAttribute>().GetCacheProvider();

                    // Thiết lập Switchor nếu như CacheEntry có lựa chọn Server Cache tùy thuộc vào tham số
                    if (cacheProvider.Is<IServerCacheSwitchable>() && this.Is<IServerCacheSwitchor>())
                        cacheProvider.As<IServerCacheSwitchable>().Switchor = this.As<IServerCacheSwitchor>();
                }

                return cacheProvider;
            }
        }

        /// <summary>
        /// Phương thức cung cấp dữ liệu cho Cache
        /// </summary>
        /// <returns></returns>
        protected abstract T LoadForCache();

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        public virtual T Get()
        {
            key = string.Empty;

            // Lấy dữ liệu từ Cache
            T t = CacheProvider.Get<T>(Key);

            // Nếu cache chưa có thì nạp
            if (t == null)
            {
                t = LoadForCache();
                if (t != null) CacheProvider.Set(Key, t, new TimeSpan(2, 0, 0));
            }

            // 
            return t;
        }

        public virtual T ReloadCache()
        {
            Clear();
            return Get();
        }

        /// <summary>
        /// Clear cache theo một Property
        /// </summary>
        /// <param name="pc"></param>
        public void ClearWith(List<PropertyCacheAttribute> pcs)
        {
            CacheProvider.Clear(pcs.Select(pc => CreateBaseKey(pc.TargetName, pc.Value)).ToList());
        }

        private string key = string.Empty;
        /// <summary>
        /// Tạo Key Cache
        /// </summary>
        protected string Key
        {
            get
            {
                if (key.IsNull())
                {
                    // Danh sách Property có PropertyCacheAttribute
                    var list = GetType().GetListPairPropertyAttribute<PropertyCacheAttribute>();

                    // Duyệt qua các Property có PropertyCacheAttribute để tạo Key Cache. Có dạng là
                    // PropertyCacheAttribute.TargetName_ Giá trị của Property
                    list.ForEach(pr => key += ParseKey(pr.T2.TargetName, pr.T1.GetValue(this, null)) + "_");

                    // Cộng với tên class
                    key += GetType().Name;
                }

                return key;
            }
        }

        private string ParseKey(string targetName, object value)
        {
            // Case value to list nếu như là kiểu list
            var valueToList = value.CastToList();

            // Nếu không phải là kiểu list
            if (valueToList.IsNull()) return CreateBaseKey(targetName, value);

            // Nếu là list thì tạo thành list liên kết với nhau bởi dấu _
            return string.Join("_", valueToList.Select(v => CreateBaseKey(targetName, v)).ToArray());
        }

        /// <summary>
        /// Cặp key value => base key
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string CreateBaseKey(string targetName, object value)
        {
            return targetName + "_" + value;
        }

        public void Clear()
        {
            CacheProvider.Clear(Key);
        }
    }

    public abstract class CacheEntry<T, TInstance> : CacheEntry<T> where T : class where TInstance : CacheEntry<T>, new()
    {
        public static T GetData()
        {
            return Singleton<TInstance>.Inst.Get();
        }
        public static T Reload() // dùng để làm mới lại cache() trong trường hợp muốn thêm cái gì đó lại vô cache
        {
            return Singleton<TInstance>.Inst.ReloadCache();
        }
    }

    [CacheFactory(TypeFactory = typeof(WebCacheFactory))]
    public abstract class CacheByWebCacheFactory<T> : CacheEntry<T> where T : class { }

    [CacheFactory(TypeFactory = typeof(WebCacheFactory))]
    public abstract class CacheByWebCacheFactory<T, TInstance> : CacheEntry<T, TInstance> where T : class where TInstance : CacheEntry<T>, new() { }
}
