namespace KWFBlazorWasm.Configuration.Application
{
    using System;

    using Microsoft.AspNetCore.Components;

    using KWFBlazorWasm.Builder;
    using System.Collections.Generic;
    using System.Linq;
    using KWFBlazorWasm.Configuration.Application.Endpoints;
    using KWFBlazorWasm.Configuration.Application.Menu;

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
            this.endpointsConfiguration.HomepageEndpoint = new EndpointDefinition(endpoint);
            return this;
        }

        public IKwfAppConfigurationSetup ConfigureHomepageEndpoint(string endpoint, int port)
        {
            this.endpointsConfiguration.HomepageEndpoint = new EndpointDefinition(endpoint, port);
            return this;
        }

        public IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint)
        {
            this.endpointsConfiguration.TranslationsEndpoint = new EndpointDefinition(endpoint);
            return this;
        }

        public IKwfAppConfigurationHomepageEndpointSetup ConfigureTranslationEndpoint(string endpoint, int port)
        {
            this.endpointsConfiguration.TranslationsEndpoint = new EndpointDefinition(endpoint, port);
            return this;
        }

        public IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint)
        {
            this.endpointsConfiguration.AuthenticationEndpoint = new EndpointDefinition(endpoint);
            return this;
        }

        public IKwfAppConfigurationTranslationEndpointSetup ConfigureAuthenticationEndpoint(string endpoint, int port)
        {
            this.endpointsConfiguration.AuthenticationEndpoint = new EndpointDefinition(endpoint, port);
            return this;
        }

        public IKwfAppConfigurationSetup AddCustomEndpoint(string key, string endpoint)
        {
            this.endpointsConfiguration.EndpointDictionary.Add(key, new EndpointDefinition(endpoint));
            return this;
        }

        public IKwfAppConfigurationSetup AddCustomEndpoint(string key, string endpoint, int port)
        {
            this.endpointsConfiguration.EndpointDictionary.Add(key, new EndpointDefinition(endpoint, port));
            return this;
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
