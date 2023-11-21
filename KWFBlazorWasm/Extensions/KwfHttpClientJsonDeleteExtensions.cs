namespace KWFBlazorWasm.Extensions
{
    using KWFBlazorWasm.Configuration.Application.Endpoints;
    using KWFBlazorWasm.RestClient;

    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public static class KwfHttpClientJsonDeleteExtensions
    {
        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, string endpointDefinitionKey, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinitionKey, null, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, string endpointDefinitionKey, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinitionKey, null, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, string endpointDefinitionKey, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinitionKey, null, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, string endpointDefinitionKey, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinitionKey, null, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, string endpointDefinitionKey, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinitionKey, additionalRoute, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, string endpointDefinitionKey, string additionalRoute, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinitionKey, additionalRoute, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, string endpointDefinitionKey, IDictionary<string, string> queryParams, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinitionKey, additionalRoute, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, null, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, null, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, null, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, null, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, additionalRoute, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, additionalRoute, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> KwfDeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, additionalRoute, queryParams, authorizedResource, null, cancellationToken);
        }
    }
}
