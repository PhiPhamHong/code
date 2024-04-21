using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities.Log;
using Core.Web.WebBase;
using Core.Extensions;
using System.Collections.Generic;
using Core.DataBase.ADOProvider.Attributes;
using System.Web.UI.WebControls;
using System;
using System.Linq;
using Core.Web.Extensions;
namespace Core.Sites.Apps.Web.Projects.LogActions.Reports
{
    [Script(Src = "Web/Projects/LogActions/Reports/js/FromViewLogActionDetail.js")]
    [Module]
    public partial class FromViewLogActionDetail : PortalModule<Log>, IAjax
    {
        protected override void OnInitData()
        {
            Entity = this.ParseParamTo<Log>(true);
            var data = Entity.Content.JsonToObject<List<LogEntity>>();
            data.BindTo(rpnote);
        }

        protected void rpnote_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            var details = e.Item.DataItem.As<LogEntity>().Details;
            if (details.Count == 0) return;
            details.BindTo(e.Find<Repeater>("rpDetail"));
        }

        public void GetLogField()
        {
            var type = Type.GetType(this.Query("type"));
            if (type.IsNull()) return;

            var values = this.Query("values");
            if (values.IsNull()) return;

            var vs = values.Split(',').Where(v => v.IsNotNull()).Distinct();

            var fca = type.GetAttribute<FieldConverterAttribute>();

            FieldConverter fc = null;
            if (fca != null && fca.Type != null)
            {
                fc = fca.Type.CreateInstance<FieldConverter>();
                fc.Type = type;
            }
            else
            {
                if (type.IsEnum) fc = new FieldConverter.Enum { };
                else if (type.CompareType(typeof(FieldConverter))) fc = type.CreateInstance<FieldConverter>();
                else fc = new FieldConverter.Default { };

                fc.Type = type;
            }
            this.SetData("Results", vs.ToDictionary(v => v, v => fc.GetName(v, null)));
        }
    }
}
