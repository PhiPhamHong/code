using System;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;

namespace Core.Sites.Apps.Web.Modules.FormLabels
{
    [Script(Src = "/Web/Modules/FormLabels/js/ManageLabels.js")]
    [ManageModulePermission(Add = 2801, Edit = 2802, Delete = 2803)]
    [Module]
    public partial class ManageLabels : ManageModule<Label, LabelLanguage, int, int, ManageLabels.ModuleProvider, FormEditLabel, FormEditLabelLanguage>
    {
        public class ModuleProvider : ManageModuleProviderLanguage.Source<Label.DataSource>
        {
            protected override void ValidateHelper(Label t)
            {
                if (Label.Inst.CheckExistsLexicon(t.LabelId, t.CompanyId, t.Lexicon))
                    throw new Exception("Từ vựng đã tồn tại");
            }
        }
    }
}