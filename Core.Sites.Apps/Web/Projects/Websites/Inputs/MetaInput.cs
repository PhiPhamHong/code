using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Inputs;
using Core.Sites.Apps.Web.Projects.Websites.FormMetas;
using Core.Web.WebBase;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Projects.Websites.Inputs
{
    public class MetaInput : SelectModel<Meta, MetaInput>
    {
        [CompanyInput.SelectData] protected int companyId { set; get; }
        public MetaInput CompanyId(int companyId) => Chain(t => t.companyId = companyId);
        [LanguageInput.SelectData] protected int languageId { set; get; }
        public MetaInput LanguageId(int languageId) => Chain(t => t.languageId = languageId);
        protected override IManageModulePermission GetManageModule() => new ManageMetas();
        protected override List<Meta> GetData() => new Meta.DataSource { CompanyId = companyId, LanguageId = languageId, FieldOrder = "CompanyId" }.GetEntities();
        
    }
}