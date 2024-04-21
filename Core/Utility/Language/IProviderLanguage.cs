namespace Core.Utility.Language
{
    public interface IProviderLanguage
    {
        string GetLabel(string lexicon);
    }

    public class ProviderNoneLanguage : IProviderLanguage
    {
        public string GetLabel(string lexicon)
        {
            return lexicon;
        }
    }
}
