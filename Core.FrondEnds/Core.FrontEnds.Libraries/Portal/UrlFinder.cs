using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Portal
{
    public class UrlFinder
    {
        public class ContextSearch
        {
            public int LanguageId { set; get; }
            public string Url { set; get; }      // Url gốc ban đầu
            public string UrlFound { set; get; } // Url đang được tìm
            public Dictionary<string, object> Params { set; get; } = new Dictionary<string, object> { };
        }
        public abstract class Process
        {
            public ContextSearch Context { set; get; }
            public virtual bool Require { get { return false; } } // Trên URL có cũng được, không có cũng được
            public abstract bool Searching();

            public abstract class ByRegexBase : Process
            {
                public abstract string Expression { get; }

                protected abstract bool Match(Match match);

                sealed public override bool Searching()
                {
                    var regex = new Regex("^" + Context.UrlFound + Expression);
                    var match = regex.Match(Context.Url);
                    if (match.Success)
                    {
                        var ok = Match(match);
                        if (ok) Context.UrlFound = match.Groups[0].Value;
                        return ok;
                    }

                    return false;
                }
            }
            public class ByRegex : ByRegexBase
            {
                public Action<Match> Result { set; get; }
                sealed public override string Expression
                {
                    get { return Exp; }
                }

                public string Exp { set; get; }
                protected override bool Match(Match match)
                {
                    Result?.Invoke(match);
                    return true;
                }
            }
        }

        public UrlFinder(string url)
        {
            Context.Url = url;
        }

        public ContextSearch Context { set; get; } = new ContextSearch { };
        protected List<Process> Finders { set; get; } = new List<Process> { };

        public void AddFinder<TFinder>(Action<TFinder> finder = null) where TFinder : Process, new()
        {
            var process = new TFinder { Context = Context };
            Finders.Add(process);
            finder?.Invoke(process);
        }

        public bool Ok
        {
            get { return Context.Url == Context.UrlFound && Context.Params.Count > 0; }
        }

        public string Query
        {
            get { return Context.Params.JoinString(p => p.Key + "=" + p.Value, "&"); }
        }

        public void Run()
        {
            foreach (var finder in Finders)
            {
                var result = finder.Searching();
                if (finder.Require && !result) return;
            }
        }
    }
}
