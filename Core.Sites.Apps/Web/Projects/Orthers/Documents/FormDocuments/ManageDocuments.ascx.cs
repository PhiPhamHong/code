using Core.Business.Entities;
using Core.Business.Entities.Others.Documents;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;


namespace Core.Sites.Apps.Web.Projects.Orthers.Documents.FormDocuments
{
    [Module]
    [Script(Src = "/Web/Projects/Orthers/Documents/FormDocuments/js/ManageDocuments.js")]
    [ManageModulePermission(Add = Per.P_53001, Edit = Per.P_53002, Delete = Per.P_53003)]
    public partial class ManageDocuments : ManageModule<Document, Document.Language, int, int, ManageDocuments.ModuleProvider, EditDocument, EditDocumentLanguages>
    {
        public class ModuleProvider : ManageModuleProviderLanguage.Source<Document.DataSource> 
        {

        }
    }
}