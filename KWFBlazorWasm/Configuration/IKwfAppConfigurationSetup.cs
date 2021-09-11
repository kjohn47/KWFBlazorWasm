namespace KWFBlazorWasm.Configuration
{
    using System;

    using Microsoft.AspNetCore.Components;

    using KWFBlazorWasm.Builder;

    public interface IKwfAppConfigurationSetup
    {
        IKwfAppConfigurationSetup AddNotFoundErrorOverride<TComponent>(Action<IAttributeBuilder> attributeBuilder = null)
            where TComponent : notnull, IComponent;
        IKwfAppConfigurationSetup AddOverrideMainLayout<TLayout>()
        where TLayout : LayoutComponentBase;
        IKwfAppConfigurationSetup AddOverrideMainLayout(Type layoutType);
        IKwfAppConfiguration Build();
    }
}
