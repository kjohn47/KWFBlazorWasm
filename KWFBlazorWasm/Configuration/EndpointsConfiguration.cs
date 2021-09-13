namespace KWFBlazorWasm.Configuration
{
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
    }
}
