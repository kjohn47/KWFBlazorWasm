namespace KWFBlazorWasm.Configuration.Application.Endpoints
{
    using System;
    using System.Collections.Generic;

    public class EndpointsConfiguration : IEndpointsConfiguration
    {
        public EndpointsConfiguration()
        {
            this.EndpointDictionary = new Dictionary<string, EndpointDefinition>();
        }

        public EndpointDefinition TranslationsEndpoint { get; set; }
        public EndpointDefinition AuthenticationEndpoint { get; set; }
        public EndpointDefinition HomepageEndpoint { get; set; }
        public IDictionary<string, EndpointDefinition> EndpointDictionary { get; set; }

        public EndpointDefinition GetCustomEnpoint(string key)
        {
            if (this.EndpointDictionary.TryGetValue(key, out var endpoint))
            {
                return endpoint;
            }

            throw new NullReferenceException($"No endpoint defined for {key} in configuration");
        }
    }
}
