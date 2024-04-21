
using Fizzler.Systems.HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using ShHtmlDocument = HtmlAgilityPack.HtmlDocument;
using System;

namespace Core.Utility.Spiders
{
    public class Spider
    {
        private ShHtmlDocument document;
        private WebRequest web = null;

        public int TotalTry { set; get; }

        public string Url
        {
            set 
            {
                if (web == null) web = new WebRequest();
                var i = 0;
                while (true)
                {
                    try
                    {
                        web.Get(value);
                        break;
                    }
                    catch(Exception ex)
                    {
                        i++;
                        if (i >= TotalTry) throw ex;
                    }
                }
                Html = web.Content;
            }
        }
        public HtmlAgilityPack.HtmlNode DocumentNode
        {
            get { return document.IsNull() ? null : document.DocumentNode; }
        }
        public string Html
        {
            set
            {
                if (document == null) document = new ShHtmlDocument();
                document.LoadHtml(value);
            }
            get
            {
                return document == null ? string.Empty : document.DocumentNode.OuterHtml;
            }
        }

        public IEnumerable<HtmlAgilityPack.HtmlNode> Select(string selectorChain) { return document.DocumentNode.QuerySelectorAll(selectorChain); }
        public List<HtmlAgilityPack.HtmlNode> SelectList(string selectorChain) { return Select(selectorChain).ToList(); }

        public IEnumerable<HtmlAgilityPack.HtmlNode> Select(HtmlAgilityPack.HtmlNode node, string selectorChain)
        {
            return node.QuerySelectorAll(selectorChain);
        }
        public List<HtmlAgilityPack.HtmlNode> SelectList(HtmlAgilityPack.HtmlNode node, string selectorChain)
        {
            return Select(node, selectorChain).ToList();
        }
    }
}