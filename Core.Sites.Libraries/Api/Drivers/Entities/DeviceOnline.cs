using Core.Web.Api;


namespace Core.Sites.Libraries.Api.Drivers.Entities
{
    public class GetDeviceOnline
    {
        public class Request
        {
            public int TargetId { set; get; }
            public int DeviceId { set; get; }
        }

        public class Response : ResponseBase
        {
            //public Device DeviceOnline { set; get; } Chưa có cấu hình máy
        }
    }
    public class GetListDeviceOnline
    {
        public class Request
        {
            public int TargetId { set; get; }
        }

        public class Response : ResponseBase
        {
            //public List<Device> DeviceOnlines { set; get; } Chưa có cấu hình máy (lấy theo địa chỉ cài đặt, list tất cả các máy đã đăng ký)
        }
    }
}
