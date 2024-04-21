using Core.Utility.Language;
namespace Core.FrontEnds.Libraries.Web
{
    public class LanguageProvider : IProviderLanguage
    {
        public string GetLabel(string lexicon)
        {
            return FeContext.Label.Get(lexicon);
        }
    }
}
