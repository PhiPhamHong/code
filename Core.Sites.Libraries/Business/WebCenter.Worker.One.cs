using Core.Business.Entities;

namespace Core.Sites.Libraries.Business
{
    public partial class WebCenter
    {
        public partial class Worker
        {
            public partial class One : SSERPOneSecond
            {
                public One(Company company, CompanyConfig config)
                {
                    CompanyId = company.CompanyId;
                    Config = config;
                    Add<Send.Email>(); //Send email
                }
            }
        }
    }
}