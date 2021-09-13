namespace KWFBlazorWasm.Configuration
{
    using System;

    using Microsoft.AspNetCore.Components;

    using KWFBlazorWasm.Builder;
    using System.Collections.Generic;
    using System.Linq;

    public class KwfAppConfiguration : IKwfAppConfiguration, 
                                       IKwfAppConfigurationSetup,
                                       IKwfAppConfigurationMenuEntry,
                                       IKwfAppConfigurationAuthenticationEndpointSetup,
                                       IKwfAppConfigurationTranslationEndpointSetup,
                                       IKwfAppConfigurationHomepageEndpointSetup
    {
        private KwfAppConfiguration()
        {
            this.menuDefinition = new List<MenuEntry>();
            this.endpointsConfiguration = new EndpointsConfiguration();
        }

        private IList<MenuEntry> menuDefinition;

        private EndpointsConfiguration endpointsConfiguration;

        public RenderFragment OverrideNotFoundComponent { get; private set; }

        public Type OverrideMainLayout { get; private set; }

        public IEnumerable<IMenuEntry> MenuDefinition => this.menuDefinition;

        public IEndpointsConfiguration Endpoints => this.endpointsConfiguration;

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

        public IKwfAppConfigurationMenuSetup AddMenuEntry(Action<MenuOptions> options)
        {
            var menuEntry = new MenuEntry(this);
            options.Invoke(menuEntry);

            if (string.IsNullOrEmpty(menuEntry.Name))
            {
                throw new ArgumentNullException("Name", "Name cannot be null");
            }

            if (this.menuDefinition.Any(x => x.Name.Equals(menuEntry.Name)))
            {
                throw new ArgumentException("Menu entry name already exists", "Name");
            }

            return menuEntry;
        }

        public IKwfAppConfigurationSetup AddMenuDefinition(MenuEntry menuEntry)
        {
            this.menuDefinition.Add(menuEntry);
            return this;
        }

        public IKwfAppConfigurationSetup ConfigureHomepageEndpoint(string endpoint)
        {
            return this;
        }

        public IKwfAppConfigurationSetup ConfigureHomepageEndpoint(string endpoint, int port)
        {
            return this.ConfigureHomepageEndpoint($"{port}:{endpoint}");
        }

        public IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint)
        {
            return this;
        }

        public IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint, int port)
        {
            return this.ConfigureTranslationEndpoint($"{port}:{endpoint}");
        }

        public IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint)
        {
            return this;
        }

        public IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint, int port)
        {
            return this.ConfigureAuthenticationEndpoint($"{port}:{endpoint}");
        }

        public IKwfAppConfigurationSetup AddCustomEndpoint(string key, string endpoint)
        {
            return this;
        }

        public IKwfAppConfigurationSetup AddCustomEndpoint(string key, string endpoint, int port)
        {
            return this.AddCustomEndpoint(key, $"{port}:{endpoint}");
        }

        public IKwfAppConfiguration Build()
        {
            return this;
        }

        public static IKwfAppConfigurationAuthenticationEndpointSetup CreateConfiguration()
        {
            return new KwfAppConfiguration();
        }
    }
}
