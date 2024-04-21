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
        [TableInfo(TableName = "[Partners.Types]", Name = "Loại đối tác")]
        public class Type : MainDb.EntityAuthor<Type>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int TypeId { set; get; }
            [FieldSearch(Name = "Tên loại"), DataTextField(Default = "-- Loại khách --")] public string Name { set; get; }
            [FieldSearch(Name = "Màu")] public string Color { set; get; }
            [FieldSearch(Name = "Màu chữ")] public string TextColor { set; get; }
            [Field(Name = "Công ty")] public int CompanyId { set; get; }
            #endregion
            public int Key
            {
                set { TypeId = value; }
                get { return TypeId; }
            }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [Field] public int Version { set; get; }

            public class DataSource : DataSource<Type>.Module, ICompanyNeedValidate
            {
                public string Name { set; get; }
                public int CompanyId { set; get; }
                public override List<Type> GetEntities() => Inst.ExeStoreToList("sp_Partners_Types_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Partners_Types_GetData_Count", CompanyId, Name);

            }
        }
    }
}
