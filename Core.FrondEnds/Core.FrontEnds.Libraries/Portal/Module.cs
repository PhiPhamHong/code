using Core.FrontEnds.Libraries.Images;
using Core.FrontEnds.Libraries.Web;
using Core.Web.WebBase;
using System;
using System.Linq;
using System.Web.UI;

namespace Core.FrontEnds.Libraries.Portal
{
    public abstract class Module : ControlBase
    {
        sealed public override void InitData()
        {
            BeforeInitData();
            Controls.Cast<Control>().OfType<ControlBase>().ToList().ForEach(m => m.InitData());
            OnInitData();
        }

        protected virtual void BeforeInitData() { }
        protected virtual void OnInitData() { }

        protected string ResourceImage(string path) { return FeContext.GetResourceImage(path); }
        protected string Label(string lexicon) { return FeContext.Label.Get(lexicon); }
        protected string Url(string prefix) { return FeUrl.Get(prefix); }
        protected string ImageTag(object src, int w, int h, object title, bool isFix = false, bool crop = false, string cls = "")
        {
            return PathImage.GetImageTag(src, w, h, title, isFix, crop, cls);
        }
        public string GetTagFullImage(object src, object title, string css = "", string id = "")
        {
            return PathImage.GetTagFullImage(src, title, css = "", id = "");
        }
        public string GetFullImage(object src)
        {
            return PathImage.GetFullImage(src);
        }
        protected string FullUrl(string url)
        {
            return FeContext.Page.GetFullUrl(url);
        }

        [AttributeUsage(AttributeTargets.Class)]
        public abstract class ConditionAttribute : Attribute
        {
            public abstract bool Condition { get; }
            public abstract string Msg { get; }
            public int Stt { set; get; }
        }
    }

    public abstract class ModuleHasControlError : Module, IModuleHasControlError
    {
        public abstract Control ControlError { get; }
    }

    public interface IModuleHasControlError
    {
        Control ControlError { get; }
    }

    public interface IModuleError
    {
        string Title { set; get; }
        string Content { set; get; }
    }
}
