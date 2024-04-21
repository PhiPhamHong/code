using Core.Attributes.Validators;
using Core.DataBase.ADOProvider.Attributes;
using Core.Web.WebBase.HtmlBuilders;
using Newtonsoft.Json;
using System;
using Core.Extensions;
using System.Collections.Generic;
using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.Utility;

namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.Companies, Name="Công ty")]
    public partial class Company : MainDb.Entity<Company>, IModel<int>, IEntityForLogShowName
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int CompanyId { set; get; }
        [Field(Name = "Mã công ty"), ValidatorRequire] public string CompanyCode { set; get; }
        [Field(Name = "Tên công ty"), DataTextField(Default = "-- Công ty --"), ValidatorRequire] public string Name { set; get; }
        [Field(Name = "Địa chỉ")] public string Address { set; get; }
        [Field] public string Email { set; get; }
        [Field(Name = "Điện thoại")] public string Phone { set; get; }
        [Field] public string Website { set; get; }
        [Field(Name = "Ghi chú")] public string Description { set; get; }
        [Field(Name = "Công ty cha")] public int ParentId { set; get; }

        [PropertyInfo(Name = "Công ty cha")]
        public int ParentCompanyId
        {
            set { ParentId = value; }
            get { return ParentId; }
        }

        [Field(Name = "Khóa")] public bool IsLock { set; get; }
        [Field(Name = "Tên miền")] public string SubDomain { set; get; }
        [Field, JsonIgnore] public int UserLock { set; get; }
        [Field(LogWhenChange = false), JsonIgnore] public DateTime? CreatedDate { set; get; }
        [Field(LogWhenChange = false), JsonIgnore] public int CreatedBy { set; get; }

        [Field(Name = "Tổng người dùng")] public int? MaxUser { set; get; }
        [Field(Name = "Tên miền sử dụng")] public string DomainUsed { set; get; }
        #endregion
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }

        public override void Save() => CompanyId = SelectFirstValue<int>(MainDbStore.sp_Companies_Save);
        public static IEnumerable<int> GetInParent(int parentId) => Inst.GetCompanyIdInParent(parentId);
        public IEnumerable<int> GetCompanyIdInParent(int parentId)
        {
            var table = ExeStore("sp_Companies_GetInParent", parentId);
            for (var i = 0; i < table.Rows.Count; i++)
                yield return table.Rows[i]["CompanyId"].To<int>();
        }
        public static string GetSubDomain(int companyId)
        {
            if (companyId != 0)
            {
                var company = new Company { CompanyId = companyId };
                company.GetByKey();
                return company.SubDomain;
            }
            else return string.Empty;
        }
        public static string GetSubDomain(string domainUsed) => Inst.SelectFirstValue<string>("sp_Companies_GetByDomainUsed", domainUsed);

        public int Key
        {
            get { return CompanyId; }
            set { CompanyId = value; }
        }
        public class DataSource : DataSource<Company>.Module
        {
            public string Name { set; get; }
            public int CompanyId { set; get; }

            public override List<Company> GetEntities() => Inst.ExeStoreToList<Company>(MainDbStore.sp_Companies_GetData, Name, CompanyId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>(MainDbStore.sp_Companies_GetData_Count, Name, CompanyId);
        }
    }
}