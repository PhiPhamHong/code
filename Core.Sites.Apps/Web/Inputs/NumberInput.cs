using Core.DataBase.ADOProvider;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;
using System.Linq;

namespace Core.Sites.Apps.Web.Inputs
{
    public class NumberInput : SelectModel<NumberInput.Item, NumberInput>
    {
        [SelectData("From")]
        protected int from { set; get; }
        public NumberInput From(int from) { return Chain(t => t.from = from); }

        [SelectData("To")]
        protected int to { set; get; }
        public NumberInput To(int to) { return Chain(t => t.to = to); }

        public NumberInput()
        {
            DisableSearch(true);
        }

        protected override List<Item> GetData()
        {
            return Enumerable.Range(from, to).Select(i => new Item { Value = i, Text = i.ToString() }).ToList();
        }

        public class Item : ModelBase
        {
            [DataValueField] public int Value { set; get; }
            [DataTextField] public string Text { set; get; }
        }
    }
}