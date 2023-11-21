namespace KWFBlazorWasm.Extensions
{
    using KWFBlazorWasm.Configuration.Application.Endpoints;
    using KWFBlazorWasm.RestClient;

    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public static class KwfHttpClientJsonGetExtensions
    {
        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, string endpointDefinitionKey, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinitionKey, null, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, string endpointDefinitionKey, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinitionKey, null, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, string endpointDefinitionKey, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinitionKey, null, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, string endpointDefinitionKey, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinitionKey, null, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, string endpointDefinitionKey, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinitionKey, additionalRoute, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, string endpointDefinitionKey, string additionalRoute, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinitionKey, additionalRoute, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, string endpointDefinitionKey, IDictionary<string, string> queryParams, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinitionKey, additionalRoute, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, additionalRoute, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, additionalRoute, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> KwfGetJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, additionalRoute, queryParams, authorizedResource, null, cancellationToken);
        }
    }
}
