using Core.Business;
using Core.Business.Entities;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Utility.Language;
using Core.Extensions;
using System.Collections.Generic;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Modules.FormGroupUsers
{
    [Script(Src = "/Web/Modules/FormGroupUsers/js/ManageGroupUsers.js")]
    [ManageModulePermission(Add = 0, Edit = 0, Delete = 0)]
    [Module]
    public partial class ManageGroupUsers : ManageModule<GroupUser, ManageGroupUsers.ModuleProvider, FormEditGroupUser>
    {
        public class ModuleProvider : ManageModuleProvider<GroupUser, int>.Source<GroupUser.DataSource>
        {
            private ModelListSave<GroupUser.Leader> Leaders { set; get; }

            protected sealed override bool UseTransactionInSave => true;
            protected override void OnBeforeSave(GroupUser t)
            {
                Leaders = t.SplitItems<int, GroupUser.Leader>("leader");
                Leaders.Upserts.ForEach(leader =>
                {
                    var leaderCheck = leader.SelectFirst(l => l.UserId == leader.UserId);
                    if (leaderCheck != null && (t.GroupId == 0 || t.GroupId != leaderCheck.GroupId))
                    {
                        var group = new GroupUser { GroupId = leaderCheck.GroupId };
                        group.GetByKey();

                        var employee = new User { UserId = leader.UserId ?? 0 };
                        employee.GetByKey();

                        throw new ErrorMessageException(Const.M74, employee.Name, group.Name);
                    }
                });
            }
            sealed protected override void Save(GroupUser t, List<LogEntity> logEntities, IDataBaseService service)
            {
                t.InService(service).Save();
                Leaders.Save(t.GroupId, service, logEntities);
            }
        }
    }
}