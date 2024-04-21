using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Core.Utility;
using Core.DataBase.ADOProvider;

namespace Core.Extensions
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Tìm kiếm những bản tin mới từ danh sách mói so với danh sách cũ
        /// Tìm xem ở listNews có gì mà ở listOlds không có
        /// </summary>
        public static IEnumerable<T1> FindNewItems<T1, T2, T>(this IEnumerable<T1> listNews, IEnumerable<T2> listOlds, Func<T1, T> ex1, Func<T2, T> ex2)
        {
            return (from vi_new in listNews
                    join vi_old in listOlds on ex1(vi_new) equals ex2(vi_old) into vi_old_
                    from vi_old_item in vi_old_.DefaultIfEmpty()
                    select new { vi_new, vi_old_item }).Where(o => object.Equals(o.vi_old_item, default(T2))).Select(o => o.vi_new);
        }
        public static void ForEach<T>(this IEnumerable<T> data, Action<T> action)
        {
            foreach (var t in data) action(t);
        }
        public static string JoinString<T, T1>(this IEnumerable<T> list, Func<T, T1> action, string sep = ",")
        {
            if (list == null) return string.Empty;
            return string.Join(sep, list.Select(action));
        }
        public static string JoinString<T, T1>(this IEnumerable<T> list, Func<T, int, T1> action, string sep = ",")
        {
            if (list == null) return string.Empty;
            return string.Join(sep, list.Select(action));
        }
        public static void SJoin<T1, T2, TValue>(this IEnumerable<T1> d1, IEnumerable<T2> d2, Func<T1,TValue> t1, Func<T2,TValue> t2, Action<T1,T2> action)
        {
            if (d1 == null || d2 == null) return;
            d1.Join(d2, d11 => t1(d11), d21 => t2(d21), (d11, d21) => { action(d11, d21); return false; }).Count();
        }
        public static int SGroupJoin<T1, T2, TValue>(this IEnumerable<T1> t1, IEnumerable<T2> t2, Func<T1, TValue> f1, Func<T2, TValue> f2, Action<T1, IEnumerable<T2>> action)
        {
            return t1.GroupJoin(t2, f1, f2, (t1i, t2is) => { action(t1i, t2is); return false; }).Count();
        }
        public static void SLeftJoin<T1, T2, T>(this IEnumerable<T1> listNews, IEnumerable<T2> listOlds, Func<T1, T> ex1, Func<T2, T> ex2, Action<T1, T2> map, Action<T1> notmap)
        {
            (from vi_new in listNews
             join vi_old in listOlds on ex1(vi_new) equals ex2(vi_old) into vi_old_
             from vi_old_item in vi_old_.DefaultIfEmpty()
             select new { vi_new, vi_old_item })
             .Where(o =>
             {
                 if (object.Equals(o.vi_old_item, default(T2))) return true;
                 else { map(o.vi_new, o.vi_old_item); return false; }
             })
             .ToList()
             .Select(o => { notmap(o.vi_new); return false; }).Count();
        }
        public static List<T> TryTake<T>(this BlockingCollection<T> data, int totalTryTake)
        {
            var list = new List<T>();
            T t; var i = 0;
            while (i < totalTryTake && data.Count > 0)
            {
                if (data.TryTake(out t))
                {
                    list.Add(t);
                    i++;
                }
            }
            return list;
        }
        public static void ProcessInPage<T>(this List<T> list, int pageSize, Action<List<T>, int> action)
        {
            // Tổng số trang
            var totalPage = (int)Math.Ceiling((decimal)list.Count / pageSize);

            for (int i = 1; i <= totalPage; i++)
                action(list.Skip((i - 1) * pageSize).Take(pageSize).ToList(), i);
        }
        public static List<T> AddMax<T>(this List<T> data, int max) where T : new()
        {
            if (data.Count < max) Enumerable.Range(1, max - data.Count).ForEach(i => data.Add(new T { }));
            return data;
        }
        public static ModelListSave<T> SplitItems<T, TKey>(this List<T> newItems, Func<List<T>> oldItems, Func<bool> needDelete, Func<T, TKey> key)
        {
            var results = new ModelListSave<T> { Upserts = newItems };
            if (needDelete())
            {
                results.Olds = oldItems();
                results.Deletes = results.Olds.FindNewItems(newItems, key, key).ToList();
            }
            return results;
        }
        public static bool ListEmpty<T>(this List<T> data) => data == null || data.Count == 0;
        public static bool Contains(this IEnumerable<int> source, IEnumerable<int> data) => source.Join(data, s => s, d => d, (s, d) => true).Any();
    }
}