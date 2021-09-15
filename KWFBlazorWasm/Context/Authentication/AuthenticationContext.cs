namespace KWFBlazorWasm.Context.Authentication
{
    using System;
    using System.Threading.Tasks;

    using KWFBlazorWasm.Context.Application;
    using KWFBlazorWasm.Extensions;
    using KWFBlazorWasm.RestClient;

    public class AuthenticationContext : IAuthenticationContext, IAuthenticationContextInitializer
    {
        private readonly IKwfHttpClient httpClient;
        private readonly IApplicationContext applicationContext;

        public AuthenticationContext(IKwfHttpClient httpClient, IApplicationContext applicationContext)
        {
            if (httpClient is KwfHttpClient kwfHttpClient)
            {
                kwfHttpClient.AddAuthenticationService(this);
            }
            this.httpClient = httpClient;
            this.applicationContext = applicationContext;
            this.IsInitialized = false;
        }

        public string Name { get; private set; }
        public bool IsInitialized { get; set; }

        public async Task<IAuthenticationContext> Initialize()
        {
            //Implement initialize methods that are called after app load like getting the local storage and registering js events
            await Task.Yield();
            this.IsInitialized = true;
            return this;
        }

        public void UpdateName(string value)
        {
            this.Name = value;
            this.applicationContext.ForceAppRender();
        }
    }
}
