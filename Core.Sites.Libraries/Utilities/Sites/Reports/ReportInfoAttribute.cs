using System;

namespace Core.Sites.Libraries.Utilities.Sites.Reports
{
    /// <summary>
    /// Thông tin về báo cáo
    /// </summary>
    public class ReportInfoAttribute : Attribute
    {
        /// <summary>
        /// Tiêu đề báo cáo
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// Kiểu bind dữ liệu vào Excel
        /// </summary>
        public ExcelBinderType BinderType { set; get; }

        private bool autoAscending = true;
        /// <summary>
        /// Có tự động tăng dần hay không
        /// </summary>
        public bool AutoAscending
        {
            get { return autoAscending; }
            set { autoAscending = value; }
        }
    }
}
