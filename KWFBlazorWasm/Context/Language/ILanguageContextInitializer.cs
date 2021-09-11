namespace KWFBlazorWasm.Context.Language
{
    using System.Threading.Tasks;

    public interface ILanguageContextInitializer
    {
        bool IsInitialized { get; }
        Task<ILanguageContext> InitializeLanguageContext();
    }
}
