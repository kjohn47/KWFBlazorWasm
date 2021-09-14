namespace KWFBlazorWasm.Configuration.Application
{
    public interface IKwfAppConfigurationHomepageEndpointSetup
    {
        IKwfAppConfigurationSetup ConfigureHomepageEndpoint(string endpoint);
        IKwfAppConfigurationSetup ConfigureHomepageEndpoint(string endpoint, int port);
    }
}
