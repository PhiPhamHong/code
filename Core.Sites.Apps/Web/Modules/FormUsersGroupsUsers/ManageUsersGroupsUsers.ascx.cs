using Core.Attributes;
using Core.Business;
using Core.Business.Entities;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Modules.FormUsersGroupsUsers
{
    [Script(Src = "/Web/Modules/FormUsersGroupsUsers/js/ManageUsersGroupsUsers.js")]
    [ManageModulePermission]
    [Module]
    public partial class ManageUsersGroupsUsers : ManageModule<GroupUser.User, ManageUsersGroupsUsers.ModuleProvider, FormEditUsersGroupsUser>
    {
        public class ModuleProvider : ManageModuleProvider<GroupUser.User, int>.Source<GroupUser.User.DataSource>
        {
            public bool ByTab { set; get; }
            public override GroupUser.User GetByKey(GroupUser.User t) => base.GetByKey(t) ?? new GroupUser.User
            {
                FromDate = DateTime.Today,
                GroupId = t.GroupId
            };

            protected override void ValidateDeleteHelper(GroupUser.User t)
            {
                if (GroupUser.User.Inst.CheckConflictDate(t.GroupUserId, t.UserId.Value, t.FromDate.Value))
                    throw new Exception("Nhân viên này đã tồn tại nhóm hoạt động từ ngày này rồi!");
            }

            protected override void Save(GroupUser.User t, List<LogEntity> logEntities, IDataBaseService service)
            {
                t.InService(service).Upsert();
                t.InService(service).UpdateToDate(t.UserId.Value);
            }

            protected override void Delete(GroupUser.User t)
            {
                ShTransaction.Do<MainDb.Service>(service =>
                {
                    t.InService(service).Delete();
                    if (t.UserId != null)
                        t.InService(service).UpdateToDate(t.UserId.Value);
                });
            }
        }

        public enum ViewHistory
        {
            [ViewHistory(Name = "Theo ngày")] ViewByDate = 0,
            [ViewHistory(Name = "Lịch sử")] History = 1
        }
        public class ViewHistoryAttribute : FieldInfoAttribute { }
        public class ViewHistoryInput : SelectEnum<ViewHistory, ViewHistoryInput> { }
    }
}