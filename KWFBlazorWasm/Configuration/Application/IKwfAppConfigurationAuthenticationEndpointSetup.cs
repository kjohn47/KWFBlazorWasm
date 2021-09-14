namespace KWFBlazorWasm.Configuration.Application
{
    public interface IKwfAppConfigurationAuthenticationEndpointSetup
    {
        IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint);
        IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint, int port);
    }
}
