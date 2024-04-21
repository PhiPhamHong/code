using Core.FrontEnds.Libraries.Web.Caches;
using System.Collections.Generic;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web
{
    public partial class FeContext
    {
        public static LabelContext Label
        {
            get { return Get(() => new LabelContext(), "Label"); }
        }

        public class LabelContext
        {
            private Dictionary<string, string> dic = CacheLabels.Get(Url.LanguageId);
            public string Get(string lexicon)
            {
                return dic.TryGet(lexicon, lexicon);
            }
        }
    }
}
