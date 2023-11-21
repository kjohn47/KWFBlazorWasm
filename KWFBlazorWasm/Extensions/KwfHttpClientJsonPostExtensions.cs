namespace KWFBlazorWasm.Extensions
{
    using KWFBlazorWasm.Configuration.Application.Endpoints;
    using KWFBlazorWasm.RestClient;

    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public static class KwfHttpClientJsonPostExtensions
    {
        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, string endpointDefinitionKey, TBody value, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinitionKey, value, null, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, string endpointDefinitionKey, TBody value, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinitionKey, value, null, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, string endpointDefinitionKey, TBody value, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinitionKey, value, null, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, string endpointDefinitionKey, TBody value, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinitionKey, value, null, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, string endpointDefinitionKey, TBody value, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinitionKey, value, additionalRoute, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, string endpointDefinitionKey, TBody value, string additionalRoute, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinitionKey, value, additionalRoute, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, string endpointDefinitionKey, TBody value, IDictionary<string, string> queryParams, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinitionKey, value, additionalRoute, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TBody value, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinition, value, null, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TBody value, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinition, value, null, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TBody value, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinition, value, null, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TBody value, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinition, value, null, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TBody value, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinition, value, additionalRoute, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TBody value, string additionalRoute, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinition, value, additionalRoute, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TBody value, IDictionary<string, string> queryParams, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfPostJsonAsync<TBody, TResult>(endpointDefinition, value, additionalRoute, queryParams, authorizedResource, null, cancellationToken);
        }
    }
}
