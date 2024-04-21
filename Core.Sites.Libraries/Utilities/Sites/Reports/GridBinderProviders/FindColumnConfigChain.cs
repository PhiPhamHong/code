using Core.Utility.Patterns;
using Core.Web.WebBase;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public abstract class FindColumnConfigChain : Chain<FindColumnConfigChain>
    {
        protected abstract ColumnConfig DoFind(string field, string format);

        public ColumnConfig Find(string field, string format)
        {
            var cc = DoFind(field, format);
            if (cc == null && Handler != null) cc = Handler.Find(field, format);
            return cc;
        }

        private static FindColumnConfigChain inst = null;
        public static FindColumnConfigChain Inst
        {
            get
            {
                if (inst == null)
                {
                    inst = new FindColumnTrueFalseConfigChain();
                    inst.SetHandler<FindColumnDateConfigChain>();
                    inst.SetHandler<FindColumnTimeConfigChain>();
                    inst.SetHandler<FindColumnDateTimeConfigChain>();
                    inst.SetHandler<FindColumnMoneyConfigChain>();
                    inst.SetHandler<FindColumnHtmlConfigChain>();
                }
                return inst;
            }
        }

        public static ColumnConfig Execute(string field, string format)
        {
            var cc = Inst.Find(field, format) ?? new ColumnConfig();
            cc.FieldName = field;
            return cc;
        }
    }
}
