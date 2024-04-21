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
        [TableInfo(TableName = "[Partners.Sources]", Name = "Nguồn đối tác")]
        public class Source : MainDb.EntityAuthor<Source>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            #region properties
            [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int SourceId { set; get; }
            [FieldSearch(Name = "Tên nguồn"), DataTextField(Default = "-- Nguồn khách --")] public string Name { set; get; }
            [FieldSearch(Name = "Màu")] public string Color { set; get; }
            [FieldSearch(Name = "Màu chữ")] public string TextColor { set; get; }
            [Field(Name = "Hệ số")] public float Factor { set; get; }
            [Field(Name = "Mã nguồn")] public string SourceCode { set; get; }
            [Field(Name = "Công ty")] public int CompanyId { set; get; }
            #endregion
            public int Key
            {
                set { SourceId = value; }
                get { return SourceId; }
            }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [Field] public int Version { set; get; }

            public class DataSource : DataSource<Source>.Module, ICompanyNeedValidate
            {
                public string Name { set; get; }
                public int CompanyId { set; get; }
                public override List<Source> GetEntities() => Inst.ExeStoreToList("sp_Partners_Sources_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Partners_Sources_GetData_Count", CompanyId, Name);

            }
        }
    }
}
