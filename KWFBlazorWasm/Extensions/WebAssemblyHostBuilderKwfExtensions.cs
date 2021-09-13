namespace KWFBlazorWasm.Extensions
{
    using System;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using KWFBlazorWasm.Configuration;
    using KWFBlazorWasm.KwfComponents;
    using KWFBlazorWasm.Context.Language;
    using KWFBlazorWasm.JsAccessor;
    using System.Net.Http;
    using KWFBlazorWasm.RestClient;

    public static class WebAssemblyHostBuilderKwfExtensions
    {
        public static WebAssemblyHostBuilder InitializeKwfApp(this WebAssemblyHostBuilder builder,
                                                                   IAppAssemblyInjector appAssemblyConfig,
                                                                   IKwfAppConfiguration appConfig,
                                                                   Action<InitializeKwfAppOptions> appOptions)
        {
            var options = new InitializeKwfAppOptions();
            appOptions.Invoke(options);

            builder.Services
                    .AddSingleton<KwfJsonSerializerOptions>()
                    .AddSingleton<IAppAssemblyInjector>(appAssemblyConfig)
                    .AddSingleton<IKwfAppConfiguration>(appConfig)
                    .AddSingleton<IBrowserStorageAccessor, BrowserStorageAccessor>()
                    .AddScoped(sp => {
                        if (!string.IsNullOrEmpty(options.OverrideApiHttpClientUrl))
                        {
                            return new KwfHttpClient(new Uri(options.OverrideApiHttpClientUrl), sp.GetService<IKwfAppConfiguration>(), sp.GetService<KwfJsonSerializerOptions>());
                        }

                        return new KwfHttpClient(new Uri(builder.HostEnvironment.BaseAddress), sp.GetService<IKwfAppConfiguration>(), sp.GetService<KwfJsonSerializerOptions>());
                    })
                    .AddScoped<ILanguageContextInitializer>(sp => {
                        if (!string.IsNullOrEmpty(options.DefaultLanguageCode))
                        {
                            return LanguageContext.CreateInstance(options.DefaultLanguageCode, sp);
                        }

                        return LanguageContext.CreateInstance(sp);
                    });

            builder.RootComponents.Add<KwfApp>("#app");

            return builder;
        }
    }
}
