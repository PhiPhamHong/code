using System;
using System.Collections.Generic;
namespace Core.Extensions
{
    public static class DictionaryExtension
    {
        public static bool Get<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, Action<TValue> action)
        {
            // Biến lưu kết quả lấy ra từ Dictionary
            TValue value;

            // Thực hiện lấy value theo key, nếu tồn tại thì thực hiện action
            if (dic.TryGetValue(key, out value))
            {
                action(value);
                return true;
            }
            return false;
        }
        public static TValue GetOrNew<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, Action<TValue> actionNew) where TValue : new()
        {
            var value = default(TValue);
            if (!dic.Get(key, c => value = c))
            {
                dic[key] = value = new TValue();
                actionNew(value);
            }
            return value;
        }
        public static TValue TryGet<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
        {
            TValue value;
            return dic.TryGetValue(key, out value) ? value : default(TValue);
        }
        public static TValue TryGet<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue @default)
        {
            if (key == null) return @default;
            TValue value;
            return dic.TryGetValue(key, out value) ? value : @default;
        }
    }
}