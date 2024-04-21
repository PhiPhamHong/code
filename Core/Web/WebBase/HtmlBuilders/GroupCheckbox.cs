using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Extensions;
using Core.DataBase.ADOProvider;
namespace Core.Web.WebBase.HtmlBuilders
{
    public class GroupCheckbox<T, TChain> : Html<TChain> where TChain : GroupCheckbox<T, TChain> where T : ModelBase, new()
    {
        protected virtual List<T> GetData() { return DbTable<T>.GetAllToList(); }

        protected object[] value = null; public TChain Value(params object[] value) { return Chain(t => t.value = value); }
        protected int col = 2; public TChain Col(int col) { return Chain(t => t.col = col); }

        public override string ToString()
        {
            var typeT = typeof(T);
            var dvf = typeT.GetListPairPropertyAttribute<DataValueFieldAttribute>().FirstOrDefault();
            var dtf = typeT.GetListPairPropertyAttribute<DataTextFieldAttribute>().FirstOrDefault();

            var itemFormat = "<div class=\"col-xs-" + col + "\">{0}</div>";

            var data = Context.Get(Key, () => GetData());
            var values = value == null ? new string[] { } : value.Where(v => v != null).Select(v => v.ToString()).ToArray();
            return "<div class='row'>" + data.JoinString(item =>
            {
                var val = item.Eval(dvf.T1.Name).ToString();
                var chk = new Checkbox<T>().Name(dvf.T1.Name).Data("group", true).Value(val).PlaceHolder(item.Eval(dtf.T1.Name)).Checked(values.Contains(val));
                return itemFormat.Frmat(chk);
            }, string.Empty) + "</div>";
        }

        protected virtual string Key
        {
            get { return "Select_" + typeof(T).FullName; }
        }
    }

    public class GroupCheckbox<T> : GroupCheckbox<T, GroupCheckbox<T>> where T : ModelBase, new() { }
}
