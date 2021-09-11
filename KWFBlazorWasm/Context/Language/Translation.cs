namespace KWFBlazorWasm.Context.Language
{
    using System.Collections.Generic;

    public class Translation
    {
        public IDictionary<string, string> Menu { get; set; }
        public IDictionary<string, string> Generic { get; set; }
        public IDictionary<string, string> Errors { get; set; }
        public IDictionary<string, IDictionary<string, string>> Custom { get; set; }
    }
}
