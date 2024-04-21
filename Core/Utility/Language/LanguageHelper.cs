using System.Configuration;
using Core.Extensions;
using System;

namespace Core.Utility.Language
{
    public class LanguageHelper
    {
        private static IProviderLanguage CreateProviderLanguage()
        {
            try
            {
                return ConfigurationManager.AppSettings["LanguageHelper"].CreateInstance<IProviderLanguage>();
            }
            catch
            {
                return new ProviderNoneLanguage();
            }
        }

        private static IProviderLanguage provider = CreateProviderLanguage();
        public static string GetLabel(string lexicon)
        {
            return provider.GetLabel(lexicon);
        }
    }

    public class ExceptionNotTranslate : Exception
    {
        public ExceptionNotTranslate(string msg) : base(msg) { }
    }
}
