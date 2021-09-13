namespace KWFBlazorWasm.RestClient
{
    using KWFBlazorWasm.Configuration;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public class KwfHttpClient : HttpClient
    {
        private readonly IKwfAppConfiguration configuration;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public KwfHttpClient(Uri uri, IKwfAppConfiguration configuration, KwfJsonSerializerOptions serializerDefaultOptions) : base()
        {
            this.BaseAddress = uri;
            this.configuration = configuration;
            this.jsonSerializerOptions = serializerDefaultOptions.JsonSerializerOptions;
        }

        public KwfHttpClient(IKwfAppConfiguration configuration, KwfJsonSerializerOptions serializerDefaultOptions) : base()
        {
            this.configuration = configuration;
            this.jsonSerializerOptions = serializerDefaultOptions.JsonSerializerOptions;
        }

        public async Task<HttpResponseMessage> KwfSendAsync(
            EndpointDefinition endpointDefinition, 
            HttpMethod method, 
            HttpContent content = null,
            string additionalRoute = null, 
            IDictionary<string, string> queryParams = null,
            bool authorizedResource = false,
            CancellationToken cancellationToken = default)
        {
            var requestUri = this.BuildUri(endpointDefinition, additionalRoute, queryParams);

            var request = new HttpRequestMessage(method, requestUri);
            request.Content = content;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (authorizedResource)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer token");
            }

            var response = await base.SendAsync(request, cancellationToken);
            if (authorizedResource)
            {
                if (!response.IsSuccessStatusCode && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    if (response.Headers.WwwAuthenticate.Any(x => x.Parameter.Equals("KRWREFRESH")))
                    {
                        //Execute refresh token process
                        //Update token on new request
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer token");
                        response = await base.SendAsync(request, cancellationToken);
                    }

                    //logout
                }
            }

            return response;
        }

        public async Task<KwfApiResponse<TResult>> KwfSendAsync<TResult>(
            EndpointDefinition endpointDefinition,
            HttpMethod method, 
            HttpContent content = null,
            string additionalRoute = null,
            IDictionary<string, string> queryParams = null, 
            bool authorizedResource = false, 
            JsonSerializerOptions jsonSerializerOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var response = await this.KwfSendAsync(endpointDefinition, method, content, additionalRoute, queryParams, authorizedResource, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return KwfApiResponse<TResult>.CreateSuccess(
                    await JsonSerializer.DeserializeAsync<TResult>(
                        await response.Content.ReadAsStreamAsync(cancellationToken), jsonSerializerOptions ?? this.jsonSerializerOptions, cancellationToken),
                    response.StatusCode);
            }

            return KwfApiResponse<TResult>.CreateError(
                await JsonSerializer.DeserializeAsync<ErrorResult>(
                    await response.Content.ReadAsStreamAsync(cancellationToken), jsonSerializerOptions ?? this.jsonSerializerOptions, cancellationToken),
                response.StatusCode);
        }

        public Task<KwfApiResponse<TResult>> KwfGetJsonAsync<TResult>(
            EndpointDefinition endpointDefinition,
            string additionalRoute = null,
            IDictionary<string, string> queryParams = null,
            bool authorizedResource = false, 
            JsonSerializerOptions jsonSerializerOptions = null, 
            CancellationToken cancellationToken = default)
        {
            return this.KwfSendAsync<TResult>(endpointDefinition, HttpMethod.Get, null, additionalRoute, queryParams, authorizedResource, jsonSerializerOptions, cancellationToken);
        }

        public Task<KwfApiResponse<TResult>> KwfPostJsonAsync<TBody, TResult>(
            EndpointDefinition endpointDefinition, 
            TBody body,
            string additionalRoute = null,
            bool authorizedResource = false, 
            JsonSerializerOptions jsonSerializerOptions = null, 
            CancellationToken cancellationToken = default)
        {
            return this.KwfSendAsync<TResult>(endpointDefinition, HttpMethod.Post, this.GetStringifiedContent(body, jsonSerializerOptions), additionalRoute, null, authorizedResource, jsonSerializerOptions, cancellationToken);
        }

        public Task<KwfApiResponse<TResult>> KwfPutJsonAsync<TBody, TResult>(
            EndpointDefinition endpointDefinition, 
            TBody body, 
            bool authorizedResource = false,
            string additionalRoute = null,
            JsonSerializerOptions jsonSerializerOptions = null, 
            CancellationToken cancellationToken = default)
        {
            return this.KwfSendAsync<TResult>(endpointDefinition, HttpMethod.Put, this.GetStringifiedContent(body, jsonSerializerOptions), additionalRoute, null, authorizedResource, jsonSerializerOptions, cancellationToken);
        }

        public async Task<KwfApiResponse<bool>> KwfDeleteAsync(
            EndpointDefinition endpointDefinition,
            string additionalRoute = null,
            bool authorizedResource = false, 
            JsonSerializerOptions jsonSerializerOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await this.KwfSendAsync(endpointDefinition, HttpMethod.Delete, null, additionalRoute, null, authorizedResource, cancellationToken);
            if (result.IsSuccessStatusCode)
            {
                return KwfApiResponse<bool>.CreateSuccess(true, result.StatusCode);
            }

            var error = await JsonSerializer.DeserializeAsync<ErrorResult>(await result.Content.ReadAsStreamAsync(cancellationToken), jsonSerializerOptions ?? this.jsonSerializerOptions, cancellationToken);

            return KwfApiResponse<bool>.CreateError(error, result.StatusCode);
        }

        private Uri BuildUri(EndpointDefinition endpointDefinition, string additionalRoute = null, IDictionary<string, string> queryParams = null)
        {
            if (endpointDefinition.IsAbsolute || this.BaseAddress == null)
            {
                var builder = new UriBuilder(GetQueryString(endpointDefinition.Endpoint, additionalRoute, queryParams));
                if (endpointDefinition.Port.HasValue)
                {
                    builder.Port = endpointDefinition.Port.Value;
                }
                return builder.Uri;
            }

            if (endpointDefinition.Port.HasValue)
            {
                var builder = new UriBuilder(this.BaseAddress);
                builder.Port = endpointDefinition.Port.Value;
                return new Uri(builder.Uri, GetQueryString(endpointDefinition.Endpoint, additionalRoute, queryParams));
            }

            return new Uri(this.BaseAddress, GetQueryString(endpointDefinition.Endpoint, additionalRoute, queryParams));
        }

        private static string GetQueryString(string endpoint, string additionalRoute = null, IDictionary<string, string> queryParams = null)
        {
            if (string.IsNullOrEmpty(additionalRoute) && queryParams == null)
            {
                return endpoint;
            }

            var builder = new StringBuilder(endpoint);

            if (!string.IsNullOrEmpty(additionalRoute))
            {
                if (!(endpoint.EndsWith('/') || additionalRoute.StartsWith('/')))
                {
                    builder.Append('/');
                }

                builder.Append((endpoint.EndsWith('/') && additionalRoute.StartsWith('/')) ? additionalRoute.Substring(1) : additionalRoute);
            }

            if (queryParams != null && queryParams.Count > 0)
            {
                var firstParam = true;
                foreach (var param in queryParams)
                {
                    if (firstParam)
                    {
                        builder.Append('?');
                        firstParam = false;
                    }
                    else
                    {
                        builder.Append('&');
                    }

                    builder.Append(param.Key);
                    builder.Append('=');
                    builder.Append(param.Value);
                }
            }

            return builder.ToString();
        }

        private StringContent GetStringifiedContent<TReq>(TReq request, JsonSerializerOptions jsonSerializerOptions = null)
        {
            return new StringContent(JsonSerializer.Serialize(request, jsonSerializerOptions ?? this.jsonSerializerOptions), Encoding.UTF8);
        }
    }
}
