
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Label = Core.Business.Entities.Websites.Label;

namespace Core.Sites.Apps.Web.Projects.Websites.FormLabels
{
    [Script(Src = "/Web/Projects/Websites/FormLabels/js/WebManageLabels.js")]
    [ManageModulePermission(Add = 22901, Edit = 22902, Delete = 22903)]
    [Module]
    public partial class WebManageLabels : ManageModule<Label, Label.Language, int, int, WebManageLabels.ModuleProvider, FormEditLabel, FormEditLabelLanguage>
    {
        public class ModuleProvider : ManageModuleProviderLanguage.Source<Label.DataSource>
        {
            protected override void ValidateHelper(Label t)
            {
                if (OldEntity == null)
                {
                    var chk = Label.Inst.HasExist(t.CompanyId, t.Lexicon);
                    if (chk == true)
                        throw new System.Exception("Từ " + t.Lexicon + " đã tồn tại!");

                }
            }
        }
    }
}