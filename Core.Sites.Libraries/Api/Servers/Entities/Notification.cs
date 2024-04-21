using Core.Web.Api;


namespace Core.Sites.Libraries.Api.Servers.Entities
{
    public class Notification
    {
        public class Request
        {
            public int NotificationId { set; get; }
        }

        public class Response : ResponseBase
        {

        }
    }
}
