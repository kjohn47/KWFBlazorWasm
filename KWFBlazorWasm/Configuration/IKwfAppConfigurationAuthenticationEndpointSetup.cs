namespace KWFBlazorWasm.Configuration
{
    public interface IKwfAppConfigurationAuthenticationEndpointSetup
    {
        IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint);
        IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint, int port);
    }
}
