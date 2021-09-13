namespace KWFBlazorWasm.Configuration
{
    using System;

    public class EndpointDefinition
    {
        public EndpointDefinition(string endpoint)
        {
            this.Endpoint = endpoint;
            if (this.Endpoint.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                IsAbsolute = true;
            }
        }

        public EndpointDefinition(string endpoint, int port) : this(endpoint)
        {
            this.Port = port;
        }

        public int? Port { get; private set; }
        public string Endpoint { get; private set; }
        public bool IsAbsolute { get; private set; }
    }
}
