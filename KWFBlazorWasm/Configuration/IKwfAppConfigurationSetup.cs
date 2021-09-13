namespace KWFBlazorWasm.Configuration
{
    using System;

    using Microsoft.AspNetCore.Components;

    using KWFBlazorWasm.Builder;

    public interface IKwfAppConfigurationSetup
    {
        IKwfAppConfigurationSetup AddCustomEndpoint(string key, string endpoint);
        IKwfAppConfigurationSetup AddCustomEndpoint(string key, string endpoint, int port);
        IKwfAppConfigurationSetup AddNotFoundErrorOverride<TComponent>(Action<IAttributeBuilder> attributeBuilder = null)
            where TComponent : notnull, IComponent;
        IKwfAppConfigurationSetup AddOverrideMainLayout<TLayout>()
        where TLayout : LayoutComponentBase;
        IKwfAppConfigurationSetup AddOverrideMainLayout(Type layoutType);
        IKwfAppConfigurationMenuSetup AddMenuEntry(Action<MenuOptions> options);
        IKwfAppConfiguration Build();
    }
}
