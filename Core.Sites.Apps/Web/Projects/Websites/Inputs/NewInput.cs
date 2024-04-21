using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Inputs;
using Core.Sites.Apps.Web.Projects.Websites.FormNews;
using Core.Web.WebBase;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Projects.Websites.Inputs
{
    public class NewInput : SelectModel<News, NewInput>
    {
        [CompanyInput.SelectData] protected int companyId { set; get; }
        public NewInput CompanyId(int companyId) => Chain(t => t.companyId = companyId);
        [LanguageInput.SelectData] protected int languageId { set; get; }
        public NewInput LanguageId(int languageId) => Chain(t => t.languageId = languageId);
        protected override IManageModulePermission GetManageModule() => new ManageNews();
        protected override List<News> GetData() => new News.DataSource { CompanyId = companyId, LanguageId = languageId, FieldOrder = "CreatedDate" }.GetEntities();
        
    }
}