
using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;

namespace Core.Sites.Apps.Web.Projects.Websites.FormMetas
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormMetas/js/ManageMetas.js")]
    [ManageModulePermission(Add = 23101, Edit = 23102, Delete = 23103)]
    public partial class ManageMetas : ManageModule<Meta, Meta.Language, int, int, ManageMetas.ModuleProvider, FormEditMeta, FormEditMetaLanguage>
    {
        public class ModuleProvider : ManageMetas.ManageModuleProviderLanguage.Source<Meta.DataSource>
        {
            protected override void ValidateHelper(Meta t)
            {
                if (OldEntity == null)
                {
                    var chk = Meta.Inst.HasExist(t.CompanyId, t.AttributeName, t.AttributeValue);
                    if (chk == true)
                        throw new System.Exception("Thẻ " + t.AttributeName + " với thuộc tính " + t.AttributeValue + " đã tồn tại!");

                }
            }
        }
    }
}