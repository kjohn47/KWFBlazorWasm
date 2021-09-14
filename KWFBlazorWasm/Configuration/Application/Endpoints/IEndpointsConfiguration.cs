namespace KWFBlazorWasm.Configuration.Application.Endpoints
{
    using System.Collections.Generic;

    public interface IEndpointsConfiguration
    {
        EndpointDefinition TranslationsEndpoint { get; }
        EndpointDefinition AuthenticationEndpoint { get; }
        EndpointDefinition HomepageEndpoint { get; }
        EndpointDefinition GetCustomEnpoint(string key);
    }
}
