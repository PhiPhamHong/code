using Core.Attributes;
using Core.Business.Entities;
using Core.Business.Entities.CRM;
using Core.DataBase.ADOProvider;
using Core.Extensions;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches.Previews;
using System.Collections.Generic;
using System.Linq;

namespace Core.FrontEnds.Libraries.UrlEngines.Previews
{
    public class UrlPreviewEngine : IUrlEngine
    {
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            var urlFinder = new UrlFinder(urlVitural);
            urlFinder.AddFinder<FindDefaultKeyword>();
            urlFinder.AddFinder<FindType>();

            urlFinder.Run();
            if (urlFinder.Ok && urlFinder.Context.Params.Count > 1)
            {
                var param = urlFinder.Context.Params;
                result.Query = GetQuery(urlFinder.Query).JoinString(s => s, "&");
                

                var type = param.TryGet("Type").To<string>();
                if(type == "Landing")
                {
                    result.Meta = new Meta 
                    {
                        Title = "Xem trước giao diện landing page",
                        MetaDescription = "Xem trước giao diện landing page, Trang xem trước",
                        MetaKeywords = "Xem trước, Preview, Landingpage",
                        Image = ""
                    };

                    var ladiId = param.TryGet("LandingId").To<int>();
                    FeContext.Url.Preview.Type = LinkType.Landing;
                    var ladi = new LandingPage { LandingId = ladiId };
                    ladi.GetByKey();
                    FeContext.Url.Preview.Landing = ladi;
                }
                else
                {
                    result.Meta = new Meta
                    {
                        Title = "Xem trước giao diện Template mẫu",
                        MetaDescription = "Xem trước giao diện Template, Trang xem trước",
                        MetaKeywords = "Xem trước, Preview, Template",
                        Image = ""
                    };
                    var tempId = param.TryGet("TemplateId").To<int>();
                    FeContext.Url.Preview.Type = LinkType.Template;
                    var temp = new Template { TemplateId = tempId };
                    temp.GetByKey();
                    FeContext.Url.Preview.Template = temp;
                }

                FeContext.Url.LanguageId = 2;
                var lang = new Language { LanguageId = 2 };
                lang.GetByKey();
                FeContext.Url.Language = lang;
            }
        }
        private IEnumerable<string> GetQuery(string Query)
        {
            yield return "prefix=" + "Preview&" + Query;
        }


        public class FindDefaultKeyword : UrlFinder.Process
        {
            public override bool Searching()
            {
                var keyTempalte = "template-";
                var keyLanding = "landing-";
                if (Context.Url.StartsWith(keyTempalte))
                {
                    Context.UrlFound = keyTempalte;
                    Context.Params["Type"] = LinkType.Template;
                    Context.Params["langId"] = 2;
                    return true;
                }
                else if (Context.Url.StartsWith(keyLanding))
                {
                    Context.UrlFound = keyLanding;
                    Context.Params["Type"] = LinkType.Landing;
                    Context.Params["langId"] = 2;
                    return true;
                }

                return false;
            }
        }
        public class FindType : UrlFinder.Process
        {
            public override bool Searching()
            {
                if (!string.IsNullOrEmpty(Context.UrlFound))
                {
                    var type = Context.Params.TryGet("Type").To<string>();
                    if (type == "Landing")
                    {
                        var ladis = LandingPage.Inst.GetAllToList();
                        foreach (var ladi in ladis)
                        {
                            var urlhope = Context.UrlFound + (ladi.CompanyId + "vs" + ladi.LandingId);
                            if (Context.Url.StartsWith(urlhope))
                            {
                                Context.Params["LandingId"] = ladi.LandingId;
                                Context.UrlFound = urlhope;
                                return true;
                            }

                        }
                    }
                    else if(type == "Template")
                    {
                        var temps = CacheTemplates.GetData();
                        foreach (var temp in temps)
                        {
                            var urlhope = Context.UrlFound + (temp.CompanyId + "vs" + temp.TemplateId);
                            if (Context.Url == urlhope)
                            {
                                Context.Params["TemplateId"] = temp.TemplateId;
                                Context.UrlFound = urlhope;
                                return true;
                            }
                        }
                        temps = Template.Inst.GetAllToList();
                        foreach (var temp in temps)
                        {
                            var urlhope = Context.UrlFound + (temp.CompanyId + "vs" + temp.TemplateId);
                            if (Context.Url == urlhope)
                            {
                                Context.Params["TemplateId"] = temp.TemplateId;
                                Context.UrlFound = urlhope;
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }

    public class Meta : IPageMeta
    {
        public string Title { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string Image { get; set; }
    }
    public enum LinkType : int
    {
        [FieldInfo(Name = "Template")] Template = 1,
        [FieldInfo(Name = "Landing Page")] Landing = 2
    }
}
