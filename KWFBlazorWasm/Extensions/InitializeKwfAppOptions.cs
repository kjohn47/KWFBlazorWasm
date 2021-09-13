namespace KWFBlazorWasm.Extensions
{
    public class InitializeKwfAppOptions
    {
        public string DefaultLanguageCode { get; set; }
        public string OverrideApiHttpClientUrl { get; set; }
        public string OverrideAuthorizationHeader { get; set; }
        public string OverrideAppIdSelector { get; set; }
    }
}
