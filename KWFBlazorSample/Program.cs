namespace KWFBlazorSample
{
    using KWFBlazorSample.Shared;

    using KWFBlazorWasm.Configuration;
    using KWFBlazorWasm.Context.Language;
    using KWFBlazorWasm.JsAccessor;
    using KWFBlazorWasm.KwfComponents;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var config = KwfAppConfiguration.CreateConfiguration()
            /*
            .AddNotFoundErrorOverride<KwfError>(builder =>
            {
                builder.AddAttribute("ErrorTitleToken", "Custom error title")
                       .AddAttribute("ErrorMessageToken", "Custom error message");
            })*/
            .AddOverrideMainLayout<MainLayout>()            
            .Build();

            builder.Services
                .AddSingleton<KwfJsonSerializerOptions>()
                .AddSingleton<IAppAssemblyInjector>(AppAssemblyInjector.Initialize(typeof(Program)).Build())
                .AddSingleton<IKwfAppConfiguration>(config)
                .AddSingleton<IBrowserStorageAccessor, BrowserStorageAccessor>()
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddScoped<ILanguageContextInitializer>(sp => LanguageContext.CreateInstance("PT", sp));

            builder.RootComponents.Add<KwfApp>("#app");

            await builder.Build().RunAsync();
        }
    }
}
