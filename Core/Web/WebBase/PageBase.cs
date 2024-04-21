using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using Core.Web.Extensions;
namespace Core.Web.WebBase
{
    public class PageBase : Page
    {
        protected virtual void InitData() { }

        protected void Page_Load(object sender, EventArgs e)
        {            
            InitData();
        }

        public T Query<T>(string key, T @default = default(T))
        {
            return this.Request.Query(key, @default);
        }
    }
}