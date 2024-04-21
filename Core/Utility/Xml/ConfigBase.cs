using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Core.Extensions;
using System;
namespace Core.Utility.Xml
{
    /// <summary>
    /// Class Base để đọc file config do lập trình viên định nghĩa
    /// </summary>
    public abstract class ConfigBase
    {
        /// <summary>
        /// Lấy ra đường dẫn chưa file settings
        /// </summary>
        /// <returns></returns>
        public virtual string GetPath()
        {
            return this.GetType().FullName + ".config";
        }

        public virtual void AfterLoad() { }

        [Serializable]
        public class XmlBase
        {
            [XmlAnyAttribute]
            public List<XmlAttribute> Settings { get; set; }

            public TValue GetSetting<TValue>(string name)
            {
                var setting = Settings.FirstOrDefault(s => s.Name == name);
                return setting == null ? default(TValue) : setting.Value.To<TValue>();
            }
        }

        public virtual XmlSerializerNamespaces GetNamespaces()
        {
            return null;
        }
    }

    public abstract class ConfigBase<TConfig> : ConfigBase where TConfig : ConfigBase, new()
    {
        public static TConfig Load(Action<TConfig> action = null)
        {
            return ReadConfig<TConfig>.Load(action);
        }
    }
}
