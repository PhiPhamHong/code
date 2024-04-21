using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Utility.Language;
namespace Core.Sites.Libraries.Utilities.Sites
{
    public class ProviderLanguage : IProviderLanguage
    {
        public string GetLabel(string lexicon)
        {
            return PortalContext.GetLabel(lexicon);
        }
    }
}