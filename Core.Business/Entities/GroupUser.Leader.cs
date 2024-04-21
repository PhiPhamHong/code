using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities
{
    public partial class GroupUser
    {
        [TableInfo(TableName = "[Users.Groups.Leaders]", Name = "Trưởng nhóm")]
        public class Leader : MainDb.Entity<Leader>, IModel<int>, IModelForeign<int, Leader>, IEmpty, IEntityForLogShowNameByRef
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true)] public int GroupLeaderId { set; get; }
            [Field] public int GroupId { set; get; }
            [Field(Name = "Trưởng nhóm", TypeRef = typeof(User))] public int? UserId { set; get; }
            [Field] public string Note { set; get; }
            #endregion

            public string UserName { set; get; }

            public int Key { get => GroupLeaderId; set => GroupLeaderId = value; }
            public int KeyForeign { get => GroupId; set => GroupId = value; }
            public int Stt { set; get; }
            public bool IsEmpty => UserId == null || UserId == 0;

            public List<Leader> GetDetails(int key) => ExeStoreToList("sp_Users_Groups_Leaders_GetItems", key);

            public int NameKey => UserId ?? 0;
            public Type TypeNameKey => typeof(User);

            public bool Editted { set; get; }
        }
    }
}
