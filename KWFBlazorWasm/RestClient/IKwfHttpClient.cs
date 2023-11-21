namespace KWFBlazorWasm.RestClient
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    using KWFBlazorWasm.Configuration.Application.Endpoints;

    public interface IKwfHttpClient
    {
        Task<KwfApiResponse<TResult>> KwfSendAsync<TResult>(
            string endpointDefinitionKey,
            HttpMethod method,
            HttpContent content,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfGetJsonAsync<TResult>(
            string endpointDefinitionKey,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(
            string endpointDefinitionKey,
            TBody body,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfPutJsonAsync<TBody, TResult>(
            string endpointDefinitionKey,
            TBody body,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<bool>> KwfDeleteAsync(
            string endpointDefinitionKey,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfSendAsync<TResult>(
            EndpointDefinition endpointDefinition,
            HttpMethod method,
            HttpContent content,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfGetJsonAsync<TResult>(
            EndpointDefinition endpointDefinition,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(
            EndpointDefinition endpointDefinition,
            TBody body,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfPutJsonAsync<TBody, TResult>(
            EndpointDefinition endpointDefinition,
            TBody body,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<bool>> KwfDeleteAsync(
            EndpointDefinition endpointDefinition,
            string additionalRoute,
            IDictionary<string, string> queryParams,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);
    }
}
