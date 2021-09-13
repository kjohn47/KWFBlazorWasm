namespace KWFBlazorWasm.RestClient
{
    using System.Collections.Generic;
    using System.Net;

    public class ErrorResult
    {
        public bool WithErrors { get; set; }
        public HttpStatusCode ErrorStatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorProperty { get; set; }
        public string ErrorType { get; set; }
        public string ErrorCode { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public bool IsValidationError { get; set; }
    }
}
