using System.Collections.Generic;
using System.Web;
using Core.Extensions;
using System;
using Newtonsoft.Json;
namespace Core.Web.WebBase
{
    /// <summary>
    /// Message được dùng để truyền tải nội dung xuống client
    /// </summary>
    public class ResponseMessage
    {
        private string javaScript = string.Empty;
        /// <summary>
        /// JavaScript cần yêu cầu thực hiện xuống client
        /// </summary>
        public string JavaScript
        {
            get { return this.javaScript; }
            set { this.javaScript += value + ";"; }
        }

        private Dictionary<string, object> data = new Dictionary<string, object>();
        /// <summary>
        /// Data. Đối tượng kiểu mảng truyền xuống client
        /// </summary>
        public Dictionary<string, object> Data
        {
            get { return data; }
        }

        [JsonProperty("recordsTotal")]
        public int RecordsTotal { set; get; }

        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get { return RecordsTotal; } }

        /// <summary>
        /// Response mong muốn trả về tại thời điểm hiện thời
        /// </summary>
        public static ResponseMessage Current
        {
            get
            {
                // Lấy ra ResponseMessage ở trong Request hiện thời
                var response = HttpContext.Current.Items["ResponseMessage"] as ResponseMessage;

                // Nếu chưa có thì khởi tạo mời
                if (response == null) HttpContext.Current.Items["ResponseMessage"] = response = new ResponseMessage();

                // return
                return response;
            }
        }

        /// <summary>
        /// Gửi xuống một alert tới client
        /// </summary>
        /// <param name="msg"></param>
        public static void Alert(string msg)
        {
            Current.JavaScript = "Core.alert({0})".Frmat(msg.ToJson());
        }

        /// <summary>
        /// Cảnh báo
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        public static void Alert(string selector, string msg, AlertType type)
        {
            string tp = string.Empty;
            switch(type)
            {
                case AlertType.Danger: tp = "alertType.alertDanger"; break;
                case AlertType.Info: tp = "alertType.alertInfo"; break;
                case AlertType.Success: tp = "alertType.alertSuccess"; break;
                case AlertType.Warning: tp = "alertType.alertWarning"; break;
            }
            Current.JavaScript = "$('" + selector + "').coreAlert(" + msg.ToJson() + ", '', null, " + tp + ")";
        }

        /// <summary>
        /// Thiết lập một function chạy timeout
        /// </summary>
        /// <param name="func"></param>
        /// <param name="miliseconds"></param>
        public static void SetTimeout(string func, int miliseconds)
        {
            Current.JavaScript = "setTimeout(function() { " + func + ";}, " + miliseconds + ")";
        }
    }

    public enum AlertType
    {
        Danger,
        Info,
        Warning,
        Success
    }
}
