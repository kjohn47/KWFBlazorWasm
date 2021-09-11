namespace KWFBlazorWasm.Configuration
{
    using System;

    using Microsoft.AspNetCore.Components;

    using KWFBlazorWasm.Builder;

    public class KwfAppConfiguration : IKwfAppConfiguration, IKwfAppConfigurationSetup
    {
        private KwfAppConfiguration()
        { }

        public RenderFragment OverrideNotFoundComponent { get; private set; }

        public Type OverrideMainLayout { get; private set; }
        
        public IKwfAppConfigurationSetup AddNotFoundErrorOverride<TComponent>(Action<IAttributeBuilder> attributeBuilder = null)
            where TComponent : notnull, IComponent
        {
            this.OverrideNotFoundComponent = ComponentBuilder.Build<TComponent>(attributeBuilder);
            return this;
        }

        public IKwfAppConfigurationSetup AddOverrideMainLayout<TLayout>()
            where TLayout : LayoutComponentBase
        {
            this.OverrideMainLayout = typeof(TLayout);
            return this;
        }

        public IKwfAppConfigurationSetup AddOverrideMainLayout(Type layoutType)
        {
            if (layoutType.BaseType != typeof(LayoutComponentBase))
            {
                throw new InvalidOperationException($"{layoutType.FullName} doesn't implement {typeof(LayoutComponentBase).FullName}");
            }

            this.OverrideMainLayout = layoutType;
            return this;
        }

        public IKwfAppConfiguration Build()
        {
            return this;
        }

        public static IKwfAppConfigurationSetup CreateConfiguration()
        {
            return new KwfAppConfiguration();
        }        
    }
}
