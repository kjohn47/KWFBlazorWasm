using KWFBlazorSample;

using KWFBlazorWasm.Configuration.Application;
using KWFBlazorWasm.Configuration.Assemblies;
using KWFBlazorWasm.Extensions;

using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var assembliesConfig = AppAssemblyInjector.Initialize(typeof(Program)).Build();

var config = KwfAppConfiguration.CreateConfiguration()
    .ConfigureAuthenticationEndpoint("authenticate")
    .ConfigureTranslationEndpoint("homepage/translations")
    .ConfigureHomepageEndpoint("homepage")
    .AddCustomEndpoint("FETCHWEATHER", "sample-data/weather.json")
    /*
        * .AddNotFoundErrorOverride<KwfError>(builder =>
        * {
        *   builder.AddAttribute("ErrorTitleToken", "Custom error title")
        *          .AddAttribute("ErrorMessageToken", "Custom error message");
        * })
        * .AddOverrideMainLayout<MainLayout>()
        */
    .AddMenuEntry(opt =>
    {
        opt.Name = "Main Menu";
    })
        .AddMenuLink(opt => {
            opt.Name = "Root";
            opt.Href = "";
            opt.Match = NavLinkMatch.All;
        })
        .AddMenuLink(opt => {
            opt.Name = "Counter";
            opt.Href = "counter";
        })
        .AddMenuLink(opt => {
            opt.Name = "Fetch Data";
            opt.Href = "fetchdata";
        })
        .AddMenuLink(opt => {
            opt.Name = "Not Found";
            opt.Href = "inexistentLink";
        })
        .AddMenuLink(opt => {
            opt.Name = "Google";
            opt.Href = "https://www.google.pt";
        })
        .CreateMenu()
    .Build();

builder.InitializeKwfApp(assembliesConfig, config, opt => {
    opt.DefaultLanguageCode = "PT";
});

await builder.Build().RunAsync();