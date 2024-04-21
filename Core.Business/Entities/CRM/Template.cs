using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[Templates]", Name = "Mẫu LandingPage")]
    public class Template : MainDb.EntityAuthor<Template>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true)] public int TemplateId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tên"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Mô tả")] public string Description { get; set; }
        [Field(Name = "Avatar"), ValidatorRequire] public string Avatar { get; set; }
        [Field(Name = "Content"), ValidatorRequire] public string Design { get; set; }
        [Field(Name = "Đóng góp cho các đơn vị khác")] public bool IsPublished { get; set; }
        [Field(Name = "Đơn vị đóng góp")] public string Author { get; set; }
        public int Key
        {
            get { return TemplateId; }
            set { TemplateId = value; }
        }

        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        public class DataSource : DataSource<Template>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public override List<Template> GetEntities() => Inst.ExeStoreToList("sp_Templates_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
            
        }
        public class SourceChoose : DataSource<Template>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public override List<Template> GetEntities() => Inst.ExeStoreToList("sp_Templates_GetDataForChoose", CompanyId);
            public override int GetTotal() => CurrentData.Count;
        }
        
    }
}
