namespace KWFBlazorWasm.Extensions
{
    using System;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using KWFBlazorWasm.Configuration.Application;
    using KWFBlazorWasm.Configuration.Assemblies;
    using KWFBlazorWasm.Configuration.Json;
    using KWFBlazorWasm.KwfComponents;
    using KWFBlazorWasm.Context.Language;
    using KWFBlazorWasm.JsAccessor;
    using KWFBlazorWasm.RestClient;
    using KWFBlazorWasm.Context.Authentication;
    using KWFBlazorWasm.Context.Application;

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
                    .AddSingleton<IApplicationContext>(sp => new ApplicationContext(appConfig, appAssemblyConfig)
                                                           .SetInitializeActions(options.OnInitializeActions)
                                                           .SetInitializeActionsAsync(options.OnInitializeActionsAsync))
                    .AddSingleton<IBrowserStorageAccessor, BrowserStorageAccessor>()
                    .AddScoped<IKwfHttpClient>(sp => {
                        if (!string.IsNullOrEmpty(options.OverrideApiHttpClientUrl))
                        {
                            return new KwfHttpClient(
                                new Uri(options.OverrideApiHttpClientUrl), 
                                sp.GetService<IApplicationContext>())
                            .SetCustomHeaders(options.OverrideAuthorizationHeader);
                        }

                        return new KwfHttpClient(
                            new Uri(builder.HostEnvironment.BaseAddress), 
                            sp.GetService<IApplicationContext>())
                        .SetCustomHeaders(options.OverrideAuthorizationHeader);
                    })
                    .AddScoped<ILanguageContextInitializer>(sp => {
                        if (!string.IsNullOrEmpty(options.DefaultLanguageCode))
                        {
                            return LanguageContext.CreateInstance(options.DefaultLanguageCode, sp);
                        }

                        return LanguageContext.CreateInstance(sp);
                    })
                    .AddScoped<IAuthenticationContextInitializer, AuthenticationContext>();

            builder.RootComponents.Add<KwfApp>(options.OverrideAppIdSelector?? "#app");

            return builder;
        }
    }
}
