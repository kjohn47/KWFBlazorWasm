namespace KWFBlazorWasm.Extensions
{
    using KWFBlazorWasm.Configuration.Application.Endpoints;
    using KWFBlazorWasm.RestClient;

    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public static class KwfHttpClientJsonExtensions
    {
        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, null, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, IDictionary<string, string> queryParams, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, additionalRoute, queryParams, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, IDictionary<string, string> queryParams, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, additionalRoute, queryParams, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, additionalRoute, null, authorizedResource, options, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> GetFromJsonAsync<TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfGetJsonAsync<TResponse>(endpointDefinition, additionalRoute, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PostAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TRequest value, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PostAsJsonAsync<TRequest, TResponse>(endpointDefinition, null, value, options, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PostAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TRequest value, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PostAsJsonAsync<TRequest, TResponse>(endpointDefinition, null, value, null, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PostAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, TRequest value, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PostAsJsonAsync<TRequest, TResponse>(endpointDefinition, additionalRoute, value, options, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PostAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, TRequest value, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PostAsJsonAsync<TRequest, TResponse>(endpointDefinition, additionalRoute, value, null, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PutAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TRequest value, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PutAsJsonAsync<TRequest, TResponse>(endpointDefinition, null, value, options, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PutAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, TRequest value, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PutAsJsonAsync<TRequest, TResponse>(endpointDefinition, null, value, null, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PutAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, TRequest value, JsonSerializerOptions options, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PutAsJsonAsync<TRequest, TResponse>(endpointDefinition, additionalRoute, value, options, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<TResponse>> PutAsJsonAsync<TRequest, TResponse>(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, TRequest value, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.PutAsJsonAsync<TRequest, TResponse>(endpointDefinition, additionalRoute, value, null, authorizedResource, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> DeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, null, authorizedResource, null, cancellationToken);
        }

        public static Task<KwfApiResponse<bool>> DeleteAsync(this IKwfHttpClient client, EndpointDefinition endpointDefinition, string additionalRoute, bool authorizedResource = false, CancellationToken cancellationToken = default)
        {
            return client.KwfDeleteAsync(endpointDefinition, additionalRoute, authorizedResource, null, cancellationToken);
        }
    }
}
