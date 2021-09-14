namespace KWFBlazorWasm.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class InitializeKwfAppOptions
    {
        public string DefaultLanguageCode { get; set; }
        public string OverrideApiHttpClientUrl { get; set; }
        public string OverrideAuthorizationHeader { get; set; }
        public string OverrideAppIdSelector { get; set; }
        public IList<Action> OnInitializeActions { get; set; }
        public IList<Task> OnInitializeActionsAsync { get; set; }
    }
}
