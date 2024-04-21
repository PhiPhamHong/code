using Core.Web.Api;

namespace Core.Sites.Libraries.Api.Drivers.Entities
{
    public class Power
    {
        public class Request
        {
            public int TargetId { set; get; } //Địa chỉ cần cài đặt()
            public int DeviceId { set; get; } //Thiết bị
            public bool Open { get; set; } // Mở or Đóng
        }

        public class Response : ResponseBase { }
    }
}
