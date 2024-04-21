using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System;
using Core.Caching;
namespace Core.Utility.Xml
{
    /// <summary>
    /// Đọc file Config và đưa dữ liệu đọc được vào một biến kiểu dữ liệu là T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadConfig<T> where T : ConfigBase, new()
    {
        /// <summary>
        /// Đối tượng để Serializer hoặc Deserializer đối tượng ra file hoặc ngược lại từ file ra đối tượng
        /// </summary>
        private static XmlSerializer xmlData = new XmlSerializer(typeof(T));

        /// <summary>
        /// Thực hiện đọc file setting và đưa thông tin vào đối tượng
        /// </summary>
        public static T Load(Action<T> action = null)
        {   
            T t = new T(); if (action != null) action(t);
            return Load(t.GetPath());
        }

        public static T Load(string path)
        {
            // Nếu đường dẫn đến file setting không tồn tại thì trả ra đối tượng rỗng
            if (!File.Exists(path)) return new T();

            T t = null;

            using (var xmlReader = new XmlTextReader(path))
            {
                t = (T)xmlData.Deserialize(xmlReader);
            }

            t.AfterLoad();
            return t;
        }

        public static T LoadByText(string xml)
        {
            T t = null;
            using (var xmlReader = new XmlTextReader(new StringReader(xml)))
            {
                t = (T)xmlData.Deserialize(xmlReader);
            }

            t.AfterLoad();
            return t;
        }

        public static void Save(T t)
        {
            // Lấy đường dẫn chưa file Settings
            var settingsPath = t.GetPath();

            // Nếu đường dẫn đến file setting không tồn tại thì trả ra đối tượng rỗng
            if (!File.Exists(settingsPath))
            {
                using (var fs = File.Create(settingsPath)) { }
            }

            var ns = t.GetNamespaces();

            using(var xmlWriter = new XmlTextWriter(settingsPath, Encoding.Unicode))
            {
                if (ns == null) xmlData.Serialize(xmlWriter, t);
                else xmlData.Serialize(xmlWriter, t, ns);
            }
        }

        public static string ToStringXml(T t)
        {
            var ns = t.GetNamespaces();
            using (var stringwriter = new Utf8StringWriter())
            {
                if (ns == null) xmlData.Serialize(stringwriter, t);
                else xmlData.Serialize(stringwriter, t, ns);
                
                return stringwriter.ToString();
            };
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
    }

    [CacheFactory(TypeFactory = typeof(WebCacheFactory))]
    public class CacheReadConfig<T> : CacheEntry<T> where T : ConfigBase, new()
    {
        protected override T LoadForCache()
        {
            return ReadConfig<T>.Load();
        }

        public static T Load()
        {
            return new CacheReadConfig<T>().Get();
        }
    }
}
