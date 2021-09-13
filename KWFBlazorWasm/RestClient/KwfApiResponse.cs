using KWFBlazorWasm.Common;

using System.Net;

namespace KWFBlazorWasm.RestClient
{
    public class KwfApiResponse<TResponse>
    {
        private KwfApiResponse(TResponse response, HttpStatusCode httpStatusCode)
        {
            this.Response = response;
            this.HttpStatusCode = httpStatusCode;
            Error = NullableObject<ErrorResult>.EmptyResult();
        }

        private KwfApiResponse(ErrorResult error, HttpStatusCode httpStatusCode)
        {
            this.Error = NullableObject<ErrorResult>.FromResult(error);
            this.HttpStatusCode = httpStatusCode;
        }

        public TResponse Response { get; private set; }

        public HttpStatusCode HttpStatusCode { get; private set; }

        public NullableObject<ErrorResult> Error { get; private set; }

        public static KwfApiResponse<TResponse> CreateSuccess(TResponse response, HttpStatusCode httpStatusCode)
        {
            return new KwfApiResponse<TResponse>(response, httpStatusCode);
        }

        public static KwfApiResponse<TResponse> CreateError(ErrorResult error, HttpStatusCode httpStatusCode)
        {
            return new KwfApiResponse<TResponse>(error, httpStatusCode);
        }
    }
}
