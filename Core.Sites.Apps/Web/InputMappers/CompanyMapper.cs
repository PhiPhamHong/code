using Core.Attributes;
using Core.Business.Entities;

namespace Core.Sites.Apps.Web.InputMappers
{
    /// <summary>
    /// Map Id công ty ra tên công ty
    /// </summary>
    public class CompanyMapper : PropertyMapper<int>
    {
        protected override string Map(int value)
        {
            if (value == 0) return string.Empty;
            var company = new Company { CompanyId = value };
            company.GetByKey();
            return company.Name;
        }
    }

    public class CompanyMapperAttribute : PropertyMapperAttribute
    {
        public CompanyMapperAttribute() : base(typeof(CompanyMapper)) { }
    }
}