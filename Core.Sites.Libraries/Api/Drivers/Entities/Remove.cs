using Core.Web.Api;


namespace Core.Sites.Libraries.Api.Drivers.Entities
{
    public class RemoveDevice
    {
        public class Request
        {
            public int TargetId { set; get; }
            public int DeviceId { set; get; }
        }

        public class Response : ResponseBase
        {

        }
    }

    public class RemoveTarget
    {
        public class Request
        {
            public int TargetId { set; get; }
        }

        public class Response : ResponseBase
        {

        }
    }
}
