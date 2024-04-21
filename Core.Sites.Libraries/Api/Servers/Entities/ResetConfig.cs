using Core.Web.Api;


namespace Core.Sites.Libraries.Api.Servers.Entities
{
    public class ResetConfig
    {
        public class ByCompany
        {
            public class Request
            {
                public int CompanyId { set; get; }
            }

            public class Response : ResponseBase
            {

            }
        }
        public class ByServer
        {
            public class Request
            {
                public int CompanyId { set; get; }
            }

            public class Response : ResponseBase
            {

            }
        }
    }
}
