namespace KWFBlazorWasm.Configuration
{
    using System.Collections.Generic;

    public interface IEndpointsConfiguration
    {
        EndpointDefinition TranslationsEndpoint { get; }
        EndpointDefinition AuthenticationEndpoint { get; }
        EndpointDefinition HomepageEndpoint { get; }
        IDictionary<string, EndpointDefinition> EndpointDictionary { get; }
    }
}
