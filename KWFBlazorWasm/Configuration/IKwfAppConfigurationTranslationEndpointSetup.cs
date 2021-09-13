namespace KWFBlazorWasm.Configuration
{
    public interface IKwfAppConfigurationTranslationEndpointSetup
    {
        IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint);
        IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint, int port);
    }
}
