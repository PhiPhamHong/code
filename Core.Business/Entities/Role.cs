using Core.DataBase.ADOProvider.Attributes;
using Core.Web.WebBase.HtmlBuilders;
using Core.DataBase.ADOProvider;
namespace Core.Business.Entities
{
    [TableInfo(TableName = "[User.Roles]",Name="Quyền")]
    public class Role : MainDb.Entity<Role>, IModel<int>, IEntityForLogShowName
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int RoleId { set; get; }
        [Field(Name = "Vai trò"), DataTextField(Default = "-- Vai trò --")] public string Name { set; get; }
        #endregion

        public int Key
        {
            get { return RoleId; }
            set { RoleId = value; }
        }
    }
}