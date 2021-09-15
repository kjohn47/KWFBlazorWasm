namespace KWFBlazorWasm.Context.Authentication
{
    using System.Threading.Tasks;

    public interface IAuthenticationContextInitializer
    {
        Task<IAuthenticationContext> Initialize();
        bool IsInitialized { get; }
    }
}
