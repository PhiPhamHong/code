using System;
using System.Linq;
using System.Collections.Generic;
using Core.Extensions;
using Core.Utility;
namespace Core.Web.WebBase.HtmlBuilders
{
    public abstract class Html<TChain> : IHtml where TChain : class
    {
        protected TChain Chain(Action<TChain> action)
        {
            var t = this as TChain;
            action(t);
            return t;
        }

        protected Dictionary<string, object> data = new Dictionary<string, object>();
        public TChain Data(string name, object data)
        {
            return Chain(t => this.data[name] = data);
        }

        protected string GetDataAttribute()
        {
            return data.Where(item => item.Value != null).JoinString(d => "data-" + d.Key + "=\"" + d.Value + "\"", " ");
        }

        public TChain Keydown(params Key[] keys)
        {
            return Chain(t => data["hot-keys"] = keys.GetString());
        }
    }

    public interface IHtml { }
}
