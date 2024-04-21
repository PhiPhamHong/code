using Core.Web.WebBase;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class FindColumnTrueFalseConfigChain : FindColumnConfigChain, IAjax
    {
        protected override ColumnConfig DoFind(string field, string format)
        {
            if (format == "TrueFalse")
            {
                var cc = new ColumnTrueFalseConfig
                {
                    TextTrue = this.Query<string>("TF_" + field + "_True"),
                    TextFalse = this.Query<string>("TF_" + field + "_False")
                };
                return cc;
            }
            return null;
        }
    }
}
