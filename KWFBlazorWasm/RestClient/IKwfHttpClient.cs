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
            EndpointDefinition endpointDefinition,
            HttpMethod method,
            HttpContent content = null,
            string additionalRoute = null,
            IDictionary<string, string> queryParams = null,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfGetJsonAsync<TResult>(
            EndpointDefinition endpointDefinition,
            string additionalRoute = null,
            IDictionary<string, string> queryParams = null,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(
            EndpointDefinition endpointDefinition,
            TBody body,
            string additionalRoute = null,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<TResult>> KwfPutJsonAsync<TBody, TResult>(
            EndpointDefinition endpointDefinition,
            TBody body,
            bool authorizedResource = false,
            string additionalRoute = null,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);

        Task<KwfApiResponse<bool>> KwfDeleteAsync(
            EndpointDefinition endpointDefinition,
            string additionalRoute = null,
            bool authorizedResource = false,
            JsonSerializerOptions jsonSerializerOptions = null,
            CancellationToken cancellationToken = default);
    }
}
