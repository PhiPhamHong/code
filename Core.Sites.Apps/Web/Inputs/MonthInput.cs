using System.Collections.Generic;
using System.Linq;
using Core.Sites.Libraries.Business;
using Core.DataBase.ADOProvider;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Inputs
{
    public class MonthInput : SelectModel<MonthInput.Month, MonthInput>
    {
        public MonthInput()
        {
            DisableSearch(true);
        }

        protected override List<Month> GetData()
        {
            return Enumerable.Range(1, 12).Select(i => new Month { Value = i, Text = PortalContext.GetLabel("Tháng " + i) }).ToList();
        }

        public class Month : ModelBase
        {
            [DataValueField]
            public int Value { set; get; }

            [DataTextField]
            public string Text { set; get; }
        }
    }
}