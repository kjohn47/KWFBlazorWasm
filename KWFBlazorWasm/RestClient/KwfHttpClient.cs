namespace KWFBlazorWasm.RestClient
{
    using KWFBlazorWasm.Configuration.Application;
    using KWFBlazorWasm.Configuration.Application.Endpoints;
    using KWFBlazorWasm.Configuration.Json;
    using KWFBlazorWasm.Context.Authentication;
    using KWFBlazorWasm.Context.Language;

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

    public class KwfHttpClient : HttpClient, IKwfHttpClient
    {
        private readonly IKwfAppConfiguration configuration;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private AuthenticationContext authenticationContext;
        private ILanguageContext languageContext;
        private string authorizationHeaderKey;

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

        public void AddAuthenticationService(AuthenticationContext authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }

        public void AddLanguageService(ILanguageContext languageContext)
        {
            this.languageContext = languageContext;
        }

        public KwfHttpClient SetCustomHeaders(string authorizationKey)
        {
            this.authorizationHeaderKey = authorizationKey;
            return this;
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
            try
            {
                var response = await this.KwfSendAsync(endpointDefinition, method, content, additionalRoute, queryParams, authorizedResource, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    return KwfApiResponse<TResult>.CreateSuccess(
                        await JsonSerializer.DeserializeAsync<TResult>(
                            await response.Content.ReadAsStreamAsync(cancellationToken), jsonSerializerOptions ?? this.jsonSerializerOptions, cancellationToken),
                        response.StatusCode);
                }
                try
                {
                    return KwfApiResponse<TResult>.CreateError(
                        await JsonSerializer.DeserializeAsync<ErrorResult>(
                            await response.Content.ReadAsStreamAsync(cancellationToken), jsonSerializerOptions ?? this.jsonSerializerOptions, cancellationToken),
                        response.StatusCode);
                }
                catch
                {
                    return KwfApiResponse<TResult>.CreateError(new ErrorResult
                    {
                        ErrorCode = "RESPONSEERR",
                        ErrorMessage = await response.Content.ReadAsStringAsync(),
                        ErrorStatusCode = response.StatusCode,
                        ErrorType = "Error"
                    }, response.StatusCode);
                }
            }
            catch(HttpRequestException httpReqEx)
            {
                return KwfApiResponse<TResult>.CreateError(new ErrorResult { 
                    ErrorCode = "RequestException",
                    ErrorMessage = httpReqEx.Message,
                    ErrorStatusCode = httpReqEx.StatusCode?? HttpStatusCode.InternalServerError,
                    ErrorType = "Exception"
                }, httpReqEx.StatusCode ?? HttpStatusCode.InternalServerError);
            }
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
            try
            {
                var response = await this.KwfSendAsync(endpointDefinition, HttpMethod.Delete, null, additionalRoute, null, authorizedResource, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return KwfApiResponse<bool>.CreateSuccess(true, response.StatusCode);
                }

                try
                {
                    return KwfApiResponse<bool>.CreateError(
                        await JsonSerializer.DeserializeAsync<ErrorResult>(
                            await response.Content.ReadAsStreamAsync(cancellationToken), jsonSerializerOptions ?? this.jsonSerializerOptions, cancellationToken),
                        response.StatusCode);
                }
                catch
                {
                    return KwfApiResponse<bool>.CreateError(new ErrorResult
                    {
                        ErrorCode = "RESPONSEERR",
                        ErrorMessage = await response.Content.ReadAsStringAsync(),
                        ErrorStatusCode = response.StatusCode,
                        ErrorType = "Error"
                    }, response.StatusCode);
                }
            }
            catch (HttpRequestException httpReqEx)
            {
                return KwfApiResponse<bool>.CreateError(new ErrorResult
                {
                    ErrorCode = "RequestException",
                    ErrorMessage = httpReqEx.Message,
                    ErrorStatusCode = httpReqEx.StatusCode ?? HttpStatusCode.InternalServerError,
                    ErrorType = "Exception"
                }, httpReqEx.StatusCode ?? HttpStatusCode.InternalServerError);
            }
        }

        private async Task<HttpResponseMessage> KwfSendAsync(
            EndpointDefinition endpointDefinition,
            HttpMethod method,
            HttpContent content = null,
            string additionalRoute = null,
            IDictionary<string, string> queryParams = null,
            bool authorizedResource = false,
            CancellationToken cancellationToken = default)
        {
            if (authorizedResource && this.authenticationContext == null)
            {
                throw new ArgumentNullException("AuthenticationContext", "To use authorized resources, you must set the Authentication Context");
            }

            var requestUri = this.BuildUri(endpointDefinition, additionalRoute, queryParams);

            if (this.authenticationContext != null)
            {
                //to be called to force logout
                this.authenticationContext.UpdateName(requestUri.ToString());
            }

            var request = new HttpRequestMessage(method, requestUri);
            request.Content = content;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (authorizedResource)
            {
                if (string.IsNullOrEmpty(this.authorizationHeaderKey))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer token");
                }
                else
                {
                    request.Headers.Add(this.authorizationHeaderKey, "Bearer token");
                }
            }

            if (!string.IsNullOrEmpty(this.languageContext?.LanguageCode))
            {
                request.Headers.Add("app-language", this.languageContext.LanguageCode);
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (authorizedResource && !response.IsSuccessStatusCode && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
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

            return response;
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
