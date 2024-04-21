using Core.FrontEnds.Libraries.Portal.Configs;
using Core.Web.WebBase;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using Core.Extensions;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace Core.FrontEnds.Libraries.Portal
{
    public abstract class PortalPage<TPagesConfig> : PageBase where TPagesConfig : PagesConfig, new()
    {
        private PageTag currentPageTag = null;
        /// <summary>
        /// PageTag đang được thực hiện
        /// </summary>
        private PageTag CurrentPageTag
        {
            get
            {
                if (currentPageTag == null) currentPageTag = HttpContext.Current.Items["PageTag"] as PageTag;
                return currentPageTag;
            }
        }

        protected sealed override void InitData()
        {
            BeforeInit();
            RenderPage();
        }

        protected virtual void BeforeInit() { }

        /// <summary>
        /// Thực hiện render Page
        /// </summary>
        private void RenderPage()
        {
            // Thiết lập tiêu đề cho website
            Page.Title = CurrentPageTag.Title;

            // Kiểm tra nếu có một cột duy nhất thì không cần tạo cột
            // thực hiện load control luôn
            if (CurrentPageTag.Columns.Count == 1 && CurrentPageTag.Columns[0].Columns.Count == 0 && CurrentPageTag.Columns[0].Id.IsNull())
            {
                // Thực hiện Load Module
                RenderModule(CurrentPageTag.Columns[0], Container);

                // Thoát khỏi hàm render
                return;
            }

            // Ngăn xếp dùng chứa các cột cần duyệt, mục đích là khử đệ quy
            // Và ngăn xếp dùng chứa các cột, các cột cấu trúc phân cột như table
            var stack = new Stack<ColumnTag>();
            var stackContainer = new Stack<Control>();

            // Duyệt qua tất cả các cột chính mà page có            
            CurrentPageTag.Columns.OrderBy(c => c.Stt).ForEach(c =>
            {
                // Đưa vào ngăn xếp để tiếp tục duyệt các cột con nếu có
                stack.Push(c);

                // Đưa vào ngăn xếp vùng mà cột đang duyệt sẽ cần phải đưa vào
                stackContainer.Push(Container);

                // Vòng lặp, lấy ra tất cả các cột cần duyệt để tạo module
                while (!stack.Count.Equals(0))
                {
                    // Lấy ra cột cần xử lý và Lấy ra container chứa cột đang cần xử lý
                    var column = stack.Pop();
                    var containerContent = stackContainer.Pop();

                    // Tạo cột
                    var divColumn = new HtmlGenericControl(column.Tag.IsNull() ? "div" : column.Tag);

                    // Tạo Id
                    if (!column.Id.IsNull()) divColumn.Attributes.Add("id", column.Id);

                    // Tạo class css cho cột nếu có, mặc định là có class f_l, nghĩa là float:left
                    // Đưa cột vừa tạo vào vùng trên trang
                    divColumn.Attributes.Add("class", "{0}".Frmat(column.Css.IsNull() ? string.Empty : "{0}".Frmat(column.Css)));
                    containerContent.Controls.Add(divColumn);

                    // Cột con
                    var columns = column.Columns.OrderBy(cc => cc.Stt).ToList();

                    // Lại duyệt tất cả các cột con đưa vào ngăn xếp để xử lý tiếp
                    for (int j = columns.Count - 1; j >= 0; j--)
                    {
                        stack.Push(columns[j]);
                        stackContainer.Push(divColumn);
                    }

                    // Render Module nếu có
                    RenderModule(column, divColumn);
                }
            });
        }

        /// <summary>
        /// Thực hiện Load Control vào một vùng div
        /// </summary>
        /// <param name="moduleTag"></param>
        /// <param name="divContent"></param>
        private void RenderModule(ColumnTag column, Control divContent)
        {
            column.Modules.OrderBy(m => m.Stt).ForEach(m =>
            {
                if (string.IsNullOrEmpty(m.Path)) m.Path = "~/Common/Modules/ModuleLoader.ascx";
                var module = LoadControl(m.Path) as Module;
                if (m.Settings != null) module.Parse(m.Settings.ToDictionary(a => a.Name, a => (object)a.Value), false);
                module.Parse(Request.QueryString, false);
                module.InitData();
                divContent.Controls.Add(module);
            });
        }

        /// <summary>
        /// Một vùng cần load control vào
        /// </summary>
        protected abstract Control Container { get; }
    }
}
