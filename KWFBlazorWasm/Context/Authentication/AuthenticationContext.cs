namespace KWFBlazorWasm.Context.Authentication
{
    using KWFBlazorWasm.Context.Application;
    using KWFBlazorWasm.RestClient;

    using System;
    public class AuthenticationContext : IAuthenticationContext
    {
        private readonly IKwfHttpClient httpClient;
        private readonly IApplicationContext applicationContext;

        public AuthenticationContext(IKwfHttpClient httpClient, IApplicationContext applicationContext)
        {
            (httpClient as KwfHttpClient).AddAuthenticationService(this);
            this.httpClient = httpClient;
            this.applicationContext = applicationContext;
        }

        public string Name { get; private set; }

        public void UpdateName(string value)
        {
            this.Name = value;
            this.applicationContext.ForceAppRender();
        }
    }
}
