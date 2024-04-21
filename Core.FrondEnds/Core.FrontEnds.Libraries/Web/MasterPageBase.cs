using Core.Web.WebBase;
using System;
using System.Linq;
using System.Web.UI;
using Core.Extensions;
using System.Web.UI.WebControls;
using Core.Attributes;
using Core.Reflectors;
using System.Web;
using Core.FrontEnds.Libraries.Images;

namespace Core.FrontEnds.Libraries.Web
{
    public abstract class MasterPageBase : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controls.Cast<Control>().OfType<ControlBase>().ToList().ForEach(m => m.InitData());
            AfterLoad();

            LiteralBottom.Visible = !FeContext.Url.Ajax;
        }

        protected virtual void AfterLoad() { }
        protected override void OnPreRender(EventArgs e)
        {
            Page.Title = GetContentFromContext(FeContext.Page.Linkit_PageTitle, FeContext.Seo.PageTitle);
            Page.MetaDescription = GetContentFromContext(FeContext.Page.Linkit_PageDescription, FeContext.Seo.Description);
            Page.MetaKeywords = GetContentFromContext(FeContext.Page.Linkit_PageKeyword, FeContext.Seo.Keyword);
            
            var canonical = GetContentFromContext(FeContext.Page.Linkit_Canonical, FeContext.Page.CurrentUrl());
            var meta = BindingMeta() + Meta_Template.Frmat("property", "og:image:width", "520")
                                     + Meta_Template.Frmat("property", "og:image:height", "280"); // +Link_Canonical_Template;

            LiteralHead.Text = meta.Frmat(canonical);
            LiteralHead.Text += FeContext.CreateLinkCss(FeContext.SiteId, "all") + Favicon_Template.Frmat(PathImage.GetFullImage(FeContext.Seo.Favicon));
            if (FeContext.Seo.GoogleAnalytics.IsNotNull())
                LiteralHead.Text += Script_Template.Frmat(FeContext.Seo.GoogleAnalytics);
            LiteralBottom.Text = FeContext.CreateLinkJs(FeContext.SiteId);
        }
        protected abstract Literal LiteralHead { get; }
        protected abstract Literal LiteralBottom { get; }

        private string BindingMeta()
        {
            var mif = ReflectTypeListMethodInfo<MethodInfoAttribute>.Inst[GetType()];
            var metas = FeContext.Metas;
            foreach (var meta in metas)
            {
                if (meta.AttributeValue == "og:image")
                    meta.AttributeContent = PathImage.GetFullImage(meta.AttributeContent);
            }
            return metas.OrderBy(mt => mt.Stt).Select(mt =>
                Meta_Template.Frmat(mt.AttributeName, mt.AttributeValue,
                    mt.AttributeContent.IsNotNull() ? mt.AttributeContent : mif.FirstOrDefault(mf => mf.MethodInfo.Name == mt.AttributeMethodContent).MethodInfo.Invoke(this, new object[] { })))
                    .JoinString(mt => mt, string.Empty);
        }

        #region meta method
        [MethodInfo] protected string GetUrl() { return FeContext.Page.CurrentUrl(); }
        [MethodInfo] protected string GetTitle() { return GetContentFromContext(FeContext.Page.Linkit_PageTitle, FeContext.Seo.PageTitle); }
        [MethodInfo]
        protected string GetImage()
        {
            return FeContext.Page.GetFullUrl(PathImage.GetRewrite(GetContentFromContext(FeContext.Page.Linkit_MetaImage, FeContext.Seo.SiteImage), 520, 280, true));
            //return PathImage.GetFullImage(GetContentFromContext(FeContext.Page.Linkit_MetaImage, FeContext.Seo.SiteImage));
        }
        [MethodInfo] protected string GetDescription() { return HttpUtility.HtmlEncode(GetContentFromContext(FeContext.Page.Linkit_PageDescription, FeContext.Seo.Description)); }
        [MethodInfo] protected string GetTags() { return GetContentFromContext(FeContext.Page.Linkit_Tags, GetKeywords()); }
        [MethodInfo] protected string GetSeeAlso() { return GetContentFromContext(FeContext.Page.Linkit_SeeAlso, string.Empty); }
        [MethodInfo] protected string GetPublishedTime() { return GetContentFromContext(FeContext.Page.Linkit_PublishedTime, DateTime.Now.ToString()); }
        [MethodInfo] protected string GetKeywords() { return GetContentFromContext(FeContext.Page.Linkit_PageKeyword, FeContext.Seo.Keyword); }
        #endregion

        #region Private
        private string GetContentFromContext(string key, string defaultValue)
        {
            var value = HttpContext.Current.Items[key];
            return value == null || value.ToString().IsNull() ? defaultValue : value.ToString();
        }
        #endregion

        public const string Link_Canonical_Template = "<link rel=\"canonical\" href=\"{0}\" />";
        public const string Script_Template = "{0}";

        public const string Favicon_Template = "<link rel=\"shortcut icon\" href=\"{0}\" type=\"image/x-icon\" />";

        public const string Meta_Template = "<meta {0}=\"{1}\" content=\"{2}\" />";


        protected string ResourceImage(string path) { return FeContext.GetResourceImage(path); }
        protected string Label(string lexicon) { return FeContext.Label.Get(lexicon); }
        protected string Url(string prefix) { return FeUrl.Get(prefix); }
        protected string ImageTag(object src, int w, int h, object title, bool isFix = false, bool crop = false, string cls = "")
        {
            return PathImage.GetImageTag(src, w, h, title, isFix, crop, cls);
        }
        protected string FullUrl(string url)
        {
            return FeContext.Page.GetFullUrl(url);
        }
    }
}
