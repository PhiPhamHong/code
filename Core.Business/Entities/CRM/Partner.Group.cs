using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.CRM
{
    public partial class Partner
    {
        [TableInfo(TableName = "[Partners.Groups]", Name = "Nhóm đối tác")]
        public class Group : MainDb.EntityAuthor<Group>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName, IVersion
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int GroupId { set; get; }
            [FieldSearch(Name = "Tên nhóm"), DataTextField(Default = "-- Nhóm khách--")] public string Name { set; get; }
            [FieldSearch(Name = "Màu")] public string Color { set; get; }
            [FieldSearch(Name = "Màu chữ")] public string TextColor { set; get; }
            [Field(Name = "Công ty")] public int CompanyId { set; get; }
            #endregion
            public int Key
            {
                set { GroupId = value; }
                get { return GroupId; }
            }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [Field] public int Version { set; get; }

            public class DataSource : DataSource<Group>.Module, ICompanyNeedValidate
            {
                public string Name { set; get; }
                public int CompanyId { set; get; }
                public override List<Group> GetEntities() => Inst.ExeStoreToList("sp_Partners_Groups_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Partners_Groups_GetData_Count", CompanyId, Name);
                
            }
        }
    }
}
