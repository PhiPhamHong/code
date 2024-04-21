using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.Extensions;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using System.Linq;


namespace Core.Sites.Apps.Web.Projects.Websites.FormSeo
{
    [Script(Src = "/Web/Projects/Websites/FormSeo/js/FormEditSeo.js")]
    [Module]
    public partial class FormEditSeo : FormEdit<Seo, Seo.Language, int, int, FormEditSeo.ModuleProvider, FormEditSeoLanguage>
    {
        protected override Seo GetForEdit()
        {
            return Provider.GetOneSeo();
        }

        public class ModuleProvider : ManageModuleProvider<Seo, Seo.Language, int, int>
        {
            public int CompanyId
            {
                get { return PortalContext.CurrentUser.CurrentCompanyId; }
            }

            protected override void ValidateHelper(Seo t)
            {
                var old = GetOneSeo();
                if (old != null) t.SeoId = old.SeoId;
                t.CompanyId = CompanyId;
            }
            protected override void BeforeSave(Seo t)
            {
                t.CompanyId = CompanyId;
                base.BeforeSave(t);
            }

            public Seo GetOneSeo()
            {
                return Seo.Inst.GetAllToList().FirstOrDefault(s => s.CompanyId == CompanyId);
            }
        }
    }
}