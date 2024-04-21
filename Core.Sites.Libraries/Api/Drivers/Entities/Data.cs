using Core.Web.Api;
using System;

namespace Core.Sites.Libraries.Api.Drivers.Entities
{
    public partial class Data
    {
        public class Flow
        {
            public class Request
            {
                public int TargetId { get; set; } // Địa chỉ cần cài đặt()
                public int DeviceId { get; set; } // Thiết bị
                public string DataType { set; get; } // Loại dữ liệu (json, xml, text, v.v)
                public int EmployeeId { set; get; }
                public string EmployeeName { set; get; }
                public string EmployeeCode { set; get; }
                public DateTime? Time { get; set; }
                public int Status { get; set; } // Trạng thái dữ liệu
            }

            public class Response : ResponseBase
            {

            }
        }


        public class Send
        {
            public class Request
            {
                public int TargetId { get; set; } // Địa chỉ cần cài đặt()
                public int DeviceId { get; set; } // Thiết bị
                public string DataType { set; get; } // Loại dữ liệu (json, xml, text, v.v)
                public int EmployeeId { set; get; }
                public string EmployeeName { set; get; }
                public string EmployeeCode { set; get; }
                public DateTime? Time { get; set; }
                public int Status { get; set; } // Trạng thái dữ liệu
            }

            public class Response : ResponseBase
            {

            }
        }
    }
}
