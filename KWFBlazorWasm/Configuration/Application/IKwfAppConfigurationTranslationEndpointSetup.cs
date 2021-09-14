namespace KWFBlazorWasm.Configuration.Application
{
    public interface IKwfAppConfigurationTranslationEndpointSetup
    {
        IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint);
        IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint, int port);
    }
}
