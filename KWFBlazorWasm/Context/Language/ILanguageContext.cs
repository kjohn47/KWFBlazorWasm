namespace KWFBlazorWasm.Context.Language
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILanguageContext
    {
        string LanguageCode { get; }
        bool IsLoading { get; }
        IDictionary<string, string> Languages { get; }
        Task ChangeLanguage(string code);
        string GetMenuTranslation(string token);
        string GetErrorTranslation(string token);
        string GetGenericTranslation(string token);
        string GetCustomTranslation(string process, string token);
    }
}
