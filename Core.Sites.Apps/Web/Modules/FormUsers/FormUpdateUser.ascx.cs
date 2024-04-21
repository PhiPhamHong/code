using Core.Business.Entities;
using Core.Extensions;
using System.Linq;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.DataBase.ADOProvider.Attributes;
using System.Collections.Generic;
using Core.DataBase.ADOProvider;

namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    [Script(Src = "/Web/Modules/FormUsers/js/FormUpdateUser.js")]
    [Module]
    public partial class FormUpdateUser : FormEdit<User, FormUpdateUser.ModuleProvider>
    {
        protected override User GetForEdit() => User.Inst.SelectToList(u => u.UserId == PortalContext.CurrentUser.User.UserId).FirstOrDefault();

        public class ModuleProvider : ManageModuleProvider<User>
        {
            protected override void Save(User t, List<LogEntity> logEntities, IDataBaseService service)
            {
                if (t.Password.IsNotNull()) t.Password = t.Password.EncryptPassword();
                t.UserId = PortalContext.CurrentUser.User.UserId;
                t.CompanyId = PortalContext.CurrentUser.CurrentCompanyId;
                t.UpdateInfo();
            }
        }
    }
}