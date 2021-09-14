namespace KWFBlazorWasm.Configuration.Json
{
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class KwfJsonSerializerOptions
    {
        public KwfJsonSerializerOptions()
        {
            this.JsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true
            };
        }

        public JsonSerializerOptions JsonSerializerOptions { get; private set; }
    }
}
