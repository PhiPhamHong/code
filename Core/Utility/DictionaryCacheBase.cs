using System.Collections.Generic;
using System.Collections.Concurrent;
using Core.Extensions;
namespace Core.Utility
{
    /// <summary>
    /// DictionaryBase dùng để cache
    /// </summary>
    public abstract class DictionaryCacheBase<TKey, TValue, TInst> where TInst : new()
    {
        public static TInst Inst { get { return Singleton<TInst>.Inst; } }

        /// <summary>
        /// Dic để lưu trữ các giá trị
        /// </summary>
        private ConcurrentDictionary<TKey, TValue> dic = new ConcurrentDictionary<TKey, TValue>();

        /// <summary>
        /// indexer để lấy giá trị theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                lock (dic)
                {
                    TValue value;
                    if (!dic.TryGetValue(key, out value)) dic[key] = value = GetValueForDic(key);
                    return value;
                }
            }
        }

        /// <summary>
        /// Phương thức nội bộ để lấy được giá trị với một Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected abstract TValue GetValueForDic(TKey key);

        /// <summary>
        /// Clear toàn bộ cache
        /// </summary>
        public void Clear() { dic.Clear(); }
    }
}
