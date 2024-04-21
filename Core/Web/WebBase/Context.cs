using System;
using System.Web;
namespace Core.Web.WebBase
{
    public class Context
    {
        /// <summary>
        /// Lưu trữ dữ liệu vào Context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void Set<T>(string name, T data) //where T : class
        {
            HttpContext.Current.Items[name] = data;
        }

        /// <summary>
        /// Lấy dữ liệu từ Context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Get<T>(string name) //where T : class
        {
            // return HttpContext.Current.Items[name] as T;
            var value = HttpContext.Current.Items[name];
            if (value == null) return default(T);
            return (T)value;
        }

        /// <summary>
        /// Thực hiện lấy dữ liệu từ context
        /// Nếu chưa có thì thực hiện lấy dữ liệu và gán vô context
        /// Dữ liệu chỉ được lưu trên một lần thực hiện Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T Get<T>(string name, Func<T> func) //where T : class
        {
            T t = Get<T>(name);
            if (t == null) Set(name, t = func());
            return t;
        }
    }
}
