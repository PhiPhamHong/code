using Core.Business.Entities.Websites;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;


namespace Core.Sites.Apps.Web.Projects.Websites.FormNews.FormNewFiles
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormNews/FormNewFiles/js/ManageNewFiles.js")]
    [ManageModulePermission(Add = 22801, Edit = 22802, Delete = 22803)]
    public partial class ManageNewFiles : ManageModule<News.File, ManageNewFiles.ModuleProvider, EditNewFiles>, IAjax
    {
        protected override void OnInitData()
        {
            this.SetData("ByTab", Provider.ByTab);
        }
        public class ModuleProvider : ManageModuleProvider<News.File, int>.Source<News.File.DataSource>
        {
            public bool ByTab { set; get; }
            public override News.File GetByKey(News.File t) => base.GetByKey(t) ?? new News.File
            {
                CompanyId = t.CompanyId,
                NewsId = t.NewsId
            };
        }
    }
}