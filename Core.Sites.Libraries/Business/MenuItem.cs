using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Core.Utility.Language;
using Core.Attributes;
using Core.Extensions;

namespace Core.Sites.Libraries.Business
{
    /// <summary>
    /// Thông tin menu
    /// </summary>
    [Serializable]
    public class MenuItem : MenuItemBase<MenuItem>
    {
        private string urlVirtual = string.Empty;
        [XmlIgnore] public string UrlVirtual => MenuUrl.IsNull() ? urlVirtual : MenuUrl;

        [XmlAttribute("url")] public string MenuUrl { set; get; }

        private string title = string.Empty;
        [XmlAttribute("title"), PropertyInfo(Name = "Loại bảng tin")]
        public string Title
        {
            set { title = value; urlVirtual = title.UnicodeFormat(); }
            get => title;
        }

        [XmlAttribute("title2")] public string Title2 { set; get; }
        [XmlAttribute("icon")] public string Icon { set; get; }

        [XmlIgnore, JsonIgnore] public int[] Pers { set; get; } = new int[] { 0 };
        [XmlAttribute("per"), JsonIgnore]
        public string Permission
        {
            set => Pers = value.SplitTo<int>().ToArray();
            get => Pers.JoinString(p => p);
        }

        [XmlAttribute("pers"), JsonIgnore] public string Permissions { set; get; }
        [XmlAttribute("module")] public string Module { set; get; }
        [XmlAttribute("hide"), JsonIgnore] public bool Hide { set; get; }
        [XmlAttribute("hideAssign"), JsonIgnore] public bool HideAssignPermission { set; get; }
        [XmlAttribute("dashboard")] public bool DashBoard { get; set; } = true;

        public override string ToString() => Title;

        /// <summary>
        /// Các thiết lập khác bằng attribute
        /// </summary>        
        [XmlAnyAttribute, JsonIgnore] public List<XmlAttribute> Settings { get; set; }
        [XmlIgnore, JsonIgnore] public PathItem ModulePath { set; get; }
        [XmlIgnore, JsonIgnore] public bool CanAccess { set; get; }
        [XmlIgnore] public string Url { get { return UrlHelper.GetUrl(UrlVirtual); } }

        public TValue GetSetting<TValue>(string name)
        {
            var setting = Settings.FirstOrDefault(s => s.Name == name);
            return setting == null ? default : setting.Value.To<TValue>();
        }

        [JsonIgnore] public string IconShow => ModulePath == null || ModulePath.Icon.IsNull() ? Icon : ModulePath.Icon;
    }

    public abstract class MenuItemLabelProvider : IMenuLabel<MenuItem>
    {
        public abstract string GetText(MenuItem t);
    }

    public abstract class MenuListLabelProvider : IMenuListLabel<MenuItem>
    {
        public abstract IEnumerable<MenuItemLabel> GetLabels(MenuItem t);
    }
}
