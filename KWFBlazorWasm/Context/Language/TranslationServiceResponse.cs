namespace KWFBlazorWasm.Context.Language
{
    using System.Collections.Generic;

    public class TranslationServiceResponse
    {
        public string SelectedLanguageCode { get; set; }
        public Translation Translation { get; set; }
        public IDictionary<string, string> Languages { get; set; }
    }
}
