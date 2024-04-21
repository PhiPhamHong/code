using System.Xml.Serialization;
using Core.Extensions;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Core.Sites.Libraries.Business
{
    public class MenuItemBase<T> where T : MenuItemBase<T>
    {
        [XmlAttribute("label"), JsonIgnore] public string Label { set; get; }
        [XmlAttribute("labelCss"), JsonIgnore] public string LabelCss { set; get; }
        [XmlAttribute("labelProvider"), JsonIgnore] public string LabelProvider { set; get; }

        [XmlAttribute("icon-color")] public string IconCssColor { set; get; }

        private int menuLeft = 1;
        [XmlAttribute("menu")]
        public int MenuLeft
        {
            get { return menuLeft; }
            set { menuLeft = value; }
        }

        private string labelText = "none";
        [XmlIgnore, JsonIgnore]
        public string LabelText
        {
            get
            {
                if (labelText == "none")
                {
                    if (Label.IsNotNull()) labelText = Label;
                    else if (LabelProvider.IsNull()) labelText = string.Empty;
                    else
                    {
                        var provider = LabelProvider.CreateInstance(true);
                        if (provider.Is<IMenuLabel<T>>())
                        {
                            labelText = provider.As<IMenuLabel<T>>().GetText(this as T);
                        }
                        else
                        {
                            labelText = string.Empty;
                            if (provider.Is<IMenuListLabel<T>>())
                                LabelTexts = provider.As<IMenuListLabel<T>>().GetLabels(this as T);
                        }
                    }
                }
                return labelText;
            }
        }

        [XmlIgnore, JsonIgnore]
        public IEnumerable<MenuItemLabel> LabelTexts { private set; get; }
    }

    public interface IMenuLabel<T>
    {
        string GetText(T t);
    }

    public class MenuItemLabel
    {
        public string BgColorCss { set; get; }
        public string Text { set; get; }
    }

    public interface IMenuListLabel<T>
    {
        IEnumerable<MenuItemLabel> GetLabels(T t);
    }
}